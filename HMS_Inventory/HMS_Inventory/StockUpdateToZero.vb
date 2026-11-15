Imports System.Data.SqlClient


Module StockUpdateToZero
    Dim objConnection As New SqlConnection With {.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\bin\Debug\HMS_DB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"}


    'SET THE QUANTITY TO ZERO IF QUANTITY IS LESS THAN ZERO
    Public Sub UpdateToZero()
        Try
            Dim strUpdateToZero As String = "UPDATE Stock_STOCK " &
                "SET Quantity_on_hand= " & 0 & " " &
                "WHERE Quantity_on_hand<" & 0 & ""

            'Open the connection
            objConnection.Open()

            'Create a command
            Dim objUpdateToStock = New SqlCommand(strUpdateToZero, objConnection)

            'Execute the command
            objUpdateToStock.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then
                objConnection.Close()
            End If
        End Try
    End Sub


End Module
