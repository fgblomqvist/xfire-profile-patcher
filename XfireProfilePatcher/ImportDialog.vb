﻿Option Strict On
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Xml

Public Class ImportDialog

    Private GamesListBoxTable As DataTable

    Private Sub BrowseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click

        If btnImport.Text = "Import" Then
            Dim import As OpenFileDialog = ImportFileDialog

            If import.ShowDialog = Windows.Forms.DialogResult.OK Then

                txtImportDir.Text = import.FileName

                Dim xRead As String = File.ReadAllText(txtImportDir.Text)

                GamesListBoxTable = Functions.ParseXML(xRead)
                lboxGames.DataSource = GamesListBoxTable

                lboxGames.DisplayMember = "name"
                lboxGames.ValueMember = "data"

            End If

        Else

            Dim import As OpenFileDialog = ImportFileDialog

            If import.ShowDialog = Windows.Forms.DialogResult.OK Then

                txtImportDir.Text = import.FileName

            End If

        End If

    End Sub

    Public Overloads Function ShowDialog() As List(Of String())

        If MyBase.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Dim importList As List(Of String()) = New List(Of String())

            Cursor = Cursors.WaitCursor

            For Each itm As DataRow In GamesListBoxTable.Rows

                importList.Add(New String() {itm("name").ToString(), itm("id").ToString(), itm("data").ToString()})

            Next

            Cursor = Cursors.Default
            Me.Close()

            Return importList

        Else

            Return Nothing

        End If

    End Function

    Private Sub ImportButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click

        If btnImport.Text = "Import" Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else

            Dim xRead As String = File.ReadAllText(txtImportDir.Text)
            ManageGames.GameProfilesTable.Clear()
            ManageGames.GameProfilesTable.TableName = "Games Table"
            ManageGames.GameProfilesTable = Functions.ParseXML(xRead)
            MsgBox("Your game profiles were successfully updated!", MsgBoxStyle.Information)
            Me.Close()

        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub ImportDialog_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        RestoreUI()
        btnBrowse.Focus()

    End Sub

    Private Sub RestoreUI()
        txtImportDir.Text = String.Empty
        If GamesListBoxTable IsNot Nothing Then
            GamesListBoxTable.Clear()
        End If
    End Sub
End Class