Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlServerCe
Imports System.Windows.Forms

NotInheritable Class SqlCeWrapper
	Private Sub New()
	End Sub
	Public Shared Function ExecuteNonQuery(connection As SqlCeConnection, commandType As CommandType, commandText As String) As Integer
		Dim command As SqlCeCommand = CreateCommand(connection, commandType, commandText)
		Try
			connection.Open()
			Return command.ExecuteNonQuery()
		Catch ex As Exception
			MessageBox.Show(ex.Message)
			Return -1
		Finally
			connection.Close()
			command.Dispose()
		End Try
	End Function

	Public Shared Function ExecuteNonQuery(connection As SqlCeConnection, commandType As CommandType, commandText As String, parameterList As Dictionary(Of String, Object)) As Integer
		Dim command As SqlCeCommand = CreateCommand(connection, commandType, commandText)
		AddParameter(command, parameterList)
		Try
			connection.Open()
			Return command.ExecuteNonQuery()
		Catch ex As Exception
			MessageBox.Show(ex.Message)
			Return -1
		Finally
			connection.Close()
			command.Dispose()
		End Try
	End Function

	Public Shared Function ExecuteScalar(connection As SqlCeConnection, commandType As CommandType, commandText As String) As Object
		Dim command As SqlCeCommand = CreateCommand(connection, commandType, commandText)
		Try
			connection.Open()
			Return command.ExecuteScalar()
		Catch ex As Exception
			MessageBox.Show(ex.Message)
			Return Nothing
		Finally
			connection.Close()
			command.Dispose()
		End Try
	End Function

	Public Shared Function ExecuteScalar(connection As SqlCeConnection, commandType As CommandType, commandText As String, parameterList As Dictionary(Of String, Object)) As Object
		Dim command As SqlCeCommand = CreateCommand(connection, commandType, commandText)
		AddParameter(command, parameterList)
		Try
			connection.Open()
			Return command.ExecuteScalar()
		Catch ex As Exception
			MessageBox.Show(ex.Message)
			Return Nothing
		Finally
			connection.Close()
			command.Dispose()
		End Try
	End Function

	Public Shared Function GetDataTable(connection As SqlCeConnection, commandType As CommandType, commandText As String) As DataTable
		Dim command As SqlCeCommand = CreateCommand(connection, commandType, commandText)
		Dim adapter As New SqlCeDataAdapter(command)
		Dim table As New DataTable()
		Try
			adapter.Fill(table)
			Return table
		Catch ex As Exception
			MessageBox.Show(ex.Message)
			Return Nothing
		Finally
			adapter.Dispose()
			command.Dispose()
		End Try
	End Function

	Public Shared Function GetDataTable(connection As SqlCeConnection, commandType As CommandType, commandText As String, parameterList As Dictionary(Of String, Object)) As DataTable
		Dim command As SqlCeCommand = CreateCommand(connection, commandType, commandText)
		AddParameter(command, parameterList)
		Dim adapter As New SqlCeDataAdapter(command)
		Dim table As New DataTable()
		Try
			adapter.Fill(table)
			Return table
		Catch ex As Exception
			MessageBox.Show(ex.Message)
			Return Nothing
		Finally
			adapter.Dispose()
			command.Dispose()
		End Try
	End Function

	Public Shared Function GetDataSet(connection As SqlCeConnection, commandType As CommandType, commandText As String) As DataSet
		Dim command As SqlCeCommand = CreateCommand(connection, commandType, commandText)
		Dim adapter As New SqlCeDataAdapter(command)
		Dim dataSet As New DataSet()
		Try
			adapter.Fill(dataSet)
			Return dataSet
		Catch ex As Exception
			MessageBox.Show(ex.Message)
			Return Nothing
		Finally
			adapter.Dispose()
			command.Dispose()
		End Try

	End Function

	Public Shared Function GetDataSet(connection As SqlCeConnection, commandType As CommandType, commandText As String, parameterList As Dictionary(Of String, Object)) As DataSet
		Dim command As SqlCeCommand = CreateCommand(connection, commandType, commandText)
		AddParameter(command, parameterList)
		Dim adapter As New SqlCeDataAdapter(command)
		Dim dataSet As New DataSet()
		Try
			adapter.Fill(dataSet)
			Return dataSet
		Catch ex As Exception
			MessageBox.Show(ex.Message)
			Return Nothing
		Finally
			adapter.Dispose()
			command.Dispose()
		End Try
	End Function

	Private Shared Function CreateCommand(connection As SqlCeConnection, commandType As CommandType, commandText As String) As SqlCeCommand
		Dim command As New SqlCeCommand(commandText, connection)
		command.CommandType = commandType
		Return command
	End Function

	Private Shared Sub AddParameter(command As SqlCeCommand, parameterList As Dictionary(Of String, Object))
		If parameterList IsNot Nothing OrElse parameterList.Count = 0 Then
			For Each pair As KeyValuePair(Of String, Object) In parameterList
				command.Parameters.AddWithValue(pair.Key, pair.Value)
			Next
		End If
	End Sub
End Class
