Imports System.Data.SqlClient

Public Class frmGuestLedgerRecord1

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Public Sub GetData()
        Try

            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("select RTRIM(GuestLedger.ID) as [ID], Convert(DateTime,date,131) as [Entry Date],RTRIM(Guest.GuestID) as [GuestID],RTRIM(GuestName) as [Guest Name],RTRIM(Amount) as [Amount],RTRIM(Deduction) as [Deduction],RTRIM(Details) as [Details] from GuestLedger,Guest where Guest.ID=GuestLedger.GuestID  order by date", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "GuestLedger")
            myDA.Fill(myDataSet, "Guest")
            dgw.DataSource = myDataSet.Tables("GuestLedger").DefaultView
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
    End Sub
    Sub Reset()
        txtGuestName.Text = ""
        DateFrom.Text = Today
        DateTo.Text = Now
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

    Private Sub txtGuestName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtGuestName.TextChanged
        Try

            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("select RTRIM(GuestLedger.ID) as [ID], Convert(DateTime,date,131) as [Entry Date],RTRIM(Guest.GuestID) as [GuestID],RTRIM(GuestName) as [Guest Name],RTRIM(Amount) as [Amount],RTRIM(Deduction) as [Deduction],RTRIM(Details) as [Details] from GuestLedger,Guest where Guest.ID=GuestLedger.GuestID  and GuestName like '%" & txtGuestName.Text & "%' order by date", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "GuestLedger")
            myDA.Fill(myDataSet, "Guest")
            dgw.DataSource = myDataSet.Tables("GuestLedger").DefaultView
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("select RTRIM(GuestLedger.ID) as [ID], Convert(DateTime,date,131) as [Entry Date],RTRIM(Guest.GuestID) as [GuestID],RTRIM(GuestName) as [Guest Name],RTRIM(Amount) as [Amount],RTRIM(Deduction) as [Deduction],RTRIM(Details) as [Details] from GuestLedger,Guest where Guest.ID=GuestLedger.GuestID  and date Between @d1 and @d2 order by date", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = DateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = DateTo.Value
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "GuestLedger")
            myDA.Fill(myDataSet, "Guest")
            dgw.DataSource = myDataSet.Tables("GuestLedger").DefaultView
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
