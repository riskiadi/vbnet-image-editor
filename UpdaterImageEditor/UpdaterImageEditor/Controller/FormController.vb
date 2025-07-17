Public Class FormController

    Private ReadOnly apiRepository As ApiRepository

    Public Sub New()
        apiRepository = New ApiRepository()
    End Sub

    Public Async Function GetConfig() As Task(Of ApiResponse)
        Return Await apiRepository.GetConfig()
    End Function

End Class