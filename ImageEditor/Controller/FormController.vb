Public Class FormController

    Private ReadOnly apiRepository As ApiRepository

    Public Sub New()
        apiRepository = New ApiRepository()
    End Sub

    Public Async Function GetCurentVersion() As Task(Of CurentAppVersionResponseModel)
        Return Await apiRepository.GetCurentAppVersion()
    End Function

    Public Async Function PostRmeDataImage(postData As String) As Task(Of PostRmeDataImageResponseModel)
        Return Await apiRepository.PostRmeDataImage(postData)
    End Function

End Class