Public Class ApiResponse
    Public Property Code As Integer
    Public Property Message As String
    Public Property Data As StaticData
End Class

Public Class StaticData
    Public Property ImageEditor As ImageEditorData
End Class

Public Class ImageEditorData
    Public Property SftpHost As String
    Public Property SftpUsername As String
    Public Property SftpPassword As String
    Public Property ServerUpdatePath As String
End Class