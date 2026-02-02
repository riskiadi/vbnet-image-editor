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
        TableLayoutPanel1 = New TableLayoutPanel()
        Button6 = New Button()
        Button5 = New Button()
        Button1 = New Button()
        Button4 = New Button()
        CheckBox1 = New CheckBox()
        PictureBox3 = New PictureBox()
        GroupBox2 = New GroupBox()
        TableLayoutPanel2 = New TableLayoutPanel()
        Label6 = New Label()
        Label3 = New Label()
        LabelNamaPasien = New Label()
        Label4 = New Label()
        LabelNoPasien = New Label()
        LabelUserInput = New Label()
        FileSystemWatcher1 = New IO.FileSystemWatcher()
        Label5 = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox2.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        CType(FileSystemWatcher1, ComponentModel.ISupportInitialize).BeginInit()
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
        Button7.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Button7.Font = New Font("Quicksand", 9.75F)
        Button7.Image = CType(resources.GetObject("Button7.Image"), Image)
        Button7.Location = New Point(317, 3)
        Button7.Margin = New Padding(3, 3, 10, 3)
        Button7.Name = "Button7"
        Button7.Size = New Size(158, 63)
        Button7.TabIndex = 9
        Button7.Text = "Simpan"
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
        ComboBox1.Location = New Point(173, 29)
        ComboBox1.Margin = New Padding(10, 3, 3, 3)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(90, 27)
        ComboBox1.TabIndex = 10
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label1.Font = New Font("Quicksand", 9.75F)
        Label1.Location = New Point(14, 32)
        Label1.Margin = New Padding(10, 0, 3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(153, 20)
        Label1.TabIndex = 11
        Label1.Text = "Ketebalan garis:"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PictureBox2.BackColor = Color.Black
        PictureBox2.Location = New Point(173, 66)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(23, 23)
        PictureBox2.TabIndex = 12
        PictureBox2.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label2.Font = New Font("Quicksand", 9.75F)
        Label2.Location = New Point(14, 67)
        Label2.Name = "Label2"
        Label2.Size = New Size(153, 20)
        Label2.TabIndex = 13
        Label2.Text = "Warna garis:"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        GroupBox1.Controls.Add(TableLayoutPanel1)
        GroupBox1.Controls.Add(CheckBox1)
        GroupBox1.Controls.Add(ComboBox1)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(PictureBox2)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Font = New Font("Quicksand", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        GroupBox1.Location = New Point(751, 159)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(501, 220)
        GroupBox1.TabIndex = 18
        GroupBox1.TabStop = False
        GroupBox1.Text = "Alat"
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 5
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 19F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 19F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 19F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 35F))
        TableLayoutPanel1.Controls.Add(Button6, 1, 0)
        TableLayoutPanel1.Controls.Add(Button5, 2, 0)
        TableLayoutPanel1.Controls.Add(Button7, 4, 0)
        TableLayoutPanel1.Controls.Add(Button1, 3, 0)
        TableLayoutPanel1.Controls.Add(Button4, 0, 0)
        TableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize
        TableLayoutPanel1.Location = New Point(8, 141)
        TableLayoutPanel1.Margin = New Padding(5, 3, 5, 3)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.Size = New Size(485, 69)
        TableLayoutPanel1.TabIndex = 20
        ' 
        ' Button6
        ' 
        Button6.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Button6.Font = New Font("Quicksand", 9.75F)
        Button6.ForeColor = Color.Black
        Button6.Image = CType(resources.GetObject("Button6.Image"), Image)
        Button6.Location = New Point(95, 3)
        Button6.Name = "Button6"
        Button6.Size = New Size(86, 63)
        Button6.TabIndex = 8
        Button6.Text = "Catatan"
        Button6.TextAlign = ContentAlignment.BottomCenter
        Button6.TextImageRelation = TextImageRelation.ImageAboveText
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Button5.Font = New Font("Quicksand", 9.75F)
        Button5.Image = CType(resources.GetObject("Button5.Image"), Image)
        Button5.Location = New Point(187, 3)
        Button5.Margin = New Padding(3, 3, 10, 3)
        Button5.Name = "Button5"
        Button5.Size = New Size(79, 63)
        Button5.TabIndex = 7
        Button5.Text = "Hapus"
        Button5.TextAlign = ContentAlignment.BottomCenter
        Button5.TextImageRelation = TextImageRelation.ImageAboveText
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Button1.Enabled = False
        Button1.Font = New Font("Quicksand", 9.75F)
        Button1.ForeColor = Color.Black
        Button1.Image = CType(resources.GetObject("Button1.Image"), Image)
        Button1.Location = New Point(279, 3)
        Button1.Name = "Button1"
        Button1.Size = New Size(32, 63)
        Button1.TabIndex = 19
        Button1.Text = "Draw"
        Button1.TextAlign = ContentAlignment.BottomCenter
        Button1.TextImageRelation = TextImageRelation.ImageAboveText
        Button1.UseVisualStyleBackColor = True
        Button1.Visible = False
        ' 
        ' Button4
        ' 
        Button4.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Button4.BackColor = Color.Transparent
        Button4.BackgroundImageLayout = ImageLayout.Center
        Button4.Font = New Font("Quicksand", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button4.ForeColor = Color.Black
        Button4.Image = CType(resources.GetObject("Button4.Image"), Image)
        Button4.Location = New Point(10, 3)
        Button4.Margin = New Padding(10, 3, 3, 3)
        Button4.Name = "Button4"
        Button4.Size = New Size(79, 63)
        Button4.TabIndex = 6
        Button4.Text = "Panah"
        Button4.TextAlign = ContentAlignment.BottomCenter
        Button4.TextImageRelation = TextImageRelation.ImageAboveText
        Button4.UseVisualStyleBackColor = False
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Enabled = False
        CheckBox1.Font = New Font("Quicksand", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CheckBox1.Location = New Point(14, 102)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(220, 23)
        CheckBox1.TabIndex = 18
        CheckBox1.Text = "Tambah komentar pada panah"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BorderStyle = BorderStyle.FixedSingle
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(11, 25)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(77, 105)
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.TabIndex = 2
        PictureBox3.TabStop = False
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        GroupBox2.Controls.Add(TableLayoutPanel2)
        GroupBox2.Controls.Add(PictureBox3)
        GroupBox2.Font = New Font("Quicksand", 9.75F)
        GroupBox2.Location = New Point(751, 12)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(501, 142)
        GroupBox2.TabIndex = 19
        GroupBox2.TabStop = False
        GroupBox2.Text = "Informasi"
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.BackColor = Color.Linen
        TableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        TableLayoutPanel2.ColumnCount = 2
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 28F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 72F))
        TableLayoutPanel2.Controls.Add(Label6, 0, 2)
        TableLayoutPanel2.Controls.Add(Label3, 0, 0)
        TableLayoutPanel2.Controls.Add(LabelNamaPasien, 1, 0)
        TableLayoutPanel2.Controls.Add(Label4, 0, 1)
        TableLayoutPanel2.Controls.Add(LabelNoPasien, 1, 1)
        TableLayoutPanel2.Controls.Add(LabelUserInput, 1, 2)
        TableLayoutPanel2.Location = New Point(103, 25)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 3
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel2.Size = New Size(380, 105)
        TableLayoutPanel2.TabIndex = 5
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.Left
        Label6.AutoSize = True
        Label6.Font = New Font("Quicksand", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(4, 77)
        Label6.Name = "Label6"
        Label6.Size = New Size(40, 19)
        Label6.TabIndex = 21
        Label6.Text = "DPJP"
        Label6.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Left
        Label3.AutoSize = True
        Label3.Font = New Font("Quicksand", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(4, 8)
        Label3.Name = "Label3"
        Label3.Size = New Size(90, 19)
        Label3.TabIndex = 0
        Label3.Text = "Nama Pasien"
        Label3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabelNamaPasien
        ' 
        LabelNamaPasien.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        LabelNamaPasien.AutoEllipsis = True
        LabelNamaPasien.Font = New Font("Quicksand SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelNamaPasien.Location = New Point(110, 8)
        LabelNamaPasien.Name = "LabelNamaPasien"
        LabelNamaPasien.Size = New Size(266, 19)
        LabelNamaPasien.TabIndex = 3
        LabelNamaPasien.Text = "-"
        LabelNamaPasien.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Left
        Label4.AutoSize = True
        Label4.Font = New Font("Quicksand", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(4, 42)
        Label4.Name = "Label4"
        Label4.Size = New Size(70, 19)
        Label4.TabIndex = 1
        Label4.Text = "No Pasien"
        Label4.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabelNoPasien
        ' 
        LabelNoPasien.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        LabelNoPasien.AutoEllipsis = True
        LabelNoPasien.Font = New Font("Quicksand SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelNoPasien.Location = New Point(110, 42)
        LabelNoPasien.Name = "LabelNoPasien"
        LabelNoPasien.Size = New Size(266, 19)
        LabelNoPasien.TabIndex = 4
        LabelNoPasien.Text = "-"
        LabelNoPasien.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' LabelUserInput
        ' 
        LabelUserInput.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        LabelUserInput.AutoEllipsis = True
        LabelUserInput.Font = New Font("Quicksand SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelUserInput.Location = New Point(110, 77)
        LabelUserInput.Name = "LabelUserInput"
        LabelUserInput.Size = New Size(266, 19)
        LabelUserInput.TabIndex = 22
        LabelUserInput.Text = "-"
        LabelUserInput.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' FileSystemWatcher1
        ' 
        FileSystemWatcher1.EnableRaisingEvents = True
        FileSystemWatcher1.SynchronizingObject = Me
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label5.AutoEllipsis = True
        Label5.Font = New Font("Quicksand SemiBold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.Silver
        Label5.Location = New Point(751, 388)
        Label5.Name = "Label5"
        Label5.Size = New Size(501, 28)
        Label5.TabIndex = 20
        Label5.Text = "© 2026 SIMRS RSUD dr. Adhyatma, MPH - Pemerintah Provinsi Jawa Tengah."
        Label5.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(1264, 761)
        Controls.Add(Label5)
        Controls.Add(GroupBox2)
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
        TableLayoutPanel1.ResumeLayout(False)
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        GroupBox2.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        CType(FileSystemWatcher1, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents FileSystemWatcher1 As IO.FileSystemWatcher
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents LabelNamaPasien As Label
    Friend WithEvents LabelNoPasien As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents LabelUserInput As Label

End Class
