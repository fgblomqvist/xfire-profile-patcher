Imports Microsoft.Win32
Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms

Public Class Settings

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        'Autopatch Setting

        If cboxAutoPatch.Checked Then

            AutoPatch = True

            If cboxRestartXfire.Checked Then
                My.Settings.restartXfire = True
            Else
                My.Settings.restartXfire = False
            End If

        Else
            AutoPatch = False
        End If

        'Game profile Update Setting

        If radbtnOnline.Checked Then
            My.Settings.UpdateGameProfiles = 1
        ElseIf radbtnManually.Checked Then
            My.Settings.UpdateGameProfiles = 2
        End If

        'Check for updates setting

        If cboxCheckForUpdates.Checked Then
            My.Settings.CheckForUpdates = True
        Else
            My.Settings.CheckForUpdates = False
        End If

        My.Settings.Save()
        Me.Close()

    End Sub

    Private Sub Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If AutoPatch = True Then

            cboxAutoPatch.Checked = True

            If My.Settings.restartXfire = True Then

                cboxRestartXfire.Checked = True

            Else

                cboxRestartXfire.Checked = False

            End If

        Else

            cboxAutoPatch.Checked = False
            cboxRestartXfire.Enabled = False

        End If

        Select Case My.Settings.UpdateGameProfiles

            Case 1
                radbtnOnline.Checked = True
            Case 2
                radbtnManually.Checked = True
        End Select

        If My.Settings.CheckForUpdates = True Then

            cboxCheckForUpdates.Checked = True

        Else

            cboxCheckForUpdates.Checked = False

        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub cboxAutoPatch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxAutoPatch.CheckedChanged

        If cboxAutoPatch.Checked Then

            cboxRestartXfire.Enabled = True

        Else

            cboxRestartXfire.Enabled = False
            cboxRestartXfire.Checked = False

        End If

    End Sub

    Private Property AutoPatch As Boolean


        Get

            Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            Dim x As String = Nothing

            Try

                x = key.GetValue("XfireProfilePatcher", Nothing).ToString

            Catch e As NullReferenceException
                'Key doesn't exist

            Catch e As Exception

                MsgBox("Unable to detect autostart in registry!", MsgBoxStyle.Critical)

            End Try

            If x IsNot Nothing Then

                Return True

            Else

                Return False

            End If

        End Get

        Set(ByVal value As Boolean)

            Dim key As RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)

            If value = True Then

                Dim output As String = """" + Application.ExecutablePath + """ -nogui"
                key.SetValue("XfireProfilePatcher", output)

            Else

                If key.GetValue("XfireProfilePatcher", Nothing) IsNot Nothing Then

                    Try
                        key.DeleteValue("XfireProfilePatcher")
                    Catch e As Exception
                        MsgBox("Failed to edit autopatch! No rights for registry!", MsgBoxStyle.Critical)
                    End Try

                End If

                End If
        End Set
    End Property
End Class
