
Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.SqlServer.Management.Smo

Public Class frmMainMenu

    Dim Filename As String

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAboutBox1.ShowDialog()
    End Sub


    Private Sub NotePadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotePadToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Notepad.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function HandleRegistry() As Boolean
        Dim firstRunDate As Date
        Dim st As Date = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\HMSSoft", "Set", Nothing)
        firstRunDate = st
        If firstRunDate = Nothing Then
            firstRunDate = System.DateTime.Today.Date
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\HMSSoft", "Set", firstRunDate)
        ElseIf (Now - firstRunDate).Days > 1365 Then
            Return False
        End If
        Return True
    End Function
    Private Sub main_form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dtpDateOut.Text = Today.AddDays(30)
            Dim result As Boolean = HandleRegistry()
            If result = False Then 'something went wrong
                MessageBox.Show("Trial expired" & vbCrLf & "for purchasing the full version of software contact us at 111-77-88-00 / info@growbiztech.com Or Visit https://growbiztech.com/", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End
            End If

            If lblUser.Text = "superadmin" Then
                Me.LicenseToolStripMenuItem.Visible = False
            End If

            If lblUserType.Text = "Cashier" Then
                Me.SearchRecordsToolStripMenuItem.Enabled = False
                POSToolStripMenuItem.Enabled = True
                Me.DataEntryToolStripMenuItem.Enabled = False
                Me.TransactionToolStripMenuItem.Enabled = False
                Me.UsersToolStripMenuItem.Enabled = False
                Me.MasterEntryToolStripMenuItem.Enabled = False
                Me.LogsToolStripMenuItem1.Enabled = False
                Me.ChatToolStripMenuItem1.Enabled = True
                Me.ReservationToolStripMenuItem.Enabled = False
                Me.CheckInToolStripMenuItem.Enabled = False
                Me.GuestToolStripMenuItem1.Enabled = False
                Me.StockToolStripMenuItem1.Enabled = False
                Me.OrderToolStripMenuItem.Enabled = True
                Me.RestaurantBillingToolStripMenuItem.Enabled = True
                Me.CheckOutToolStripMenuItem.Enabled = False
                Me.EmployeeToolStripMenuItem1.Enabled = False
                Me.AdvanceEntryToolStripMenuItem1.Enabled = False
                Me.AttendanceToolStripMenuItem2.Enabled = False
                Me.PaymentToolStripMenuItem1.Enabled = False
                SmsToolStripMenuItem1.Enabled = False
                Me.dgw.Enabled = False
                Me.DataGridView1.Enabled = False
                Me.DataGridView2.Enabled = False
                Me.DataGridView3.Enabled = False
                Me.DatabaseToolStripMenuItem.Enabled = False
                Me.btnSearch.Enabled = False
                Me.btnReset.Enabled = False
                Me.GroupBox2.Enabled = False
                Me.GroupBox1.Enabled = False
                Me.ReportsToolStripMenuItem.Enabled = False
                RestaurantBillingToolStripMenuItem.Enabled = True
                LaundryBillingToolStripMenuItem1.Enabled = True
                AdditionalReportsToolStripMenuItem.Enabled = False
            End If
            If (lblUserType.Text = "Admin") Then
                Me.SearchRecordsToolStripMenuItem.Enabled = True
                POSToolStripMenuItem.Enabled = True
                Me.DataEntryToolStripMenuItem.Enabled = True
                Me.TransactionToolStripMenuItem.Enabled = True
                Me.UsersToolStripMenuItem.Enabled = True
                SmsToolStripMenuItem1.Enabled = True
                Me.MasterEntryToolStripMenuItem.Enabled = True
                Me.LogsToolStripMenuItem1.Enabled = True
                Me.ChatToolStripMenuItem1.Enabled = True
                Me.ReservationToolStripMenuItem.Enabled = True
                Me.CheckInToolStripMenuItem.Enabled = True
                Me.GuestToolStripMenuItem1.Enabled = True
                Me.StockToolStripMenuItem1.Enabled = True
                Me.OrderToolStripMenuItem.Enabled = True
                Me.RestaurantBillingToolStripMenuItem.Enabled = True
                Me.CheckOutToolStripMenuItem.Enabled = True
                Me.EmployeeToolStripMenuItem1.Enabled = True
                Me.AdvanceEntryToolStripMenuItem1.Enabled = True
                Me.AttendanceToolStripMenuItem2.Enabled = True
                Me.PaymentToolStripMenuItem1.Enabled = True
                Me.dgw.Enabled = True
                Me.DataGridView1.Enabled = True
                Me.DataGridView2.Enabled = True
                Me.DataGridView3.Enabled = True
                Me.DatabaseToolStripMenuItem.Enabled = True
                Me.btnSearch.Enabled = True
                Me.btnReset.Enabled = True
                Me.ReportsToolStripMenuItem.Enabled = True
                Me.GroupBox2.Enabled = True
                Me.GroupBox1.Enabled = True
                RestaurantBillingToolStripMenuItem.Enabled = True
                LaundryBillingToolStripMenuItem1.Enabled = True
                AdditionalReportsToolStripMenuItem.Enabled = True
            End If
            If (lblUserType.Text = "Store Manager") Then
                Me.SearchRecordsToolStripMenuItem.Enabled = True
                POSToolStripMenuItem.Enabled = True
                Me.DataEntryToolStripMenuItem.Enabled = True
                Me.TransactionToolStripMenuItem.Enabled = True
                Me.UsersToolStripMenuItem.Enabled = True
                SmsToolStripMenuItem1.Enabled = True
                Me.MasterEntryToolStripMenuItem.Enabled = True
                Me.LogsToolStripMenuItem1.Enabled = True
                Me.ChatToolStripMenuItem1.Enabled = True
                Me.ReservationToolStripMenuItem.Enabled = True
                Me.CheckInToolStripMenuItem.Enabled = True
                Me.GuestToolStripMenuItem1.Enabled = True
                Me.StockToolStripMenuItem1.Enabled = True
                Me.OrderToolStripMenuItem.Enabled = True
                Me.RestaurantBillingToolStripMenuItem.Enabled = True
                Me.CheckOutToolStripMenuItem.Enabled = True
                Me.EmployeeToolStripMenuItem1.Enabled = True
                Me.AdvanceEntryToolStripMenuItem1.Enabled = True
                Me.AttendanceToolStripMenuItem2.Enabled = True
                Me.PaymentToolStripMenuItem1.Enabled = True
                Me.dgw.Enabled = True
                Me.DataGridView1.Enabled = True
                Me.DataGridView2.Enabled = True
                Me.DataGridView3.Enabled = True
                Me.DatabaseToolStripMenuItem.Enabled = True
                Me.btnSearch.Enabled = True
                Me.btnReset.Enabled = True
                Me.ReportsToolStripMenuItem.Enabled = True
                Me.GroupBox2.Enabled = True
                Me.GroupBox1.Enabled = True
                RestaurantBillingToolStripMenuItem.Enabled = True
                LaundryBillingToolStripMenuItem1.Enabled = True
                AdditionalReportsToolStripMenuItem.Enabled = True
            End If
            If (lblUserType.Text = "Finance Manager") Then
                Me.SearchRecordsToolStripMenuItem.Enabled = True
                POSToolStripMenuItem.Enabled = False
                Me.DataEntryToolStripMenuItem.Enabled = True
                Me.TransactionToolStripMenuItem.Enabled = True
                Me.UsersToolStripMenuItem.Enabled = False
                SmsToolStripMenuItem1.Enabled = True
                Me.MasterEntryToolStripMenuItem.Enabled = False
                Me.LogsToolStripMenuItem1.Enabled = False
                Me.ChatToolStripMenuItem1.Enabled = True
                Me.ReservationToolStripMenuItem.Enabled = False
                Me.CheckInToolStripMenuItem.Enabled = False
                Me.GuestToolStripMenuItem1.Enabled = False
                Me.StockToolStripMenuItem1.Enabled = True
                Me.OrderToolStripMenuItem.Enabled = False
                Me.RestaurantBillingToolStripMenuItem.Enabled = False
                Me.CheckOutToolStripMenuItem.Enabled = False
                Me.EmployeeToolStripMenuItem1.Enabled = False
                Me.AdvanceEntryToolStripMenuItem1.Enabled = True
                Me.AttendanceToolStripMenuItem2.Enabled = True
                Me.PaymentToolStripMenuItem1.Enabled = True
                Me.dgw.Enabled = False
                Me.DataGridView1.Enabled = False
                Me.DataGridView2.Enabled = False
                Me.DataGridView3.Enabled = False
                Me.DatabaseToolStripMenuItem.Enabled = False
                Me.btnSearch.Enabled = False
                Me.btnReset.Enabled = False
                Me.ReportsToolStripMenuItem.Enabled = True
                Me.GroupBox2.Enabled = False
                Me.GroupBox1.Enabled = False
                RestaurantBillingToolStripMenuItem.Enabled = False
                LaundryBillingToolStripMenuItem1.Enabled = False
                AdditionalReportsToolStripMenuItem.Enabled = True
            End If
            If lblUserType.Text = "Receptionist" Then
                Me.SearchRecordsToolStripMenuItem.Enabled = False
                POSToolStripMenuItem.Enabled = True
                Me.DataEntryToolStripMenuItem.Enabled = False
                Me.TransactionToolStripMenuItem.Enabled = False
                Me.UsersToolStripMenuItem.Enabled = False
                Me.MasterEntryToolStripMenuItem.Enabled = False
                Me.LogsToolStripMenuItem1.Enabled = False
                Me.ChatToolStripMenuItem1.Enabled = True
                Me.ReservationToolStripMenuItem.Enabled = True
                Me.CheckInToolStripMenuItem.Enabled = True
                Me.GuestToolStripMenuItem1.Enabled = True
                Me.StockToolStripMenuItem1.Enabled = True
                SmsToolStripMenuItem1.Enabled = True
                Me.ReportsToolStripMenuItem.Enabled = True
                Me.OrderToolStripMenuItem.Enabled = True
                Me.RestaurantBillingToolStripMenuItem.Enabled = True
                Me.CheckOutToolStripMenuItem.Enabled = True
                Me.EmployeeToolStripMenuItem1.Enabled = False
                Me.AdvanceEntryToolStripMenuItem1.Enabled = False
                Me.AttendanceToolStripMenuItem2.Enabled = True
                Me.PaymentToolStripMenuItem1.Enabled = False
                Me.dgw.Enabled = True
                Me.DataGridView1.Enabled = True
                Me.DataGridView2.Enabled = True
                Me.DataGridView3.Enabled = True
                Me.DatabaseToolStripMenuItem.Enabled = False
                Me.btnSearch.Enabled = True
                Me.btnReset.Enabled = True
                Me.ReportsToolStripMenuItem.Enabled = True
                Me.GroupBox2.Enabled = True
                Me.GroupBox1.Enabled = True
                RestaurantBillingToolStripMenuItem.Enabled = True
                LaundryBillingToolStripMenuItem1.Enabled = True
                AdditionalReportsToolStripMenuItem.Enabled = True
            End If
            If (lblUserType.Text = "Store Keeper") Then
                Me.SearchRecordsToolStripMenuItem.Enabled = False
                POSToolStripMenuItem.Enabled = False
                Me.DataEntryToolStripMenuItem.Enabled = False
                Me.TransactionToolStripMenuItem.Enabled = False
                Me.UsersToolStripMenuItem.Enabled = False
                SmsToolStripMenuItem1.Enabled = False
                Me.MasterEntryToolStripMenuItem.Enabled = False
                Me.LogsToolStripMenuItem1.Enabled = False
                Me.ChatToolStripMenuItem1.Enabled = True
                Me.ReservationToolStripMenuItem.Enabled = False
                Me.CheckInToolStripMenuItem.Enabled = False
                Me.GuestToolStripMenuItem1.Enabled = False
                Me.StockToolStripMenuItem1.Enabled = True
                Me.OrderToolStripMenuItem.Enabled = False
                Me.RestaurantBillingToolStripMenuItem.Enabled = False
                Me.CheckOutToolStripMenuItem.Enabled = False
                Me.EmployeeToolStripMenuItem1.Enabled = False
                Me.AdvanceEntryToolStripMenuItem1.Enabled = False
                Me.AttendanceToolStripMenuItem2.Enabled = False
                Me.PaymentToolStripMenuItem1.Enabled = False
                Me.dgw.Enabled = False
                Me.DataGridView1.Enabled = False
                Me.DataGridView2.Enabled = False
                Me.DataGridView3.Enabled = False
                Me.DatabaseToolStripMenuItem.Enabled = False
                Me.btnSearch.Enabled = False
                Me.btnReset.Enabled = False
                Me.ReportsToolStripMenuItem.Enabled = False
                Me.GroupBox2.Enabled = False
                Me.GroupBox1.Enabled = False
                RestaurantBillingToolStripMenuItem.Enabled = False
                LaundryBillingToolStripMenuItem1.Enabled = False
                AdditionalReportsToolStripMenuItem.Enabled = False
            End If
            Me.Refresh()
            GetData()
            lblDateTime.Text = Now
            lblUser.Text = frmLogin.UserID.Text
            DataGridView1.ClearSelection()
            DataGridView2.ClearSelection()
            DataGridView3.ClearSelection()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SystemInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemInfoToolStripMenuItem.Click
        frmSystemInfo.ShowDialog()
    End Sub

    Private Sub CalculatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculatorToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Calc.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EmployeeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmEmployeesRecord.Show()
    End Sub


    Private Sub AttendanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttendanceToolStripMenuItem.Click
        frmAttendance.lblUser.Text = lblUser.Text
        frmAttendance.Reset()
        frmAttendance.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Start()
        lblDateTime.Text = Now.ToString("dd/MM/yyyy hh:mm:ss tt")
    End Sub

    Private Sub AdvanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvanceToolStripMenuItem.Click
        frmAdvanceEntry.lblUser.Text = lblUser.Text
        frmAdvanceEntry.Reset()
        frmAdvanceEntry.ShowDialog()
    End Sub

    Private Sub PaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentToolStripMenuItem.Click
        frmEmployeePayment.lblUser.Text = lblUser.Text
        frmEmployeePayment.Reset()
        frmEmployeePayment.ShowDialog()
    End Sub

    Private Sub RegistrationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrationToolStripMenuItem.Click
        frmEmployeeRegistration.lblUser.Text = lblUser.Text
        frmEmployeeRegistration.Reset()
        frmEmployeeRegistration.ShowDialog()
    End Sub

    Private Sub EmployeePaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeePaymentToolStripMenuItem.Click
        frmEmployeePaymentRecord1.Reset()
        frmEmployeePaymentRecord1.ShowDialog()
    End Sub


    Private Sub AttendanceToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttendanceToolStripMenuItem2.Click
        frmAttendance.lblUser.Text = lblUser.Text
        frmAttendance.Reset()
        frmAttendance.ShowDialog()
    End Sub

    Private Sub AdvanceEntryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvanceEntryToolStripMenuItem1.Click
        frmAdvanceEntry.lblUser.Text = lblUser.Text
        frmAdvanceEntry.Reset()
        frmAdvanceEntry.ShowDialog()
    End Sub

    Private Sub PaymentToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentToolStripMenuItem1.Click
        frmEmployeePayment.lblUser.Text = lblUser.Text
        frmEmployeePayment.Reset()
        frmEmployeePayment.ShowDialog()
    End Sub
    Sub LogOut()
        Dim st As String = "Successfully logged out"
        LogFunc(lblUser.Text, st)
        Me.Hide()
        frmChatStart.Hide()
        frmCheckIN_Room.Hide()
        frmCheckOut_Room.Hide()
        frmReservation.Hide()
        frmLogin.Show()
        frmLogin.UserID.Text = ""
        frmLogin.Password.Text = ""
        frmLogin.UserID.Focus()
    End Sub
    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Try
            If MessageBox.Show("Do you really want to logout from application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If MessageBox.Show("Do you want backup database before logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Backup()
                    LogOut()
                Else
                    LogOut()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub RoomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoomToolStripMenuItem.Click
        frmRoom.lblUser.Text = lblUser.Text
        frmRoom.Reset()
        frmRoom.ShowDialog()
    End Sub


    Private Sub CheckInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckInToolStripMenuItem.Click

        frmCheckIN_Room.lblUser.Text = lblUser.Text
        frmCheckIN_Room.Reset()
        frmCheckIN_Room.ShowDialog()
    End Sub

    Private Sub CheckOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckOutToolStripMenuItem.Click
        frmCheckOut_Room.lblUser.Text = lblUser.Text
        frmCheckOut_Room.Reset()
        frmCheckOut_Room.ShowDialog()
    End Sub


    Private Sub CheckInToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckInToolStripMenuItem1.Click
        frmCheckIN_Room.lblUser.Text = lblUser.Text
        frmCheckIN_Room.Reset()
        frmCheckIN_Room.ShowDialog()
    End Sub

    Private Sub CheckOutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckOutToolStripMenuItem1.Click
        frmCheckOut_Room.lblUser.Text = lblUser.Text
        frmCheckOut_Room.Reset()
        frmCheckOut_Room.ShowDialog()
    End Sub


    Private Sub RegistrationToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrationToolStripMenuItem1.Click
        frmRegistration.lblUser.Text = lblUser.Text
        frmRegistration.Reset()
        frmRegistration.ShowDialog()
    End Sub



    Private Sub OthersTransToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OthersTransToolStripMenuItem.Click
        frmTransaction.lblUser.Text = lblUser.Text
        frmTransaction.Reset()
        frmTransaction.ShowDialog()
    End Sub

    Private Sub DishToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DishToolStripMenuItem.Click
        frmDish.lblUser.Text = lblUser.Text
        frmDish.Reset()
        frmDish.ShowDialog()
    End Sub

    Private Sub GuestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuestToolStripMenuItem.Click
        frmGuest.lblUser.Text = lblUser.Text
        frmGuest.Reset()
        frmGuest.ShowDialog()
    End Sub

    Private Sub OthersTransactionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OthersTransactionToolStripMenuItem.Click
        frmTransactionRecord.Reset()
        frmTransactionRecord.ShowDialog()
    End Sub

    Private Sub PurchasedInventoryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchasedInventoryToolStripMenuItem1.Click
        frmPurchaseRecord.Reset()
        frmPurchaseRecord.ShowDialog()
    End Sub

    Private Sub ExtraToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExtraToolStripMenuItem.Click
        frmExtraBed.lblUser.Text = lblUser.Text
        frmExtraBed.Reset()
        frmExtraBed.ShowDialog()
    End Sub

    Private Sub CheckInToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckInToolStripMenuItem2.Click
        frmCheckInRecord.Reset()
        frmCheckInRecord.ShowDialog()
    End Sub


    Private Sub ReservationToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReservationToolStripMenuItem2.Click
        frmReservationRecord.Reset()
        frmReservationRecord.ShowDialog()
    End Sub

    Private Sub OrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrderToolStripMenuItem.Click
        frmOrder.lblUser.Text = lblUser.Text
        frmOrder.Reset()
        frmOrder.ShowDialog()
    End Sub

    Private Sub HallToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HallToolStripMenuItem.Click
        frmHall.lblUser.Text = lblUser.Text
        frmHall.Reset()
        frmHall.ShowDialog()
    End Sub

    Private Sub GardenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GardenToolStripMenuItem.Click
        frmGarden.lblUser.Text = lblUser.Text
        frmGarden.Reset()
        frmGarden.ShowDialog()
    End Sub

    Private Sub StockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockToolStripMenuItem.Click
        frmStock.lblUser.Text = lblUser.Text
        frmStock.Reset()
        frmStock.ShowDialog()
    End Sub


    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(CheckIn_Room.Cin_ID),RTRIM(Guest.GuestID), RTRIM(Room.RoomNo),RTRIM(PlanCode),RTRIM(GuestName),DateIN,DateOut 
                        from Checkin_Room INNER JOIN Guest ON Checkin_Room.GuestID = Guest.ID FULL OUTER JOIN
                            Room ON Checkin_Room.RoomID = Room.R_ID WHERE Status='Check In' Order by datein"

            '                  union all
            '                  Select RTRIM(Reservation_Details.ID),RTRIM(Guest.GuestID), RTRIM(Room.RoomNo),RTRIM(PlanCode),RTRIM(GuestName),DateIN,DateOut   
            '                  from Guest,Room,Reservation, Reservation_Details where Reservation.Reserve_ID = Reservation_Details.Reserve_ID
            'and Guest.ID=Reservation.Guest_ID and Room.R_ID=Reservation_Details.RoomID and Reservation_Details.Status='Check In' Order by DateIN"

            cmd = New SqlCommand(sql, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6))
            End While
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                If Convert.ToDateTime(r.Cells(6).Value) <= System.DateTime.Now.Date Then
                    r.DefaultCellStyle.BackColor = Color.Orange
                Else
                    r.DefaultCellStyle.BackColor = Color.LightGreen
                End If
            Next
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql1 As String = "SELECT RTRIM(Reservation.ReservationNo), RTRIM(Guest.GuestID), RTRIM(Room.RoomNo), RTRIM(Room.PlanCode), RTRIM(Guest.GuestName), Reservation.DateIN, 
                  Reservation.DateOUT, Reservation.GrandTotal, Reservation.TotalPaid FROM  Reservation INNER JOIN
                  Guest ON Reservation.Guest_ID = Guest.ID FULL OUTER JOIN
                  Room ON Reservation.RoomID = Room.R_ID WHERE Status='Reserved' Order by ReservationDate"
            cmd = New SqlCommand(sql1, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView2.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8))
            End While
            'For Each r As DataGridViewRow In Me.DataGridView2.Rows
            '    If Convert.ToDateTime(r.Cells(6).Value) <= System.DateTime.Now.Date Then
            '        r.DefaultCellStyle.BackColor = Color.Orange
            '    Else
            '        r.DefaultCellStyle.BackColor = Color.LightGreen
            '    End If
            'Next
            For Each row As DataGridViewRow In DataGridView2.Rows
                If (Convert.ToInt32(row.Cells(7).Value) = Convert.ToInt32(row.Cells(8).Value)) Then
                    row.DefaultCellStyle.BackColor = Color.Green
                    row.DefaultCellStyle.ForeColor = Color.White
                Else
                    row.DefaultCellStyle.BackColor = Color.Red
                    row.DefaultCellStyle.ForeColor = Color.White
                End If
            Next
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql2 As String = "Select distinct RTRIM(RoomNo),RTRIM(RoomType),RTRIM(R_Status) from Room where Active='Yes' and R_Status in ('Vacant Dirty','Vacant Clean') order by 1"
            cmd = New SqlCommand(sql2, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView3.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView3.Rows.Add(rdr(0), rdr(1), rdr(2))
            End While
            For Each r As DataGridViewRow In Me.DataGridView3.Rows
                If (r.Cells(2).Value) = "Vacant Clean" Then
                    r.DefaultCellStyle.BackColor = Color.LawnGreen
                Else
                    r.DefaultCellStyle.BackColor = Color.OrangeRed
                End If
            Next
            con.Close()
            DataGridView1.ClearSelection()
            DataGridView2.ClearSelection()
            DataGridView3.ClearSelection()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub OrdersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrdersToolStripMenuItem.Click
        frmOrdersRecord1.Reset()
        frmOrdersRecord1.ShowDialog()
    End Sub

    Private Sub GuestToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuestToolStripMenuItem1.Click
        frmGuest.lblUser.Text = lblUser.Text
        frmGuest.Reset()
        frmGuest.ShowDialog()
    End Sub


    Private Sub RoomsAvailabilityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogsToolStripMenuItem1.Click
        frmLogs.Reset()
        frmLogs.lblUser.Text = lblUser.Text
        frmLogs.ShowDialog()
    End Sub

    Private Sub LogsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogsToolStripMenuItem.Click
        frmLogs.Reset()
        frmLogs.lblUser.Text = lblUser.Text
        frmLogs.ShowDialog()
    End Sub

    Private Sub HotelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HotelToolStripMenuItem.Click
        frmHotel.lblUser.Text = lblUser.Text
        frmHotel.Reset()
        frmHotel.ShowDialog()
    End Sub

    Private Sub RoomTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoomTypeToolStripMenuItem.Click
        frmRoomType.lblUser.Text = lblUser.Text
        frmRoomType.Reset()
        frmRoomType.ShowDialog()
    End Sub

    Private Sub CategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoryToolStripMenuItem.Click
        frmCategory.lblUser.Text = lblUser.Text
        frmCategory.lblSet.Text = ""
        frmCategory.Reset()
        frmCategory.ShowDialog()
    End Sub

    Private Sub TaxToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaxToolStripMenuItem.Click
        frmTax.lblUser.Text = lblUser.Text
        frmTax.Reset()
        frmTax.ShowDialog()
    End Sub

    Private Sub ExtraPersonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExtraPersonToolStripMenuItem.Click
        frmExtraPerson.lblUser.Text = lblUser.Text
        frmExtraPerson.Reset()
        frmExtraPerson.ShowDialog()
    End Sub

    Private Sub LiquorCategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquorCategoryToolStripMenuItem.Click
        frmLiquorCategory.lblUser.Text = lblUser.Text
        frmLiquorCategory.Reset()
        frmLiquorCategory.ShowDialog()
    End Sub

    Private Sub LiquorQuantityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquorQuantityToolStripMenuItem.Click
        frmLiquorQuantity.lblUser.Text = lblUser.Text
        frmLiquorQuantity.Reset()
        frmLiquorQuantity.ShowDialog()
    End Sub

    Private Sub LiquorToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquorToolStripMenuItem1.Click
        frmLiquor.lblUser.Text = lblUser.Text
        frmLiquor.Reset()
        frmLiquor.ShowDialog()
    End Sub

    Private Sub LiquorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquorToolStripMenuItem.Click
        frmLiquorRate.lblUser.Text = lblUser.Text
        frmLiquorRate.Reset()
        frmLiquorRate.ShowDialog()
    End Sub


    Private Sub HallOrGardenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HallOrGardenToolStripMenuItem1.Click
        frmReservation_HallorGarden.lblUser.Text = lblUser.Text
        frmReservation_HallorGarden.Reset()
        frmReservation_HallorGarden.ShowDialog()
    End Sub

    Private Sub PurchasedInventoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchasedInventoryToolStripMenuItem.Click
        frmPurchase.lblUser.Text = lblUser.Text
        frmPurchase.Reset()
        frmPurchase.ShowDialog()
    End Sub


    Private Sub RoomToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoomToolStripMenuItem1.Click
        frmReservation.lblUser.Text = lblUser.Text
        frmReservation.Reset()
        frmReservation.Show()
    End Sub

    Private Sub GuestsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuestsToolStripMenuItem.Click
        frmGuestRecord1.lblSet.Text = "Reservation_HallorGarden"
        frmGuestRecord1.Reset()
        frmGuestRecord1.ShowDialog()
    End Sub

    Private Sub IDTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IDTypeToolStripMenuItem.Click
        frmIDType.lblUser.Text = lblUser.Text
        frmIDType.lblSet.Text = ""
        frmIDType.Reset()
        frmIDType.ShowDialog()
    End Sub

    Private Sub StockToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockToolStripMenuItem1.Click
        frmStock.lblUser.Text = lblUser.Text
        frmStock.Reset()
        frmStock.ShowDialog()
    End Sub

    Private Sub LiquorStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquorStockToolStripMenuItem.Click
        frmStockRecord.Reset()
        frmStockRecord.ShowDialog()
    End Sub

    Private Sub CheckOutToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckOutToolStripMenuItem2.Click
        frmCheckOutRecord.Reset()
        frmCheckOutRecord.ShowDialog()
    End Sub

    Private Sub HallOrGardenReservationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HallOrGardenReservationToolStripMenuItem.Click
        frmReservationRecord_HallOrGarden.Reset()
        frmReservationRecord_HallOrGarden.ShowDialog()
    End Sub

    Private Sub RestaurantBillingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestaurantBillingToolStripMenuItem.Click
        frmRestaurantPOS.lblUser.Text = lblUser.Text
        frmRestaurantPOS.Reset()
        frmRestaurantPOS.Reset1()
        frmRestaurantPOS.Reset2()
        frmRestaurantPOS.Reset3()
        frmRestaurantPOS.ShowDialog()
    End Sub

    Private Sub ReToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReToolStripMenuItem.Click
        frmRestaurantBillingRecord1.Reset()
        frmRestaurantBillingRecord1.ShowDialog()
    End Sub

    Private Sub RoomToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RoomToolStripMenuItem2.Click
        frmReservation.lblUser.Text = lblUser.Text
        frmReservation.Reset()
        frmReservation.ShowDialog()
    End Sub

    Private Sub HallOrGardenToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles HallOrGardenToolStripMenuItem.Click
        frmReservation_HallorGarden.lblUser.Text = lblUser.Text
        frmReservation_HallorGarden.Reset()
        frmReservation_HallorGarden.ShowDialog()
    End Sub

    Private Sub FoodToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles FoodToolStripMenuItem.Click
        frmOthersRecord.Reset()
        frmOthersRecord.ShowDialog()
    End Sub

    Private Sub CheckInToolStripMenuItem3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CheckInToolStripMenuItem3.Click
        frmCheckInReport.Reset()
        frmCheckInReport.ShowDialog()
    End Sub

    Private Sub CheckOutToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckOutToolStripMenuItem3.Click
        frmCheckoutReport.Reset()
        frmCheckoutReport.ShowDialog()
    End Sub



    Private Sub CheckOutWithIDToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CheckOutWithIDToolStripMenuItem.Click
        frmCheckout_IdReport.Reset()
        frmCheckout_IdReport.ShowDialog()
    End Sub

    Private Sub CheckInWithIDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckInWithIDToolStripMenuItem.Click
        frmCheckInWithIdReport.Reset()
        frmCheckInWithIdReport.ShowDialog()
    End Sub
    Public Sub Reset()
        dtpDateIn.Text = Today
        dtpDateOut.Text = Today.AddDays(30)
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        txtSearchByGuestName.Text = ""
        TextBox1.Text = ""
        GetData()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        dtpDateIn.Text = Today
        dtpDateOut.Text = Today.AddDays(30)
        dgw.Rows.Clear()
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        DataGridView3.ClearSelection()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            dgw.Enabled = True
            'If dtpDateIn.Value.Date = dtpDateOut.Value.Date Then
            '    MessageBox.Show("Date Out can not be same as Date IN", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    dtpDateOut.Focus()
            '    dtpDateOut.Text = Today.AddDays(15)
            '    Exit Sub
            'End If
            If dtpDateOut.Value.Date < dtpDateIn.Value.Date Then
                MessageBox.Show("Selected date out must be greater than date in", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dtpDateOut.Focus()
                dtpDateOut.Text = Today.AddDays(30)
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "SELECT distinct R.R_ID, RTRIM(R.RoomNo),RTRIM(R.RoomType),RTRIM(R.PlanCode),R.RoomCharges FROM Room as R Inner Join Room as S on R.RoomNo=S.RoomNo where R.Active='Yes' and R.RoomNo not in (Select RoomNo from Reservation,Room where Room.R_ID=Reservation.RoomID and Status ='Reserved' and Reservation.DateIn < @d1 AND Reservation.DateOut > @d2 ) and S.Active='Yes' and S.RoomNo not in (SELECT RoomNo FROM Checkin_Room,Room where Room.R_ID=CheckIn_Room.RoomID and Status = 'Check In' and Checkin_Room.DateIn < @d1 AND Checkin_Room.DateOut > @d2) "
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@d1", dtpDateIn.Value.Date)
            cmd.Parameters.AddWithValue("@d2", dtpDateOut.Value.Date)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4))
            End While

            frmnCalender.txtDateIn.Text = dtpDateIn.Value.Date
            frmnCalender.txtDateOut.Text = dtpDateOut.Value.Date
            frmnCalender.ShowDialog()


            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                If RadioButton3.Checked = False And RadioButton4.Checked = False Then
                    MessageBox.Show("Please select operation", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If RadioButton3.Checked = True Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "SELECT * FROM Room where R_Status='Vacant Dirty' and RoomNo=@d1"
                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", dr.Cells(1).Value)
                    rdr = cmd.ExecuteReader()
                    If rdr.Read Then
                        MessageBox.Show("Selected Room can not be booked because its dirty " & vbCrLf & "Room Status must be Vacant Clean before booking", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        If Not rdr Is Nothing Then
                            rdr.Close()
                        End If
                        Exit Sub
                    End If
                    con.Close()
                    frmCheckIN_Room.Reset()
                    frmCheckIN_Room.Show()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmCheckIN_Room.lblUser.Text = lblUser.Text
                    frmCheckIN_Room.cmbRoomNo.Text = dr.Cells(1).Value.ToString().Trim
                    frmCheckIN_Room.txtRoomID.Text = dr.Cells(0).Value.ToString().Trim
                    frmCheckIN_Room.cmbPlanCode.DropDownStyle = ComboBoxStyle.DropDown
                    frmCheckIN_Room.cmbPlanCode.Text = dr.Cells(3).Value.ToString().Trim
                    frmCheckIN_Room.dtpDateIn.Text = dtpDateIn.Value.Date
                    frmCheckIN_Room.dtpDateOut.Text = dtpDateOut.Value.Date
                    frmCheckIN_Room.txtRoomCharges.Text = dr.Cells(4).Value
                    frmCheckIN_Room.cmbRoomNo.Enabled = False
                    frmCheckIN_Room.cmbPlanCode.Enabled = False
                    frmCheckIN_Room.GetPlan()
                    dgw.Rows.Clear()
                    dtpDateIn.Text = Today
                    dtpDateOut.Text = Today.AddDays(30)
                    dgw.Enabled = False
                End If
                If RadioButton4.Checked = True Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    frmReservation.Reset()
                    frmReservation.Show()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmReservation.lblUser.Text = lblUser.Text
                    frmReservation.cmbRoomNo.Text = dr.Cells(1).Value.ToString().Trim
                    frmReservation.txtRoomID.Text = dr.Cells(0).Value.ToString().Trim
                    frmReservation.cmbPlanCode.DropDownStyle = ComboBoxStyle.DropDown
                    frmReservation.cmbPlanCode.Text = dr.Cells(3).Value.ToString().Trim
                    frmReservation.dtpDateIn.Text = dtpDateIn.Value.Date
                    frmReservation.dtpDateOut.Text = dtpDateOut.Value.Date
                    frmReservation.txtRoomCharges.Text = dr.Cells(4).Value
                    frmReservation.cmbRoomNo.Enabled = False
                    frmReservation.cmbPlanCode.Enabled = False
                    frmReservation.GetPlan()
                    dgw.Rows.Clear()
                    dtpDateIn.Text = Today
                    dtpDateOut.Text = Today.AddDays(30)
                    dgw.Enabled = False
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

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            If DataGridView1.Rows.Count > 0 Then
                If RadioButton1.Checked = False And RadioButton2.Checked = False And rbLaundry.Checked = False And rbRoomServices.Checked = False Then
                    MessageBox.Show("Please select operation", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                If RadioButton1.Checked = True Then
                    Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
                    Dim Res As String = ""

                    If Not IsDBNull(dr.Cells(2).Value) Then
                        Res = "0"
                    End If
                    ' Res = Res.Substring(0, 1)

                    If Res = "0" Then
                        frmCheckIN_Room.lblUser.Text = lblUser.Text
                        frmCheckIN_Room.Reset()
                        frmCheckIN_Room.Show()
                        frmCheckIN_Room.btnSave.Enabled = False
                        frmCheckIN_Room.btnUpdate.Enabled = True
                        frmCheckIN_Room.btnDelete.Enabled = True
                        frmCheckIN_Room.btnRoomAvailability.Enabled = False
                        frmCheckIN_Room.btnChangeRoom.Enabled = True
                        frmCheckIN_Room.btnPrint.Enabled = False
                        frmCheckIN_Room.cmbRoomNo.Text = dr.Cells(2).Value.ToString
                        frmCheckIN_Room.cmbRoomNo1.Text = dr.Cells(2).Value.ToString
                        frmCheckIN_Room.cmbPlanCode.DropDownStyle = ComboBoxStyle.DropDown
                        frmCheckIN_Room.cmbPlanCode.Text = dr.Cells(3).Value.ToString
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sql2 As String = "SELECT sum(PaymentDue) FROM CheckIN_Room,Room_OrderInfo where Room_Orderinfo.CheckInId=Checkin_Room.Cin_ID and Checkin_Room.Cin_ID= " & dr.Cells(0).Value.ToString() & " and RO_Status='Unpaid'"
                        cmd = New SqlCommand(sql2, con)
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        If rdr.Read() Then
                            txtRoomOrderCharges.Text = rdr.GetValue(0).ToString()
                        Else
                            txtRoomOrderCharges.Text = 0
                        End If
                        con.Close()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sql3 As String = "SELECT sum(PaymentDue) FROM CheckIN_Room,Laundry_BillInfo where Laundry_BillInfo.CheckInId=Checkin_Room.Cin_ID and Checkin_Room.Cin_ID= " & dr.Cells(0).Value.ToString() & " and LB_Status='Unpaid'"
                        cmd = New SqlCommand(sql3, con)
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        If rdr.Read() Then
                            txtLaundryCharges.Text = rdr.GetValue(0).ToString()
                        Else
                            txtLaundryCharges.Text = 0
                        End If
                        con.Close()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sql1 As String = "SELECT ID,RTRIM(Address), RTRIM(City),RTRIM( ContactNo), RTRIM(Gender), RTRIM(Occupation), RTRIM(Religion), RTRIM(IDType), RTRIM(IDNumber),RTRIM(Country) from Guest WHERE GuestId='" & dr.Cells(1).Value & "'"
                        cmd = New SqlCommand(sql1, con)
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        If (rdr.Read() = True) Then
                            frmCheckIN_Room.txtID.Text = rdr.GetValue(0)
                            frmCheckIN_Room.txtGuestAddress.Text = rdr.GetValue(1)
                            frmCheckIN_Room.txtGuestCity.Text = rdr.GetValue(2)
                            frmCheckIN_Room.txtGuestContactNo.Text = rdr.GetValue(3)
                            frmCheckIN_Room.txtGender.Text = rdr.GetValue(4)
                            frmCheckIN_Room.txtOccupation.Text = rdr.GetValue(5)
                            frmCheckIN_Room.txtReligion.Text = rdr.GetString(6)
                            frmCheckIN_Room.txtIDType.Text = rdr.GetValue(7)
                            frmCheckIN_Room.txtIDNumber.Text = rdr.GetValue(8)
                            frmCheckIN_Room.txtCountry.Text = rdr.GetValue(9)
                        End If
                        con.Close()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sql As String = "Select RTRIM(CheckIn_Room.Cin_Id) as [Check In ID], RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],
                    RTRIM(Room. RoomNo) as [Room No.], RTRIM(CheckIN_Room.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], 
                    Convert(DateTime,DateOUT,103) as [Date Out], RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], 
                    RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], RTRIM(NoOfExtraBed) as [No. Of Extra Bed], 
                    RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(RoomOrderCharges) as [Room Order Charges], RTRIM(ExtraPersonCharges) as [Extra Person Charges], 
                    RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges], RTRIM(OtherCharges) as [Laundry Charges], 
                    RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %], RTRIM(STAmount) as [ST Amount], 
                    RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(SubTotal) as [Sub Total], 
                    RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance], RTRIM(CheckIn_Room.Notes) as [Notes],
                    OtherCharge from Guest,Room,CheckIN_Room where Guest.ID=CheckIN_Room.GuestID and Status='Check In' and
                    Room.R_ID=CheckIN_Room.RoomID and Checkin_Room.Cin_ID=" & dr.Cells(0).Value & ""

                        cmd = New SqlCommand(sql, con)
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        If (rdr.Read() = True) Then
                            frmCheckIN_Room.txtCheckInID.Text = rdr.GetValue(0)
                            frmCheckIN_Room.txtGuestID.Text = rdr.GetValue(1)
                            frmCheckIN_Room.txtGuestName.Text = rdr.GetValue(2)
                            frmCheckIN_Room.txtRoomCharges.Text = rdr.GetValue(4)
                            frmCheckIN_Room.dtpDateIn.Text = rdr.GetValue(5)
                            frmCheckIN_Room.dtpDateOut.Text = rdr.GetValue(6)
                            frmCheckIN_Room.txtNoOfDays.Text = rdr.GetValue(7)
                            frmCheckIN_Room.txtNoOfMales.Text = rdr.GetValue(8)
                            frmCheckIN_Room.txtNoOfFemales.Text = rdr.GetValue(9)
                            frmCheckIN_Room.txtNoOfKids.Text = rdr.GetValue(10)
                            frmCheckIN_Room.txtNoOfExtraBed.Text = rdr.GetValue(11)
                            frmCheckIN_Room.txtNoOfExtraPerson.Text = rdr.GetValue(12)
                            frmCheckIN_Room.txtRoomOrderCharges.Text = rdr.GetValue(13) + Val(txtRoomOrderCharges.Text)
                            frmCheckIN_Room.txtExtraPersonCharges.Text = rdr.GetValue(14)
                            frmCheckIN_Room.txtTotalRoomCharges.Text = rdr.GetValue(15)
                            frmCheckIN_Room.txtExtraBedCharges.Text = rdr.GetValue(16)
                            frmCheckIN_Room.txtLaundryCharges.Text = rdr.GetValue(17) + Val(txtLaundryCharges.Text)
                            frmCheckIN_Room.txtDiscountPer.Text = rdr.GetValue(18)
                            frmCheckIN_Room.txtDiscountAmount.Text = rdr.GetValue(19)
                            frmCheckIN_Room.txtServiceTaxPer.Text = rdr.GetValue(20)
                            frmCheckIN_Room.txtServiceTaxAmount.Text = rdr.GetValue(21)
                            frmCheckIN_Room.txtLuxuryTaxPer.Text = rdr.GetValue(22)
                            frmCheckIN_Room.txtLuxuryTaxAmount.Text = rdr.GetValue(23)
                            frmCheckIN_Room.txtSubTotal.Text = rdr.GetValue(24)
                            frmCheckIN_Room.txtGrandTotal.Text = rdr.GetValue(25)
                            frmCheckIN_Room.txtTotalPaid.Text = rdr.GetValue(26)
                            frmCheckIN_Room.txtBalance.Text = rdr.GetValue(27)
                            frmCheckIN_Room.txtNotes.Text = rdr.GetValue(28)
                            frmCheckIN_Room.txtOtherCharges.Text = rdr.GetValue(29)
                        End If
                        frmCheckIN_Room.Compute()
                        con.Close()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sqlq As String = "SELECT RTRIM(PaymentMode),CheckIn_Payment.TotalPaid,PaymentDate from CheckIn_Room,CheckIN_Payment where 
CheckIn_Room.Cin_ID=CheckIn_Payment.CheckInID and CheckInID=@d1 and CheckIn_Payment.TotalPaid > 0"
                        cmd = New SqlCommand(sqlq, con)
                        cmd.Parameters.AddWithValue("@d1", dr.Cells(0).Value.ToString())
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        frmCheckIN_Room.DataGridView2.Rows.Clear()
                        While (rdr.Read() = True)
                            frmCheckIN_Room.DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), "Not allowed")
                        End While
                        con.Close()
                        frmCheckIN_Room.GetPlan()
                        frmCheckIN_Room.cmbPlanCode.Enabled = False
                        frmCheckIN_Room.lblStatus.Text = "Not allowed"
                    Else
                        frmGroupReservation.Label1.Text = "Group Check In"
                        frmGroupReservation.lblUser.Text = lblUser.Text
                        frmGroupReservation.Reset()
                        frmGroupReservation.Show()
                        frmGroupReservation.btnSave.Enabled = False
                        frmGroupReservation.btnPrint.Enabled = True
                        frmGroupReservation.btnDelete.Enabled = True
                        'frmGroupReservation.btnRoomAvailability.Enabled = False
                        frmGroupReservation.cmbRoomNo.Text = dr.Cells(2).Value.ToString
                        frmGroupReservation.cmbRoomNo1.Text = dr.Cells(2).Value.ToString
                        frmGroupReservation.cmbPlanCode.DropDownStyle = ComboBoxStyle.DropDown
                        frmGroupReservation.cmbPlanCode.Text = dr.Cells(3).Value.ToString
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sql1 As String = "SELECT ID,RTRIM(Address), RTRIM(City),RTRIM( ContactNo), RTRIM(Gender), RTRIM(Occupation), RTRIM(Religion), RTRIM(IDType), RTRIM(IDNumber),RTRIM(Country) from Guest WHERE GuestId='" & dr.Cells(1).Value & "'"
                        cmd = New SqlCommand(sql1, con)
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        If (rdr.Read() = True) Then
                            frmGroupReservation.txtID.Text = rdr.GetValue(0)
                            frmGroupReservation.txtGuestContactNo.Text = rdr.GetValue(3)
                        End If
                        con.Close()
                        con = New SqlConnection(cs)
                        con.Open()
                        sql1 = "SELECT reserve_id from reservation WHERE Guest_Id='" & Convert.ToString(dr.Cells(1).Value).Remove(0, 1) & "' and DateIN='" & dr.Cells(5).Value & "' and roomid is null"
                        cmd = New SqlCommand(sql1, con)
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        If (rdr.Read() = True) Then
                            frmGroupReservation.txtReservationID.Text = rdr.GetValue(0)
                            frmGroupReservation.txtReservationNo.Text = "G" + Convert.ToString(rdr.GetValue(0))
                        End If
                        con.Close()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sql As String = "Select RTRIM(Reserve_ID), RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name], '' as [Room No.], 
                    RTRIM(Reservation.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out], 
                    RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], 
                    RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(ReservationNo), 
                    RTRIM(ExtraPersonCharges) as [Extra Person Charges], RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges],
                    ReservationDate, RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %], 
                    RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], 
                    RTRIM(SubTotal) as [Sub Total], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance], 
                    RTRIM(Reservation.Notes) as [Notes] from Guest,Reservation where Guest.ID=Reservation.Guest_ID and Status='Check In' 
                    and Reserve_ID=" & frmGroupReservation.txtReservationID.Text & ""

                        cmd = New SqlCommand(sql, con)
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        If (rdr.Read() = True) Then
                            frmGroupReservation.txtReservationID.Text = rdr.GetValue(0)
                            frmGroupReservation.txtGuestID.Text = rdr.GetValue(1)
                            frmGroupReservation.txtGuestName.Text = rdr.GetValue(2)
                            frmGroupReservation.txtRoomCharges.Text = rdr.GetValue(4)
                            frmGroupReservation.dtpDateIn.Text = rdr.GetValue(5)
                            frmGroupReservation.dtpDateOut.Text = rdr.GetValue(6)
                            frmGroupReservation.txtNoOfDays.Text = rdr.GetValue(7)
                            frmGroupReservation.txtNoOfMales.Text = rdr.GetValue(8)
                            frmGroupReservation.txtNoOfFemales.Text = rdr.GetValue(9)
                            frmGroupReservation.txtNoOfKids.Text = rdr.GetValue(10)
                            frmGroupReservation.txtNoOfExtraBed.Text = rdr.GetValue(11)
                            frmGroupReservation.txtNoOfExtraPerson.Text = rdr.GetValue(12)
                            frmGroupReservation.txtReservationNo.Text = rdr.GetValue(13)
                            frmGroupReservation.txtExtraPersonCharges.Text = rdr.GetValue(14)
                            frmGroupReservation.txtTotalRoomCharges.Text = rdr.GetValue(15)
                            frmGroupReservation.txtExtraBedCharges.Text = rdr.GetValue(16)
                            frmGroupReservation.dtpReservationDate.Value = rdr.GetValue(17)
                            frmGroupReservation.txtDiscountPer.Text = rdr.GetValue(18)
                            frmGroupReservation.txtDiscountAmount.Text = rdr.GetValue(19)
                            frmGroupReservation.txtServiceTaxPer.Text = rdr.GetValue(20)
                            frmGroupReservation.txtServiceTaxAmount.Text = rdr.GetValue(21)
                            frmGroupReservation.txtGroupTax.Text = rdr.GetValue(21)
                            frmGroupReservation.txtLuxuryTaxPer.Text = rdr.GetValue(22)
                            frmGroupReservation.txtLuxuryTaxAmount.Text = rdr.GetValue(23)
                            frmGroupReservation.txtSubTotal.Text = rdr.GetValue(24)
                            frmGroupReservation.txtGrandTotal.Text = rdr.GetValue(25)

                            frmGroupReservation.txtTotalPaid.Text = rdr.GetValue(26)
                            frmGroupReservation.txtBalance.Text = rdr.GetValue(27)
                            frmGroupReservation.txtGroupBalance.Text = rdr.GetValue(27)
                            frmGroupReservation.txtGroupTotal.Text = rdr.GetValue(25)
                            'frmGroupReservation.txtNotes.Text = rdr.GetValue(28)
                        End If
                        frmReservation.Compute()

                        con.Close()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sqlq As String = "SELECT RTRIM(PaymentMode),Reservation_Payment.TotalPaid,PaymentDate from Reservation,Reservation_Payment where Reservation.Reserve_ID=Reservation_Payment.ReservationID and ReservationID=@d1 and Reservation_Payment.TotalPaid > 0"
                        cmd = New SqlCommand(sqlq, con)
                        cmd.Parameters.AddWithValue("@d1", Convert.ToString(dr.Cells(0).Value).Remove(0, 1))
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        frmReservation.DataGridView2.Rows.Clear()
                        While (rdr.Read() = True)
                            frmReservation.DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), "Not allowed")
                        End While
                        con.Close()
                        frmGroupReservation.GetPlan()
                        'frmGroupReservation.CalGroupTotal()
                        frmGroupReservation.btnCancelReservation.Enabled = False
                        frmGroupReservation.cmbPlanCode.Enabled = False
                        frmGroupReservation.btnCancelReservation.Enabled = False
                        frmGroupReservation.btnCancelReservationReceipt.Enabled = False
                        frmGroupReservation.btnCheckedIN.Visible = True
                        frmGroupReservation.btnCheckOut.Visible = False
                        frmGroupReservation.btnSave.Enabled = False
                        frmGroupReservation.btnNew.Enabled = False
                        frmGroupReservation.btnDelete.Enabled = False
                        frmGroupReservation.lblStatus.Text = "Not allowed"
                        frmGroupReservation.txtStatus.Text = "Check In"
                        frmGroupReservation.LoadRoomPayments()
                        'frmGroupReservation.Button2.Visible = True
                        frmGroupReservation.btnAddRooms.Visible = False
                        frmGroupReservation.LoadRoomPayments()

                        frmGroupReservation.LoadRooms()
                    End If
                End If
                If RadioButton2.Checked = True Then
                    Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
                    Dim Res As String = ""

                    If Not IsDBNull(dr.Cells(2).Value) Then
                        Res = "0"
                    End If

                    If Res = "" Then
                        frmGroupReservation.Label1.Text = "Group Check Out"
                        frmGroupReservation.lblUser.Text = lblUser.Text
                        frmGroupReservation.Reset()
                        frmGroupReservation.Show()
                        frmGroupReservation.btnSave.Enabled = False
                        frmGroupReservation.btnPrint.Enabled = True
                        frmGroupReservation.btnDelete.Enabled = True
                        'frmGroupReservation.btnRoomAvailability.Enabled = False
                        frmGroupReservation.cmbRoomNo.Text = dr.Cells(2).Value.ToString
                        frmGroupReservation.cmbRoomNo1.Text = dr.Cells(2).Value.ToString
                        frmGroupReservation.cmbPlanCode.DropDownStyle = ComboBoxStyle.DropDown
                        frmGroupReservation.cmbPlanCode.Text = dr.Cells(3).Value.ToString
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sql1 As String = "SELECT ID,RTRIM(Address), RTRIM(City),RTRIM( ContactNo), RTRIM(Gender), RTRIM(Occupation), RTRIM(Religion), RTRIM(IDType), RTRIM(IDNumber),RTRIM(Country) from Guest WHERE GuestId='" & dr.Cells(1).Value & "'"
                        cmd = New SqlCommand(sql1, con)
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        If (rdr.Read() = True) Then
                            frmGroupReservation.txtID.Text = rdr.GetValue(0)
                            frmGroupReservation.txtGuestContactNo.Text = rdr.GetValue(3)
                        End If
                        con.Close()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim dt As String = dr.Cells(5).Value
                        Dim arr As String() = dt.Split("/")

                        If arr(0) > 12 Then
                            dt = arr(2) & "/" & arr(1) & "/" & arr(0)
                        Else
                            dt = arr(2) & "/" & arr(0) & "/" & arr(1)
                        End If


                        sql1 = "SELECT reserve_id from reservation WHERE Guest_Id='" & Convert.ToString(dr.Cells(1).Value).Remove(0, 1) & "' and DateIN='" & dt & "' and roomid is null"
                        cmd = New SqlCommand(sql1, con)
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        If (rdr.Read() = True) Then
                            frmGroupReservation.txtReservationID.Text = rdr.GetValue(0)
                            frmGroupReservation.txtReservationNo.Text = "G" + Convert.ToString(rdr.GetValue(0))
                        End If
                        con.Close()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sql As String = "Select RTRIM(Reserve_ID), RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name], '' as [Room No.], 
                    RTRIM(Reservation.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out], 
                    RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], 
                    RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(ReservationNo), 
                    RTRIM(ExtraPersonCharges) as [Extra Person Charges], RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges],
                    ReservationDate, RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %], 
                    RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], 
                    RTRIM(SubTotal) as [Sub Total], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance], 
                    RTRIM(Reservation.Notes) as [Notes] from Guest,Reservation where Guest.ID=Reservation.Guest_ID and Status='Check In' 
                    and Reserve_ID=" & frmGroupReservation.txtReservationID.Text & ""

                        cmd = New SqlCommand(sql, con)
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        If (rdr.Read() = True) Then
                            frmGroupReservation.txtReservationID.Text = rdr.GetValue(0)
                            frmGroupReservation.txtGuestID.Text = rdr.GetValue(1)
                            frmGroupReservation.txtGuestName.Text = rdr.GetValue(2)
                            frmGroupReservation.txtRoomCharges.Text = rdr.GetValue(4)
                            frmGroupReservation.dtpDateIn.Text = rdr.GetValue(5)
                            frmGroupReservation.dtpDateOut.Text = rdr.GetValue(6)
                            frmGroupReservation.txtNoOfDays.Text = rdr.GetValue(7)
                            frmGroupReservation.txtNoOfMales.Text = rdr.GetValue(8)
                            frmGroupReservation.txtNoOfFemales.Text = rdr.GetValue(9)
                            frmGroupReservation.txtNoOfKids.Text = rdr.GetValue(10)
                            frmGroupReservation.txtNoOfExtraBed.Text = rdr.GetValue(11)
                            frmGroupReservation.txtNoOfExtraPerson.Text = rdr.GetValue(12)
                            frmGroupReservation.txtReservationNo.Text = rdr.GetValue(13)
                            frmGroupReservation.txtExtraPersonCharges.Text = rdr.GetValue(14)
                            frmGroupReservation.txtTotalRoomCharges.Text = rdr.GetValue(15)
                            frmGroupReservation.txtExtraBedCharges.Text = rdr.GetValue(16)
                            frmGroupReservation.dtpReservationDate.Value = rdr.GetValue(17)
                            frmGroupReservation.txtDiscountPer.Text = rdr.GetValue(18)
                            frmGroupReservation.txtDiscountAmount.Text = rdr.GetValue(19)
                            frmGroupReservation.txtServiceTaxPer.Text = rdr.GetValue(20)
                            frmGroupReservation.txtServiceTaxAmount.Text = rdr.GetValue(21)
                            frmGroupReservation.txtGroupTax.Text = rdr.GetValue(21)
                            frmGroupReservation.txtLuxuryTaxPer.Text = rdr.GetValue(22)
                            frmGroupReservation.txtLuxuryTaxAmount.Text = rdr.GetValue(23)
                            frmGroupReservation.txtSubTotal.Text = rdr.GetValue(24)
                            frmGroupReservation.txtGrandTotal.Text = rdr.GetValue(25)

                            frmGroupReservation.txtTotalPaid.Text = rdr.GetValue(26)
                            frmGroupReservation.txtBalance.Text = rdr.GetValue(27)
                            frmGroupReservation.txtGroupBalance.Text = rdr.GetValue(27)
                            frmGroupReservation.txtGroupTotal.Text = rdr.GetValue(25)
                            'frmGroupReservation.txtNotes.Text = rdr.GetValue(28)
                        End If
                        frmReservation.Compute()

                        con.Close()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sqlq As String = "SELECT RTRIM(PaymentMode),Reservation_Payment.TotalPaid,PaymentDate from Reservation,Reservation_Payment where Reservation.Reserve_ID=Reservation_Payment.ReservationID and ReservationID=@d1 and Reservation_Payment.TotalPaid > 0"
                        cmd = New SqlCommand(sqlq, con)
                        cmd.Parameters.AddWithValue("@d1", Convert.ToString(dr.Cells(0).Value).Remove(0, 1))
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        frmReservation.DataGridView2.Rows.Clear()
                        While (rdr.Read() = True)
                            frmReservation.DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), "Not allowed")
                        End While
                        con.Close()
                        frmGroupReservation.GetPlan()
                        'frmGroupReservation.CalGroupTotal()
                        frmGroupReservation.btnCancelReservation.Enabled = False
                        frmGroupReservation.cmbPlanCode.Enabled = False
                        frmGroupReservation.btnCancelReservation.Enabled = False
                        frmGroupReservation.btnCancelReservationReceipt.Enabled = False
                        frmGroupReservation.btnCheckedIN.Visible = False
                        frmGroupReservation.btnCheckOut.Visible = True
                        frmGroupReservation.btnCheckOut.Enabled = True
                        frmGroupReservation.btnSave.Enabled = False
                        frmGroupReservation.btnNew.Enabled = False
                        frmGroupReservation.btnDelete.Enabled = False
                        frmGroupReservation.lblStatus.Text = "Not allowed"
                        frmGroupReservation.txtStatus.Text = "Check Out"
                        ' frmGroupReservation.LoadRoomPayments()
                        'frmGroupReservation.Button2.Visible = True
                        frmGroupReservation.btnAddRooms.Visible = False

                        frmGroupReservation.Label10.VISIBLE = True
                        frmGroupReservation.Label9.Visible = True
                        frmGroupReservation.TextBox5.Visible = True
                        frmGroupReservation.TextBox4.Visible = True
                        frmGroupReservation.LoadRoomPayments()
                        frmGroupReservation.LoadRooms()
                    Else
                        frmCheckOut_Room.Reset()
                        frmCheckOut_Room.Show()
                        frmCheckOut_Room.lblUser.Text = lblUser.Text

                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sql2 As String = "SELECT sum(PaymentDue) FROM CheckIN_Room,Room_OrderInfo where Room_Orderinfo.CheckInId=Checkin_Room.Cin_ID and Checkin_Room.Cin_ID= " & dr.Cells(0).Value.ToString() & " and RO_Status='Unpaid'"
                        cmd = New SqlCommand(sql2, con)
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        If rdr.Read() Then
                            txtRoomOrderCharges.Text = rdr.GetValue(0).ToString()
                        Else
                            txtRoomOrderCharges.Text = 0
                        End If
                        con.Close()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sql3 As String = "SELECT sum(PaymentDue) FROM CheckIN_Room,Laundry_BillInfo where Laundry_BillInfo.CheckInId=Checkin_Room.Cin_ID and Checkin_Room.Cin_ID= " & dr.Cells(0).Value.ToString() & " and LB_Status='Unpaid'"
                        cmd = New SqlCommand(sql3, con)
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        If rdr.Read() Then
                            txtLaundryCharges.Text = rdr.GetValue(0).ToString()
                        Else
                            txtLaundryCharges.Text = 0
                        End If
                        con.Close()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sql1 As String = "SELECT ID,RTRIM(Address), RTRIM(City),RTRIM( ContactNo), RTRIM(Gender), RTRIM(Occupation), RTRIM(Religion), RTRIM(IDType), RTRIM(IDNumber),RTRIM(Country) from Guest WHERE GuestId='" & dr.Cells(1).Value & "'"
                        cmd = New SqlCommand(sql1, con)
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        If (rdr.Read() = True) Then
                            frmCheckOut_Room.txtID.Text = rdr.GetValue(0)
                            frmCheckOut_Room.txtGuestAddress.Text = rdr.GetValue(1)
                            frmCheckOut_Room.txtGuestCity.Text = rdr.GetValue(2)
                            frmCheckOut_Room.txtGuestContactNo.Text = rdr.GetValue(3)
                            frmCheckOut_Room.txtGender.Text = rdr.GetValue(4)
                            frmCheckOut_Room.txtOccupation.Text = rdr.GetValue(5)
                            frmCheckOut_Room.txtReligion.Text = rdr.GetString(6)
                            frmCheckOut_Room.txtIDType.Text = rdr.GetValue(7)
                            frmCheckOut_Room.txtIDNumber.Text = rdr.GetValue(8)
                            frmCheckOut_Room.txtCountry.Text = rdr.GetValue(9)
                        End If
                        con.Close()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sql As String = "Select RTRIM(CheckIn_Room.Cin_Id) as [Check In ID], RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Room. RoomNo) as [Room No.], RTRIM(CheckIN_Room.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out], RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(RoomOrderCharges) as [Room Order Charges], RTRIM(ExtraPersonCharges) as [Extra Person Charges], RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges], RTRIM(OtherCharges) as [Laundry Charges], RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %], RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(SubTotal) as [Sub Total], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance],RoomID,RTRIM(PlanCode),OtherCharge from Guest,Room,CheckIN_Room where Guest.ID=CheckIN_Room.GuestID and Status='Check In' and Room.R_ID=CheckIN_Room.RoomID and Checkin_Room.Cin_ID=" & dr.Cells(0).Value & ""
                        cmd = New SqlCommand(sql, con)
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        If (rdr.Read() = True) Then
                            frmCheckOut_Room.txtCheckInID.Text = rdr.GetValue(0)
                            frmCheckOut_Room.txtGuestID.Text = rdr.GetValue(1)
                            frmCheckOut_Room.txtGuestName.Text = rdr.GetValue(2)
                            frmCheckOut_Room.txtRoomNo.Text = rdr.GetValue(3)
                            frmCheckOut_Room.txtRoomCharges.Text = rdr.GetValue(4)
                            frmCheckOut_Room.dtpDateIn.Text = rdr.GetValue(5)
                            frmCheckOut_Room.dtpDateOut.Text = rdr.GetValue(6)
                            frmCheckOut_Room.txtNoOfDays.Text = rdr.GetValue(7)
                            frmCheckOut_Room.txtNoOfMales.Text = rdr.GetValue(8)
                            frmCheckOut_Room.txtNoOfFemales.Text = rdr.GetValue(9)
                            frmCheckOut_Room.txtNoOfKids.Text = rdr.GetValue(10)
                            frmCheckOut_Room.txtNoOfExtraBed.Text = rdr.GetValue(11)
                            frmCheckOut_Room.txtNoOfExtraPerson.Text = rdr.GetValue(12)
                            frmCheckOut_Room.txtRoomOrderCharges.Text = rdr.GetValue(13) + Val(txtRoomOrderCharges.Text)
                            frmCheckOut_Room.txtExtraPersonCharges.Text = rdr.GetValue(14)
                            frmCheckOut_Room.txtTotalRoomCharges.Text = rdr.GetValue(15)
                            frmCheckOut_Room.txtExtraBedCharges.Text = rdr.GetValue(16)
                            frmCheckOut_Room.txtLaundryCharges.Text = rdr.GetValue(17) + Val(txtLaundryCharges.Text)
                            frmCheckOut_Room.txtDiscountPer.Text = rdr.GetValue(18)
                            frmCheckOut_Room.txtDiscountAmount.Text = rdr.GetValue(19)
                            frmCheckOut_Room.txtServiceTaxPer.Text = rdr.GetValue(20)
                            frmCheckOut_Room.txtServiceTaxAmount.Text = rdr.GetValue(21)
                            frmCheckOut_Room.txtLuxuryTaxPer.Text = rdr.GetValue(22)
                            frmCheckOut_Room.txtLuxuryTaxAmount.Text = rdr.GetValue(23)
                            frmCheckOut_Room.txtSubTotal.Text = rdr.GetValue(24)
                            frmCheckOut_Room.txtGrandTotal.Text = rdr.GetValue(25)
                            frmCheckOut_Room.txtTotalPaid.Text = rdr.GetValue(26)
                            frmCheckOut_Room.txtBalance.Text = rdr.GetValue(27)
                            frmCheckOut_Room.txtRoomID.Text = rdr.GetValue(28)
                            frmCheckOut_Room.txtPlanCode.Text = rdr.GetValue(29)
                            frmCheckOut_Room.txtOtherCharges.Text = rdr.GetValue(30)
                            frmCheckOut_Room.dtpDateIn.Enabled = False
                            frmCheckOut_Room.dtpDateOut.Enabled = False
                        End If
                        frmCheckOut_Room.Fill()
                        con.Close()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sqln As String = "SELECT RTRIM(PaymentMode),CheckIn_Payment.TotalPaid,PaymentDate from CheckIn_Room,CheckIN_Payment where CheckIn_Room.Cin_ID=CheckIn_Payment.CheckInID and CheckInID=@d1 and CheckIn_Payment.TotalPaid > 0"
                        cmd = New SqlCommand(sqln, con)
                        cmd.Parameters.AddWithValue("@d1", dr.Cells(0).Value.ToString())
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        frmCheckOut_Room.DataGridView2.Rows.Clear()
                        While (rdr.Read() = True)
                            frmCheckOut_Room.DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), "Not allowed")
                        End While
                        con.Close()
                        frmCheckOut_Room.lblStatus.Text = "Not allowed"
                        frmCheckOut_Room.GetPlan()
                        frmCheckOut_Room.txtCheckInID.Text = dr.Cells(0).Value.ToString
                    End If

                End If
                If rbRoomServices.Checked = True Then
                    Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
                    frmOrder.Reset()
                    frmOrder.lblUser.Text = lblUser.Text
                    frmOrder.Show()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmOrder.txtCheckedInID.Text = dr.Cells(0).Value.ToString()
                    frmOrder.txtGuestID.Text = dr.Cells(1).Value.ToString()
                    frmOrder.txtGuestName.Text = dr.Cells(4).Value.ToString()
                    frmOrder.txtRoomNo.Text = dr.Cells(2).Value.ToString()
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = con.CreateCommand()
                    cmd.CommandText = "SELECT RTRIM(ContactNo),ID from Guest WHERE GuestId='" & dr.Cells(1).Value & "'"
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        frmOrder.txtContactNo.Text = rdr.GetValue(0)
                        frmOrder.txtG_ID.Text = rdr.GetValue(1)
                    End If
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    frmOrder.fillFoodName()
                    frmOrder.fillLiquorName()
                End If
                If rbLaundry.Checked = True Then
                    Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
                    frmLaundryBilling.Reset()
                    frmLaundryBilling.lblUser.Text = lblUser.Text
                    frmLaundryBilling.Show()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmLaundryBilling.txtCheckedInID.Text = dr.Cells(0).Value.ToString()
                    frmLaundryBilling.txtGuestID.Text = dr.Cells(1).Value.ToString()
                    frmLaundryBilling.txtGuestName.Text = dr.Cells(4).Value.ToString()
                    frmLaundryBilling.txtRoomNo.Text = dr.Cells(2).Value.ToString()
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = con.CreateCommand()
                    cmd.CommandText = "SELECT RTRIM(ContactNo),ID from Guest WHERE GuestId='" & dr.Cells(1).Value & "'"
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        frmLaundryBilling.txtContactNo.Text = rdr.GetValue(0)
                        frmLaundryBilling.txtG_ID.Text = rdr.GetValue(1)
                    End If
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    frmLaundryBilling.fillServiceName()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub DataGridView2_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView2.RowHeaderMouseClick
        Try
            If DataGridView2.Rows.Count > 0 Then
                If rbCheckIN_Reservation.Checked = False And rbReservation.Checked = False Then
                    MessageBox.Show("Please select operation", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                If rbCheckIN_Reservation.Checked = True Then
                    Dim dr As DataGridViewRow = DataGridView2.SelectedRows(0)
                    Dim Res As String = dr.Cells(0).Value

                    Res = Res.Substring(0, 1)

                    If (Res = "R" Or Res = "S") Then
                        frmCheckIN_Room.lblUser.Text = lblUser.Text
                        frmCheckIN_Room.Reset()
                        frmCheckIN_Room.Show()
                        frmCheckIN_Room.btnSave.Enabled = False
                        frmCheckIN_Room.btnDelete.Enabled = True
                        frmCheckIN_Room.btnRoomAvailability.Enabled = False
                        frmCheckIN_Room.cmbRoomNo.Text = dr.Cells(2).Value.ToString
                        frmCheckIN_Room.cmbRoomNo1.Text = dr.Cells(2).Value.ToString
                        frmCheckIN_Room.cmbPlanCode.DropDownStyle = ComboBoxStyle.DropDown
                        frmCheckIN_Room.cmbPlanCode.Text = dr.Cells(3).Value.ToString
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sql1 As String = "SELECT ID,RTRIM(Address), RTRIM(City),RTRIM( ContactNo), RTRIM(Gender), RTRIM(Occupation), RTRIM(Religion), RTRIM(IDType), RTRIM(IDNumber),RTRIM(Country) from Guest WHERE GuestId='" & dr.Cells(1).Value & "'"
                        cmd = New SqlCommand(sql1, con)
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        If (rdr.Read() = True) Then
                            frmCheckIN_Room.txtID.Text = rdr.GetValue(0)
                            frmCheckIN_Room.txtGuestAddress.Text = rdr.GetValue(1)
                            frmCheckIN_Room.txtGuestCity.Text = rdr.GetValue(2)
                            frmCheckIN_Room.txtGuestContactNo.Text = rdr.GetValue(3)
                            frmCheckIN_Room.txtGender.Text = rdr.GetValue(4)
                            frmCheckIN_Room.txtOccupation.Text = rdr.GetValue(5)
                            frmCheckIN_Room.txtReligion.Text = rdr.GetString(6)
                            frmCheckIN_Room.txtIDType.Text = rdr.GetValue(7)
                            frmCheckIN_Room.txtIDNumber.Text = rdr.GetValue(8)
                            frmCheckIN_Room.txtCountry.Text = rdr.GetValue(9)
                        End If

                        con.Close()
                        con = New SqlConnection(cs)
                        con.Open()

                        Dim sql As String = "Select RTRIM(Reserve_ID), RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Room.RoomNo) as [Room No.], 
                    RTRIM(Reservation.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out], 
                    RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids],
                    RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(ExtraPersonCharges) as [Extra Person Charges], 
                    RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges], RTRIM(DiscountPer) as [Discount %], 
                    RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %], RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],
                    RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(TotalPaid) as [Total Paid],RTRIM(ReservationNo) from Guest,Room,Reservation 
                    where Guest.ID=Reservation.Guest_ID and Status='Reserved' and Room.R_ID=Reservation.RoomID and Reserve_ID=" & Convert.ToString(dr.Cells(0).Value).Remove(0, 1) & ""

                        cmd = New SqlCommand(sql, con)
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        If (rdr.Read() = True) Then
                            frmCheckIN_Room.txtReservationID.Text = rdr.GetValue(0)
                            frmCheckIN_Room.txtGuestID.Text = rdr.GetValue(1)
                            frmCheckIN_Room.txtGuestName.Text = rdr.GetValue(2)
                            frmCheckIN_Room.txtRoomCharges.Text = rdr.GetValue(4)
                            frmCheckIN_Room.dtpDateIn.Text = rdr.GetValue(5)
                            frmCheckIN_Room.dtpDateOut.Text = rdr.GetValue(6)
                            frmCheckIN_Room.txtNoOfDays.Text = rdr.GetValue(7)
                            frmCheckIN_Room.txtNoOfMales.Text = rdr.GetValue(8)
                            frmCheckIN_Room.txtNoOfFemales.Text = rdr.GetValue(9)
                            frmCheckIN_Room.txtNoOfKids.Text = rdr.GetValue(10)
                            frmCheckIN_Room.txtNoOfExtraBed.Text = rdr.GetValue(11)
                            frmCheckIN_Room.txtNoOfExtraPerson.Text = rdr.GetValue(12)
                            frmCheckIN_Room.txtExtraPersonCharges.Text = rdr.GetValue(13)
                            frmCheckIN_Room.txtTotalRoomCharges.Text = rdr.GetValue(14)
                            frmCheckIN_Room.txtExtraBedCharges.Text = rdr.GetValue(15)
                            frmCheckIN_Room.txtDiscountPer.Text = rdr.GetValue(16)
                            frmCheckIN_Room.txtDiscountAmount.Text = rdr.GetValue(17)
                            frmCheckIN_Room.txtServiceTaxPer.Text = rdr.GetValue(18)
                            frmCheckIN_Room.txtServiceTaxAmount.Text = rdr.GetValue(19)
                            frmCheckIN_Room.txtLuxuryTaxPer.Text = rdr.GetValue(20)
                            frmCheckIN_Room.txtLuxuryTaxAmount.Text = rdr.GetValue(21)
                            frmCheckIN_Room.txtTotalPaid.Text = rdr.GetValue(22)
                            frmCheckIN_Room.txtReservationNo.Text = rdr.GetValue(23)
                            frmCheckIN_Room.CheckId(rdr.GetValue(1))
                        End If

                        frmCheckIN_Room.Compute()
                        con.Close()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sqlq As String = "SELECT RTRIM(PaymentMode),Reservation_Payment.TotalPaid,PaymentDate from Reservation,Reservation_Payment where Reservation.Reserve_ID=Reservation_Payment.ReservationID and ReservationID=@d1 and Reservation_Payment.TotalPaid > 0"
                        cmd = New SqlCommand(sqlq, con)
                        cmd.Parameters.AddWithValue("@d1", Convert.ToString(dr.Cells(0).Value).Remove(0, 1))
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        frmCheckIN_Room.DataGridView2.Rows.Clear()
                        While (rdr.Read() = True)
                            frmCheckIN_Room.DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), "Not allowed")
                        End While

                        frmCheckIN_Room.LoadRoomPayments()

                        '                    For Each element [ As datatype ] In group
                        '    [ statements ]
                        '    [ Continue For ]
                        '    [ statements ]
                        '    [ Exit For ]
                        '    [ statements ]
                        'Next [ element ]
                        con.Close()
                        frmCheckIN_Room.lblUser.Text = lblUser.Text
                        frmCheckIN_Room.cmbPlanCode.Enabled = False
                        frmCheckIN_Room.GetPlan()
                        frmCheckIN_Room.btnDelete.Enabled = False
                        frmCheckIN_Room.btnSave.Enabled = False
                        frmCheckIN_Room.dtpDateIn.Enabled = False
                        frmCheckIN_Room.dtpDateOut.Enabled = False
                        frmCheckIN_Room.cmbRoomNo.Enabled = False
                        frmCheckIN_Room.btnRoomAvailability.Enabled = False
                        frmCheckIN_Room.btnPrint.Enabled = False
                        frmCheckIN_Room.TotalPayment()
                        frmCheckIN_Room.Compute1()
                        frmCheckIN_Room.Fill()
                        frmCheckIN_Room.lblStatus.Text = "Not allowed"
                        frmCheckIN_Room.btnCheckedIN.Enabled = True
                    Else
                        frmGroupReservation.Label1.Text = "Group Check In"
                        frmGroupReservation.lblUser.Text = lblUser.Text
                        frmGroupReservation.Reset()
                        frmGroupReservation.Show()
                        frmGroupReservation.btnSave.Enabled = False
                        frmGroupReservation.btnPrint.Enabled = True
                        frmGroupReservation.btnDelete.Enabled = True
                        'frmGroupReservation.btnRoomAvailability.Enabled = False
                        frmGroupReservation.cmbRoomNo.Text = dr.Cells(2).Value.ToString
                        frmGroupReservation.cmbRoomNo1.Text = dr.Cells(2).Value.ToString
                        frmGroupReservation.cmbPlanCode.DropDownStyle = ComboBoxStyle.DropDown
                        frmGroupReservation.cmbPlanCode.Text = dr.Cells(3).Value.ToString
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sql1 As String = "SELECT ID,RTRIM(Address), RTRIM(City),RTRIM( ContactNo), RTRIM(Gender), RTRIM(Occupation), RTRIM(Religion), RTRIM(IDType), RTRIM(IDNumber),RTRIM(Country) from Guest WHERE GuestId='" & dr.Cells(1).Value & "'"
                        cmd = New SqlCommand(sql1, con)
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        If (rdr.Read() = True) Then
                            frmGroupReservation.txtID.Text = rdr.GetValue(0)
                            frmGroupReservation.txtGuestContactNo.Text = rdr.GetValue(3)
                        End If
                        con.Close()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sql As String = "Select RTRIM(Reserve_ID), RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name], '' as [Room No.], 
                    RTRIM(Reservation.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out], 
                    RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], 
                    RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(ReservationNo), 
                    RTRIM(ExtraPersonCharges) as [Extra Person Charges], RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges],
                    ReservationDate, RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %], 
                    RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], 
                    RTRIM(SubTotal) as [Sub Total], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance], 
                    RTRIM(Reservation.Notes) as [Notes] from Guest,Reservation where Guest.ID=Reservation.Guest_ID and Status='Reserved' 
                    and Reserve_ID=" & Convert.ToString(dr.Cells(0).Value).Remove(0, 1) & ""

                        cmd = New SqlCommand(sql, con)
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        If (rdr.Read() = True) Then
                            frmGroupReservation.txtReservationID.Text = rdr.GetValue(0)
                            frmGroupReservation.txtGuestID.Text = rdr.GetValue(1)
                            frmGroupReservation.txtGuestName.Text = rdr.GetValue(2)
                            frmGroupReservation.txtRoomCharges.Text = rdr.GetValue(4)
                            frmGroupReservation.dtpDateIn.Text = rdr.GetValue(5)
                            frmGroupReservation.dtpDateOut.Text = rdr.GetValue(6)
                            frmGroupReservation.txtNoOfDays.Text = rdr.GetValue(7)
                            frmGroupReservation.txtNoOfMales.Text = rdr.GetValue(8)
                            frmGroupReservation.txtNoOfFemales.Text = rdr.GetValue(9)
                            frmGroupReservation.txtNoOfKids.Text = rdr.GetValue(10)
                            frmGroupReservation.txtNoOfExtraBed.Text = rdr.GetValue(11)
                            frmGroupReservation.txtNoOfExtraPerson.Text = rdr.GetValue(12)
                            frmGroupReservation.txtReservationNo.Text = rdr.GetValue(13)
                            frmGroupReservation.txtExtraPersonCharges.Text = rdr.GetValue(14)
                            frmGroupReservation.txtTotalRoomCharges.Text = rdr.GetValue(15)
                            frmGroupReservation.txtExtraBedCharges.Text = rdr.GetValue(16)
                            frmGroupReservation.dtpReservationDate.Value = rdr.GetValue(17)
                            frmGroupReservation.txtDiscountPer.Text = rdr.GetValue(18)
                            frmGroupReservation.txtDiscountAmount.Text = rdr.GetValue(19)
                            frmGroupReservation.txtServiceTaxPer.Text = rdr.GetValue(20)
                            frmGroupReservation.txtServiceTaxAmount.Text = rdr.GetValue(21)
                            frmGroupReservation.txtGroupTax.Text = rdr.GetValue(21)
                            frmGroupReservation.txtLuxuryTaxPer.Text = rdr.GetValue(22)
                            frmGroupReservation.txtLuxuryTaxAmount.Text = rdr.GetValue(23)
                            frmGroupReservation.txtSubTotal.Text = rdr.GetValue(24)
                            frmGroupReservation.txtGrandTotal.Text = rdr.GetValue(25)

                            frmGroupReservation.txtTotalPaid.Text = rdr.GetValue(26)
                            frmGroupReservation.txtBalance.Text = rdr.GetValue(27)
                            frmGroupReservation.txtGroupBalance.Text = rdr.GetValue(27)
                            frmGroupReservation.txtGroupTotal.Text = rdr.GetValue(25)
                            'frmGroupReservation.txtNotes.Text = rdr.GetValue(28)
                        End If
                        frmReservation.Compute()

                        con.Close()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sqlq As String = "SELECT RTRIM(PaymentMode),Reservation_Payment.TotalPaid,PaymentDate from Reservation,Reservation_Payment where Reservation.Reserve_ID=Reservation_Payment.ReservationID and ReservationID=@d1 and Reservation_Payment.TotalPaid > 0"
                        cmd = New SqlCommand(sqlq, con)
                        cmd.Parameters.AddWithValue("@d1", Convert.ToString(dr.Cells(0).Value).Remove(0, 1))
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        frmReservation.DataGridView2.Rows.Clear()
                        While (rdr.Read() = True)
                            frmReservation.DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), "Not allowed")
                        End While
                        con.Close()
                        frmGroupReservation.GetPlan()
                        'frmGroupReservation.CalGroupTotal()
                        frmGroupReservation.btnCancelReservation.Enabled = False
                        frmGroupReservation.cmbPlanCode.Enabled = False
                        frmGroupReservation.btnCancelReservation.Enabled = False
                        frmGroupReservation.btnCancelReservationReceipt.Enabled = False
                        frmGroupReservation.btnCheckedIN.Visible = True
                        frmGroupReservation.btnCheckOut.Visible = False
                        frmGroupReservation.btnSave.Enabled = False
                        frmGroupReservation.btnNew.Enabled = False
                        frmGroupReservation.btnDelete.Enabled = True
                        frmGroupReservation.lblStatus.Text = "Not allowed"
                        frmGroupReservation.txtStatus.Text = "Reserved"
                        frmGroupReservation.LoadRoomPayments()
                        'frmGroupReservation.Button2.Visible = True
                        frmGroupReservation.btnAddRooms.Visible = False
                        frmGroupReservation.LoadRoomPayments()
                        frmGroupReservation.LoadRooms()
                    End If
                End If

                    If rbReservation.Checked = True Then
                    Dim dr As DataGridViewRow = DataGridView2.SelectedRows(0)
                    Dim Res As String = dr.Cells(0).Value

                    Res = Res.Substring(0, 1)

                    If (Res = "R" Or Res = "S") Then
                        frmReservation.Button2.Visible = True
                        frmReservation.lblUser.Text = lblUser.Text
                        frmReservation.Reset()
                        frmReservation.Show()
                        frmReservation.btnSave.Enabled = False
                        frmReservation.btnPrint.Enabled = True
                        frmReservation.btnDelete.Enabled = True
                        frmReservation.btnRoomAvailability.Enabled = False
                        frmReservation.cmbRoomNo.Text = dr.Cells(2).Value.ToString
                        frmReservation.cmbRoomNo1.Text = dr.Cells(2).Value.ToString
                        frmReservation.cmbPlanCode.DropDownStyle = ComboBoxStyle.DropDown
                        frmReservation.cmbPlanCode.Text = dr.Cells(3).Value.ToString
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sql1 As String = "SELECT ID,RTRIM(Address), RTRIM(City),RTRIM( ContactNo), RTRIM(Gender), RTRIM(Occupation), RTRIM(Religion), RTRIM(IDType), RTRIM(IDNumber),RTRIM(Country) from Guest WHERE GuestId='" & dr.Cells(1).Value & "'"
                        cmd = New SqlCommand(sql1, con)
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        If (rdr.Read() = True) Then
                            frmReservation.txtID.Text = rdr.GetValue(0)
                            frmReservation.txtGuestAddress.Text = rdr.GetValue(1)
                            frmReservation.txtGuestCity.Text = rdr.GetValue(2)
                            frmReservation.txtGuestContactNo.Text = rdr.GetValue(3)
                            frmReservation.txtGender.Text = rdr.GetValue(4)
                            frmReservation.txtOccupation.Text = rdr.GetValue(5)
                            frmReservation.txtReligion.Text = rdr.GetString(6)
                            frmReservation.txtIDType.Text = rdr.GetValue(7)
                            frmReservation.txtIDNumber.Text = rdr.GetValue(8)
                            frmReservation.txtCountry.Text = rdr.GetValue(9)
                        End If
                        con.Close()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sql As String = "Select RTRIM(Reserve_ID), RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Room.RoomNo) as [Room No.], 
                    RTRIM(Reservation.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out], 
                    RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], 
                    RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(ReservationNo), 
                    RTRIM(ExtraPersonCharges) as [Extra Person Charges], RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges],
                    ReservationDate, RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %], 
                    RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], 
                    RTRIM(SubTotal) as [Sub Total], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance], 
                    RTRIM(Reservation.Notes) as [Notes] from Guest,Room,Reservation where Guest.ID=Reservation.Guest_ID and Status='Reserved' and 
                    Room.R_ID=Reservation.RoomID and Reserve_ID=" & Convert.ToString(dr.Cells(0).Value).Remove(0, 1) & ""

                        cmd = New SqlCommand(sql, con)
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        If (rdr.Read() = True) Then
                            frmReservation.txtReservationID.Text = rdr.GetValue(0)
                            frmReservation.txtGuestID.Text = rdr.GetValue(1)
                            frmReservation.txtGuestName.Text = rdr.GetValue(2)
                            frmReservation.txtRoomCharges.Text = rdr.GetValue(4)
                            frmReservation.dtpDateIn.Text = rdr.GetValue(5)
                            frmReservation.dtpDateOut.Text = rdr.GetValue(6)
                            frmReservation.txtNoOfDays.Text = rdr.GetValue(7)
                            frmReservation.txtNoOfMales.Text = rdr.GetValue(8)
                            frmReservation.txtNoOfFemales.Text = rdr.GetValue(9)
                            frmReservation.txtNoOfKids.Text = rdr.GetValue(10)
                            frmReservation.txtNoOfExtraBed.Text = rdr.GetValue(11)
                            frmReservation.txtNoOfExtraPerson.Text = rdr.GetValue(12)
                            frmReservation.txtReservationNo.Text = rdr.GetValue(13)
                            frmReservation.txtExtraPersonCharges.Text = rdr.GetValue(14)
                            frmReservation.txtTotalRoomCharges.Text = rdr.GetValue(15)
                            frmReservation.txtExtraBedCharges.Text = rdr.GetValue(16)
                            frmReservation.dtpReservationDate.Value = rdr.GetValue(17)
                            frmReservation.txtDiscountPer.Text = rdr.GetValue(18)
                            frmReservation.txtDiscountAmount.Text = rdr.GetValue(19)
                            frmReservation.txtServiceTaxPer.Text = rdr.GetValue(20)
                            frmReservation.txtServiceTaxAmount.Text = rdr.GetValue(21)
                            frmReservation.txtLuxuryTaxPer.Text = rdr.GetValue(22)
                            frmReservation.txtLuxuryTaxAmount.Text = rdr.GetValue(23)
                            frmReservation.txtSubTotal.Text = rdr.GetValue(24)
                            frmReservation.txtGrandTotal.Text = rdr.GetValue(25)
                            frmReservation.txtTotalPaid.Text = rdr.GetValue(26)
                            frmReservation.txtBalance.Text = rdr.GetValue(27)
                            frmReservation.txtNotes.Text = rdr.GetValue(28)
                        End If
                        frmReservation.Compute()
                        con.Close()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sqlq As String = "SELECT RTRIM(PaymentMode),Reservation_Payment.TotalPaid,PaymentDate from Reservation,Reservation_Payment where Reservation.Reserve_ID=Reservation_Payment.ReservationID and ReservationID=@d1 and Reservation_Payment.TotalPaid > 0"
                        cmd = New SqlCommand(sqlq, con)
                        cmd.Parameters.AddWithValue("@d1", Convert.ToString(dr.Cells(0).Value).Remove(0, 1))
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        frmReservation.DataGridView2.Rows.Clear()
                        While (rdr.Read() = True)
                            frmReservation.DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), "Not allowed")
                        End While
                        con.Close()
                        frmReservation.GetPlan()
                        frmReservation.CalGroupTotal()
                        frmReservation.btnCancelReservation.Enabled = True
                        frmReservation.cmbPlanCode.Enabled = False
                        frmReservation.lblStatus.Text = "Not allowed"
                        frmReservation.txtStatus.Text = "Reserved"
                        frmReservation.LoadRoomPayments()
                        frmReservation.Button2.Visible = True
                        frmReservation.btnAddRooms.Visible = False
                    Else
                        'frmGroupReservation.Button2.Visible = True
                        frmGroupReservation.lblUser.Text = lblUser.Text
                        frmGroupReservation.Reset()
                        frmGroupReservation.Show()
                        frmGroupReservation.btnSave.Enabled = False
                        frmGroupReservation.btnPrint.Enabled = True
                        frmGroupReservation.btnDelete.Enabled = True
                        'frmGroupReservation.btnRoomAvailability.Enabled = False
                        frmGroupReservation.cmbRoomNo.Text = dr.Cells(2).Value.ToString
                        frmGroupReservation.cmbRoomNo1.Text = dr.Cells(2).Value.ToString
                        frmGroupReservation.cmbPlanCode.DropDownStyle = ComboBoxStyle.DropDown
                        frmGroupReservation.cmbPlanCode.Text = dr.Cells(3).Value.ToString
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sql1 As String = "SELECT ID,RTRIM(Address), RTRIM(City),RTRIM( ContactNo), RTRIM(Gender), RTRIM(Occupation), RTRIM(Religion), RTRIM(IDType), RTRIM(IDNumber),RTRIM(Country) from Guest WHERE GuestId='" & dr.Cells(1).Value & "'"
                        cmd = New SqlCommand(sql1, con)
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        If (rdr.Read() = True) Then
                            frmGroupReservation.txtID.Text = rdr.GetValue(0)
                            frmGroupReservation.txtGuestContactNo.Text = rdr.GetValue(3)
                        End If
                        con.Close()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sql As String = "Select RTRIM(Reserve_ID), RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name], '' as [Room No.], 
                    RTRIM(Reservation.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out], 
                    RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], 
                    RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(ReservationNo), 
                    RTRIM(ExtraPersonCharges) as [Extra Person Charges], RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges],
                    ReservationDate, RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %], 
                    RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], 
                    RTRIM(SubTotal) as [Sub Total], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance], 
                    RTRIM(Reservation.Notes) as [Notes] from Guest,Reservation where Guest.ID=Reservation.Guest_ID and Status='Reserved' 
                    and Reserve_ID=" & Convert.ToString(dr.Cells(0).Value).Remove(0, 1) & ""

                        cmd = New SqlCommand(sql, con)
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        If (rdr.Read() = True) Then
                            frmGroupReservation.txtReservationID.Text = rdr.GetValue(0)
                            frmGroupReservation.txtGuestID.Text = rdr.GetValue(1)
                            frmGroupReservation.txtGuestName.Text = rdr.GetValue(2)
                            frmGroupReservation.txtRoomCharges.Text = rdr.GetValue(4)
                            frmGroupReservation.dtpDateIn.Text = rdr.GetValue(5)
                            frmGroupReservation.dtpDateOut.Text = rdr.GetValue(6)
                            frmGroupReservation.txtNoOfDays.Text = rdr.GetValue(7)
                            frmGroupReservation.txtNoOfMales.Text = rdr.GetValue(8)
                            frmGroupReservation.txtNoOfFemales.Text = rdr.GetValue(9)
                            frmGroupReservation.txtNoOfKids.Text = rdr.GetValue(10)
                            frmGroupReservation.txtNoOfExtraBed.Text = rdr.GetValue(11)
                            frmGroupReservation.txtNoOfExtraPerson.Text = rdr.GetValue(12)
                            frmGroupReservation.txtReservationNo.Text = rdr.GetValue(13)
                            frmGroupReservation.txtExtraPersonCharges.Text = rdr.GetValue(14)
                            frmGroupReservation.txtTotalRoomCharges.Text = rdr.GetValue(15)
                            frmGroupReservation.txtExtraBedCharges.Text = rdr.GetValue(16)
                            frmGroupReservation.dtpReservationDate.Value = rdr.GetValue(17)
                            frmGroupReservation.txtDiscountPer.Text = rdr.GetValue(18)
                            frmGroupReservation.txtDiscountAmount.Text = rdr.GetValue(19)
                            frmGroupReservation.txtServiceTaxPer.Text = rdr.GetValue(20)
                            frmGroupReservation.txtServiceTaxAmount.Text = rdr.GetValue(21)
                            frmGroupReservation.txtGroupTax.Text = rdr.GetValue(21)
                            frmGroupReservation.txtLuxuryTaxPer.Text = rdr.GetValue(22)
                            frmGroupReservation.txtLuxuryTaxAmount.Text = rdr.GetValue(23)
                            frmGroupReservation.txtSubTotal.Text = rdr.GetValue(24)
                            frmGroupReservation.txtGrandTotal.Text = rdr.GetValue(25)
                            frmGroupReservation.txtGroupTotal.Text = rdr.GetValue(25)
                            frmGroupReservation.txtTotalPaid.Text = rdr.GetValue(26)
                            frmGroupReservation.txtBalance.Text = rdr.GetValue(27)
                            frmGroupReservation.txtGroupBalance.Text = rdr.GetValue(27)
                            'frmGroupReservation.txtNotes.Text = rdr.GetValue(28)
                        End If
                        frmReservation.Compute()
                        con.Close()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sqlq As String = "SELECT RTRIM(PaymentMode),Reservation_Payment.TotalPaid,PaymentDate from Reservation,Reservation_Payment where Reservation.Reserve_ID=Reservation_Payment.ReservationID and ReservationID=@d1 and Reservation_Payment.TotalPaid > 0"
                        cmd = New SqlCommand(sqlq, con)
                        cmd.Parameters.AddWithValue("@d1", Convert.ToString(dr.Cells(0).Value).Remove(0, 1))
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        frmReservation.DataGridView2.Rows.Clear()
                        While (rdr.Read() = True)
                            frmReservation.DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), "Not allowed")
                        End While
                        con.Close()
                        frmGroupReservation.GetPlan()
                        '  frmGroupReservation.CalGroupTotal()
                        frmGroupReservation.btnCancelReservation.Enabled = True
                        frmGroupReservation.cmbPlanCode.Enabled = False
                        frmGroupReservation.lblStatus.Text = "Not allowed"
                        frmGroupReservation.txtStatus.Text = "Reserved"
                        frmGroupReservation.LoadRoomPayments()
                        'frmGroupReservation.Button2.Visible = True
                        frmGroupReservation.btnAddRooms.Visible = False
                        frmGroupReservation.btnCancelReservation.Enabled = True
                        frmGroupReservation.btnCancelReservationReceipt.Enabled = True
                        frmGroupReservation.btnCheckedIN.Visible = False
                        frmGroupReservation.btnCheckOut.Visible = False
                        frmGroupReservation.btnSave.Enabled = False
                        frmGroupReservation.btnNew.Enabled = False
                        frmGroupReservation.btnDelete.Enabled = True
                        frmGroupReservation.LoadRooms()
                        frmGroupReservation.LoadRoomPayments()
                    End If

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView2_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView2.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView2.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView2.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub EmployeeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeToolStripMenuItem1.Click
        frmEmployeeRegistration.lblUser.Text = lblUser.Text
        frmEmployeeRegistration.Reset()
        frmEmployeeRegistration.ShowDialog()
    End Sub

    Private Sub EmployeesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeesToolStripMenuItem.Click
        frmEmployeesRecord.Reset()
        frmEmployeesRecord.ShowDialog()
    End Sub

    Private Sub AdvanceEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvanceEntryToolStripMenuItem.Click
        frmAdvanceEntryRecord.Reset()
        frmAdvanceEntryRecord.ShowDialog()
    End Sub


    Private Sub DeductionEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeductionEntryToolStripMenuItem.Click
        frmDeductionRecord.Reset()
        frmDeductionRecord.ShowDialog()
    End Sub

    Private Sub EmployeePayment2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeePayment2ToolStripMenuItem.Click
        frmEmployeePaymentRecord.Reset()
        frmEmployeePaymentRecord.ShowDialog()
    End Sub

    Private Sub EmployeeAttendanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeAttendanceToolStripMenuItem.Click
        frmAttendanceEntryRecord.Reset()
        frmAttendanceEntryRecord.ShowDialog()
    End Sub

    Private Sub EmployeeAttendnace2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeAttendnace2ToolStripMenuItem.Click
        frmTotalAttendanceRecord.Reset()
        frmTotalAttendanceRecord.ShowDialog()
    End Sub
    Sub Backup()
        Try

            Dim destdir As String = "HMS_DB " & DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") & ".bak"
            Dim objdlg As New SaveFileDialog
            objdlg.FileName = destdir
            objdlg.ShowDialog()
            Filename = objdlg.FileName
            Cursor = Cursors.WaitCursor
            Timer2.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "backup database HMS_DB to disk='" & Filename & "'with init,stats=10"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupToolStripMenuItem.Click
        Backup()
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Cursor = Cursors.Default
        Timer2.Enabled = False
    End Sub

    Private Sub RestoreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoreToolStripMenuItem.Click
        Try
            With OpenFileDialog1
                .Filter = ("DB Backup File|*.bak;")
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog1.FileName = ""

            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                Timer2.Enabled = True
                SqlConnection.ClearAllPools()
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "USE Master ALTER DATABASE hms_db SET Single_User WITH Rollback Immediate Restore database hms_db FROM disk='" & OpenFileDialog1.FileName & "' WITH REPLACE ALTER DATABASE hms_db SET Multi_User "
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.ExecuteReader()
                con.Close()
                Dim st As String = "Sucessfully performed the restore"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully performed", "Database Restore", MessageBoxButtons.OK, MessageBoxIcon.Information)
                GetData()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RestaurantBillingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestaurantBillingToolStripMenuItem1.Click
        frmRestaurantBillingReport.Reset()
        frmRestaurantBillingReport.ShowDialog()
    End Sub

    Private Sub RoomOrdersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoomOrdersToolStripMenuItem.Click
        frmRoomOrdersReport.Reset()
        frmRoomOrdersReport.ShowDialog()
    End Sub

    Private Sub GardenReservationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GardenReservationToolStripMenuItem.Click
        frmGardenReservationReport.Reset()
        frmGardenReservationReport.ShowDialog()
    End Sub

    Private Sub RoomReservationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoomReservationToolStripMenuItem.Click
        frmRoomReservationReport.Reset()
        frmRoomReservationReport.ShowDialog()
    End Sub

    Private Sub SalarySlipsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalarySlipsToolStripMenuItem.Click
        frmSalarySlipsReport.Reset()
        frmSalarySlipsReport.ShowDialog()
    End Sub

    Private Sub EmployeePaymentToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeePaymentToolStripMenuItem1.Click
        frmEmployeePaymentReport.Reset()
        frmEmployeePaymentReport.ShowDialog()
    End Sub

    Private Sub HallReservationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HallReservationToolStripMenuItem.Click
        frmHallReservationReport.Reset()
        frmHallReservationReport.ShowDialog()
    End Sub

    Private Sub RoomInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoomInvoiceToolStripMenuItem.Click
        frmRoomBill.Reset()
        frmRoomBill.ShowDialog()
    End Sub

    Private Sub HallReservationInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HallReservationInvoiceToolStripMenuItem.Click
        frmHallReservationInvoice.Reset()
        frmHallReservationInvoice.ShowDialog()
    End Sub

    Private Sub GardenReservationInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GardenReservationInvoiceToolStripMenuItem.Click
        frmGardenReservationInvoice.Reset()
        frmGardenReservationInvoice.ShowDialog()
    End Sub

    Private Sub RestaurantInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestaurantInvoiceToolStripMenuItem.Click
        frmRestaurantBill.Reset()
        frmRestaurantBill.ShowDialog()
    End Sub

    Private Sub RoomOrderInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoomOrderInvoiceToolStripMenuItem.Click
        frmFoodOrderBill.Reset()
        frmFoodOrderBill.ShowDialog()
    End Sub

    Private Sub GuestToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuestToolStripMenuItem2.Click
        frmGuestReport.Reset()
        frmGuestReport.ShowDialog()
    End Sub

    Private Sub SalarySlipToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalarySlipToolStripMenuItem.Click
        frmSalaryslip.Reset()
        frmSalaryslip.ShowDialog()
    End Sub

    Private Sub AdvanceEntryToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvanceEntryToolStripMenuItem2.Click
        frmAdvanceEntryReport.Reset()
        frmAdvanceEntryReport.ShowDialog()
    End Sub

    Private Sub DeductionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeductionToolStripMenuItem.Click
        frmDeductionReport.Reset()
        frmDeductionReport.ShowDialog()
    End Sub


    Private Sub frmMainMenu_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
    End Sub


    Private Sub LaundryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaundryToolStripMenuItem.Click
        frmLaundry_master.lblUser.Text = lblUser.Text
        frmLaundry_master.Reset()
        frmLaundry_master.ShowDialog()
    End Sub

    Private Sub LaundryBillingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaundryBillingToolStripMenuItem1.Click
        frmLaundryBilling.lblUser.Text = lblUser.Text
        frmLaundryBilling.Reset()
        frmLaundryBilling.ShowDialog()
    End Sub

    Private Sub LaundryBillingToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LaundryBillingToolStripMenuItem2.Click
        frmLaundryBillingRecord.Reset()
        frmLaundryBillingRecord.ShowDialog()
    End Sub

    Private Sub LaundaryBillToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaundaryBillToolStripMenuItem.Click
        frmLaundryBill.Reset()
        frmLaundryBill.ShowDialog()
    End Sub

    Private Sub WordpadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WordpadToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Wordpad.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MSWordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MSWordToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("WinWord.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TaskManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaskManagerToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("TaskMgr.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MSPaintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MSPaintToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("MSPaint.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TableToolStripMenuItem.Click
        frmTable.lblUser.Text = lblUser.Text
        frmTable.Reset()
        frmTable.ShowDialog()
    End Sub

    Private Sub OrderToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrderToolStripMenuItem3.Click
        frmOrder.lblUser.Text = lblUser.Text
        frmOrder.Reset()
        frmOrder.ShowDialog()
    End Sub

    Private Sub LaundryBillingToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaundryBillingToolStripMenuItem3.Click
        frmLaundryBilling.lblUser.Text = lblUser.Text
        frmLaundryBilling.Reset()
        frmLaundryBilling.ShowDialog()
    End Sub


    Private Sub RestaurantBillingToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestaurantBillingToolStripMenuItem3.Click
        frmRestaurantBilling.lblUser.Text = lblUser.Text
        frmRestaurantBilling.Reset()
        frmRestaurantBilling.ShowDialog()
    End Sub


    Private Sub RestaurantBillingKOTToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestaurantBillingKOTToolStripMenuItem1.Click
        frmRestaurantBillingKOT.lblUser.Text = lblUser.Text
        frmRestaurantBillingKOT.Reset()
        frmRestaurantBillingKOT.Reset1()
        frmRestaurantBillingKOT.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ExportExcel(DataGridView1)
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ExportExcel(DataGridView2)
    End Sub

    Private Sub txtSearchByGuestName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchByGuestName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(CheckIn_Room.Cin_ID),RTRIM(Guest.GuestID), RTRIM(Room.RoomNo),RTRIM(PlanCode),RTRIM(GuestName),DateIN,DateOut from Guest,Room,Checkin_Room where Guest.ID=Checkin_room.GuestID and Room.R_ID=Checkin_Room.RoomID and Status='Check In' and GuestName like '%" & txtSearchByGuestName.Text & "%' Order by DateIN"
            cmd = New SqlCommand(sql, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6))
            End While
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                If Convert.ToDateTime(r.Cells(6).Value) <= System.DateTime.Now.Date Then
                    r.DefaultCellStyle.BackColor = Color.Red
                Else
                    r.DefaultCellStyle.BackColor = Color.LightGreen
                End If
            Next
            con.Close()
            DataGridView1.ClearSelection()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql1 As String = "Select RTRIM(Reservation.Reserve_ID),RTRIM(Guest.GuestID),RTRIM(Room.RoomNo),RTRIM(PlanCode),RTRIM(GuestName),DateIN,DateOut, GrandTotal, TotalPaid  from Guest,Room,Reservation where Guest.ID=Reservation.Guest_ID and Room.R_ID=Reservation.RoomID and Status='Reserved' and Guestname like '%" & TextBox1.Text & "%' Order by DateIN"
            cmd = New SqlCommand(sql1, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView2.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8))
            End While
            'For Each r As DataGridViewRow In Me.DataGridView2.Rows
            '    If Convert.ToDateTime(r.Cells(6).Value) <= System.DateTime.Now.Date Then
            '        r.DefaultCellStyle.BackColor = Color.Red
            '    Else
            '        r.DefaultCellStyle.BackColor = Color.LightGreen
            '    End If
            'Next
            For Each row As DataGridViewRow In DataGridView2.Rows
                If (Convert.ToInt32(row.Cells(7).Value) = Convert.ToInt32(row.Cells(8).Value)) Then
                    row.DefaultCellStyle.BackColor = Color.Green
                    row.DefaultCellStyle.ForeColor = Color.White
                Else
                    row.DefaultCellStyle.BackColor = Color.Red
                    row.DefaultCellStyle.ForeColor = Color.White
                End If
            Next
            con.Close()
            DataGridView2.ClearSelection()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtSearchByGuestName.Text = ""
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        rbRoomServices.Checked = False
        rbLaundry.Checked = False
        DataGridView1.ClearSelection()
        DataGridView3.ClearSelection()
        GetData()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        TextBox1.Text = ""
        rbCheckIN_Reservation.Checked = False
        rbReservation.Checked = False
        DataGridView3.ClearSelection()
        DataGridView2.ClearSelection()
        GetData()
    End Sub


    Private Sub CurrentAdvanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CurrentAdvanceToolStripMenuItem.Click
        frmCurrentAdvanceList.Reset()
        frmCurrentAdvanceList.ShowDialog()
    End Sub

    Private Sub GuestLedgerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuestLedgerToolStripMenuItem1.Click
        frmGuestLedgerRecord1.Reset()
        frmGuestLedgerRecord1.ShowDialog()
    End Sub

    Private Sub CurrentBalanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CurrentBalanceToolStripMenuItem.Click
        frmCurrentBalance.Reset()
        frmCurrentBalance.ShowDialog()
    End Sub



    Private Sub GuestLedgerToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuestLedgerToolStripMenuItem2.Click
        frmGuestBalanceEntry.lblUser.Text = lblUser.Text
        frmGuestBalanceEntry.Reset()
        frmGuestBalanceEntry.ShowDialog()
    End Sub

    Private Sub SmsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SmsToolStripMenuItem1.Click
        frmSMSSetting.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        frmVoucher.lblUser.Text = lblUser.Text
        frmVoucher.Reset()
        frmVoucher.ShowDialog()
    End Sub

    Private Sub ExpensesMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpensesMasterToolStripMenuItem.Click
        Dim frm As New frmExpense
        frm.Reset()
        frm.lblUser.Text = lblUser.Text
        frm.ShowDialog()
    End Sub

    Private Sub ExpenseTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpenseTypeToolStripMenuItem.Click
        Dim frm As New frmExpenseType
        frm.Reset()
        frm.lblUser.Text = lblUser.Text
        frm.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Dim frm As New frmContacts
        frm.Reset()
        frm.lblUser.Text = lblUser.Text
        frm.ShowDialog()
    End Sub

    Private Sub BankMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankMasterToolStripMenuItem.Click
        Dim frm As New frmBank
        frm.Reset()
        frm.lblUser.Text = lblUser.Text
        frm.ShowDialog()
    End Sub

    Private Sub BranchMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BranchMasterToolStripMenuItem.Click
        Dim frm As New frmBranchMaster_Bank
        frm.Reset()
        frm.lblUser.Text = lblUser.Text
        frm.ShowDialog()
    End Sub

    Private Sub BankAccountsRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankAccountsRegisterToolStripMenuItem.Click
        Dim frm As New frmBankAccountRegistration
        frm.Reset()
        frm.lblUser.Text = lblUser.Text
        frm.ShowDialog()
    End Sub

    Private Sub CurrencyMasterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CurrencyMasterToolStripMenuItem.Click
        Dim frm As New frmCurrency
        frm.lblUser.Text = lblUser.Text
        frm.Reset()
        frm.ShowDialog()
    End Sub

    Private Sub RoomToolStripMenuItem3_Click(sender As System.Object, e As System.EventArgs) Handles RoomToolStripMenuItem3.Click
        frmRoomsReport.ShowDialog()
    End Sub

    Private Sub DebtorsListToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles DebtorsListToolStripMenuItem1.Click
        frmDebtorsReport.ShowDialog()
    End Sub

    Private Sub FoodMenuItemsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FoodMenuItemsToolStripMenuItem.Click
        frmFoodMenuItemsReport.ShowDialog()
    End Sub

    Private Sub LiquorMenuItemsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LiquorMenuItemsToolStripMenuItem.Click
        frmLiquorMenuItemsReport.ShowDialog()
    End Sub

    Private Sub LiToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LiToolStripMenuItem.Click
        frmLiquorStockInReport.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem3.Click
        frmLiquorStockOutReport.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem4.Click
        frmLaundryBillingReport.Reset()
        frmLaundryBillingReport.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem5.Click
        frmRestaurantBillingKOTReport.Reset()
        frmRestaurantBillingKOTReport.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem6.Click
        frmCurrentPayrollAdvanceReport.ShowDialog()
    End Sub

    Private Sub EmployeeAccountMasterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EmployeeAccountMasterToolStripMenuItem.Click
        frmEmployeeAccountMaster.Reset()
        frmEmployeeAccountMaster.lblUser.Text = lblUser.Text
        frmEmployeeAccountMaster.ShowDialog()
    End Sub

    Private Sub SQLServerSettingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SQLServerSettingToolStripMenuItem.Click
        frmSqlServerSetting.Reset()
        frmSqlServerSetting.lblSet.Text = "Main Form"
        frmSqlServerSetting.ShowDialog()
    End Sub

    Private Sub LockToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LockToolStripMenuItem.Click
        Me.Hide()
        frmLock.UserID.Text = lblUser.Text
        frmLock.Password.Text = ""
        frmLock.Password.Focus()
        frmLock.ShowDialog()
    End Sub

    Private Sub EducationTaxMasterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EducationTaxMasterToolStripMenuItem.Click
        Dim frm As New frmOtherTaxes
        frm.lblUser.Text = lblUser.Text
        frm.Reset()
        frm.ShowDialog()
    End Sub

    Private Sub HotelPlanMasterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HotelPlanMasterToolStripMenuItem.Click
        Dim frm As New frmPlan
        frm.lblUser.Text = lblUser.Text
        frm.Reset()
        frm.ShowDialog()
    End Sub

    Private Sub EmailSettingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EmailSettingToolStripMenuItem.Click
        frmEmailSetting.Reset()
        frmEmailSetting.ShowDialog()
    End Sub

    Private Sub DaybookToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DaybookToolStripMenuItem.Click
        frmGeneralDayBook.Reset()
        frmGeneralDayBook.ShowDialog()
    End Sub

    Private Sub GeneralLedgerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GeneralLedgerToolStripMenuItem.Click
        frmGeneralLedger.Reset()
        frmGeneralLedger.ShowDialog()
    End Sub

    Private Sub TrialBalanceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TrialBalanceToolStripMenuItem.Click
        frmTrialBalance.Reset()
        frmTrialBalance.ShowDialog()
    End Sub

    Private Sub SuppliersToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SuppliersToolStripMenuItem.Click
        frmSupplierRecord.Reset()
        frmSupplierRecord.ShowDialog()
    End Sub

    Private Sub SupplierPaymentToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SupplierPaymentToolStripMenuItem.Click
        frmPaymentRecord.Reset()
        frmPaymentRecord.ShowDialog()
    End Sub

    Private Sub PaymentToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles PaymentToolStripMenuItem2.Click
        frmPayment.lblUser.Text = lblUser.Text
        frmPayment.Reset()
        frmPayment.ShowDialog()
    End Sub

    Private Sub SupplierMasterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SupplierMasterToolStripMenuItem.Click
        frmSupplier.lblUser.Text = lblUser.Text
        frmSupplier.Reset()
        frmSupplier.ShowDialog()
    End Sub

    Private Sub CreditorsListToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CreditorsListToolStripMenuItem.Click
        frmCreditorsReport.Reset()
        frmCreditorsReport.ShowDialog()
    End Sub

    Private Sub PurchaseDaybookToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PurchaseDaybookToolStripMenuItem.Click
        frmPurchaseDaybook.Reset()
        frmPurchaseDaybook.ShowDialog()
    End Sub

    Private Sub PurchaseToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles PurchaseToolStripMenuItem1.Click
        frmPurchasedInventoryReport.Reset()
        frmPurchasedInventoryReport.ShowDialog()
    End Sub

    Private Sub SupplierLedgerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SupplierLedgerToolStripMenuItem.Click
        frmSupplierLedger.Reset()
        frmSupplierLedger.ShowDialog()
    End Sub

    Private Sub GuestLedgerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GuestLedgerToolStripMenuItem.Click
        frmGuestLedger.Reset()
        frmGuestLedger.ShowDialog()
    End Sub

    Private Sub RestaurantPOSTouchscreenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RestaurantPOSTouchscreenToolStripMenuItem.Click
        frmRestaurantPOS.lblUser.Text = lblUser.Text
        frmRestaurantPOS.Reset()
        frmRestaurantPOS.Reset1()
        frmRestaurantPOS.Reset2()
        frmRestaurantPOS.Reset3()
        frmRestaurantPOS.ShowDialog()
    End Sub

    Private Sub POSPrinterSettingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles POSPrinterSettingToolStripMenuItem.Click
        frmPrinterSetting.Reset()
        frmPrinterSetting.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As System.Object, e As System.EventArgs)
        frmRestaurantPOSReport.Reset()
        frmRestaurantPOSReport.ShowDialog()
    End Sub

    Private Sub RestaurantPOSReportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RestaurantPOSReportToolStripMenuItem.Click
        frmRPOSReport.Reset()
        frmRPOSReport.ShowDialog()
    End Sub

    Private Sub KitchenMasterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles KitchenMasterToolStripMenuItem.Click
        frmKitchen_Section.Reset()
        frmKitchen_Section.lblUser.Text = lblUser.Text
        frmKitchen_Section.ShowDialog()
    End Sub

    Private Sub DeliveryPersonToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeliveryPersonToolStripMenuItem.Click
        frmDeliveryPerson.Reset()
        frmDeliveryPerson.lblUser.Text = lblUser.Text
        frmDeliveryPerson.ShowDialog()
    End Sub

    Private Sub ItemNotesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ItemNotesToolStripMenuItem.Click
        frmNotesMaster.Reset()
        frmNotesMaster.lblUser.Text = lblUser.Text
        frmNotesMaster.ShowDialog()
    End Sub

    Private Sub OtherChargesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OtherChargesToolStripMenuItem.Click
        frmOtherCharges.Reset()
        frmOtherCharges.lblUser.Text = lblUser.Text
        frmOtherCharges.ShowDialog()
    End Sub

    Private Sub RoomServicesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RoomServicesToolStripMenuItem.Click
        frmOrder.lblUser.Text = lblUser.Text
        frmOrder.Reset()
        frmOrder.ShowDialog()
    End Sub

    Private Sub DataGridView3_RowPostPaint(sender As System.Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView3.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView3.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView3.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub DataGridView3_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView3.MouseClick
        If DataGridView3.Rows.Count > 0 Then
            Try
                Dim dr As DataGridViewRow = DataGridView3.SelectedRows(0)
                If dr.Cells(2).Value.trim = "Vacant Dirty" Then
                    If MessageBox.Show("Do you really want to change room Status from" & vbCrLf & "Vacant Dirty to Vacant Clean?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb As String = "update Room set R_Status='Vacant Clean' where RoomNo=@d1"
                        cmd = New SqlCommand(cb)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", dr.Cells(0).Value)
                        cmd.ExecuteReader()
                        con.Close()
                        Dim st As String = "updated the Room '" & dr.Cells(0).Value & "'Status from Vacant Dirty To Vacant Clean"
                        LogFunc(lblUser.Text, st)
                        MessageBox.Show("Successfully updated", "Room Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        RefreshRecords()
                    End If
                End If
            Catch ex As Exception
                'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub ServerToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ServerToolStripMenuItem1.Click
        frmChatStart.Show()
    End Sub

    Private Sub ChatToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ChatToolStripMenuItem1.Click
        frmChatStart.Show()
    End Sub

    Private Sub GuestTransactionsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GuestTransactionsToolStripMenuItem.Click
        frmGuestsTransactions.Reset()
        frmGuestsTransactions.ShowDialog()
    End Sub

    Private Sub RoomOccupancyToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RoomOccupancyToolStripMenuItem.Click
        frmRoomOccupancyReport.ShowDialog()
    End Sub

    Private Sub RefundToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RefundToolStripMenuItem.Click
        frmRefundReport.Reset()
        frmRefundReport.ShowDialog()
    End Sub

    Private Sub CheckOutListToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CheckOutListToolStripMenuItem.Click
        frmCheckOutDueReport.Reset()
        frmCheckOutDueReport.ShowDialog()
    End Sub

    Private Sub GuestAccountRefundMoneyToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GuestAccountRefundMoneyToolStripMenuItem.Click
        frmRefundMoney.lblUser.Text = lblUser.Text
        frmRefundMoney.Reset()
        frmRefundMoney.ShowDialog()
    End Sub

    Private Sub RefundGuestsAccountToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RefundGuestsAccountToolStripMenuItem.Click
        frmRefundInGuestAccount.Reset()
        frmRefundInGuestAccount.ShowDialog()
    End Sub

    Private Sub GuestsToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles GuestsToolStripMenuItem1.Click
        frmSendBroadcastSMS_Guests.Reset()
        frmSendBroadcastSMS_Guests.ShowDialog()
    End Sub

    Private Sub EmployeesToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles EmployeesToolStripMenuItem1.Click
        frmSendBroadcastSMS_Employees.Reset()
        frmSendBroadcastSMS_Employees.ShowDialog()
    End Sub

    Private Sub InventorySystemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventorySystemToolStripMenuItem.Click
        Dim frm As New InventoryMain
        frm.ShowDialog()
    End Sub

    Private Sub LicenseToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ' frmLock.UserID.Text = lblUser.Text
        frmLicense.ShowDialog()
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        Try


            If RadioButton6.Checked = True Then
                con = New SqlConnection(cs)
                con.Open()
                Dim sql1 As String = "Select RTRIM(Reservation.Reserve_ID),RTRIM(Guest.GuestID),RTRIM(Room.RoomNo),RTRIM(PlanCode),RTRIM(GuestName),DateIN,DateOut, GrandTotal, TotalPaid from Guest,Room,Reservation where Guest.ID=Reservation.Guest_ID and Room.R_ID=Reservation.RoomID and Status='Reserved' and Reservation.GrandTotal = Reservation.totalpaid Order by DateIN"
                cmd = New SqlCommand(sql1, con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                DataGridView2.Rows.Clear()
                While (rdr.Read() = True)
                    DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8))
                End While
                For Each row As DataGridViewRow In DataGridView2.Rows
                    If (Convert.ToInt32(row.Cells(7)) = Convert.ToInt32(row.Cells(8))) Then
                        row.DefaultCellStyle.BackColor = Color.Green
                        row.DefaultCellStyle.ForeColor = Color.White
                    Else
                        row.DefaultCellStyle.BackColor = Color.Red
                        row.DefaultCellStyle.ForeColor = Color.White
                    End If
                Next
                con.Close()
            End If
        Catch ex As Exception
            '  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        Try


            If RadioButton5.Checked = True Then
                con = New SqlConnection(cs)
                con.Open()
                Dim sql1 As String = "Select RTRIM(Reservation.Reserve_ID),RTRIM(Guest.GuestID),RTRIM(Room.RoomNo),RTRIM(PlanCode),RTRIM(GuestName),DateIN,DateOut, GrandTotal, TotalPaid from Guest,Room,Reservation where Guest.ID=Reservation.Guest_ID and Room.R_ID=Reservation.RoomID and Status='Reserved' and Reservation.GrandTotal != Reservation.totalpaid Order by DateIN"
                cmd = New SqlCommand(sql1, con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                DataGridView2.Rows.Clear()
                While (rdr.Read() = True)
                    DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8))
                End While

                For Each row As DataGridViewRow In DataGridView2.Rows
                    If (Convert.ToInt32(row.Cells(7)) = Convert.ToInt32(row.Cells(8))) Then
                        row.DefaultCellStyle.BackColor = Color.Green
                        row.DefaultCellStyle.ForeColor = Color.White
                    Else
                        row.DefaultCellStyle.BackColor = Color.Red
                        row.DefaultCellStyle.ForeColor = Color.White
                    End If
                Next
                con.Close()
            End If
        Catch ex As Exception
            '   MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LicenseToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles LicenseToolStripMenuItem.Click
        frmLicense.ShowDialog()
    End Sub

    Private Sub GroupInvoiceToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupInvoiceToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles GroupInvoiceToolStripMenuItem.Click
        frmGroupInv.ShowDialog()
    End Sub

    Private Sub GroupReservationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GroupReservationToolStripMenuItem.Click
        frmGroupReservation.lblUser.Text = lblUser.Text
        frmGroupReservation.Reset()
        frmGroupReservation.ShowDialog()
    End Sub
End Class