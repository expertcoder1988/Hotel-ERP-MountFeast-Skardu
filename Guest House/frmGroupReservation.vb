Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class frmGroupReservation

    Dim num1, num2, num3, num4, num5, num6, num7, num8, num9, num10, num11, num12, a As Double
    Dim st2, GID As String

    Dim dt As New DataTable
    Dim col1, col2, col3, col4, col5, col6, col7, col8, col9, col10, col11, col12, col13, col14, col15, col16, col17, col18, col19, col20, col21, col22 As DataColumn

    Dim gLuxuryTaxAmount As Decimal
    Dim gSTAmount As Decimal
    Dim gDiscountAmount As Decimal
    Dim gExtraPersonCharges As Decimal
    Dim gExtraBedCharges As Decimal
    Dim gGrandTotal As Decimal

    Sub Compute()
        Try
            If dtpDateOut.Value.Date = dtpDateIn.Value.Date Then
                txtNoOfDays.Text = 1
            Else
                txtNoOfDays.Text = dtpDateOut.Value.Date.Subtract(dtpDateIn.Value.Date).Days.ToString
            End If
            num8 = CDbl(Val(txtNoOfExtraBed.Text) * Val(txtExtraBedC.Text))
            num8 = Math.Round(num8, 2)
            txtExtraBedCharges.Text = num8
            num9 = CDbl(Val(txtNoOfExtraPerson.Text) * Val(txtExtraPersonC.Text))
            num9 = Math.Round(num9, 2)
            txtExtraPersonCharges.Text = num9
            num1 = CDbl(Val(txtRoomCharges.Text) * Val(txtNoOfDays.Text))
            num1 = Math.Round(num1, 2)
            txtTotalRoomCharges.Text = num1
            num2 = CDbl(((Val(txtTotalRoomCharges.Text) + Val(txtExtraBedCharges.Text) + Val(txtExtraPersonCharges.Text)) * Val(txtDiscountPer.Text)) / 100)
            num2 = Math.Round(num2, 2)
            txtDiscountAmount.Text = num2
            num3 = CDbl((Val(txtTotalRoomCharges.Text) + Val(txtExtraBedCharges.Text) + Val(txtExtraPersonCharges.Text)) - Val(txtDiscountAmount.Text))
            num3 = Math.Round(num3, 2)
            TextBox2.Text = num3
            num4 = CDbl((Val(TextBox2.Text) * Val(txtServiceTaxPer.Text)) / 100)
            num4 = Math.Round(num4, 2)
            txtServiceTaxAmount.Text = num4
            num5 = CDbl(((Val(TextBox2.Text) + Val(txtServiceTaxAmount.Text)) * Val(txtLuxuryTaxPer.Text)) / 100)
            num5 = Math.Round(num5, 2)
            txtLuxuryTaxAmount.Text = num5
            num10 = CDbl(Val(TextBox2.Text))
            num10 = Math.Round(num10, 2)
            txtSubTotal.Text = num10
            num6 = CDbl(Val(txtSubTotal.Text) + Val(txtServiceTaxAmount.Text) + Val(txtLuxuryTaxAmount.Text))
            num6 = Math.Round(num6, 2)
            txtGrandTotal.Text = num6
            num7 = CDbl(Val(txtGrandTotal.Text) - Val(txtTotalPaid.Text))
            num7 = Math.Round(num7, 2)
            txtBalance.Text = num7


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Reset()
        txtSaved.Text = "0"
    End Sub

    Sub Reset()

        txtExtraBedCharges.Text = ""
        txtExtraPersonCharges.Text = ""
        txtGuestID.Text = ""
        txtGuestName.Text = ""
        cmbRoomNo.SelectedIndex = -1
        cmbPlanCode.SelectedIndex = -1
        txtPlanName.Text = ""
        txtRoomCharges.Text = ""
        dtpDateIn.Text = Today
        dtpDateOut.Text = Today
        txtNoOfMales.Text = 0
        txtNoOfFemales.Text = 0
        txtNoOfKids.Text = 0
        txtNoOfExtraBed.Text = 0
        txtNoOfExtraPerson.Text = 0
        txtNoOfDays.Text = ""
        txtTotalRoomCharges.Text = ""
        txtExtraBedCharges.Text = ""
        txtSubTotal.Text = ""
        txtLuxuryTaxPer.Text = "0"
        txtReservationNo.Text = ""
        dtpReservationDate.Value = Now
        txtServiceTaxAmount.Text = ""
        txtServiceTaxPer.Text = "5"
        txtLuxuryTaxAmount.Text = "0"
        txtDiscountPer.Text = "0"
        txtDiscountAmount.Text = ""
        txtGrandTotal.Text = ""
        txtTotalPaid.Text = 0
        txtBalance.Text = ""
        btnSave.Enabled = True
        btnDelete.Enabled = False
        dtpDateIn.Enabled = True
        dtpDateOut.Enabled = True
        cmbRoomNo.Enabled = True
        'DataGridView2.Rows.Clear()
        '  btnRoomAvailability.Enabled = True
        lblStatus.Text = ""
        txtStatus.Text = ""
        Clear1()
        cmbPaymentMode.SelectedIndex = 1
        cmbPlanCode.Enabled = False
        cmbPlanCode.DropDownStyle = ComboBoxStyle.DropDownList
        cmbRoomNo.Enabled = True
        cmbRoomNo1.Enabled = True
        '  btnCancelReservation.Enabled = False
        ' btnCancelReservationReceipt.Enabled = False
        btnPrint.Enabled = False
        '  txtCountry.Text = ""
        FillData()
        auto()
    End Sub

    Private Sub dtpDateOut_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateOut.ValueChanged
        Try
            If dtpDateOut.Value.Date = dtpDateIn.Value.Date Then
                txtNoOfDays.Text = 1
            Else
                txtNoOfDays.Text = dtpDateOut.Value.Date.Subtract(dtpDateIn.Value.Date).Days.ToString
            End If
            txtTotalRoomCharges.Text = CInt(Val(txtRoomCharges.Text) * Val(txtNoOfDays.Text)).ToString()
            '  CheckAvailability()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
        Compute()
    End Sub

    Private Sub dtpDateOut_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpDateOut.Validating

        Try
            If Len(Trim(cmbRoomNo.Text)) = 0 Then
                MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbRoomNo.Focus()
                Exit Sub
            End If

            If dtpDateOut.Value.Date < dtpDateIn.Value.Date Then
                MessageBox.Show("Selected date out must be greater than date in", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dtpDateOut.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub txtDiscountPer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscountPer.TextChanged
        Compute()
    End Sub

    Private Sub txtServiceTaxPer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtServiceTaxPer.TextChanged
        Compute()
    End Sub

    Private Sub txtLuxuryTaxPer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLuxuryTaxPer.TextChanged
        Compute()
    End Sub

    Private Sub txtGrandTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGrandTotal.TextChanged
        Compute()
    End Sub

    Sub FillData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT ServiceTax,LuxuryTax,Discount FROM Tax WHERE Type='Room'"
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtServiceTaxPer.Text = "5" ' rdr.GetValue(0)
                txtLuxuryTaxPer.Text = "0" 'rdr.GetValue(1)
                txtDiscountPer.Text = "0" 'rdr.GetValue(2)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub FillExtraBed()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT Charges FROM ExtraBed where RoomType=@d1"
            cmd.Parameters.AddWithValue("@d1", txtRoomType.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                If dtpDateOut.Value.Date = dtpDateIn.Value.Date Then
                    txtNoOfDays.Text = 1
                Else
                    txtNoOfDays.Text = dtpDateOut.Value.Date.Subtract(dtpDateIn.Value.Date).Days.ToString
                End If
                txtExtraBedC.Text = rdr.GetValue(0) * Val(txtNoOfDays.Text)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub FillExtraPerson()
        Try

            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT Charges FROM ExtraPerson where RoomType=@d1"
            cmd.Parameters.AddWithValue("@d1", txtRoomType.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                If dtpDateOut.Value.Date = dtpDateIn.Value.Date Then
                    txtNoOfDays.Text = 1
                Else
                    txtNoOfDays.Text = dtpDateOut.Value.Date.Subtract(dtpDateIn.Value.Date).Days.ToString
                End If
                txtExtraPersonC.Text = rdr.GetValue(0) * Val(txtNoOfDays.Text)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub autoGuestId()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM Guest")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtID.Text = Num.ToString
            txtGuestID.Text = "G" + Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtID.Text = Num.ToString
            txtGuestID.Text = "G" + Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub

    Private Sub EnableGuestControls()
        txtGuestName.ReadOnly = False
        'txtGuestAddress.ReadOnly = False
        'txtGuestCity.ReadOnly = False
        'txtIDNumber.ReadOnly = False
        'txtIDNumber.ReadOnly = False
        'txtIDNumber.ReadOnly = False
        'txtNotes.ReadOnly = False
        'txtGender.ReadOnly = False
        'txtOccupation.ReadOnly = False
        'txtCountry.ReadOnly = False
        'txtReligion.ReadOnly = False
    End Sub

    Private Sub DisableGuestControls()
        txtGuestName.ReadOnly = True
        'txtGuestAddress.ReadOnly = True
        'txtGuestCity.ReadOnly = True
        'txtIDNumber.ReadOnly = True
        'txtIDNumber.ReadOnly = True
        'txtIDNumber.ReadOnly = True
        'txtNotes.ReadOnly = True
        'txtGender.ReadOnly = True
        'txtOccupation.ReadOnly = True
        'txtCountry.ReadOnly = True
        'txtReligion.ReadOnly = True
    End Sub

    Private Sub auto1()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM GuestLedger")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtGuestLedgerID.Text = Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtGuestLedgerID.Text = Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub




    Private Sub SaveRooms()
        Try
            If dt.Rows.Count > 0 Then
                If Len(Trim(txtGuestName.Text)) = 0 Then
                    MessageBox.Show("Please enter guest name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtGuestName.Focus()
                    Exit Sub
                End If
                If Len(Trim(cmbRoomNo.Text)) = 0 Then
                    MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cmbRoomNo.Focus()
                    Exit Sub
                End If
                If Len(Trim(cmbPlanCode.Text)) = 0 Then
                    MessageBox.Show("Please select plan code", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cmbPlanCode.Focus()
                    Exit Sub
                End If
                If (Val(txtNoOfFemales.Text) + Val(txtNoOfMales.Text) + Val(txtNoOfKids.Text)) = 0 Then
                    MessageBox.Show("No. Of (Males + Females + Kids) must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If Len(Trim(txtTotalPaid.Text)) = 0 Then
                    MessageBox.Show("Please enter total paid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtTotalPaid.Focus()
                    Exit Sub
                End If
                If Val(txtBalance.Text) < 0 Then
                    MessageBox.Show("Balance can not be less than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtTotalPaid.Focus()
                    Exit Sub
                End If
                If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
                    MessageBox.Show("Total paid can not be more than grand total", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtTotalPaid.Text = ""
                    txtTotalPaid.Focus()
                    Exit Sub
                End If
                If dtpDateIn.Value.Date > dtpDateOut.Value.Date Then
                    MessageBox.Show("Date IN should be smaller then Date OUT", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                If dtpDateIn.Value.Date = dtpDateOut.Value.Date Then
                    MessageBox.Show("Date Out can not be same as Date IN", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If


                For Each row As DataGridViewRow In DataGridView2.Rows
                    If Not row.IsNewRow Then
                        If row.Cells(0).Value = "From Guest's Account" Then
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim ctg As String = "select ISNULL(sum(Amount)-Sum(Deduction),0) from GuestLedger,Guest where Guest.ID=GuestLedger.GuestID and GuestLedger.GuestID=@d1"
                            cmd = New SqlCommand(ctg)
                            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
                            cmd.Connection = con
                            rdr = cmd.ExecuteReader()
                            If rdr.Read() Then
                                a = rdr.GetValue(0)
                            Else
                                a = 0
                            End If
                            con.Close()
                            If a >= TotalPayment1() Then
                                auto1()
                                Dim string1 As String = "Paid for room reservation"
                                con = New SqlConnection(cs)
                                con.Open()
                                Dim cbx As String = "insert into GuestLedger( Id,GuestID,Amount,Deduction,Date,Details,GL_Label) Values (" & txtGuestLedgerID.Text & "," & txtID.Text & ",0," & TotalPayment1() & ",@d1,@d2,'" & txtReservationNo.Text & "')"
                                cmd = New SqlCommand(cbx)
                                cmd.Parameters.AddWithValue("@d1", Now)
                                cmd.Parameters.AddWithValue("@d2", string1)
                                cmd.Connection = con
                                cmd.ExecuteReader()
                                con.Close()
                            Else
                                MessageBox.Show("Insufficient fund available in guest's account...try other payment mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                        End If
                    End If
                Next
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                Compute()
                GetRoomID()
                auto()
                con = New SqlConnection(cs)
                con.Open()

                txtGuestEnterHere.Text = False

                Dim cb As String = "insert into Reservation(Reserve_ID, Guest_ID, RoomID, RoomCharges, DateIN, DateOUT, NoOfDays, NoOfMales, NoOfFemales, 
                    NoOfKids, NoOfExtraBed, NoOfExtraPerson, ExtraPersonCharges, TotalRoomCharges,ExtraBedCharges, DiscountPer, DiscountAmount, STPer, STAmount, 
                    LuxuryTaxPer, LuxuryTaxAmount, SubTotal, GrandTotal, TotalPaid, Balance, Status, Notes,ReservationNo,ReservationDate) VALUES 
                    (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d14,@d15,@d16,@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26,@d27,'Reserved',@d28,@d29,@d30)"

                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", Val(txtReservationID.Text))
                cmd.Parameters.AddWithValue("@d2", Val(txtID.Text))
                cmd.Parameters.AddWithValue("@d3", DBNull.Value)
                cmd.Parameters.AddWithValue("@d4", 0)
                cmd.Parameters.AddWithValue("@d5", dtpDateIn.Value.Date)
                cmd.Parameters.AddWithValue("@d6", dtpDateOut.Value.Date)
                cmd.Parameters.AddWithValue("@d7", Val(txtNoOfDays.Text))
                cmd.Parameters.AddWithValue("@d8", 0)
                cmd.Parameters.AddWithValue("@d9", 0)
                cmd.Parameters.AddWithValue("@d10", 0)
                cmd.Parameters.AddWithValue("@d11", 0)
                cmd.Parameters.AddWithValue("@d12", 0)
                cmd.Parameters.AddWithValue("@d14", 0)
                cmd.Parameters.AddWithValue("@d15", 0)
                cmd.Parameters.AddWithValue("@d16", 0)
                cmd.Parameters.AddWithValue("@d18", 0)
                cmd.Parameters.AddWithValue("@d19", gDiscountAmount)
                cmd.Parameters.AddWithValue("@d20", 0)
                cmd.Parameters.AddWithValue("@d21", gSTAmount)
                cmd.Parameters.AddWithValue("@d22", 0)
                cmd.Parameters.AddWithValue("@d23", gLuxuryTaxAmount)
                cmd.Parameters.AddWithValue("@d24", 0)
                cmd.Parameters.AddWithValue("@d25", gGrandTotal)
                cmd.Parameters.AddWithValue("@d26", Val(txtTotalPaid.Text))
                cmd.Parameters.AddWithValue("@d27", Val(txtGroupBalance.Text))
                cmd.Parameters.AddWithValue("@d28", "")
                cmd.Parameters.AddWithValue("@d29", txtReservationNo.Text)
                cmd.Parameters.AddWithValue("@d30", dtpReservationDate.Value)
                cmd.ExecuteReader()
                con.Close()
                If DataGridView2.Rows.Count = 0 Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cbV As String = "insert into Reservation_Payment(ReservationID,PaymentMode,TotalPaid,PaymentDate) VALUES (" & txtReservationID.Text & " ,@d4,@d5,@d6)"
                    cmd = New SqlCommand(cbV)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d4", "")
                    cmd.Parameters.AddWithValue("@d5", 0.0)
                    cmd.Parameters.AddWithValue("@d6", System.DateTime.Now)
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
                con = New SqlConnection(cs)
                con.Open()
                Dim cb2 As String = "insert into Reservation_Payment(ReservationID,PaymentMode,TotalPaid,PaymentDate) VALUES (" & txtReservationID.Text & " ,@d4,@d5,@d6)"
                cmd = New SqlCommand(cb2)
                cmd.Connection = con
                ' Prepare command for repeated execution
                cmd.Prepare()
                ' Data to be inserted
                For Each row As DataGridViewRow In DataGridView2.Rows
                    If Not row.IsNewRow Then
                        cmd.Parameters.AddWithValue("@d4", row.Cells(0).Value)
                        cmd.Parameters.AddWithValue("@d5", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@d6", row.Cells(2).Value)
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                Next

                For Each row As DataRow In dt.Rows


                    cb = "insert into Reservation_Details(Reserve_ID, RoomID, RoomCharges, NoOfDays, NoOfMales, NoOfFemales, NoOfKids, 
                           NoOfExtraBed, NoOfExtraPerson, ExtraPersonCharges, TotalRoomCharges,ExtraBedCharges, DiscountPer, DiscountAmount, STPer, STAmount,
                           LuxuryTaxPer, LuxuryTaxAmount, SubTotal, GrandTotal, Status) 
                           VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,'Reserved')"

                    cmd = New SqlCommand(cb)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", Convert.ToString(row("Reserve_ID")).Remove(0, 1))
                    cmd.Parameters.AddWithValue("@d2", row("RoomID"))
                    cmd.Parameters.AddWithValue("@d3", row("RoomCharges"))
                    cmd.Parameters.AddWithValue("@d4", row("NoOfDays"))
                    cmd.Parameters.AddWithValue("@d5", row("NoOfMales"))
                    cmd.Parameters.AddWithValue("@d6", row("NoOfFemales"))
                    cmd.Parameters.AddWithValue("@d7", row("NoOfKids"))
                    cmd.Parameters.AddWithValue("@d8", row("NoOfExtraBed"))
                    cmd.Parameters.AddWithValue("@d9", row("NoOfExtraPerson"))
                    cmd.Parameters.AddWithValue("@d10", row("ExtraPersonCharges"))
                    cmd.Parameters.AddWithValue("@d11", row("TotalRoomCharges"))
                    cmd.Parameters.AddWithValue("@d12", row("ExtraBedCharges"))
                    cmd.Parameters.AddWithValue("@d13", row("DiscountPer"))
                    cmd.Parameters.AddWithValue("@d14", row("DiscountAmount"))
                    cmd.Parameters.AddWithValue("@d15", row("STPer"))
                    cmd.Parameters.AddWithValue("@d16", row("STAmount"))
                    cmd.Parameters.AddWithValue("@d17", row("LuxuryTaxPer"))
                    cmd.Parameters.AddWithValue("@d18", row("LuxuryTaxAmount"))
                    cmd.Parameters.AddWithValue("@d19", row("SubTotal"))
                    cmd.Parameters.AddWithValue("@d20", row("GrandTotal"))
                    cmd.ExecuteReader()
                Next

                con.Close()
                LedgerSave(dtpReservationDate.Value, txtGuestName.Text, txtReservationNo.Text, "Room Reservation", Val(txtGrandTotal.Text), 0, txtGuestID.Text)
                For Each row As DataGridViewRow In DataGridView2.Rows
                    If Not row.IsNewRow Then
                        If row.Cells(0).Value = "By Cash" Or row.Cells(0).Value = "From Guest's Account" Then
                            LedgerSave(Convert.ToDateTime(row.Cells(2).Value), "Cash Account", txtReservationNo.Text, "Payment", 0, Val(row.Cells(1).Value), txtGuestID.Text)
                        End If
                        If row.Cells(0).Value = "By Credit Card" Or row.Cells(0).Value = "By Debit Card" Then
                            LedgerSave(Convert.ToDateTime(row.Cells(2).Value), "Bank Account", txtReservationNo.Text, "Payment", 0, Val(row.Cells(1).Value), txtGuestID.Text)
                        End If
                        If row.Cells(0).Value = "From Guest's Account" Then
                            LedgerSave(Convert.ToDateTime(row.Cells(2).Value), txtGuestName.Text, txtReservationNo.Text, "Guest's Account", Val(row.Cells(1).Value), 0, txtGuestID.Text)
                        End If
                    End If
                Next
                Dim st As String = "Reserved multiple rooms for Guest '" & txtGuestName.Text & "' having reservation no. '" & txtReservationNo.Text & "'"
                LogFunc(lblUser.Text, st)
                SendSMS()
                If CheckForInternetConnection() = True Then
                    Cursor = Cursors.WaitCursor
                    Timer1.Enabled = True
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim str As String = "select IsNull(Email,0) from Guest where Guest.ID=" & txtID.Text & ""
                    cmd = New SqlCommand(str)
                    cmd.Connection = con
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        GID = rdr.GetValue(0).ToString.Trim()
                    End If
                    If GID <> "0" Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim ctn As String = "select RTRIM(Username),RTRIM(Password),RTRIM(SMTPAddress),(Port) from EmailSetting where IsDefault='Yes' and IsActive='Yes'"
                        cmd = New SqlCommand(ctn)
                        cmd.Connection = con
                        rdr = cmd.ExecuteReader()
                        If rdr.Read() Then
                            Dim rpt As New rptReservationInvoice 'The report you created.
                            Dim myConnection As SqlConnection
                            Dim MyCommand, MyCommand1, MyCommand2 As New SqlCommand()
                            Dim myDA, myDA1, myDA2 As New SqlDataAdapter()
                            Dim myDS As New DataSet 'The DataSet you created.
                            If (Not System.IO.Directory.Exists(Application.StartupPath & "\PDF Reports")) Then
                                System.IO.Directory.CreateDirectory(Application.StartupPath & "\PDF Reports")
                            End If
                            Dim pdfFile As String = Application.StartupPath & "\PDF Reports\ReservationInvoice " & DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".Pdf"
                            myConnection = New SqlConnection(cs)
                            MyCommand.Connection = myConnection
                            MyCommand1.Connection = myConnection
                            MyCommand2.Connection = myConnection
                            MyCommand.CommandText = "SELECT Guest.ID, Guest.GuestID, Guest.GuestName, Guest.Address, Guest.City, Guest.Country, Guest.ContactNo, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.Email, Guest.IDType, Guest.IDNumber,Guest.Pic1, Guest.Pic2, Guest.pic3, Guest.Notes, Guest.Company, Guest.Model, Guest.VehicleNo, Guest.Color, Reservation.Reserve_ID, Reservation.ReservationNo, Reservation.ReservationDate,Reservation.Guest_ID, Reservation.RoomID, Reservation.RoomCharges, Reservation.DateIN, Reservation.DateOUT, Reservation.NoOfDays, Reservation.NoOfMales, Reservation.NoOfFemales, Reservation.NoOfKids, Reservation.NoOfExtraBed, Reservation.NoOfExtraPerson, Reservation.ExtraPersonCharges, Reservation.TotalRoomCharges, Reservation.ExtraBedCharges, Reservation.DiscountPer, Reservation.DiscountAmount, Reservation.STPer, Reservation.STAmount, Reservation.LuxuryTaxPer, Reservation.LuxuryTaxAmount, Reservation.SubTotal, Reservation.GrandTotal, Reservation.TotalPaid, Reservation.Balance, Room.R_ID, Room.RoomNo, Room.PlanCode, Room.RoomType, Room.MaxNoOfAdults,Room.MaxNoOfKids, Room.Active FROM Guest INNER JOIN Reservation ON Guest.ID = Reservation.Guest_ID INNER JOIN Room ON Reservation.RoomID = Room.R_ID and Reservation.ReservationNo='" & txtReservationNo.Text & "'"
                            MyCommand1.CommandText = "SELECT * from Hotel"
                            MyCommand2.CommandText = "SELECT * from Currency"
                            MyCommand.CommandType = CommandType.Text
                            MyCommand1.CommandType = CommandType.Text
                            MyCommand2.CommandType = CommandType.Text
                            myDA.SelectCommand = MyCommand
                            myDA1.SelectCommand = MyCommand1
                            myDA2.SelectCommand = MyCommand2
                            myDA.Fill(myDS, "Guest")
                            myDA.Fill(myDS, "Room")
                            myDA.Fill(myDS, "Reservation")
                            myDA1.Fill(myDS, "Hotel")
                            myDA2.Fill(myDS, "Currency")
                            rpt.SetDataSource(myDS)
                            frmReport.CrystalReportViewer1.ReportSource = rpt
                            rpt.ExportToDisk(ExportFormatType.PortableDocFormat, pdfFile)
                            SendMail(rdr.GetValue(0), GID, "Please find the attachment below", pdfFile, "Reservation Invoice", rdr.GetValue(2), rdr.GetValue(3), rdr.GetValue(0), Decrypt(rdr.GetValue(1)))
                            If (rdr IsNot Nothing) Then
                                rdr.Close()
                            End If
                        End If
                    End If
                End If
                btnSave.Enabled = False
                DisableGuestControls()
                'DataGridView1.Rows.Add(cmbRoomNo.Text, Val(txtRoomCharges.Text), Val(txtGrandTotal.Text))
                LoadGroupRooms()
                RefreshRecords()
                ' DataGridView1.DataSource = Nothing
                MessageBox.Show("Successfully Reserved", "Room", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnPrint.Enabled = True
                Cursor = Cursors.Default
                btnAdd1.Enabled = True
                btnRemove1.Enabled = True
            Else
                MessageBox.Show("Please select atleast one room", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelReservation_Click(sender As Object, e As EventArgs) Handles btnCancelReservation.Click
        Try
            'If Len(Trim(txtGuestID.Text)) = 0 Then
            '    MessageBox.Show("Please retrieve guest info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    txtGuestID.Focus()
            '    Exit Sub
            'End If

            'If Len(Trim(cmbRoomNo.Text)) = 0 Then
            '    MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    cmbRoomNo.Focus()
            '    Exit Sub
            'End If
            If (txtStatus.Text = "Cancelled") Then
                MessageBox.Show("Reservation is already cancelled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If (txtStatus.Text = "Confirmed" Or txtStatus.Text = "Check In" Or txtStatus.Text = "Check Out") Then
                MessageBox.Show("Reservation is confirmed and Guest is already Check In " & vbCrLf & " so it can not be cancelled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If MessageBox.Show("Are you sure want to cancel this reservation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "update Reservation set Status='Cancelled' where Reserve_ID=" & txtReservationID.Text & ""
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.ExecuteReader()
                con.Close()

                For Each row As DataGridViewRow In DataGridView2.Rows
                    If Not row.IsNewRow Then
                        If row.Cells(0).Value = "By Cash" Then
                            LedgerSave(System.DateTime.Now, "Cash Account", txtReservationNo.Text, "Payment", Val(row.Cells(1).Value), 0, txtGuestID.Text)
                            LedgerSave(System.DateTime.Now, txtGuestName.Text, txtReservationNo.Text, "Reservation cancellation refund", 0, Val(txtGrandTotal.Text), txtGuestID.Text)
                        End If
                        If row.Cells(0).Value = "By Credit Card" Or row.Cells(0).Value = "By Debit Card" Then
                            LedgerSave(System.DateTime.Now, "Bank Account", txtReservationNo.Text, "Payment", Val(row.Cells(1).Value), 0, txtGuestID.Text)
                            LedgerSave(System.DateTime.Now, txtGuestName.Text, txtReservationNo.Text, "Reservation cancellation refund", 0, Val(txtGrandTotal.Text), txtGuestID.Text)
                        End If
                        If row.Cells(0).Value = "From Guest's Account" Then
                            auto1()
                            Dim string1 As String = "Refund for Reservation Cancellation"
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim cbx As String = "insert into GuestLedger(Id,GuestID,Amount,Deduction,Date,Details) Values (" & txtGuestLedgerID.Text & "," & txtID.Text & "," & TotalPayment1() & ",0,@d1,@d2)"
                            cmd = New SqlCommand(cbx)
                            cmd.Parameters.AddWithValue("@d1", Now)
                            cmd.Parameters.AddWithValue("@d2", string1)
                            cmd.Connection = con
                            cmd.ExecuteReader()
                            con.Close()
                            LedgerSave(System.DateTime.Now, "Cash Account", txtReservationNo.Text, "Payment", Val(row.Cells(1).Value), 0, txtGuestID.Text)
                            LedgerSave(System.DateTime.Now, txtGuestName.Text, txtReservationNo.Text, "Reservation cancellation refund", 0, Val(txtGrandTotal.Text), txtGuestID.Text)
                        End If
                    End If
                Next
                Dim st As String = "cancelled the reservation having reservation no.'" & txtReservationNo.Text & "' of guest '" & txtGuestName.Text & "'"
                LogFunc(lblUser.Text, st)
                If CheckForInternetConnection() = True Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ctn As String = "select RTRIM(APIURL) from SMSSetting where IsDefault='Yes' and IsEnabled='Yes'"
                    cmd = New SqlCommand(ctn)
                    cmd.Connection = con
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        st2 = rdr.GetValue(0)
                        Dim st3 As String = "Hello, " & txtGuestName.Text & " your reservation has been cancelled having reservation no. " & txtReservationNo.Text & ""
                        SMSFunc(txtGuestContactNo.Text.Trim, st3, st2)
                        If (rdr IsNot Nothing) Then
                            rdr.Close()
                        End If
                    End If
                    con.Close()
                End If
                MessageBox.Show("Successfully cancelled", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnCancelReservation.Enabled = False
                btnCancelReservationReceipt.Enabled = True
                RefreshRecords()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelReservationReceipt_Click(sender As Object, e As EventArgs) Handles btnCancelReservationReceipt.Click
        Print1()
    End Sub

    Sub Print1()
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptReservationCancellationReceipt 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1, MyCommand2 As New SqlCommand()
            Dim myDA, myDA1, myDA2 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            Dim pdfFile As String = Application.StartupPath & "\Report.Pdf"
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand2.Connection = myConnection
            MyCommand.CommandText = "SELECT Guest.ID, Guest.GuestID, Guest.GuestName, Guest.Address, Guest.City, Guest.Country, Guest.ContactNo, Guest.Gender, 
Guest.Occupation, Guest.Religion, Guest.Email, Guest.IDType, Guest.IDNumber,Guest.Pic1, Guest.Pic2, Guest.pic3, Guest.Notes, Guest.Company, Guest.Model, 
Guest.VehicleNo, Guest.Color, Reservation.Reserve_ID, Reservation.ReservationNo, Reservation.ReservationDate,Reservation.Guest_ID, Reservation.RoomID, 
Reservation.RoomCharges, Reservation.DateIN, Reservation.DateOUT, Reservation.NoOfDays, Reservation.NoOfMales, Reservation.NoOfFemales, Reservation.NoOfKids, 
Reservation.NoOfExtraBed, Reservation.NoOfExtraPerson, Reservation.ExtraPersonCharges, Reservation.TotalRoomCharges, Reservation.ExtraBedCharges, 
Reservation.DiscountPer, Reservation.DiscountAmount, Reservation.STPer, Reservation.STAmount, Reservation.LuxuryTaxPer, Reservation.LuxuryTaxAmount, 
Reservation.SubTotal, Reservation.GrandTotal, Reservation.TotalPaid, Reservation.Balance, Room.R_ID, Room.RoomNo, Room.PlanCode, Room.RoomType, 
Room.MaxNoOfAdults,Room.MaxNoOfKids, Room.Active FROM Guest INNER JOIN Reservation ON Guest.ID = Reservation.Guest_ID Left outer JOIN Room ON 
Reservation.RoomID = Room.R_ID and Status='Cancelled' and Reservation.ReservationNo='" & txtReservationNo.Text & "'"

            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand2.CommandText = "SELECT * from Currency"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            MyCommand2.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA2.SelectCommand = MyCommand2
            myDA.Fill(myDS, "Guest")
            myDA.Fill(myDS, "Room")
            myDA.Fill(myDS, "Reservation")
            myDA1.Fill(myDS, "Hotel")
            myDA2.Fill(myDS, "Currency")
            rpt.SetDataSource(myDS)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCheckedIN_Click(sender As Object, e As EventArgs) Handles btnCheckedIN.Click
        Try
            If Len(Trim(txtGuestID.Text)) = 0 Then
                MessageBox.Show("Please retrieve guest info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtGuestID.Focus()
                Exit Sub
            End If

            'If Len(Trim(cmbRoomNo.Text)) = 0 Then
            '    MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    cmbRoomNo.Focus()
            '    Exit Sub
            'End If
            'If Len(Trim(cmbPlanCode.Text)) = 0 Then
            '    MessageBox.Show("Please select plan code", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    cmbPlanCode.Focus()
            '    Exit Sub
            'End If
            'If Len(Trim(txtTotalPaid.Text)) = 0 Then
            '    MessageBox.Show("Please enter total paid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    txtTotalPaid.Focus()
            '    Exit Sub
            'End If
            'If Val(txtBalance.Text) < 0 Then
            '    MessageBox.Show("Balance can not be less than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    txtTotalPaid.Focus()
            '    Exit Sub
            'End If
            'If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
            '    MessageBox.Show("Total paid can not be more than grand total", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    txtTotalPaid.Text = ""
            '    txtTotalPaid.Focus()
            '    Exit Sub
            'End If

            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow Then
                    If row.Cells(0).Value = "From Guest's Account" Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cbz1 As String = "Delete from GuestLedger where GL_Label='" & txtReservationNo.Text & "'"
                        cmd = New SqlCommand(cbz1)
                        cmd.Connection = con
                        cmd.ExecuteReader()
                        con.Close()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim ctg As String = "select ISNULL(sum(Amount)-Sum(Deduction),0) from GuestLedger,Guest where Guest.ID=GuestLedger.GuestID and GuestLedger.GuestID=@d1"
                        cmd = New SqlCommand(ctg)
                        cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
                        cmd.Connection = con
                        rdr = cmd.ExecuteReader()
                        If rdr.Read() Then
                            a = rdr.GetValue(0)
                        Else
                            a = 0
                        End If
                        con.Close()
                        If a >= TotalPayment1() Then
                            auto1()
                            Dim string1 As String = "Paid for room charges"
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim cbz As String = "insert into GuestLedger( Id,GuestID,Amount,Deduction,Date,Details,GL_Label) Values (" & txtGuestLedgerID.Text & "," & txtID.Text & ",0," & txtTotalPaid.Text & ",@d1,@d2,'" & txtCheckInID.Text & "')"
                            cmd = New SqlCommand(cbz)
                            cmd.Parameters.AddWithValue("@d1", Now)
                            cmd.Parameters.AddWithValue("@d2", string1)
                            cmd.Connection = con
                            cmd.ExecuteReader()
                            con.Close()
                        Else
                            MessageBox.Show("Insufficient fund available in guest's account...try other payment mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If
                End If
            Next
            CheckIn_Auto()
            '  GetRoomID()
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "update reservation_details set status = 'Check In' where Reserve_ID = " & Convert.ToString(txtReservationNo.Text).Remove(0, 1)
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            'cmd.Parameters.AddWithValue("@d1", Val(txtRoomID.Text))
            'cmd.Parameters.AddWithValue("@d2", "")
            'cmd.Parameters.AddWithValue("@d3", dtpDateIn.Value.Date)
            'cmd.Parameters.AddWithValue("@d4", dtpDateOut.Value.Date)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "Check In guest '" & txtGuestName.Text & "' with Check In ID='" & txtCheckInID.Text & "'"
            LogFunc(lblUser.Text, st)
            con = New SqlConnection(cs)
            con.Open()
            Dim cb3 As String = "Update Reservation set Status='Check In' where Reserve_ID=" & Convert.ToString(txtReservationNo.Text).Remove(0, 1)
            cmd = New SqlCommand(cb3)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            cb = "insert into CheckIN_Room(Cin_Id, GuestID, RoomID, RoomCharges, DateIN, DateOUT, NoOfDays, NoOfMales, NoOfFemales, NoOfKids, NoOfExtraBed, 
                    NoOfExtraPerson, RoomOrderCharges, ExtraPersonCharges, TotalRoomCharges,ExtraBedCharges, OtherCharges, DiscountPer, DiscountAmount, STPer, 
                    STAmount, LuxuryTaxPer, LuxuryTaxAmount, SubTotal, GrandTotal, TotalPaid, Balance, Status, Notes) 
                    select " & txtCheckInID.Text & ",Guest_ID, RoomID, RoomCharges, DateIN, DateOUT, NoOfDays, NoOfMales, NoOfFemales, NoOfKids, NoOfExtraBed, 
                    NoOfExtraPerson, 0, ExtraPersonCharges, TotalRoomCharges,ExtraBedCharges, 0, DiscountPer, DiscountAmount, STPer, 
                    STAmount, LuxuryTaxPer, LuxuryTaxAmount, SubTotal, GrandTotal, TotalPaid, Balance, 'Check In', '' from Reservation 
                    where Reserve_ID=" & Convert.ToString(txtReservationNo.Text).Remove(0, 1)

            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtRoomID.Text))
            cmd.Parameters.AddWithValue("@d2", "")
            cmd.Parameters.AddWithValue("@d3", dtpDateIn.Value.Date)
            cmd.Parameters.AddWithValue("@d4", dtpDateOut.Value.Date)
            cmd.ExecuteReader()
            con.Close()
            If DataGridView2.Rows.Count = 0 Then
                con = New SqlConnection(cs)
                con.Open()
                Dim cbV As String = "insert into CheckIn_Payment(CheckInID,PaymentMode,TotalPaid,PaymentDate) VALUES (" & txtCheckInID.Text & ",@d4,@d5,@d6)"
                cmd = New SqlCommand(cbV)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d4", "")
                cmd.Parameters.AddWithValue("@d5", 0.0)
                cmd.Parameters.AddWithValue("@d6", System.DateTime.Now)
                cmd.ExecuteNonQuery()
                con.Close()
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cbx As String = "insert into CheckIn_Payment(CheckInID,PaymentMode,TotalPaid,PaymentDate) VALUES (" & txtCheckInID.Text & ",@d4,@d5,@d6)"
            cmd = New SqlCommand(cbx)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d4", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d6", row.Cells(2).Value)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cbC As String = "update Room set R_Status='Booked' where RoomNo=@d1"
            cmd = New SqlCommand(cbC)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            cmd.ExecuteReader()
            con.Close()
            LedgerDelete(txtReservationNo.Text, "Guest's Account")
            LedgerDelete(txtReservationNo.Text, "Room Reservation")
            LedgerDelete(txtReservationNo.Text, "Payment")
            LedgerSave(dtpDateIn.Value.Date, txtGuestName.Text, txtCheckInID.Text, "Room Charges", Val(txtGrandTotal.Text) - 0 - 0, 0, txtGuestID.Text)
            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow Then
                    If row.Cells(0).Value = "By Cash" Or row.Cells(0).Value = "From Guest's Account" Then
                        LedgerSave(Convert.ToDateTime(row.Cells(2).Value), "Cash Account", txtCheckInID.Text, "Payment", 0, Val(row.Cells(1).Value), txtGuestID.Text)
                    End If
                    If row.Cells(0).Value = "From Guest's Account" Then
                        LedgerSave(Convert.ToDateTime(row.Cells(2).Value), txtGuestName.Text, txtCheckInID.Text, "Guest's Account", Val(row.Cells(1).Value), 0, txtGuestID.Text)
                    End If
                End If
            Next
            SendSMS()
            btnCheckedIN.Enabled = False
            btnPrint.Enabled = True
            RefreshRecords()
            MessageBox.Show("Successfully Checked In", "Guest", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub LoadRooms()
        Try
            Dim MyCommand As New SqlCommand()
            Dim myDA As New SqlDataAdapter()
            Dim myDS As New DataSet

            con = New SqlConnection(cs)
            con.Open()
            MyCommand.Connection = con

            MyCommand.CommandText = "select r1.*, r2.RoomNo as RoomNum from reservation_details r1 inner join room r2 on r1.roomid = r2.r_id where Reserve_ID = " & txtReservationID.Text
            MyCommand.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA.Fill(myDS, "reservation_details")

            DataGridView1.DataSource = myDS.Tables(0)


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CheckIn_Auto()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(Cin_ID) FROM CheckIn_Room")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtCheckInID.Text = Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtCheckInID.Text = Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub

    Private Sub BillNo()

        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM CheckOut_Room")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtBillID.Text = Num.ToString
            txtBillNo.Text = "B" + Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtBillID.Text = Num.ToString
            txtBillNo.Text = "B" + Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCheckOut.Click
        Try
            'If Len(Trim(txtGuestID.Text)) = 0 Then
            '    MessageBox.Show("Please retrieve guest info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    txtGuestID.Focus()
            '    Exit Sub
            'End If

            'If Len(Trim(txtRoomNo.Text)) = 0 Then
            '    MessageBox.Show("Please retrieve room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    txtRoomNo.Focus()
            '    Exit Sub
            'End If
            'If (Val(txtNoOfFemales.Text) + Val(txtNoOfMales.Text) + Val(txtNoOfKids.Text)) = 0 Then
            '    MessageBox.Show("No. Of (Males + Females + Kids) must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If
            'If Len(Trim(txtOtherCharges.Text)) = 0 Then
            '    MessageBox.Show("Please enter other charges", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    txtOtherCharges.Focus()
            '    Exit Sub
            'End If
            'If Len(Trim(txtServiceTaxPer.Text)) = 0 Then
            '    MessageBox.Show("Please enter service tax %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    txtServiceTaxPer.Focus()
            '    Exit Sub
            'End If
            'If Len(Trim(txtLuxuryTaxPer.Text)) = 0 Then
            '    MessageBox.Show("Please enter luxury tax %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    txtLuxuryTaxPer.Focus()
            '    Exit Sub
            'End If
            'If Len(Trim(txtDiscountPer.Text)) = 0 Then
            '    MessageBox.Show("Please enter discount %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    txtDiscountPer.Focus()
            '    Exit Sub
            'End If
            'If Len(Trim(txtTotalPaid.Text)) = 0 Then
            '    MessageBox.Show("Please enter total paid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    txtTotalPaid.Focus()
            '    Exit Sub
            'End If
            'If Val(txtBalance.Text) < 0 Then
            '    MessageBox.Show("Balance can not be less than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    txtTotalPaid.Focus()
            '    Exit Sub
            'End If
            'If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
            '    MessageBox.Show("Total paid can not be more than grand total", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    txtTotalPaid.Text = ""
            '    txtTotalPaid.Focus()
            '    Exit Sub
            'End If

            If TextBox4.Text = "" Then
                MessageBox.Show("Please enter Room Service Charges.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox4.Focus()
                Exit Sub
            End If

            If TextBox5.Text = "" Then
                MessageBox.Show("Please enter Laundry Charges.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox5.Focus()
                Exit Sub
            End If

            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow Then
                    If row.Cells(0).Value = "From Guest's Account" And row.Cells(3).Value = "" Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cbz1 As String = "Delete from GuestLedger where GL_Label='" & txtCheckInID.Text & "'"
                        cmd = New SqlCommand(cbz1)
                        cmd.Connection = con
                        cmd.ExecuteReader()
                        con.Close()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim ctg As String = "select ISNULL(sum(Amount)-Sum(Deduction),0) from GuestLedger,Guest where Guest.ID=GuestLedger.GuestID and GuestLedger.GuestID=@d1"
                        cmd = New SqlCommand(ctg)
                        cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
                        cmd.Connection = con
                        rdr = cmd.ExecuteReader()
                        If rdr.Read() Then
                            a = rdr.GetValue(0)
                        Else
                            a = 0
                        End If
                        con.Close()
                        If a >= TotalPayment1() Then
                            auto1()
                            Dim string1 As String = "Paid for room charges"
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim cbx As String = "insert into GuestLedger( Id,GuestID,Amount,Deduction,Date,Details,GL_Label) Values (" & txtGuestLedgerID.Text & "," & txtID.Text & ",0," & TotalPayment1() & ",@d1,@d2,'" & txtReservationNo.Text & "')"
                            cmd = New SqlCommand(cbx)
                            cmd.Parameters.AddWithValue("@d1", Now)
                            cmd.Parameters.AddWithValue("@d2", string1)
                            cmd.Connection = con
                            cmd.ExecuteReader()
                            con.Close()
                        Else
                            MessageBox.Show("Insufficient fund available in guest's account...try other payment mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If
                End If
            Next
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            BillNo()
            GetRoomID()

            Dim dt As String = dtpDateIn.Value
            Dim arr As String() = dt.Split("/")

            If arr(0) > 12 Then
                dt = arr(2) & "/" & arr(1) & "/" & arr(0)
            Else
                dt = arr(2) & "/" & arr(0) & "/" & arr(1)
            End If

            con = New SqlConnection(cs)
            con.Open()
            Dim cinID As String = "select cin_id from CheckIN_Room where GuestID=" & Convert.ToString(txtGuestID.Text).Remove(0, 1) & " and Datein='" &
                dt & "' and roomid is null"
            cmd = New SqlCommand(cinID)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtCheckInID.Text = rdr.GetValue(0)
            Else
                txtCheckInID.Text = txtReservationID.Text
            End If
            con.Close()

            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into CheckOut_Room(ID,BillNo,CheckInID,BillDate,Notes ) VALUES (" & txtBillID.Text & ",'" & txtBillNo.Text & "'," & txtCheckInID.Text & ",@d2,@d1)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", "")
            cmd.Parameters.AddWithValue("@d2", DateTime.Today.ToShortDateString)
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()


            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update CheckIN_Room Set Status='Checked Out' where Cin_ID=" & txtCheckInID.Text & ""

            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()

            con = New SqlConnection(cs)
            con.Open()
            Dim cb3 As String = "Update Reservation set Status='Checked Out', RoomOrderCharges=" & txtRoomOrderCharges.Text & ", OtherCharges=" &
                txtLaundryCharges.Text & " where reserve_id=" & Val(txtReservationID.Text) & " And DateIN = '" & dt & "'"
            cmd = New SqlCommand(cb3)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()

            con = New SqlConnection(cs)
            con.Open()
            Dim cbZ As String = "Update Room_OrderInfo set RO_Status='Paid' where CheckInID=" & txtCheckInID.Text & ""
            cmd = New SqlCommand(cbZ)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cbZx As String = "Update Laundry_BillInfo set LB_Status='Paid' where CheckInID=" & txtCheckInID.Text & ""
            cmd = New SqlCommand(cbZx)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from CheckIn_Payment where CheckInID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Parameters.AddWithValue("@d1", txtCheckInID.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb2 As String = "insert into CheckIn_Payment(CheckInID,PaymentMode,TotalPaid,PaymentDate) VALUES (" & txtCheckInID.Text & " ,@d4,@d5,@d6)"
            cmd = New SqlCommand(cb2)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d4", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d6", row.Cells(2).Value)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cbC As String = "update Room set R_Status='Vacant Dirty' where R_ID=x@d1"

            For Each row As DataGridViewRow In DataGridView1.Rows
                cmd = New SqlCommand(cbC)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", row.Cells(3).Value)
                cmd.ExecuteReader()
            Next


            con.Close()
            LedgerDelete(txtCheckInID.Text, "Payment")
            LedgerDelete(txtCheckInID.Text, "Room Charges")
            LedgerDelete(txtCheckInID.Text, "Guest's Account")
            LedgerSave(dt, txtGuestName.Text, txtBillNo.Text, "Room Charges", Val(txtGrandTotal.Text) - Val(txtLaundryCharges.Text) - Val(txtRoomOrderCharges.Text), 0, txtGuestID.Text)
            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow Then
                    If row.Cells(0).Value = "By Cash" Or row.Cells(0).Value = "From Guest's Account" Then
                        LedgerSave(Convert.ToDateTime(row.Cells(2).Value), "Cash Account", txtBillNo.Text, "Payment", 0, Val(row.Cells(1).Value), txtGuestID.Text)
                    End If
                    If row.Cells(0).Value = "By Credit Card" Or row.Cells(0).Value = "By Debit Card" Then
                        LedgerSave(Convert.ToDateTime(row.Cells(2).Value), "Bank Account", txtBillNo.Text, "Payment", 0, Val(row.Cells(1).Value), txtGuestID.Text)
                    End If
                    If row.Cells(0).Value = "From Guest's Account" Then
                        LedgerSave(Convert.ToDateTime(row.Cells(2).Value), txtGuestName.Text, txtBillNo.Text, "Guest's Account", Val(row.Cells(1).Value), 0, txtGuestID.Text)
                    End If
                End If
            Next
            Dim st As String = "Checked Out guest '" & txtGuestName.Text & "' with Bill no.'" & txtBillNo.Text & "'"
            LogFunc(lblUser.Text, st)
            'If CheckForInternetConnection() = True Then
            '    Cursor = Cursors.WaitCursor
            '    Timer1.Enabled = True
            '    con = New SqlConnection(cs)
            '    con.Open()
            '    Dim ctn As String = "select RTRIM(APIURL) from SMSSetting where IsDefault='Yes' and IsEnabled='Yes'"
            '    cmd = New SqlCommand(ctn)
            '    cmd.Connection = con
            '    rdr = cmd.ExecuteReader()
            '    If rdr.Read() Then
            '        st2 = rdr.GetValue(0)
            '        Dim st3 As String = "Hello, " & txtGuestName.Text & " you have successfully Checked out from room no. " & txtRoomNo.Text & ""
            '        SMSFunc(txtGuestContactNo.Text.Trim, st3, st2)
            '        If (rdr IsNot Nothing) Then
            '            rdr.Close()
            '        End If
            '    End If
            'End If
            If CheckForInternetConnection() = True Then
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                con = New SqlConnection(cs)
                con.Open()
                Dim str As String = "select IsNull(Email,0) from Guest where Guest.ID=" & txtID.Text & ""
                cmd = New SqlCommand(str)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    GID = rdr.GetValue(0).ToString.Trim()
                End If
                If GID <> "0" Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ctn As String = "select RTRIM(Username),RTRIM(Password),RTRIM(SMTPAddress),(Port) from EmailSetting where IsDefault='Yes' and IsActive='Yes'"
                    cmd = New SqlCommand(ctn)
                    cmd.Connection = con
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        Dim rpt As New rptRoomInvoice 'The report you created.
                        Dim myConnection As SqlConnection
                        Dim MyCommand, MyCommand1, MyCommand2 As New SqlCommand()
                        Dim myDA, myDA1, myDA2 As New SqlDataAdapter()
                        Dim myDS As New DataSet 'The DataSet you created.
                        If (Not System.IO.Directory.Exists(Application.StartupPath & "\PDF Reports")) Then
                            System.IO.Directory.CreateDirectory(Application.StartupPath & "\PDF Reports")
                        End If
                        Dim pdfFile As String = Application.StartupPath & "\PDF Reports\RoomInvoice " & DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".Pdf"
                        myConnection = New SqlConnection(cs)
                        MyCommand.Connection = myConnection
                        MyCommand1.Connection = myConnection
                        MyCommand2.Connection = myConnection
                        MyCommand.CommandText = "SELECT Checkin_Room.Cin_Id,Guest.ID,CheckIN_Room.GuestID, CheckIN_Room.RoomID, CheckIN_Room.RoomCharges, CheckIN_Room.DateIN, CheckIN_Room.DateOUT, CheckIN_Room.NoOfDays, CheckIN_Room.NoOfMales,CheckIN_Room.NoOfFemales, CheckIN_Room.NoOfKids, CheckIN_Room.NoOfExtraBed, CheckIN_Room.NoOfExtraPerson, CheckIN_Room.RoomOrderCharges, CheckIN_Room.ExtraPersonCharges, CheckIN_Room.TotalRoomCharges, CheckIN_Room.ExtraBedCharges, CheckIN_Room.OtherCharges, CheckIN_Room.DiscountPer, CheckIN_Room.DiscountAmount, CheckIN_Room.STPer,CheckIN_Room.STAmount, CheckIN_Room.LuxuryTaxPer, CheckIN_Room.LuxuryTaxAmount, CheckIN_Room.SubTotal, CheckIN_Room.GrandTotal, CheckIN_Room.TotalPaid, CheckIN_Room.Balance,CheckIN_Room.Status, CheckIN_Room.Notes, Room.RoomType, Guest.GuestName, Guest.Address, Guest.City, Guest.ContactNo,Guest.Country, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.IDType, Guest.IDNumber, Guest.Pic1, Guest.Pic2, Guest.pic3, Guest.Notes AS Expr5,Guest_Docs.Id AS Expr6, Guest_Docs.GuestID AS Expr7, Guest_Docs.Image1, Guest_Docs.Image2, Guest_Docs.Image3 FROM CheckIN_Room INNER JOIN Room ON CheckIN_Room.RoomID = Room.R_ID INNER JOIN Guest ON CheckIN_Room.GuestID = Guest.ID INNER JOIN Guest_Docs ON Guest.ID = Guest_Docs.GuestID where Status='Checked Out' and Cin_ID=" & txtCheckInID.Text & ""
                        MyCommand1.CommandText = "SELECT * from Hotel"
                        MyCommand2.CommandText = "SELECT * from Currency"
                        MyCommand.CommandType = CommandType.Text
                        MyCommand1.CommandType = CommandType.Text
                        MyCommand2.CommandType = CommandType.Text
                        myDA.SelectCommand = MyCommand
                        myDA1.SelectCommand = MyCommand1
                        myDA2.SelectCommand = MyCommand2
                        myDA.Fill(myDS, "Guest")
                        myDA.Fill(myDS, "Room")
                        myDA.Fill(myDS, "CheckIn_Room")
                        myDA.Fill(myDS, "Guest_Docs")
                        myDA1.Fill(myDS, "Hotel")
                        myDA2.Fill(myDS, "Currency")
                        rpt.SetDataSource(myDS)
                        rpt.SetParameterValue("v1", txtReservationNo.Text)
                        rpt.SetParameterValue("v2", DateTime.Today.ToShortDateString)
                        frmReport.CrystalReportViewer1.ReportSource = rpt
                        rpt.ExportToDisk(ExportFormatType.PortableDocFormat, pdfFile)
                        SendMail(rdr.GetValue(0), GID, "Please find the attachment below", pdfFile, "Room Invoice", rdr.GetValue(2), rdr.GetValue(3), rdr.GetValue(0), Decrypt(rdr.GetValue(1)))
                        If (rdr IsNot Nothing) Then
                            rdr.Close()
                        End If
                    End If
                End If
            End If
            btnSave.Enabled = False
            RefreshRecords()
            MessageBox.Show("Successfully Checked out", "Guest", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnPrint.Enabled = True
            '   btnPrint1.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub SendSMS()
        Try
            If CheckForInternetConnection() = True Then
                con = New SqlConnection(cs)
                con.Open()
                Dim ctn As String = "select RTRIM(APIURL) from SMSSetting where IsDefault='Yes' and IsEnabled='Yes'"
                cmd = New SqlCommand(ctn)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    st2 = rdr.GetValue(0)
                    Dim st3 As String = "Hello, " & txtGuestName.Text & " you have successfully reserved the room " & cmbRoomNo.Text & " having Reservation No. '" & txtReservationNo.Text & "'"
                    SMSFunc(txtGuestContactNo.Text.Trim, st3, st2)
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub CalGroupTotal()
        Try
            Dim gID As String = txtGuestID.Text
            gID = gID.Remove(0, 1)
            con.Open()
            Dim ct As String = "SELECT grandtotal as grouptotal, sum(balance) as groupbalance from Reservation where guest_id=@d1 and datein=@d2 AND DateOut = @d3"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", gID)
            cmd.Parameters.AddWithValue("@d2", dtpDateIn.Value.Date)
            cmd.Parameters.AddWithValue("@d3", dtpDateOut.Value.Date)
            rdr = cmd.ExecuteReader()

            If rdr.Read Then
                If rdr.GetValue(0) > 1 Then
                    con.Close()
                    con.Open()
                    rdr.Close()
                    ct = "SELECT sum(grandtotal) as grouptotal, sum(balance) as groupbalance from Reservation where guest_id=@d1 and datein=@d2 AND DateOut = @d3"
                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", gID)
                    cmd.Parameters.AddWithValue("@d2", dtpDateIn.Value.Date)
                    cmd.Parameters.AddWithValue("@d3", dtpDateOut.Value.Date)
                    rdr = cmd.ExecuteReader()

                    If rdr.Read Then
                        txtGroupTotal.Text = rdr.GetValue(0)
                        txtGroupBalance.Text = rdr.GetValue(1)
                        rdr.Close()
                    End If
                Else
                    txtGroupTotal.Text = "0"
                    txtGroupBalance.Text = "0"
                    ' DataGridView1.Rows.Clear()

                End If
            Else
                txtGroupTotal.Text = "0"
                txtGroupBalance.Text = "0"
                ' DataGridView1.Rows.Clear()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub LoadRoomPayments()
        Try
            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            Dim rID As String = txtReservationNo.Text
            rID = rID.Remove(0, 1)
            con.Open()
            Dim ct As String = "SELECT AmountPaid,PaymentMode,PaymentDate from roompayments where ReservationID=@d1 and status=1"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", rID)
            rdr = cmd.ExecuteReader()
            DataGridView2.Rows.Clear()

            While (rdr.Read() = True)
                DataGridView2.Rows.Add(rdr.GetValue(1), rdr.GetValue(0), rdr.GetValue(2))

            End While

            rdr.Close()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub LoadGroupRooms()
        Try
            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            Dim gid As String = txtGuestID.Text.Remove(0, 1)
            Dim rID As String = txtReservationNo.Text
            rID = rID.Remove(0, 1)
            con.Open()
            Dim ct As String = "select r2.RoomNo, r2.RoomType, r1.RoomCharges, r1.GrandTotal from Reservation r1 inner join Room r2 on r1.RoomID = r2.R_ID where r1.Guest_ID = @d1 and CONVERT(date,r1.DateIN) = @d2"
            cmd = New SqlCommand(ct)
            cmd.Connection = con

            cmd.Parameters.AddWithValue("@d1", gid)
            cmd.Parameters.AddWithValue("@d2", dtpDateIn.Value.Date)
            rdr = cmd.ExecuteReader()
            'DataGridView1.Rows.Clear()

            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr.GetValue(0), rdr.GetValue(1), rdr.GetValue(2))
            End While
            rdr.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub auto()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(Reserve_ID) FROM Reservation")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtReservationID.Text = Num.ToString
            txtReservationNo.Text = "G" + Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtReservationID.Text = Num.ToString
            txtReservationNo.Text = "G" + Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub

    Sub GetRoomID()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT R_ID FROM Room WHERE PlanCode=@d1 and RoomNo=@d2"
            cmd.Parameters.AddWithValue("@d1", cmbPlanCode.Text)
            cmd.Parameters.AddWithValue("@d2", cmbRoomNo.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtRoomID.Text = rdr.GetValue(0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveRooms()
        txtSaved.Text = "1"
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
                RefreshRecords()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from Reservation where Reserve_ID=" & txtReservationID.Text & ""
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            con.Close()
            If RowsAffected > 0 Then
                LedgerDelete(txtReservationNo.Text, "Room Reservation")
                LedgerDelete(txtReservationNo.Text, "Payment")
                Dim st As String = "deleted the Reservation record having Reservation No. '" & txtReservationNo.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
                frmMainMenu.GetData()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Protected Function CheckAvailability() As Boolean
        Try
            Dim flag As Boolean = False

            If Len(Trim(cmbRoomNo.Text)) = 0 Then
                MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbRoomNo.Focus()
                Exit Function
            End If
            If dtpDateIn.Value.Date = dtpDateOut.Value.Date Then
                MessageBox.Show("Date Out can not be same as Date IN", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT RoomNo from Reservation,Room where Room.R_ID=Reservation.RoomID and RoomNo=@d1 AND Status='Reserved' and
                    Reservation.DateIn < @d2  AND Reservation.DateOut > @d3 union SELECT RoomNo FROM Reservation,Room where 
                    Room.R_ID=Reservation.RoomID and RoomNo=@d1 AND Status='Check In' and Reservation.DateIn < @d2  AND Reservation.DateOut > @d3
                    union all
                    SELECT RoomNo from Reservation,Reservation_details,Room where Reservation.Reserve_ID = Reservation_Details.Reserve_ID and
					Room.R_ID=Reservation_details.RoomID and RoomNo=@d1 AND Reservation.Status='Reserved' and
                    Reservation.DateIn < @d2  AND Reservation.DateOut > @d3 union SELECT RoomNo FROM Reservation,Room where 
                    Room.R_ID=Reservation.RoomID and RoomNo=@d1 AND Status='Check In' and Reservation.DateIn < @d2  AND Reservation.DateOut > @d3"
            cmd = New SqlCommand(ct)
            cmd.Connection = con

            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            cmd.Parameters.AddWithValue("@d2", dtpDateOut.Value.Date)
            cmd.Parameters.AddWithValue("@d3", dtpDateIn.Value.Date)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Selected Room is already reserved/booked", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                flag = False
            Else
                ' MessageBox.Show("Selected Room is available", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                flag = True
            End If
            If Not rdr Is Nothing Then
                rdr.Close()
            End If

            Return flag
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Function


    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            Cursor = Cursors.WaitCursor

            Dim param As String = "Reservation Invoice"

            If (btnCheckOut.Visible = True) Then
                param = "Check-Out Invoice"
            ElseIf btnCheckedIN.Visible = True Then
                param = "Check-In Invoice"
            Else
                param = "Reservation Invoice"
            End If

            Dim rpt As New rptGroupRoomReservation 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1, MyCommand2, MyCommand3, MyCommand4 As New SqlCommand()
            Dim myDA, myDA1, myDA2, myDA3, myDA4 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            Dim pdfFile As String = Application.StartupPath & "\Report.Pdf"
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand2.Connection = myConnection
            MyCommand3.Connection = myConnection
            MyCommand4.Connection = myConnection
            MyCommand.CommandText = "SELECT Guest.ID, Guest.GuestID, Guest.GuestName, Guest.Address, Guest.City, Guest.Country, Guest.ContactNo, Guest.Gender, 
                Guest.Occupation, Guest.Religion, Guest.Email, Guest.IDType, Guest.IDNumber,Guest.Pic1, Guest.Pic2, Guest.pic3, Guest.Notes, Guest.Company, 
                Guest.Model, Guest.VehicleNo, Guest.Color, Reservation.Reserve_ID, Reservation.ReservationNo, Reservation.ReservationDate,Reservation.Guest_ID, 
                Reservation.RoomID, Reservation.RoomCharges, Reservation.DateIN, Reservation.DateOUT, Reservation.NoOfDays, Reservation.NoOfMales, 
                Reservation.NoOfFemales, Reservation.NoOfKids, Reservation.NoOfExtraBed, Reservation.NoOfExtraPerson, Reservation.ExtraPersonCharges, 
                Reservation.TotalRoomCharges, Reservation.ExtraBedCharges, Reservation.DiscountPer, Reservation.DiscountAmount, Reservation.STPer, 
                Reservation.STAmount, Reservation.LuxuryTaxPer, Reservation.LuxuryTaxAmount, Reservation.SubTotal, Reservation.GrandTotal, 
                Reservation.TotalPaid, Reservation.Balance FROM Guest INNER JOIN Reservation ON Guest.ID = Reservation.Guest_ID where 
                Reservation.Guest_ID=" & txtID.Text & " and Reservation.DateIN = '" & dtpDateIn.Value.ToShortDateString & "'"
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand2.CommandText = "SELECT * from Currency"
            MyCommand3.CommandText = "SELECT RoomType, count(roomtype) as NoOfRooms from Reservation r inner join Room r1 on r.roomid = r1.R_ID where r.Guest_ID=" & txtID.Text & " and r.DateIN = '" & dtpDateIn.Value.ToShortDateString & "' group by r1.roomtype"
            MyCommand4.CommandText = "SELECT r3.RoomNo as RoomNum, r3.RoomType, r3.PlanCode, r2.* from    Reservation r1 INNER JOIN
                        Reservation_Details r2 ON r1.Reserve_ID = r2.Reserve_ID INNER JOIN
                      Room r3 ON r2.RoomID = r3.R_ID  where Guest_ID = " & txtID.Text & " and CONVERT(date,DateIN) = '" & dtpDateIn.Value.ToShortDateString & "'"
            MyCommand3.CommandType = CommandType.Text
            MyCommand4.CommandType = CommandType.Text
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            MyCommand2.CommandType = CommandType.Text
            MyCommand4.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA2.SelectCommand = MyCommand2
            myDA3.SelectCommand = MyCommand3
            myDA4.SelectCommand = MyCommand4
            myDA.Fill(myDS, "Guest")
            myDA.Fill(myDS, "Room")
            myDA.Fill(myDS, "Reservation")
            myDA1.Fill(myDS, "Hotel")
            myDA2.Fill(myDS, "Currency")
            myDA3.Fill(myDS, "RoomTypes")
            myDA4.Fill(myDS, "Reservation_Details")
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("v1", param)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            frmReport.CrystalReportViewer1.Refresh()
            Cursor = Cursors.Default

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        frmGuestRecord1.lblSet.Text = "Group Reservation"
        frmGuestRecord1.Reset()
        frmGuestRecord1.Show()
        txtGuestEnterHere.Text = False
        DisableGuestControls()
    End Sub

    Sub fillRoomNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(RoomNo) FROM Room where Active='Yes'", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbRoomNo.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbRoomNo.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub cmbRoomNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRoomNo.SelectedIndexChanged
        Try
            cmbPlanCode.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(PlanCode) from Room where RoomNo=@d1", con)
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            rdr = cmd.ExecuteReader()
            cmbPlanCode.Items.Clear()
            While rdr.Read()
                cmbPlanCode.Items.Add(rdr(0))
            End While
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Fill()
    End Sub

    Sub Fill()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RoomCharges,RoomType FROM Room WHERE RoomNo=@d1 and PlanCode=@d2"
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            cmd.Parameters.AddWithValue("@d2", cmbPlanCode.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtRoomCharges.Text = rdr.GetValue(0)
                txtRoomType.Text = rdr.GetString(1)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            FillData()
            FillExtraBed()
            FillExtraPerson()
            Compute()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub cmbPlanCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPlanCode.SelectedIndexChanged
        Fill()
        GetPlan()
    End Sub

    Sub GetPlan()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT PlanName FROM [Plan] WHERE P_Code=@d1"
            cmd.Parameters.AddWithValue("@d1", cmbPlanCode.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtPlanName.Text = rdr.GetValue(0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnAddRooms_Click(sender As Object, e As EventArgs) Handles btnAddRooms.Click
        Try
            If Len(Trim(txtGuestName.Text)) = 0 Then
                MessageBox.Show("Please enter guest name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtGuestName.Focus()
                Exit Sub
            End If
            If Len(Trim(txtGuestContactNo.Text)) = 0 Then
                MessageBox.Show("Please enter guest contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtGuestContactNo.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbRoomNo.Text)) = 0 Then
                MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbRoomNo.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbPlanCode.Text)) = 0 Then
                MessageBox.Show("Please select plan code", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbPlanCode.Focus()
                Exit Sub
            End If
            If (Val(txtNoOfFemales.Text) + Val(txtNoOfMales.Text) + Val(txtNoOfKids.Text)) = 0 Then
                MessageBox.Show("No. Of (Males + Females + Kids) must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If Len(Trim(txtTotalPaid.Text)) = 0 Then
                MessageBox.Show("Please enter total paid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTotalPaid.Focus()
                Exit Sub
            End If
            If Val(txtBalance.Text) < 0 Then
                MessageBox.Show("Balance can not be less than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTotalPaid.Focus()
                Exit Sub
            End If
            If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
                MessageBox.Show("Total paid can not be more than grand total", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTotalPaid.Text = ""
                txtTotalPaid.Focus()
                Exit Sub
            End If
            If dtpDateIn.Value.Date > dtpDateOut.Value.Date Then
                MessageBox.Show("Date IN should be smaller then Date OUT", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If dtpDateIn.Value.Date = dtpDateOut.Value.Date Then
                MessageBox.Show("Date Out can not be same as Date IN", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim flag As Boolean = False

            flag = CheckAvailability()
            If (flag = False) Then
                Exit Sub
            End If

            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT * FROM Room where R_Status='Vacant Dirty' and RoomNo=@d1"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Selected Room can not be booked because its dirty " & vbCrLf & "Room Status must be Vacant Clean before booking", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()

            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT MaxNoOfKids,MaxNoOfAdults FROM Room WHERE RoomNo=@d1"
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txti1.Text = rdr.GetValue(0)
                txti2.Text = rdr.GetValue(1)
            End If
            If Val(txtNoOfMales.Text) + Val(txtNoOfFemales.Text) > Val(txti2.Text) Then
                MessageBox.Show("No. of adults (Males + Females) are more than allowed adults in a room", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If Val(txtNoOfKids.Text) > Val(txti1.Text) Then
                MessageBox.Show("No. of kids are more than allowed kids in a room", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            Compute()
            GetRoomID()

            Dim row As DataRow = (From column In dt.Rows Where column("RoomID") = txtRoomID.Text).FirstOrDefault()
            If IsNothing(row) Then
                Dim R As DataRow = dt.NewRow
                R("Reserve_ID") = txtReservationNo.Text
                R("Status") = True
                R("RoomID") = Val(txtRoomID.Text)
                R("RoomNum") = cmbRoomNo.SelectedItem.ToString
                R("RoomCharges") = Val(txtRoomCharges.Text)
                R("NoOfDays") = Val(txtNoOfDays.Text)
                R("NoOfMales") = Val(txtNoOfMales.Text)
                R("NoOfFemales") = Val(txtNoOfFemales.Text)
                R("NoOfKids") = Val(txtNoOfKids.Text)
                R("NoOfExtraBed") = Val(txtNoOfExtraBed.Text)
                R("NoOfExtraPerson") = Val(txtNoOfExtraPerson.Text)
                R("ExtraPersonCharges") = Val(txtExtraPersonCharges.Text)
                R("TotalRoomCharges") = Val(txtTotalRoomCharges.Text)
                R("ExtraBedCharges") = Val(txtExtraBedCharges.Text)
                R("DiscountPer") = Val(txtDiscountPer.Text)
                R("DiscountAmount") = Val(txtDiscountAmount.Text)
                R("STPer") = Val(txtServiceTaxPer.Text)
                R("STAmount") = Val(txtServiceTaxAmount.Text)
                R("LuxuryTaxPer") = Val(txtLuxuryTaxPer.Text)
                R("LuxuryTaxAmount") = Val(txtLuxuryTaxAmount.Text)
                R("SubTotal") = Val(txtSubTotal.Text)
                R("GrandTotal") = Val(txtGrandTotal.Text)
                dt.Rows.Add(R)
            Else
                MessageBox.Show("This room is already selected.")
            End If

            'For Each row1 As DataRow In dt.Rows

            'Next

            Dim _LuxuryTaxAmount = Aggregate st In dt Into Sum(st.Field(Of Decimal)("LuxuryTaxAmount"))
            Dim _STAmount = Aggregate st In dt Into Sum(st.Field(Of Decimal)("STAmount"))
            Dim _DiscountAmount = Aggregate st In dt Into Sum(st.Field(Of Decimal)("DiscountAmount"))
            Dim _ExtraPersonCharges = Aggregate st In dt Into Sum(st.Field(Of Decimal)("ExtraPersonCharges"))
            Dim _ExtraBedCharges = Aggregate st In dt Into Sum(st.Field(Of Decimal)("ExtraBedCharges"))
            Dim _GrandTotal = Aggregate st In dt Into Sum(st.Field(Of Decimal)("GrandTotal"))

            DataGridView1.DataSource = dt

            gLuxuryTaxAmount = _LuxuryTaxAmount
            gSTAmount = _STAmount
            gDiscountAmount = _DiscountAmount
            gExtraPersonCharges = _ExtraPersonCharges
            gExtraBedCharges = _ExtraBedCharges
            gGrandTotal = _GrandTotal

            txtGroupTax.Text = gLuxuryTaxAmount + gSTAmount
            txtTotalPaid.Text = 0
            txtGroupBalance.Text = gGrandTotal
            txtGroupTotal.Text = gGrandTotal

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

    End Sub

    Private Sub frmGroupReservation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillRoomNo()
        FillData()
        DisableGuestControls()

        dtpDateOut.Value = dtpDateOut.Value.AddDays(1)

        If dt.Columns.Count < 1 Then
            col1 = New DataColumn("Status", System.Type.GetType("System.Boolean"))
            col2 = New DataColumn("RoomID", System.Type.GetType("System.Int32"))
            col3 = New DataColumn("RoomCharges", System.Type.GetType("System.Decimal"))
            col4 = New DataColumn("NoOfDays", System.Type.GetType("System.Int32"))
            col5 = New DataColumn("NoOfMales", System.Type.GetType("System.Int32"))
            col6 = New DataColumn("NoOfFemales", System.Type.GetType("System.Int32"))
            col7 = New DataColumn("NoOfKids", System.Type.GetType("System.Int32"))
            col8 = New DataColumn("NoOfExtraBed", System.Type.GetType("System.Int32"))
            col9 = New DataColumn("NoOfExtraPerson", System.Type.GetType("System.Int32"))
            col10 = New DataColumn("ExtraPersonCharges", System.Type.GetType("System.Decimal"))
            col11 = New DataColumn("TotalRoomCharges", System.Type.GetType("System.Decimal"))
            col12 = New DataColumn("ExtraBedCharges", System.Type.GetType("System.Decimal"))
            col13 = New DataColumn("DiscountPer", System.Type.GetType("System.Decimal"))
            col14 = New DataColumn("DiscountAmount", System.Type.GetType("System.Decimal"))
            col15 = New DataColumn("STPer", System.Type.GetType("System.Decimal"))
            col16 = New DataColumn("STAmount", System.Type.GetType("System.Decimal"))
            col17 = New DataColumn("LuxuryTaxPer", System.Type.GetType("System.Decimal"))
            col18 = New DataColumn("LuxuryTaxAmount", System.Type.GetType("System.Decimal"))
            col19 = New DataColumn("SubTotal", System.Type.GetType("System.Decimal"))
            col20 = New DataColumn("GrandTotal", System.Type.GetType("System.Decimal"))
            col21 = New DataColumn("Reserve_ID", System.Type.GetType("System.String"))
            col22 = New DataColumn("RoomNum", System.Type.GetType("System.String"))

            dt.Columns.Add(col21)
            dt.Columns.Add(col1)
            dt.Columns.Add(col2)
            dt.Columns.Add(col22)
            dt.Columns.Add(col4)
            dt.Columns.Add(col5)
            dt.Columns.Add(col6)
            dt.Columns.Add(col7)
            dt.Columns.Add(col8)
            dt.Columns.Add(col9)
            dt.Columns.Add(col10)
            dt.Columns.Add(col11)
            dt.Columns.Add(col12)
            dt.Columns.Add(col13)
            dt.Columns.Add(col3)
            dt.Columns.Add(col16)
            dt.Columns.Add(col14)
            dt.Columns.Add(col15)
            dt.Columns.Add(col17)
            dt.Columns.Add(col18)
            dt.Columns.Add(col19)
            dt.Columns.Add(col20)

            DataGridView1.Columns(0).Name = "RoomID"
            DataGridView1.Columns(0).DataPropertyName = "RoomID"
            DataGridView1.Columns(1).Name = "RoomNum"
            DataGridView1.Columns(1).DataPropertyName = "RoomNum"
            DataGridView1.Columns(2).Name = "ExtraPersonCharges"
            DataGridView1.Columns(2).DataPropertyName = "ExtraPersonCharges"
            DataGridView1.Columns(3).Name = "ExtraBedCharges"
            DataGridView1.Columns(3).DataPropertyName = "ExtraBedCharges"
            DataGridView1.Columns(4).Name = "RoomCharges"
            DataGridView1.Columns(4).DataPropertyName = "RoomCharges"
            DataGridView1.Columns(5).Name = "STAmount"
            DataGridView1.Columns(5).DataPropertyName = "STAmount"
            DataGridView1.Columns(6).Name = "DiscountAmount"
            DataGridView1.Columns(6).DataPropertyName = "DiscountAmount"
            DataGridView1.Columns(7).Name = "GrandTotal"
            DataGridView1.Columns(7).DataPropertyName = "GrandTotal"

        End If

        btnAdd1.Enabled = True
        btnRemove1.Enabled = True
        btnDelete.Enabled = True
        txtSaved.Text = "0"
    End Sub

    Private Sub DataGridView1_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles DataGridView1.ColumnAdded
        If e.Column.Name = "Status" Then DataGridView1.Columns("Status").Visible = False
        If e.Column.Name = "NoOfDays" Then DataGridView1.Columns("NoOfDays").Visible = False
        If e.Column.Name = "NoOfMales" Then DataGridView1.Columns("NoOfMales").Visible = False
        If e.Column.Name = "NoOfFemales" Then DataGridView1.Columns("NoOfFemales").Visible = False
        If e.Column.Name = "NoOfKids" Then DataGridView1.Columns("NoOfKids").Visible = False
        If e.Column.Name = "NoOfExtraBed" Then DataGridView1.Columns("NoOfExtraBed").Visible = False
        If e.Column.Name = "NoOfExtraPerson" Then DataGridView1.Columns("NoOfExtraPerson").Visible = False
        If e.Column.Name = "DiscountPer" Then DataGridView1.Columns("DiscountPer").Visible = False
        If e.Column.Name = "STPer" Then DataGridView1.Columns("STPer").Visible = False
        If e.Column.Name = "ID" Then DataGridView1.Columns("ID").Visible = False
        If e.Column.Name = "OtherCharges" Then DataGridView1.Columns("OtherCharges").Visible = False
        If e.Column.Name = "RoomOrderCharges" Then DataGridView1.Columns("RoomOrderCharges").Visible = False
        If e.Column.Name = "LuxuryTaxPer" Then DataGridView1.Columns("LuxuryTaxPer").Visible = False
        If e.Column.Name = "LuxuryTaxAmount" Then DataGridView1.Columns("LuxuryTaxAmount").Visible = False
        If e.Column.Name = "SubTotal" Then DataGridView1.Columns("SubTotal").Visible = False
        If e.Column.Name = "Reserve_ID" Then DataGridView1.Columns("Reserve_ID").Visible = False
        If e.Column.Name = "TotalRoomCharges" Then DataGridView1.Columns("TotalRoomCharges").Visible = False
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        dt.Clear()
        'DataGridView1.Rows.Clear()
        Me.Close()
    End Sub

    Private Sub btnListReset1_Click(sender As Object, e As EventArgs) Handles btnListReset1.Click
        Clear1()
    End Sub

    Sub Clear1()
        cmbPaymentMode.SelectedIndex = -1
        txtPayment.Text = ""
        dtpPaymentDate.Text = Today
        btnAdd1.Enabled = True
        btnRemove1.Enabled = False
        btnListUpdate1.Enabled = False
    End Sub

    Public Function TotalPayment() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                sum = sum + r.Cells(1).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Public Function TotalPayment1() As Double
        Dim sum As Double = 0
        Try

            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                If r.Cells(0).Value = "From Guest's Account" Then
                    sum = sum + r.Cells(1).Value
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function

    Sub Compute1()
        Dim i As Double = 0
        i = Val(txtGroupTotal.Text) - Val(txtTotalPaid.Text)
        i = Math.Round(i, 2)
        txtGroupBalance.Text = i
    End Sub

    Private Sub btnAdd1_Click(sender As Object, e As EventArgs) Handles btnAdd1.Click
        Try
            'If txtSaved.Text = "" Or txtSaved.Text = "0" Then
            '    MessageBox.Show("Please save this booking first.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    btnSave.Focus()
            '    Exit Sub
            'End If

            If cmbPaymentMode.Text = "" Then
                MessageBox.Show("Please select payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbPaymentMode.Focus()
                Exit Sub
            End If
            If txtPayment.Text = "" Then
                MessageBox.Show("Please enter payment", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPayment.Focus()
                Exit Sub
            End If
            DataGridView2.Rows.Add(cmbPaymentMode.Text, Val(txtPayment.Text), dtpPaymentDate.Value.Date)
            Dim j As Double = 0
            j = TotalPayment()
            j = Math.Round(j, 2)
            txtTotalPaid.Text = j

            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "update Reservation set totalpaid=totalpaid+@d2, balance=balance-@d2 where Reserve_ID=@d1"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtReservationID.Text)
            cmd.Parameters.AddWithValue("@d2", j)

            rdr = cmd.ExecuteReader()
            con.Close()
            rdr.Close()

            con = New SqlConnection(cs)
            con.Open()
            ct = "insert into roompayments (ReservationID,AmountPaid,PaymentMode,PaymentDate, status) values (@d1, @d2, @d3, @d4, 1)"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtReservationID.Text)
            cmd.Parameters.AddWithValue("@d2", Val(txtPayment.Text))
            cmd.Parameters.AddWithValue("@d3", cmbPaymentMode.Text)
            cmd.Parameters.AddWithValue("@d4", dtpPaymentDate.Value.Date)

            rdr = cmd.ExecuteReader()
            con.Close()
            rdr.Close()

            'Select Case AmountPaid,PaymentMode,PaymentDate from roompayments where ReservationID=@d1 And status=1

            Compute1()
            Clear1()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnRemove1_Click(sender As Object, e As EventArgs) Handles btnRemove1.Click
        Try
            For Each row As DataGridViewRow In DataGridView2.SelectedRows
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "update Reservation set totalpaid=totalpaid-@d2, balance=balance+@d2 where Reserve_ID=@d1"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", txtReservationID.Text)
                cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value)

                rdr = cmd.ExecuteReader()
                con.Close()
                rdr.Close()

                con = New SqlConnection(cs)
                con.Open()
                ct = "update  roompayments set status = 0 where ReservationID = @d1 and AmountPaid = @d2"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", txtReservationID.Text)
                cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value)
                rdr = cmd.ExecuteReader()
                con.Close()
                rdr.Close()
                DataGridView2.Rows.Remove(row)
            Next
            Dim k As Double = 0
            k = TotalPayment()
            k = Math.Round(k, 2)
            txtTotalPaid.Text = k
            Compute1()
            Compute()
            Clear1()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnListUpdate1_Click(sender As Object, e As EventArgs) Handles btnListUpdate1.Click
        Try

            If cmbPaymentMode.Text = "" Then
                MessageBox.Show("Please select payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbPaymentMode.Focus()
                Exit Sub
            End If
            If txtPayment.Text = "" Then
                MessageBox.Show("Please enter payment", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPayment.Focus()
                Exit Sub
            End If
            DataGridView2.Rows.Add(cmbPaymentMode.Text, Val(txtPayment.Text), dtpPaymentDate.Value.Date)
            Dim j As Double = 0
            j = TotalPayment()
            j = Math.Round(j, 2)
            txtTotalPaid.Text = j
            Compute1()


            Dim gID As String = txtGuestID.Text
            gID = gID.Remove(0, 1)
            con.Open()
            Dim ct As String = "SELECT count(Roomid) from Reservation where guest_id=@d1 and datein=@d2 AND DateOut = @d3"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", gID)
            cmd.Parameters.AddWithValue("@d2", dtpDateIn.Value.Date)
            cmd.Parameters.AddWithValue("@d3", dtpDateOut.Value.Date)
            rdr = cmd.ExecuteReader()

            Dim count As Integer = 0
            Dim paid As Integer = 0
            Dim bal As Integer = 0
            Dim rID As Integer = 0
            Dim GrandTotal As Integer = 0

            If rdr.Read Then
                count = rdr.GetValue(0)
                rdr.Close()

                ct = "SELECT top 1 Reserve_ID from Reservation where guest_id=@d1 and datein=@d2 AND DateOut = @d3 order by Reserve_ID"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", gID)
                cmd.Parameters.AddWithValue("@d2", dtpDateIn.Value.Date)
                cmd.Parameters.AddWithValue("@d3", dtpDateOut.Value.Date)
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    rID = rdr.GetValue(0)
                    con.Close()
                    rdr.Close()
                End If


                If (count > 0) Then
                    Dim a As Integer
                    For a = rID To (rID + (count - 1))

                        con = New SqlConnection(cs)
                        con.Open()
                        ct = "select GrandTotal from reservation where Reserve_ID=@d1"
                        cmd = New SqlCommand(ct)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", a)
                        rdr = cmd.ExecuteReader()

                        If rdr.Read Then
                            GrandTotal = rdr.GetValue(0)
                            con.Close()
                            rdr.Close()
                        End If

                        paid = Val(txtPayment.Text) / count
                        bal = Val(GrandTotal) - paid

                        con = New SqlConnection(cs)
                        con.Open()
                        ct = "update Reservation set totalpaid=totalpaid+@d2, balance=@d3 where Reserve_ID=@d1"
                        cmd = New SqlCommand(ct)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", a)
                        cmd.Parameters.AddWithValue("@d2", paid)
                        cmd.Parameters.AddWithValue("@d3", bal)

                        rdr = cmd.ExecuteReader()
                        con.Close()
                        rdr.Close()
                    Next

                End If
            End If
            Clear1()

        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
        End Try
    End Sub

    Private Sub hsExtraBed_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hsExtraBed.ValueChanged
        If Len(Trim(cmbRoomNo.Text)) = 0 Then
            MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbRoomNo.Focus()
            Exit Sub
        End If
        txtNoOfExtraBed.Text = hsExtraBed.Value.ToString
        FillExtraBed()
        Compute()
    End Sub

    Private Sub hsExtraPerson_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hsExtraPerson.ValueChanged
        If Len(Trim(cmbRoomNo.Text)) = 0 Then
            MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbRoomNo.Focus()
            Exit Sub
        End If
        txtNoOfExtraPerson.Text = hsExtraPerson.Value.ToString
        FillExtraPerson()
        Compute()
    End Sub

    Private Sub hsFemales_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hsFemales.ValueChanged
        txtNoOfFemales.Text = hsFemales.Value.ToString
    End Sub

    Private Sub hsKids_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hsKids.ValueChanged
        txtNoOfKids.Text = hsKids.Value.ToString
    End Sub

    Private Sub hsNoOfMales_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hsMales.ValueChanged
        txtNoOfMales.Text = hsMales.Value.ToString
    End Sub
End Class