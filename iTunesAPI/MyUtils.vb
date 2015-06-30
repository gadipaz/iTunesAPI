Public Class MyUtils
    Public Shared Function MillisToMin(milis As Int64) As String
        Return String.Format("{0:0.00}", (milis / 1000) / 60)
    End Function
End Class
