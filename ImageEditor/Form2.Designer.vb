<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        DrawPan = New Panel()
        Button1 = New Button()
        DrawPan.SuspendLayout()
        SuspendLayout()
        ' 
        ' DrawPan
        ' 
        DrawPan.BackColor = Color.Black
        DrawPan.Controls.Add(Button1)
        DrawPan.Dock = DockStyle.Fill
        DrawPan.Location = New Point(0, 0)
        DrawPan.Name = "DrawPan"
        DrawPan.Size = New Size(1090, 617)
        DrawPan.TabIndex = 0
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(124, 155)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 0
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1090, 617)
        Controls.Add(DrawPan)
        Name = "Form2"
        Text = "Form2"
        DrawPan.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents DrawPan As Panel
    Friend WithEvents Button1 As Button
End Class
