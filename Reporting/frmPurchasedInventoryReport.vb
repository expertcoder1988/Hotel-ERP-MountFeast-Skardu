Imports System.Data.SqlClient

Public Class frmPurchasedInventoryReport
    Dim a As Decimal
    Sub Reset()
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Now
        cmbSupplierName.Text = ""
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
            Try
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
            Dim rpt As New rptPurchase 'The report you created.
                Dim myConnection As SqlConnection
                Dim MyCommand, MyCommand1, MyCommand2 As New SqlCommand()
                Dim myDA, myDA1, myDA2 As New SqlDataAdapter()
                Dim myDS As New DataSet 'The DataSet you created.
                myConnection = New SqlConnection(cs)
                MyCommand.Connection = myConnection
                MyCommand1.Connection = myConnection
                MyCommand2.Connection = myConnection
            MyCommand.CommandText = "SELECT Supplier.ID, Supplier.Name, Supplier.Address, Supplier.City, Supplier.State, Supplier.ZipCode, Supplier.ContactNo, Supplier.EmailID, Supplier.Remarks, Purchase.ST_ID, Purchase.InvoiceNo,Purchase.Date, Purchase.PurchaseType, Purchase.SupplierID, Purchase.SubTotal, Purchase.DiscountPer, Purchase.Discount, Purchase.PreviousDue, Purchase.FreightCharges, Purchase.OtherCharges,Purchase.Total, Purchase.RoundOff, Purchase.GrandTotal, Purchase.TotalPayment, Purchase.PaymentDue, Purchase.Remarks AS Expr2, Purchase_Join.SP_ID, Purchase_Join.PurchaseID,Purchase_Join.Productname, Purchase_Join.Qty, Purchase_Join.Unit, Purchase_Join.Price, Purchase_Join.TotalAmount FROM Supplier INNER JOIN Purchase ON Supplier.ID = Purchase.SupplierID INNER JOIN Purchase_Join ON Purchase.ST_ID = Purchase_Join.PurchaseID where Purchase.date between @d1 and @d2 order by Purchase.Date"
                MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
                MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date
                MyCommand1.CommandText = "SELECT * from Hotel"
                MyCommand2.CommandText = "SELECT * from Currency"
                MyCommand.CommandType = CommandType.Text
                MyCommand1.CommandType = CommandType.Text
                MyCommand2.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA1.SelectCommand = MyCommand1
                myDA2.SelectCommand = MyCommand2
            myDA.Fill(myDS, "Purchase")
            myDA.Fill(myDS, "Purchase_Join")
            myDA.Fill(myDS, "Supplier")
                myDA1.Fill(myDS, "Hotel")
                myDA2.Fill(myDS, "Currency")
                rpt.SetDataSource(myDS)
            rpt.SetParameterValue("P1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("P2", dtpDateTo.Value.Date)
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
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptPurchase 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1, MyCommand2 As New SqlCommand()
            Dim myDA, myDA1, myDA2 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand2.Connection = myConnection
            MyCommand.CommandText = "SELECT Supplier.ID, Supplier.Name, Supplier.Address, Supplier.City, Supplier.State, Supplier.ZipCode, Supplier.ContactNo, Supplier.EmailID, Supplier.Remarks, Purchase.ST_ID, Purchase.InvoiceNo,Purchase.Date, Purchase.PurchaseType, Purchase.SupplierID, Purchase.SubTotal, Purchase.DiscountPer, Purchase.Discount, Purchase.PreviousDue, Purchase.FreightCharges, Purchase.OtherCharges,Purchase.Total, Purchase.RoundOff, Purchase.GrandTotal, Purchase.TotalPayment, Purchase.PaymentDue, Purchase.Remarks AS Expr2, Purchase_Join.SP_ID, Purchase_Join.PurchaseID,Purchase_Join.Productname, Purchase_Join.Qty, Purchase_Join.Unit, Purchase_Join.Price, Purchase_Join.TotalAmount FROM Supplier INNER JOIN Purchase ON Supplier.ID = Purchase.SupplierID INNER JOIN Purchase_Join ON Purchase.ST_ID = Purchase_Join.PurchaseID where Name=@d1 order by Purchase.Date"
            MyCommand.Parameters.AddWithValue("@d1", cmbSupplierName.Text)
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand2.CommandText = "SELECT * from Currency"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            MyCommand2.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA2.SelectCommand = MyCommand2
            myDA.Fill(myDS, "Purchase")
            myDA.Fill(myDS, "Purchase_Join")
            myDA.Fill(myDS, "Supplier")
            myDA1.Fill(myDS, "Hotel")
            myDA2.Fill(myDS, "Currency")
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("P1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("P2", dtpDateTo.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillCombo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Name) FROM Supplier,Purchase where Supplier.ID=Purchase.SupplierID", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbSupplierName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbSupplierName.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmPurchasedInventoryReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        fillCombo()
    End Sub
End Class
