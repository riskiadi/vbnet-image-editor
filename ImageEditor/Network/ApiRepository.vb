Imports System.Net.Http
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class ApiRepository

    Private ReadOnly apiConfiguration As ApiConfiguration

    Public Sub New()
        ' Inisialisasi ApiConfiguration di konstruktor
        apiConfiguration = New ApiConfiguration()
    End Sub

    Public Async Function GetCurentAppVersion() As Task(Of CurentAppVersionResponseModel)
        Dim jsonObject As JObject = Await apiConfiguration.GetApi(Of JObject)("getImageEditorVersion")
        If jsonObject IsNot Nothing AndAlso jsonObject.HasValues Then
            Dim modelResult As CurentAppVersionResponseModel = jsonObject.ToObject(Of CurentAppVersionResponseModel)()
            Return modelResult
        Else
            Return Nothing
        End If
    End Function

    'Public Async Function LoginUser(username As String, password As String) As Task(Of LoginReponseModel)
    '    Dim formData As New List(Of KeyValuePair(Of String, String)) From {
    '    New KeyValuePair(Of String, String)("username", username),
    '    New KeyValuePair(Of String, String)("password", password)
    '    }
    '    Dim jsonObject As JObject = Await apiConfiguration.PostApi(Of JObject)("login", formData)
    '    If jsonObject IsNot Nothing AndAlso jsonObject.HasValues Then
    '        Dim loginReponseModel As LoginReponseModel = jsonObject.ToObject(Of LoginReponseModel)()
    '        Return loginReponseModel
    '    Else
    '        Return Nothing
    '    End If
    'End Function

    'Public Async Function GetCommitHistory() As Task(Of CommitHistoryResponseModel)
    '    Dim jsonObject As JObject = Await apiConfiguration.GetApi(Of JObject)("getCommitHistory")
    '    If jsonObject IsNot Nothing AndAlso jsonObject.HasValues Then
    '        Dim modelResult As CommitHistoryResponseModel = jsonObject.ToObject(Of CommitHistoryResponseModel)()
    '        Return modelResult
    '    Else
    '        Return Nothing
    '    End If
    'End Function

    'Public Async Function GetLiveFile() As Task(Of LiveFileResponseModel)
    '    Dim jsonObject As JObject = Await apiConfiguration.GetApi(Of JObject)("getLiveFile")
    '    If jsonObject IsNot Nothing AndAlso jsonObject.HasValues Then
    '        Dim modelResult As LiveFileResponseModel = jsonObject.ToObject(Of LiveFileResponseModel)()
    '        Return modelResult
    '    Else
    '        Return Nothing
    '    End If
    'End Function

    'Public Async Function GetFileTracking(commitId As String) As Task(Of FileTrackingResponseModel)
    '    Dim jsonObject As JObject = Await apiConfiguration.GetApi(Of JObject)("getFileTracking?commit_id=" + commitId.ToString)
    '    If jsonObject IsNot Nothing AndAlso jsonObject.HasValues Then
    '        Dim modelResult As FileTrackingResponseModel = jsonObject.ToObject(Of FileTrackingResponseModel)()
    '        Return modelResult
    '    Else
    '        Return Nothing
    '    End If
    'End Function

    'Public Async Function PostLiveFile(postData As String) As Task(Of PostLiveFileResponseModel)
    '    Dim jsonObject As JObject = Await apiConfiguration.PostApi2(Of JObject)("postLiveFile", postData)
    '    If jsonObject IsNot Nothing AndAlso jsonObject.HasValues Then
    '        Dim modelResult As PostLiveFileResponseModel = jsonObject.ToObject(Of PostLiveFileResponseModel)()
    '        Return modelResult
    '    Else
    '        Return Nothing
    '    End If
    'End Function

End Class
