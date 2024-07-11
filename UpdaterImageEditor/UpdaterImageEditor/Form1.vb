Imports System.IO
Imports System.Reflection
Imports Renci.SshNet
Imports System.Runtime.InteropServices

Public Class Form1

    Private SftpHost As String = My.Settings.SftpHost
    Private SftpUsername As String = My.Settings.SftpUsername
    Private SftpPassword As String = My.Settings.SftpPassword
    Private serverUpdatePath As String = My.Settings.ServerUpdatePath

    Private hospitalAppStream As FileStream
    Private countScanningFile As Integer = 0
    Private downloadStartTime As DateTime
    Private totalBytesDownloaded As Long
    Private basePath As String = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)

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
        Dim task As Task = Task.Run(Function() DownloadFileByArray())
        Await task
    End Sub


    Private Async Function DownloadFileByArray() As Task

        Await Task.Run(Async Sub()
                           Using client As New SftpClient(SftpHost, SftpUsername, SftpPassword)

                               Dim proc = Process.GetProcessesByName("ImageEditor")
                               For i As Integer = 0 To proc.Count - 1
                                   proc(i).CloseMainWindow()
                               Next i

                               client.Connect()

                               Dim files = client.ListDirectory(serverUpdatePath)

                               For Each file In files

                                   If file.IsDirectory AndAlso file.Name.Equals("updater", StringComparison.OrdinalIgnoreCase) Then
                                       Continue For
                                   End If

                                   If Not file.Name.StartsWith(".") Then ' Skip hidden files and directories
                                       Dim localFilePath As String = Path.Combine($"{basePath}\..\", file.Name)
                                       Using fileStream As New FileStream(localFilePath, FileMode.Create)
                                           client.DownloadFile(file.FullName, fileStream)
                                       End Using
                                   End If
                               Next

                               client.Disconnect()

                               OpenImageEditorApp()

                           End Using

                       End Sub)
    End Function

    'Private Sub OpenProgram()
    '    Try
    '        Dim appPath As String = Path.Combine(basePath, "..\ImageEditor.exe")
    '        appPath = Path.GetFullPath(appPath)
    '        Process.Start(appPath)
    '        Me.Close()
    '    Catch ex As Exception
    '        MessageBox.Show($"Tidak dapat membuka ImageEditor.exe, {ex}")
    '    End Try
    'End Sub

    Private Sub OpenImageEditorApp()
        Dim appPath As String = Path.Combine(basePath, "..\ImageEditor.exe")
        Dim proc As Process = Process.Start(appPath)
        Threading.Thread.Sleep(100)
        Dim hWnd As IntPtr = FindWindowByProcessId(proc.Id)
        If hWnd <> IntPtr.Zero Then
            ' Memfokuskan jendela aplikasi
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
