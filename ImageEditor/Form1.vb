Imports IniParser
Imports IniParser.Model
Imports System.Reflection
Imports System.IO
Imports FxResources.System
Imports Newtonsoft.Json
Imports System.Runtime.InteropServices

Public Class Form1

    '[config]
    'TemplatePath = \\10.10.7.12\shareimages\sitemarking\template
    'TemplateName = GIGI (PALMER SYSTEM).jpg

    'NamaTabel = RME_IMAGES
    'FilePath = \\10.10.7.12\shareimages\sitemarking\
    'FileName = uploaded.jpg
    'ID = 1234567890
    'IDHeadDoc = 123ABC
    'KodeDoc = EROP-1
    'NoReg = 1234567890
    'NoPasien = 665566
    'KodeBagian = 9301
    'UserInput = ADMIN
    'CompInput = MSI

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

    Private basePath As String = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
    Private iniPath As String = $"{basePath}\ImageEditor.ini"

    Private ReadOnly formController As FormController
    Dim parser As New FileIniDataParser()

    Dim iniTemplatePath = ""
    Dim iniTemplateName = ""
    Dim iniNamaTabel = ""
    Dim iniFilePath = ""
    Dim iniFileName = ""
    Dim iniID = ""
    Dim iniIDHeadDoc = ""
    Dim iniKodeDoc = ""
    Dim iniNoReg = ""
    Dim iniNoPasien = ""
    Dim iniKodeBagian = ""
    Dim iniUserInput = ""
    Dim iniCompInput = ""

    Dim appVersion = Assembly.GetExecutingAssembly().GetName().Version

    Private isPenMode As Boolean = False
    Private isTextMode As Boolean = False
    Private isEraseMode As Boolean = False

    Private lineWeight As Integer = 7
    Private lineColor As Color = Color.Black

    Private textSize As Integer = 12
    Private textFont As String = "Arial"
    Private textColor As Color = Color.Black

    Private commentTextSize As Integer = 10

    Private isDragging As Boolean = False
    Private isEditingEndPoint As Boolean = False
    Private isEditingStartPoint As Boolean = False
    Private selectedArrowIndex As Integer = -1
    Private selectedTextIndex As Integer = -1
    Private startPoint As Point
    Private endPoint As Point
    Private textPosition As Point
    Private WithEvents redrawTimer As New Timer() With {.Interval = 16} ' 60 FPS
    Private pendingRedraw As Boolean = False
    Private lastMouseX As Integer = -1
    Private lastMouseY As Integer = -1

    Private image As Bitmap
    Private arrows As New List(Of DrawArrow)
    Private texts As New List(Of DrawText)

    Public Sub New()

        formController = New FormController()

        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)

        Try

            CheckServerAppVersion()

            If Not File.Exists(iniPath) Then
                Try
                    Using writer As New StreamWriter($"{basePath}\ImageEditor.ini")
                        writer.WriteLine("[config]")
                        writer.WriteLine("TemplatePath=\\10.10.7.12\shareimages\sitemarking\template")
                        writer.WriteLine("TemplateName=GIGI (PALMER SYSTEM).jpg")
                        writer.WriteLine("NamaTabel=RME_IMAGES")
                        writer.WriteLine("FilePath=\\10.10.7.12\shareimages\sitemarking\")
                        writer.WriteLine("FileName=uploaded.jpg")
                        writer.WriteLine("ID=0")
                        writer.WriteLine("IDHeadDoc=0")
                        writer.WriteLine("KodeDoc=0")
                        writer.WriteLine("NoReg=0")
                        writer.WriteLine("NoPasien=0")
                        writer.WriteLine("KodeBagian=0")
                        writer.WriteLine("UserInput=0")
                        writer.WriteLine("CompInput=0")
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error, tidak dapat membuat file .ini: " & ex.Message)
                End Try
            End If

            Dim dataIni As IniData = parser.ReadFile($"{basePath}\ImageEditor.ini")
            iniTemplatePath = dataIni("config")("TemplatePath")
            iniTemplateName = dataIni("config")("TemplateName")
            iniNamaTabel = dataIni("config")("NamaTabel")
            iniFilePath = dataIni("config")("FilePath")
            iniFileName = dataIni("config")("FileName")
            iniID = dataIni("config")("ID")
            iniIDHeadDoc = dataIni("config")("IDHeadDoc")
            iniKodeDoc = dataIni("config")("KodeDoc")
            iniNoReg = dataIni("config")("NoReg")
            iniNoPasien = dataIni("config")("NoPasien")
            iniKodeBagian = dataIni("config")("KodeBagian")
            iniUserInput = dataIni("config")("UserInput")
            iniCompInput = dataIni("config")("CompInput")
        Catch ex As Exception
            MessageBox.Show("File ImageEditor.INI error atau tidak ditemukan.", "Image Editor RME - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try

        Me.DoubleBuffered = True
        InitializeComponent()
    End Sub

    Public Structure DrawArrow
        Public StartPoint As Point
        Public EndPoint As Point
        Public LineWeight As Integer
        Public LineColor As Color
        Public Comment As String
        Public CommentTextColor As Color
        Public CommentTextSize As Integer
        Public CommentBgColor As Color
    End Structure

    Public Structure DrawText
        Public Position As Point
        Public Content As String
        Public TextSize As Integer
        Public TextSizeIndex As Integer
        Public Font As String
        Public Color As Color
        Public BgColor As Color
    End Structure

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = $"Site Marking RME - RSUD dr Adhyatma MPH  (v.{appVersion.Major}.{appVersion.Minor}.{appVersion.Build})"

        CheckBox1.Checked = My.Settings.AlwaysAddComment

        AddHandler redrawTimer.Tick, AddressOf redrawTimer_Tick

        ComboBox1.Items.AddRange(New Object() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25})
        ComboBox1.SelectedIndex = 10
        lineWeight = CInt(ComboBox1.SelectedItem)
        PictureBox2.BackColor = lineColor


        Dim localPath As String = $"{AppDomain.CurrentDomain.BaseDirectory}\image.jpg"
        Try
            DownloadImage(iniTemplatePath, iniTemplateName, localPath)
            image = New Bitmap(localPath)
            PictureBox1.Image = image
        Catch ex As Exception
            MessageBox.Show("Gagal mengunduh gambar: " & ex.Message)
        End Try

    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown

        If isPenMode Then

            If e.Button = MouseButtons.Left Then
                selectedArrowIndex = GetSelectedArrowIndex(ConvertMouseToImageCoords(e.Location))
                If selectedArrowIndex >= 0 Then
                    Dim arrow = arrows(selectedArrowIndex)
                    If IsNearPoint(ConvertMouseToImageCoords(e.Location), arrow.StartPoint) Then
                        isEditingStartPoint = True
                    ElseIf IsNearPoint(ConvertMouseToImageCoords(e.Location), arrow.EndPoint) Then
                        isEditingEndPoint = True
                    End If
                Else
                    isDragging = True
                    startPoint = ConvertMouseToImageCoords(e.Location)
                    endPoint = ConvertMouseToImageCoords(e.Location)
                End If
            End If

        ElseIf isTextMode Then

            If e.Button = MouseButtons.Left Then
                ' Cari indeks teks yang diklik
                selectedTextIndex = GetSelectedTextIndex(ConvertMouseToImageCoords(e.Location))

                If selectedTextIndex >= 0 Then
                    ' Jika teks ditemukan, buka form edit
                    EditExistingText(selectedTextIndex)
                Else
                    ' Jika tidak ada teks, buat baru
                    AddNewText(ConvertMouseToImageCoords(e.Location))
                End If
            End If

        ElseIf isEraseMode = True Then

            If e.Button = MouseButtons.Left Then
                selectedArrowIndex = GetSelectedArrowIndex(ConvertMouseToImageCoords(e.Location))
                If selectedArrowIndex >= 0 AndAlso selectedArrowIndex < arrows.Count Then
                    arrows.RemoveAt(selectedArrowIndex)
                    selectedArrowIndex = -1
                    RedrawImage()
                End If

                selectedTextIndex = GetSelectedTextIndex(ConvertMouseToImageCoords(e.Location))
                If selectedTextIndex >= 0 AndAlso selectedTextIndex < texts.Count Then
                    texts.RemoveAt(selectedTextIndex)
                    selectedTextIndex = -1
                    RedrawImage()
                End If

            End If

        Else

        End If

        'If e.Button = MouseButtons.Left Then
        '    selectedArrowIndex = GetSelectedArrowIndex(e.Location)
        '    selectedTextIndex = GetSelectedTextIndex(e.Location)
        '    If selectedArrowIndex >= 0 Then
        '        Dim arrow = arrows(selectedArrowIndex)
        '        If IsNearPoint(e.Location, arrow.StartPoint) Then
        '            isEditingStartPoint = True
        '        ElseIf IsNearPoint(e.Location, arrow.EndPoint) Then
        '            isEditingEndPoint = True
        '        End If
        '    ElseIf selectedTextIndex >= 0 Then
        '        ' Begin editing text
        '        textPosition = texts(selectedTextIndex).Position
        '        TextBox1.Location = New Point(textPosition.X + PictureBox1.Left, textPosition.Y + PictureBox1.Top)
        '        TextBox1.Text = texts(selectedTextIndex).Content
        '        TextBox1.Visible = True
        '        TextBox1.Focus()
        '    Else
        '        isDragging = True
        '        startPoint = e.Location
        '        endPoint = e.Location
        '    End If
        'End If
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove

        Dim imagePoint As Point = ConvertMouseToImageCoords(e.Location)

        If isPenMode = True Then
            selectedArrowIndex = GetSelectedArrowIndex(ConvertMouseToImageCoords(e.Location))
            If selectedArrowIndex >= 0 Then
                PictureBox1.Cursor = Cursors.Hand
            Else
                PictureBox1.Cursor = Cursors.Cross
            End If
        ElseIf isTextMode = True Then

            Dim hoverIndex As Integer = GetSelectedTextIndex(imagePoint)
            PictureBox1.Cursor = If(hoverIndex >= 0, Cursors.Hand, Cursors.IBeam)

        End If


        Dim moveThreshold As Integer = If(isEditingStartPoint OrElse isEditingEndPoint, 3, 15)

        If Math.Abs(e.X - lastMouseX) > moveThreshold OrElse Math.Abs(e.Y - lastMouseY) > moveThreshold Then

            lastMouseX = e.X
            lastMouseY = e.Y

            If isDragging Then
                endPoint = ConvertMouseToImageCoords(e.Location)
                pendingRedraw = True
                If Not redrawTimer.Enabled Then redrawTimer.Start()
            ElseIf isEditingStartPoint AndAlso selectedArrowIndex >= 0 Then
                Dim arrow = arrows(selectedArrowIndex)
                If arrow.StartPoint <> ConvertMouseToImageCoords(e.Location) Then
                    arrow.StartPoint = ConvertMouseToImageCoords(e.Location)
                    arrows(selectedArrowIndex) = arrow
                    pendingRedraw = True
                End If
                If Not redrawTimer.Enabled Then redrawTimer.Start()
            ElseIf isEditingEndPoint AndAlso selectedArrowIndex >= 0 Then
                Dim arrow = arrows(selectedArrowIndex)
                If arrow.EndPoint <> ConvertMouseToImageCoords(e.Location) Then
                    arrow.EndPoint = ConvertMouseToImageCoords(e.Location)
                    arrows(selectedArrowIndex) = arrow
                    pendingRedraw = True
                End If
                If Not redrawTimer.Enabled Then redrawTimer.Start()
            End If

        End If




        'Dim moveThreshold As Integer = 15 ' Minimum perubahan posisi dalam piksel
        'If Math.Abs(e.X - lastMouseX) > moveThreshold OrElse Math.Abs(e.Y - lastMouseY) > moveThreshold Then
        '    lastMouseX = e.X
        '    lastMouseY = e.Y

        '    If isDragging Then
        '        endPoint = ConvertMouseToImageCoords(e.Location)
        '        pendingRedraw = True
        '        If Not redrawTimer.Enabled Then redrawTimer.Start()
        '    ElseIf isEditingStartPoint AndAlso selectedArrowIndex >= 0 Then
        '        Dim arrow = arrows(selectedArrowIndex)
        '        arrow.StartPoint = ConvertMouseToImageCoords(e.Location)
        '        arrows(selectedArrowIndex) = arrow
        '        pendingRedraw = True
        '        If Not redrawTimer.Enabled Then redrawTimer.Start()
        '    ElseIf isEditingEndPoint AndAlso selectedArrowIndex >= 0 Then
        '        Dim arrow = arrows(selectedArrowIndex)
        '        arrow.EndPoint = ConvertMouseToImageCoords(e.Location)
        '        arrows(selectedArrowIndex) = arrow
        '        pendingRedraw = True
        '        If Not redrawTimer.Enabled Then redrawTimer.Start()
        '    End If
        'End If

        'If isDragging Then
        '    endPoint = ConvertMouseToImageCoords(e.Location)
        '    RedrawImage()
        'ElseIf isEditingStartPoint AndAlso selectedArrowIndex >= 0 Then
        '    Dim arrow = arrows(selectedArrowIndex)
        '    arrow.StartPoint = ConvertMouseToImageCoords(e.Location)
        '    arrows(selectedArrowIndex) = arrow
        '    RedrawImage()
        'ElseIf isEditingEndPoint AndAlso selectedArrowIndex >= 0 Then
        '    Dim arrow = arrows(selectedArrowIndex)
        '    arrow.EndPoint = ConvertMouseToImageCoords(e.Location)
        '    arrows(selectedArrowIndex) = arrow
        '    RedrawImage()
        'End If

        '====== lawas
        'If isPenMode = True Then
        '    selectedArrowIndex = GetSelectedArrowIndex(ConvertMouseToImageCoords(e.Location))
        '    If selectedArrowIndex >= 0 Then
        '        PictureBox1.Cursor = Cursors.Hand
        '    Else
        '        PictureBox1.Cursor = Cursors.Cross
        '    End If
        'ElseIf isTextMode = True Then
        '    selectedTextIndex = GetSelectedTextIndex(ConvertMouseToImageCoords(e.Location))
        '    If selectedTextIndex >= 0 Then
        '        PictureBox1.Cursor = Cursors.Hand
        '    Else
        '        PictureBox1.Cursor = Cursors.IBeam
        '    End If
        'End If

        'If isDragging Then
        '    endPoint = ConvertMouseToImageCoords(e.Location)
        '    RedrawImage()
        'ElseIf isEditingStartPoint AndAlso selectedArrowIndex >= 0 Then
        '    Dim arrow = arrows(selectedArrowIndex)
        '    arrow.StartPoint = ConvertMouseToImageCoords(e.Location)
        '    arrows(selectedArrowIndex) = arrow
        '    RedrawImage()
        'ElseIf isEditingEndPoint AndAlso selectedArrowIndex >= 0 Then
        '    Dim arrow = arrows(selectedArrowIndex)
        '    arrow.EndPoint = ConvertMouseToImageCoords(e.Location)
        '    arrows(selectedArrowIndex) = arrow
        '    RedrawImage()
        'End If







        'If isDragging Then
        '    endPoint = ConvertMouseToImageCoords(e.Location)
        '    RedrawImage()
        'ElseIf isEditingStartPoint AndAlso selectedArrowIndex >= 0 Then
        '    Dim arrow = arrows(selectedArrowIndex)
        '    arrow.StartPoint = ConvertMouseToImageCoords(e.Location)
        '    arrows(selectedArrowIndex) = arrow
        '    RedrawImage()
        'ElseIf isEditingEndPoint AndAlso selectedArrowIndex >= 0 Then
        '    Dim arrow = arrows(selectedArrowIndex)
        '    arrow.EndPoint = ConvertMouseToImageCoords(e.Location)
        '    arrows(selectedArrowIndex) = arrow
        '    RedrawImage()
        'End If
    End Sub

    ' Fungsi untuk mengedit teks yang sudah ada
    Private Sub EditExistingText(index As Integer)

        Dim textToEdit = texts(index)

        Dim commentForm As New FormComment With {
            .CommentText = textToEdit.Content,
            .BgColor = textToEdit.BgColor,
            .TextColor = textToEdit.Color,
            .CommentTextSize = textToEdit.TextSize,
            .CommentTextSizeIndex = textToEdit.TextSizeIndex
        }

        If commentForm.ShowDialog() = DialogResult.OK Then
            textToEdit.Content = commentForm.CommentText
            textToEdit.TextSize = commentForm.CommentTextSize
            textToEdit.TextSizeIndex = commentForm.CommentTextSizeIndex
            textToEdit.Color = commentForm.TextColor
            textToEdit.BgColor = commentForm.BgColor
            texts(index) = textToEdit
            RedrawImage()
        End If

    End Sub

    ' Fungsi untuk menambahkan teks baru
    Private Sub AddNewText(position As Point)

        Dim commentForm As New FormComment()

        If commentForm.ShowDialog() = DialogResult.OK Then
            Dim newText As New DrawText With {
                .Position = position,
                .Content = commentForm.CommentText,
                .TextSize = commentForm.CommentTextSize,
                .TextSizeIndex = commentForm.CommentTextSizeIndex,
                .Color = commentForm.TextColor,
                .BgColor = commentForm.BgColor
            }
            texts.Add(newText)
            RedrawImage()
        End If

    End Sub

    Private Sub redrawTimer_Tick(sender As Object, e As EventArgs) Handles redrawTimer.Tick
        If pendingRedraw Then
            RedrawImage()
            pendingRedraw = False ' Reset flag setelah pembaruan
        Else
            redrawTimer.Stop() ' Hentikan timer jika tidak ada pembaruan
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp

        lastMouseX = -1
        lastMouseY = -1
        redrawTimer.Stop()

        If isDragging Then
            isDragging = False
            Dim newArrow As New DrawArrow With {
                .StartPoint = startPoint,
                .EndPoint = endPoint,
                .LineWeight = lineWeight,
                .LineColor = lineColor
            }

            ' Tampilkan kotak dialog if checked untuk memasukkan komentar
            If My.Settings.AlwaysAddComment Then

                Dim commentForm As New FormComment()
                Dim comment As String = String.Empty
                Dim commentTxtSize As Integer = 10
                Dim commentTxtColor As Color = Color.Black
                Dim commentBgColor As Color = Color.Gold

                If commentForm.ShowDialog() = DialogResult.OK Then
                    comment = commentForm.CommentText
                    commentTxtSize = commentForm.CommentTextSize
                    commentTxtColor = commentForm.TextColor
                    commentBgColor = commentForm.BgColor
                End If

                If Not String.IsNullOrEmpty(comment) Then
                    newArrow.Comment = comment
                    newArrow.CommentTextSize = commentTxtSize
                    newArrow.CommentTextColor = commentTxtColor
                    newArrow.CommentBgColor = commentBgColor
                End If

            End If

            arrows.Add(newArrow)
            RedrawImage()
        End If

        If isEditingStartPoint OrElse isEditingEndPoint Then
            isEditingStartPoint = False
            isEditingEndPoint = False
            RedrawImage()
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        isPenMode = Not isPenMode
        isTextMode = False
        isEraseMode = False
        If isPenMode Then
            Button4.BackColor = ColorTranslator.FromHtml("#97c5f1")
            PictureBox1.Cursor = Cursors.Cross
            Button5.BackColor = Color.Transparent
            Button6.BackColor = Color.Transparent
        Else
            Button4.BackColor = Color.Transparent
            PictureBox1.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        isPenMode = False
        isTextMode = False
        isEraseMode = Not isEraseMode
        If isEraseMode Then
            Button5.BackColor = ColorTranslator.FromHtml("#97c5f1")
            PictureBox1.Cursor = Cursors.Hand
            Button4.BackColor = Color.Transparent
            Button6.BackColor = Color.Transparent
        Else
            Button5.BackColor = Color.Transparent
            PictureBox1.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        isPenMode = False
        isTextMode = Not isTextMode
        isEraseMode = False
        If isTextMode Then
            Button6.BackColor = ColorTranslator.FromHtml("#97c5f1")
            PictureBox1.Cursor = Cursors.IBeam
            Button4.BackColor = Color.Transparent
            Button5.BackColor = Color.Transparent
        Else
            Button6.BackColor = Color.Transparent
            PictureBox1.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        lineWeight = CInt(ComboBox1.SelectedItem)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim cDialog As New ColorDialog()
        cDialog.Color = lineColor
        If (cDialog.ShowDialog() = DialogResult.OK) Then
            lineColor = cDialog.Color
            PictureBox2.BackColor = cDialog.Color
        End If
    End Sub

    Private Async Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            SaveImage("exported.jpg")
            Dim localFilePath As String = $"{AppDomain.CurrentDomain.BaseDirectory}\exported.jpg"
            UploadImage(localFilePath, iniFilePath, iniFileName)
            Dim postData As String = JsonConvert.SerializeObject(New With {
                .tableName = iniNamaTabel,
                .filePath = iniFilePath,
                .fileName = iniFileName,
                .ID = iniID,
                .IDHeadDoc = iniIDHeadDoc,
                .kodeDoc = iniKodeDoc,
                .noReg = iniNoReg,
                .noPasien = iniNoPasien,
                .kodeBagian = iniKodeBagian,
                .userInput = iniUserInput,
                .compInput = iniCompInput
             })
            Dim response = Await formController.PostRmeDataImage(postData)
            If response.Code = 200 Or response.Code = 201 Then
                MessageBox.Show("Penyimpanan data kedalam database berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show($"Penyimpanan data kedalam database gagal, {response.Message }", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Close()
        Catch ex As Exception
            MessageBox.Show($"Proses menyimpan file gagal: {ex.Message }", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try

    End Sub

    Private Sub RedrawImage()
        Dim tempImage As Bitmap = New Bitmap(image)

        Using g As Graphics = Graphics.FromImage(tempImage)

            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            ' Draw all arrows
            If arrows IsNot Nothing Then
                For Each arrow In arrows

                    Dim pen As New Pen(arrow.LineColor, arrow.LineWeight)
                    pen.EndCap = Drawing2D.LineCap.ArrowAnchor
                    g.DrawLine(pen, arrow.StartPoint, arrow.EndPoint)


                    ' Draw comment near the line
                    If Not String.IsNullOrEmpty(arrow.Comment) Then

                        ' Calculate the midpoint of the line
                        Dim midPoint As New Point(
                        (arrow.StartPoint.X + arrow.EndPoint.X) \ 2,
                        (arrow.StartPoint.Y + arrow.EndPoint.Y) \ 2)

                        ' Measure text size
                        Dim font As New Font("Arial", arrow.CommentTextSize, FontStyle.Regular)
                        Dim textSize As SizeF = g.MeasureString(arrow.Comment, font)
                        Dim textWidth As Integer = CInt(textSize.Width)
                        Dim textHeight As Integer = CInt(textSize.Height)

                        ' Determine orientation
                        Dim deltaX As Integer = arrow.EndPoint.X - arrow.StartPoint.X
                        Dim deltaY As Integer = arrow.EndPoint.Y - arrow.StartPoint.Y
                        Dim lineLength As Double = Math.Sqrt(deltaX * deltaX + deltaY * deltaY)
                        Dim diagonalTolerance As Double = 2 * lineLength
                        Dim commentPosition As Point

                        Dim brush As New SolidBrush(arrow.CommentTextColor)
                        Dim backgroundBrush As New SolidBrush(Color.FromArgb(200, arrow.CommentBgColor))

                        Dim minDistance As Integer = 20 ' Jarak minimum dari kepala panah
                        Dim angle As Double = Math.Atan2(deltaY, deltaX)
                        Dim offsetX As Integer = CInt(minDistance * Math.Cos(angle))
                        Dim offsetY As Integer = CInt(minDistance * Math.Sin(angle))
                        Dim horizontalPadding As Integer = 10

                        If deltaX > 0 And deltaY < 0 Then
                            ' Kuadran I (kanan atas)
                            commentPosition = New Point(
                                    arrow.EndPoint.X + horizontalPadding,
                                    arrow.EndPoint.Y + offsetY
                                    )
                        ElseIf deltaX < 0 And deltaY < 0 Then
                            ' Kuadran II (kiri atas)
                            commentPosition = New Point(
                                    arrow.EndPoint.X - (textWidth + horizontalPadding),
                                    arrow.EndPoint.Y + offsetY
                                    )
                        ElseIf deltaX < 0 And deltaY > 0 Then
                            ' Kuadran III (kiri bawah)
                            commentPosition = New Point(
                                    arrow.EndPoint.X - (textWidth + horizontalPadding),
                                    arrow.EndPoint.Y - offsetY
                                    )
                        Else
                            ' Kuadran IV (kanan bawah)
                            commentPosition = New Point(
                                    arrow.EndPoint.X + horizontalPadding,
                                    arrow.EndPoint.Y - offsetY
                                    )
                        End If

                        ' Draw the comment
                        Dim stringFormat As New StringFormat() With {
                        .Alignment = StringAlignment.Near,
                        .LineAlignment = StringAlignment.Near
                        }
                        Dim commentRect As New RectangleF(commentPosition.X, commentPosition.Y, textSize.Width, textSize.Height)
                        g.FillRectangle(backgroundBrush, commentRect)
                        g.DrawString(arrow.Comment, font, brush, commentRect)

                    End If

                Next
            End If

            ' Draw the temporary arrow while dragging
            If isDragging Then
                Dim pen As New Pen(lineColor, lineWeight)
                pen.EndCap = Drawing2D.LineCap.ArrowAnchor
                g.DrawLine(pen, startPoint, endPoint)
            End If

            ' Draw all texts
            For Each DrawText In texts

                Dim font As New Font("Arial", DrawText.TextSize, FontStyle.Regular)
                Dim textSize As SizeF = g.MeasureString(DrawText.Content, font)
                Dim commentRect As New RectangleF(DrawText.Position.X - 5, DrawText.Position.Y - 7, textSize.Width, textSize.Height)
                Dim textBrush As New SolidBrush(DrawText.Color)
                Dim backgroundBrush As New SolidBrush(Color.FromArgb(200, DrawText.BgColor))

                g.FillRectangle(backgroundBrush, commentRect)
                g.DrawString(DrawText.Content, font, textBrush, commentRect)

            Next
        End Using

        ' Set the PictureBox image to the tempImage
        PictureBox1.Image = tempImage
        PictureBox1.Invalidate()
    End Sub

    Private Function IsNearPoint(point1 As Point, point2 As Point, Optional threshold As Integer = 35) As Boolean
        Dim dx As Integer = point1.X - point2.X
        Dim dy As Integer = point1.Y - point2.Y
        Return (dx * dx + dy * dy) <= (threshold * threshold)
    End Function

    Private Function IsNearLine(point As Point, startPoint As Point, endPoint As Point, threshold As Integer) As Boolean
        Dim A As Double = endPoint.Y - startPoint.Y
        Dim B As Double = startPoint.X - endPoint.X
        Dim C As Double = endPoint.X * startPoint.Y - startPoint.X * endPoint.Y
        Dim distance As Double = Math.Abs(A * point.X + B * point.Y + C) / Math.Sqrt(A * A + B * B)
        Return distance <= threshold
    End Function

    Private Function GetSelectedArrowIndex(clickPoint As Point) As Integer

        Const clickThreshold As Integer = 0 ' Sesuaikan threshold ini sesuai kebutuhan Anda

        For i As Integer = 0 To arrows.Count - 1
            If IsNearPoint(clickPoint, arrows(i).StartPoint) OrElse IsNearPoint(clickPoint, arrows(i).EndPoint) Then
                Return i
            ElseIf IsNearLine(clickPoint, arrows(i).StartPoint, arrows(i).EndPoint, clickThreshold) Then
                Return i
            End If
        Next
        Return -1

    End Function

    Private Function GetSelectedTextIndex(clickPoint As Point) As Integer
        If texts.Count = 0 Then Return -1

        Using g As Graphics = Graphics.FromImage(image)
            For i As Integer = 0 To texts.Count - 1
                Dim text As DrawText = texts(i)
                Using font As New Font(text.Font, text.TextSize)
                    Dim size As SizeF = g.MeasureString(text.Content, font)
                    Dim rect As New Rectangle(
                    text.Position.X,
                    text.Position.Y,
                    CInt(size.Width),
                    CInt(size.Height)
                )

                    ' Beri toleransi 5 pixel di semua sisi
                    rect.Inflate(5, 5)

                    ' Deteksi dengan akurasi tinggi
                    If rect.Contains(clickPoint) Then
                        Return i
                    End If
                End Using
            Next
        End Using

        Return -1
    End Function

    Private Sub SaveImage(filePath As String)

        Dim tempImage As Bitmap = New Bitmap(image)

        Using g As Graphics = Graphics.FromImage(tempImage)

            For Each arrow In arrows

                Dim pen As New Pen(arrow.LineColor, arrow.LineWeight)
                pen.EndCap = Drawing2D.LineCap.ArrowAnchor
                g.DrawLine(pen, arrow.StartPoint, arrow.EndPoint)


                ' Draw comment near the line
                If Not String.IsNullOrEmpty(arrow.Comment) Then
                    ' Calculate the midpoint of the line
                    Dim midPoint As New Point(
                        (arrow.StartPoint.X + arrow.EndPoint.X) \ 2,
                        (arrow.StartPoint.Y + arrow.EndPoint.Y) \ 2)

                    ' Measure text size
                    Dim font As New Font("Arial", arrow.CommentTextSize, FontStyle.Regular)
                    Dim maxWidth As Integer = 150 ' Max width for wrapping text
                    Dim textSize As SizeF = g.MeasureString(arrow.Comment, font, maxWidth)
                    Dim textWidth As Integer = CInt(textSize.Width)
                    Dim textHeight As Integer = CInt(textSize.Height)

                    ' Determine orientation
                    Dim deltaX As Integer = arrow.EndPoint.X - arrow.StartPoint.X
                    Dim deltaY As Integer = arrow.EndPoint.Y - arrow.StartPoint.Y
                    Dim lineLength As Double = Math.Sqrt(deltaX * deltaX + deltaY * deltaY)
                    Dim diagonalTolerance As Double = 0.7 * lineLength
                    Dim commentPosition As Point

                    Dim brush As New SolidBrush(arrow.CommentTextColor)
                    Dim backgroundBrush As New SolidBrush(Color.FromArgb(200, arrow.CommentBgColor))


                    If Math.Abs(Math.Abs(deltaX) - Math.Abs(deltaY)) <= diagonalTolerance Then ' IF Diagonal

                        Dim minDistance As Integer = 20 ' Jarak minimum dari kepala panah
                        Dim angle As Double = Math.Atan2(deltaY, deltaX)
                        Dim offsetX As Integer = CInt(minDistance * Math.Cos(angle))
                        Dim offsetY As Integer = CInt(minDistance * Math.Sin(angle))

                        If deltaX > 0 And deltaY < 0 Then
                            ' Kuadran I (kanan atas)
                            commentPosition = New Point(arrow.EndPoint.X + offsetX, arrow.EndPoint.Y + offsetY)
                        ElseIf deltaX < 0 And deltaY < 0 Then
                            ' Kuadran II (kiri atas)
                            commentPosition = New Point(arrow.EndPoint.X - offsetX + 25, arrow.EndPoint.Y + offsetY)
                        ElseIf deltaX < 0 And deltaY > 0 Then
                            ' Kuadran III (kiri bawah)
                            commentPosition = New Point(arrow.EndPoint.X - offsetX + 25, arrow.EndPoint.Y - offsetY)
                        Else
                            ' Kuadran IV (kanan bawah)
                            commentPosition = New Point(arrow.EndPoint.X + offsetX, arrow.EndPoint.Y - offsetY)
                        End If
                    ElseIf Math.Abs(deltaY) < Math.Abs(deltaX) Then
                        ' Horizontal
                        commentPosition = New Point(midPoint.X - (textWidth \ 2), midPoint.Y - textHeight - 10)
                    ElseIf Math.Abs(deltaX) < Math.Abs(deltaY) Then
                        ' Vertical
                        commentPosition = New Point(midPoint.X + 10, midPoint.Y - (textHeight \ 2))
                    End If


                    ' Draw the comment
                    Dim commentRect As New RectangleF(commentPosition.X, commentPosition.Y, textSize.Width, textSize.Height)
                    g.FillRectangle(backgroundBrush, commentRect)
                    g.DrawString(arrow.Comment, font, brush, commentRect)

                End If

            Next

            For Each DrawText In texts

                Dim font As New Font("Arial", DrawText.TextSize, FontStyle.Regular)
                Dim textSize As SizeF = g.MeasureString(DrawText.Content, font)
                Dim commentRect As New RectangleF(DrawText.Position.X - 5, DrawText.Position.Y - 7, textSize.Width, textSize.Height)
                Dim textBrush As New SolidBrush(DrawText.Color)
                Dim backgroundBrush As New SolidBrush(Color.FromArgb(200, DrawText.BgColor))

                g.FillRectangle(backgroundBrush, commentRect)
                g.DrawString(DrawText.Content, font, textBrush, commentRect)

            Next

        End Using

        tempImage.Save(filePath, Imaging.ImageFormat.Jpeg)

    End Sub

    Private Function ConvertMouseToImageCoords(mousePoint As Point) As Point
        If image Is Nothing OrElse PictureBox1.ClientSize.Width = 0 OrElse PictureBox1.ClientSize.Height = 0 Then
            Return Point.Empty
        End If

        ' Hitung rasio aspek
        Dim imageRatio As Double = image.Width / CDbl(image.Height)
        Dim pbRatio As Double = PictureBox1.ClientSize.Width / CDbl(PictureBox1.ClientSize.Height)

        ' Hitung skala
        Dim scale As Double = If(imageRatio > pbRatio,
        PictureBox1.ClientSize.Width / CDbl(image.Width),
        PictureBox1.ClientSize.Height / CDbl(image.Height))

        ' Hitung area gambar yang terlihat
        Dim scaledWidth As Integer = CInt(image.Width * scale)
        Dim scaledHeight As Integer = CInt(image.Height * scale)
        Dim offsetX As Integer = (PictureBox1.ClientSize.Width - scaledWidth) \ 2
        Dim offsetY As Integer = (PictureBox1.ClientSize.Height - scaledHeight) \ 2

        ' Hitung koordinat relatif terhadap gambar
        Dim imgX As Integer = CInt((mousePoint.X - offsetX) / scale)
        Dim imgY As Integer = CInt((mousePoint.Y - offsetY) / scale)

        ' Clamping ke batas gambar
        imgX = Math.Max(0, Math.Min(image.Width - 1, imgX))
        imgY = Math.Max(0, Math.Min(image.Height - 1, imgY))

        Return New Point(imgX, imgY)
    End Function


    Function GetAppVersion() As String
        Dim assembly As Assembly = Assembly.GetExecutingAssembly()
        Dim versionInfo As AssemblyName = assembly.GetName()
        Return versionInfo.Version.ToString()
    End Function

    Private Async Sub CheckServerAppVersion()
        Try
            Dim result = Await formController.GetCurentVersion()
            If result.Code = 200 Then

                Dim localVersion As New Version(GetAppVersion())
                Dim serverVersion As New Version(result.Data.version)
                Dim comparisonResult As Integer = localVersion.CompareTo(serverVersion)

                If comparisonResult < 0 Then
                    Try
                        OpenUpdaterApp()
                    Catch ex As Exception
                        MessageBox.Show($"Updater tidak ditemukan (updater/UpdaterImageEditor.exe), {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Close()
                    End Try
                End If

            Else

            End If
        Catch ex As Exception
            MessageBox.Show($"An error occurred during CheckServerAppVersion(). {vbCrLf}{vbCrLf} {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'Button1.Enabled = True
            'TextBox1.Enabled = True
            'TextBox2.Enabled = True
            'loginStatusLabel.Text = ""
        End Try
    End Sub

    Sub DownloadImage(sharedFolderPath As String, fileName As String, localPath As String)
        Dim sourcePath As String = Path.Combine(sharedFolderPath, fileName)
        File.Copy(sourcePath, localPath, True)
    End Sub

    Sub UploadImage(localFilePath As String, sharedFolderPath As String, remoteFileName As String)
        Dim remoteFilePath As String = Path.Combine(sharedFolderPath, remoteFileName)
        File.Copy(localFilePath, remoteFilePath, True)
    End Sub

    Private Sub OpenUpdaterApp()
        Dim appPath As String = Path.Combine(basePath, "updater\UpdaterImageEditor.exe")
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

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        My.Settings.AlwaysAddComment = CheckBox1.Checked
        My.Settings.Save()
    End Sub

End Class
