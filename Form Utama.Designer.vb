Partial Class FormUtama
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
		Me.menuStripUtama = New System.Windows.Forms.MenuStrip()
		Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.inputImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.databaseImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.pictureBoxCover = New System.Windows.Forms.PictureBox()
		Me.detectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.menuStripUtama.SuspendLayout()
		DirectCast(Me.pictureBoxCover, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		' 
		' menuStripUtama
		' 
		Me.menuStripUtama.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.helpToolStripMenuItem, Me.aboutToolStripMenuItem, Me.exitToolStripMenuItem})
		Me.menuStripUtama.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
		Me.menuStripUtama.Location = New System.Drawing.Point(0, 0)
		Me.menuStripUtama.Name = "menuStripUtama"
		Me.menuStripUtama.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.menuStripUtama.Size = New System.Drawing.Size(720, 24)
		Me.menuStripUtama.TabIndex = 0
		Me.menuStripUtama.Text = "menuStripUtama"
		' 
		' fileToolStripMenuItem
		' 
		Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.inputImageToolStripMenuItem, Me.databaseImageToolStripMenuItem, Me.detectionToolStripMenuItem})
		Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
		Me.fileToolStripMenuItem.ShortcutKeyDisplayString = ""
		Me.fileToolStripMenuItem.Size = New System.Drawing.Size(112, 20)
		Me.fileToolStripMenuItem.Text = "Image Processing"
		' 
		' inputImageToolStripMenuItem
		' 
		Me.inputImageToolStripMenuItem.Name = "inputImageToolStripMenuItem"
		Me.inputImageToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
		Me.inputImageToolStripMenuItem.Text = "Input Image"
		AddHandler Me.inputImageToolStripMenuItem.Click, New System.EventHandler(AddressOf Me.inputImageToolStripMenuItem_Click)
		' 
		' databaseImageToolStripMenuItem
		' 
		Me.databaseImageToolStripMenuItem.Name = "databaseImageToolStripMenuItem"
		Me.databaseImageToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
		Me.databaseImageToolStripMenuItem.Text = "Database Image"
		AddHandler Me.databaseImageToolStripMenuItem.Click, New System.EventHandler(AddressOf Me.databaseImageToolStripMenuItem_Click)
		' 
		' helpToolStripMenuItem
		' 
		Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
		Me.helpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
		Me.helpToolStripMenuItem.Text = "Help"
		AddHandler Me.helpToolStripMenuItem.Click, New System.EventHandler(AddressOf Me.helpToolStripMenuItem_Click)
		' 
		' aboutToolStripMenuItem
		' 
		Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
		Me.aboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
		Me.aboutToolStripMenuItem.Text = "About"
		AddHandler Me.aboutToolStripMenuItem.Click, New System.EventHandler(AddressOf Me.aboutToolStripMenuItem_Click)
		' 
		' exitToolStripMenuItem
		' 
		Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
		Me.exitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
		Me.exitToolStripMenuItem.Text = "Exit"
		AddHandler Me.exitToolStripMenuItem.Click, New System.EventHandler(AddressOf Me.exitToolStripMenuItem_Click)
		' 
		' pictureBoxCover
		' 
		Me.pictureBoxCover.Location = New System.Drawing.Point(0, 24)
		Me.pictureBoxCover.Margin = New System.Windows.Forms.Padding(0)
		Me.pictureBoxCover.Name = "pictureBoxCover"
		Me.pictureBoxCover.Size = New System.Drawing.Size(720, 480)
		Me.pictureBoxCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.pictureBoxCover.TabIndex = 1
		Me.pictureBoxCover.TabStop = False
		' 
		' detectionToolStripMenuItem
		' 
		Me.detectionToolStripMenuItem.Name = "detectionToolStripMenuItem"
		Me.detectionToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
		Me.detectionToolStripMenuItem.Text = "Detection"
		AddHandler Me.detectionToolStripMenuItem.Click, New System.EventHandler(AddressOf Me.detectionToolStripMenuItem_Click)
		' 
		' FormUtama
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(720, 504)
		Me.Controls.Add(Me.pictureBoxCover)
		Me.Controls.Add(Me.menuStripUtama)
		Me.Name = "FormUtama"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Main Menu"
		AddHandler Me.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf Me.FormUtama_FormClosed)
		AddHandler Me.Load, New System.EventHandler(AddressOf Me.FormUtama_Load)
		Me.menuStripUtama.ResumeLayout(False)
		Me.menuStripUtama.PerformLayout()
		DirectCast(Me.pictureBoxCover, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	#End Region

    Private WithEvents menuStripUtama As System.Windows.Forms.MenuStrip
    Private WithEvents fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents inputImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents databaseImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents pictureBoxCover As System.Windows.Forms.PictureBox
    Private WithEvents detectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
