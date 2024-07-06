Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports Newtonsoft.Json

Public Class ApiConfiguration

    ' True = Local Network | False = Server Network
    Private ReadOnly isDevelopmentMode = False

    Public Async Function GetApi(Of T)(endPoint As String) As Task(Of T)
        Using client As New HttpClient()
            Dim URI As New Uri(If(isDevelopmentMode, My.Settings.BaseUrlDev, My.Settings.BaseUrlProd) + endPoint)
            Dim response = Await client.GetAsync(URI)
            If response.IsSuccessStatusCode Then
                ' Jika respon berhasil, membaca dan mengonversi JSON ke objek T
                Dim json = Await response.Content.ReadAsStringAsync()
                Return JsonConvert.DeserializeObject(Of T)(json)
            Else
                ' Handle kesalahan jika diperlukan
                Throw New Exception($"Gagal mendapatkan data dari API. Kode status: {response}")
            End If
        End Using
    End Function

    Public Async Function PostApi(Of T)(endPoint As String, formData As List(Of KeyValuePair(Of String, String))) As Task(Of T)
        Using client As New HttpClient()
            Dim URI As New Uri(If(isDevelopmentMode, My.Settings.BaseUrlDev, My.Settings.BaseUrlProd) + endPoint)
            Dim formContent As New FormUrlEncodedContent(formData)
            Dim response = Await client.PostAsync(URI, formContent)
            Dim json = Await response.Content.ReadAsStringAsync()
            Return JsonConvert.DeserializeObject(Of T)(json)
        End Using
    End Function

    Public Async Function PostApi2(Of T)(endPoint As String, jsonData As String) As Task(Of T)
        Using client As New HttpClient()
            client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
            Dim URI As New Uri(If(isDevelopmentMode, My.Settings.BaseUrlDev, My.Settings.BaseUrlProd) + endPoint)
            Dim jsonContent As New StringContent(jsonData, Encoding.UTF8, "application/json")
            Dim response = Await client.PostAsync(URI, jsonContent)
            If response.IsSuccessStatusCode Then
                Dim jsonResult = Await response.Content.ReadAsStringAsync()
                Return JsonConvert.DeserializeObject(Of T)(jsonResult)
            Else
                Throw New Exception($"Failed to get data from API. Status code: {response.StatusCode}")
            End If
        End Using
    End Function

End Class
