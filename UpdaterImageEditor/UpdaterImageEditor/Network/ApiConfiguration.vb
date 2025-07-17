Imports System.Net.Http
Imports Newtonsoft.Json

Public Class ApiConfiguration

    Public Async Function GetApi(Of T)(endPoint As String) As Task(Of T)
        Using client As New HttpClient()
            Try
                Dim URI As New Uri(My.Settings.BaseUrl + endPoint)
                client.DefaultRequestHeaders.Add("x-token", "y82Y4T#@nL=Image_Editor")
                Dim response = Await client.GetAsync(URI)

                If response.IsSuccessStatusCode Then
                    Dim json = Await response.Content.ReadAsStringAsync()
                    Return JsonConvert.DeserializeObject(Of T)(json)
                Else
                    ' Log error dengan status code
                    Dim errorContent = Await response.Content.ReadAsStringAsync()
                    Throw New Exception($"Gagal mendapatkan data dari API. Kode status: {response.StatusCode}, Pesan: {errorContent}")
                End If

            Catch ex As Exception
                ' Tangani error jaringan atau lainnya
                Throw New Exception($"Terjadi kesalahan: {ex.Message}")
            End Try
        End Using
    End Function

End Class
