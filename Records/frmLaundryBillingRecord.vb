Imports System.Data.SqlClient

Public Class frmLaundryBillingRecord
    Sub fillBillNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(BillNo) FROM Laundry_BillInfo", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbBillNo.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbBillNo.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(Laundry_BillInfo.Id) as [Bill ID], RTRIM(BillNo) as [Bill No.],Convert(DateTime,BillDate,131) as [Bill Date],RTRIM(PaymentMode) as [Payment Mode], RTRIM(CheckInId) as [Check In ID],RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(RoomNo) as [Room No.],RTRIM(Laundry_BillInfo.GrandTotal) as [Grand Total], RTRIM(TotalPayment) as [Total Payment], RTRIM(PaymentDue) as [Payment Due] from Guest,CheckIN_Room,Laundry_BillInfo,Room where Guest.ID=CheckIn_Room.GuestID and Laundry_BillInfo.CheckInId=Checkin_Room.Cin_ID and Room.R_ID=CheckIN_Room.RoomID order by BillDate", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Laundry_BillInfo")
            dgw.DataSource = myDataSet.Tables("Laundry_BillInfo").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
        fillBillNo()
    End Sub
    Sub Reset()
        cmbBillNo.Text = ""
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Now
        txtGuestName.Text = ""
        GetData()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub


    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                If lblSet.Text = "Laundry" Then

                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    Me.Hide()
                    frmLaundryBilling.Show()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmLaundryBilling.txtBillID.Text = dr.Cells(0).Value.ToString()
                    frmLaundryBilling.txtBillNo.Text = dr.Cells(1).Value.ToString()
                    frmLaundryBilling.dtpBillDate.Text = dr.Cells(2).Value.ToString()
                    frmLaundryBilling.cmbPaymentMode.Text = dr.Cells(3).Value.ToString()
                    frmLaundryBilling.txtCheckedInID.Text = dr.Cells(4).Value.ToString()
                    frmLaundryBilling.txtGuestID.Text = dr.Cells(5).Value.ToString()
                    frmLaundryBilling.txtGuestName.Text = dr.Cells(6).Value.ToString()
                    frmLaundryBilling.txtRoomNo.Text = dr.Cells(7).Value.ToString()
                    frmLaundryBilling.txtGrandTotal.Text = dr.Cells(8).Value.ToString()
                    frmLaundryBilling.txtTotalPayment.Text = dr.Cells(9).Value.ToString()
                    frmLaundryBilling.txtPaymentDue.Text = dr.Cells(10).Value.ToString()
                    frmLaundryBilling.btnSave.Enabled = False
                    frmLaundryBilling.btnDelete.Enabled = True
                    frmLaundryBilling.btnUpdate.Enabled = True
                    frmLaundryBilling.btnPrint.Enabled = True
                    frmLaundryBilling.btnRemove.Enabled = False
                    frmLaundryBilling.dtpBillDate.Enabled = False
                    frmLaundryBilling.btnListOfGuest.Enabled = False
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql As String = "Select RTRIM(Service),RTRIM(Rate),RTRIM(Qty),RTRIM(TotalAmount) from Laundry_BillInfo,LaundryServices where Laundry_BillInfo.Id=LaundryServices.BillID and Laundry_BillInfo.ID=" & dr.Cells(0).Value & ""
                    cmd = New SqlCommand(sql, con)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    frmLaundryBilling.DataGridView1.Rows.Clear()
                    While (rdr.Read() = True)
                        frmLaundryBilling.DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3))
                    End While
                    con.Close()
                    lblSet.Text = ""
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

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


    Private Sub txtGuestName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGuestName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(Laundry_BillInfo.Id) as [Bill ID], RTRIM(BillNo) as [Bill No.],Convert(DateTime,BillDate,131) as [Bill Date],RTRIM(PaymentMode) as [Payment Mode], RTRIM(CheckInId) as [Check In ID],RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(RoomNo) as [Room No.],RTRIM(Laundry_BillInfo.GrandTotal) as [Grand Total], RTRIM(TotalPayment) as [Total Payment], RTRIM(PaymentDue) as [Payment Due] from Guest,CheckIN_Room,Laundry_BillInfo,Room where Guest.ID=CheckIn_Room.GuestID and Laundry_BillInfo.CheckInId=Checkin_Room.Cin_ID and Room.R_ID=CheckIN_Room.RoomID and GuestName like '%" & txtGuestName.Text & "%' order by BillDate", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Laundry_BillInfo")
            dgw.DataSource = myDataSet.Tables("Laundry_BillInfo").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(Laundry_BillInfo.Id) as [Bill ID], RTRIM(BillNo) as [Bill No.],Convert(DateTime,BillDate,131) as [Bill Date],RTRIM(PaymentMode) as [Payment Mode], RTRIM(CheckInId) as [Check In ID],RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(RoomNo) as [Room No.],RTRIM(Laundry_BillInfo.GrandTotal) as [Grand Total], RTRIM(TotalPayment) as [Total Payment], RTRIM(PaymentDue) as [Payment Due] from Guest,CheckIN_Room,Laundry_BillInfo,Room where Guest.ID=CheckIn_Room.GuestID and Laundry_BillInfo.CheckInId=Checkin_Room.Cin_ID and Room.R_ID=CheckIN_Room.RoomID and BillDate between @d1 and @d2 order by BillDate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "BillDate").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "BillDate").Value = dtpDateTo.Value
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Laundry_BillInfo")
            dgw.DataSource = myDataSet.Tables("Laundry_BillInfo").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbBillNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBillNo.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(Laundry_BillInfo.Id) as [Bill ID], RTRIM(BillNo) as [Bill No.],Convert(DateTime,BillDate,131) as [Bill Date],RTRIM(PaymentMode) as [Payment Mode], RTRIM(CheckInId) as [Check In ID],RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(RoomNo) as [Room No.],RTRIM(Laundry_BillInfo.GrandTotal) as [Grand Total], RTRIM(TotalPayment) as [Total Payment], RTRIM(PaymentDue) as [Payment Due] from Guest,CheckIN_Room,Laundry_BillInfo,Room where Guest.ID=CheckIn_Room.GuestID and Laundry_BillInfo.CheckInId=Checkin_Room.Cin_ID and Room.R_ID=CheckIN_Room.RoomID and BillNo='" & cmbBillNo.Text & "' order by BillDate", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Laundry_BillInfo")
            dgw.DataSource = myDataSet.Tables("Laundry_BillInfo").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbBillNo_Format(sender As System.Object, e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbBillNo.Format
        If (e.DesiredType Is GetType(String)) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub
End Class
