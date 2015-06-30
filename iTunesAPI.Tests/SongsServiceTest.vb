Imports NUnit.Framework

<TestFixture> _
Public Class SongsServiceTest

    <Test> _
    Public Sub GetSongs_UrlEmptyOrNull_ReturnsEmptyList()
        ServiceLocator.Init()
        Dim songsService As SongsServiceLive = ServiceLocator.GetService(Of ISongsService)()

        Dim songs = songsService.GetSongs(Nothing)

        Assert.AreEqual(0, songs.Count)
    End Sub

End Class