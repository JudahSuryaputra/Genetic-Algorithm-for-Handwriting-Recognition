Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms

Public Partial Class FormInput
	Inherits Form
	Private imageInfo As ImageInformation
	Public openerForm As FormUtama

	Public Sub New()
		InitializeComponent()
		imageInfo = New ImageInformation()
	End Sub

	Private Sub buttonLoad_Click(sender As Object, e As EventArgs)
		LoadDialog()
	End Sub

	Private Sub LoadDialog()
		If CommonMethod.LoadImage(openFileDialogLoad, imageInfo) Then
			textBoxImageName.Text = Path.GetFileName(openFileDialogLoad.FileName)
			pictureBoxInput.Image = imageInfo.picture
		End If
	End Sub

	Private Sub ClearForm()
		textBoxImageName.Clear()
		imageInfo.Clear()
		CommonMethod.DisposePictureBoxImage(pictureBoxInput)
	End Sub

	Private Sub FormInput_FormClosed(sender As Object, e As FormClosedEventArgs)
		ClearForm()
		Me.openerForm.fInput = Nothing
		Me.Dispose()
	End Sub

	Private Sub Save()
		If Not imageInfo.load Then
			MessageBox.Show("Belum memilih image.")
			Return
		End If
		If String.IsNullOrWhiteSpace(textBoxImageName.Text) Then
			MessageBox.Show("Belum memasukkan nama image.")
			Return
		End If
		If comboBox1.SelectedItem Is Nothing Then
			MessageBox.Show("Pilih jenis karakter.")
			Return
		End If
		Dim fileName As String = textBoxImageName.Text
		Dim character As String = comboBox1.SelectedItem.ToString()
		Dim chromosomeBit As String = ""
		Dim dm As New DataModule()
        dm.DeleteData(fileName)
        Dim oCropper As New Autocrop()
        Dim iBoundTop As Integer = 0
        Dim iBoundBottom As Integer = 0
        Dim iBoundLeft As Integer = 0
        Dim iBoundRight As Integer = 0
        Dim blackCount As Integer = 0        
        Dim threshold As Integer(,) = DIPFunction.Thresholding(imageInfo.pixelValue)
        oCropper.FindBound(threshold, iBoundLeft, iBoundRight, iBoundTop, iBoundBottom, blackCount)
        Dim iBoundHeight As Integer = iBoundBottom - iBoundTop + 1
        Dim iBoundWidth As Integer = iBoundRight - iBoundLeft + 1
        Dim thresholdCrop As Integer(,) = oCropper.Crop(threshold, iBoundLeft, iBoundTop, iBoundWidth, iBoundHeight)
        Dim scaled As Integer(,) = DIPFunction.Scale(thresholdCrop, 20, 30)
		chromosomeBit = DIPFunction.ConvertToChromosome(scaled)
		Dim success As Boolean = dm.AddData(fileName, imageInfo.picture, character, chromosomeBit)
		If success Then
			MessageBox.Show("Saved!")
		Else
			MessageBox.Show("Not Saved!")
		End If
	End Sub

	Private Sub closeToolStripMenuItem_Click(sender As Object, e As EventArgs)
		Me.Close()
	End Sub

	Private Sub clearToolStripMenuItem_Click(sender As Object, e As EventArgs)
		ClearForm()
	End Sub

	Private Sub loadImageToolStripMenuItem_Click(sender As Object, e As EventArgs)
		LoadDialog()
	End Sub

	Private Sub buttonSave_Click(sender As Object, e As EventArgs)
		Save()
	End Sub
End Class
