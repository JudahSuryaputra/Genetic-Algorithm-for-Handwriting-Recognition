Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms

Partial Public Class FormUtama
    Inherits Form
    Public fAbout As FormAbout
    Public fDatabase As FormDatabase
    Public fInput As FormInput
    Public fDetection As FormDetection

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub inputImageToolStripMenuItem_Click(sender As Object, e As EventArgs)
        OpenFormInput(True)
    End Sub

    Private Sub OpenFormInput(entryMode As Boolean)
        If fInput Is Nothing Then
            fInput = New FormInput()
            fInput.openerForm = Me
            fInput.Show()
        End If
    End Sub

    Private Sub databaseImageToolStripMenuItem_Click(sender As Object, e As EventArgs)
        OpenFormDatabase()
    End Sub

    Private Sub OpenFormDatabase()
        If fDatabase Is Nothing Then
            fDatabase = New FormDatabase()
            fDatabase.openerForm = Me
            fDatabase.Show()
        End If
    End Sub

    Private Sub aboutToolStripMenuItem_Click(sender As Object, e As EventArgs)
        OpenFormAbout()
    End Sub

    Private Sub OpenFormAbout()
        If fAbout Is Nothing Then
            fAbout = New FormAbout()
            fAbout.openerForm = Me
            fAbout.Show()
        End If
    End Sub

    Private Sub exitToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub FormUtama_Load(sender As Object, e As EventArgs)
        CommonMethod.LoadPictureBoxImage(Me.pictureBoxCover, Application.StartupPath & "\cover.jpg")
    End Sub

    Private Sub helpToolStripMenuItem_Click(sender As Object, e As EventArgs)
        OpenHelp()
    End Sub

    Private Sub OpenHelp()
        'Dim FilePath As String = Application.StartupPath & "\User Manual.pdf"
        Dim FilePath As String = Path.GetDirectoryName(Application.StartupPath & "\help.pdf")
        'Dim FilePath As String = "E:\help.pdf"
        System.Diagnostics.Process.Start(FilePath + "\help.pdf")
        'If My.Computer.FileSystem.FileExists(FilePath) Then
        '    Try
        '        Process.Start("AcroRd32", FilePath)
        '    Catch ex As Exception
        '    End Try
        'Else
        'MsgBox("File not found.")
        'End If
        'Dim helpFile As String = Application.StartupPath & "\help.chm"
        'If File.Exists(helpFile) Then
        '	Help.ShowHelp(Me, helpFile)
        'End If
    End Sub

    Private Sub FormUtama_FormClosed(sender As Object, e As FormClosedEventArgs)
        CommonMethod.DisposePictureBoxImage(pictureBoxCover)
        Me.Dispose()
    End Sub

    Private Sub detectionToolStripMenuItem_Click(sender As Object, e As EventArgs)
        OpenFormDetection()
    End Sub

    Private Sub OpenFormDetection()
        If fDetection Is Nothing Then
            fDetection = New FormDetection()
            fDetection.openerForm = Me
            fDetection.Show()
        End If
    End Sub
End Class
