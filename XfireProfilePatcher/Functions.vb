Imports System.Xml

Public Class Functions

    Public Shared Function ParseXML(ByVal XMLText As String) As DataTable

        Dim table As New DataTable

        table.TableName = "GameProfiles"
        table.Columns.Add("name")
        table.Columns.Add("id")
        table.Columns.Add("data")

        Dim xdoc As New XmlDocument

        xdoc.LoadXml(XMLText)

        Dim version As Integer

        Try
            version = Convert.ToInt32(xdoc.SelectSingleNode("//gameprofiles/@version").Value)
        Catch ex As NullReferenceException
            version = 1
        End Try

        Dim GameNames As XmlNodeList
        Dim GameID As XmlNodeList
        Dim GameData As XmlNodeList

        If version < 2 Then
            'Old version file
            GameNames = xdoc.GetElementsByTagName("Name")
            GameData = xdoc.GetElementsByTagName("Data")

            For i As Integer = 0 To GameNames.Count - 1

                table.Rows.Add(GameNames(i).InnerText, String.Empty, GameData(i).InnerText.Replace(",", "#").Replace("XGP=1", ""))

            Next
        Else
            'Newer version file
            GameNames = xdoc.GetElementsByTagName("name")
            GameID = xdoc.GetElementsByTagName("id")
            GameData = xdoc.GetElementsByTagName("data")

            For i As Integer = 0 To GameNames.Count - 1

                table.Rows.Add(GameNames(i).InnerText, GameID(i).InnerText, GameData(i).InnerText)

            Next
        End If

        Return table

    End Function

End Class
