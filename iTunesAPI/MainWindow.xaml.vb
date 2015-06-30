Imports System.Collections.ObjectModel
Imports Newtonsoft.Json.Linq
Class MainWindow

    Public Property Songs As New ObservableCollection(Of String)
    Private _songsService As ISongsService

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        Me.DataContext = Me
        ServiceLocator.Init()
        _songsService = ServiceLocator.GetService(Of ISongsService)()
    End Sub
    ''' <summary>
    ''' When pressing the button, perform a web service call and get songs that fits artist name
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSearch_Click(sender As Object, e As RoutedEventArgs) Handles btnSearch.Click
        Dim songsList = _songsService.GetSongs(txbArtist.Text)
        Songs.Clear()
        For Each song As String In songsList
            Songs.Add(song)
        Next
        lblAveragePrice.Content = _songsService.GetAverageTime
    End Sub
End Class
