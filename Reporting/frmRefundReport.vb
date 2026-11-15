Imports System.Data.SqlClient


Public Class frmRefundReport

    Dim a, b, c, d, f, g, h, i As Decimal

    Sub Reset()
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Today
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub


    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT Reservation.ReservationDate, Reservation.ReservationNo, Guest.GuestName, Reservation.TotalPaid FROM Reservation INNER JOIN Guest ON Reservation.Guest_ID = Guest.ID WHERE (Reservation.Status = 'Cancelled') AND (Reservation.TotalPaid > 0) and ReservationDate between @d1 and @d2 UNION SELECT Reservation_Hall.BillDate, Reservation_Hall.BillNo, Guest_1.GuestName, Reservation_Hall.TotalPaid FROM Reservation_Hall INNER JOIN Guest AS Guest_1 ON Reservation_Hall.GuestID = Guest_1.ID WHERE (Reservation_Hall.Status = 'Cancelled') AND (Reservation_Hall.TotalPaid > 0) and BillDate between @d1 and @d2 UNION SELECT Reservation_Garden.BillDate, Reservation_Garden.BillNo, Guest_1.GuestName, Reservation_Garden.TotalPaid FROM Reservation_Garden INNER JOIN Guest AS Guest_1 ON Reservation_Garden.GuestID = Guest_1.ID WHERE (Reservation_Garden.Status = 'Cancelled') AND (Reservation_Garden.TotalPaid > 0) and BillDate between @d1 and @d2"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT Reservation.ReservationDate, Reservation.ReservationNo, Guest.GuestName, Reservation.TotalPaid FROM Reservation INNER JOIN Guest ON Reservation.Guest_ID = Guest.ID WHERE (Reservation.Status = 'Cancelled') AND (Reservation.TotalPaid > 0) and ReservationDate between @d1 and @d2 UNION SELECT Reservation_Hall.BillDate, Reservation_Hall.BillNo, Guest_1.GuestName, Reservation_Hall.TotalPaid FROM Reservation_Hall INNER JOIN Guest AS Guest_1 ON Reservation_Hall.GuestID = Guest_1.ID WHERE (Reservation_Hall.Status = 'Cancelled') AND (Reservation_Hall.TotalPaid > 0) and BillDate between @d1 and @d2 UNION SELECT Reservation_Garden.BillDate, Reservation_Garden.BillNo, Guest_1.GuestName, Reservation_Garden.TotalPaid FROM Reservation_Garden INNER JOIN Guest AS Guest_1 ON Reservation_Garden.GuestID = Guest_1.ID WHERE (Reservation_Garden.Status = 'Cancelled') AND (Reservation_Garden.TotalPaid > 0) and BillDate between @d1 and @d2 order by 2", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("RefundReport.xml")
            Dim rpt As New rptRefund
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmSalesReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
