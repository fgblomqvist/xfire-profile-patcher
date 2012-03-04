﻿Public Class AddManually

    Public EditMode As Boolean = False

    Private Sub btnAddEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddEdit.Click

        txtName.Text.Replace("#", "")

        If Not String.IsNullOrWhiteSpace(txtName.Text) And Not String.IsNullOrWhiteSpace(txtData.Text) Then
            If btnAddEdit.Text = "Save" Then

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            End If
        Else

            MsgBox("Please enter valid name and data first!", MsgBoxStyle.Exclamation)

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub AddManually_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If EditMode = True Then

            Me.Text = "Edit"
            btnAddEdit.Text = "Save"

        Else

            txtName.Text = ""
            txtData.Text = ""
            Me.Text = "Add Game"
            btnAddEdit.Text = "Add Game"

        End If

    End Sub

    Private Function RebuildData(ByVal Data As String) As String

        Dim split() As String = Data.Split(CChar("#"))
        Dim complete As String = Nothing

        For Each item As String In split

            If complete = Nothing Then

                complete = item

            Else

                complete += vbNewLine + item

            End If

        Next

        Return complete
    End Function

    ''' <summary>
    ''' Will allow the user to edit the game. Returns array with new data (0 = Name, 1 = Data).
    ''' </summary>
    ''' <param name="GameName">Name of the game.</param>
    ''' <param name="GameData">The game data.</param><returns></returns>
    Public Function Edit(ByVal GameName As String, ByVal GameData As String) As String()

        EditMode = True

        txtName.Text = GameName
        txtData.Text = RebuildData(GameData)

        If MyBase.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Return New String() {txtName.Text, Join(txtData.Lines, "#")}

        Else

            Return Nothing

        End If

    End Function

    Public Function Add() As String()

        EditMode = False

        If MyBase.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Return New String() {txtName.Text, Join(txtData.Lines, "#")}

        Else

            Return Nothing

        End If

    End Function
End Class