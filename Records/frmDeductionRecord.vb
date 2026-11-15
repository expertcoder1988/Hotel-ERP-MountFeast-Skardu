Imports System.Data.SqlClient

Public Class frmDeductionRecord

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Public Sub GetData()
        Try
            Total.Visible = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("select RTRIM(AdvanceEntry.ID) as [ID], Convert(DateTime,workingdate,131) as [Entry Date],RTRIM(EmployeeRegistration.ID) as [Emp ID],RTRIM(EmployeeRegistration.EmployeeID) as [Employee ID],RTRIM(EmployeeName) as [Employee Name],RTRIM(Deduction) as [Deduction] from Advanceentry,employeeRegistration where EmployeeRegistration.ID=AdvanceEntry.EmployeeID and Deduction > 0 order by workingdate", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "AdvanceEntry")
            myDA.Fill(myDataSet, "EmployeeRegistration")
            dgw.DataSource = myDataSet.Tables("AdvanceEntry").DefaultView
            dgw.DataSource = myDataSet.Tables("EmployeeRegistration").DefaultView
            Dim sum As Double = 0
            For Each r As DataGridViewRow In Me.dgw.Rows
                sum = sum + r.Cells(5).Value
            Next
            sum = Math.Round(sum, 2)
            TotalAdvance.Text = sum
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
    End Sub
    Sub Reset()
        txtEmployeeName.Text = ""
        DateFrom.Text = Today
        DateTo.Text = Now
        Total.Visible = False
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

    Private Sub dgw_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub txtEmployeeName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtEmployeeName.TextChanged
        Try
            Total.Visible = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("select RTRIM(AdvanceEntry.ID) as [ID], Convert(DateTime,workingdate,131) as [Entry Date],RTRIM(EmployeeRegistration.ID) as [Emp ID],RTRIM(EmployeeRegistration.EmployeeID) as [Employee ID],RTRIM(EmployeeName) as [Employee Name],RTRIM(Deduction) as [Deduction] from Advanceentry,employeeRegistration where EmployeeRegistration.ID=AdvanceEntry.EmployeeID and Deduction > 0 and EmployeeName like '%" & txtEmployeeName.Text & "%' order by workingdate", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "AdvanceEntry")
            myDA.Fill(myDataSet, "EmployeeRegistration")
            dgw.DataSource = myDataSet.Tables("AdvanceEntry").DefaultView
            dgw.DataSource = myDataSet.Tables("EmployeeRegistration").DefaultView
            Dim sum As Double = 0
            For Each r As DataGridViewRow In Me.dgw.Rows
                sum = sum + r.Cells(5).Value
            Next
            sum = Math.Round(sum, 2)
            TotalAdvance.Text = sum
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            Total.Visible = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("select RTRIM(AdvanceEntry.ID) as [ID], Convert(DateTime,workingdate,131) as [Entry Date],RTRIM(EmployeeRegistration.ID) as [Emp ID],RTRIM(EmployeeRegistration.EmployeeID) as [Employee ID],RTRIM(EmployeeName) as [Employee Name],RTRIM(Deduction) as [Deduction] from Advanceentry,employeeRegistration where EmployeeRegistration.ID=AdvanceEntry.EmployeeID and Deduction > 0 and WorkingDate Between @d1 and @d2 order by workingdate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = DateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = DateTo.Value
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "AdvanceEntry")
            myDA.Fill(myDataSet, "EmployeeRegistration")
            dgw.DataSource = myDataSet.Tables("AdvanceEntry").DefaultView
            dgw.DataSource = myDataSet.Tables("EmployeeRegistration").DefaultView
            Dim sum As Double = 0
            For Each r As DataGridViewRow In Me.dgw.Rows
                sum = sum + r.Cells(5).Value
            Next
            sum = Math.Round(sum, 2)
            TotalAdvance.Text = sum
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
