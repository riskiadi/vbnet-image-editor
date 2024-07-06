Imports System.Drawing.Drawing2D
Imports ImageEditor.Arrow
Imports System.Security

Public Class Form2

    Private bm As Bitmap
    Private g As Graphics
    Private ptStart As Point
    Private ptEnd As Point
    Private bMouseDown As Boolean = False
    Private lstDrawOject As New List(Of ptObject)

    Private drawLineArrow As New Arrow

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set up the drawing surface
        bm = New Bitmap(DrawPan.Width, DrawPan.Height)
        DrawPan.BackgroundImage = bm
        g = Graphics.FromImage(bm)
        g.SmoothingMode = SmoothingMode.Default
        g.Clear(Color.White)
    End Sub

    Private Sub DrawPan_MouseDown(sender As Object, e As MouseEventArgs) Handles DrawPan.MouseDown
        ptStart = e.Location
        bMouseDown = True
    End Sub

    Private Sub DrawPan_MouseMove(sender As Object, e As MouseEventArgs) Handles DrawPan.MouseMove
        If bMouseDown Then
            ptEnd = e.Location
            Draw()
        End If
    End Sub

    Private Sub DrawPan_MouseUp(sender As Object, e As MouseEventArgs) Handles DrawPan.MouseUp
        If bMouseDown Then
            bMouseDown = False
            ptEnd = e.Location

            ' Save the drawn object
            Dim obj As New ptObject
            obj.X1 = ptStart
            obj.X2 = ptEnd
            obj.draw = Principal.LINE ' Set the draw type here
            obj.penLine = New Pen(Color.Black, 2) ' Set default pen properties
            lstDrawOject.Add(obj)

            Draw()
        End If
    End Sub

    Private Sub Draw()
        g.Clear(Color.White)

        ' Draw all saved objects
        For Each pt In lstDrawOject
            Select Case pt.draw
                Case Principal.LINE
                    DrawLine(pt)
                Case Principal.RECTANGLE
                    DrawRectangle(pt)
                Case Principal.ELLIPSE
                    DrawEllipse(pt)
                    ' Add other cases as needed
            End Select
        Next

        ' Draw the current object
        If bMouseDown Then
            Dim obj As New ptObject
            obj.X1 = ptStart
            obj.X2 = ptEnd
            obj.draw = Principal.LINE ' Set the draw type here
            obj.penLine = New Pen(Color.Black, 2) ' Set default pen properties
            Select Case obj.draw
                Case Principal.LINE
                    DrawLine(obj)
                Case Principal.RECTANGLE
                    DrawRectangle(obj)
                Case Principal.ELLIPSE
                    DrawEllipse(obj)
                    ' Add other cases as needed
            End Select
        End If

        DrawPan.Invalidate()
    End Sub

    Private Sub DrawLine(pt As ptObject)
        Dim pen As New Pen(Color.Red, 8) ' You can set pen properties here
        g.DrawLine(pen, pt.X1, pt.X2)
    End Sub

    Private Sub DrawRectangle(pt As ptObject)
        Dim rect As New Rectangle(Math.Min(pt.X1.X, pt.X2.X), Math.Min(pt.X1.Y, pt.X2.Y), Math.Abs(pt.X2.X - pt.X1.X), Math.Abs(pt.X2.Y - pt.X1.Y))
        g.DrawRectangle(pt.penLine, rect)
    End Sub

    Private Sub DrawEllipse(pt As ptObject)
        Dim rect As New Rectangle(Math.Min(pt.X1.X, pt.X2.X), Math.Min(pt.X1.Y, pt.X2.Y), Math.Abs(pt.X2.X - pt.X1.X), Math.Abs(pt.X2.Y - pt.X1.Y))
        g.DrawEllipse(pt.penLine, rect)
    End Sub

    Private Sub DrawArrow(pt As ptObject, arrowStart As Boolean)
        Dim brushFore As New SolidBrush(pt.ForeColor)
        Dim penDraw As New Pen(brushFore, pt.penSize)
        penDraw.DashStyle = DashStyle.Solid
        If arrowStart Then
            drawLineArrow.ArrowEnd(g, pt, penDraw.DashStyle)
        Else
            drawLineArrow.ArrowStartEnd(g, pt, penDraw.DashStyle)
        End If
    End Sub

End Class

' Define enums and classes used in the code
Public Enum Principal
    LINE
    RECTANGLE
    ELLIPSE
    ' Add other draw types as needed
End Enum

Public Structure ptObject
    Public name As String
    Public X1 As Point
    Public X2 As Point
    Public XORIG1 As Point
    Public XORIG2 As Point
    Public penLine As Pen
    Public draw As Integer
    Public bitmap As Bitmap
    Public text As String
    Public directionText As String
    Public lstPtCurve As ArrayList
    Public font As Font
    Public rotation As Integer
    Public penSize As Single
    Public penStyle As String
    Public FillColor As Color
    Public FillColor2 As Color
    Public ForeColor As Color
    Public bringToFront As Boolean
    Public brightness As Double
    Public contrast As Double
    Public gamma As Double
    Public orderDesign As Integer
    Public brushBitmap As String
    Public dCube As Integer
End Structure