Imports Newtonsoft.Json.Linq
''' <summary>
''' Service for songs search
''' </summary>
''' <remarks></remarks>
Public Class SongsService
    Implements ISongsService

    ''' <summary>
    ''' Holds the songs average time
    ''' </summary>
    ''' <remarks></remarks>
    Private _averageTime As String
    ''' <summary>
    ''' Main function for songs search
    ''' </summary>
    ''' <param name="artistName">search by this parameter</param>
    ''' <returns>songs list that fits the artist name</returns>
    ''' <remarks></remarks>
    Public Function GetSongs(ByVal artistName As String) As List(Of String) Implements ISongsService.GetSongs
        Dim webClientService As IWebClientService = ServiceLocator.GetService(Of IWebClientService)()
        Dim retVal As New List(Of String)
        Dim url As String = String.Format("https://itunes.apple.com/search?term={0}", artistName)
        Dim result As String = webClientService.DownloadString(url)
        Dim json As JObject = JObject.Parse(result)
        If json IsNot Nothing AndAlso json.HasValues Then
            If json.SelectTokens("results") IsNot Nothing AndAlso json.SelectTokens("results").Children().Any() Then
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
        Return retVal
    End Function
    ''' <summary>
    ''' Get the average time
    ''' </summary>
    ''' <returns>Average time</returns>
    ''' <remarks></remarks>
    Public Function GetAverageTime() As String Implements ISongsService.GetAverageTime
        Return _averageTime
    End Function
End Class
