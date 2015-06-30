Imports NUnit.Framework
Imports Moq

<TestFixture> _
Public Class SongsServiceTest

    <TestCase(Nothing)>
    <TestCase("")>
    Public Sub GetSongs_UrlEmptyOrNull_ReturnsEmptyList(url As String)
        'Arrange
        ServiceLocator.Init()
        Dim songsService = ServiceLocator.GetService(Of ISongsService)()

        'Act
        Dim songs = songsService.GetSongs(url)

        'Assert
        Assert.AreEqual(0, songs.Count)
    End Sub

    <Test> _
    Public Sub GetSongs_CallWebClient_ExactlyOnce()
        ServiceLocator.Init()
        Dim songsService = ServiceLocator.GetService(Of ISongsService)()
        Dim webClientServiceMock As New Mock(Of IWebClientService)
        ServiceLocator.ReplaceService(Of IWebClientService)(webClientServiceMock.Object)
        'webClientServiceMock.Setup(Function(m) m.DownloadString(It.IsAny(Of String))).Returns("")

        Dim songs = songsService.GetSongs("")

        webClientServiceMock.Verify(Function(m) m.DownloadString(It.IsAny(Of String)), Times.Once)
    End Sub

End Class