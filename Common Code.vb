Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Threading.Tasks
Imports System.Windows.Forms

Public Class CommonMethod
	Public Shared Sub DisposePictureBoxImage(ByRef picBox As PictureBox)
		If picBox.Image IsNot Nothing Then
			picBox.Image.Dispose()
			picBox.Image = Nothing
		End If
	End Sub

	Public Shared Sub LoadPictureBoxImage(ByRef picBox As PictureBox, filePath As String)
		If File.Exists(filePath) Then
			Try
				picBox.Load(filePath)
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End If
	End Sub

	Public Shared Function LoadImage(dialog As OpenFileDialog, ByRef imageInfo As ImageInformation) As Boolean
		Dim dResult As DialogResult = dialog.ShowDialog()
		If dResult = DialogResult.OK OrElse dResult = DialogResult.Yes Then
			Dim fileLocation As String = dialog.FileName
			Dim loaded As Boolean = False
			Try
				Dim image As New Bitmap(fileLocation)
				Dim message As String = ""
				If DIPFunction.CheckImageSize(image.Height, image.Width, message) Then
					imageInfo = New ImageInformation(image)
					loaded = True
				Else
					MessageBox.Show(message)
					image.Dispose()
					loaded = False
				End If
			Catch
				MessageBox.Show("File yang dipilih bukan gambar.")
				loaded = False
			End Try
			Return loaded
		Else
			Return False
		End If
	End Function
End Class

Public NotInheritable Class CommonEvents
	Private Sub New()
	End Sub
	Public Shared Sub KeyPressIntegerOnly(sender As Object, e As KeyPressEventArgs)
		Dim c As Char = e.KeyChar
        If c = ChrW(Keys.Back) OrElse (c >= "0"c AndAlso c <= "9"c) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Public Shared Sub KeyPressDoubleOnly(sender As Object, e As KeyPressEventArgs)
        Dim key As Char = e.KeyChar
        Dim decimalSeparator As String = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator
        Dim text As String = ""
        If TypeOf sender Is TextBox Then
            text = TryCast(sender, TextBox).Text
        Else
            Return
        End If
        If key.ToString() = decimalSeparator Then
            e.Handled = text.Contains(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)
        ElseIf (key >= "0"c AndAlso key <= "9"c) OrElse key = ChrW(Keys.Back) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Public Shared Sub KeyPressLowerCaseOnly(sender As Object, e As KeyPressEventArgs)
        Dim c As Char = e.KeyChar
        If c = ChrW(Keys.Back) OrElse (c >= "a"c AndAlso c <= "z"c) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Public Shared Sub KeyPressUpperCaseOnly(sender As Object, e As KeyPressEventArgs)
        Dim c As Char = e.KeyChar
        If c = ChrW(Keys.Back) OrElse (c >= "A"c AndAlso c <= "Z"c) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Public Shared Sub KeyPressAlphabetOnly(sender As Object, e As KeyPressEventArgs)
        Dim c As Char = e.KeyChar
        If c = ChrW(Keys.Back) OrElse (c >= "a"c AndAlso c <= "z"c) OrElse (c >= "A"c AndAlso c <= "Z"c) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

	Public Shared Sub ValidateCheckBlank(sender As Object, e As CancelEventArgs)
		Dim text As String = ""
		If TypeOf sender Is TextBox Then
			Dim tBox As TextBox = TryCast(sender, TextBox)
			text = tBox.Text
		Else
			Return
		End If
		If String.IsNullOrEmpty(text) Then
			MessageBox.Show("Cannot blank.")
			e.Cancel = True
		End If
	End Sub

	Public Shared Sub ValidatePositiveDouble(sender As Object, e As CancelEventArgs)
		Dim text As String = ""
		If TypeOf sender Is TextBox Then
			Dim tBox As TextBox = TryCast(sender, TextBox)
			text = tBox.Text
		Else
			Return
		End If
		If Convert.ToDouble(text) <= 0 Then
			MessageBox.Show("Must be more than 0.")
			e.Cancel = True
		End If
	End Sub

	Public Shared Sub ValidatePositiveInteger(sender As Object, e As CancelEventArgs)
		Dim text As String = ""
		If TypeOf sender Is TextBox Then
			Dim tBox As TextBox = TryCast(sender, TextBox)
			text = tBox.Text
		Else
			Return
		End If
		If Convert.ToInt32(text) <= 0 Then
			MessageBox.Show("Must be more than 0.")
			e.Cancel = True
		End If
	End Sub
End Class

Public NotInheritable Class ParallelExt
	Private Sub New()
	End Sub
	Public Shared Function ForRange(fromInclusive As Integer, toExclusive As Integer, body As Action(Of Integer, Integer)) As ParallelLoopResult
		Try
			Dim numberOfRanges As Integer = Environment.ProcessorCount
			Dim range As Integer = toExclusive - fromInclusive
			Dim stride As Integer = range \ numberOfRanges
			If range <= 0 Then
				numberOfRanges = 0
			End If
            Return Parallel.[For](0, numberOfRanges, Sub(i)
                                                         Dim start As Integer = i * stride + fromInclusive
                                                         Dim [end] As Integer = If((i = numberOfRanges - 1), toExclusive, start + stride)
                                                         body(start, [end])
                                                     End Sub)
		Finally
		End Try
	End Function
End Class
