
'  Xfire Profile Patcher
'  ---------------------------
'
'  Copyright © 2009-2012 Fredrik Blomqvist
'
'  This file is part of Xfire Profile Patcher.
'
'    Xfire Profile Patcher is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    Xfire Profile Patcher is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with Xfire Profile Patcher.  If not, see <http://www.gnu.org/licenses/>.

Imports System.IO
Imports System.Text.RegularExpressions
Imports System.ComponentModel
Imports System.Threading
Imports Microsoft.Win32
Imports System.Net


Public Class XfireProfilePatcher

    Private pPatchLabelStatus As PatchStatus
    Private Delegate Sub SetPatchLabelInvoker(color As Color, text As String)
    Private Delegate Sub SetRestoreBtnInvoker(bool As Boolean)

    Public Enum PatchStatus

        Patched
        PartlyPatched
        NotPatched

    End Enum

    Public Enum BwUpdateResult

        Available
        NotAvailable
        ErrorOccured

    End Enum

    Public ReadOnly Property BackupExists As Boolean

        Get
            Return File.Exists(My.Settings.xfireINIPath + ".bak")
        End Get

    End Property

    Public Property PatchLabelStatus As PatchStatus

        Get
            Return pPatchLabelStatus
        End Get

        Set(value As PatchStatus)
            pPatchLabelStatus = value

            Dim color As Color
            Dim text As String = Nothing

            Select Case value

                Case PatchStatus.Patched
                    text = "Xfire is patched"
                    color = color.Green

                Case PatchStatus.PartlyPatched
                    text = "Xfire is partly patched"
                    color = color.DarkOrange

                Case PatchStatus.NotPatched
                    text = "Xfire is not patched"
                    color = color.Red

            End Select

            SetPatchLabel(color, text)

        End Set
    End Property

    Private Sub SetPatchLabel(color As Color, text As String)

        If Me.StatusLabel.InvokeRequired Then
            Me.StatusLabel.Invoke(New SetPatchLabelInvoker(AddressOf SetPatchLabel), color, text)
        Else
            StatusLabel.Text = text
            StatusLabel.ForeColor = color
        End If

    End Sub

    Private Sub SetRestoreBtn(bool As Boolean)

        If Me.btnRestore.InvokeRequired Then
            Me.btnRestore.Invoke(New SetRestoreBtnInvoker(AddressOf SetRestoreBtn), bool)
        Else
            btnRestore.Enabled = bool
        End If

    End Sub

    Public ReadOnly Property Portable As Boolean

        Get
            'Check if the regkey with the path to the program exists, if it doesn't it is portable
            Dim key As RegistryKey
            If Environment.Is64BitOperatingSystem Then

                key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Xfire Profile Patcher")

            Else
                key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Xfire Profile Patcher")
            End If

            Dim value As String = Nothing

            Try
                If key IsNot Nothing Then

                    value = Convert.ToString(key.GetValue("InstallLocation", Nothing))

                Else

                    Return True

                End If

            Catch ex As Exception


            End Try

            If value IsNot Nothing Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property

    Public Sub XfireGamePatcher_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetXfireINIPath()

        Dim args() As String
        Dim i As Integer

        args = Split(Command$, " ")

        For i = LBound(args) To UBound(args)

            Select Case LCase(args(i))

                Case "-nogui", "/nogui"

                    With TrayIcon
                        .Visible = True
                        .BalloonTipText = "Patching Xfire..."
                        .BalloonTipTitle = "XPP " + Application.ProductVersion
                        .Text = "You can't stop me now :P"
                        .ShowBalloonTip(5000)
                        PatchFile(False)
                        .Visible = False
                        .Visible = True
                        .BalloonTipText = "Finished Patching, Have a nice day."
                        .ShowBalloonTip(3000)
                    End With

                    If My.Settings.restartXfire = True Then
                        RestartXfire()
                    End If

                    timerOne.Start()

                    Exit Sub
            End Select

        Next i

        Me.Opacity = 100
        Me.ShowInTaskbar = True

        ThreadPool.QueueUserWorkItem(AddressOf UpdateStatus)

        If My.Settings.CheckForUpdates = True Then

            CheckForUpdates()

        End If

    End Sub

    Private Sub RestartXfire()

        Dim path As String = XfireEXEPath()
        Process.Start(path, "/quit")

        Dim sw As New Stopwatch
        sw.Start()
        Do While sw.ElapsedMilliseconds < 3000
            ' Allows UI to remain responsive
            Application.DoEvents()
        Loop

        Process.Start(path, "/minimized")

    End Sub

    Public Function IsOSVersionOld() As Boolean

        Dim os As OperatingSystem = Environment.OSVersion
        Dim osInfo As Version = os.Version

        Select Case osInfo.Major

            Case Is < 6

                Return True

            Case Is >= 6

                Return False

        End Select

        Return True

    End Function

    Public Function XfireEXEPath() As String

        If IsOSVersionOld() Then

            If Environment.Is64BitOperatingSystem Then

                Return My.Computer.Registry.LocalMachine.GetValue("SOFTWARE\WoW6432Node\Xfire", "", Nothing).ToString + "\Xfire.exe"

            Else

                Return My.Computer.Registry.LocalMachine.GetValue("SOFTWARE\Xfire", "", Nothing).ToString + "\Xfire.exe"

            End If

        Else

            Dim ini As New INIAccess
            Return ini.INIRead(Path.GetDirectoryName(My.Settings.xfireINIPath) + "\Xfire.ini", "Xfire", "ProgramPath", Nothing).ToString & "\Xfire.exe"

        End If

    End Function

    Private Function GetVersion(ByVal version As Version) As Object

        Return (String.Format("{0}.{1}{2}{3}", version.Major, version.Minor, If(version.Build = 0 AndAlso version.Revision = 0, String.Empty, "." + version.Build.ToString()), If(version.Revision = 0, String.Empty, "." + version.Revision.ToString())))

    End Function

    Public Sub UpdateStatus(ByVal state As Object)

        Dim patchCount As Integer = 0

        Dim ini As New INIAccess
        Dim path As String = My.Settings.xfireINIPath()

        If path IsNot Nothing Then

            If ini.INIRead(path, "-1", "PatchedByXPP", "0") = "1" Then
                'The file is at least touched, so look for more

                Dim matches As MatchCollection = Regex.Matches(My.Settings.MyGames, "(?<=\[)\d{1,8}(?=])")
                Dim value As String

                For i As Integer = 0 To matches.Count - 1 Step 1

                    value = ini.INIRead(path, matches(i).Value, "XPP", Nothing)
                    If Not String.IsNullOrEmpty(value) Then
                        patchCount += 1
                    Else
                        If patchCount > 1 Then
                            'The file is partly patched
                            PatchLabelStatus = PatchStatus.PartlyPatched
                            'Enable the Restore button if there is an available backup
                            If BackupExists Then SetRestoreBtn(True)
                            Exit Sub
                        End If
                    End If
                Next

                If patchCount = matches.Count Then
                    'The file has been patched
                    PatchLabelStatus = PatchStatus.Patched
                    'Enable the Restore button if there is an available backup
                    If BackupExists Then SetRestoreBtn(True)
                ElseIf patchCount = 0 Then
                    'The file isn't really patched
                    PatchLabelStatus = PatchStatus.NotPatched
                    'Disable restore button
                    SetRestoreBtn(False)
                End If
            Else
                'The file isn't touched, assume not patched
                PatchLabelStatus = PatchStatus.NotPatched
                'Disable the restore button
                SetRestoreBtn(False)
            End If

        Else
            MsgBox("Xfire is not installed or you don't have rights to read from the registry!", MsgBoxStyle.Critical)
        End If

    End Sub

    Public Function GetXfire_GamesINI() As String

        Dim loc As String = Nothing

        If IsOSVersionOld() Then

            If Environment.Is64BitOperatingSystem Then
                loc = My.Computer.Registry.LocalMachine.GetValue("SOFTWARE\WoW6432Node\Xfire", "", Nothing).ToString + "\xfire_games.ini"
            Else
                loc = My.Computer.Registry.LocalMachine.GetValue("SOFTWARE\Xfire", "", Nothing).ToString + "\xfire_games.ini"
            End If

        Else

            loc = System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData) + "\Xfire\xfire_games.ini"

        End If

        Return loc

    End Function

    Private Sub btnPatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPatch.Click

        btnPatch.Text = "Patching..."
        btnPatch.Enabled = False
        Cursor = Cursors.WaitCursor

        ThreadPool.QueueUserWorkItem(AddressOf UpdateStatus)
        bw.RunWorkerAsync()

    End Sub

    Private Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles bw.DoWork

        Select Case PatchFile(False)

            Case 0
                MsgBox("Xfire was successfully patched!", MsgBoxStyle.Information)

            Case 1
                MsgBox("You have not added any games to patch!", MsgBoxStyle.Critical)

            Case 2
                MsgBox("Xfire_games.ini could not be found on your system!", MsgBoxStyle.Critical)

            Case 3
                MsgBox("Xfire was already fully patched!", MsgBoxStyle.Information)

        End Select

    End Sub
    Private Sub bw_Done() Handles bw.RunWorkerCompleted

        btnPatch.Text = "Patch"
        btnPatch.Enabled = True
        Cursor = Cursors.Default
        ThreadPool.QueueUserWorkItem(AddressOf UpdateStatus)

    End Sub

    Public Sub BackupXfireINI()

        'Only backup if the existing file is not patched
        If PatchLabelStatus = PatchStatus.NotPatched Then
            Dim filedir As String = My.Settings.xfireINIPath
            File.Copy(filedir, filedir + ".bak", True)
        End If

    End Sub

    Public Function PatchFile(ByVal ExitWhenDone As Boolean) As Integer

        If PatchLabelStatus = PatchStatus.Patched Then Return 3

        Dim filedir As String = My.Settings.xfireINIPath
        If File.Exists(filedir) = False Then Return 2 'Missing xfire INI file

        If My.Settings.xfpatch = Nothing Then Return 1 'The user hasn't added any games to patch

        Dim ini As New INIAccess

        Dim matches As MatchCollection = Regex.Matches(My.Settings.MyGames, "(?<=\[)\d{1,8}(?=])")

        For i As Integer = 0 To matches.Count - 1 Step 1
            ini.INIDelete(filedir, matches(i).Value)
        Next

        Dim gamedata() As String = My.Settings.xfpatch.Split(New Char() {Chr(0)}, StringSplitOptions.RemoveEmptyEntries)

        For i As Integer = 0 To gamedata.Count - 1
            gamedata(i) = gamedata(i).Replace("#", Environment.NewLine)
        Next

        Dim xfpatch As String = String.Join(Environment.NewLine + Environment.NewLine + Environment.NewLine, gamedata)

        BackupXfireINI()
        File.AppendAllText(filedir, xfpatch)

        ini.INIWrite(filedir, "-1", "PatchedByXPP", "1")

        If ExitWhenDone = True Then Application.Exit()

        Return 0

    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If ManageGames.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ThreadPool.QueueUserWorkItem(AddressOf UpdateStatus)
        End If

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles AboutLabel.LinkClicked

        About.ShowDialog()

    End Sub

    Private Sub SettingsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsButton.Click

        Dim ini As New INIAccess

        Settings.ShowDialog()

    End Sub

    Private Sub RestoreButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestore.Click

        Dim filedir As String = My.Settings.xfireINIPath
        Dim backupfile As String = filedir + ".bak"

        If File.Exists(backupfile) Then

            Dim info As New FileInfo(backupfile)

            Dim result As MsgBoxResult = MsgBox("This will restore the original (" + info.LastWriteTime.ToString + ") xfire_games.ini?", MsgBoxStyle.OkCancel, "Restore Original")

            If result = MsgBoxResult.Ok Then

                My.Computer.FileSystem.CopyFile(filedir + ".bak", filedir, True)
                MsgBox("The original was restored successfully!", MsgBoxStyle.Information)
                ThreadPool.QueueUserWorkItem(AddressOf UpdateStatus)

            End If
        End If

    End Sub

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerOne.Tick
        Application.Exit()
    End Sub

    Private Sub CheckForUpdates()

        If (Portable) Then

            bwCheckUpdates.RunWorkerAsync()

        Else
            Dim args As String = String.Format("-pids {0} -version ""{1}"" -apiurls ""{2}""", Process.GetCurrentProcess().Id, Application.ProductVersion.ToString(), "http://fredrikblomqvist.developer.se/dev/getupdate.php?name=xpp|http://mumble.codecafe.com/dev/getupdate.php?name=xpp")
            Try
                Process.Start("SharpDate.exe", args)
            Catch ex As FileNotFoundException

            Catch ex As Exception
            End Try
        End If

    End Sub

    Public Function compareDates(ByVal Date1 As Date, ByVal Date2 As Date) As Integer

        Select Case Date1
            Case Is > Date2
                compareDates = 1
            Case Is < Date2
                compareDates = 2
            Case Is = Date2
                compareDates = 0
            Case Else
                compareDates = -1

                Return compareDates

        End Select
    End Function

    Private Sub SetXfireINIPath()

        My.Settings.xfireINIPath = GetXfire_GamesINI()

    End Sub

    Private Sub bwCheckUpdates_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwCheckUpdates.DoWork

        Dim client As WebClient = New WebClient()
        Dim newVersion As Version

        Try
            newVersion = Version.Parse(client.DownloadString("http://fredrikblomqvist.developer.se/dev/getversion.php?name=xpp"))
        Catch ex As Exception
            e.Result = BwUpdateResult.ErrorOccured
            Return
        End Try

        Dim curVersion As Version = Version.Parse(Application.ProductVersion)

        If (newVersion > curVersion) Then
            e.Result = BwUpdateResult.Available
        Else
            e.Result = BwUpdateResult.NotAvailable
        End If

    End Sub

    Private Sub bwCheckUpdates_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwCheckUpdates.RunWorkerCompleted

        If CType(e.Result, BwUpdateResult) = BwUpdateResult.Available Then
            MessageBox.Show("There is a new version available at http://cyb3rh4xter.wordpress.com/!", "New Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf CType(e.Result, BwUpdateResult) = BwUpdateResult.ErrorOccured Then
            MessageBox.Show("Failed to check for updates!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
End Class


