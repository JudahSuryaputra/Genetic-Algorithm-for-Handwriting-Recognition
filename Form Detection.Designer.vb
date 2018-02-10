Partial Class FormDetection
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
        Me.openFileDialogLoad = New System.Windows.Forms.OpenFileDialog()
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.loadImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.PreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.detectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.clearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.closeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pictureBoxInput = New System.Windows.Forms.PictureBox()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.richTextBoxResult = New System.Windows.Forms.RichTextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.menuStrip1.SuspendLayout()
        CType(Me.pictureBoxInput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'openFileDialogLoad
        '
        Me.openFileDialogLoad.Filter = "Bitmap|*.bmp|JPEG|*.jpg;*.jpeg|PNG|*.png"
        '
        'menuStrip1
        '
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.loadImageToolStripMenuItem, Me.toolStripComboBox1, Me.PreviewToolStripMenuItem, Me.detectToolStripMenuItem, Me.clearToolStripMenuItem, Me.closeToolStripMenuItem})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(853, 27)
        Me.menuStrip1.TabIndex = 18
        Me.menuStrip1.Text = "menuStrip1"
        '
        'loadImageToolStripMenuItem
        '
        Me.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem"
        Me.loadImageToolStripMenuItem.Size = New System.Drawing.Size(81, 23)
        Me.loadImageToolStripMenuItem.Text = "Load Image"
        '
        'toolStripComboBox1
        '
        Me.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.toolStripComboBox1.Items.AddRange(New Object() {"One Point Crossover", "Two Point Crossover", "Uniform Crossover"})
        Me.toolStripComboBox1.Name = "toolStripComboBox1"
        Me.toolStripComboBox1.Size = New System.Drawing.Size(121, 23)
        '
        'PreviewToolStripMenuItem
        '
        Me.PreviewToolStripMenuItem.Name = "PreviewToolStripMenuItem"
        Me.PreviewToolStripMenuItem.Size = New System.Drawing.Size(60, 23)
        Me.PreviewToolStripMenuItem.Text = "Preview"
        '
        'detectToolStripMenuItem
        '
        Me.detectToolStripMenuItem.Name = "detectToolStripMenuItem"
        Me.detectToolStripMenuItem.Size = New System.Drawing.Size(53, 23)
        Me.detectToolStripMenuItem.Text = "Detect"
        '
        'clearToolStripMenuItem
        '
        Me.clearToolStripMenuItem.Name = "clearToolStripMenuItem"
        Me.clearToolStripMenuItem.Size = New System.Drawing.Size(46, 23)
        Me.clearToolStripMenuItem.Text = "Clear"
        '
        'closeToolStripMenuItem
        '
        Me.closeToolStripMenuItem.Name = "closeToolStripMenuItem"
        Me.closeToolStripMenuItem.Size = New System.Drawing.Size(48, 23)
        Me.closeToolStripMenuItem.Text = "Close"
        '
        'pictureBoxInput
        '
        Me.pictureBoxInput.Location = New System.Drawing.Point(0, 0)
        Me.pictureBoxInput.Name = "pictureBoxInput"
        Me.pictureBoxInput.Size = New System.Drawing.Size(825, 346)
        Me.pictureBoxInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureBoxInput.TabIndex = 20
        Me.pictureBoxInput.TabStop = False
        '
        'panel1
        '
        Me.panel1.AutoScroll = True
        Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panel1.Controls.Add(Me.pictureBoxInput)
        Me.panel1.Location = New System.Drawing.Point(12, 27)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(829, 350)
        Me.panel1.TabIndex = 21
        '
        'richTextBoxResult
        '
        Me.richTextBoxResult.Location = New System.Drawing.Point(12, 383)
        Me.richTextBoxResult.Name = "richTextBoxResult"
        Me.richTextBoxResult.ReadOnly = True
        Me.richTextBoxResult.Size = New System.Drawing.Size(829, 201)
        Me.richTextBoxResult.TabIndex = 22
        Me.richTextBoxResult.Text = ""
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 592)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(853, 22)
        Me.StatusStrip1.TabIndex = 23
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(800, 16)
        '
        'FormDetection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 614)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.richTextBoxResult)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.menuStrip1)
        Me.MainMenuStrip = Me.menuStrip1
        Me.Name = "FormDetection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Input Image"
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        CType(Me.pictureBoxInput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private toolStripComboBox1 As System.Windows.Forms.ToolStripComboBox

	#End Region

    Private WithEvents openFileDialogLoad As System.Windows.Forms.OpenFileDialog
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents loadImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents clearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents closeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents detectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents pictureBoxInput As System.Windows.Forms.PictureBox
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents richTextBoxResult As System.Windows.Forms.RichTextBox
    Friend WithEvents PreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
End Class
