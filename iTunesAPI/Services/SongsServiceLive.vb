Imports Newtonsoft.Json.Linq
Imports System.Diagnostics.Contracts
Public Class SongsServiceLive
    Implements ISongsService

    Public Function GetSongs(ByVal artistName As String) As List(Of String) Implements ISongsService.GetSongs
        Try
            Dim webClientService As IWebClientService = ServiceLocator.GetService(Of IWebClientService)()
            Dim retVal As New List(Of String)
            Dim url As String = String.Format("https://itunes.apple.com/search?term={0}", artistName)
            Dim result As String = webClientService.DownloadString(url)            
        Catch ex As Exception
            Dim i = 5
        End Try
        Return New List(Of String)()
    End Function

    Public Function GetAverageTime() As String Implements ISongsService.GetAverageTime
        Return Nothing
    End Function
End Class
