Imports Newtonsoft.Json.Linq

Public Class SongsServiceLive
    Implements ISongsService

    Public Function GetSongs(ByVal artistName As String) As List(Of String) Implements ISongsService.GetSongs
        Return Nothing
    End Function

    Public Function GetAverageTime() As String Implements ISongsService.GetAverageTime
        Return Nothing
    End Function
End Class
