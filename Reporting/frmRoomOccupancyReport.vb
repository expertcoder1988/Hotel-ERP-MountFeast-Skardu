Imports System.Data.SqlClient
Public Class frmRoomOccupancyReport

    Private Sub frmReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT DISTINCT Room.RoomType, Room.RoomNo, CheckIN_Room.Cin_Id, Guest.GuestName, Guest.Occupation, CheckIN_Room.DateIN, CheckIN_Room.DateOUT, CheckIN_Room.Status FROM Room LEFT OUTER JOIN CheckIN_Room ON Room.R_ID = CheckIN_Room.RoomID LEFT OUTER JOIN Guest ON CheckIN_Room.GuestID = Guest.ID WHERE (CheckIN_Room.Status = 'Check In') OR (CheckIN_Room.Status IS NULL) ORDER BY Room.RoomNo", con)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("RoomOccupancyReport.xml")
            Dim rpt As New rptRoomOccupancy
            rpt.SetDataSource(ds)
            Me.CrystalReportViewer1.ReportSource = rpt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

 
End Class