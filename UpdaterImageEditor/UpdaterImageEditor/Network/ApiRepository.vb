Imports Newtonsoft.Json.Linq

Public Class ApiRepository

    Private ReadOnly apiConfiguration As ApiConfiguration

    Public Sub New()
        apiConfiguration = New ApiConfiguration()
    End Sub

    Public Async Function GetConfig() As Task(Of ApiResponse)
        Dim jsonObject As JObject = Await apiConfiguration.GetApi(Of JObject)("staticSecretData")
        If jsonObject IsNot Nothing AndAlso jsonObject.HasValues Then
            Dim modelResult As ApiResponse = jsonObject.ToObject(Of ApiResponse)()
            Return modelResult
        Else
            Return Nothing
        End If
    End Function

End Class
