Imports System.Windows.Forms

Public Partial Class FormDatabase
	Inherits Form
	Private dm As DataModule
	Public openerForm As FormUtama

	Public Sub New()
		InitializeComponent()
		Me.dm = New DataModule()
	End Sub

	Private Sub FormDatabase_Shown(sender As Object, e As EventArgs)
		RefreshData()
	End Sub

	Private Sub RefreshData()
		listBoxDatabase.Items.Clear()
		Dim names As String() = Me.dm.GetAllImageID()
		If names IsNot Nothing Then
			listBoxDatabase.Items.AddRange(names)
		End If
	End Sub

	Private Sub buttonClose_Click(sender As Object, e As EventArgs)
		Me.Close()
	End Sub

	Private Sub FormDatabase_FormClosed(sender As Object, e As FormClosedEventArgs)
		CommonMethod.DisposePictureBoxImage(pictureBoxDatabase)
		Me.openerForm.fDatabase = Nothing
		Me.Dispose()
	End Sub

	Private Sub ClearData()
		CommonMethod.DisposePictureBoxImage(pictureBoxDatabase)
		textBoxCharacter.Clear()
		textBoxImageName.Clear()
		richTextBoxChromosome.Clear()
	End Sub

	Private Sub listBoxDatabase_SelectedIndexChanged(sender As Object, e As EventArgs)
		If listBoxDatabase.SelectedItem Is Nothing Then
			Return
		End If
		Dim name As String = listBoxDatabase.SelectedItem.ToString()
		Dim result As ResultData = Me.dm.GetSingleData(name)
		textBoxCharacter.Text = result.character
		textBoxImageName.Text = result.imageName
		richTextBoxChromosome.Text = result.chromosomeBit
		pictureBoxDatabase.Image = result.oBitmap
	End Sub

	Private Sub buttonDelete_Click(sender As Object, e As EventArgs)
		Delete()
	End Sub

	Private Sub Delete()
		If listBoxDatabase.SelectedItem Is Nothing Then
			Return
		End If
		Dim dr As DialogResult = MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.YesNo)
		If (dr = DialogResult.Yes) OrElse (dr = DialogResult.OK) Then
			Dim name As String = listBoxDatabase.SelectedItem.ToString()
			Dim deleted As Boolean = Me.dm.DeleteData(name)
			If deleted Then
				CommonMethod.DisposePictureBoxImage(pictureBoxDatabase)
				listBoxDatabase.Items.Remove(listBoxDatabase.SelectedItem)
				ClearData()
				MessageBox.Show("Deleted!")
			End If
		End If
	End Sub

	Private Sub comboBoxType_SelectedIndexChanged(sender As Object, e As EventArgs)
		RefreshData()
	End Sub
End Class
