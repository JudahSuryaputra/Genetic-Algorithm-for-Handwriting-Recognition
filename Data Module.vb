Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlServerCe
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DbWrapper = GeneticAlgorithm.SqlCeWrapper

Class DataModule
	Implements IDisposable
	Private databaseName As String = ConfigurationManager.AppSettings("dbName")
	Private con As SqlCeConnection

	Public Sub New()
		Dim constring As String = "Data Source=" & Application.StartupPath & "\" & databaseName & ";Max Database Size=4000;Persist Security Info=False"
		con = New SqlCeConnection(constring)
	End Sub

	Public Sub New(connectionString As String)
		con = New SqlCeConnection(connectionString)
	End Sub

	Public Function AddData(trainingName As String, bmp As Bitmap, character As String, chromosomeBit As String) As Boolean
		Try
			Dim sb As New StringBuilder()
			sb.Append("Insert INTO tblImage Values(")
			sb.Append("@trainingName, @bitmap, @character, @bit")
			sb.Append(")")
			Dim sqlText As String = sb.ToString()
			Dim paramList As New Dictionary(Of String, Object)()
			paramList.Add("@trainingName", trainingName)
			paramList.Add("@bitmap", DataConverter.ConvertToByteArray(bmp))
			paramList.Add("@character", character)
			paramList.Add("@bit", chromosomeBit)
			Dim affected As Integer = DbWrapper.ExecuteNonQuery(con, CommandType.Text, sqlText, paramList)
			Return affected > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DeleteData(trainingName As String) As Boolean
		Try
			Dim sqlText As String = "DELETE FROM tblImage WHERE TrainingName = @trainingName"
			Dim paramList As New Dictionary(Of String, Object)()
			paramList.Add("@trainingName", trainingName)
			Dim affected As Integer = DbWrapper.ExecuteNonQuery(con, CommandType.Text, sqlText, paramList)
			Return affected > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function EmptyData() As Boolean
		Try
			Dim sqlText As String = "SELECT Count(*) FROM tblImage"
			Dim row As Integer = CInt(DbWrapper.ExecuteScalar(con, CommandType.Text, sqlText))
			Return (row <= 0)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function GetAllData() As ResultData()
		Dim result As ResultData() = Nothing
		Try
			Dim sqlText As String = "Select * FROM tblImage"
			Dim dt As DataTable = DbWrapper.GetDataTable(con, CommandType.Text, sqlText)
			Dim rowCount As Integer = dt.Rows.Count
			Dim listResult As New List(Of ResultData)(rowCount)
			result = New ResultData(rowCount - 1) {}
			For Each row As DataRow In dt.Rows
				listResult.Add(ProcessDataRow(row))
			Next
			listResult.CopyTo(result)
		Catch ex As Exception
			Throw ex
		End Try
		Return result
	End Function

	Public Function GetSingleData(trainingName As String) As ResultData
		Dim result As New ResultData()
		Try
			Dim sqlText As String = "Select * FROM tblImage WHERE TrainingName = @trainingName"
			Dim paramList As New Dictionary(Of String, Object)()
			paramList.Add("@trainingName", trainingName)
			Dim dt As DataTable = DbWrapper.GetDataTable(con, CommandType.Text, sqlText, paramList)
			Dim dr As DataRow = dt.Rows(0)
			result = ProcessDataRow(dr)
		Catch ex As Exception
			Throw ex
		End Try
		Return result
	End Function

	Public Function GetAllImageID() As String()
		Dim result As String() = Nothing
		Try
			Dim sqlText As String = "Select TrainingName from tblImage"
			Dim dt As DataTable = DbWrapper.GetDataTable(con, CommandType.Text, sqlText)
			Dim iData As Integer = dt.Rows.Count
			result = New String(iData - 1) {}
			For i As Integer = 0 To iData - 1
				result(i) = dt.Rows(i)(0).ToString()
			Next
		Catch ex As Exception
			Throw ex
		End Try
		Return result
	End Function

	Private Function ProcessDataRow(dr As DataRow) As ResultData
		Dim name As String = dr("TrainingName").ToString()
		Dim oArray As Byte() = DirectCast(dr("Bitmap"), Byte())
		Dim bmp As Bitmap = DataConverter.ConvertToBitmap(oArray)
		Dim character As String = dr("Character").ToString()
		Dim chromosomeBit As String = dr("ChromosomeBit").ToString()

		Return New ResultData(name, bmp, character, chromosomeBit)
	End Function

	Public Sub Dispose() Implements IDisposable.Dispose
		If Me.con IsNot Nothing Then
			If Me.con.State <> ConnectionState.Closed Then
				Me.con.Close()
			End If
			Me.con.Dispose()
			Me.con = Nothing
		End If
	End Sub
End Class
