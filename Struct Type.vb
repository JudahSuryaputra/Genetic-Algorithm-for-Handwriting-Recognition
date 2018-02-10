Imports System.Collections.Generic
Imports System.Drawing
Imports System.IO
Imports System.Drawing.Imaging
Imports System.Linq
Imports System.Runtime.Serialization.Formatters.Binary

Public Enum CrossoverMethod
	OnePoint
	TwoPoint
	Uniform
End Enum

Public Class ImageInformation
	Implements IDisposable
	Public width As Integer
	Public height As Integer
	Public load As Boolean
	Public pixelValue As Integer(,)
	Public streamPicture As MemoryStream

	Public band As Byte

	Public Sub New()
		Me.load = False
	End Sub

	Public Sub New(bmp As Bitmap)
		Me.load = True
		Me.width = bmp.Width
		Me.height = bmp.Height
		Me.picture = bmp
		Me.pixelValue = DIPFunction.GetGrayscale(bmp)
	End Sub

	Public Sub New(band As Byte)
		Me.band = band
		Me.load = False
	End Sub

	Public Property picture() As Bitmap
		Get
			If streamPicture Is Nothing Then
				Return Nothing
			Else
				Return New Bitmap(streamPicture)
			End If
		End Get
		Set
			If streamPicture IsNot Nothing Then
				streamPicture.Dispose()
			End If
			streamPicture = New MemoryStream()
			Try
				value.Save(streamPicture, value.RawFormat)
			Catch
				value.Save(streamPicture, ImageFormat.Bmp)
			End Try
		End Set
	End Property

	Public Sub SetValue(width As Integer, height As Integer, pixel As Integer(,), stream As MemoryStream)
		Me.width = width
		Me.height = height
		Me.pixelValue = pixel
		Me.streamPicture = stream
		Me.load = True
	End Sub

	Public Sub SetValue(bmp As Bitmap)
		Me.width = bmp.Width
		Me.height = bmp.Height
		Me.picture = bmp
		Me.pixelValue = DIPFunction.GetGrayscale(bmp)
		Me.load = True
	End Sub

	Public Sub Clear()
		width = 0
		height = 0
		load = False
		pixelValue = Nothing
		If Me.streamPicture IsNot Nothing Then
			Me.streamPicture.Dispose()
		End If
	End Sub

	Public Overrides Function ToString() As String
		Return "B" & band.ToString() & " : " & (If(load, "Load", "Unload"))
	End Function

	#Region "IDisposable Members"

	Public Sub Dispose() Implements IDisposable.Dispose
		If Me.streamPicture IsNot Nothing Then
			Me.streamPicture.Dispose()
		End If
	End Sub

	#End Region
End Class

Public Class ResultData
	Implements IComparable
	Public imageName As String
	Public oBitmap As Bitmap
	Public character As String
	Public chromosomeBit As String
	Public distance As Double
	Public chromosome As Boolean()

	Public Sub New()
		Me.imageName = ""
		Me.oBitmap = Nothing
		Me.distance = 0
	End Sub

	Public Sub New(imageName As String, bmp As Bitmap, character As String, chromosomeBit As String)
		Me.imageName = imageName
		Me.character = character
		Me.oBitmap = bmp
        Me.distance = 0
        Me.chromosomeBit = chromosomeBit
		Me.chromosome = New Boolean(chromosomeBit.Length - 1) {}
		For i As Integer = 0 To chromosomeBit.Length - 1
			Me.chromosome(i) = If(chromosomeBit(i) = "0"C, False, True)
		Next
	End Sub

	Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
		Dim other As ResultData = DirectCast(obj, ResultData)
		If Me.distance > other.distance Then
			Return 1
		ElseIf Me.distance < other.distance Then
			Return -1
		Else
			Return 0
		End If
	End Function
End Class
