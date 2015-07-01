Public Interface ISongsService
    ''' <summary>
    ''' Main function for songs search
    ''' </summary>
    ''' <param name="artistName">search by this parameter</param>
    ''' <returns>songs list that fits the artist name</returns>
    ''' <remarks></remarks>
    Function GetSongs(artistName As String) As List(Of String)
End Interface
