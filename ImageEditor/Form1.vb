
Imports System.Net.Mime.MediaTypeNames

Public Class Form1

    Private isDragging As Boolean = False
    Private isEditingEndPoint As Boolean = False
    Private isEditingStartPoint As Boolean = False
    Private selectedArrowIndex As Integer = -1
    Private startPoint As Point
    Private endPoint As Point
    Private textPosition As Point
    Private selectedTextIndex As Integer = -1
    Private image As Bitmap
    Private arrows As New List(Of DrawArrow)
    Private texts As New List(Of DrawText)
    Private Const ClickThreshold As Integer = 10

    Private isDraggingText As Boolean = False
    Private clickedTextIndex As Integer = -1
    Private clickedLocation As Point

    Public Structure DrawArrow
        Public StartPoint As Point
        Public EndPoint As Point
    End Structure

    Public Structure DrawText
        Public Position As Point
        Public Content As String
    End Structure

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        image = New Bitmap("image.jpg")
        PictureBox1.Image = image
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        If e.Button = MouseButtons.Left Then
            selectedArrowIndex = GetSelectedArrowIndex(e.Location)
            selectedTextIndex = GetSelectedTextIndex(e.Location)
            If selectedArrowIndex >= 0 Then
                Dim arrow = arrows(selectedArrowIndex)
                If IsNearPoint(e.Location, arrow.StartPoint) Then
                    isEditingStartPoint = True
                ElseIf IsNearPoint(e.Location, arrow.EndPoint) Then
                    isEditingEndPoint = True
                End If
            ElseIf selectedTextIndex >= 0 Then
                ' Begin editing text
                textPosition = texts(selectedTextIndex).Position
                TextBox1.Location = New Point(textPosition.X + PictureBox1.Left, textPosition.Y + PictureBox1.Top)
                TextBox1.Text = texts(selectedTextIndex).Content
                TextBox1.Visible = True
                TextBox1.Focus()
            Else
                isDragging = True
                startPoint = e.Location
                endPoint = e.Location
            End If
        End If
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If isDragging Then
            endPoint = e.Location
            RedrawImage()
        ElseIf isEditingStartPoint AndAlso selectedArrowIndex >= 0 Then
            Dim arrow = arrows(selectedArrowIndex)
            arrow.StartPoint = e.Location
            arrows(selectedArrowIndex) = arrow
            RedrawImage()
        ElseIf isEditingEndPoint AndAlso selectedArrowIndex >= 0 Then
            Dim arrow = arrows(selectedArrowIndex)
            arrow.EndPoint = e.Location
            arrows(selectedArrowIndex) = arrow
            RedrawImage()
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        If isDragging Then
            isDragging = False
            Dim newArrow As New DrawArrow With {
                .StartPoint = startPoint,
                .EndPoint = endPoint
            }
            arrows.Add(newArrow)
            'If arrows.Count > 5 Then arrows.RemoveAt(0) ' Limit to 2 arrows
            RedrawImage()
        End If
        If isEditingStartPoint OrElse isEditingEndPoint Then
            isEditingStartPoint = False
            isEditingEndPoint = False
            RedrawImage()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Visible Then
            ' Update the existing text
            If selectedTextIndex >= 0 Then
                Dim text = texts(selectedTextIndex)
                text.Content = TextBox1.Text
                texts(selectedTextIndex) = text
            Else
                ' Add new text to the image
                Dim newText As New DrawText With {
                    .Position = textPosition,
                    .Content = TextBox1.Text
                }
                texts.Add(newText)
            End If
            TextBox1.Visible = False
            RedrawImage()
        End If
    End Sub

    Private Sub PictureBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDoubleClick
        ' Set text position on double-click
        textPosition = e.Location
        TextBox1.Location = New Point(textPosition.X + PictureBox1.Left, textPosition.Y + PictureBox1.Top)
        TextBox1.Visible = True
        TextBox1.Focus()
    End Sub

    Private Sub RedrawImage()

        Dim tempImage As Bitmap = New Bitmap(image)

        Using g As Graphics = Graphics.FromImage(tempImage)

            Dim pen As New Pen(Color.Black, 7)
            pen.EndCap = Drawing2D.LineCap.ArrowAnchor
            ListBox1.Items.Clear()

            For Each arrow In arrows
                ListBox1.Items.Add($"Start Point: {arrow.StartPoint} | End Point: {arrow.EndPoint}")
                g.DrawLine(pen, arrow.StartPoint, arrow.EndPoint)
            Next

            Dim textFont As New Drawing.Font("Arial", 13, FontStyle.Bold Or FontStyle.Italic)
            Dim brush As New SolidBrush(Color.Black)
            For Each DrawText In texts
                g.DrawString(DrawText.Content, textFont, brush, DrawText.Position)
            Next

            If isDragging Then
                g.DrawLine(pen, startPoint, endPoint)
            End If
        End Using

        PictureBox1.Image = tempImage
    End Sub

    Private Function CalculateAngle(startPoint As Point, endPoint As Point) As Single
        Dim deltaX As Integer = endPoint.X - startPoint.X
        Dim deltaY As Integer = endPoint.Y - startPoint.Y
        Dim angle As Single = Math.Atan2(deltaY, deltaX) * (180.0F / Math.PI)
        Return angle
    End Function

    Private Function GetTextPositionForArrow(arrow As DrawArrow) As Point
        Dim midPointX As Integer = (arrow.StartPoint.X + arrow.EndPoint.X) \ 2
        Dim midPointY As Integer = (arrow.StartPoint.Y + arrow.EndPoint.Y) \ 2
        Return New Point(midPointX, midPointY - 30) ' Adjust the Y position to place text above the arrow
    End Function

    Private Function IsNearPoint(clickPoint As Point, targetPoint As Point) As Boolean
        ' Check if the click point is near the target point
        Return Math.Abs(clickPoint.X - targetPoint.X) < ClickThreshold AndAlso Math.Abs(clickPoint.Y - targetPoint.Y) < ClickThreshold
    End Function

    Private Function GetSelectedArrowIndex(clickPoint As Point) As Integer
        For i As Integer = 0 To arrows.Count - 1
            If IsNearPoint(clickPoint, arrows(i).StartPoint) OrElse IsNearPoint(clickPoint, arrows(i).EndPoint) Then
                Return i
            End If
        Next
        Return -1
    End Function

    Private Function GetSelectedTextIndex(clickPoint As Point) As Integer
        For i As Integer = 0 To texts.Count - 1
            Dim textRect As New Rectangle(texts(i).Position, TextRenderer.MeasureText(texts(i).Content, New Drawing.Font("Times New Roman",
                               16,
                               FontStyle.Bold Or FontStyle.Italic)))
            If textRect.Contains(clickPoint) Then
                Return i
            End If
        Next
        Return -1
    End Function

    Private Sub SaveImage(filePath As String)
        ' Create a copy of the original image to draw on
        Dim tempImage As Bitmap = New Bitmap(image)

        Using g As Graphics = Graphics.FromImage(tempImage)
            ' Define the pen for drawing the arrow
            Dim pen As New Pen(Color.Black, 7)
            pen.EndCap = Drawing2D.LineCap.ArrowAnchor

            ' Draw all arrows
            For Each arrow In arrows
                g.DrawLine(pen, arrow.StartPoint, arrow.EndPoint)
            Next

            ' Draw all texts
            Dim textFont As New Drawing.Font("Times New Roman",
                               16,
                               FontStyle.Bold Or FontStyle.Italic)
            Dim brush As New SolidBrush(Color.Black)
            For Each DrawText In texts
                g.DrawString(DrawText.Content, textFont, brush, DrawText.Position)
            Next
        End Using

        ' Save the image to the specified file path
        tempImage.Save(filePath, Imaging.ImageFormat.Jpeg)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SaveImage("exported.jpg")
    End Sub
End Class
