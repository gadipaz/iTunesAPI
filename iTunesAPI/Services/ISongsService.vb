Public Interface ISongsService
    ''' <summary>
    ''' Get the average time
    ''' </summary>
    ''' <returns>Average time</returns>
    ''' <remarks></remarks>
    Function GetAverageTime() As String
    ''' <summary>
    ''' Main function for songs search
    ''' </summary>
    ''' <param name="artistName">search by this parameter</param>
    ''' <returns>songs list that fits the artist name</returns>
    ''' <remarks></remarks>
    Function GetSongs(artistName As String) As List(Of String)
End Interface
