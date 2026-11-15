Imports System.Data.SqlClient
Public Class frmDebtorsReport

    Private Sub frmDebtorsReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select GuestID,GuestName,City,ContactNo,Sum(debit)-Sum(Credit) as [Balance] from Guest,LedgerBook where Guest.GuestID=LedgerBook.PartyID Group By GuestID,GuestName,City,ContactNo having (sum(debit)-sum(credit))> 0 order by GuestName", con)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("Debtors.xml")
            Dim rpt As New rptDebtors
            rpt.SetDataSource(ds)
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