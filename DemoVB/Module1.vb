Module Module1
    Public s_Form1 As Form1
    Public Sub UpdateLogInfo(ByVal input As String)
        If s_Form1 Is Nothing Then
            Return
        End If
        s_Form1.UpdateLogInfo(input)
    End Sub
End Module
