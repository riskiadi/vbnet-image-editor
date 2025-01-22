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
        TextBox1 = New TextBox()
        Button7 = New Button()
        ComboBox1 = New ComboBox()
        Label1 = New Label()
        PictureBox2 = New PictureBox()
        Label2 = New Label()
        Label3 = New Label()
        ComboBox2 = New ComboBox()
        Label4 = New Label()
        PictureBox3 = New PictureBox()
        GroupBox1 = New GroupBox()
        CheckBox1 = New CheckBox()
        Button6 = New Button()
        Button5 = New Button()
        Button4 = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        PictureBox1.BackColor = Color.Black
        PictureBox1.BorderStyle = BorderStyle.FixedSingle
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(12, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(703, 737)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' TextBox1
        ' 
        TextBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        TextBox1.BorderStyle = BorderStyle.FixedSingle
        TextBox1.Font = New Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TextBox1.Location = New Point(749, 552)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(169, 26)
        TextBox1.TabIndex = 2
        TextBox1.Visible = False
        ' 
        ' Button7
        ' 
        Button7.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button7.Image = My.Resources.Resources.save_32px
        Button7.Location = New Point(431, 114)
        Button7.Margin = New Padding(3, 3, 10, 3)
        Button7.Name = "Button7"
        Button7.Size = New Size(80, 68)
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
        ComboBox1.Location = New Point(13, 53)
        ComboBox1.Margin = New Padding(10, 3, 3, 3)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(105, 23)
        ComboBox1.TabIndex = 10
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label1.Location = New Point(13, 35)
        Label1.Margin = New Padding(10, 0, 3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(73, 15)
        Label1.TabIndex = 11
        Label1.Text = "Line Weight:"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PictureBox2.BackColor = Color.Black
        PictureBox2.Location = New Point(132, 53)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(23, 23)
        PictureBox2.TabIndex = 12
        PictureBox2.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label2.Location = New Point(129, 35)
        Label2.Name = "Label2"
        Label2.Size = New Size(73, 15)
        Label2.TabIndex = 13
        Label2.Text = "Line Color:"
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label3.Location = New Point(245, 35)
        Label3.Name = "Label3"
        Label3.Size = New Size(73, 15)
        Label3.TabIndex = 14
        Label3.Text = "Text Size:"
        ' 
        ' ComboBox2
        ' 
        ComboBox2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox2.FormatString = "N0"
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(245, 53)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(105, 23)
        ComboBox2.TabIndex = 15
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label4.Location = New Point(361, 35)
        Label4.Name = "Label4"
        Label4.Size = New Size(73, 15)
        Label4.TabIndex = 16
        Label4.Text = "Text Color:"
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PictureBox3.BackColor = Color.Black
        PictureBox3.Location = New Point(366, 53)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(23, 23)
        PictureBox3.TabIndex = 17
        PictureBox3.TabStop = False
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        GroupBox1.Controls.Add(CheckBox1)
        GroupBox1.Controls.Add(ComboBox2)
        GroupBox1.Controls.Add(Button7)
        GroupBox1.Controls.Add(PictureBox3)
        GroupBox1.Controls.Add(Button6)
        GroupBox1.Controls.Add(ComboBox1)
        GroupBox1.Controls.Add(Button5)
        GroupBox1.Controls.Add(Button4)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(PictureBox2)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Location = New Point(728, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(524, 210)
        GroupBox1.TabIndex = 18
        GroupBox1.TabStop = False
        GroupBox1.Text = "Tools"
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Location = New Point(13, 104)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(150, 19)
        CheckBox1.TabIndex = 18
        CheckBox1.Text = "Always add a comment"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' Button6
        ' 
        Button6.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button6.Image = My.Resources.Resources.type_24px
        Button6.Location = New Point(93, 139)
        Button6.Name = "Button6"
        Button6.Size = New Size(60, 60)
        Button6.TabIndex = 8
        Button6.Text = "Text"
        Button6.TextAlign = ContentAlignment.BottomCenter
        Button6.TextImageRelation = TextImageRelation.ImageAboveText
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button5.Image = My.Resources.Resources.erase_32px
        Button5.Location = New Point(173, 139)
        Button5.Name = "Button5"
        Button5.Size = New Size(60, 60)
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
        Button4.Image = My.Resources.Resources.up_right_32px
        Button4.Location = New Point(13, 139)
        Button4.Margin = New Padding(10, 3, 3, 3)
        Button4.Name = "Button4"
        Button4.Size = New Size(60, 60)
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
        Controls.Add(TextBox1)
        Controls.Add(PictureBox1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Editor Gambar"
        TopMost = True
        WindowState = FormWindowState.Maximized
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button7 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents CheckBox1 As CheckBox

End Class
