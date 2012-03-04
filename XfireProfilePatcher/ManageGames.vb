Option Strict On
Imports System.Environment
Imports System.IO
Imports System.Xml
Imports System.Text.RegularExpressions
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Threading

Public Class ManageGames

    Public MyGamesTable As DataTable
    Public GameProfilesTable As DataTable = Nothing  'Name, ID, DATA
    Private MyGamesBinding As BindingSource
    Public EditedGameName As String = Nothing
    Public EditedGameData As String = Nothing
    Public customData(1) As String
    Public UpdateChecked As Boolean = False


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If cboxGameProfiles.SelectedIndex = -1 Then

            MsgBox("You must select a game first!", MsgBoxStyle.Critical)

        Else

            Dim exist As Boolean = False

            For Each row As DataRow In MyGamesTable.Rows

                If row(0).ToString = CStr(GameProfilesTable.Rows(cboxGameProfiles.SelectedIndex)("Name")) Then

                    exist = True

                End If

            Next

            If exist = True Then

                MsgBox("You have already added that game!", MsgBoxStyle.Critical)

            Else

                Dim name As String = CStr(GameProfilesTable.Rows(cboxGameProfiles.SelectedIndex)("name"))
                Dim data As String = CStr(GameProfilesTable.Rows(cboxGameProfiles.SelectedIndex)("data"))
                Dim ID As String = CStr(GameProfilesTable.Rows(cboxGameProfiles.SelectedIndex)("id"))

                AddGame(name, data, ID, customData)

                customData(0) = Nothing
                customData(1) = Nothing

            End If

        End If

        cboxGameProfiles.SelectedIndex = -1

    End Sub

    Public Sub AddGame(Name As String, Data As String)

        AddGame(Name, Data, Nothing, Nothing)

    End Sub

    Public Sub Addgame(Name As String, Data As String, ID As String)

        AddGame(Name, Data, ID, Nothing)

    End Sub

    Public Sub AddGame(ByVal Name As String, ByVal Data As String, ByVal ID As String, ByVal customData As String())

        Dim newName As String = Name

        If customData IsNot Nothing Then

            If customData(0) IsNot Nothing Then

                Dim regex As New Regex("(?<=#LauncherExe=).+?(?=#)")
                Data = regex.Replace(Data, customData(0))

                newName = Name + " (Custom)"

            End If


            If customData(1) IsNot Nothing Then

                Dim regex As New Regex("(?<=#InGameRenderer=).+?(?=#)")
                Data = regex.Replace(Data, customData(1))

                newName = Name + " (Custom)"

            End If

        End If

        If ID = Nothing Or String.IsNullOrEmpty(ID) Then
            ID = GetGameID(Data)
        End If

        Dim newRow As DataRow = MyGamesTable.NewRow()
        newRow("name") = newName
        newRow("id") = ID
        newRow("data") = Data

        MyGamesTable.Rows.Add(newRow)

    End Sub

    Private Sub ManageGames_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Try
            If GameProfilesTable IsNot Nothing Then
                If GameProfilesTable.Rows.Count > 0 Then
                    Dim sW As New StringWriter
                    GameProfilesTable.WriteXml(sW, System.Data.XmlWriteMode.WriteSchema, False)

                    My.Settings.GameProfiles = sW.ToString

                End If
            End If

        Catch exc As Exception

            MsgBox(exc.Message)

        End Try

    End Sub
    Private Sub ManageGames_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Logger.Write("Loading Manage Games...")
        cboxGameProfiles.Enabled = False
        lblGameProfiles.Visible = False

        'Logger.Write("Running UpdateGameProfile sub")

        If UpdateChecked = False Then
            If bwCheckUpdates.IsBusy = False Then

                lblGameProfiles.Text = "Fetching new game profiles..."
                lblGameProfiles.Visible = True
                bwCheckUpdates.RunWorkerAsync()

            End If

        Else

            lblGameProfiles.Text = "Loading game profiles..."
            lblGameProfiles.Visible = True
            LoadLocalGameProfiles()
            lblGameProfiles.Visible = False
            cboxGameProfiles.Enabled = True

        End If

        MyGamesBinding = New BindingSource

        If My.Settings.MyGames.Length > 1 Then

            'Logger.Write("Loading mygameprofiles from settings")
            MyGamesTable = New DataTable
            Dim sR As New StringReader(My.Settings.MyGames)
            MyGamesTable.ReadXml(sR)
            'Logger.Write("Finished loading")

            If MyGamesTable.Columns.Count < 3 Then
                'Wrong format, add a column
                MyGamesTable.Columns.Add("ID")
            End If

        Else

            MyGamesTable = New DataTable

            MyGamesTable.Columns.Add("Name")
            MyGamesTable.Columns.Add("ID")
            MyGamesTable.Columns.Add("Data")

        End If

        MyGamesBinding.DataSource = MyGamesTable

        lboxAddedGames.DisplayMember = "Name"
        lboxAddedGames.ValueMember = "Data"
        lboxAddedGames.DataSource = MyGamesBinding

        MyGamesBinding.Sort = "Name"

        MyGamesTable.TableName = "My Games Table"

    End Sub

    Private Sub SaveMyGamesTable()

        Try
            Dim sW As New StringWriter
            MyGamesTable.WriteXml(sW, System.Data.XmlWriteMode.WriteSchema, False)

            My.Settings.MyGames = sW.ToString
            My.Settings.Save()

        Catch e As Exception

            MsgBox(e.Message)

        End Try
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        SaveMyGamesTable()
        BuildXfpatch()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        Dim results As String() = AddManually.Add()

        If (results IsNot Nothing) Then

            AddGame(results(0), results(1))

        End If

    End Sub

    Private Sub RemoveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveButton.Click

        If lboxAddedGames.Items.Count > 0 Then

            MyGamesBinding.RemoveCurrent()

        End If
    End Sub

    Private Sub BuildXfpatch()

        Try

            'reset xfpatch setting
            My.Settings.xfpatch = ""

            Dim xfpatch As String

            xfpatch = Environment.NewLine + Environment.NewLine

            'for each game in MyGames
            For Each row As DataRow In MyGamesTable.Rows

                Dim data As String = row("data").ToString + "#XPP=1"

                xfpatch += data + Chr(0)
            Next

            'put the complete string with all the games from MyGames into the xfpatch setting
            My.Settings.xfpatch = xfpatch

        Catch e As Exception

            MsgBox(e.Message)

        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Me.Close()

    End Sub

    Private Sub EditButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditButton.Click

        EditGame()

    End Sub

    Private Sub EditGame()

        Dim currentRow = DirectCast(MyGamesBinding.Current, DataRowView)

        If currentRow Is Nothing Then

            MsgBox("Please select a game first!", MsgBoxStyle.Critical)

        Else

            Dim result As String() = AddManually.Edit(currentRow.Row("Name").ToString, currentRow.Row("Data").ToString)

            If result IsNot Nothing Then

                currentRow.Delete()
                AddGame(result(0), result(1))

            End If

        End If

    End Sub
    Private Sub ExportButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportButton.Click

        If MyGamesTable.Rows.Count > 0 Then
            ExportDialog.ShowDialog(MyGamesTable)
        Else
            MessageBox.Show("You don't have any profiles to export!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub ImportButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportButton.Click

        Dim results As List(Of String()) = ImportDialog.ShowDialog()

        If results IsNot Nothing Then

            For Each game As String() In results

                AddGame(game(0), game(1))

            Next

        End If

    End Sub

    Private Sub MyGamesListBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lboxAddedGames.KeyDown

        If e.KeyCode = Keys.Delete Then
            RemoveButton_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.Enter Then
            EditGame()
        End If

    End Sub

    Private Sub MyGamesListBox_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lboxAddedGames.MouseDoubleClick

        EditGame()

    End Sub

    Private Function UpdateGameProfiles() As Integer

        Dim newVersion As Integer
        Dim curVersion As Integer = My.Settings.GameProfilesVersion

        Try
            newVersion = GetLatestGameProfilesVersion()
        Catch ex As WebException
            'Probably unable to connect
            Return 2
        Catch ex As FormatException
            'Something wrong with the remote-end
            Return 3
        Catch ex As Exception
            'Uknown error
            Return 4
        End Try

        If curVersion < newVersion Or String.IsNullOrEmpty(My.Settings.GameProfiles) Then

            'Update the gameprofiles
            Dim client As WebClient = New WebClient()
            Dim xml As String = Nothing
            Try
                xml = client.DownloadString("http://fredrikblomqvist.developer.se/xpp/getgprofiles.php")
            Catch ex As Exception
                MsgBox("Error fetching gameprofiles: " + ex.ToString())
                Return 2
            End Try

            GameProfilesTable = New DataTable()
            GameProfilesTable = Functions.ParseXML(xml)

            My.Settings.GameProfilesVersion = newVersion

        Else

            'The user already has the newest version
            Return 1

        End If

        Return 0

    End Function

    Private Sub bwCheckUpdates_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwCheckUpdates.DoWork

        Select Case My.Settings.UpdateGameProfiles

            Case 1

                Dim result As Integer = UpdateGameProfiles()

                If result = 0 Then



                ElseIf result = 1 Then

                    LoadLocalGameProfiles()

                ElseIf result > 1 Then

                    MsgBox("Failed to fetch new game profiles! Will load the last fetched ones' instead.", MsgBoxStyle.Exclamation, "Error")
                    LoadLocalGameProfiles()

                End If

            Case 2

                LoadLocalGameProfiles()

        End Select

    End Sub


    Private Sub LoadLocalGameProfiles()

        GameProfilesTable = New DataTable

        If My.Settings.GameProfiles.ToString.Count > 1 Then

            Dim sR As New StringReader(My.Settings.GameProfiles)

            Try

                GameProfilesTable.ReadXml(sR)

            Catch ex As Exception

                MsgBox("Failed to load gameprofiles!")

            End Try

        End If

    End Sub

    Private Sub UpdateGameProfilesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateGameProfilesToolStripMenuItem.Click

        UpdateGameProfiles()
        MsgBox("Your game profiles got successfully updated!", MsgBoxStyle.Information)

    End Sub

    Private Sub bwCheckUpdates_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwCheckUpdates.RunWorkerCompleted

        If GameProfilesTable.Rows.Count > 1 Then

            cboxGameProfiles.DataSource = GameProfilesTable
            cboxGameProfiles.DisplayMember = "Name"
            cboxGameProfiles.ValueMember = "Data"
            cboxGameProfiles.SelectedIndex = -1

            lblGameProfiles.Visible = False
            cboxGameProfiles.Enabled = True
            UpdateChecked = True

        Else

            lblGameProfiles.Text = "No gameprofiles available"

        End If

    End Sub

    Private Function GetLatestGameProfilesVersion() As Integer

        Dim client As WebClient = New WebClient()
        Dim data As String
        Dim newVersion As Integer

        Try
            data = client.DownloadString("http://fredrikblomqvist.developer.se/dev/getversion.php?name=gameprofiles")
            newVersion = Int32.Parse(data)
        Catch ex As Exception
            Throw ex
        End Try

        Return newVersion

    End Function

    Private Function GetGameID(Data As String) As String

        Dim regex As Regex = New Regex("(?<=\[)[\d_]{1,6}(?=\])")
        Dim match As Match = regex.Match(Data)

        Return match.Value

    End Function

    Private Sub lblCustomSettings_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblCustomSettings.LinkClicked

        Dim values As String()

            If customData(0) Is Nothing And customData(1) Is Nothing Then
                values = ExtractCurrentValues(CStr(cboxGameProfiles.SelectedValue))
                customData = Customizer.ShowDialog(values)

            Else
                customData = Customizer.ShowDialog(customData)
            End If

    End Sub

    Private Function ExtractCurrentValues(data As String) As String()

        Dim regex As Regex = New Regex("(?<=InGameRenderer=)\w+(?=#)|(?<=LauncherExe=)[\w\s\.]+(?=#)")
        Dim matches As MatchCollection = regex.Matches(data) '0 = Launcher Exe, 1 = Renderer

        If matches.Count < 2 Then

            If matches(0).Value.Contains("InGameRenderer") Then

                Return New String() {Nothing, matches(0).Value}

            Else

                Return New String() {matches(0).Value, Nothing}

            End If

        Else
            Return New String() {matches(0).Value, matches(1).Value}
        End If



    End Function

    Private Sub cboxGameProfiles_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboxGameProfiles.SelectedIndexChanged

        customData(0) = Nothing
        customData(1) = Nothing

        If cboxGameProfiles.SelectedIndex = -1 Then
            lblCustomSettings.Enabled = False
            btnAdd.Enabled = False
        Else
            lblCustomSettings.Enabled = True
            btnAdd.Enabled = True
        End If

    End Sub

    Private Sub SubmitGame()

        Dim currentRow = DirectCast(MyGamesBinding.Current, DataRowView)

        If currentRow Is Nothing Then

            MsgBox("Please select a game first!", MsgBoxStyle.Critical)

        Else

            Dim macAddr As String = (From nic In NetworkInterface.GetAllNetworkInterfaces() Where nic.OperationalStatus = OperationalStatus.Up Select nic.GetPhysicalAddress()).FirstOrDefault().ToString()

            ' Create a request using a URL that can receive a post. 
            Dim request As WebRequest = WebRequest.Create("http://fredrikblomqvist.developer.se/xpp/contribute.php")
            ' Set the Method property of the request to POST.
            request.Method = "POST"
            ' Create POST data and convert it to a byte array.
            Dim postData As String = "name=" + currentRow.Row("Name").ToString() + "&data=" + currentRow.Row("Data").ToString() + "&mac=" + macAddr
            Dim byteArray As Byte() = System.Text.Encoding.UTF8.GetBytes(postData)
            ' Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded"
            ' Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length

            Try
                ' Get the request stream.
                Dim dataStream As Stream = request.GetRequestStream()
                ' Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length)
                ' Clean up the streams.
                dataStream.Close()
            Catch ex As WebException
                MessageBox.Show("Thank you for trying to contribute," + Environment.NewLine + _
                 "unfortunatley the contribute server couldn't be reached." + Environment.NewLine + _
                 "Please try again later!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End Try

            MessageBox.Show("Thank you for contributing!" + Environment.NewLine + _
                            "If the submitted data is correct," + Environment.NewLine + _
                            "it will get added to the db within 24 hours usually." + Environment.NewLine + Environment.NewLine + _
                            "Note that abusing this system results in ban from using it," + Environment.NewLine + _
                            "along with ban from fetching new gameprofiles!", "Thank you!", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub btnContribute_Click(sender As System.Object, e As System.EventArgs) Handles btnContribute.Click

        Dim result As DialogResult = MessageBox.Show("Before you submit this game," + Environment.NewLine + _
                            "please check these things:" + Environment.NewLine + Environment.NewLine + _
                            "• The name is the official one" + Environment.NewLine + _
                            "• The name is correctly spelled" + Environment.NewLine + _
                            "• The data is working" + Environment.NewLine + _
                            "• The game doesn't already exist" + Environment.NewLine + Environment.NewLine + _
                            "Have you confirmed all of the above and want to submit it?", "Thank you!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If result = Windows.Forms.DialogResult.Yes Then
            SubmitGame()
        End If

    End Sub
End Class