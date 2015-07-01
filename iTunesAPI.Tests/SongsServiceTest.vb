Imports NUnit.Framework
Imports Moq

<TestFixture>
Public Class SongsServiceTest

    Private _songsService As ISongsService
    Private _webClientServiceMock As Mock(Of IWebClientService)

    <SetUp>
    Public Sub Init()
        ServiceLocator.Init()
        _songsService = ServiceLocator.GetService(Of ISongsService)()
        _webClientServiceMock = New Mock(Of IWebClientService)
        ServiceLocator.ReplaceService(Of IWebClientService)(_webClientServiceMock.Object)
    End Sub
    <TestCase(Nothing)>
    <TestCase("")>
    Public Sub GetSongs_UrlEmptyOrNull_ReturnsEmptyList(url As String)
        'Arrange
        _webClientServiceMock.Setup(Function(m) m.DownloadString(It.IsAny(Of String))).Returns("")

        'Act
        Dim songs = _songsService.GetSongs(url)

        'Assert
        Assert.AreEqual(0, songs.Count)
    End Sub
    <Test>
    Public Sub GetSongs_WebClient_CalledOnce()
        _webClientServiceMock.Setup(Function(m) m.DownloadString(It.IsAny(Of String))).Returns("")

        _songsService.GetSongs("")

        _webClientServiceMock.Verify(Function(m) m.DownloadString(It.IsAny(Of String)), Times.Once)
    End Sub
    <Test>
    Public Sub GetSongs_WebClientThrowsWebException_ReturnsEmptyList()
        _webClientServiceMock.Setup(Function(m) m.DownloadString(It.IsAny(Of String))).Throws(Of System.Net.WebException)()

        Dim songs = _songsService.GetSongs("")

        Assert.AreEqual(0, songs.Count)
    End Sub
    <Test>
    Public Sub GetSongs_WebClientGets3Songs_ReturnsListWith3Songs()
        Dim threeSongs As String = "{""resultCount"": 3, ""results"": [{""wrapperType"": ""track"", ""kind"": ""song"", ""artistId"": 217005, ""collectionId"": 251947909, ""trackId"": 251948354, ""artistName"": ""Britney Spears"", ""collectionName"": ""In the Zone"", ""trackName"": ""Toxic"", ""collectionCensoredName"": ""In the Zone"", ""trackCensoredName"": ""Toxic"", ""artistViewUrl"": ""https://itunes.apple.com/us/artist/britney-spears/id217005?uo=4"", ""collectionViewUrl"": ""https://itunes.apple.com/us/album/toxic/id251947909?i=251948354&uo=4"", ""trackViewUrl"": ""https://itunes.apple.com/us/album/toxic/id251947909?i=251948354&uo=4"", ""previewUrl"": ""http://a117.phobos.apple.com/us/r1000/080/Music/92/53/9a/mzm.taqrhbut.aac.p.m4a"", ""artworkUrl30"": ""http://is2.mzstatic.com/image/pf/us/r30/Music/fb/8d/21/mzi.rjjkdcsj.30x30-50.jpg"", ""artworkUrl60"": ""http://is4.mzstatic.com/image/pf/us/r30/Music/fb/8d/21/mzi.rjjkdcsj.60x60-50.jpg"", ""artworkUrl100"": ""http://is3.mzstatic.com/image/pf/us/r30/Music/fb/8d/21/mzi.rjjkdcsj.100x100-75.jpg"", ""collectionPrice"": 9.99, ""trackPrice"": 1.29, ""releaseDate"": ""2003-01-01T08:00:00Z"", ""collectionExplicitness"": ""notExplicit"", ""trackExplicitness"": ""notExplicit"", ""discCount"": 1, ""discNumber"": 1, ""trackCount"": 13, ""trackNumber"": 6, ""trackTimeMillis"": 60000, ""country"": ""USA"", ""currency"": ""USD"", ""primaryGenreName"": ""Pop"", ""radioStationUrl"": ""https://itunes.apple.com/station/idra.251948354"", ""isStreamable"": true }, {""wrapperType"": ""track"", ""kind"": ""song"", ""artistId"": 217005, ""collectionId"": 296667896, ""trackId"": 296667984, ""artistName"": ""Britney Spears"", ""collectionName"": ""Circus (Deluxe Version)"", ""trackName"": ""Circus"", ""collectionCensoredName"": ""Circus (Deluxe Version)"", ""trackCensoredName"": ""Circus"", ""artistViewUrl"": ""https://itunes.apple.com/us/artist/britney-spears/id217005?uo=4"", ""collectionViewUrl"": ""https://itunes.apple.com/us/album/circus/id296667896?i=296667984&uo=4"", ""trackViewUrl"": ""https://itunes.apple.com/us/album/circus/id296667896?i=296667984&uo=4"", ""previewUrl"": ""http://a691.phobos.apple.com/us/r1000/101/Music/50/90/60/mzm.snzdnnxy.aac.p.m4a"", ""artworkUrl30"": ""http://is2.mzstatic.com/image/pf/us/r30/Music/d5/b2/60/mzi.doisfoll.30x30-50.jpg"", ""artworkUrl60"": ""http://is1.mzstatic.com/image/pf/us/r30/Music/d5/b2/60/mzi.doisfoll.60x60-50.jpg"", ""artworkUrl100"": ""http://is4.mzstatic.com/image/pf/us/r30/Music/d5/b2/60/mzi.doisfoll.100x100-75.jpg"", ""collectionPrice"": 13.99, ""trackPrice"": 1.29, ""releaseDate"": ""2008-12-01T08:00:00Z"", ""collectionExplicitness"": ""notExplicit"", ""trackExplicitness"": ""notExplicit"", ""discCount"": 1, ""discNumber"": 1, ""trackCount"": 15, ""trackNumber"": 2, ""trackTimeMillis"": 180000, ""country"": ""USA"", ""currency"": ""USD"", ""primaryGenreName"": ""Pop"", ""radioStationUrl"": ""https://itunes.apple.com/station/idra.296667984"", ""isStreamable"": true }, {""wrapperType"": ""track"", ""kind"": ""song"", ""artistId"": 217005, ""collectionId"": 296667896, ""trackId"": 296667979, ""artistName"": ""Britney Spears"", ""collectionName"": ""Circus (Deluxe Version)"", ""trackName"": ""Womanizer"", ""collectionCensoredName"": ""Circus (Deluxe Version)"", ""trackCensoredName"": ""Womanizer"", ""artistViewUrl"": ""https://itunes.apple.com/us/artist/britney-spears/id217005?uo=4"", ""collectionViewUrl"": ""https://itunes.apple.com/us/album/womanizer/id296667896?i=296667979&uo=4"", ""trackViewUrl"": ""https://itunes.apple.com/us/album/womanizer/id296667896?i=296667979&uo=4"", ""previewUrl"": ""http://a619.phobos.apple.com/us/r1000/060/Music/d4/64/cd/mzm.nwcstxzx.aac.p.m4a"", ""artworkUrl30"": ""http://is2.mzstatic.com/image/pf/us/r30/Music/d5/b2/60/mzi.doisfoll.30x30-50.jpg"", ""artworkUrl60"": ""http://is1.mzstatic.com/image/pf/us/r30/Music/d5/b2/60/mzi.doisfoll.60x60-50.jpg"", ""artworkUrl100"": ""http://is4.mzstatic.com/image/pf/us/r30/Music/d5/b2/60/mzi.doisfoll.100x100-75.jpg"", ""collectionPrice"": 13.99, ""trackPrice"": 1.29, ""releaseDate"": ""2008-12-01T08:00:00Z"", ""collectionExplicitness"": ""notExplicit"", ""trackExplicitness"": ""notExplicit"", ""discCount"": 1, ""discNumber"": 1, ""trackCount"": 15, ""trackNumber"": 1, ""trackTimeMillis"": 300000, ""country"": ""USA"", ""currency"": ""USD"", ""primaryGenreName"": ""Pop"", ""radioStationUrl"": ""https://itunes.apple.com/station/idra.296667979"", ""isStreamable"": true } ] }"
        _webClientServiceMock.Setup(Function(m) m.DownloadString(It.IsAny(Of String))).Returns(threeSongs)

        Dim songs = _songsService.GetSongs("")

        Assert.AreEqual(3, songs.Count)
    End Sub
    <Test>
    Public Sub GetSongs_CalculateAverage_ShouldBe3()
        Dim threeSongs As String = "{""resultCount"": 3, ""results"": [{""wrapperType"": ""track"", ""kind"": ""song"", ""artistId"": 217005, ""collectionId"": 251947909, ""trackId"": 251948354, ""artistName"": ""Britney Spears"", ""collectionName"": ""In the Zone"", ""trackName"": ""Toxic"", ""collectionCensoredName"": ""In the Zone"", ""trackCensoredName"": ""Toxic"", ""artistViewUrl"": ""https://itunes.apple.com/us/artist/britney-spears/id217005?uo=4"", ""collectionViewUrl"": ""https://itunes.apple.com/us/album/toxic/id251947909?i=251948354&uo=4"", ""trackViewUrl"": ""https://itunes.apple.com/us/album/toxic/id251947909?i=251948354&uo=4"", ""previewUrl"": ""http://a117.phobos.apple.com/us/r1000/080/Music/92/53/9a/mzm.taqrhbut.aac.p.m4a"", ""artworkUrl30"": ""http://is2.mzstatic.com/image/pf/us/r30/Music/fb/8d/21/mzi.rjjkdcsj.30x30-50.jpg"", ""artworkUrl60"": ""http://is4.mzstatic.com/image/pf/us/r30/Music/fb/8d/21/mzi.rjjkdcsj.60x60-50.jpg"", ""artworkUrl100"": ""http://is3.mzstatic.com/image/pf/us/r30/Music/fb/8d/21/mzi.rjjkdcsj.100x100-75.jpg"", ""collectionPrice"": 9.99, ""trackPrice"": 1.29, ""releaseDate"": ""2003-01-01T08:00:00Z"", ""collectionExplicitness"": ""notExplicit"", ""trackExplicitness"": ""notExplicit"", ""discCount"": 1, ""discNumber"": 1, ""trackCount"": 13, ""trackNumber"": 6, ""trackTimeMillis"": 60000, ""country"": ""USA"", ""currency"": ""USD"", ""primaryGenreName"": ""Pop"", ""radioStationUrl"": ""https://itunes.apple.com/station/idra.251948354"", ""isStreamable"": true }, {""wrapperType"": ""track"", ""kind"": ""song"", ""artistId"": 217005, ""collectionId"": 296667896, ""trackId"": 296667984, ""artistName"": ""Britney Spears"", ""collectionName"": ""Circus (Deluxe Version)"", ""trackName"": ""Circus"", ""collectionCensoredName"": ""Circus (Deluxe Version)"", ""trackCensoredName"": ""Circus"", ""artistViewUrl"": ""https://itunes.apple.com/us/artist/britney-spears/id217005?uo=4"", ""collectionViewUrl"": ""https://itunes.apple.com/us/album/circus/id296667896?i=296667984&uo=4"", ""trackViewUrl"": ""https://itunes.apple.com/us/album/circus/id296667896?i=296667984&uo=4"", ""previewUrl"": ""http://a691.phobos.apple.com/us/r1000/101/Music/50/90/60/mzm.snzdnnxy.aac.p.m4a"", ""artworkUrl30"": ""http://is2.mzstatic.com/image/pf/us/r30/Music/d5/b2/60/mzi.doisfoll.30x30-50.jpg"", ""artworkUrl60"": ""http://is1.mzstatic.com/image/pf/us/r30/Music/d5/b2/60/mzi.doisfoll.60x60-50.jpg"", ""artworkUrl100"": ""http://is4.mzstatic.com/image/pf/us/r30/Music/d5/b2/60/mzi.doisfoll.100x100-75.jpg"", ""collectionPrice"": 13.99, ""trackPrice"": 1.29, ""releaseDate"": ""2008-12-01T08:00:00Z"", ""collectionExplicitness"": ""notExplicit"", ""trackExplicitness"": ""notExplicit"", ""discCount"": 1, ""discNumber"": 1, ""trackCount"": 15, ""trackNumber"": 2, ""trackTimeMillis"": 180000, ""country"": ""USA"", ""currency"": ""USD"", ""primaryGenreName"": ""Pop"", ""radioStationUrl"": ""https://itunes.apple.com/station/idra.296667984"", ""isStreamable"": true }, {""wrapperType"": ""track"", ""kind"": ""song"", ""artistId"": 217005, ""collectionId"": 296667896, ""trackId"": 296667979, ""artistName"": ""Britney Spears"", ""collectionName"": ""Circus (Deluxe Version)"", ""trackName"": ""Womanizer"", ""collectionCensoredName"": ""Circus (Deluxe Version)"", ""trackCensoredName"": ""Womanizer"", ""artistViewUrl"": ""https://itunes.apple.com/us/artist/britney-spears/id217005?uo=4"", ""collectionViewUrl"": ""https://itunes.apple.com/us/album/womanizer/id296667896?i=296667979&uo=4"", ""trackViewUrl"": ""https://itunes.apple.com/us/album/womanizer/id296667896?i=296667979&uo=4"", ""previewUrl"": ""http://a619.phobos.apple.com/us/r1000/060/Music/d4/64/cd/mzm.nwcstxzx.aac.p.m4a"", ""artworkUrl30"": ""http://is2.mzstatic.com/image/pf/us/r30/Music/d5/b2/60/mzi.doisfoll.30x30-50.jpg"", ""artworkUrl60"": ""http://is1.mzstatic.com/image/pf/us/r30/Music/d5/b2/60/mzi.doisfoll.60x60-50.jpg"", ""artworkUrl100"": ""http://is4.mzstatic.com/image/pf/us/r30/Music/d5/b2/60/mzi.doisfoll.100x100-75.jpg"", ""collectionPrice"": 13.99, ""trackPrice"": 1.29, ""releaseDate"": ""2008-12-01T08:00:00Z"", ""collectionExplicitness"": ""notExplicit"", ""trackExplicitness"": ""notExplicit"", ""discCount"": 1, ""discNumber"": 1, ""trackCount"": 15, ""trackNumber"": 1, ""trackTimeMillis"": 300000, ""country"": ""USA"", ""currency"": ""USD"", ""primaryGenreName"": ""Pop"", ""radioStationUrl"": ""https://itunes.apple.com/station/idra.296667979"", ""isStreamable"": true } ] }"
        _webClientServiceMock.Setup(Function(m) m.DownloadString(It.IsAny(Of String))).Returns(threeSongs)

        _songsService.GetSongs("")

        Assert.AreEqual("3.00", DirectCast(_songsService, SongsService).AverageTime)
    End Sub

End Class