Imports System.Data.SqlClient

Public Class frmGroupInv
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Cursor = Cursors.WaitCursor

        Dim rpt As New rptGroupRoomReservation 'The report you created.
        Dim myConnection As SqlConnection
        Dim MyCommand, MyCommand1, MyCommand2, MyCommand3, MyCommand4 As New SqlCommand()
        Dim myDA, myDA1, myDA2, myDA3, myDA4 As New SqlDataAdapter()
        Dim myDS As New DataSet 'The DataSet you created.
        Dim pdfFile As String = Application.StartupPath & "\Report.Pdf"
        myConnection = New SqlConnection(cs)
        MyCommand.Connection = myConnection
        MyCommand1.Connection = myConnection
        MyCommand2.Connection = myConnection
        MyCommand3.Connection = myConnection
        MyCommand4.Connection = myConnection
        MyCommand.CommandText = "SELECT Guest.ID, Guest.GuestID, Guest.GuestName, Guest.Address, Guest.City, Guest.Country, Guest.ContactNo, Guest.Gender, 
                Guest.Occupation, Guest.Religion, Guest.Email, Guest.IDType, Guest.IDNumber,Guest.Pic1, Guest.Pic2, Guest.pic3, Guest.Notes, Guest.Company, 
                Guest.Model, Guest.VehicleNo, Guest.Color, Reservation.Reserve_ID, Reservation.ReservationNo, Reservation.ReservationDate,Reservation.Guest_ID, 
                Reservation.RoomID, Reservation.RoomCharges, Reservation.DateIN, Reservation.DateOUT, Reservation.NoOfDays, Reservation.NoOfMales, 
                Reservation.NoOfFemales, Reservation.NoOfKids, Reservation.NoOfExtraBed, Reservation.NoOfExtraPerson, Reservation.ExtraPersonCharges, 
                Reservation.TotalRoomCharges, Reservation.ExtraBedCharges, Reservation.DiscountPer, Reservation.DiscountAmount, Reservation.STPer, 
                Reservation.STAmount, Reservation.LuxuryTaxPer, Reservation.LuxuryTaxAmount, Reservation.SubTotal, Reservation.GrandTotal, 
                Reservation.TotalPaid, Reservation.Balance FROM Guest INNER JOIN Reservation ON Guest.ID = Reservation.Guest_ID where 
                Reservation.Guest_ID=" & txtID.Text & " and Reservation.DateIN = '" & dtpDateIn.Value.ToShortDateString & "'"
        MyCommand1.CommandText = "SELECT * from Hotel"
        MyCommand2.CommandText = "SELECT * from Currency"
        MyCommand3.CommandText = "SELECT RoomType, count(roomtype) as NoOfRooms from Reservation r inner join Room r1 on r.roomid = r1.R_ID where r.Guest_ID=" & txtID.Text & " and r.DateIN = '" & dtpDateIn.Value.ToShortDateString & "' group by r1.roomtype"
        MyCommand4.CommandText = "SELECT r3.RoomNo as RoomNum, r2.* from    Reservation r1 INNER JOIN
                        Reservation_Details r2 ON r1.Reserve_ID = r2.Reserve_ID INNER JOIN
                      Room r3 ON r2.RoomID = r3.R_ID  where Guest_ID = " & txtID.Text & " and CONVERT(date,DateIN) = '" & dtpDateIn.Value.ToShortDateString & "'"
        MyCommand3.CommandType = CommandType.Text
        MyCommand4.CommandType = CommandType.Text
        MyCommand.CommandType = CommandType.Text
        MyCommand1.CommandType = CommandType.Text
        MyCommand2.CommandType = CommandType.Text
        MyCommand4.CommandType = CommandType.Text
        myDA.SelectCommand = MyCommand
        myDA1.SelectCommand = MyCommand1
        myDA2.SelectCommand = MyCommand2
        myDA3.SelectCommand = MyCommand3
        myDA4.SelectCommand = MyCommand4
        myDA.Fill(myDS, "Guest")
        myDA.Fill(myDS, "Room")
        myDA.Fill(myDS, "Reservation")
        myDA1.Fill(myDS, "Hotel")
        myDA2.Fill(myDS, "Currency")
        myDA3.Fill(myDS, "RoomTypes")
        myDA4.Fill(myDS, "Reservation_Details")
        rpt.SetDataSource(myDS)
        frmReport.CrystalReportViewer1.ReportSource = rpt
        frmReport.ShowDialog()
        frmReport.CrystalReportViewer1.Refresh()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        frmGuestRecord1.lblSet.Text = "Group Invoice"
        frmGuestRecord1.Reset()
        frmGuestRecord1.Show()
        txtID.Text = False
    End Sub
End Class