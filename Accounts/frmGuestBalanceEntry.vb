Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Public Class frmGuestBalanceEntry
    Sub Reset()
        txtGuestID.Text = ""
        txtGuestName.Text = ""
        txtAmount.Text = ""
        txtSearchByGuestName.Text = ""
        dtpEntryDate.Text = Now
        GetData()
        btnDelete.Enabled = False
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        dtpEntryDate.Enabled = True
        btnPrint.Enabled = False
    End Sub
    Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "SELECT RTRIM(Guest.ID),RTRIM(Guest.guestID),RTRIM(GuestName),IsNull(sum(Amount)-sum(Deduction),0) FROM Guest left join GuestLedger on Guest.ID=GuestLedger.guestID group by guestname,Guest.guestid,Guest.ID order by guestName"
            cmd = New SqlCommand(sql, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(txtGuestID.Text)) = 0 Then
            MessageBox.Show("Please retrieve guest info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtGuestID.Focus()
            Exit Sub
        End If
        If Len(Trim(txtAmount.Text)) = 0 Then
            MessageBox.Show("Please enter Amount", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAmount.Focus()
            Exit Sub
        End If

        Try
            auto()
            Dim string1 As String = "Deposited the money in account"
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into GuestLedger(ID,date,guestid,amount,deduction,Details) VALUES (" & txtID.Text & ",@d1," & txtG_ID.Text & "," & txtAmount.Text & ",0,@d2)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", dtpEntryDate.Value)
            cmd.Parameters.AddWithValue("@d2", string1)
            cmd.Connection = con
            cmd.ExecuteReader()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()
            LedgerSave(dtpEntryDate.Value.Date, txtGuestName.Text, txtID.Text, "Deposit in Guest's Account", 0, Val(txtAmount.Text), txtGuestID.Text)
            Dim st As String = "added the new Guest Ledger entry having id '" & txtID.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully saved", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            con.Close()
            GetData()
            RefreshRecords()
            btnPrint.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        If Len(Trim(txtGuestID.Text)) = 0 Then
            MessageBox.Show("Please retrieve guest info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtGuestID.Focus()
            Exit Sub
        End If
        If Len(Trim(txtAmount.Text)) = 0 Then
            MessageBox.Show("Please enter Amount", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAmount.Focus()
            Exit Sub
        End If

        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update GuestLedger set guestID=" & txtG_ID.Text & ",Amount=" & txtAmount.Text & " where id=" & txtID.Text & ""
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()
            LedgerUpdate(dtpEntryDate.Value.Date, txtGuestName.Text, 0, Val(txtAmount.Text), txtGuestID.Text, txtID.Text, "Deposit in Guest's Account")
            Dim st As String = "updated the Guest Ledger Entry having id '" & txtID.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            con.Close()
            GetData()
            RefreshRecords()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
                RefreshRecords()
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
            Dim cq As String = "delete from GuestLedger where id=" & txtID.Text & ""
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                LedgerDelete(txtID.Text, "Deposit in Guest's Account")
                Dim st As String = "deleted the advance entry having id '" & txtID.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                GetData()
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

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub frmGuestLedger_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GetData()
    End Sub

    Private Sub dgw_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtG_ID.Text = dr.Cells(0).Value
                txtGuestID.Text = dr.Cells(1).Value.ToString
                txtGuestName.Text = dr.Cells(2).Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgw_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub


    Private Sub txtAmount_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtAmount.Text
            Dim selectionStart = Me.txtAmount.SelectionStart
            Dim selectionLength = Me.txtAmount.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an Integereger that is longer than 16 digits.
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
    Private Sub auto()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM GuestLedger")
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
    End Sub
    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        frmGuestLedgerRecord.lblSet.Text = "Guest Ledger"
        frmGuestLedgerRecord.Reset()
        frmGuestLedgerRecord.ShowDialog()
    End Sub

    Private Sub txtSearchByGuestName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchByGuestName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "SELECT RTRIM(Guest.ID),RTRIM(Guest.guestID),RTRIM(GuestName),IsNull(sum(Amount)-sum(Deduction),0) FROM Guest left join GuestLedger on Guest.ID=GuestLedger.guestID where GuestName like '%" & txtSearchByGuestName.Text & "%' group by guestname,Guest.guestid,Guest.ID order by guestName"
            cmd = New SqlCommand(sql, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        txtSearchByGuestName.Text = ""
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        ExportExcel(dgw)
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptMoneyDepositReceipt 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT GuestLedger.Id, GuestLedger.Amount, GuestLedger.Deduction, GuestLedger.Date, GuestLedger.Details, GuestLedger.GL_Label,Guest.GuestName, Guest.Address, Guest.City, Guest.Country, Guest.ContactNo, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.Email, Guest.IDType, Guest.IDNumber, Guest.Pic1, Guest.Pic2, Guest.pic3,Guest.Notes, Guest.Company, Guest.Model, Guest.VehicleNo, Guest.Color FROM GuestLedger INNER JOIN Guest ON GuestLedger.GuestID = Guest.ID where GuestLedger.Id=" & txtID.Text & ""
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "Guest")
            myDA.Fill(myDS, "GuestLedger")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub
End Class
