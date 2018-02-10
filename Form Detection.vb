Imports System.Collections.Generic
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Public Partial Class FormDetection
	Inherits Form
	Private imageInfo As ImageInformation
	Public openerForm As FormUtama
    Private queueImage As Queue(Of Bitmap)

	Public Sub New()
		InitializeComponent()
        imageInfo = New ImageInformation()
        queueImage = New Queue(Of Bitmap)()
	End Sub

	Private Sub buttonLoad_Click(sender As Object, e As EventArgs)
		LoadDialog()
	End Sub

	Private Sub LoadDialog()
		If CommonMethod.LoadImage(openFileDialogLoad, imageInfo) Then
			pictureBoxInput.Image = imageInfo.picture
		End If
	End Sub

	Private Sub ClearForm()
		richTextBoxResult.Clear()
		imageInfo.Clear()
        CommonMethod.DisposePictureBoxImage(pictureBoxInput)
        queueImage.Clear()
	End Sub

    Private Sub FormDetection_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ClearForm()
        Me.openerForm.fDetection = Nothing
        Me.Dispose()
    End Sub

    Private Sub Detect()
        If queueImage.Count = 0 Then
            MessageBox.Show("Belum melakukan preview.")
            Return
        End If
        ToolStripProgressBar1.Maximum = queueImage.Count
        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Step = 1
        Dim sb As StringBuilder = New StringBuilder()
        Dim method As CrossoverMethod
        If toolStripComboBox1.SelectedIndex = 0 Then
            method = CrossoverMethod.OnePoint
        ElseIf toolStripComboBox1.SelectedIndex = 1 Then
            method = CrossoverMethod.TwoPoint
        Else
            method = CrossoverMethod.Uniform
        End If
        Dim dm As New DataModule()
        Dim allData As ResultData() = dm.GetAllData()
        Dim GA As New Genetic_Algorithm(allData, method)
        While queueImage.Count > 0
            Dim bm As Bitmap = queueImage.Dequeue()
            ToolStripProgressBar1.PerformStep()
            If bm Is Nothing Then
                sb.AppendLine()
            Else
                Dim pixels As Integer(,) = DIPFunction.GetGrayscale(bm)
                Dim scaled As Integer(,) = DIPFunction.Scale(pixels, 20, 30)
                Dim bit As Boolean() = DIPFunction.ConvertToChromosome2(scaled)
                Dim resultBit As String = GA.Run(bit, 100)
                sb.Append(resultBit)
            End If
        End While
        richTextBoxResult.Text = sb.ToString()
    End Sub

    Private Sub closeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles closeToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub clearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles clearToolStripMenuItem.Click
        ClearForm()
    End Sub

    Private Sub loadImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles loadImageToolStripMenuItem.Click
        LoadDialog()
    End Sub
	
    Sub DetectToolStripMenuItemClick(sender As Object, e As EventArgs) Handles detectToolStripMenuItem.Click
        Detect()
    End Sub

    Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewToolStripMenuItem.Click
        Preview()
    End Sub

    Private Sub Preview()
        If Not imageInfo.load Then
            MessageBox.Show("Belum memilih image.")
            Return
        End If        
        Dim threshold As Integer(,) = DIPFunction.Thresholding(imageInfo.pixelValue)
        richTextBoxResult.Clear()
        Dim sb As New StringBuilder()
        Dim oCropper As New Autocrop()
        Dim edgeLeft As Integer = 0
        Dim edgeRight As Integer = 0
        Dim edgeTop As Integer = 0
        Dim edgeBottom As Integer = 0
        Dim tempBlack As Integer = 0
        oCropper.FindBound(threshold, edgeLeft, edgeRight, edgeTop, edgeBottom, tempBlack)
        Dim edgeWidth As Integer = edgeRight - edgeLeft + 1
        Dim edgeHeight As Integer = edgeBottom - edgeTop + 1
        Dim readyToCrop As Integer(,) = oCropper.Crop(threshold, edgeLeft, edgeTop, edgeWidth, edgeHeight)

        Dim fPreview As FormPreview = New FormPreview()        
        'crop level 1
        Dim vHistogram As Integer() = oCropper.VerticalHistogram(readyToCrop)
        Dim lineRange As List(Of Point) = oCropper.FindLineRange(vHistogram, 1000, 3)
        Dim croppedArea As New List(Of Rectangle)()
        Dim counter As Integer = 1
        ToolStripProgressBar1.Maximum = (lineRange.Count - 1) * 7
        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Step = 1
        For i As Integer = 0 To lineRange.Count - 2
            Dim top As Integer = lineRange(i).Y + 5
            Dim bottom As Integer = lineRange(i + 1).X - 5
            Dim lineHeight As Integer = bottom - top + 1
            Dim croppedLineBrailleCell As Integer(,) = oCropper.Crop(readyToCrop, 0, top, edgeWidth, lineHeight)
            Dim horizontalHistogram As Integer() = oCropper.HorizontalHistogram(croppedLineBrailleCell)
            Dim cellRange As List(Of Point) = oCropper.FindColumnRange(horizontalHistogram, 135, 3)
            For j As Integer = 0 To cellRange.Count - 2
                Dim left As Integer = cellRange(j).Y + 5
                Dim right As Integer = cellRange(j + 1).X - 5
                Dim width As Integer = right - left + 1
                Dim cell As Integer(,) = oCropper.Crop(readyToCrop, left, top, width, lineHeight)

                Dim iBoundTop As Integer = 0
                Dim iBoundBottom As Integer = 0
                Dim iBoundLeft As Integer = 0
                Dim iBoundRight As Integer = 0
                Dim blackCount As Integer = 0
                oCropper.FindBound(cell, iBoundLeft, iBoundRight, iBoundTop, iBoundBottom, blackCount)
                If blackCount < 5 Then
                    Continue For
                End If
                Dim iBoundHeight As Integer = iBoundBottom - iBoundTop + 1
                Dim iBoundWidth As Integer = iBoundRight - iBoundLeft + 1
                Dim thresholdCrop As Integer(,) = oCropper.Crop(cell, iBoundLeft, iBoundTop, iBoundWidth, iBoundHeight)
                Dim bm As Bitmap = New Bitmap(DIPFunction.CreateImage(thresholdCrop))
                'bm.Save("E:\Crop\" & DateTime.Now.Ticks & ".bmp", Imaging.ImageFormat.Bmp)
                queueImage.Enqueue(bm)
                fPreview.CreateTab(counter.ToString(), bm)
                ToolStripProgressBar1.PerformStep()
                counter += 1
            Next
            queueImage.Enqueue(Nothing)
        Next
        fPreview.Show()
    End Sub
End Class
