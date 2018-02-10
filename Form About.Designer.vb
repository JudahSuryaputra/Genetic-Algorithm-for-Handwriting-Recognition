Partial Class FormAbout
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
		Me.pictureBoxAbout = New System.Windows.Forms.PictureBox()
		DirectCast(Me.pictureBoxAbout, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		' 
		' pictureBoxAbout
		' 
		Me.pictureBoxAbout.Location = New System.Drawing.Point(0, 0)
		Me.pictureBoxAbout.Margin = New System.Windows.Forms.Padding(0)
		Me.pictureBoxAbout.Name = "pictureBoxAbout"
		Me.pictureBoxAbout.Size = New System.Drawing.Size(500, 500)
		Me.pictureBoxAbout.TabIndex = 0
		Me.pictureBoxAbout.TabStop = False
		' 
		' FormAbout
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(500, 500)
		Me.Controls.Add(Me.pictureBoxAbout)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "FormAbout"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "About"
		AddHandler Me.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf Me.FormAbout_FormClosed)
		AddHandler Me.Load, New System.EventHandler(AddressOf Me.FormAbout_Load)
		DirectCast(Me.pictureBoxAbout, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

	#End Region

    Private WithEvents pictureBoxAbout As System.Windows.Forms.PictureBox
End Class
