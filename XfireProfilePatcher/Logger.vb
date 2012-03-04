Option Strict On
Imports System.IO

Public Class Logger

    Public Shared Sub Write(ByVal msg As String)
        Dim xwrite As New StreamWriter("xpp.log", True)
        xwrite.Write(vbNewLine & Now.Year.ToString & "." & Now.Month.ToString & Now.Day.ToString & " " & Now.TimeOfDay.ToString & ": " & msg)
        xwrite.Close()
    End Sub
End Class
