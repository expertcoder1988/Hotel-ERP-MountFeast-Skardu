Imports System.Data.SqlClient
Public Class frmLogin
    Dim frm As New frmMainMenu
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click, Button1.Click
        If Len(Trim(UserID.Text)) = 0 Then
            MessageBox.Show("Please enter user id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            UserID.Focus()
            Exit Sub
        End If
        If Len(Trim(Password.Text)) = 0 Then
            MessageBox.Show("Please enter password", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Password.Focus()
            Exit Sub
        End If
        Try
            Dim dt As Date = DateTime.Today

            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT LicenseDate FROM License"

            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                Dim diff As String = (Convert.ToDateTime(rdr.GetValue(0)) - dt).TotalDays.ToString()
                If dt >= Convert.ToDateTime(rdr.GetValue(0)) Then
                    MessageBox.Show("Yor License has been expired. Please contact your vendor.")
                    Return
                ElseIf Convert.ToInt32(diff) < 10 Then
                    MessageBox.Show("Your license will be expire on " + Convert.ToDateTime(rdr.GetValue(0)).ToShortDateString + ". Please contact your vendor.")
                End If
            End If

            Dim str As String = Decrypt("bXNrMTIzNDU=") 'admin-mex@123, gbt@123, msk12345

            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(UserID),RTRIM(Password) FROM Registration where UserID = @d1 and Password=@d2 and Active='Yes'"
            cmd.Parameters.AddWithValue("@d1", UserID.Text)
            cmd.Parameters.AddWithValue("@d2", Encrypt(Password.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                If Encrypt(Password.Text).Trim = rdr.GetValue(1).trim Then
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = con.CreateCommand()
                    cmd.CommandText = "SELECT usertype FROM Registration where UserID=@d3 and Password=@d4"
                    cmd.Parameters.AddWithValue("@d3", UserID.Text)
                    cmd.Parameters.AddWithValue("@d4", Encrypt(Password.Text))
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        UserType.Text = rdr.GetValue(0).ToString.Trim
                    End If
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If


                    If UserType.Text = "Cashier" Then
                        frmMainMenu.SearchRecordsToolStripMenuItem.Enabled = False
                        frmMainMenu.POSToolStripMenuItem.Enabled = True
                        frmMainMenu.DataEntryToolStripMenuItem.Enabled = False
                        frmMainMenu.TransactionToolStripMenuItem.Enabled = False
                        frmMainMenu.UsersToolStripMenuItem.Enabled = False
                        frmMainMenu.MasterEntryToolStripMenuItem.Enabled = False
                        frmMainMenu.LogsToolStripMenuItem1.Enabled = False
                        frmMainMenu.SmsToolStripMenuItem1.Enabled = False
                        frmMainMenu.ChatToolStripMenuItem1.Enabled = True
                        frmMainMenu.ReservationToolStripMenuItem.Enabled = False
                        frmMainMenu.CheckInToolStripMenuItem.Enabled = False
                        frmMainMenu.GuestToolStripMenuItem1.Enabled = False
                        frmMainMenu.StockToolStripMenuItem1.Enabled = False
                        frmMainMenu.OrderToolStripMenuItem.Enabled = True
                        frmMainMenu.RestaurantBillingToolStripMenuItem.Enabled = True
                        frmMainMenu.CheckOutToolStripMenuItem.Enabled = False
                        frmMainMenu.EmployeeToolStripMenuItem1.Enabled = False
                        frmMainMenu.AdvanceEntryToolStripMenuItem1.Enabled = False
                        frmMainMenu.AttendanceToolStripMenuItem2.Enabled = False
                        frmMainMenu.PaymentToolStripMenuItem1.Enabled = False
                        frmMainMenu.dgw.Enabled = False
                        frmMainMenu.DataGridView1.Enabled = False
                        frmMainMenu.DataGridView2.Enabled = False
                        frmMainMenu.DataGridView3.Enabled = False
                        frmMainMenu.DatabaseToolStripMenuItem.Enabled = False
                        frmMainMenu.btnSearch.Enabled = False
                        frmMainMenu.btnReset.Enabled = False
                        frmMainMenu.GroupBox2.Enabled = False
                        frmMainMenu.GroupBox1.Enabled = False
                        frmMainMenu.ReportsToolStripMenuItem.Enabled = False
                        frmMainMenu.RestaurantBillingToolStripMenuItem.Enabled = True
                        frmMainMenu.LaundryBillingToolStripMenuItem1.Enabled = True
                        frmMainMenu.AdditionalReportsToolStripMenuItem.Enabled = False
                        frmMainMenu.lblUser.Text = UserID.Text
                        frmMainMenu.lblUserType.Text = UserType.Text
                        Dim st As String = "Successfully logged in"
                        LogFunc(UserID.Text, st)
                        Me.Hide()
                        frmMainMenu.lblUser.Text = UserID.Text
                        frmMainMenu.Show()
                    End If
                    If (UserType.Text = "Store Keeper") Then
                        frmMainMenu.SearchRecordsToolStripMenuItem.Enabled = False
                        frmMainMenu.POSToolStripMenuItem.Enabled = False
                        frmMainMenu.DataEntryToolStripMenuItem.Enabled = False
                        frmMainMenu.TransactionToolStripMenuItem.Enabled = False
                        frmMainMenu.UsersToolStripMenuItem.Enabled = False
                        frmMainMenu.SmsToolStripMenuItem1.Enabled = False
                        frmMainMenu.MasterEntryToolStripMenuItem.Enabled = False
                        frmMainMenu.LogsToolStripMenuItem1.Enabled = False
                        frmMainMenu.ChatToolStripMenuItem1.Enabled = True
                        frmMainMenu.ReservationToolStripMenuItem.Enabled = False
                        frmMainMenu.CheckInToolStripMenuItem.Enabled = False
                        frmMainMenu.GuestToolStripMenuItem1.Enabled = False
                        frmMainMenu.StockToolStripMenuItem1.Enabled = True
                        frmMainMenu.OrderToolStripMenuItem.Enabled = False
                        frmMainMenu.RestaurantBillingToolStripMenuItem.Enabled = False
                        frmMainMenu.CheckOutToolStripMenuItem.Enabled = False
                        frmMainMenu.EmployeeToolStripMenuItem1.Enabled = False
                        frmMainMenu.AdvanceEntryToolStripMenuItem1.Enabled = False
                        frmMainMenu.AttendanceToolStripMenuItem2.Enabled = False
                        frmMainMenu.PaymentToolStripMenuItem1.Enabled = False
                        frmMainMenu.dgw.Enabled = False
                        frmMainMenu.DataGridView1.Enabled = False
                        frmMainMenu.DataGridView2.Enabled = False
                        frmMainMenu.DataGridView3.Enabled = False
                        frmMainMenu.DatabaseToolStripMenuItem.Enabled = False
                        frmMainMenu.btnSearch.Enabled = False
                        frmMainMenu.btnReset.Enabled = False
                        frmMainMenu.ReportsToolStripMenuItem.Enabled = False
                        frmMainMenu.AdditionalReportsToolStripMenuItem.Enabled = False
                        frmMainMenu.GroupBox2.Enabled = False
                        frmMainMenu.GroupBox1.Enabled = False
                        frmMainMenu.RestaurantBillingToolStripMenuItem.Enabled = False
                        frmMainMenu.LaundryBillingToolStripMenuItem1.Enabled = False
                        frmMainMenu.lblUser.Text = UserID.Text
                        frmMainMenu.lblUserType.Text = UserType.Text
                        Dim st As String = "Successfully logged in"
                        LogFunc(UserID.Text, st)
                        frmMainMenu.Hide()
                        frmMainMenu.lblUser.Text = UserID.Text
                        frmMainMenu.Show()
                    End If
                    If (UserType.Text = "Store Manager") Then
                        frmMainMenu.SearchRecordsToolStripMenuItem.Enabled = True
                        frmMainMenu.POSToolStripMenuItem.Enabled = True
                        frmMainMenu.DataEntryToolStripMenuItem.Enabled = True
                        frmMainMenu.TransactionToolStripMenuItem.Enabled = True
                        frmMainMenu.UsersToolStripMenuItem.Enabled = True
                        frmMainMenu.MasterEntryToolStripMenuItem.Enabled = True
                        frmMainMenu.LogsToolStripMenuItem1.Enabled = True
                        frmMainMenu.SmsToolStripMenuItem1.Enabled = True
                        frmMainMenu.ChatToolStripMenuItem1.Enabled = True
                        frmMainMenu.ReservationToolStripMenuItem.Enabled = True
                        frmMainMenu.CheckInToolStripMenuItem.Enabled = True
                        frmMainMenu.GuestToolStripMenuItem1.Enabled = True
                        frmMainMenu.StockToolStripMenuItem1.Enabled = True
                        frmMainMenu.OrderToolStripMenuItem.Enabled = True
                        frmMainMenu.RestaurantBillingToolStripMenuItem.Enabled = True
                        frmMainMenu.CheckOutToolStripMenuItem.Enabled = True
                        frmMainMenu.EmployeeToolStripMenuItem1.Enabled = True
                        frmMainMenu.AdvanceEntryToolStripMenuItem1.Enabled = True
                        frmMainMenu.AttendanceToolStripMenuItem2.Enabled = True
                        frmMainMenu.PaymentToolStripMenuItem1.Enabled = True
                        frmMainMenu.dgw.Enabled = True
                        frmMainMenu.DataGridView1.Enabled = True
                        frmMainMenu.DataGridView2.Enabled = True
                        frmMainMenu.DataGridView3.Enabled = True
                        frmMainMenu.DatabaseToolStripMenuItem.Enabled = True
                        frmMainMenu.btnSearch.Enabled = True
                        frmMainMenu.btnReset.Enabled = True
                        frmMainMenu.ReportsToolStripMenuItem.Enabled = True
                        frmMainMenu.AdditionalReportsToolStripMenuItem.Enabled = True
                        frmMainMenu.GroupBox2.Enabled = True
                        frmMainMenu.GroupBox1.Enabled = True
                        frmMainMenu.lblUser.Text = UserID.Text
                        frmMainMenu.lblUserType.Text = UserType.Text
                        frmMainMenu.RestaurantBillingToolStripMenuItem.Enabled = True
                        frmMainMenu.LaundryBillingToolStripMenuItem1.Enabled = True
                        Dim st As String = "Successfully logged in"
                        LogFunc(UserID.Text, st)
                        Me.Hide()
                        frmMainMenu.lblUser.Text = UserID.Text
                        frmMainMenu.Show()
                    End If
                    If (UserType.Text = "Admin") Then
                        frmMainMenu.SearchRecordsToolStripMenuItem.Enabled = True
                        frmMainMenu.POSToolStripMenuItem.Enabled = True
                        frmMainMenu.DataEntryToolStripMenuItem.Enabled = True
                        frmMainMenu.TransactionToolStripMenuItem.Enabled = True
                        frmMainMenu.UsersToolStripMenuItem.Enabled = True
                        frmMainMenu.MasterEntryToolStripMenuItem.Enabled = True
                        frmMainMenu.LogsToolStripMenuItem1.Enabled = True
                        frmMainMenu.SmsToolStripMenuItem1.Enabled = True
                        frmMainMenu.ChatToolStripMenuItem1.Enabled = True
                        frmMainMenu.ReservationToolStripMenuItem.Enabled = True
                        frmMainMenu.CheckInToolStripMenuItem.Enabled = True
                        frmMainMenu.GuestToolStripMenuItem1.Enabled = True
                        frmMainMenu.StockToolStripMenuItem1.Enabled = True
                        frmMainMenu.OrderToolStripMenuItem.Enabled = True
                        frmMainMenu.RestaurantBillingToolStripMenuItem.Enabled = True
                        frmMainMenu.CheckOutToolStripMenuItem.Enabled = True
                        frmMainMenu.EmployeeToolStripMenuItem1.Enabled = True
                        frmMainMenu.AdvanceEntryToolStripMenuItem1.Enabled = True
                        frmMainMenu.AttendanceToolStripMenuItem2.Enabled = True
                        frmMainMenu.PaymentToolStripMenuItem1.Enabled = True
                        frmMainMenu.dgw.Enabled = True
                        frmMainMenu.DataGridView1.Enabled = True
                        frmMainMenu.DataGridView2.Enabled = True
                        frmMainMenu.DataGridView3.Enabled = True
                        frmMainMenu.DatabaseToolStripMenuItem.Enabled = True
                        frmMainMenu.btnSearch.Enabled = True
                        frmMainMenu.btnReset.Enabled = True
                        frmMainMenu.ReportsToolStripMenuItem.Enabled = True
                        frmMainMenu.AdditionalReportsToolStripMenuItem.Enabled = True
                        frmMainMenu.GroupBox2.Enabled = True
                        frmMainMenu.GroupBox1.Enabled = True
                        frmMainMenu.lblUser.Text = UserID.Text
                        frmMainMenu.lblUserType.Text = UserType.Text
                        frmMainMenu.RestaurantBillingToolStripMenuItem.Enabled = True
                        frmMainMenu.LaundryBillingToolStripMenuItem1.Enabled = True
                        Dim st As String = "Successfully logged in"
                        LogFunc(UserID.Text, st)
                        Me.Hide()
                        frmMainMenu.lblUser.Text = UserID.Text
                        frmMainMenu.Show()
                    End If
                    If (UserType.Text = "Finance Manager") Then
                        frmMainMenu.SearchRecordsToolStripMenuItem.Enabled = True
                        frmMainMenu.POSToolStripMenuItem.Enabled = False
                        frmMainMenu.DataEntryToolStripMenuItem.Enabled = True
                        frmMainMenu.TransactionToolStripMenuItem.Enabled = True
                        frmMainMenu.UsersToolStripMenuItem.Enabled = False
                        frmMainMenu.MasterEntryToolStripMenuItem.Enabled = False
                        frmMainMenu.LogsToolStripMenuItem1.Enabled = False
                        frmMainMenu.SmsToolStripMenuItem1.Enabled = True
                        frmMainMenu.ChatToolStripMenuItem1.Enabled = True
                        frmMainMenu.ReservationToolStripMenuItem.Enabled = False
                        frmMainMenu.CheckInToolStripMenuItem.Enabled = False
                        frmMainMenu.GuestToolStripMenuItem1.Enabled = False
                        frmMainMenu.StockToolStripMenuItem1.Enabled = True
                        frmMainMenu.OrderToolStripMenuItem.Enabled = False
                        frmMainMenu.RestaurantBillingToolStripMenuItem.Enabled = False
                        frmMainMenu.CheckOutToolStripMenuItem.Enabled = False
                        frmMainMenu.EmployeeToolStripMenuItem1.Enabled = False
                        frmMainMenu.AdvanceEntryToolStripMenuItem1.Enabled = True
                        frmMainMenu.AttendanceToolStripMenuItem2.Enabled = True
                        frmMainMenu.PaymentToolStripMenuItem1.Enabled = True
                        frmMainMenu.dgw.Enabled = False
                        frmMainMenu.DataGridView1.Enabled = False
                        frmMainMenu.DataGridView2.Enabled = False
                        frmMainMenu.DataGridView3.Enabled = False
                        frmMainMenu.DatabaseToolStripMenuItem.Enabled = False
                        frmMainMenu.btnSearch.Enabled = False
                        frmMainMenu.btnReset.Enabled = False
                        frmMainMenu.ReportsToolStripMenuItem.Enabled = True
                        frmMainMenu.AdditionalReportsToolStripMenuItem.Enabled = True
                        frmMainMenu.GroupBox2.Enabled = False
                        frmMainMenu.GroupBox1.Enabled = False
                        frmMainMenu.RestaurantBillingToolStripMenuItem.Enabled = False
                        frmMainMenu.LaundryBillingToolStripMenuItem1.Enabled = False
                        frmMainMenu.lblUser.Text = UserID.Text
                        frmMainMenu.lblUserType.Text = UserType.Text
                        Dim st As String = "Successfully logged in"
                        LogFunc(UserID.Text, st)
                        Me.Hide()
                        frmMainMenu.lblUser.Text = UserID.Text
                        frmMainMenu.Show()
                    End If
                    If UserType.Text = "Receptionist" Then
                        frmMainMenu.SearchRecordsToolStripMenuItem.Enabled = False
                        frmMainMenu.POSToolStripMenuItem.Enabled = True
                        frmMainMenu.DataEntryToolStripMenuItem.Enabled = False
                        frmMainMenu.TransactionToolStripMenuItem.Enabled = False
                        frmMainMenu.UsersToolStripMenuItem.Enabled = False
                        frmMainMenu.MasterEntryToolStripMenuItem.Enabled = False
                        frmMainMenu.LogsToolStripMenuItem1.Enabled = False
                        frmMainMenu.ChatToolStripMenuItem1.Enabled = True
                        frmMainMenu.ReservationToolStripMenuItem.Enabled = True
                        frmMainMenu.CheckInToolStripMenuItem.Enabled = True
                        frmMainMenu.GuestToolStripMenuItem1.Enabled = True
                        frmMainMenu.StockToolStripMenuItem1.Enabled = True
                        frmMainMenu.ReportsToolStripMenuItem.Enabled = True
                        frmMainMenu.SmsToolStripMenuItem1.Enabled = True
                        frmMainMenu.OrderToolStripMenuItem.Enabled = True
                        frmMainMenu.RestaurantBillingToolStripMenuItem.Enabled = True
                        frmMainMenu.CheckOutToolStripMenuItem.Enabled = True
                        frmMainMenu.EmployeeToolStripMenuItem1.Enabled = False
                        frmMainMenu.AdvanceEntryToolStripMenuItem1.Enabled = False
                        frmMainMenu.AttendanceToolStripMenuItem2.Enabled = True
                        frmMainMenu.PaymentToolStripMenuItem1.Enabled = False
                        frmMainMenu.dgw.Enabled = True
                        frmMainMenu.DataGridView1.Enabled = True
                        frmMainMenu.DataGridView2.Enabled = True
                        frmMainMenu.DataGridView3.Enabled = True
                        frmMainMenu.DatabaseToolStripMenuItem.Enabled = False
                        frmMainMenu.btnSearch.Enabled = True
                        frmMainMenu.btnReset.Enabled = True
                        frmMainMenu.ReportsToolStripMenuItem.Enabled = True
                        frmMainMenu.AdditionalReportsToolStripMenuItem.Enabled = True
                        frmMainMenu.GroupBox2.Enabled = True
                        frmMainMenu.GroupBox1.Enabled = True
                        frmMainMenu.lblUser.Text = UserID.Text
                        frmMainMenu.lblUserType.Text = UserType.Text
                        frmMainMenu.RestaurantBillingToolStripMenuItem.Enabled = True
                        frmMainMenu.LaundryBillingToolStripMenuItem1.Enabled = True
                        Dim st As String = "Successfully logged in"
                        LogFunc(UserID.Text, st)
                        Me.Hide()
                        frmMainMenu.lblUser.Text = UserID.Text
                        frmMainMenu.Show()
                    End If
                End If
            Else
                MsgBox("Login is Failed...Try again !", MsgBoxStyle.Critical, "Login Denied")
                ' UserID.Text = ""
                Password.Text = ""
                Password.Focus()
            End If
            cmd.Dispose()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click, Button2.Click
        End
    End Sub

    Private Sub LoginForm1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Panel1.Location = New Point(Me.ClientSize.Width / 2 - Panel1.Size.Width / 2, Me.ClientSize.Height / 2 - Panel1.Size.Height / 2)
        Panel1.Anchor = AnchorStyles.None
    End Sub

    Private Sub frmLogin_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        End
    End Sub

    Private Sub btnChangePassword_Click(sender As System.Object, e As System.EventArgs) Handles btnChangePassword.Click
        Me.Hide()
        frmChangePassword.Show()
        frmChangePassword.UserID.Text = ""
        frmChangePassword.OldPassword.Text = ""
        frmChangePassword.NewPassword.Text = ""
        frmChangePassword.ConfirmPassword.Text = ""
        frmChangePassword.UserID.Focus()
    End Sub

    Private Sub btnRecoveryPassword_Click(sender As System.Object, e As System.EventArgs) Handles btnRecoveryPassword.Click
        Me.Hide()
        frmRecoveryPassword.Show()
        frmRecoveryPassword.txtEmailID.Text = ""
        frmRecoveryPassword.txtEmailID.Focus()
    End Sub

    Private Sub btnKeyboard_Click(sender As System.Object, e As System.EventArgs) Handles btnKeyboard.Click
        Dim old As Long
        If Environment.Is64BitOperatingSystem Then
            If Wow64DisableWow64FsRedirection(old) Then
                Process.Start("osk.exe")
                Wow64EnableWow64FsRedirection(old)
            End If
        Else
            Process.Start("osk.exe")
        End If
    End Sub

    Private Sub btnChangePassword_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnChangePassword.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(btnChangePassword, "Change Password")
    End Sub

    Private Sub btnRecoveryPassword_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnRecoveryPassword.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(btnRecoveryPassword, "Password Recovery")
    End Sub

    Private Sub btnKeyboard_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnKeyboard.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(btnKeyboard, "OnScreen Keyboard")
    End Sub

End Class
