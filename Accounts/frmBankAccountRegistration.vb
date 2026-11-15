Imports System.Data.SqlClient
Imports System.IO

Public Class frmBankAccountRegistration
    Private Sub auto()
        Try
            Dim Num As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = ("SELECT MAX(ID) FROM BankAccountRegistration")
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
        txtAccountName.Text = ""
        txtAccountNo.Text = ""
        cmbAccountType.SelectedIndex = -1
        cmbActive.SelectedIndex = 0
        txtBalanceAmount.Text = ""
        dtpOpeningDate.Value = Today
        txtContactNo.Text = ""
        txtIFSCCode.Text = ""
        txtSwiftCode.Text = ""
        txtBranchName.Text = ""
        txtBank.Text = ""
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        txtAccountNo.Focus()
        auto()
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
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
        If cmbAccountType.Text = "" Then
            MessageBox.Show("Please select account type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbAccountType.Focus()
            Return
        End If
        If txtBalanceAmount.Text = "" Then
            MessageBox.Show("Please enter balance amount", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBalanceAmount.Focus()
            Return
        End If



        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into BankAccountRegistration(Id, AccountNo, AccountName, AccountType, OpeningDate, BalanceAmount, Active, BranchID) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtID.Text)
            cmd.Parameters.AddWithValue("@d2", txtAccountNo.Text)
            cmd.Parameters.AddWithValue("@d3", txtAccountName.Text)
            cmd.Parameters.AddWithValue("@d4", cmbAccountType.Text)
            cmd.Parameters.AddWithValue("@d5", dtpOpeningDate.Value.Date)
            cmd.Parameters.AddWithValue("@d6", txtBalanceAmount.Text)
            cmd.Parameters.AddWithValue("@d7", cmbActive.Text)
            cmd.Parameters.AddWithValue("@d8", txtBranchID.Text)
            cmd.ExecuteNonQuery()
            con.Close()
            Dim st As String = "added the new Bank account having account no. '" & txtAccountNo.Text & "' and Bank Name '" & txtBank.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            Getdata1()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub


    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
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
        If cmbAccountType.Text = "" Then
            MessageBox.Show("Please select account type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbAccountType.Focus()
            Return
        End If
        If txtBalanceAmount.Text = "" Then
            MessageBox.Show("Please enter balance amount", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBalanceAmount.Focus()
            Return
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update BankAccountRegistration set  AccountNo=@d2, AccountName=@d3, AccountType=@d4, OpeningDate=@d5, BalanceAmount=@d6, Active=@d7, BranchID=@d8 where ID=@d1"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtID.Text)
            cmd.Parameters.AddWithValue("@d2", txtAccountNo.Text)
            cmd.Parameters.AddWithValue("@d3", txtAccountName.Text)
            cmd.Parameters.AddWithValue("@d4", cmbAccountType.Text)
            cmd.Parameters.AddWithValue("@d5", dtpOpeningDate.Value.Date)
            cmd.Parameters.AddWithValue("@d6", txtBalanceAmount.Text)
            cmd.Parameters.AddWithValue("@d7", cmbActive.Text)
            cmd.Parameters.AddWithValue("@d8", txtBranchID.Text)
            cmd.ExecuteNonQuery()
            con.Close()
            Dim st As String = "updated the Bank account registration details having account no. '" & txtAccountNo.Text & "' and Bank Name '" & txtBank.Text & "'"
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
            cmd = New SqlCommand("SELECT RTRIM(BankAccountRegistration.ID),RTRIM(AccountNo),RTRIM(AccountName),RTRIM(AccountType),Openingdate,BalanceAmount,RTRIM(Active),BranchID,RTRIM(Bank.BankName), RTRIM(BranchName), RTRIM(Address), RTRIM(ContactNo), RTRIM(SwiftCode), RTRIM(IFSCCode) from BankBranch,Bank,BankAccountRegistration where Bank.BankName=BankBranch.BankName and BankBranch.ID=BankAccountRegistration.BranchID order by Bank.BankName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID),RTRIM(BankName), RTRIM(BranchName), RTRIM(Address), RTRIM(ContactNo), RTRIM(SwiftCode), RTRIM(IFSCCode) from BankBranch order by BranchName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub


    Private Sub dgw_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub frmRegistration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
        Getdata1()
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtBranchID.Text = dr.Cells(0).Value.ToString()
                txtBank.Text = dr.Cells(1).Value.ToString()
                txtBranchName.Text = dr.Cells(2).Value.ToString()
                txtAddress.Text = dr.Cells(3).Value.ToString()
                txtContactNo.Text = dr.Cells(4).Value.ToString()
                txtSwiftCode.Text = dr.Cells(5).Value.ToString()
                txtIFSCCode.Text = dr.Cells(6).Value.ToString()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
            Dim cq As String = "delete from BankAccountRegistration where ID=" & txtID.Text & ""
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the Bank account registration having account no. '" & txtAccountNo.Text & "' and Bank Name '" & txtBank.Text & "'"
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

    Private Sub txtBalanceAmount_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBalanceAmount.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtBalanceAmount.Text
            Dim selectionStart = Me.txtBalanceAmount.SelectionStart
            Dim selectionLength = Me.txtBalanceAmount.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub DataGridView1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        Try
            If DataGridView1.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
                txtID.Text = dr.Cells(0).Value.ToString()
                txtAccountNo.Text = dr.Cells(1).Value.ToString()
                txtAccountName.Text = dr.Cells(2).Value.ToString()
                cmbAccountType.Text = dr.Cells(3).Value.ToString()
                dtpOpeningDate.Text = dr.Cells(4).Value.ToString()
                txtBalanceAmount.Text = dr.Cells(5).Value.ToString()
                cmbActive.Text = dr.Cells(6).Value.ToString()
                txtBranchID.Text = dr.Cells(7).Value.ToString()
                txtBank.Text = dr.Cells(8).Value.ToString()
                txtBranchName.Text = dr.Cells(9).Value.ToString()
                txtAddress.Text = dr.Cells(10).Value.ToString()
                txtContactNo.Text = dr.Cells(11).Value.ToString()
                txtSwiftCode.Text = dr.Cells(12).Value.ToString()
                txtIFSCCode.Text = dr.Cells(13).Value.ToString()
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
End Class
