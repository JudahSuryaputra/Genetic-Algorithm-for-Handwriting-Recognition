Partial Class FormInput
	''' <summary>
	''' Required designer variable.
	''' </summary>
	Private components As System.ComponentModel.IContainer = Nothing

	''' <summary>
	''' Clean up any resources being used.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(disposing As Boolean)
		If disposing AndAlso (components IsNot Nothing) Then
			components.Dispose()
		End If
		MyBase.Dispose(disposing)
	End Sub

	#Region "Windows Form Designer generated code"

	''' <summary>
	''' Required method for Designer support - do not modify
	''' the contents of this method with the code editor.
	''' </summary>
	Private Sub InitializeComponent()
		Me.pictureBoxInput = New System.Windows.Forms.PictureBox()
		Me.openFileDialogLoad = New System.Windows.Forms.OpenFileDialog()
		Me.textBoxImageName = New System.Windows.Forms.TextBox()
		Me.labelFileName = New System.Windows.Forms.Label()
		Me.buttonSave = New System.Windows.Forms.Button()
		Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
		Me.loadImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.clearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.closeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.tabControl1 = New System.Windows.Forms.TabControl()
		Me.tabPageImage = New System.Windows.Forms.TabPage()
		Me.label1 = New System.Windows.Forms.Label()
		Me.comboBox1 = New System.Windows.Forms.ComboBox()
		DirectCast(Me.pictureBoxInput, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.menuStrip1.SuspendLayout()
		Me.tabControl1.SuspendLayout()
		Me.tabPageImage.SuspendLayout()
		Me.SuspendLayout()
		' 
		' pictureBoxInput
		' 
		Me.pictureBoxInput.Location = New System.Drawing.Point(0, 0)
		Me.pictureBoxInput.Name = "pictureBoxInput"
		Me.pictureBoxInput.Size = New System.Drawing.Size(100, 100)
		Me.pictureBoxInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
		Me.pictureBoxInput.TabIndex = 0
		Me.pictureBoxInput.TabStop = False
		' 
		' openFileDialogLoad
		' 
		Me.openFileDialogLoad.Filter = "Bitmap|*.bmp|JPEG|*.jpg;*.jpeg|PNG|*.png"
		' 
		' textBoxImageName
		' 
		Me.textBoxImageName.Location = New System.Drawing.Point(129, 73)
		Me.textBoxImageName.Name = "textBoxImageName"
		Me.textBoxImageName.Size = New System.Drawing.Size(329, 20)
		Me.textBoxImageName.TabIndex = 2
		' 
		' labelFileName
		' 
		Me.labelFileName.AutoSize = True
		Me.labelFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
		Me.labelFileName.Location = New System.Drawing.Point(126, 53)
		Me.labelFileName.Name = "labelFileName"
		Me.labelFileName.Size = New System.Drawing.Size(79, 17)
		Me.labelFileName.TabIndex = 4
		Me.labelFileName.Text = "Data Name"
		' 
		' buttonSave
		' 
		Me.buttonSave.Location = New System.Drawing.Point(386, 116)
		Me.buttonSave.Name = "buttonSave"
		Me.buttonSave.Size = New System.Drawing.Size(72, 23)
		Me.buttonSave.TabIndex = 14
		Me.buttonSave.Text = "Save"
		Me.buttonSave.UseVisualStyleBackColor = True
		AddHandler Me.buttonSave.Click, New System.EventHandler(AddressOf Me.buttonSave_Click)
		' 
		' menuStrip1
		' 
		Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.loadImageToolStripMenuItem, Me.clearToolStripMenuItem, Me.closeToolStripMenuItem})
		Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
		Me.menuStrip1.Name = "menuStrip1"
		Me.menuStrip1.Size = New System.Drawing.Size(471, 24)
		Me.menuStrip1.TabIndex = 18
		Me.menuStrip1.Text = "menuStrip1"
		' 
		' loadImageToolStripMenuItem
		' 
		Me.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem"
		Me.loadImageToolStripMenuItem.Size = New System.Drawing.Size(81, 20)
		Me.loadImageToolStripMenuItem.Text = "Load Image"
		AddHandler Me.loadImageToolStripMenuItem.Click, New System.EventHandler(AddressOf Me.loadImageToolStripMenuItem_Click)
		' 
		' clearToolStripMenuItem
		' 
		Me.clearToolStripMenuItem.Name = "clearToolStripMenuItem"
		Me.clearToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
		Me.clearToolStripMenuItem.Text = "Clear"
		AddHandler Me.clearToolStripMenuItem.Click, New System.EventHandler(AddressOf Me.clearToolStripMenuItem_Click)
		' 
		' closeToolStripMenuItem
		' 
		Me.closeToolStripMenuItem.Name = "closeToolStripMenuItem"
		Me.closeToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
		Me.closeToolStripMenuItem.Text = "Close"
		AddHandler Me.closeToolStripMenuItem.Click, New System.EventHandler(AddressOf Me.closeToolStripMenuItem_Click)
		' 
		' tabControl1
		' 
		Me.tabControl1.Controls.Add(Me.tabPageImage)
		Me.tabControl1.Location = New System.Drawing.Point(12, 31)
		Me.tabControl1.Name = "tabControl1"
		Me.tabControl1.SelectedIndex = 0
		Me.tabControl1.Size = New System.Drawing.Size(108, 126)
		Me.tabControl1.TabIndex = 19
		' 
		' tabPageImage
		' 
		Me.tabPageImage.AutoScroll = True
		Me.tabPageImage.Controls.Add(Me.pictureBoxInput)
		Me.tabPageImage.Location = New System.Drawing.Point(4, 22)
		Me.tabPageImage.Name = "tabPageImage"
		Me.tabPageImage.Padding = New System.Windows.Forms.Padding(3)
		Me.tabPageImage.Size = New System.Drawing.Size(100, 100)
		Me.tabPageImage.TabIndex = 0
		Me.tabPageImage.Text = "Image"
		Me.tabPageImage.UseVisualStyleBackColor = True
		' 
		' label1
		' 
		Me.label1.AutoSize = True
		Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
		Me.label1.Location = New System.Drawing.Point(126, 96)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(70, 17)
		Me.label1.TabIndex = 20
		Me.label1.Text = "Character"
		' 
		' comboBox1
		' 
		Me.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.comboBox1.FormattingEnabled = True
		Me.comboBox1.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F", _
			"G", "H", "I", "J", "K", "L", _
			"M", "N", "O", "P", "Q", "R", _
			"S", "T", "U", "V", "W", "X", _
			"Y", "Z", "a", "b", "c", "d", _
			"e", "f", "g", "h", "i", "j", _
			"k", "l", "m", "n", "o", "p", _
			"q", "r", "s", "t", "u", "v", _
			"w", "x", "y", "z", "0", "1", _
			"2", "3", "4", "5", "6", "7", _
			"8", "9"})
		Me.comboBox1.Location = New System.Drawing.Point(129, 116)
		Me.comboBox1.Name = "comboBox1"
		Me.comboBox1.Size = New System.Drawing.Size(67, 21)
		Me.comboBox1.TabIndex = 21
		' 
		' FormInput
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(471, 164)
		Me.Controls.Add(Me.comboBox1)
		Me.Controls.Add(Me.label1)
		Me.Controls.Add(Me.buttonSave)
		Me.Controls.Add(Me.tabControl1)
		Me.Controls.Add(Me.labelFileName)
		Me.Controls.Add(Me.textBoxImageName)
		Me.Controls.Add(Me.menuStrip1)
		Me.MainMenuStrip = Me.menuStrip1
		Me.Name = "FormInput"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Input Image"
		AddHandler Me.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf Me.FormInput_FormClosed)
		DirectCast(Me.pictureBoxInput, System.ComponentModel.ISupportInitialize).EndInit()
		Me.menuStrip1.ResumeLayout(False)
		Me.menuStrip1.PerformLayout()
		Me.tabControl1.ResumeLayout(False)
		Me.tabPageImage.ResumeLayout(False)
		Me.tabPageImage.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	#End Region

    Private WithEvents pictureBoxInput As System.Windows.Forms.PictureBox
    Private WithEvents openFileDialogLoad As System.Windows.Forms.OpenFileDialog
    Private WithEvents textBoxImageName As System.Windows.Forms.TextBox
    Private WithEvents labelFileName As System.Windows.Forms.Label
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents loadImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents clearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents closeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private WithEvents tabPageImage As System.Windows.Forms.TabPage
    Private WithEvents buttonSave As System.Windows.Forms.Button
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents comboBox1 As System.Windows.Forms.ComboBox
End Class
