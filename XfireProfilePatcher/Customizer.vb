Imports System.Text.RegularExpressions

Public Class Customizer

    Private rendererTable As New DataTable("Renderers")

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Public Overloads Function ShowDialog(customData As String()) As String()

        If customData(0) Is Nothing Then
            txtLauncherExe.Enabled = True
            txtLauncherExe.Text = String.Empty
            txtLauncherExe.Enabled = False
        Else
            txtLauncherExe.Text = customData(0)
        End If

        If rendererTable.Columns.Count < 1 Then

            With rendererTable

                .Columns.Add("name")
                .Columns.Add("value")

                .PrimaryKey = New DataColumn() {rendererTable.Columns("value")}

                .Rows.Add("OpenGL", "OGL")
                .Rows.Add("DirectDraw", "DDRAW")
                .Rows.Add("DirectDraw 4", "DDRAW4")
                .Rows.Add("DirectX 7", "D3D7")
                .Rows.Add("DirectX 8", "D3D8")
                .Rows.Add("DirectX 9", "D3D9")
                .Rows.Add("DirectX 10", "D3D10")
                .Rows.Add("DirectX 11", "D3D11")

            End With

        End If

        cboxRenderer.DataSource = rendererTable
        cboxRenderer.DisplayMember = "name"
        cboxRenderer.ValueMember = "value"

        If customData(1) IsNot Nothing Then
            cboxRenderer.Enabled = True
            Dim row As DataRow = rendererTable.Rows.Find(customData(1))
            cboxRenderer.Text = CStr(row(0))
        Else
            cboxRenderer.Enabled = False
        End If

        If MyBase.ShowDialog = Windows.Forms.DialogResult.OK Then

            Return New String() {txtLauncherExe.Text, cboxRenderer.SelectedValue.ToString()}

        Else

            Return New String() {Nothing, Nothing}

        End If


    End Function
End Class