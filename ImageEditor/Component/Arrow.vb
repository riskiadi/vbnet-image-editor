Public Class Arrow

    Public Sub ArrowEnd(g As Graphics, pt As ptObject, ds As Single)
        If pt.brushBitmap <> Nothing Then
            Dim oBmp As Bitmap
            Dim oBrushTexture As TextureBrush
            oBmp = New Bitmap(CStr(pt.brushBitmap))
            oBrushTexture = New TextureBrush(oBmp)
            Dim P As New Pen(oBrushTexture, pt.penSize)
            P.DashStyle = ds
            P.EndCap = Drawing2D.LineCap.ArrowAnchor
            g.DrawLine(P, pt.X1.X, pt.X1.Y, pt.X2.X, pt.X2.Y)
        Else
            Dim P As New Pen(pt.ForeColor, pt.penSize)
            P.DashStyle = ds
            P.EndCap = Drawing2D.LineCap.ArrowAnchor
            g.DrawLine(P, pt.X1.X, pt.X1.Y, pt.X2.X, pt.X2.Y)
        End If
    End Sub

    Public Sub ArrowStartEnd(g As Graphics, pt As ptObject, ds As Single)
        If pt.brushBitmap <> Nothing Then
            Dim oBmp As Bitmap
            Dim oBrushTexture As TextureBrush
            oBmp = New Bitmap(CStr(pt.brushBitmap))
            oBrushTexture = New TextureBrush(oBmp)
            Dim P As New Pen(oBrushTexture, pt.penSize)
            P.DashStyle = ds
            P.StartCap = Drawing2D.LineCap.ArrowAnchor
            P.EndCap = Drawing2D.LineCap.ArrowAnchor
            g.DrawLine(P, pt.X1.X, pt.X1.Y, pt.X2.X, pt.X2.Y)
        Else
            Dim P As New Pen(pt.ForeColor, pt.penSize)
            P.DashStyle = ds
            P.StartCap = Drawing2D.LineCap.ArrowAnchor
            P.EndCap = Drawing2D.LineCap.ArrowAnchor
            g.DrawLine(P, pt.X1.X, pt.X1.Y, pt.X2.X, pt.X2.Y)
        End If
    End Sub


End Class
