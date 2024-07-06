Imports System.IO
Imports System.Reflection
Imports Renci.SshNet

Public Class Form1

    Private SftpHost As String = "10.10.7.12"
    Private SftpUsername As String = "pd3"
    Private SftpPassword As String = "p4$$w0rd"

    Private hospitalAppStream As FileStream
    Private countScanningFile As Integer = 0
    Private downloadStartTime As DateTime
    Private totalBytesDownloaded As Long
    Private basePath As String = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)

    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MessageBox.Show(basePath)

        Try
            Process.Start($"app\ImageEditor.exe")
        Catch ex As Exception
            MessageBox.Show($"Tidak dapat membuka ImageEditor.exe, {ex}")
        End Try

        'Dim task As Task = Task.Run(Function() DownloadFileByArray())
        'Await task
    End Sub


    Private Async Function DownloadFileByArray() As Task

        Await Task.Run(Async Sub()
                           Using client As New SftpClient(SftpHost, SftpUsername, SftpPassword)

                               Dim proc = Process.GetProcessesByName("ImageEditor")
                               For i As Integer = 0 To proc.Count - 1
                                   proc(i).CloseMainWindow()
                               Next i

                               client.Connect()

                               Dim files = client.ListDirectory("updtsim/Update Image Editor RME/")

                               For Each file In files
                                   If Not file.Name.StartsWith(".") Then ' Skip hidden files and directories
                                       Dim localFilePath As String = Path.Combine($"{basePath}\app\", file.Name)
                                       Using fileStream As New FileStream(localFilePath, FileMode.Create)
                                           client.DownloadFile(file.FullName, fileStream)
                                       End Using
                                   End If
                               Next

                               client.Disconnect()

                               OpenProgram()

                           End Using

                       End Sub)
    End Function

    Private Sub OpenProgram()
        Try
            Process.Start($"{basePath}\app\ImageEditor.exe")
            Me.Close()
        Catch ex As Exception
            MessageBox.Show($"Tidak dapat membuka ImageEditor.exe, {ex}")
        End Try
    End Sub


End Class
