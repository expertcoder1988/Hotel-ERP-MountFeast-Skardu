Imports System.Data.SqlClient
Imports System.IO

Public Class frmEmployeeAccountMaster
    Private Sub auto()
        Try
            Dim Num As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = ("SELECT MAX(ID) FROM EmployeeAccountRegistration")
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            If (IsDBNull(cmd.ExecuteScalar)) Then
                Num = 1
                txtID.Text = Num.ToString
            Else
                Num = cmd.ExecuteScalar + 1
                txtID.Text = Num.ToString
            End If
            cmd.Dispose()
            con.Close()
            con.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Reset()
        txtAddress.Text = ""
        txtSearchByEmployeeName.Text = ""
        txtAccountName.Text = ""
        txtAccountNo.Text = ""
        txtEmployeeID.Text = ""
        cmbActive.SelectedIndex = 0
        txtEmployeeName.Text = ""
        txtIFSCCode.Text = ""
        txtSwiftCode.Text = ""
        txtBranchName.Text = ""
        txtBank.Text = ""
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        txtEmployeeID.Focus()
        txtAccountNo.Focus()
        auto()
        Getdata1()
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtEmployeeID.Text = "" Then
            MessageBox.Show("Please retrieve employee information", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmployeeID.Focus()
            Return
        End If
        If txtAccountNo.Text = "" Then
            MessageBox.Show("Please enter account no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAccountNo.Focus()
            Return
        End If
        If txtAccountName.Text = "" Then
            MessageBox.Show("Please enter account name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAccountName.Focus()
            Return
        End If
        If txtBank.Text = "" Then
            MessageBox.Show("Please enter bank", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBank.Focus()
            Return
        End If
        If txtBranchName.Text = "" Then
            MessageBox.Show("Please enter branch name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBranchName.Focus()
            Return
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into EmployeeAccountRegistration(Id, AccountNo, AccountName, BankName, Branch, Address, IFSCCode, SwiftCode, EmployeeID, Active) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtID.Text)
            cmd.Parameters.AddWithValue("@d2", txtAccountNo.Text)
            cmd.Parameters.AddWithValue("@d3", txtAccountName.Text)
            cmd.Parameters.AddWithValue("@d4", txtBank.Text)
            cmd.Parameters.AddWithValue("@d5", txtBranchName.Text)
            cmd.Parameters.AddWithValue("@d6", txtAddress.Text)
            cmd.Parameters.AddWithValue("@d7", txtIFSCCode.Text)
            cmd.Parameters.AddWithValue("@d8", txtSwiftCode.Text)
            cmd.Parameters.AddWithValue("@d9", txtEmp_ID.Text)
            cmd.Parameters.AddWithValue("@d10", cmbActive.Text)
            cmd.ExecuteNonQuery()
            con.Close()
            Dim st As String = "added the new Employee Bank account details having account no. '" & txtAccountNo.Text & "' and Bank Name '" & txtBank.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            Getdata1()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub


    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If txtEmployeeID.Text = "" Then
            MessageBox.Show("Please retrieve employee information", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmployeeID.Focus()
            Return
        End If
        If txtAccountNo.Text = "" Then
            MessageBox.Show("Please enter account no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAccountNo.Focus()
            Return
        End If
        If txtAccountName.Text = "" Then
            MessageBox.Show("Please enter account name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAccountName.Focus()
            Return
        End If
        If txtBank.Text = "" Then
            MessageBox.Show("Please enter bank", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBank.Focus()
            Return
        End If
        If txtBranchName.Text = "" Then
            MessageBox.Show("Please enter branch name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBranchName.Focus()
            Return
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update EmployeeAccountRegistration set AccountNo=@d2, AccountName=@d3, BankName=@d4, Branch=@d5, Address=@d6, IFSCCode=@d7, SwiftCode=@d8, EmployeeID=@d9, Active=@d10 where ID=@d1"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtID.Text)
            cmd.Parameters.AddWithValue("@d2", txtAccountNo.Text)
            cmd.Parameters.AddWithValue("@d3", txtAccountName.Text)
            cmd.Parameters.AddWithValue("@d4", txtBank.Text)
            cmd.Parameters.AddWithValue("@d5", txtBranchName.Text)
            cmd.Parameters.AddWithValue("@d6", txtAddress.Text)
            cmd.Parameters.AddWithValue("@d7", txtIFSCCode.Text)
            cmd.Parameters.AddWithValue("@d8", txtSwiftCode.Text)
            cmd.Parameters.AddWithValue("@d9", txtEmp_ID.Text)
            cmd.Parameters.AddWithValue("@d10", cmbActive.Text)
            cmd.ExecuteNonQuery()
            con.Close()
            Dim st As String = "updated the Employee Bank account details having account no. '" & txtAccountNo.Text & "' and Bank Name '" & txtBank.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            Getdata1()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Public Sub Getdata1()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(EmployeeAccountRegistration.ID),RTRIM(EmployeeRegistration.ID),RTRIM(EmployeeRegistration.EmployeeID),RTRIM(EmployeeName),RTRIM(AccountNo),RTRIM(AccountName),RTRIM(BankName),RTRIM(Branch),RTRIM(EmployeeAccountRegistration.Address),RTRIM(SwiftCode),RTRIM(IFSCCode),RTRIM(Active) from EmployeeRegistration,EmployeeAccountRegistration where EmployeeRegistration.ID=EmployeeAccountRegistration.EmployeeID order by EmployeeName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub


    Private Sub frmRegistration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata1()
    End Sub



    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DeleteRecord()

        Try
            Dim RowsAffected As Integer = 0

            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from EmployeeAccountRegistration where ID=" & txtID.Text & ""
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the Employee account record having account no. '" & txtAccountNo.Text & "' and Bank Name '" & txtBank.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Getdata1()
                Reset()
            Else
                MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub


    Private Sub DataGridView1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        Try
            If DataGridView1.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
                txtID.Text = dr.Cells(0).Value.ToString()
                txtEmp_ID.Text = dr.Cells(1).Value.ToString()
                txtEmployeeID.Text = dr.Cells(2).Value.ToString()
                txtEmployeeName.Text = dr.Cells(3).Value.ToString()
                txtAccountNo.Text = dr.Cells(4).Value.ToString()
                txtAccountName.Text = dr.Cells(5).Value.ToString()
                txtBank.Text = dr.Cells(6).Value.ToString()
                txtBranchName.Text = dr.Cells(7).Value.ToString()
                txtAddress.Text = dr.Cells(8).Value.ToString()
                txtSwiftCode.Text = dr.Cells(9).Value.ToString()
                txtIFSCCode.Text = dr.Cells(10).Value.ToString()
                cmbActive.Text = dr.Cells(11).Value.ToString()
                btnUpdate.Enabled = True
                btnSave.Enabled = False
                btnDelete.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        frmEmployeesRecord.lblSet.Text = "Employee Account Master"
        frmEmployeesRecord.Reset()
        frmEmployeesRecord.ShowDialog()
    End Sub

    Private Sub txtSearchByEmployeeName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchByEmployeeName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(EmployeeAccountRegistration.ID),RTRIM(EmployeeRegistration.ID),RTRIM(EmployeeRegistration.EmployeeID),RTRIM(EmployeeName),RTRIM(AccountNo),RTRIM(AccountName),RTRIM(BankName),RTRIM(Branch),RTRIM(EmployeeAccountRegistration.Address),RTRIM(SwiftCode),RTRIM(IFSCCode),RTRIM(Active) from EmployeeRegistration,EmployeeAccountRegistration where EmployeeRegistration.ID=EmployeeAccountRegistration.EmployeeID and EmployeeName like '%" & txtSearchByEmployeeName.Text & "%' order by EmployeeName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
