''' <summary>
''' DI for ServiceLocator
''' </summary>
''' <remarks></remarks>
Public Class ServiceLocator
    ''' <summary>
    ''' map that contains pairs of interfaces and
    ''' references to concrete implementations
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared services As IDictionary(Of Object, Object)
    ''' <summary>
    ''' Use Init on app start ONLY ONCE
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub Init()
        services = New Dictionary(Of Object, Object)()

        ' fill the map
        services.Add(GetType(ISongsService), New SongsService())
        services.Add(GetType(IWebClientService), New WebClientService())
    End Sub
    ''' <summary>
    ''' Get the suitable service
    ''' </summary>
    ''' <typeparam name="T">Service type</typeparam>
    ''' <returns>suitable service</returns>
    ''' <remarks></remarks>
    Public Shared Function GetService(Of T)() As T
        Try
            Return DirectCast(services(GetType(T)), T)
        Catch generatedExceptionName As KeyNotFoundException
            Throw New ApplicationException("The requested service is not registered")
        End Try
    End Function
End Class