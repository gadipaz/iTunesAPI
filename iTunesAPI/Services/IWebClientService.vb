
''' <summary>
''' Override DownloadString for mocking
''' </summary>
''' <param name="url">url with query string</param>
''' <returns>response from the server</returns>
''' <remarks></remarks>
Public Interface IWebClientService
    Function DownloadString(ByVal url As String) As String
End Interface
