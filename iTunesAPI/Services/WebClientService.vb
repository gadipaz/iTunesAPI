Imports System.Net

''' <summary>
''' WebClient wrapper class
''' </summary>
''' <remarks></remarks>
Public Class WebClientService
    Inherits WebClient
    Implements IWebClientService
    ''' <summary>
    ''' Override DownloadString for mocking
    ''' </summary>
    ''' <param name="url">url with query string</param>
    ''' <returns>response from the server</returns>
    ''' <remarks></remarks>
    Public Overloads Function DownloadString(url As String) As String Implements IWebClientService.DownloadString
        Dim webClient As New WebClient
        Return webClient.DownloadString(url)
    End Function
End Class
