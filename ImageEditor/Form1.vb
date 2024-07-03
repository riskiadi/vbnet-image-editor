
Public Class Form1

    Private isPenMode As Boolean = False
    Private isTextMode As Boolean = False
    Private isEraseMode As Boolean = False

    Private lineWeight As Integer = 7
    Private lineColor As Color = Color.Black

    Private textSize As Integer = 12
    Private textFont As String = "Arial"
    Private textColor As Color = Color.Black

    Private isDragging As Boolean = False
    Private isEditingEndPoint As Boolean = False
    Private isEditingStartPoint As Boolean = False
    Private selectedArrowIndex As Integer = -1
    Private selectedTextIndex As Integer = -1
    Private startPoint As Point
    Private endPoint As Point
    Private textPosition As Point

    Private image As Bitmap
    Private arrows As New List(Of DrawArrow)
    Private texts As New List(Of DrawText)

    Public Structure DrawArrow
        Public StartPoint As Point
        Public EndPoint As Point
        Public LineWeight As Integer
        Public LineColor As Color
    End Structure

    Public Structure DrawText
        Public Position As Point
        Public Content As String
        Public TextSize As Integer
        Public Font As String
        Public Color As Color
    End Structure

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        image = New Bitmap("image.jpg")
        ComboBox1.Items.AddRange(New Object() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15})
        ComboBox2.Items.AddRange(New Object() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25})
        ComboBox1.SelectedIndex = 6
        ComboBox2.SelectedIndex = 12
        lineWeight = CInt(ComboBox1.SelectedItem)
        textSize = CInt(ComboBox2.SelectedItem)
        PictureBox1.Image = image
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown

        If isPenMode = True Then

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

        ElseIf isTextMode = True Then

            If e.Button = MouseButtons.Left Then

                selectedTextIndex = GetSelectedTextIndex(ConvertMouseToImageCoords(e.Location))

                If selectedTextIndex >= 0 Then
                    Dim text = texts(selectedTextIndex)
                    textPosition = ConvertMouseToImageCoords(e.Location)
                    TextBox1.Location = New Point(e.X + 12, e.Y + 5)
                    TextBox1.Visible = True
                    text.Content = TextBox1.Text
                    text.Position = textPosition
                    texts(selectedTextIndex) = Text
                    TextBox1.Focus()
                Else

                    textPosition = ConvertMouseToImageCoords(e.Location)
                    TextBox1.Location = New Point(e.X + 12, e.Y + 5)
                    TextBox1.Visible = True
                    TextBox1.Focus()

                End If
            End If

        ElseIf isEraseMode = True Then

            If e.Button = MouseButtons.Left Then
                selectedArrowIndex = GetSelectedArrowIndex(ConvertMouseToImageCoords(e.Location))
                If selectedArrowIndex >= 0 AndAlso selectedArrowIndex < arrows.Count Then

                    arrows.RemoveAt(selectedArrowIndex)
                    selectedArrowIndex = -1
                    RedrawImage()

                    'Dim arrow = arrows(selectedArrowIndex)
                    'If IsNearPoint(ConvertMouseToImageCoords(e.Location), arrow.StartPoint) Then
                    '    isEditingStartPoint = True
                    'ElseIf IsNearPoint(ConvertMouseToImageCoords(e.Location), arrow.EndPoint) Then
                    '    isEditingEndPoint = True
                    'End If
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

        If isPenMode = True Then
            selectedArrowIndex = GetSelectedArrowIndex(ConvertMouseToImageCoords(e.Location))
            If selectedArrowIndex >= 0 Then
                PictureBox1.Cursor = Cursors.Hand
            Else
                PictureBox1.Cursor = Cursors.Cross
            End If
        ElseIf isTextMode = True Then
            selectedTextIndex = GetSelectedTextIndex(ConvertMouseToImageCoords(e.Location))
            If selectedTextIndex >= 0 Then
                PictureBox1.Cursor = Cursors.Hand
            Else
                PictureBox1.Cursor = Cursors.IBeam
            End If
        End If


        If isDragging Then
            endPoint = ConvertMouseToImageCoords(e.Location)
            RedrawImage()
        ElseIf isEditingStartPoint AndAlso selectedArrowIndex >= 0 Then
            Dim arrow = arrows(selectedArrowIndex)
            arrow.StartPoint = ConvertMouseToImageCoords(e.Location)
            arrows(selectedArrowIndex) = arrow
            RedrawImage()
        ElseIf isEditingEndPoint AndAlso selectedArrowIndex >= 0 Then
            Dim arrow = arrows(selectedArrowIndex)
            arrow.EndPoint = ConvertMouseToImageCoords(e.Location)
            arrows(selectedArrowIndex) = arrow
            RedrawImage()
        End If

    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        If isDragging Then
            isDragging = False
            Dim newArrow As New DrawArrow With {
                .StartPoint = startPoint,
                .EndPoint = endPoint,
                .LineWeight = lineWeight,
                .LineColor = lineColor
            }
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
            Button4.BackColor = Color.MediumSeaGreen
            PictureBox1.Cursor = Cursors.Cross
            Button5.BackColor = Color.Transparent
            Button6.BackColor = Color.Transparent
            TextBox1.Visible = False
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
            Button5.BackColor = Color.MediumSeaGreen
            PictureBox1.Cursor = Cursors.UpArrow
            Button4.BackColor = Color.Transparent
            Button6.BackColor = Color.Transparent
            TextBox1.Visible = False
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
            Button6.BackColor = Color.MediumSeaGreen
            PictureBox1.Cursor = Cursors.IBeam
            Button4.BackColor = Color.Transparent
            Button5.BackColor = Color.Transparent
        Else
            TextBox1.Visible = False
            Button6.BackColor = Color.Transparent
            PictureBox1.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        lineWeight = CInt(ComboBox1.SelectedItem)
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            If TextBox1.Visible Then
                If selectedTextIndex >= 0 Then
                    Dim text = texts(selectedTextIndex)
                    text.Content = TextBox1.Text
                    texts(selectedTextIndex) = text
                Else
                    Dim newText As New DrawText With {
                    .Position = textPosition,
                    .Content = TextBox1.Text,
                    .TextSize = textSize,
                    .Font = textFont,
                    .Color = textColor
                }
                    texts.Add(newText)
                End If
                TextBox1.Visible = False
                TextBox1.Clear()
                RedrawImage()
            End If
            e.Handled = True
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim cDialog As New ColorDialog()
        cDialog.Color = lineColor
        If (cDialog.ShowDialog() = DialogResult.OK) Then
            lineColor = cDialog.Color
            PictureBox2.BackColor = cDialog.Color
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim cDialog As New ColorDialog()
        cDialog.Color = textColor
        If (cDialog.ShowDialog() = DialogResult.OK) Then
            textColor = cDialog.Color
            PictureBox3.BackColor = cDialog.Color
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        SaveImage("exported.jpg")
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        textSize = CInt(ComboBox2.SelectedItem)
    End Sub

    Private Sub RedrawImage()

        Dim tempImage As Bitmap = New Bitmap(image)

        Using g As Graphics = Graphics.FromImage(tempImage)


            If arrows Is Nothing Then

            Else

                For Each arrow In arrows
                    Dim pen As New Pen(arrow.LineColor, arrow.LineWeight)
                    pen.EndCap = Drawing2D.LineCap.ArrowAnchor
                    g.DrawLine(pen, arrow.StartPoint, arrow.EndPoint)
                    If isDragging Then
                        g.DrawLine(pen, startPoint, endPoint)
                    End If
                Next

            End If


            For Each DrawText In texts
                Dim brush As New SolidBrush(DrawText.Color)
                g.DrawString(DrawText.Content, New Drawing.Font(DrawText.Font, DrawText.TextSize, FontStyle.Regular), Brush, DrawText.Position)
            Next

        End Using

        PictureBox1.Image = tempImage

    End Sub

    Private Function IsNearPoint(point1 As Point, point2 As Point, Optional threshold As Integer = 10) As Boolean
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

        Const clickThreshold As Integer = 2 ' Sesuaikan threshold ini sesuai kebutuhan Anda

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
        For i As Integer = 0 To texts.Count - 1
            Dim textRect As New Rectangle(texts(i).Position, TextRenderer.MeasureText(texts(i).Content, New Drawing.Font(textFont,
                               16,
                               FontStyle.Bold Or FontStyle.Italic)))
            If textRect.Contains(clickPoint) Then
                Return i
            End If
        Next
        Return -1
    End Function

    Private Sub SaveImage(filePath As String)

        Dim tempImage As Bitmap = New Bitmap(image)

        Using g As Graphics = Graphics.FromImage(tempImage)

            For Each arrow In arrows
                Dim pen As New Pen(arrow.LineColor, arrow.LineWeight)
                pen.EndCap = Drawing2D.LineCap.ArrowAnchor
                g.DrawLine(pen, arrow.StartPoint, arrow.EndPoint)
            Next

            For Each DrawText In texts
                Dim brush As New SolidBrush(DrawText.Color)
                g.DrawString(DrawText.Content, New Font(DrawText.Font, DrawText.TextSize, FontStyle.Regular), brush, DrawText.Position)
            Next

        End Using

        tempImage.Save(filePath, Imaging.ImageFormat.Jpeg)

    End Sub

    Private Function ConvertMouseToImageCoords(mousePoint As Point) As Point
        Dim imageSize As Size = image.Size
        Dim pictureBoxSize As Size = PictureBox1.ClientSize

        Dim imageAspectRatio As Single = imageSize.Width / imageSize.Height
        Dim pictureBoxAspectRatio As Single = pictureBoxSize.Width / pictureBoxSize.Height

        Dim scaleFactor As Single
        Dim offset As Point

        If imageAspectRatio > pictureBoxAspectRatio Then
            ' Image is limited by width
            scaleFactor = pictureBoxSize.Width / imageSize.Width
            offset = New Point(0, (pictureBoxSize.Height - imageSize.Height * scaleFactor) / 2)
        Else
            ' Image is limited by height
            scaleFactor = pictureBoxSize.Height / imageSize.Height
            offset = New Point((pictureBoxSize.Width - imageSize.Width * scaleFactor) / 2, 0)
        End If

        Dim imagePoint As New Point((mousePoint.X - offset.X) / scaleFactor, (mousePoint.Y - offset.Y) / scaleFactor)
        Return imagePoint
    End Function

End Class
