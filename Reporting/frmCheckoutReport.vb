Imports System.Data.SqlClient

Public Class frmCheckoutReport
    Sub fillRoomNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Room.RoomNo) FROM CheckOut_Room,Guest,Room,CheckIN_Room where Guest.ID=CheckIN_Room.GuestID 
and Checkout_Room.CheckInID=CheckIn_Room.Cin_ID and Room.R_ID=CheckIN_Room.RoomID", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbRoomNo.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbRoomNo.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(CheckOut_Room.ID) as [Bill ID],RTRIM(BillNo) as [Bill No.],Convert(Datetime,BillDate,131) as [Bill Date],
RTRIM(CheckIn_Room.Cin_Id) as [Check In ID], RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Room. RoomNo) as [Room No.], 
RTRIM(CheckIN_Room.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out],
RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], 
RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(RoomOrderCharges) as [Room Order Charges],
RTRIM(ExtraPersonCharges) as [Extra Person Charges], RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges],
RTRIM(OtherCharges) as [Laundry Charges], RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %],
RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(SubTotal) as [Sub Total],
RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance], RTRIM(Checkout_Room.Notes) as [Notes] from CheckOut_Room 
inner join Checkin_Room on CheckOut_Room.checkinid = Checkin_Room.cin_id INNER JOIN Guest ON Checkin_Room.GuestID = Guest.ID LEft OUTER JOIN
                            Room ON Checkin_Room.RoomID = Room.R_ID Order by DateOut", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Checkin_room")
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            dgw.DataSource = myDataSet.Tables("Room").DefaultView
            dgw.DataSource = myDataSet.Tables("Checkin_room").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
        fillRoomNo()
    End Sub
    Sub Reset()
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Now
        DateTimePicker2.Text = Today
        DateTimePicker1.Text = Now
        cmbRoomNo.SelectedIndex = -1
        GetData()
        fillRoomNo()
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


    Private Sub dgw_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(CheckOut_Room.ID) as [Bill ID],RTRIM(BillNo) as [Bill No.],Convert(Datetime,BillDate,131) as [Bill Date],
RTRIM(CheckIn_Room.Cin_Id) as [Check In ID], RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Room. RoomNo) as [Room No.], 
RTRIM(CheckIN_Room.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out], 
RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], 
RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(RoomOrderCharges) as [Room Order Charges], 
RTRIM(ExtraPersonCharges) as [Extra Person Charges], RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges], 
RTRIM(OtherCharges) as [Laundry Charges], RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %],
RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(SubTotal) as [Sub Total], 
RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance], RTRIM(Checkout_Room.Notes) as [Notes] from CheckOut_Room 
inner join Checkin_Room on CheckOut_Room.checkinid = Checkin_Room.cin_id INNER JOIN Guest ON Checkin_Room.GuestID = Guest.ID LEft OUTER JOIN
                            Room ON Checkin_Room.RoomID = Room.R_ID where DateOut between @d1 and @d2 Order by DateOut", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateOut").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateOut").Value = dtpDateTo.Value
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Checkin_room")
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            dgw.DataSource = myDataSet.Tables("Room").DefaultView
            dgw.DataSource = myDataSet.Tables("Checkin_room").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptCheckOut 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1, MyCommand2 As New SqlCommand()
            Dim myDA, myDA1, myDA2 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand2.Connection = myConnection
            MyCommand.CommandText = "Select Room.R_ID, Room.RoomNo, Room.PlanCode, Room.RoomType, Room.RoomCharges, Room.MaxNoOfAdults, Room.MaxNoOfKids, Room.Active, CheckIN_Room.Cin_Id, CheckIN_Room.GuestID,CheckIN_Room.RoomID, CheckIN_Room.RoomCharges AS Expr1, CheckIN_Room.DateIN, CheckIN_Room.DateOUT, CheckIN_Room.NoOfDays, CheckIN_Room.NoOfMales, CheckIN_Room.NoOfFemales,  CheckIN_Room.NoOfKids, CheckIN_Room.NoOfExtraBed, CheckIN_Room.NoOfExtraPerson, CheckIN_Room.RoomOrderCharges, CheckIN_Room.ExtraPersonCharges, CheckIN_Room.TotalRoomCharges, CheckIN_Room.ExtraBedCharges, CheckIN_Room.OtherCharges, CheckIN_Room.DiscountPer, CheckIN_Room.DiscountAmount, CheckIN_Room.STPer, CheckIN_Room.STAmount, CheckIN_Room.LuxuryTaxPer, CheckIN_Room.LuxuryTaxAmount, CheckIN_Room.SubTotal, CheckIN_Room.GrandTotal, CheckIN_Room.TotalPaid, CheckIN_Room.Balance, CheckIN_Room.Status, CheckIN_Room.Notes, Guest.ID, Guest.GuestID AS Expr2, Guest.GuestName, Guest.Address, Guest.City, Guest.Country, Guest.ContactNo, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.Email, Guest.IDType, Guest.IDNumber,  Guest.Pic1, Guest.Pic2, Guest.pic3, Guest.Notes AS Expr3, Guest.Company, Guest.Model, Guest.VehicleNo, Guest.Color FROM Room INNER JOIN CheckIN_Room ON Room.R_ID = CheckIN_Room.RoomID INNER JOIN Guest ON CheckIN_Room.GuestID = Guest.ID where DateOut between @d1 and @d2 and Status='Checked Out' order by DateOut"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand2.CommandText = "SELECT * from Currency"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            MyCommand2.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA2.SelectCommand = MyCommand2
            myDA.Fill(myDS, "CheckIN_Room")
            myDA.Fill(myDS, "Guest")
            myDA.Fill(myDS, "Room")
            myDA1.Fill(myDS, "Hotel")
            myDA2.Fill(myDS, "Currency")
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("v1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("v2", dtpDateTo.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Try
            If cmbRoomNo.Text = "" Then
                MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbRoomNo.Focus()
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(CheckOut_Room.ID) as [Bill ID],RTRIM(BillNo) as [Bill No.],Convert(Datetime,BillDate,131) as [Bill Date],RTRIM(CheckIn_Room.Cin_Id) as [Check In ID], RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Room. RoomNo) as [Room No.], RTRIM(CheckIN_Room.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out], RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(RoomOrderCharges) as [Room Order Charges], RTRIM(ExtraPersonCharges) as [Extra Person Charges], RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges], RTRIM(OtherCharges) as [Laundry Charges], RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %], RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(SubTotal) as [Sub Total], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance], RTRIM(Checkout_Room.Notes) as [Notes] from CheckOut_Room,Guest,Room,CheckIN_Room where Guest.ID=CheckIN_Room.GuestID and Checkout_Room.CheckInID=CheckIn_Room.Cin_ID and Room.R_ID=CheckIN_Room.RoomID and DateOut between @d1 and @d2 and Room.RoomNo=@d3 Order by DateOut", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateOut").Value = DateTimePicker2.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateOut").Value = DateTimePicker1.Value
            cmd.Parameters.Add("@d3", SqlDbType.NChar, 50, "RoomNo").Value = cmbRoomNo.Text
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Checkin_room")
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            dgw.DataSource = myDataSet.Tables("Room").DefaultView
            dgw.DataSource = myDataSet.Tables("Checkin_room").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Try
            If cmbRoomNo.Text = "" Then
                MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbRoomNo.Focus()
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptCheckOut1 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1, MyCommand2 As New SqlCommand()
            Dim myDA, myDA1, myDA2 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand2.Connection = myConnection
            MyCommand.CommandText = "Select Room.R_ID, Room.RoomNo, Room.PlanCode, Room.RoomType, Room.RoomCharges, Room.MaxNoOfAdults, Room.MaxNoOfKids, Room.Active, CheckIN_Room.Cin_Id, CheckIN_Room.GuestID,CheckIN_Room.RoomID, CheckIN_Room.RoomCharges AS Expr1, CheckIN_Room.DateIN, CheckIN_Room.DateOUT, CheckIN_Room.NoOfDays, CheckIN_Room.NoOfMales, CheckIN_Room.NoOfFemales,  CheckIN_Room.NoOfKids, CheckIN_Room.NoOfExtraBed, CheckIN_Room.NoOfExtraPerson, CheckIN_Room.RoomOrderCharges, CheckIN_Room.ExtraPersonCharges, CheckIN_Room.TotalRoomCharges, CheckIN_Room.ExtraBedCharges, CheckIN_Room.OtherCharges, CheckIN_Room.DiscountPer, CheckIN_Room.DiscountAmount, CheckIN_Room.STPer, CheckIN_Room.STAmount, CheckIN_Room.LuxuryTaxPer, CheckIN_Room.LuxuryTaxAmount, CheckIN_Room.SubTotal, CheckIN_Room.GrandTotal, CheckIN_Room.TotalPaid, CheckIN_Room.Balance, CheckIN_Room.Status, CheckIN_Room.Notes, Guest.ID, Guest.GuestID AS Expr2, Guest.GuestName, Guest.Address, Guest.City, Guest.Country, Guest.ContactNo, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.Email, Guest.IDType, Guest.IDNumber,  Guest.Pic1, Guest.Pic2, Guest.pic3, Guest.Notes AS Expr3, Guest.Company, Guest.Model, Guest.VehicleNo, Guest.Color FROM Room INNER JOIN CheckIN_Room ON Room.R_ID = CheckIN_Room.RoomID INNER JOIN Guest ON CheckIN_Room.GuestID = Guest.ID where DateOut between @d1 and @d2 and Status='Checked Out' and Room.RoomNo=@d3 order by DateOut"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = DateTimePicker2.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = DateTimePicker1.Value
            MyCommand.Parameters.Add("@d3", SqlDbType.NChar, 50, "RoomNo").Value = cmbRoomNo.Text
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand2.CommandText = "SELECT * from Currency"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            MyCommand2.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA2.SelectCommand = MyCommand2
            myDA.Fill(myDS, "CheckIN_Room")
            myDA.Fill(myDS, "Guest")
            myDA.Fill(myDS, "Room")
            myDA1.Fill(myDS, "Hotel")
            myDA2.Fill(myDS, "Currency")
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("v1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("v2", dtpDateTo.Value.Date)
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
