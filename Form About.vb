Imports System.IO
Imports System.Windows.Forms

Public Partial Class FormAbout
	Inherits Form
	Public openerForm As FormUtama

	Public Sub New()
		InitializeComponent()
	End Sub

	Private Sub FormAbout_FormClosed(sender As Object, e As FormClosedEventArgs)
		CommonMethod.DisposePictureBoxImage(pictureBoxAbout)
		Me.openerForm.fAbout = Nothing
		Me.Dispose()
	End Sub

	Private Sub FormAbout_Load(sender As Object, e As EventArgs)
		CommonMethod.LoadPictureBoxImage(pictureBoxAbout, Application.StartupPath & "\about.jpg")
	End Sub
End Class
