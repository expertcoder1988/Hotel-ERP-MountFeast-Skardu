Imports System.Data.SqlClient
Public Class frmCurrentPayrollAdvanceReport

    Private Sub frmCurrentPayrollAdvanceReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT (EmployeeRegistration.EmployeeID),(EmployeeName),Designation,Department,IsNull(sum(Amount)-sum(Deduction),0) FROM EmployeeRegistration Inner join AdvanceEntry on EmployeeRegistration.ID=AdvanceEntry.EmployeeID group by employeename,employeeregistration.employeeid,Department,Designation having (sum(Amount)-sum(Deduction)) > 0  order by EmployeeName", con)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("CurrentPayrollAdvanceReport.xml")
            Dim rpt As New rptCurrentPayrollAdvance
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