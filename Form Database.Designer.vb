Partial Class FormDatabase
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
		Me.pictureBoxDatabase = New System.Windows.Forms.PictureBox()
		Me.listBoxDatabase = New System.Windows.Forms.ListBox()
		Me.buttonClose = New System.Windows.Forms.Button()
		Me.buttonDelete = New System.Windows.Forms.Button()
		Me.labelTrainingName = New System.Windows.Forms.Label()
		Me.textBoxCharacter = New System.Windows.Forms.TextBox()
		Me.openFileDialogLoad = New System.Windows.Forms.OpenFileDialog()
		Me.textBoxImageName = New System.Windows.Forms.TextBox()
		Me.label4 = New System.Windows.Forms.Label()
		Me.label1 = New System.Windows.Forms.Label()
		Me.richTextBoxChromosome = New System.Windows.Forms.RichTextBox()
		DirectCast(Me.pictureBoxDatabase, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		' 
		' pictureBoxDatabase
		' 
		Me.pictureBoxDatabase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pictureBoxDatabase.Location = New System.Drawing.Point(241, 12)
		Me.pictureBoxDatabase.Name = "pictureBoxDatabase"
		Me.pictureBoxDatabase.Size = New System.Drawing.Size(165, 165)
		Me.pictureBoxDatabase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.pictureBoxDatabase.TabIndex = 0
		Me.pictureBoxDatabase.TabStop = False
		' 
		' listBoxDatabase
		' 
		Me.listBoxDatabase.FormattingEnabled = True
		Me.listBoxDatabase.HorizontalScrollbar = True
		Me.listBoxDatabase.Location = New System.Drawing.Point(13, 12)
		Me.listBoxDatabase.Name = "listBoxDatabase"
		Me.listBoxDatabase.Size = New System.Drawing.Size(222, 537)
		Me.listBoxDatabase.TabIndex = 1
		AddHandler Me.listBoxDatabase.SelectedIndexChanged, New System.EventHandler(AddressOf Me.listBoxDatabase_SelectedIndexChanged)
		' 
		' buttonClose
		' 
		Me.buttonClose.Location = New System.Drawing.Point(160, 557)
		Me.buttonClose.Name = "buttonClose"
		Me.buttonClose.Size = New System.Drawing.Size(75, 23)
		Me.buttonClose.TabIndex = 2
		Me.buttonClose.Text = "Close"
		Me.buttonClose.UseVisualStyleBackColor = True
		AddHandler Me.buttonClose.Click, New System.EventHandler(AddressOf Me.buttonClose_Click)
		' 
		' buttonDelete
		' 
		Me.buttonDelete.Location = New System.Drawing.Point(12, 557)
		Me.buttonDelete.Name = "buttonDelete"
		Me.buttonDelete.Size = New System.Drawing.Size(75, 23)
		Me.buttonDelete.TabIndex = 3
		Me.buttonDelete.Text = "Delete"
		Me.buttonDelete.UseVisualStyleBackColor = True
		AddHandler Me.buttonDelete.Click, New System.EventHandler(AddressOf Me.buttonDelete_Click)
		' 
		' labelTrainingName
		' 
		Me.labelTrainingName.AutoSize = True
		Me.labelTrainingName.Location = New System.Drawing.Point(241, 217)
		Me.labelTrainingName.Name = "labelTrainingName"
		Me.labelTrainingName.Size = New System.Drawing.Size(53, 13)
		Me.labelTrainingName.TabIndex = 4
		Me.labelTrainingName.Text = "Character"
		' 
		' textBoxCharacter
		' 
		Me.textBoxCharacter.Location = New System.Drawing.Point(241, 233)
		Me.textBoxCharacter.Name = "textBoxCharacter"
		Me.textBoxCharacter.[ReadOnly] = True
		Me.textBoxCharacter.Size = New System.Drawing.Size(61, 20)
		Me.textBoxCharacter.TabIndex = 5
		' 
		' openFileDialogLoad
		' 
		Me.openFileDialogLoad.Filter = "Bitmap|*.bmp|JPEG|*.jpg;*.jpeg"
		' 
		' textBoxImageName
		' 
		Me.textBoxImageName.Location = New System.Drawing.Point(241, 196)
		Me.textBoxImageName.Name = "textBoxImageName"
		Me.textBoxImageName.[ReadOnly] = True
		Me.textBoxImageName.Size = New System.Drawing.Size(165, 20)
		Me.textBoxImageName.TabIndex = 43
		' 
		' label4
		' 
		Me.label4.AutoSize = True
		Me.label4.Location = New System.Drawing.Point(241, 180)
		Me.label4.Name = "label4"
		Me.label4.Size = New System.Drawing.Size(61, 13)
		Me.label4.TabIndex = 42
		Me.label4.Text = "Data Name"
		' 
		' label1
		' 
		Me.label1.AutoSize = True
		Me.label1.Location = New System.Drawing.Point(241, 256)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(68, 13)
		Me.label1.TabIndex = 44
		Me.label1.Text = "Chromosome"
		' 
		' richTextBoxChromosome
		' 
		Me.richTextBoxChromosome.Location = New System.Drawing.Point(241, 272)
		Me.richTextBoxChromosome.Name = "richTextBoxChromosome"
		Me.richTextBoxChromosome.[ReadOnly] = True
		Me.richTextBoxChromosome.Size = New System.Drawing.Size(173, 308)
		Me.richTextBoxChromosome.TabIndex = 46
		Me.richTextBoxChromosome.Text = ""
		' 
		' FormDatabase
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(426, 590)
		Me.Controls.Add(Me.richTextBoxChromosome)
		Me.Controls.Add(Me.label1)
		Me.Controls.Add(Me.textBoxImageName)
		Me.Controls.Add(Me.label4)
		Me.Controls.Add(Me.textBoxCharacter)
		Me.Controls.Add(Me.labelTrainingName)
		Me.Controls.Add(Me.buttonDelete)
		Me.Controls.Add(Me.buttonClose)
		Me.Controls.Add(Me.listBoxDatabase)
		Me.Controls.Add(Me.pictureBoxDatabase)
		Me.Name = "FormDatabase"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Image Database"
		AddHandler Me.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf Me.FormDatabase_FormClosed)
		AddHandler Me.Shown, New System.EventHandler(AddressOf Me.FormDatabase_Shown)
		DirectCast(Me.pictureBoxDatabase, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	#End Region

    Private WithEvents pictureBoxDatabase As System.Windows.Forms.PictureBox
    Private WithEvents listBoxDatabase As System.Windows.Forms.ListBox
    Private WithEvents buttonClose As System.Windows.Forms.Button
    Private WithEvents buttonDelete As System.Windows.Forms.Button
    Private WithEvents labelTrainingName As System.Windows.Forms.Label
    Private WithEvents textBoxCharacter As System.Windows.Forms.TextBox
    Private WithEvents openFileDialogLoad As System.Windows.Forms.OpenFileDialog
    Private WithEvents textBoxImageName As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents richTextBoxChromosome As System.Windows.Forms.RichTextBox
End Class
