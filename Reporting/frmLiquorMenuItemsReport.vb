Imports System.Data.SqlClient
Public Class frmLiquorMenuItemsReport
    Private Sub frmLiquorMenuItemsReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptLiquorMenuItems 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT Category_Liquor.CategoryName, Category_Liquor.VAT, Category_Liquor.ST, Liquor.LiquorName, Liquor.Category, Liquor.Discount, Liquor_Rate.Id, Liquor_Rate.LiquorName AS Expr1, Liquor_Rate.Quantity,Liquor_Rate.Rate FROM Category_Liquor INNER JOIN Liquor ON Category_Liquor.CategoryName = Liquor.Category INNER JOIN Liquor_Rate ON Liquor.LiquorName = Liquor_Rate.LiquorName order By CategoryName,Liquor.LiquorName"
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "Category_Liquor")
            myDA.Fill(myDS, "Liquor")
            myDA.Fill(myDS, "Liquor_Rate")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            CrystalReportViewer1.ReportSource = rpt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub
End Class