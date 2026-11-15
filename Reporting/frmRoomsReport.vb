Imports System.Data.SqlClient
Public Class frmRoomsReport
    Private Sub frmRoomsReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptRoom 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT Room.R_ID, Room.RoomNo, Room.PlanCode, Room.RoomType, Room.RoomCharges, Room.MaxNoOfAdults, Room.MaxNoOfKids, Room.Active, [Plan].P_Code, [Plan].Planname, [Plan].Description FROM Room INNER JOIN [Plan] ON Room.PlanCode = [Plan].P_Code Order By Room.RoomNo"
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "Room")
            myDA.Fill(myDS, "Plan")
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