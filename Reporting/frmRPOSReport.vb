Imports System.Data.SqlClient

Public Class frmRPOSReport
    Dim a, b As Decimal
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
            Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
            Dim ds As DataSet
            Dim adp, adp1, adp2, adp3, adp4 As SqlDataAdapter
            Dim dtable, dtable1, dtable2, dtable3, dtable4 As DataTable
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select Operator from RestaurantPOS_BillingInfoKOT where BillDate between @d1 and @d2 union select Operator from RestaurantPOS_BillingInfoTA where BillDate between @d1 and @d2 union select Operator from RestaurantPOS_BillingInfoHD where BillDate between @d1 and @d2"
            cmd5 = New SqlCommand(ct)
            cmd5.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd5.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value
            cmd5.Connection = con
            rdr = cmd5.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry..No record found between selected dates", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT * from Hotel", con)
            adp = New SqlDataAdapter(cmd)
            cmd1 = New SqlCommand("SELECT Operator,Sum(GrandTotal) as [GrandTotal] from(Select Operator,GrandTotal from RestaurantPOS_BillingInfoKOT where BillDate between @d1 and @d2 Union all Select Operator,GrandTotal from RestaurantPOS_BillingInfoTA where BillDate between @d1 and @d2 Union all Select Operator,GrandTotal from RestaurantPOS_BillingInfoHD where BillDate between @d1 and @d2)G  group by Operator order by 1", con)
            cmd1.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd1.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
            adp1 = New SqlDataAdapter(cmd1)
            cmd2 = New SqlCommand("SELECT Category,Sum(TotalAmount) as Total from (Select category,(TotalAmount) from RestaurantPOS_OrderedProductBillKOT,Dish, RestaurantPOS_BillingInfoKOT where RestaurantPOS_OrderedProductBillKOT.Dish=Dish.Dishname and RestaurantPOS_BillingInfoKOT.ID=RestaurantPOS_OrderedProductBillKOT.BillID and Billdate between @d3 and @d4 UNION ALL Select category,(TotalAmount) from RestaurantPOS_OrderedProductBillTA,Dish, RestaurantPOS_BillingInfoTA where RestaurantPOS_OrderedProductBillTA.Dish=Dish.Dishname and RestaurantPOS_BillingInfoTA.ID=RestaurantPOS_OrderedProductBillTA.BillID and Billdate between @d3 and @d4 UNION ALL Select category,(TotalAmount) from RestaurantPOS_OrderedProductBillHD,Dish, RestaurantPOS_BillingInfoHD where RestaurantPOS_OrderedProductBillHD.Dish=Dish.Dishname and RestaurantPOS_BillingInfoHD.ID=RestaurantPOS_OrderedProductBillHD.BillID and Billdate between @d3 and @d4)C group by Category order by 1", con)
            cmd2.Parameters.Add("@d3", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd2.Parameters.Add("@d4", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
            adp2 = New SqlDataAdapter(cmd2)
            cmd3 = New SqlCommand("SELECT Category,Sum(Quantity) as TotalQuantity from (Select category,Quantity from RestaurantPOS_OrderedProductBillKOT,Dish, RestaurantPOS_BillingInfoKOT where RestaurantPOS_OrderedProductBillKOT.Dish=Dish.Dishname and RestaurantPOS_BillingInfoKOT.ID=RestaurantPOS_OrderedProductBillKOT.BillID and Billdate between @d5 and @d6 UNION ALL Select category,Quantity from RestaurantPOS_OrderedProductBillTA,Dish, RestaurantPOS_BillingInfoTA where RestaurantPOS_OrderedProductBillTA.Dish=Dish.Dishname and RestaurantPOS_BillingInfoTA.ID=RestaurantPOS_OrderedProductBillTA.BillID and Billdate between @d5 and @d6 UNION ALL Select category,Quantity from RestaurantPOS_OrderedProductBillHD,Dish, RestaurantPOS_BillingInfoHD where RestaurantPOS_OrderedProductBillHD.Dish=Dish.Dishname and RestaurantPOS_BillingInfoHD.ID=RestaurantPOS_OrderedProductBillHD.BillID and Billdate between @d5 and @d6)C group by Category order by 1", con)
            cmd3.Parameters.Add("@d5", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd3.Parameters.Add("@d6", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
            adp3 = New SqlDataAdapter(cmd3)
            cmd4 = New SqlCommand("SELECT Dish,Sum(Quantity) as [Quantity],Sum(TotalAmount) as [Amount] from (Select Dish,Quantity,TotalAmount from RestaurantPOS_OrderedProductBillKOT,RestaurantPOS_BillingInfoKOT where BillDate between @d7 and @d8 and RestaurantPOS_BillingInfoKOT.ID=RestaurantPOS_OrderedProductBillKOT.BillID Union All Select Dish,Quantity,TotalAmount from RestaurantPOS_OrderedProductBillTA,RestaurantPOS_BillingInfoTA where BillDate between @d7 and @d8 and RestaurantPOS_BillingInfoTA.ID=RestaurantPOS_OrderedProductBillTA.BillID Union All Select Dish,Quantity,TotalAmount from RestaurantPOS_OrderedProductBillHD,RestaurantPOS_BillingInfoHD where BillDate between @d7 and @d8 and RestaurantPOS_BillingInfoHD.ID=RestaurantPOS_OrderedProductBillHD.BillID)G  group by Dish order by 1", con)
            cmd4.Parameters.Add("@d7", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd4.Parameters.Add("@d8", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
            adp4 = New SqlDataAdapter(cmd4)

            con = New SqlConnection(cs)
            con.Open()
            Dim ct1 As String = "select IsNull(Sum(HomeDeliveryCharges),0) from RestaurantPOS_BillingInfoHD where BillDate between @d9 and @d10"
            cmd = New SqlCommand(ct1)
            cmd.Parameters.Add("@d9", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d10", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                a = rdr.GetValue(0)
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ct2 As String = "select IsNull(Sum(ParcelCharges),0) from RestaurantPOS_BillingInfoTA where BillDate between @d11 and @d12"
            cmd = New SqlCommand(ct2)
            cmd.Parameters.Add("@d11", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d12", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                b = rdr.GetValue(0)
            End If
            con.Close()
            dtable = New DataTable()
            dtable1 = New DataTable()
            dtable2 = New DataTable()
            dtable3 = New DataTable()
            dtable4 = New DataTable()
            adp.Fill(dtable)
            adp1.Fill(dtable1)
            adp2.Fill(dtable2)
            adp3.Fill(dtable3)
            adp4.Fill(dtable4)
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.Tables.Add(dtable1)
            ds.Tables.Add(dtable2)
            ds.Tables.Add(dtable3)
            ds.Tables.Add(dtable4)
            ds.WriteXmlSchema("RPOS.xml")
            Dim rpt As New rptRPOS
            rpt.Subreports(0).SetDataSource(ds)
            rpt.Subreports(1).SetDataSource(ds)
            rpt.Subreports(2).SetDataSource(ds)
            rpt.Subreports(3).SetDataSource(ds)
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            rpt.SetParameterValue("p3", a)
            rpt.SetParameterValue("p4", b)
            rpt.SetParameterValue("p5", a)
            rpt.SetParameterValue("p6", b)
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

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ctX As String = "select Operator from RestaurantPOS_BillingInfoKOT where BillDate between @d1 and @d2 union select Operator from RestaurantPOS_BillingInfoTA where BillDate between @d1 and @d2"
            cmd = New SqlCommand(ctX)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry..No record found between selected dates", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptRestaurantPOS 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT RestaurantPOS_BillingInfoKOT.Id,PaymentMode,Operator, RestaurantPOS_BillingInfoKOT.BillNo, RestaurantPOS_BillingInfoKOT.BillDate, RestaurantPOS_BillingInfoKOT.GrandTotal, RestaurantPOS_BillingInfoKOT.Cash, RestaurantPOS_BillingInfoKOT.Change,RestaurantPOS_OrderedProductBillKOT.OP_ID, RestaurantPOS_OrderedProductBillKOT.BillID, RestaurantPOS_OrderedProductBillKOT.Dish,RestaurantPOS_OrderedProductBillKOT.Rate, RestaurantPOS_OrderedProductBillKOT.Quantity, RestaurantPOS_OrderedProductBillKOT.Amount,RestaurantPOS_OrderedProductBillKOT.VATPer, RestaurantPOS_OrderedProductBillKOT.VATAmount, RestaurantPOS_OrderedProductBillKOT.STPer, RestaurantPOS_OrderedProductBillKOT.STAmount,RestaurantPOS_OrderedProductBillKOT.DiscountPer, RestaurantPOS_OrderedProductBillKOT.DiscountAmount, RestaurantPOS_OrderedProductBillKOT.TotalAmount, RestaurantPOS_OrderedProductBillKOT.TableNo FROM RestaurantPOS_BillingInfoKOT INNER JOIN RestaurantPOS_OrderedProductBillKOT ON RestaurantPOS_BillingInfoKOT.Id = RestaurantPOS_OrderedProductBillKOT.BillID where BillDate between @d1 and @d2 order by BillDate"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "RestaurantPOS_BillingInfoKOT")
            myDA.Fill(myDS, "RestaurantPOS_OrderedProductBillKOT")
            myDA1.Fill(myDS, "Hotel")
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select IsNull(Sum(GrandTotal),0) from RestaurantPOS_BillingInfoKOT where BillDate between @d1 and @d2"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                a = rdr.GetValue(0)
            End While
            con.Close()
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            rpt.SetParameterValue("p3", a)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ctX As String = "select Operator from RestaurantPOS_BillingInfoTA where BillDate between @d1 and @d2"
            cmd = New SqlCommand(ctX)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry..No record found between selected dates", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptRestaurantPOSTA 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT RestaurantPOS_BillingInfoTA.Id,Operator,PaymentMode,ParcelCharges,SubTotal, RestaurantPOS_BillingInfoTA.BillNo, RestaurantPOS_BillingInfoTA.BillDate, RestaurantPOS_BillingInfoTA.GrandTotal, RestaurantPOS_BillingInfoTA.Cash, RestaurantPOS_BillingInfoTA.Change,RestaurantPOS_OrderedProductBillTA.OP_ID, RestaurantPOS_OrderedProductBillTA.BillID, RestaurantPOS_OrderedProductBillTA.Dish,RestaurantPOS_OrderedProductBillTA.Rate, RestaurantPOS_OrderedProductBillTA.Quantity, RestaurantPOS_OrderedProductBillTA.Amount,RestaurantPOS_OrderedProductBillTA.VATPer, RestaurantPOS_OrderedProductBillTA.VATAmount, RestaurantPOS_OrderedProductBillTA.STPer, RestaurantPOS_OrderedProductBillTA.STAmount,RestaurantPOS_OrderedProductBillTA.DiscountPer, RestaurantPOS_OrderedProductBillTA.DiscountAmount, RestaurantPOS_OrderedProductBillTA.TotalAmount FROM RestaurantPOS_BillingInfoTA INNER JOIN RestaurantPOS_OrderedProductBillTA ON RestaurantPOS_BillingInfoTA.Id = RestaurantPOS_OrderedProductBillTA.BillID where BillDate between @d1 and @d2 order by BillDate"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "RestaurantPOS_BillingInfoTA")
            myDA.Fill(myDS, "RestaurantPOS_OrderedProductBillTA")
            myDA1.Fill(myDS, "Hotel")
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select IsNull(Sum(GrandTotal),0) from RestaurantPOS_BillingInfoTA where BillDate between @d1 and @d2"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                a = rdr.GetValue(0)
            End While
            con.Close()
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            rpt.SetParameterValue("p3", a)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ctX As String = "select Operator from RestaurantPOS_BillingInfoHD where BillDate between @d1 and @d2"
            cmd = New SqlCommand(ctX)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry..No record found between selected dates", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptRestaurantPOSHD 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT RestaurantPOS_BillingInfoHD.Id, RestaurantPOS_BillingInfoHD.BillNo, RestaurantPOS_BillingInfoHD.BillDate, RestaurantPOS_BillingInfoHD.Operator, RestaurantPOS_BillingInfoHD.SubTotal,RestaurantPOS_BillingInfoHD.HomeDeliveryCharges, RestaurantPOS_BillingInfoHD.GrandTotal, RestaurantPOS_BillingInfoHD.CustomerName, RestaurantPOS_BillingInfoHD.Address,RestaurantPOS_BillingInfoHD.ContactNo, RestaurantPOS_BillingInfoHD.Employee_ID, RestaurantPOS_BillingInfoHD.PaymentMode, RestaurantPOS_OrderedProductBillHD.OP_ID, RestaurantPOS_OrderedProductBillHD.BillID, RestaurantPOS_OrderedProductBillHD.Dish, RestaurantPOS_OrderedProductBillHD.Rate, RestaurantPOS_OrderedProductBillHD.Quantity,RestaurantPOS_OrderedProductBillHD.Amount, RestaurantPOS_OrderedProductBillHD.VATPer, RestaurantPOS_OrderedProductBillHD.VATAmount, RestaurantPOS_OrderedProductBillHD.STPer,RestaurantPOS_OrderedProductBillHD.STAmount, RestaurantPOS_OrderedProductBillHD.DiscountPer, RestaurantPOS_OrderedProductBillHD.DiscountAmount,RestaurantPOS_OrderedProductBillHD.TotalAmount, RestaurantPOS_OrderedProductBillHD.Notes, DeliveryPerson.EmpId, DeliveryPerson.EmployeeID, DeliveryPerson.EmployeeName,DeliveryPerson.Address AS Expr1, DeliveryPerson.City, DeliveryPerson.ContactNo AS Expr2, DeliveryPerson.Email, DeliveryPerson.DateOfJoining, DeliveryPerson.Photo,DeliveryPerson.Active FROM RestaurantPOS_BillingInfoHD INNER JOIN RestaurantPOS_OrderedProductBillHD ON RestaurantPOS_BillingInfoHD.Id = RestaurantPOS_OrderedProductBillHD.BillID INNER JOIN DeliveryPerson ON RestaurantPOS_BillingInfoHD.Employee_ID = DeliveryPerson.EmpId where BillDate between @d1 and @d2 order by BillDate"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "RestaurantPOS_BillingInfoHD")
            myDA.Fill(myDS, "RestaurantPOS_OrderedProductBillHD")
            myDA.Fill(myDS, "DeliveryPerson")
            myDA1.Fill(myDS, "Hotel")
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select IsNull(Sum(GrandTotal),0) from RestaurantPOS_BillingInfoHD where BillDate between @d1 and @d2"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                a = rdr.GetValue(0)
            End While
            con.Close()
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            rpt.SetParameterValue("p3", a)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
