Option Strict On
Imports System.Xml
Imports System.IO

Public Class ExportDialog

    Public xfpatchstring As String
    Private gamesTable As DataTable

    Public Overloads Sub ShowDialog(ByVal Games As DataTable)

        gamesTable = Games
        'load up order defaults
        MyBase.ShowDialog()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If txtExportDir.Text.Length > 0 Then

            ExportGames(txtExportDir.Text, gamesTable)
            MsgBox("Done!", MsgBoxStyle.Information)
            Me.Close()

        Else

            MsgBox("You must select a valid export location first!", MsgBoxStyle.Critical)

        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click

        Dim dia As SaveFileDialog = SaveFile

        If dia.ShowDialog = Windows.Forms.DialogResult.OK Then

            txtExportDir.Text = dia.FileName

        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Me.Close()

    End Sub
    Private Sub ExportGames(ByVal sPath As String, ByVal Table As DataTable)


        Dim xwrite As New XmlTextWriter(sPath, System.Text.Encoding.UTF8)

        With xwrite

            .Formatting = Formatting.Indented
            .Indentation = 4


            .WriteStartDocument()

            .WriteStartElement("gameprofiles")
            .WriteAttributeString("version", "2")

            For Each row As DataRow In Table.Rows

                .WriteStartElement("game")
                .WriteStartElement("name")
                .WriteString(row("Name").ToString)
                .WriteEndElement()
                .WriteStartElement("id")
                .WriteString(row("ID").ToString)
                .WriteEndElement()
                .WriteStartElement("data")
                .WriteString(row("Data").ToString)
                .WriteEndElement()
                .WriteEndElement()

            Next

            .WriteEndElement()
            .WriteEndDocument()
            .Close()


        End With
    End Sub
End Class