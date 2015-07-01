Imports Newtonsoft.Json.Linq
Imports System.Diagnostics.Contracts
Public Class SongsServiceLive
    Implements ISongsService

    Private _averageTime As String
    Public ReadOnly Property AverageTime() As String
        Get
            Return _averageTime
        End Get
    End Property

    Public Function GetSongs(ByVal artistName As String) As List(Of String) Implements ISongsService.GetSongs
        Dim webClientService As IWebClientService = ServiceLocator.GetService(Of IWebClientService)()
        Dim retVal As New List(Of String)
        Dim url As String = String.Format("https://itunes.apple.com/search?term={0}", artistName)
        Try
            Dim result As String = webClientService.DownloadString(url)
            If Not String.IsNullOrEmpty(result) Then
                Dim json As JObject = JObject.Parse(result)
                If json IsNot Nothing AndAlso json.HasValues Then
                    Dim averageTime As Double = 0
                    Dim resultCount As Int32 = json.SelectToken("resultCount")
                    Dim results() As JToken = json.SelectTokens("results").Children().ToArray()
                    For Each song As JToken In results
                        Dim time As Double = song.Item("trackTimeMillis")
                        Dim name As String = song.Item("trackName")
                        retVal.Add(String.Format("{0} - {1}", name, MyUtils.MillisToMin(time)))
                        averageTime += time
                    Next
                    averageTime /= resultCount
                    _averageTime = MyUtils.MillisToMin(averageTime)
                End If
            End If
        Catch ex As System.Net.WebException
        End Try
        Return retVal
    End Function
End Class
