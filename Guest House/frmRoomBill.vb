Imports System.Data.SqlClient

Public Class frmRoomBill
    Sub fillBilllNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(BillNo) FROM CheckOut_Room", CN)
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

    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillBilllNo()
    End Sub
    Sub Reset()
        cmbBillNo.Text = ""
        fillBilllNo()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub


    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Len(Trim(cmbBillNo.Text)) = 0 Then
                MessageBox.Show("Please select bill no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbBillNo.Focus()
                Exit Sub
            End If
                Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            GetData()
                Dim rpt As New rptRoomInvoice 'The report you created.
                Dim myConnection As SqlConnection
                Dim MyCommand, MyCommand1, MyCommand2 As New SqlCommand()
                Dim myDA, myDA1, myDA2 As New SqlDataAdapter()
                Dim myDS As New DataSet 'The DataSet you created.
                myConnection = New SqlConnection(cs)
                MyCommand.Connection = myConnection
                MyCommand1.Connection = myConnection
                MyCommand2.Connection = myConnection
            MyCommand.CommandText = "SELECT OtherCharge,Room.R_ID, Room.RoomNo, Room.PlanCode, Room.RoomType, Room.RoomCharges, Room.MaxNoOfAdults, Room.MaxNoOfKids, Room.Active, CheckIN_Room.Cin_Id, CheckIN_Room.GuestID,CheckIN_Room.RoomID, CheckIN_Room.RoomCharges AS Expr1, CheckIN_Room.DateIN, CheckIN_Room.DateOUT, CheckIN_Room.NoOfDays, CheckIN_Room.NoOfMales, CheckIN_Room.NoOfFemales,  CheckIN_Room.NoOfKids, CheckIN_Room.NoOfExtraBed, CheckIN_Room.NoOfExtraPerson, CheckIN_Room.RoomOrderCharges, CheckIN_Room.ExtraPersonCharges, CheckIN_Room.TotalRoomCharges, CheckIN_Room.ExtraBedCharges, CheckIN_Room.OtherCharges, CheckIN_Room.DiscountPer, CheckIN_Room.DiscountAmount, CheckIN_Room.STPer, CheckIN_Room.STAmount, CheckIN_Room.LuxuryTaxPer, CheckIN_Room.LuxuryTaxAmount, CheckIN_Room.SubTotal, CheckIN_Room.GrandTotal, CheckIN_Room.TotalPaid, CheckIN_Room.Balance, CheckIN_Room.Status, CheckIN_Room.Notes, Guest.ID, Guest.GuestID AS Expr2, Guest.GuestName, Guest.Address, Guest.City, Guest.Country, Guest.ContactNo, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.Email, Guest.IDType, Guest.IDNumber,  Guest.Pic1, Guest.Pic2, Guest.pic3, Guest.Notes AS Expr3, Guest.Company, Guest.Model, Guest.VehicleNo, Guest.Color FROM Room INNER JOIN CheckIN_Room ON Room.R_ID = CheckIN_Room.RoomID INNER JOIN Guest ON CheckIN_Room.GuestID = Guest.ID where Status='Checked Out' and Cin_ID=" & txtCheckedInID.Text & ""
                MyCommand1.CommandText = "SELECT * from Hotel"
                MyCommand2.CommandText = "SELECT * from Currency"
                MyCommand.CommandType = CommandType.Text
                MyCommand1.CommandType = CommandType.Text
                MyCommand2.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA1.SelectCommand = MyCommand1
                myDA2.SelectCommand = MyCommand2
                myDA.Fill(myDS, "Guest")
                myDA.Fill(myDS, "Room")
                myDA.Fill(myDS, "CheckIn_Room")
                myDA.Fill(myDS, "Guest_Docs")
                myDA1.Fill(myDS, "Hotel")
                myDA2.Fill(myDS, "Currency")
                rpt.SetDataSource(myDS)
            rpt.SetParameterValue("v1", cmbBillNo.Text)
            rpt.SetParameterValue("v2", dtpBillDate.Value)
                frmReport.CrystalReportViewer1.ReportSource = rpt
                frmReport.ShowDialog()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
    End Sub
    Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT CheckInID,BillDate,RoomNo FROM CheckOut_Room,CheckIn_Room,Room where Room.R_ID=CheckIn_Room.RoomID and CheckIn_Room.Cin_ID=CheckOut_Room.CheckInID and BillNo=@d1"
            cmd.Parameters.AddWithValue("@d1", cmbBillNo.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtCheckedInID.Text = rdr.GetValue(0)
                dtpBillDate.Text = rdr.GetValue(1)
                txtRoomNo.Text = rdr.GetValue(2)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub cmbBillNo_Format(sender As System.Object, e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbBillNo.Format
        If (e.DesiredType Is GetType(String)) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub
End Class
