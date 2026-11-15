Imports System.Data.SqlClient

Public Class frmReservationRecord
    Sub fillRoomNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(RoomNo) FROM Reservation,Room where Room.R_ID=Reservation.RoomID", CN)
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
            cmd = New SqlCommand("Select RTRIM(Reservation.Reserve_ID) as [Reservation ID],RTRIM(ReservationNo) as [Reservation No.],Convert(DateTime,ReservationDate,131), RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Room. RoomNo) as [Room No.],RTRIM(PlanCode) as [Plan Code],RTRIM(PlanName) as [Plan Name], RTRIM(Reservation.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out], RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(ExtraPersonCharges) as [Extra Person Charges], RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges], RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %], RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(SubTotal) as [Sub Total], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance], RTRIM(Reservation.Notes) as [Notes],RTRIM(Status) as [Status] from Guest,Room,Reservation,[Plan] where Guest.ID=Reservation.Guest_ID  and Room.R_ID=Reservation.RoomID and [Plan].P_Code=Room.PlanCode Order by ReservationDate", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Reservation")
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            dgw.DataSource = myDataSet.Tables("Room").DefaultView
            dgw.DataSource = myDataSet.Tables("Reservation").DefaultView
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
        cmbRoomNo.Text = ""
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Today
        txtGuestName.Text = ""
        cmbStatus.SelectedIndex = -1
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
                If lblSet.Text = "Reservation" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    Me.Hide()
                    frmReservation.Show()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmReservation.txtReservationID.Text = dr.Cells(0).Value.ToString()
                    frmReservation.txtReservationNo.Text = dr.Cells(1).Value.ToString()
                    frmReservation.dtpReservationDate.Value = dr.Cells(2).Value.ToString()
                    frmReservation.txtGuestID.Text = dr.Cells(3).Value.ToString()
                    frmReservation.txtGuestName.Text = dr.Cells(4).Value.ToString()
                    frmReservation.cmbRoomNo.Text = dr.Cells(5).Value.ToString()
                    frmReservation.cmbPlanCode.Text = dr.Cells(6).Value.ToString()
                    frmReservation.txtPlanName.Text = dr.Cells(7).Value.ToString()
                    frmReservation.txtRoomCharges.Text = dr.Cells(8).Value.ToString()
                    frmReservation.dtpDateIn.Text = dr.Cells(9).Value.ToString()
                    frmReservation.dtpDateOut.Text = dr.Cells(10).Value.ToString()
                    frmReservation.txtNoOfDays.Text = dr.Cells(11).Value.ToString()
                    frmReservation.txtNoOfMales.Text = dr.Cells(12).Value.ToString()
                    frmReservation.txtNoOfFemales.Text = dr.Cells(13).Value.ToString()
                    frmReservation.txtNoOfKids.Text = dr.Cells(14).Value.ToString()
                    frmReservation.txtNoOfExtraBed.Text = dr.Cells(15).Value.ToString()
                    frmReservation.txtNoOfExtraPerson.Text = dr.Cells(16).Value.ToString()
                    frmReservation.txtExtraPersonCharges.Text = dr.Cells(17).Value.ToString()
                    frmReservation.txtTotalRoomCharges.Text = dr.Cells(18).Value.ToString()
                    frmReservation.txtExtraBedCharges.Text = dr.Cells(19).Value.ToString()
                    frmReservation.txtDiscountPer.Text = dr.Cells(20).Value.ToString()
                    frmReservation.txtDiscountAmount.Text = dr.Cells(21).Value.ToString()
                    frmReservation.txtServiceTaxPer.Text = dr.Cells(22).Value.ToString()
                    frmReservation.txtServiceTaxAmount.Text = dr.Cells(23).Value.ToString()
                    frmReservation.txtLuxuryTaxPer.Text = dr.Cells(24).Value.ToString()
                    frmReservation.txtLuxuryTaxAmount.Text = dr.Cells(25).Value.ToString()
                    frmReservation.txtSubTotal.Text = dr.Cells(26).Value.ToString()
                    Dim num1, num2, num3 As Double
                    num1 = CDbl(dr.Cells(27).Value)
                    num1 = Math.Round(num1, 2)
                    num2 = CDbl(dr.Cells(28).Value)
                    num2 = Math.Round(num2, 2)
                    num3 = CDbl(dr.Cells(29).Value)
                    num3 = Math.Round(num3, 2)
                    frmReservation.txtGrandTotal.Text = num1
                    frmReservation.txtTotalPaid.Text = num2
                    frmReservation.txtBalance.Text = num3
                    frmReservation.txtNotes.Text = dr.Cells(30).Value.ToString()
                    frmReservation.txtStatus.Text = dr.Cells(31).Value.ToString()
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = con.CreateCommand()
                    cmd.CommandText = "SELECT ID, RTRIM(Address), RTRIM(City), RTRIM(ContactNo), RTRIM(Gender), RTRIM(Occupation), RTRIM(Religion),RTRIM(IDType), RTRIM(IDNumber),RTRIM(Country) from Guest WHERE GuestId='" & dr.Cells(3).Value & "'"
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        frmReservation.txtID.Text = rdr.GetValue(0)
                        frmReservation.txtGuestAddress.Text = rdr.GetValue(1)
                        frmReservation.txtGuestCity.Text = rdr.GetValue(2)
                        frmReservation.txtGuestContactNo.Text = rdr.GetValue(3)
                        frmReservation.txtGender.Text = rdr.GetValue(4)
                        frmReservation.txtOccupation.Text = rdr.GetValue(5)
                        frmReservation.txtReligion.Text = rdr.GetString(6)
                        frmReservation.txtIDType.Text = rdr.GetValue(7)
                        frmReservation.txtIDNumber.Text = rdr.GetValue(8)
                        frmReservation.txtCountry.Text = rdr.GetValue(9)
                    End If
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    frmReservation.btnSave.Enabled = False
                    frmReservation.btnDelete.Enabled = True
                    frmReservation.btnRoomAvailability.Enabled = False
                    frmReservation.Compute()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql1 As String = "SELECT RTRIM(PaymentMode),Reservation_Payment.TotalPaid,PaymentDate from Reservation,Reservation_Payment where Reservation.Reserve_ID=Reservation_Payment.ReservationID and ReservationID=@d1 and Reservation_Payment.TotalPaid > 0"
                    cmd = New SqlCommand(sql1, con)
                    cmd.Parameters.AddWithValue("@d1", dr.Cells(0).Value.ToString())
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    frmReservation.DataGridView2.Rows.Clear()
                    While (rdr.Read() = True)
                        frmReservation.DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), "Not allowed")
                    End While
                    con.Close()
                    If frmReservation.txtStatus.Text = "Reserved" Then
                        frmReservation.btnCancelReservation.Enabled = True
                        frmReservation.btnCancelReservationReceipt.Enabled = False
                        frmReservation.btnPrint.Enabled = True
                    ElseIf frmReservation.txtStatus.Text = "Confirmed" Then
                        frmReservation.btnCancelReservation.Enabled = False
                        frmReservation.btnCancelReservationReceipt.Enabled = False
                        frmReservation.btnPrint.Enabled = True
                    ElseIf frmReservation.txtStatus.Text = "Cancelled" Then
                        frmReservation.btnCancelReservation.Enabled = False
                        frmReservation.btnCancelReservationReceipt.Enabled = True
                        frmReservation.btnPrint.Enabled = False
                    End If
                    frmReservation.lblStatus.Text = "Not allowed"
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
            cmd = New SqlCommand("Select RTRIM(Reservation.Reserve_ID) as [Reservation ID],RTRIM(ReservationNo) as [Reservation No.],Convert(DateTime,ReservationDate,131), RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Room. RoomNo) as [Room No.],RTRIM(PlanCode) as [Plan Code],RTRIM(PlanName) as [Plan Name], RTRIM(Reservation.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out], RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(ExtraPersonCharges) as [Extra Person Charges], RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges], RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %], RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(SubTotal) as [Sub Total], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance], RTRIM(Reservation.Notes) as [Notes],RTRIM(Status) as [Status] from Guest,Room,Reservation,[Plan] where Guest.ID=Reservation.Guest_ID  and Room.R_ID=Reservation.RoomID and [Plan].P_Code=Room.PlanCode and GuestName like '%" & txtGuestName.Text & "%' Order by ReservationDate", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Reservation")
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            dgw.DataSource = myDataSet.Tables("Room").DefaultView
            dgw.DataSource = myDataSet.Tables("Reservation").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbRoomNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRoomNo.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(Reservation.Reserve_ID) as [Reservation ID],RTRIM(ReservationNo) as [Reservation No.],Convert(DateTime,ReservationDate,131), RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Room. RoomNo) as [Room No.],RTRIM(PlanCode) as [Plan Code],RTRIM(PlanName) as [Plan Name], RTRIM(Reservation.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out], RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(ExtraPersonCharges) as [Extra Person Charges], RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges], RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %], RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(SubTotal) as [Sub Total], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance], RTRIM(Reservation.Notes) as [Notes],RTRIM(Status) as [Status] from Guest,Room,Reservation,[Plan] where Guest.ID=Reservation.Guest_ID  and Room.R_ID=Reservation.RoomID and [Plan].P_Code=Room.PlanCode and Room.RoomNo=@d1 Order by ReservationDate", con)
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Reservation")
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            dgw.DataSource = myDataSet.Tables("Room").DefaultView
            dgw.DataSource = myDataSet.Tables("Reservation").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(Reservation.Reserve_ID) as [Reservation ID],RTRIM(ReservationNo) as [Reservation No.],Convert(DateTime,ReservationDate,131), RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Room. RoomNo) as [Room No.],RTRIM(PlanCode) as [Plan Code],RTRIM(PlanName) as [Plan Name], RTRIM(Reservation.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out], RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(ExtraPersonCharges) as [Extra Person Charges], RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges], RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %], RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(SubTotal) as [Sub Total], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance], RTRIM(Reservation.Notes) as [Notes],RTRIM(Status) as [Status] from Guest,Room,Reservation,[Plan] where Guest.ID=Reservation.Guest_ID  and Room.R_ID=Reservation.RoomID and [Plan].P_Code=Room.PlanCode and ReservationDate between @d1 and @d2 Order by ReservationDate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Reservation")
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            dgw.DataSource = myDataSet.Tables("Room").DefaultView
            dgw.DataSource = myDataSet.Tables("Reservation").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbStatus.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(Reservation.Reserve_ID) as [Reservation ID],RTRIM(ReservationNo) as [Reservation No.],Convert(DateTime,ReservationDate,131), RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Room. RoomNo) as [Room No.],RTRIM(PlanCode) as [Plan Code],RTRIM(PlanName) as [Plan Name], RTRIM(Reservation.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out], RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(ExtraPersonCharges) as [Extra Person Charges], RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges], RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %], RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(SubTotal) as [Sub Total], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance], RTRIM(Reservation.Notes) as [Notes],RTRIM(Status) as [Status] from Guest,Room,Reservation,[Plan] where Guest.ID=Reservation.Guest_ID  and Room.R_ID=Reservation.RoomID and [Plan].P_Code=Room.PlanCode and Status=@d1 Order by ReservationDate", con)
            cmd.Parameters.AddWithValue("@d1", cmbStatus.Text)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Reservation")
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            dgw.DataSource = myDataSet.Tables("Room").DefaultView
            dgw.DataSource = myDataSet.Tables("Reservation").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbRoomNo_Format(sender As System.Object, e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbRoomNo.Format
        If (e.DesiredType Is GetType(String)) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub

End Class
