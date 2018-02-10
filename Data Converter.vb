Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging

Public NotInheritable Class DataConverter
	Private Sub New()
	End Sub
	Public Shared Function ConvertToByteArray(bmp As Bitmap) As Byte()
		Dim ms As New MemoryStream()
		bmp.Save(ms, ImageFormat.Bmp)
		Dim result As Byte() = ms.ToArray()
		ms.Dispose()
		Return result
	End Function

	Public Shared Function ConvertToBitmap(byteArray As Byte()) As Bitmap
		Dim ms As New MemoryStream(byteArray)
		Dim bmp As New Bitmap(ms)
		ms.Dispose()
		Return bmp
	End Function

	Public Shared Function CreateCSV(list As Double(,)) As String
		Dim feature As String = ""
		Dim width As Integer = list.GetLength(0)
		Dim height As Integer = list.GetLength(1)
		Dim stringArr As String() = New String(height - 1) {}
		Dim temp As String() = New String(width - 1) {}
		For j As Integer = 0 To height - 1
			For i As Integer = 0 To width - 1
				temp(i) = list(i, j).ToString("F14")
			Next
			stringArr(j) = String.Join(";", temp)
		Next
		feature = String.Join("|", stringArr)
		Return feature
	End Function

	Public Shared Function CreateCSV(list As Integer(,)) As String
		Dim feature As String = ""
		Dim width As Integer = list.GetLength(0)
		Dim height As Integer = list.GetLength(1)
		Dim stringArr As String() = New String(height - 1) {}
		Dim temp As String() = New String(width - 1) {}
		For j As Integer = 0 To height - 1
			For i As Integer = 0 To width - 1
				temp(i) = list(i, j).ToString()
			Next
			stringArr(j) = String.Join(";", temp)
		Next
		feature = String.Join("|", stringArr)
		Return feature
	End Function

	Public Shared Function CreateCSV(list As Double()) As String
		Dim feature As String = ""
		Dim stringArr As String() = New String(list.Length - 1) {}
		For i As Integer = 0 To list.Length - 1
			stringArr(i) = list(i).ToString("F14")
		Next
		feature = String.Join(";", stringArr)
		Return feature
	End Function

	Public Shared Function CreateCSV(list As Integer()) As String
		Dim feature As String = ""
		Dim stringArr As String() = New String(list.Length - 1) {}
		For i As Integer = 0 To list.Length - 1
			stringArr(i) = list(i).ToString()
		Next
		feature = String.Join(";", stringArr)
		Return feature
	End Function

	Public Shared Function SplitDoubleCSV(byteArray As Byte()) As Double()
		Dim encoder As New UnicodeEncoding()
		Dim line As String = encoder.GetString(byteArray)
		Dim csv As String() = line.Split(";"C)
		Dim result As Double() = New Double(csv.Length - 1) {}
		For i As Integer = 0 To csv.Length - 1
			result(i) = Double.Parse(csv(i))
		Next
		Return result
	End Function

	Public Shared Function SplitDoubleCSV(line As String) As Double()
		Dim csv As String() = line.Split(";"C)
		Dim result As Double() = New Double(csv.Length - 1) {}
		For i As Integer = 0 To csv.Length - 1
			result(i) = Double.Parse(csv(i))
		Next
		Return result
	End Function

	Public Shared Function SplitDoubleCSV2(byteArray As Byte()) As Double(,)
		Dim encoder As New UnicodeEncoding()
		Dim line As String = encoder.GetString(byteArray)
		Dim csvLine As String() = line.Split("|"C)
		Dim height As Integer = csvLine.Length
		Dim width As Integer = csvLine(0).Split(";"C).Length
		Dim result As Double(,) = New Double(width - 1, height - 1) {}
		For j As Integer = 0 To height - 1
			Dim csv As String() = csvLine(j).Split(";"C)
			For i As Integer = 0 To width - 1
				result(i, j) = Double.Parse(csv(i))
			Next
		Next
		Return result
	End Function

	Public Shared Function SplitDoubleCSV2(line As String) As Double(,)
		Dim csvLine As String() = line.Split("|"C)
		Dim height As Integer = csvLine.Length
		Dim width As Integer = csvLine(0).Split(";"C).Length
		Dim result As Double(,) = New Double(width - 1, height - 1) {}
		For j As Integer = 0 To height - 1
			Dim csv As String() = csvLine(j).Split(";"C)
			For i As Integer = 0 To width - 1
				result(i, j) = Double.Parse(csv(i))
			Next
		Next
		Return result
	End Function

	Public Shared Function SplitIntegerCSV(byteArray As Byte()) As Integer()
		Dim encoder As New UnicodeEncoding()
		Dim line As String = encoder.GetString(byteArray)
		Dim csv As String() = line.Split(";"C)
		Dim result As Integer() = New Integer(csv.Length - 1) {}
		For i As Integer = 0 To csv.Length - 1
			result(i) = Integer.Parse(csv(i))
		Next
		Return result
	End Function

	Public Shared Function SplitIntegerCSV(line As String) As Integer()
		Dim csv As String() = line.Split(";"C)
		Dim result As Integer() = New Integer(csv.Length - 1) {}
		For i As Integer = 0 To csv.Length - 1
			result(i) = Integer.Parse(csv(i))
		Next
		Return result
	End Function

	Public Shared Function SplitIntegerCSV2(byteArray As Byte()) As Integer(,)
		Dim encoder As New UnicodeEncoding()
		Dim line As String = encoder.GetString(byteArray)
		Dim csvLine As String() = line.Split("|"C)
		Dim height As Integer = csvLine.Length
		Dim width As Integer = csvLine(0).Split(";"C).Length
		Dim result As Integer(,) = New Integer(width - 1, height - 1) {}
		For j As Integer = 0 To height - 1
			Dim csv As String() = csvLine(j).Split(";"C)
			For i As Integer = 0 To width - 1
				result(i, j) = Integer.Parse(csv(i))
			Next
		Next
		Return result
	End Function

	Public Shared Function SplitIntegerCSV2(line As String) As Integer(,)
		Dim csvLine As String() = line.Split("|"C)
		Dim height As Integer = csvLine.Length
		Dim width As Integer = csvLine(0).Split(";"C).Length
		Dim result As Integer(,) = New Integer(width - 1, height - 1) {}
		For j As Integer = 0 To height - 1
			Dim csv As String() = csvLine(j).Split(";"C)
			For i As Integer = 0 To width - 1
				result(i, j) = Integer.Parse(csv(i))
			Next
		Next
		Return result
	End Function
End Class
