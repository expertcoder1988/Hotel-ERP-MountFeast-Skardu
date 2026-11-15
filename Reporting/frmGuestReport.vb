Imports System.Data.SqlClient

Public Class frmGuestReport
    Sub fillBilllNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(GuestName) FROM Guest", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbGuestName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbGuestName.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillBilllNo()
    End Sub
    Sub Reset()
        cmbGuestName.Text = ""
        fillBilllNo()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub


    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Len(Trim(cmbGuestName.Text)) = 0 Then
                MessageBox.Show("Please select guest name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbGuestName.Focus()
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptGuest 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT Guest.GuestName,Guest.Country, Guest.Address, Guest.City, Guest.ContactNo, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.IDType, Guest.IDNumber, Guest.Notes, Guest_Docs.Id,Guest_Docs.Image1, Guest_Docs.Image2, Guest_Docs.Image3 FROM Guest INNER JOIN Guest_Docs ON Guest.ID = Guest_Docs.GuestID where Guest.GuestName=@d1"
            MyCommand.Parameters.AddWithValue("@d1", cmbGuestName.Text)
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "Guest")
            myDA.Fill(myDS, "Guest_Docs")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub cmbGuestName_Format(sender As System.Object, e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbGuestName.Format
        If (e.DesiredType Is GetType(String)) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Try
           
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT (Guest.guestID),(GuestName),City,ContactNo,IsNull(sum(Amount)-sum(Deduction),0) as [Balance] FROM Guest left join GuestLedger on Guest.ID=GuestLedger.guestID group by guestname,Guest.guestid,City,ContactNo having((sum(Amount)-sum(Deduction))>0) order by guestName", con)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("GuestCurrentBalanceReport.xml")
            Dim rpt As New rptGuestBalance
            rpt.SetDataSource(ds)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Try
            If Len(Trim(cmbGuestName.Text)) = 0 Then
                MessageBox.Show("Please select guest name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbGuestName.Focus()
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Guest.GuestID,GuestName,City,ContactNo,Date,Amount,Deduction,Details From Guest,GuestLedger where Guest.ID=GuestLedger.GuestID and GuestName=@d1", con)
            cmd.Parameters.AddWithValue("@d1", cmbGuestName.Text)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("GuestAccountLedgerReport.xml")
            Dim rpt As New rptGuestAccountLedger
            rpt.SetDataSource(ds)
            frmGuestAccountLedgerReport.CrystalReportViewer1.ReportSource = rpt
            frmGuestAccountLedgerReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
