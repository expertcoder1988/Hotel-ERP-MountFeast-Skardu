Imports System.Data.SqlClient
Public Class frmLicense
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into License(LicenseDate) VALUES (@d1)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Encrypt(DateTimePicker1.Value))
            cmd.ExecuteReader()
            con.Close()
            'MessageBox.Show("Successfully activated", "Software", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' frmLogin.Show()
            Me.Hide()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class