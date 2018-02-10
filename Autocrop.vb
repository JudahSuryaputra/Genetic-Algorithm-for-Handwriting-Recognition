Imports System.Collections.Generic
Imports System.Drawing

Public Class Autocrop
	Public Sub New()
	End Sub

	Public Function VerticalHistogram(source As Integer(,)) As Integer()
		Dim width As Integer = source.GetLength(0)
		Dim height As Integer = source.GetLength(1)
		Dim result As Integer() = New Integer(height - 1) {}
		For j As Integer = 0 To height - 1
			Dim temp As Integer = 0
			For i As Integer = 0 To width - 1
				If source(i, j) = 0 Then
					temp += 1
				End If
			Next
			result(j) = temp
		Next
		Return result
	End Function

	Public Function HorizontalHistogram(source As Integer(,)) As Integer()
		Dim width As Integer = source.GetLength(0)
		Dim height As Integer = source.GetLength(1)
		Dim result As Integer() = New Integer(width - 1) {}
		For i As Integer = 0 To width - 1
			Dim temp As Integer = 0
			For j As Integer = 0 To height - 1
				If source(i, j) = 0 Then
					temp += 1
				End If
			Next
			result(i) = temp
		Next
		Return result
	End Function

	Public Function FindLineRange(vertical As Integer(), minimumPixelForLine As Integer, toleranceBlankLine As Integer) As List(Of Point)
		Dim first As Integer = -1
		Dim blankLine As Integer = 0
		Dim last As Integer = -1
		Dim lineRange As New List(Of Point)()
		Dim firstFind As Boolean = False
		For i As Integer = 0 To vertical.Length - 1
			If vertical(i) <= minimumPixelForLine Then
				blankLine += 1
				If blankLine >= toleranceBlankLine AndAlso firstFind Then
					lineRange.Add(New Point(first, last))
					firstFind = False
					blankLine = 0
				End If
			Else
				If Not firstFind Then
					first = i
					firstFind = True
				End If
				blankLine = 0
				last = i
			End If
		Next
		If firstFind Then
			lineRange.Add(New Point(first, last))
		End If
		Return lineRange
	End Function

	Public Function FindColumnRange(horizontal As Integer(), minimumPixelForColumn As Integer, toleranceBlankColumn As Integer) As List(Of Point)
		Dim first As Integer = -1
		Dim blankColumn As Integer = 0
		Dim last As Integer = -1
		Dim characterRange As New List(Of Point)()
		Dim firstFind As Boolean = False
		Dim charFound As Integer = 0
		For i As Integer = 0 To horizontal.Length - 1
			If horizontal(i) <= minimumPixelForColumn Then
				blankColumn += 1
				If blankColumn >= toleranceBlankColumn AndAlso firstFind Then
					characterRange.Add(New Point(first, last))
					charFound += 1
					firstFind = False
					blankColumn = 0
				End If
			Else
				If Not firstFind Then
					first = i
					firstFind = True
				End If
				blankColumn = 0
				last = i
			End If
		Next
		If firstFind Then
			characterRange.Add(New Point(first, last))
		End If
		Return characterRange
	End Function

	Public Function Crop(source As Integer(,), x As Integer, y As Integer, cropWidth As Integer, cropHeight As Integer) As Integer(,)
		Dim width As Integer = source.GetLength(0)
		Dim height As Integer = source.GetLength(1)
		Dim cropped As Integer(,) = New Integer(cropWidth - 1, cropHeight - 1) {}
		Dim finishX As Integer = x + cropWidth
		Dim finishY As Integer = y + cropHeight
		For i As Integer = x To finishX - 1
			For j As Integer = y To finishY - 1
				cropped(i - x, j - y) = source(i, j)
			Next
		Next
		Return cropped
	End Function

	Public Sub FindHorizontalBound(source As Integer(,), ByRef left As Integer, ByRef right As Integer)
		Dim width As Integer = source.GetLength(0)
		Dim height As Integer = source.GetLength(1)
		left = width - 1
		right = 0
		For j As Integer = 0 To height - 1
			For i As Integer = 0 To width - 1
				If source(i, j) = 0 Then
					If i < left Then
						left = i
					End If
					If i > right Then
						right = i
					End If
				End If
			Next
		Next
		If left > right Then
			Dim temp As Integer = right
			right = left
			left = temp
		End If
	End Sub

	Public Sub FindVerticalBound(source As Integer(,), ByRef top As Integer, ByRef bottom As Integer)
		Dim width As Integer = source.GetLength(0)
		Dim height As Integer = source.GetLength(1)
		top = height - 1
		bottom = 0
		For i As Integer = 0 To width - 1
			For j As Integer = 0 To height - 1
				If source(i, j) = 0 Then
					If j < top Then
						top = j
					End If
					If j > bottom Then
						bottom = j
					End If
				End If
			Next
		Next
		If top > bottom Then
			Dim temp As Integer = bottom
			bottom = top
			top = temp
		End If
	End Sub

	Public Sub FindBound(source As Integer(,), ByRef left As Integer, ByRef right As Integer, ByRef top As Integer, ByRef bottom As Integer, ByRef blackCount As Integer)
		Dim width As Integer = source.GetLength(0)
		Dim height As Integer = source.GetLength(1)
		left = width - 1
		right = 0
		top = height - 1
		bottom = 0
		blackCount = 0
		For j As Integer = 0 To height - 1
			For i As Integer = 0 To width - 1
				If source(i, j) = 0 Then
					blackCount += 1
					If i < left Then
						left = i
					End If
					If i > right Then
						right = i
					End If
					If j < top Then
						top = j
					End If
					If j > bottom Then
						bottom = j
					End If
				End If
			Next
		Next
		If left > right Then
			Dim temp As Integer = right
			right = left
			left = temp
		End If
		If top > bottom Then
			Dim temp As Integer = bottom
			bottom = top
			top = temp
		End If
	End Sub
End Class
