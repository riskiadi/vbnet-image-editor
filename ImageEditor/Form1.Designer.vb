<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        PictureBox1 = New PictureBox()
        Button7 = New Button()
        ComboBox1 = New ComboBox()
        Label1 = New Label()
        PictureBox2 = New PictureBox()
        Label2 = New Label()
        GroupBox1 = New GroupBox()
        Button1 = New Button()
        CheckBox1 = New CheckBox()
        Button6 = New Button()
        Button5 = New Button()
        Button4 = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        PictureBox1.BackColor = Color.DimGray
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(12, 12)
        PictureBox1.Margin = New Padding(3, 3, 10, 3)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(726, 737)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Button7
        ' 
        Button7.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button7.Font = New Font("Quicksand", 9.75F)
        Button7.Image = CType(resources.GetObject("Button7.Image"), Image)
        Button7.Location = New Point(407, 164)
        Button7.Margin = New Padding(3, 3, 10, 3)
        Button7.Name = "Button7"
        Button7.Size = New Size(81, 60)
        Button7.TabIndex = 9
        Button7.Text = "Save"
        Button7.TextAlign = ContentAlignment.BottomCenter
        Button7.TextImageRelation = TextImageRelation.ImageAboveText
        Button7.UseVisualStyleBackColor = True
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.FormatString = "N0"
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(140, 29)
        ComboBox1.Margin = New Padding(10, 3, 3, 3)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(90, 27)
        ComboBox1.TabIndex = 10
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label1.Font = New Font("Quicksand", 9F)
        Label1.Location = New Point(14, 32)
        Label1.Margin = New Padding(10, 0, 3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(113, 20)
        Label1.TabIndex = 11
        Label1.Text = "Arrow Line Weight:"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PictureBox2.BackColor = Color.Black
        PictureBox2.Location = New Point(139, 66)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(23, 23)
        PictureBox2.TabIndex = 12
        PictureBox2.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label2.Font = New Font("Quicksand", 9F)
        Label2.Location = New Point(14, 67)
        Label2.Name = "Label2"
        Label2.Size = New Size(70, 20)
        Label2.TabIndex = 13
        Label2.Text = "Line Color:"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        GroupBox1.Controls.Add(Button1)
        GroupBox1.Controls.Add(CheckBox1)
        GroupBox1.Controls.Add(Button7)
        GroupBox1.Controls.Add(Button6)
        GroupBox1.Controls.Add(ComboBox1)
        GroupBox1.Controls.Add(Button5)
        GroupBox1.Controls.Add(Button4)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(PictureBox2)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Font = New Font("Quicksand", 9.75F)
        GroupBox1.Location = New Point(751, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(501, 238)
        GroupBox1.TabIndex = 18
        GroupBox1.TabStop = False
        GroupBox1.Text = "Tools"
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button1.Enabled = False
        Button1.Font = New Font("Quicksand", 9.75F)
        Button1.ForeColor = Color.Black
        Button1.Image = CType(resources.GetObject("Button1.Image"), Image)
        Button1.Location = New Point(282, 164)
        Button1.Name = "Button1"
        Button1.Size = New Size(81, 60)
        Button1.TabIndex = 19
        Button1.Text = "Draw"
        Button1.TextAlign = ContentAlignment.BottomCenter
        Button1.TextImageRelation = TextImageRelation.ImageAboveText
        Button1.UseVisualStyleBackColor = True
        Button1.Visible = False
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Enabled = False
        CheckBox1.Font = New Font("Quicksand", 9.75F)
        CheckBox1.Location = New Point(14, 102)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(174, 23)
        CheckBox1.TabIndex = 18
        CheckBox1.Text = "Add comment on arrow"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' Button6
        ' 
        Button6.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button6.Font = New Font("Quicksand", 9.75F)
        Button6.ForeColor = Color.Black
        Button6.Image = CType(resources.GetObject("Button6.Image"), Image)
        Button6.Location = New Point(101, 164)
        Button6.Name = "Button6"
        Button6.Size = New Size(81, 60)
        Button6.TabIndex = 8
        Button6.Text = "Note"
        Button6.TextAlign = ContentAlignment.BottomCenter
        Button6.TextImageRelation = TextImageRelation.ImageAboveText
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button5.Font = New Font("Quicksand", 9.75F)
        Button5.Image = CType(resources.GetObject("Button5.Image"), Image)
        Button5.Location = New Point(188, 164)
        Button5.Margin = New Padding(3, 3, 10, 3)
        Button5.Name = "Button5"
        Button5.Size = New Size(81, 60)
        Button5.TabIndex = 7
        Button5.Text = "Eraser"
        Button5.TextAlign = ContentAlignment.BottomCenter
        Button5.TextImageRelation = TextImageRelation.ImageAboveText
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button4.BackColor = Color.Transparent
        Button4.BackgroundImageLayout = ImageLayout.Center
        Button4.Font = New Font("Quicksand", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button4.ForeColor = Color.Black
        Button4.Image = CType(resources.GetObject("Button4.Image"), Image)
        Button4.Location = New Point(14, 164)
        Button4.Margin = New Padding(10, 3, 3, 3)
        Button4.Name = "Button4"
        Button4.Size = New Size(81, 60)
        Button4.TabIndex = 6
        Button4.Text = "Arrow"
        Button4.TextAlign = ContentAlignment.BottomCenter
        Button4.TextImageRelation = TextImageRelation.ImageAboveText
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(1264, 761)
        Controls.Add(GroupBox1)
        Controls.Add(PictureBox1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Site Marking"
        TopMost = True
        WindowState = FormWindowState.Maximized
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button7 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Button1 As Button

End Class
