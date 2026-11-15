Imports System.Data.SqlClient

Public Class frmLaundryBillingReport
    Dim a As Decimal
    Sub Reset()
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Now
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim cmd, cmd1, cmd2 As SqlCommand
            Dim ds As DataSet
            Dim adp, adp1 As SqlDataAdapter
            Dim dtable, dtable1 As DataTable
            con = New SqlConnection(cs)
            con.Open()
            cmd2 = New SqlCommand("SELECT * from Hotel", con)
            adp = New SqlDataAdapter(cmd2)
            cmd1 = New SqlCommand("SELECT Guest.GuestID, Guest.GuestName,PaymentMode,Laundry_BillInfo.BillNo, Laundry_BillInfo.BillDate, Laundry_BillInfo.CheckInID, Laundry_BillInfo.GrandTotal, Laundry_BillInfo.TotalPayment, Laundry_BillInfo.PaymentDue, LaundryServices.LS_Id, LaundryServices.BillID, LaundryServices.Service, LaundryServices.Rate, LaundryServices.Qty, LaundryServices.TotalAmount, Laundry_Master.ServiceName,Laundry_Master.ChargesPerUnit, CheckIN_Room.Cin_Id, CheckIN_Room.RoomID,CheckIn_Room.DateIn,CheckIN_Room.DateOut, CheckIN_Room.Notes, Guest.Address, Guest.City, Guest.ContactNo,Room.RoomNo, Room.RoomType, Room.RoomCharges AS Expr6 FROM Laundry_BillInfo INNER JOIN LaundryServices ON Laundry_BillInfo.Id = LaundryServices.BillID INNER JOIN Laundry_Master ON LaundryServices.Service = Laundry_Master.ServiceName INNER JOIN CheckIN_Room ON Laundry_BillInfo.CheckInID = CheckIN_Room.Cin_Id INNER JOIN Guest ON CheckIN_Room.GuestID = Guest.ID INNER JOIN Room ON CheckIN_Room.RoomID = Room.R_ID and BillDate >=@d1 and BillDate < @d2 order by BillDate", con)
            cmd1.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd1.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            adp1 = New SqlDataAdapter(cmd1)
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select IsNull(Sum(GrandTotal),0) from Laundry_BillInfo where BillDate >=@d1 and BillDate < @d2"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                a = rdr.GetValue(0)
            End While
            con.Close()
            dtable = New DataTable()
            dtable1 = New DataTable()
            adp.Fill(dtable)
            adp1.Fill(dtable1)
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.Tables.Add(dtable1)
            ds.WriteXmlSchema("LaundryBillingReport1.xml")
            Dim rpt As New rptLaundryBilling
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            rpt.SetParameterValue("p3", a)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub
End Class
