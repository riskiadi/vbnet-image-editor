Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class FormComment

    Private _textColor As Color = Color.Black
    Public Property TextColor As Color
        Get
            Return _textColor
        End Get
        Set(value As Color)
            _textColor = value
            PictureBox1.BackColor = value
        End Set
    End Property

    Private _bgColor As Color = Color.White
    Public Property BgColor As Color
        Get
            Return _bgColor
        End Get
        Set(value As Color)
            _bgColor = value
            PictureBox2.BackColor = value
        End Set
    End Property

    Public Property CommentText As String
        Get
            Return TextBox1.Text
        End Get
        Set(value As String)
            TextBox1.Text = value
        End Set
    End Property

    Private _commentTextSize
    Public Property CommentTextSize As Integer
        Get
            Return _commentTextSize
        End Get
        Set(value As Integer)
            _commentTextSize = value
        End Set
    End Property

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim cDialog As New ColorDialog()
        cDialog.Color = TextColor
        If (cDialog.ShowDialog() = DialogResult.OK) Then
            TextColor = cDialog.Color
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim cDialog As New ColorDialog()
        cDialog.Color = BgColor
        If (cDialog.ShowDialog() = DialogResult.OK) Then
            BgColor = cDialog.Color
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        CommentTextSize = CInt(ComboBox1.SelectedItem)
    End Sub

    Private Sub FormComment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.AddRange(New Object() {8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20})
        ComboBox1.SelectedIndex = 2
    End Sub
End Class