Imports System.IO
Imports System.Reflection
Imports Renci.SshNet
Imports System.Runtime.InteropServices
Imports Renci.SshNet.Sftp

Public Class Form1

    Private ReadOnly formController As FormController
    Private ReadOnly apiRepository As ApiRepository

    Private SftpHost As String = ""
    Private SftpUsername As String = ""
    Private SftpPassword As String = ""
    Private serverUpdatePath As String = ""

    Private hospitalAppStream As FileStream
    Private countScanningFile As Integer = 0
    Private downloadStartTime As DateTime
    Private totalBytesDownloaded As Long
    Private basePath As String = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)

    Public Sub New()
        formController = New FormController()
        InitializeComponent()
    End Sub

    ' Deklarasi fungsi API
    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function FindWindowEx(hwndParent As IntPtr, hwndChildAfter As IntPtr, lpszClass As String, lpszWindow As String) As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function GetWindowThreadProcessId(hWnd As IntPtr, ByRef lpdwProcessId As UInteger) As UInteger
    End Function

    <DllImport("user32.dll")>
    Private Shared Function SetForegroundWindow(hWnd As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll")>
    Private Shared Function ShowWindow(hWnd As IntPtr, nCmdShow As Integer) As Boolean
    End Function

    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            InfoLabel.Text = "Get configuration..."
            Dim result = Await formController.GetConfig()

            If result.Code = 200 Then

                SftpHost = result.Data.ImageEditor.SftpHost
                SftpUsername = result.Data.ImageEditor.SftpUsername
                SftpPassword = result.Data.ImageEditor.SftpPassword
                serverUpdatePath = result.Data.ImageEditor.ServerUpdatePath

            Else
                MessageBox.Show(result.Message)
            End If

            Dim task As Task = Task.Run(Function() DownloadFileByArray())
            Await task
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Async Function DownloadFileByArray() As Task
        Try

            InfoLabel.Text = "Connecting to storage..."

            Await Task.Run(Async Function()
                               Using client As New SftpClient(SftpHost, SftpUsername, SftpPassword)
                                   Try

                                       ' Menutup aplikasi yang sedang berjalan
                                       Dim proc = Process.GetProcessesByName("ImageEditor")
                                       For i As Integer = 0 To proc.Count - 1
                                           proc(i).CloseMainWindow()
                                       Next i

                                       ' Koneksi ke SFTP
                                       client.Connect()

                                       ' Mendapatkan daftar file
                                       Dim files = client.ListDirectory(serverUpdatePath)

                                       ' Pastikan UI tetap responsif dengan memanggil di thread utama
                                       Me.Invoke(Sub() InfoLabel.Text = $"Downloading {files.Count()} files...")

                                       For Each file In files

                                           If file.IsDirectory AndAlso file.Name.Equals("updater", StringComparison.OrdinalIgnoreCase) Then
                                               Continue For
                                           End If

                                           If Not file.Name.StartsWith(".") Then
                                               Dim localFilePath As String = Path.Combine($"{basePath}\..\", file.Name)

                                               Try
                                                   ' Mengunduh file
                                                   Using fileStream As New FileStream(localFilePath, FileMode.Create)
                                                       client.DownloadFile(file.FullName, fileStream)
                                                   End Using
                                               Catch ex As Exception
                                                   ' Log kesalahan jika terjadi error saat mengunduh file
                                                   Me.Invoke(Sub() InfoLabel.Text = $"Error downloading {file.Name}: {ex.Message}")
                                               End Try
                                           End If

                                       Next

                                   Catch ex As Exception
                                       Me.Invoke(Sub() InfoLabel.Text = $"Error: {ex.Message}")
                                   Finally
                                       If client.IsConnected Then client.Disconnect()
                                   End Try
                               End Using
                           End Function)

            OpenImageEditorApp()

        Catch ex As Exception
            InfoLabel.Text = $"Download failed: {ex.Message}"
        End Try
    End Function

    Private Sub OpenImageEditorApp()
        Dim appPath As String = Path.Combine(basePath, "..\ImageEditor.exe")
        Dim proc As Process = Process.Start(appPath)
        Threading.Thread.Sleep(100)
        Dim hWnd As IntPtr = FindWindowByProcessId(proc.Id)
        If hWnd <> IntPtr.Zero Then
            SetForegroundWindow(hWnd)
        End If
        Close()
    End Sub

    Private Function FindWindowByProcessId(processId As Integer) As IntPtr
        Dim hWnd As IntPtr = IntPtr.Zero
        Do
            hWnd = FindWindowEx(IntPtr.Zero, hWnd, Nothing, Nothing)
            If hWnd = IntPtr.Zero Then Exit Do

            Dim windowProcessId As UInteger
            GetWindowThreadProcessId(hWnd, windowProcessId)

            If windowProcessId = processId Then
                Return hWnd
            End If
        Loop While hWnd <> IntPtr.Zero

        Return IntPtr.Zero
    End Function

End Class
