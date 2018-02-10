Imports System.Collections.Specialized
Imports System.Configuration
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

Public Class DIPFunction
	Public Shared Function CheckImageSize(height As Integer, width As Integer, ByRef message As String) As Boolean
		message = ""
		Dim result As Boolean = True
		Dim appSettings As NameValueCollection = ConfigurationManager.AppSettings
		Try
			Dim minHeight As Integer = Integer.Parse(appSettings("minHeight"))
			Dim minWidth As Integer = Integer.Parse(appSettings("minWidth"))
			Dim maxHeight As Integer = Integer.Parse(appSettings("maxHeight"))
			Dim maxWidth As Integer = Integer.Parse(appSettings("maxWidth"))
			If (height < minHeight) OrElse (height > maxHeight) Then
				result = False
				message += "Tinggi gambar minimal " & minHeight.ToString() & " dan maksimal " & maxHeight.ToString() & ". "
			End If
			If (width < minWidth) OrElse (width > maxWidth) Then
				result = False
				message += "Lebar gambar minimal " & minWidth.ToString() & " dan maksimal " & maxWidth.ToString() & ". "
			End If
		Catch ex As Exception
			result = False
			message = ex.Message
		End Try
		Return result
	End Function

	Public Shared Function CreateImage(source As Color(,)) As Bitmap
		Dim width As Integer = source.GetLength(0)
		Dim height As Integer = source.GetLength(1)
		Dim bmp As New Bitmap(width, height)
		Dim bitmapData As BitmapData = bmp.LockBits(New Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.[WriteOnly], PixelFormat.Format24bppRgb)
		Dim bytes As Byte() = New Byte(bitmapData.Stride * height - 1) {}
		For j As Integer = 0 To height - 1
			Dim x As Integer = j * bitmapData.Stride
			For i As Integer = 0 To width - 1
				bytes(x) = source(i, j).B
				bytes(x + 1) = source(i, j).G
				bytes(x + 2) = source(i, j).R
				x += 3
			Next
		Next
		Marshal.Copy(bytes, 0, bitmapData.Scan0, bytes.Length)
		bmp.UnlockBits(bitmapData)
		Return bmp
	End Function

	Public Shared Function CreateImage(source As Integer(,)) As Bitmap
		Dim width As Integer = source.GetLength(0)
		Dim height As Integer = source.GetLength(1)
		Dim bmp As New Bitmap(width, height)
		Dim bitmapData As BitmapData = bmp.LockBits(New Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.[WriteOnly], PixelFormat.Format24bppRgb)
		Dim bytes As Byte() = New Byte(bitmapData.Stride * height - 1) {}
		For j As Integer = 0 To height - 1
			Dim x As Integer = j * bitmapData.Stride
			For i As Integer = 0 To width - 1
				bytes(x) = Convert.ToByte(source(i, j))
				bytes(x + 1) = Convert.ToByte(source(i, j))
				bytes(x + 2) = Convert.ToByte(source(i, j))
				x += 3
			Next
		Next
		Marshal.Copy(bytes, 0, bitmapData.Scan0, bytes.Length)
		bmp.UnlockBits(bitmapData)
		Return bmp
	End Function

	Public Shared Function GetColor(bmp As Bitmap) As Color(,)
		Dim width As Integer = bmp.Width
		Dim height As Integer = bmp.Height
		Dim result As Color(,) = New Color(width - 1, height - 1) {}
		Dim bitmapData As BitmapData = bmp.LockBits(New Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.[ReadOnly], PixelFormat.Format24bppRgb)
		Dim byteCount As Integer = bitmapData.Stride * bmp.Height
		Dim bitmapBytes As Byte() = New Byte(byteCount - 1) {}
		Marshal.Copy(bitmapData.Scan0, bitmapBytes, 0, byteCount)
		For j As Integer = 0 To height - 1
			Dim s As Integer = j * bitmapData.Stride
			For i As Integer = 0 To width - 1
				Dim b As Integer = bitmapBytes(s)
				Dim g As Integer = bitmapBytes(s + 1)
				Dim r As Integer = bitmapBytes(s + 2)
				s += 3
				result(i, j) = Color.FromArgb(r, g, b)
			Next
		Next
		bmp.UnlockBits(bitmapData)
		Return result
	End Function

	Public Shared Function GetColor(image As Image) As Color(,)
		Return GetColor(DirectCast(image, Bitmap))
	End Function

	Public Shared Function GetGrayscale(bmp As Bitmap) As Integer(,)
		Dim width As Integer = bmp.Width
		Dim height As Integer = bmp.Height
		Dim result As Integer(,) = New Integer(width - 1, height - 1) {}
		Dim bitmapData As BitmapData = bmp.LockBits(New Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.[ReadOnly], PixelFormat.Format24bppRgb)
		Dim stride As Integer = bitmapData.Stride
		Dim byteCount As Integer = bitmapData.Stride * bmp.Height
		Dim bitmapBytes As Byte() = New Byte(byteCount - 1) {}
		Marshal.Copy(bitmapData.Scan0, bitmapBytes, 0, byteCount)
		For j As Integer = 0 To height - 1
			Dim s As Integer = j * bitmapData.Stride
			For i As Integer = 0 To width - 1
				Dim b As Integer = bitmapBytes(s)
				Dim g As Integer = bitmapBytes(s + 1)
				Dim r As Integer = bitmapBytes(s + 2)
				s += 3
				result(i, j) = (r + g + b) \ 3
			Next
		Next
		bmp.UnlockBits(bitmapData)
		Return result
	End Function

	Public Shared Function GetGrayscale(image As Image) As Integer(,)
		Return GetGrayscale(DirectCast(image, Bitmap))
	End Function

	Public Shared Function GetGrayscale(color As Color(,)) As Integer(,)
		Dim width As Integer = color.GetLength(0)
		Dim height As Integer = color.GetLength(1)
		Dim result As Integer(,) = New Integer(width - 1, height - 1) {}
		For i As Integer = 0 To width - 1
			For j As Integer = 0 To height - 1
				'result[i, j] = 0.3 * color[i, j].R + 0.59 * color[i, j].G + 0.11 * color[i, j].B;
				result(i, j) = (color(i, j).R + color(i, j).G + color(i, j).B) \ 3
			Next
		Next
		Return result
	End Function

	Public Shared Function Thresholding(source As Integer(,)) As Integer(,)
		Dim width As Integer = source.GetLength(0)
		Dim height As Integer = source.GetLength(1)
		Dim min As Double = source(0, 0)
		Dim max As Double = source(0, 0)
		For i As Integer = 0 To width - 1
			For j As Integer = 0 To height - 1
				Dim pix As Double = source(i, j)
				If pix < min Then
					min = pix
				End If
				If pix > max Then
					max = pix
				End If
			Next
		Next
		Dim t As Double = (min + max) / 2
		Dim result As Integer(,) = New Integer(width - 1, height - 1) {}
		For i As Integer = 0 To width - 1
			For j As Integer = 0 To height - 1
				result(i, j) = If(source(i, j) >= t, 255, 0)
			Next
		Next
		Return result
	End Function

	Public Shared Function Scale(source As Integer(,), newWidth As Integer, newHeight As Integer) As Integer(,)
		Dim width As Integer = source.GetLength(0)
		Dim height As Integer = source.GetLength(1)
		Dim result As Integer(,) = New Integer(newWidth - 1, newHeight - 1) {}
		Dim scaleWidth As Double = CDbl(width) / newWidth
		Dim scaleHeight As Double = CDbl(height) / newHeight
		For i As Integer = 0 To newWidth - 1
			Dim x As Integer = CInt(Math.Truncate(i * scaleWidth))
			For j As Integer = 0 To newHeight - 1
				Dim y As Integer = CInt(Math.Truncate(j * scaleHeight))
				result(i, j) = source(x, y)
			Next
		Next
		Return result
	End Function

	Public Shared Function ConvertToChromosome(source As Integer(,)) As String
		Dim width As Integer = source.GetLength(0)
		Dim height As Integer = source.GetLength(1)
		Dim charArray As Char() = New Char(width * height - 1) {}
		Dim x As Integer = 0
		For i As Integer = 0 To width - 1
			For j As Integer = 0 To height - 1
				charArray(x) = If(source(i, j) = 0, "0"C, "1"C)
				x += 1
			Next
		Next
		Return New String(charArray)
	End Function

	Public Shared Function ConvertToChromosome2(source As Integer(,)) As Boolean()
		Dim width As Integer = source.GetLength(0)
		Dim height As Integer = source.GetLength(1)
		Dim bit As Boolean() = New Boolean(width * height - 1) {}
		Dim x As Integer = 0
		For i As Integer = 0 To width - 1
			For j As Integer = 0 To height - 1
                bit(x) = If(source(i, j) = 0, False, True)
                x += 1
			Next
		Next
		Return bit
	End Function

	Public Shared Function Scale(imgPhoto As Bitmap, Width As Integer, Height As Integer) As Bitmap
		Dim sourceWidth As Integer = imgPhoto.Width
		Dim sourceHeight As Integer = imgPhoto.Height
		If sourceWidth = Width AndAlso sourceHeight = Height Then
			Return imgPhoto
		End If
		Dim sourceX As Integer = 0
		Dim sourceY As Integer = 0
		Dim destX As Integer = 0
		Dim destY As Integer = 0
		Dim destWidth As Integer = Width
		Dim destHeight As Integer = Height

		Dim bmPhoto As New Bitmap(Width, Height, PixelFormat.Format24bppRgb)
		bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution)

		Dim grPhoto As Graphics = Graphics.FromImage(bmPhoto)
		grPhoto.Clear(Color.Black)
		grPhoto.InterpolationMode = InterpolationMode.NearestNeighbor

		grPhoto.DrawImage(imgPhoto, New Rectangle(destX, destY, destWidth, destHeight), New Rectangle(sourceX, sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel)

		grPhoto.Dispose()
		Return bmPhoto
	End Function
End Class

Public NotInheritable Class ImageCommonFunction
	Private Sub New()
	End Sub
	Public Shared Function CropImage(source As Bitmap, rect As Rectangle) As Bitmap
		Dim cropped As Bitmap = source.Clone(rect, source.PixelFormat)
		Return cropped
	End Function
End Class
