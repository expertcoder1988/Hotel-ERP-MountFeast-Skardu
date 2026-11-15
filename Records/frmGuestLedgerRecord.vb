Imports System.Data.SqlClient

Public Class frmGuestLedgerRecord

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("select RTRIM(GuestLedger.ID) as [ID], Convert(DateTime,date,131) as [Entry Date],RTRIM(Guest.ID) as [GID],RTRIM(Guest.GuestID) as [GuestID],RTRIM(GuestName) as [Guest Name],RTRIM(Amount) as [Amount] from GuestLedger,Guest where Guest.ID=GuestLedger.GuestID and Amount > 0 order by date", con)
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

    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                If lblSet.Text = "Guest Ledger" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    Me.Hide()
                    frmGuestBalanceEntry.Show()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmGuestBalanceEntry.txtID.Text = dr.Cells(0).Value.ToString()
                    frmGuestBalanceEntry.dtpEntryDate.Text = dr.Cells(1).Value.ToString()
                    frmGuestBalanceEntry.txtG_ID.Text = dr.Cells(2).Value.ToString()
                    frmGuestBalanceEntry.txtGuestID.Text = dr.Cells(3).Value.ToString()
                    frmGuestBalanceEntry.txtGuestName.Text = dr.Cells(4).Value.ToString()
                    frmGuestBalanceEntry.txtAmount.Text = dr.Cells(5).Value.ToString()
                    frmGuestBalanceEntry.btnSave.Enabled = False
                    frmGuestBalanceEntry.btnUpdate.Enabled = True
                    frmGuestBalanceEntry.btnDelete.Enabled = True
                    frmGuestBalanceEntry.dtpEntryDate.Enabled = False
                    frmGuestBalanceEntry.btnPrint.Enabled = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

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
            cmd = New SqlCommand("select RTRIM(GuestLedger.ID) as [ID], Convert(DateTime,date,131) as [Entry Date],RTRIM(Guest.ID) as [GID],RTRIM(Guest.GuestID) as [GuestID],RTRIM(GuestName) as [Guest Name],RTRIM(Amount) as [Amount] from GuestLedger,Guest where Guest.ID=GuestLedger.GuestID and Amount > 0 and GuestName like '%" & txtGuestName.Text & "%' order by date", con)
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
            cmd = New SqlCommand("select RTRIM(GuestLedger.ID) as [ID], Convert(DateTime,date,131) as [Entry Date],RTRIM(Guest.ID) as [GID],RTRIM(Guest.GuestID) as [GuestID],RTRIM(GuestName) as [Guest Name],RTRIM(Amount) as [Amount] from GuestLedger,Guest where Guest.ID=GuestLedger.GuestID and Amount > 0 and date Between @d1 and @d2 order by date", con)
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
