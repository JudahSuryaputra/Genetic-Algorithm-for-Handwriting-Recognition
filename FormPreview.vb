Imports System.Collections.Generic
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Public Class FormPreview
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub CreateTab(x As String, bmp As Bitmap)
        Dim oTab As New TabPage()
        Dim picBox As New PictureBox()
        picBox.Width = 200
        picBox.Height = 200
        picBox.Left = 0
        picBox.Top = 0
        picBox.Image = bmp
        oTab.Controls.Add(picBox)
        TabControl1.TabPages.Add(oTab)
    End Sub
End Class