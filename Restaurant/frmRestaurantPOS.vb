Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports Microsoft.SqlServer.Management.Smo
Public Class frmRestaurantPOS
    Dim Filename As String
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Dim UserButtons As List(Of Button) = New List(Of Button)
    Dim sign_Indicator As Integer = 0
    Dim variable1 As Double
    Dim variable2 As Double
    Dim fl As Boolean = False
    Dim s, x As String
    Dim num1, num2, num3, num4, num5, num6 As Decimal
    Dim s1, s2, s3 As String
    Dim str1 As String
    Dim str2 As Integer = 0
    Private Sub auto1()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM RestaurantPOS_BillingInfoKOT")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtBillID.Text = Num.ToString
            lblBillNo.Text = "#" + Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtBillID.Text = Num.ToString
            lblBillNo.Text = "#" + Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub
    Private Sub auto2()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM RestaurantPOS_BillingInfoTA")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtBillID1.Text = Num.ToString
            lblBillNo1.Text = "#" + Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtBillID1.Text = Num.ToString
            lblBillNo1.Text = "#" + Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub
    Private Sub auto3()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM RestaurantPOS_BillingInfoHD")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtBillID2.Text = Num.ToString
            lblBillNo2.Text = "#" + Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtBillID2.Text = Num.ToString
            lblBillNo2.Text = "#" + Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub
    Sub fillTableNo()
        Try
            Dim _with1 = lvTable
            _with1.Clear()
            _with1.Columns.Add("Table No.", 120, HorizontalAlignment.Left)
            _with1.Columns.Add("Group/Customer Name", 270, HorizontalAlignment.Left)
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT distinct RTRIM(R_Table.TableNo),RTRIM(GroupName) FROM R_Table,TempRestaurantPOS_OrderInfoKOT where TempRestaurantPOS_OrderInfoKOT.TableNo=R_Table.TableNo and R_Table.TableNo in (Select TableNo from TempRestaurantPOS_OrderInfoKOT) and R_Table.Status='Activate'", con)
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                Dim item = New ListViewItem()
                item.Text = rdr(0).ToString().Trim()
                item.SubItems.Add(rdr(1).ToString().Trim())
                lvTable.Items.Add(item)
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Reset1()
        lblBillNo.Text = ""
        txtGrandTotal.Text = ""
        txtCash.Text = ""
        txtChange.Text = ""
        DataGridView2.Rows.Clear()
        btnPrint1.Enabled = False
        btnSave1.Enabled = True
        btnDelete1.Enabled = False
        lvTable.Enabled = True
        lblPaymentMode.Text = ""
        GetOtherCharges()
        auto1()
        fillTableNo()
        FillAvailableTables()
    End Sub
    Sub GetOtherCharges()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT IsNull(ParcelCharges,0),Isnull(HomeDeliveryCharges,0) from OtherCharges"
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtParcelCharges.Text = rdr.GetValue(0)
                txtDeliveryCharges.Text = rdr.GetValue(1)
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
    Sub Reset2()
        lblBillNo1.Text = ""
        txtSubTotal1.Text = ""
        txtCash1.Text = ""
        txtGrandTotal1.Text = ""
        txtChange1.Text = ""
        DataGridView3.Rows.Clear()
        btnPrint2.Enabled = False
        btnSave2.Enabled = True
        btnDelete2.Enabled = False
        GetOtherCharges()
        flpCategoriesTA.Enabled = True
        flpItemsTA.Enabled = True
        btnNotes1.Enabled = False
        btnPlus1.Enabled = False
        btnMinus1.Enabled = False
        btnChangeRate1.Enabled = False
        btnChangeQty1.Enabled = False
        btnCancel1.Enabled = False
        lblBalance1.Text = "0.00"
        lblPaymentMode1.Text = ""

        lblSet.Text = ""
        txtNotes.Text = ""
        auto2()
        Clear2()
    End Sub
    Sub Reset3()
        lblBillNo2.Text = ""
        txtSubTotal.Text = ""
        txtGrandTotal2.Text = ""
        DataGridView4.Rows.Clear()
        btnPrint3.Enabled = False
        btnSave3.Enabled = True
        btnDelete3.Enabled = False
        GetOtherCharges()
        txtCustomerName.Text = ""
        txtAddress.Text = ""
        txtContactNo.Text = ""
        txtDeliveryPerson.Text = ""
        lblPaymentMode2.Text = ""
        flpCategoriesHD.Enabled = True
        flpItemsHD.Enabled = True
        btnNotes2.Enabled = False
        btnPlus2.Enabled = False
        btnMinus2.Enabled = False
        btnChangeRate2.Enabled = False
        btnChangeQty2.Enabled = False
        btnCancel2.Enabled = False
        lblBalance2.Text = "0.00"
        lblSet.Text = ""
        txtNotes.Text = ""
        auto3()
        Clear3()
    End Sub
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            GetOtherCharges()
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT Distinct RTRIM(CategoryName),Category.BackColor from Category,Dish where Category.Categoryname=Dish.Category order by 1"
            cmd = New SqlCommand(cmdText1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader
            flpCategoriesKOT.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = rdr.GetValue(0)
                btn.FlatStyle = FlatStyle.Popup
                Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                btn.BackColor = btnColor
                btn.Width = 130
                btn.Height = 60
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                UserButtons.Add(btn)
                flpCategoriesKOT.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.Button_Click
            Loop
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText2 As String = "SELECT Distinct RTRIM(CategoryName),Category.BackColor from Category,Dish where Category.Categoryname=Dish.Category order by 1"
            cmd = New SqlCommand(cmdText2)
            cmd.Connection = con
            rdr = cmd.ExecuteReader
            flpCategoriesTA.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = rdr.GetValue(0)
                btn.FlatStyle = FlatStyle.Popup
                Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                btn.BackColor = btnColor
                btn.Width = 130
                btn.Height = 60
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                UserButtons.Add(btn)
                flpCategoriesTA.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.ButtonTA_Click
            Loop
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText3 As String = "SELECT Distinct RTRIM(CategoryName),Category.BackColor from Category,Dish where Category.Categoryname=Dish.Category order by 1"
            cmd = New SqlCommand(cmdText3)
            cmd.Connection = con
            rdr = cmd.ExecuteReader
            flpCategoriesHD.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = rdr.GetValue(0)
                btn.FlatStyle = FlatStyle.Popup
                Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                btn.BackColor = btnColor
                btn.Width = 130
                btn.Height = 60
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                UserButtons.Add(btn)
                flpCategoriesHD.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.ButtonHD_Click
            Loop
            con.Close()
            FillAvailableTables()
            fillTableNo()
            Fill()
            auto()
            auto1()
            auto2()
            auto3()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT Distinct RTRIM(DishName),Dish.BackColor from Category,Dish where Category.CategoryName=Dish.Category and Category=@d1 order by 1"
            cmd = New SqlCommand(cmdText1)
            cmd.Parameters.AddWithValue("@d1", str)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpItemsKOT.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = rdr.GetValue(0)
                btn.FlatStyle = FlatStyle.Popup
                Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                btn.BackColor = btnColor
                btn.Width = 130
                btn.Height = 60
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                btn.ForeColor = System.Drawing.Color.White
                UserButtons.Add(btn)
                flpItemsKOT.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.Button1_Click
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ButtonTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT Distinct RTRIM(DishName),Dish.BackColor from Category,Dish where Category.CategoryName=Dish.Category and Category=@d1 order by 1"
            cmd = New SqlCommand(cmdText1)
            cmd.Parameters.AddWithValue("@d1", str)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpItemsTA.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = rdr.GetValue(0)
                btn.FlatStyle = FlatStyle.Popup
                Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                btn.BackColor = btnColor
                btn.Width = 130
                btn.Height = 60
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                btn.ForeColor = System.Drawing.Color.White
                UserButtons.Add(btn)
                flpItemsTA.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.ButtonTA1_Click
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ButtonHD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT Distinct RTRIM(DishName),Dish.BackColor from Category,Dish where Category.CategoryName=Dish.Category and Category=@d1 order by 1"
            cmd = New SqlCommand(cmdText1)
            cmd.Parameters.AddWithValue("@d1", str)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpItemsHD.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = rdr.GetValue(0)
                btn.FlatStyle = FlatStyle.Popup
                Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                btn.BackColor = btnColor
                btn.Width = 130
                btn.Height = 60
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                btn.ForeColor = System.Drawing.Color.White
                UserButtons.Add(btn)
                flpItemsHD.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.ButtonHD1_Click
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Fill()
        Try

            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText2 As String = "SELECT Top 1 RTRIM(categoryname) from Category,Dish where Category.CategoryName=Dish.Category order by 1"
            cmd = New SqlCommand(cmdText2)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                str1 = rdr.GetValue(0)
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT Distinct RTRIM(DishName),Dish.BackColor from Category,Dish where Category.CategoryName=Dish.Category and Category=@d1 order by 1"
            cmd = New SqlCommand(cmdText1)
            cmd.Parameters.AddWithValue("@d1", str1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpItemsKOT.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = rdr.GetValue(0)
                btn.FlatStyle = FlatStyle.Popup
                Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                btn.BackColor = btnColor
                btn.Width = 130
                btn.Height = 60
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                btn.ForeColor = System.Drawing.Color.White
                UserButtons.Add(btn)
                flpItemsKOT.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.Button1_Click
            Loop
            con.Close()

            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText4 As String = "SELECT Top 1 RTRIM(categoryname) from Category,Dish where Category.CategoryName=Dish.Category order by 1"
            cmd = New SqlCommand(cmdText4)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                str1 = rdr.GetValue(0)
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText3 As String = "SELECT Distinct RTRIM(DishName),Dish.BackColor from Category,Dish where Category.CategoryName=Dish.Category and Category=@d1 order by 1"
            cmd = New SqlCommand(cmdText3)
            cmd.Parameters.AddWithValue("@d1", str1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpItemsTA.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = rdr.GetValue(0)
                btn.FlatStyle = FlatStyle.Popup
                Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                btn.BackColor = btnColor
                btn.Width = 130
                btn.Height = 60
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                btn.ForeColor = System.Drawing.Color.White
                UserButtons.Add(btn)
                flpItemsTA.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.ButtonTA1_Click
            Loop
            con.Close()

            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText6 As String = "SELECT Top 1 RTRIM(categoryname) from Category,Dish where Category.CategoryName=Dish.Category order by 1"
            cmd = New SqlCommand(cmdText6)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                str1 = rdr.GetValue(0)
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText5 As String = "SELECT Distinct RTRIM(DishName),Dish.BackColor from Category,Dish where Category.CategoryName=Dish.Category and Category=@d1 order by 1"
            cmd = New SqlCommand(cmdText5)
            cmd.Parameters.AddWithValue("@d1", str1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpItemsHD.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = rdr.GetValue(0)
                btn.FlatStyle = FlatStyle.Popup
                Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                btn.BackColor = btnColor
                btn.Width = 130
                btn.Height = 60
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                btn.ForeColor = System.Drawing.Color.White
                UserButtons.Add(btn)
                flpItemsHD.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.ButtonHD1_Click
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        lblDateTime.Text = Now.ToString("dddd, dd MMMM yyyy hh:mm tt")
    End Sub
    Sub FillAvailableTables()
        con = New SqlConnection(cs)
        con.Open()
        Dim cmdText1 As String = "SELECT distinct RTRIM(R_Table.TableNo),BkColor,Sum(TempRestaurantPOS_OrderInfoKOT.GrandTotal) from R_Table left Join TempRestaurantPOS_OrderInfoKOT on R_Table.TableNo=TempRestaurantPOS_OrderInfoKOT.TableNo where Status='Activate' group By R_Table.TableNo,BkColor order by 1"
        cmd = New SqlCommand(cmdText1)
        cmd.Connection = con
        rdr = cmd.ExecuteReader()
        flpTables.Controls.Clear()
        Do While (rdr.Read())
            Dim btn As New Button
            btn.Text = rdr.GetValue(0) & Environment.NewLine & rdr.GetValue(2)
            btn.TextAlign = ContentAlignment.MiddleCenter
            Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
            btn.BackColor = btnColor
            btn.FlatStyle = FlatStyle.Popup
            btn.Width = 80
            btn.Height = 40
            btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            UserButtons.Add(btn)
            flpTables.Controls.Add(btn)
            AddHandler btn.Click, AddressOf Me.Button2_Click
        Loop
        con.Close()
    End Sub

    Sub Compute()
        Try
            num1 = CDbl(Val(txtRate_Food.Text) * Val(txtQty_Food.Text))
            num1 = Math.Round(num1, 2)
            txtAmt_Food.Text = num1
            num2 = CDbl((Val(txtAmt_Food.Text) * Val(txtDiscountPer_Food.Text)) / 100)
            num2 = Math.Round(num2, 2)
            txtDiscountAmount_Food.Text = num2
            num3 = CDbl(Val(txtAmt_Food.Text) - Val(txtDiscountAmount_Food.Text))
            num3 = Math.Round(num3, 2)
            txtSubTotal_Food.Text = num3
            num4 = CDbl((Val(txtSubTotal_Food.Text) * Val(txtServiceTaxPer_Food.Text)) / 100)
            num4 = Math.Round(num4, 2)
            txtServiceTaxAmount_Food.Text = num4
            num5 = CDbl((Val(txtSubTotal_Food.Text) * Val(txtVATPer_Food.Text)) / 100)
            num5 = Math.Round(num5, 2)
            txtVATAmt_Food.Text = num5
            num6 = CDbl(Val(txtSubTotal_Food.Text) + Val(txtServiceTaxAmount_Food.Text) + Val(txtVATAmt_Food.Text))
            num6 = Math.Round(num6, 2)
            txtTotalAmt_Food.Text = num6
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT Rate,Category,Discount FROM Dish WHERE DishName=@d1"
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtRate_Food.Text = rdr.GetValue(0)
                txtCategory_Food.Text = rdr.GetString(1)
                txtDiscountPer_Food.Text = rdr.GetValue(2)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT VAT,ST FROM Category WHERE CategoryName=@d1"
            cmd.Parameters.AddWithValue("@d1", txtCategory_Food.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtVATPer_Food.Text = rdr.GetValue(0)
                txtServiceTaxPer_Food.Text = rdr.GetValue(1)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            Compute()
            DataGridView1.Rows.Add(str, Val(txtRate_Food.Text), 1, Val(txtAmt_Food.Text), Val(txtDiscountPer_Food.Text), Val(txtDiscountAmount_Food.Text), Val(txtServiceTaxPer_Food.Text), Val(txtServiceTaxAmount_Food.Text), Val(txtVATPer_Food.Text), Val(txtVATAmt_Food.Text), Val(txtTotalAmt_Food.Text))
            Dim k As Double = 0
            k = GrandTotal_Food()
            k = Math.Round(k, 2)
            lblBalance.Text = k
            Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub ButtonTA1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT Rate,Category,Discount FROM Dish WHERE DishName=@d1"
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtRate_Food.Text = rdr.GetValue(0)
                txtCategory_Food.Text = rdr.GetString(1)
                txtDiscountPer_Food.Text = rdr.GetValue(2)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT VAT,ST FROM Category WHERE CategoryName=@d1"
            cmd.Parameters.AddWithValue("@d1", txtCategory_Food.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtVATPer_Food.Text = rdr.GetValue(0)
                txtServiceTaxPer_Food.Text = rdr.GetValue(1)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            Compute()
            DataGridView3.Rows.Add(str, Val(txtRate_Food.Text), 1, Val(txtAmt_Food.Text), Val(txtDiscountPer_Food.Text), Val(txtDiscountAmount_Food.Text), Val(txtServiceTaxPer_Food.Text), Val(txtServiceTaxAmount_Food.Text), Val(txtVATPer_Food.Text), Val(txtVATAmt_Food.Text), Val(txtTotalAmt_Food.Text))
            Dim k As Double = 0
            k = GrandTotal_Food2()
            k = Math.Round(k, 2)
            lblBalance1.Text = k
            txtSubTotal1.Text = Val(lblBalance1.Text)
            Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub ButtonHD1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT Rate,Category,Discount FROM Dish WHERE DishName=@d1"
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtRate_Food.Text = rdr.GetValue(0)
                txtCategory_Food.Text = rdr.GetString(1)
                txtDiscountPer_Food.Text = rdr.GetValue(2)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT VAT,ST FROM Category WHERE CategoryName=@d1"
            cmd.Parameters.AddWithValue("@d1", txtCategory_Food.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtVATPer_Food.Text = rdr.GetValue(0)
                txtServiceTaxPer_Food.Text = rdr.GetValue(1)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            Compute()
            DataGridView4.Rows.Add(str, Val(txtRate_Food.Text), 1, Val(txtAmt_Food.Text), Val(txtDiscountPer_Food.Text), Val(txtDiscountAmount_Food.Text), Val(txtServiceTaxPer_Food.Text), Val(txtServiceTaxAmount_Food.Text), Val(txtVATPer_Food.Text), Val(txtVATAmt_Food.Text), Val(txtTotalAmt_Food.Text))
            Dim k As Double = 0
            k = GrandTotal_Food3()
            k = Math.Round(k, 2)
            lblBalance2.Text = k
            txtSubTotal.Text = Val(lblBalance2.Text)
            Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            lblTableNo.Text = ""
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text.Trim()
            Dim strText() As String
            strText = Split(str, vbCrLf)
            lblTableNo.Text = strText(0)
            cmbGroup.Enabled = True
            FillGroup()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub Clear()
        txtFoodName.Text = ""
        txtRate_Food.Text = ""
        txtQty_Food.Text = 1
        txtAmt_Food.Text = ""
        txtServiceTaxAmount_Food.Text = ""
        txtServiceTaxPer_Food.Text = ""
        txtDiscountAmount_Food.Text = ""
        txtDiscountPer_Food.Text = ""
        txtVATAmt_Food.Text = ""
        txtVATPer_Food.Text = ""
        txtTotalAmt_Food.Text = ""
        btnMinus.Enabled = False
        btnPlus.Enabled = False
        btnCancel.Enabled = False
        btnChangeRate.Enabled = False
        btnChangeQty.Enabled = False
        DataGridView1.ClearSelection()
    End Sub
    Sub Clear2()
        txtFoodName.Text = ""
        txtRate_Food.Text = ""
        txtQty_Food.Text = 1
        txtAmt_Food.Text = ""
        txtServiceTaxAmount_Food.Text = ""
        txtServiceTaxPer_Food.Text = ""
        txtDiscountAmount_Food.Text = ""
        txtDiscountPer_Food.Text = ""
        txtVATAmt_Food.Text = ""
        txtVATPer_Food.Text = ""
        txtTotalAmt_Food.Text = ""
        btnMinus1.Enabled = False
        btnPlus1.Enabled = False
        btnCancel1.Enabled = False
        btnChangeRate1.Enabled = False
        btnChangeQty1.Enabled = False
        DataGridView3.ClearSelection()
    End Sub
    Sub Clear3()
        txtFoodName.Text = ""
        txtRate_Food.Text = ""
        txtQty_Food.Text = 1
        txtAmt_Food.Text = ""
        txtServiceTaxAmount_Food.Text = ""
        txtServiceTaxPer_Food.Text = ""
        txtDiscountAmount_Food.Text = ""
        txtDiscountPer_Food.Text = ""
        txtVATAmt_Food.Text = ""
        txtVATPer_Food.Text = ""
        txtTotalAmt_Food.Text = ""
        btnMinus2.Enabled = False
        btnPlus2.Enabled = False
        btnCancel2.Enabled = False
        btnChangeRate2.Enabled = False
        btnChangeQty2.Enabled = False
        DataGridView4.ClearSelection()
    End Sub
    Sub Clear1()
        txtFoodName.Text = ""
        txtRate_Food.Text = ""
        txtQty_Food.Text = 1
        txtAmt_Food.Text = ""
        txtServiceTaxAmount_Food.Text = ""
        txtServiceTaxPer_Food.Text = ""
        txtDiscountAmount_Food.Text = ""
        txtDiscountPer_Food.Text = ""
        txtVATAmt_Food.Text = ""
        txtVATPer_Food.Text = ""
        txtTotalAmt_Food.Text = ""
    End Sub
    Public Function GrandTotal_Food() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                sum = sum + r.Cells(10).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Public Function GrandTotal_Food2() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView3.Rows
                sum = sum + r.Cells(10).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Public Function GrandTotal_Food3() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView4.Rows
                sum = sum + r.Cells(10).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Private Sub DataGridView1_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        If DataGridView1.Rows.Count > 0 Then
            If lblSet.Text = "Not Allowed" Then
                btnPlus.Enabled = False
                btnCancel.Enabled = False
                btnChangeRate.Enabled = False
                btnChangeQty.Enabled = False
                btnMinus.Enabled = False
                btnNotes.Enabled = False
            Else
                For Each row As DataGridViewRow In DataGridView1.SelectedRows
                    btnPlus.Enabled = True
                    btnCancel.Enabled = True
                    btnNotes.Enabled = True
                    btnChangeRate.Enabled = True
                    btnChangeQty.Enabled = True
                    If row.Cells(2).Value > 1 Then
                        btnMinus.Enabled = True
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub btnPlus_Click(sender As System.Object, e As System.EventArgs) Handles btnPlus.Click
        Try
            For Each r As DataGridViewRow In Me.DataGridView1.SelectedRows
                FillData()
                Compute()
                r.Cells(0).Value = r.Cells(0).Value
                r.Cells(1).Value = txtRate_Food.Text
                r.Cells(2).Value = Val(r.Cells(2).Value) + 1
                r.Cells(3).Value = Val(r.Cells(3).Value) + Val(txtAmt_Food.Text)
                r.Cells(4).Value = Val(txtDiscountPer_Food.Text)
                r.Cells(5).Value = Val(r.Cells(5).Value) + Val(txtDiscountAmount_Food.Text)
                r.Cells(6).Value = Val(txtServiceTaxPer_Food.Text)
                r.Cells(7).Value = Val(r.Cells(7).Value) + Val(txtServiceTaxAmount_Food.Text)
                r.Cells(8).Value = Val(txtVATPer_Food.Text)
                r.Cells(9).Value = Val(r.Cells(9).Value) + Val(txtVATAmt_Food.Text)
                r.Cells(10).Value = Val(r.Cells(10).Value) + Val(txtTotalAmt_Food.Text)
                Dim i As Double = 0
                i = GrandTotal_Food()
                i = Math.Round(i, 2)
                lblBalance.Text = i
                Clear1()
                If r.Cells(2).Value > 1 Then
                    btnMinus.Enabled = True
                Else
                    btnMinus.Enabled = False
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Try
            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                DataGridView1.Rows.Remove(row)
            Next
            Dim k As Double = 0
            k = GrandTotal_Food()
            k = Math.Round(k, 2)
            lblBalance.Text = k
            Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnMinus_Click(sender As System.Object, e As System.EventArgs) Handles btnMinus.Click
        Try
            For Each r As DataGridViewRow In Me.DataGridView1.SelectedRows
                FillData()
                If r.Cells(2).Value = 1 Then
                    btnMinus.Enabled = False
                    Exit Sub
                End If
                Compute()
                r.Cells(0).Value = r.Cells(0).Value
                r.Cells(1).Value = txtRate_Food.Text
                r.Cells(2).Value = Val(r.Cells(2).Value) - 1
                r.Cells(3).Value = Val(r.Cells(3).Value) - Val(txtAmt_Food.Text)
                r.Cells(4).Value = Val(txtDiscountPer_Food.Text)
                r.Cells(5).Value = Val(r.Cells(5).Value) - Val(txtDiscountAmount_Food.Text)
                r.Cells(6).Value = Val(txtServiceTaxPer_Food.Text)
                r.Cells(7).Value = Val(r.Cells(7).Value) - Val(txtServiceTaxAmount_Food.Text)
                r.Cells(8).Value = Val(txtVATPer_Food.Text)
                r.Cells(9).Value = Val(r.Cells(9).Value) - Val(txtVATAmt_Food.Text)
                r.Cells(10).Value = Val(r.Cells(10).Value) - Val(txtTotalAmt_Food.Text)
                Dim i As Double = 0
                i = GrandTotal_Food()
                i = Math.Round(i, 2)
                lblBalance.Text = i
                Clear1()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub auto()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM RestaurantPOS_OrderInfoKOT")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtTicketID.Text = Num.ToString
            lblTicketNo.Text = "KOT-" + Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtTicketID.Text = Num.ToString
            lblTicketNo.Text = "KOT-" + Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub

    Private Sub btnChangeRate_Click(sender As System.Object, e As System.EventArgs) Handles btnChangeRate.Click
        Try
            frmChangeRate.lblSet.Text = "KOT"
            If DataGridView1.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
                frmChangeRate.txtNotes.Text = dr.Cells(11).Value
            End If
            frmChangeRate.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub FillData()
        Try
            If DataGridView1.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
                txtFoodName.Text = dr.Cells(0).Value.ToString()
                txtRate_Food.Text = dr.Cells(1).Value.ToString
                txtQty_Food.Text = 1
                txtAmt_Food.Text = dr.Cells(3).Value.ToString()
                txtDiscountPer_Food.Text = dr.Cells(4).Value.ToString()
                txtDiscountAmount_Food.Text = dr.Cells(5).Value.ToString()
                txtServiceTaxPer_Food.Text = dr.Cells(6).Value.ToString()
                txtServiceTaxAmount_Food.Text = dr.Cells(7).Value.ToString()
                txtVATPer_Food.Text = dr.Cells(8).Value.ToString()
                txtVATAmt_Food.Text = dr.Cells(9).Value.ToString()
                txtTotalAmt_Food.Text = dr.Cells(10).Value.ToString()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub FillData1()
        Try
            If DataGridView3.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView3.SelectedRows(0)
                txtFoodName.Text = dr.Cells(0).Value.ToString()
                txtRate_Food.Text = dr.Cells(1).Value.ToString
                txtQty_Food.Text = 1
                txtAmt_Food.Text = dr.Cells(3).Value.ToString()
                txtDiscountPer_Food.Text = dr.Cells(4).Value.ToString()
                txtDiscountAmount_Food.Text = dr.Cells(5).Value.ToString()
                txtServiceTaxPer_Food.Text = dr.Cells(6).Value.ToString()
                txtServiceTaxAmount_Food.Text = dr.Cells(7).Value.ToString()
                txtVATPer_Food.Text = dr.Cells(8).Value.ToString()
                txtVATAmt_Food.Text = dr.Cells(9).Value.ToString()
                txtTotalAmt_Food.Text = dr.Cells(10).Value.ToString()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub FillData2()
        Try
            If DataGridView4.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView4.SelectedRows(0)
                txtFoodName.Text = dr.Cells(0).Value.ToString()
                txtRate_Food.Text = dr.Cells(1).Value.ToString
                txtQty_Food.Text = 1
                txtAmt_Food.Text = dr.Cells(3).Value.ToString()
                txtDiscountPer_Food.Text = dr.Cells(4).Value.ToString()
                txtDiscountAmount_Food.Text = dr.Cells(5).Value.ToString()
                txtServiceTaxPer_Food.Text = dr.Cells(6).Value.ToString()
                txtServiceTaxAmount_Food.Text = dr.Cells(7).Value.ToString()
                txtVATPer_Food.Text = dr.Cells(8).Value.ToString()
                txtVATAmt_Food.Text = dr.Cells(9).Value.ToString()
                txtTotalAmt_Food.Text = dr.Cells(10).Value.ToString()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtTotalAmt_Food_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotalAmt_Food.TextChanged
        Compute()
    End Sub

    Private Sub txtDiscountAmount_Food_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDiscountAmount_Food.TextChanged
        Compute()
    End Sub

    Private Sub txtServiceTaxPer_Food_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtServiceTaxPer_Food.TextChanged
        Compute()
    End Sub

    Private Sub txtVATAmt_Food_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtVATAmt_Food.TextChanged
        Compute()
    End Sub

    Private Sub txtVATPer_Food_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtVATPer_Food.TextChanged
        Compute()
    End Sub

    Private Sub txtServiceTaxAmount_Food_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtServiceTaxAmount_Food.TextChanged
        Compute()
    End Sub

    Private Sub txtDiscountPer_Food_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDiscountPer_Food.TextChanged
        Compute()
    End Sub

    Private Sub txtAmt_Food_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAmt_Food.TextChanged
        Compute()
    End Sub

    Private Sub txtQty_Food_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtQty_Food.TextChanged
        Compute()
    End Sub

    Private Sub txtRate_Food_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRate_Food.TextChanged
        Compute()
    End Sub
    Sub Settle()
        Try
            If DataGridView1.Rows.Count > 0 Then
                con = New SqlConnection(cs)
                con.Open()
                Dim cb1 As String = "insert into PosGrouping VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)"
                cmd = New SqlCommand(cb1)
                cmd.Connection = con
                ' Prepare command for repeated execution
                cmd.Prepare()
                ' Data to be inserted
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If Not row.IsNewRow Then
                        cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@d3", Val(row.Cells(2).Value))
                        cmd.Parameters.AddWithValue("@d4", Val(row.Cells(3).Value))
                        cmd.Parameters.AddWithValue("@d5", Val(row.Cells(4).Value))
                        cmd.Parameters.AddWithValue("@d6", Val(row.Cells(5).Value))
                        cmd.Parameters.AddWithValue("@d7", Val(row.Cells(6).Value))
                        cmd.Parameters.AddWithValue("@d8", Val(row.Cells(7).Value))
                        cmd.Parameters.AddWithValue("@d9", Val(row.Cells(8).Value))
                        cmd.Parameters.AddWithValue("@d10", Val(row.Cells(9).Value))
                        cmd.Parameters.AddWithValue("@d11", Val(row.Cells(10).Value))
                        If row.Cells(11).Value = "" Then
                            cmd.Parameters.AddWithValue("@d12", "")
                        Else
                            cmd.Parameters.AddWithValue("@d12", row.Cells(11).Value)
                        End If
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                Next
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("SELECT RTRIM(Col1),Col2,Sum(Col3),SUM(Col4),(Col5),Sum(Col6),(Col7),Sum(Col8),(Col9),Sum(Col10),Sum(Col11),Col12 from PosGrouping group by Col1,Col2,Col5,Col7,Col9,col12 order by Col1", con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                DataGridView1.Rows.Clear()
                While (rdr.Read() = True)
                    DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11))
                End While
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                Dim cb2 As String = "delete from PosGrouping"
                cmd = New SqlCommand(cb2)
                cmd.Connection = con
                cmd.ExecuteNonQuery()
                con.Close()
                DataGridView1.ClearSelection()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Settle1()
        Try
            If DataGridView3.Rows.Count > 0 Then
                con = New SqlConnection(cs)
                con.Open()
                Dim cb1 As String = "insert into PosGrouping VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)"
                cmd = New SqlCommand(cb1)
                cmd.Connection = con
                ' Prepare command for repeated execution
                cmd.Prepare()
                ' Data to be inserted
                For Each row As DataGridViewRow In DataGridView3.Rows
                    If Not row.IsNewRow Then
                        cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@d3", Val(row.Cells(2).Value))
                        cmd.Parameters.AddWithValue("@d4", Val(row.Cells(3).Value))
                        cmd.Parameters.AddWithValue("@d5", Val(row.Cells(4).Value))
                        cmd.Parameters.AddWithValue("@d6", Val(row.Cells(5).Value))
                        cmd.Parameters.AddWithValue("@d7", Val(row.Cells(6).Value))
                        cmd.Parameters.AddWithValue("@d8", Val(row.Cells(7).Value))
                        cmd.Parameters.AddWithValue("@d9", Val(row.Cells(8).Value))
                        cmd.Parameters.AddWithValue("@d10", Val(row.Cells(9).Value))
                        cmd.Parameters.AddWithValue("@d11", Val(row.Cells(10).Value))
                        If row.Cells(11).Value = "" Then
                            cmd.Parameters.AddWithValue("@d12", "")
                        Else
                            cmd.Parameters.AddWithValue("@d12", row.Cells(11).Value)
                        End If
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                Next
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("SELECT RTRIM(Col1),Col2,Sum(Col3),SUM(Col4),(Col5),Sum(Col6),(Col7),Sum(Col8),(Col9),Sum(Col10),Sum(Col11),Col12 from PosGrouping group by Col1,Col2,Col5,Col7,Col9,col12 order by Col1", con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                DataGridView3.Rows.Clear()
                While (rdr.Read() = True)
                    DataGridView3.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11))
                End While
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                Dim cb2 As String = "delete from PosGrouping"
                cmd = New SqlCommand(cb2)
                cmd.Connection = con
                cmd.ExecuteNonQuery()
                con.Close()
                DataGridView3.ClearSelection()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Settle2()
        Try
            If DataGridView4.Rows.Count > 0 Then
                con = New SqlConnection(cs)
                con.Open()
                Dim cb1 As String = "insert into PosGrouping VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)"
                cmd = New SqlCommand(cb1)
                cmd.Connection = con
                ' Prepare command for repeated execution
                cmd.Prepare()
                ' Data to be inserted
                For Each row As DataGridViewRow In DataGridView4.Rows
                    If Not row.IsNewRow Then
                        cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@d3", Val(row.Cells(2).Value))
                        cmd.Parameters.AddWithValue("@d4", Val(row.Cells(3).Value))
                        cmd.Parameters.AddWithValue("@d5", Val(row.Cells(4).Value))
                        cmd.Parameters.AddWithValue("@d6", Val(row.Cells(5).Value))
                        cmd.Parameters.AddWithValue("@d7", Val(row.Cells(6).Value))
                        cmd.Parameters.AddWithValue("@d8", Val(row.Cells(7).Value))
                        cmd.Parameters.AddWithValue("@d9", Val(row.Cells(8).Value))
                        cmd.Parameters.AddWithValue("@d10", Val(row.Cells(9).Value))
                        cmd.Parameters.AddWithValue("@d11", Val(row.Cells(10).Value))
                        If row.Cells(11).Value = "" Then
                            cmd.Parameters.AddWithValue("@d12", "")
                        Else
                            cmd.Parameters.AddWithValue("@d12", row.Cells(11).Value)
                        End If
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                Next
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("SELECT RTRIM(Col1),Col2,Sum(Col3),SUM(Col4),(Col5),Sum(Col6),(Col7),Sum(Col8),(Col9),Sum(Col10),Sum(Col11),Col12 from PosGrouping group by Col1,Col2,Col5,Col7,Col9,col12 order by Col1", con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                DataGridView4.Rows.Clear()
                While (rdr.Read() = True)
                    DataGridView4.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11))
                End While
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                Dim cb2 As String = "delete from PosGrouping"
                cmd = New SqlCommand(cb2)
                cmd.Connection = con
                cmd.ExecuteNonQuery()
                con.Close()
                DataGridView4.ClearSelection()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnSettle_Click(sender As System.Object, e As System.EventArgs) Handles btnSettle.Click
        Try
            If lblTableNo.Text = "" Then
                MessageBox.Show("Please select table", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If DataGridView1.Rows.Count = 0 Then
                MessageBox.Show("sorry no item added to datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Settle()
            flpCategoriesKOT.Enabled = False
            flpItemsKOT.Enabled = False
            flpTables.Enabled = False
            lblSet.Text = "Not Allowed"
            DataGridView1.ClearSelection()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Try
            If lblTableNo.Text = "" Then
                MessageBox.Show("Please select table", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If DataGridView1.Rows.Count = 0 Then
                MessageBox.Show("sorry no item added to datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Settle()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into RestaurantPOS_OrderInfoKOT( Id,TicketNo, BillDate, GrandTotal,tableNo,Operator,GroupName) Values (" & txtTicketID.Text & ",'" & lblTicketNo.Text & "',@d2," & lblBalance.Text & ",@d1,@d3,@d4)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", lblTableNo.Text)
            cmd.Parameters.AddWithValue("@d2", System.DateTime.Now)
            cmd.Parameters.AddWithValue("@d3", lblUser.Text)
            cmd.Parameters.AddWithValue("@d4", cmbGroup.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cl As String = "insert into TempRestaurantPOS_OrderInfoKOT( Id, TicketNo, BillDate, GrandTotal,tableNo,GroupName) Values (" & txtTicketID.Text & ",'" & lblTicketNo.Text & "',@d2," & lblBalance.Text & ",@d1,@d3)"
            cmd = New SqlCommand(cl)
            cmd.Parameters.AddWithValue("@d1", lblTableNo.Text)
            cmd.Parameters.AddWithValue("@d2", System.DateTime.Now)
            cmd.Parameters.AddWithValue("@d3", cmbGroup.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into RestaurantPOS_OrderedProductKOT(TicketID,Dish,Rate,Quantity,Amount,DiscountPer, DiscountAmount, STPer, STAmount, VATPer, VATAmount,TotalAmount,Notes ) VALUES (" & txtTicketID.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(2).Value))
                    cmd.Parameters.AddWithValue("@d4", Val(row.Cells(3).Value))
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(4).Value))
                    cmd.Parameters.AddWithValue("@d6", Val(row.Cells(5).Value))
                    cmd.Parameters.AddWithValue("@d7", Val(row.Cells(6).Value))
                    cmd.Parameters.AddWithValue("@d8", Val(row.Cells(7).Value))
                    cmd.Parameters.AddWithValue("@d9", Val(row.Cells(8).Value))
                    cmd.Parameters.AddWithValue("@d10", Val(row.Cells(9).Value))
                    cmd.Parameters.AddWithValue("@d11", Val(row.Cells(10).Value))
                    If row.Cells(11).Value = "" Then
                        cmd.Parameters.AddWithValue("@d12", "")
                    Else
                        cmd.Parameters.AddWithValue("@d12", row.Cells(11).Value)
                    End If
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cl1 As String = "insert into TempRestaurantPOS_OrderedProductKOT(TicketID,Dish,Rate,Quantity,Amount,DiscountPer, DiscountAmount, STPer, STAmount, VATPer, VATAmount,TotalAmount ) VALUES (" & txtTicketID.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)"
            cmd = New SqlCommand(cl1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(2).Value))
                    cmd.Parameters.AddWithValue("@d4", Val(row.Cells(3).Value))
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(4).Value))
                    cmd.Parameters.AddWithValue("@d6", Val(row.Cells(5).Value))
                    cmd.Parameters.AddWithValue("@d7", Val(row.Cells(6).Value))
                    cmd.Parameters.AddWithValue("@d8", Val(row.Cells(7).Value))
                    cmd.Parameters.AddWithValue("@d9", Val(row.Cells(8).Value))
                    cmd.Parameters.AddWithValue("@d10", Val(row.Cells(9).Value))
                    cmd.Parameters.AddWithValue("@d11", Val(row.Cells(10).Value))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cbX As String = "Update R_Table set BkColor=@d2 where TableNo=@d1"
            cmd = New SqlCommand(cbX)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", lblTableNo.Text)
            cmd.Parameters.AddWithValue("@d2", Color.Red.ToArgb())
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "added the new restaurant pos record having ticket no. '" & lblTicketNo.Text & "'"
            LogFunc(lblUser.Text, st)
            btnSave.Enabled = False
            Print()
            fillTableNo()
            FillGroup()
            FillAvailableTables()
            Reset()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
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
            Dim ctx As String = "Select Count(TicketNo) from TempRestaurantPOS_OrderInfoKOT where TableNo=@d1"
            cmd = New SqlCommand(ctx)
            cmd.Parameters.AddWithValue("@d1", lblTableNo.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                str2 = rdr.GetValue(0)
                If Val(str2) = 1 Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cbX As String = "Update R_Table set BkColor=@d2 where TableNo=@d1"
                    cmd = New SqlCommand(cbX)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", lblTableNo.Text)
                    cmd.Parameters.AddWithValue("@d2", Color.LightGreen.ToArgb())
                    cmd.ExecuteReader()
                    con.Close()
                End If
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "delete from TempRestaurantPOS_OrderInfoKOT where TicketNo=@d1"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d1", lblTicketNo.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ct1 As String = "delete from RestaurantPOS_OrderInfoKOT where ID=" & txtTicketID.Text & ""
            cmd = New SqlCommand(ct1)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            If RowsAffected > 0 Then
                Dim st As String = "deleted the restaurant pos record having ticket no. '" & lblTicketNo.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                fillTableNo()
                FillGroup()
                FillAvailableTables()
                Reset()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub DeleteRecord1()
        Try
            Dim RowsAffected As Integer = 0
            con.Open()
            Dim ct As String = "delete from RestaurantPOS_BillingInfoKOT where ID=" & txtBillID.Text & ""
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            If RowsAffected > 0 Then
                LedgerDelete(lblBillNo.Text, "Restaurant POS")
                Dim st As String = "deleted the restaurant pos record having bill no. '" & lblBillNo.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                fillTableNo()
                FillAvailableTables()
                Reset1()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset1()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub DeleteRecord2()
        Try
            Dim RowsAffected As Integer = 0
            con.Open()
            Dim ct As String = "delete from RestaurantPOS_BillingInfoTA where ID=" & txtBillID1.Text & ""
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            If RowsAffected > 0 Then
                LedgerDelete(lblBillNo1.Text, "Restaurant POS(Takeaway)")
                Dim st As String = "deleted the restaurant pos(takeaway) record having bill no. '" & lblBillNo1.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset2()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset2()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub DeleteRecord3()
        Try
            Dim RowsAffected As Integer = 0
            con.Open()
            Dim ct As String = "delete from RestaurantPOS_BillingInfoHD where ID=" & txtBillID2.Text & ""
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            If RowsAffected > 0 Then
                LedgerDelete(lblBillNo2.Text, "Restaurant POS(Home Delivery)")
                Dim st As String = "deleted the restaurant pos(takeaway) record having bill no. '" & lblBillNo2.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset3()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset3()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub PrintFunc1()
        Dim CN As New SqlConnection(cs)
        CN.Open()
        adp = New SqlDataAdapter()
        adp.SelectCommand = New SqlCommand("SELECT DISTINCT RTRIM(Kitchen.Kitchenname) FROM Dish INNER JOIN Kitchen ON Dish.Kitchen = Kitchen.Kitchenname INNER JOIN RestaurantPOS_OrderedProductKOT ON Dish.DishName = RestaurantPOS_OrderedProductKOT.Dish INNER JOIN RestaurantPOS_OrderInfoKOT ON RestaurantPOS_OrderedProductKOT.TicketID = RestaurantPOS_OrderInfoKOT.ID where TicketNo='" & lblTicketNo.Text & "'", CN)
        ds = New DataSet("ds")
        adp.Fill(ds)
        Dim dtable As DataTable = ds.Tables(0)
        CBox.Items.Clear()
        For Each drow As DataRow In dtable.Rows
            CBox.Items.Add(drow(0).ToString())
        Next
        For Each item As String In CBox.Items
            Cursor = Cursors.WaitCursor
            Timer2.Enabled = True
            Dim rpt As New rptRestaurantPOSKOTInvoice_Kitchen 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT distinct RestaurantPOS_OrderedProductKOT.OP_ID,RestaurantPOS_OrderedProductKOT.Notes,Operator,GroupName, RestaurantPOS_OrderedProductKOT.TicketID, RestaurantPOS_OrderedProductKOT.Dish, RestaurantPOS_OrderedProductKOT.VATPer,RestaurantPOS_OrderedProductKOT.VATAmount, RestaurantPOS_OrderedProductKOT.STPer, RestaurantPOS_OrderedProductKOT.STAmount, RestaurantPOS_OrderedProductKOT.DiscountPer, RestaurantPOS_OrderedProductKOT.DiscountAmount,RestaurantPOS_OrderedProductKOT.Rate, RestaurantPOS_OrderedProductKOT.Quantity, RestaurantPOS_OrderedProductKOT.Amount, RestaurantPOS_OrderedProductKOT.TotalAmount,RestaurantPOS_OrderInfoKOT.ID, RestaurantPOS_OrderInfoKOT.TicketNo,RestaurantPOS_OrderInfoKOT.TableNo, RestaurantPOS_OrderInfoKOT.BillDate, RestaurantPOS_OrderInfoKOT.GrandTotal FROM Dish INNER JOIN Kitchen ON Dish.Kitchen = Kitchen.Kitchenname INNER JOIN RestaurantPOS_OrderedProductKOT ON Dish.DishName = RestaurantPOS_OrderedProductKOT.Dish INNER JOIN RestaurantPOS_OrderInfoKOT ON RestaurantPOS_OrderedProductKOT.TicketID = RestaurantPOS_OrderInfoKOT.ID where TicketNo='" & lblTicketNo.Text & "' and KitchenName=@d1"
            MyCommand.Parameters.AddWithValue("@d1", item)
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "RestaurantPOS_OrderInfoKOT")
            myDA.Fill(myDS, "Dish")
            myDA.Fill(myDS, "Kitchen")
            myDA.Fill(myDS, "RestaurantPOS_OrderedProductKOT")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT Printer from Kitchen where KitchenName=@d1 and IsEnabled='Yes'"
            cmd.Parameters.AddWithValue("@d1", item)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                s1 = rdr.GetValue(0)
                rpt.PrintOptions.PrinterName = s1
                rpt.PrintToPrinter(1, False, 0, 0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Next
    End Sub
    Sub PrintFunc2()
        Cursor = Cursors.WaitCursor
        Timer2.Enabled = True
        Dim rpt As New rptRestaurantPOSKOTInvoice 'The report you created.
        Dim myConnection As SqlConnection
        Dim MyCommand, MyCommand1 As New SqlCommand()
        Dim myDA, myDA1 As New SqlDataAdapter()
        Dim myDS As New DataSet 'The DataSet you created.
        myConnection = New SqlConnection(cs)
        MyCommand.Connection = myConnection
        MyCommand1.Connection = myConnection
        MyCommand.CommandText = "SELECT RestaurantPOS_OrderedProductKOT.OP_ID,RestaurantPOS_OrderedProductKOT.Notes,Operator,GroupName, RestaurantPOS_OrderedProductKOT.TicketID, RestaurantPOS_OrderedProductKOT.Dish, RestaurantPOS_OrderedProductKOT.VATPer,RestaurantPOS_OrderedProductKOT.VATAmount, RestaurantPOS_OrderedProductKOT.STPer, RestaurantPOS_OrderedProductKOT.STAmount, RestaurantPOS_OrderedProductKOT.DiscountPer, RestaurantPOS_OrderedProductKOT.DiscountAmount,RestaurantPOS_OrderedProductKOT.Rate, RestaurantPOS_OrderedProductKOT.Quantity, RestaurantPOS_OrderedProductKOT.Amount, RestaurantPOS_OrderedProductKOT.TotalAmount,RestaurantPOS_OrderInfoKOT.ID, RestaurantPOS_OrderInfoKOT.TicketNo,RestaurantPOS_OrderInfoKOT.TableNo, RestaurantPOS_OrderInfoKOT.BillDate, RestaurantPOS_OrderInfoKOT.GrandTotal FROM RestaurantPOS_OrderedProductKOT INNER JOIN  RestaurantPOS_OrderInfoKOT ON RestaurantPOS_OrderedProductKOT.TicketID = RestaurantPOS_OrderInfoKOT.ID where RestaurantPOS_OrderInfoKOT.TicketNo='" & lblTicketNo.Text & "'"
        MyCommand1.CommandText = "SELECT * from Hotel"
        MyCommand.CommandType = CommandType.Text
        MyCommand1.CommandType = CommandType.Text
        myDA.SelectCommand = MyCommand
        myDA1.SelectCommand = MyCommand1
        myDA.Fill(myDS, "RestaurantPOS_OrderInfoKOT")
        myDA.Fill(myDS, "RestaurantPOS_OrderedProductKOT")
        myDA1.Fill(myDS, "Hotel")
        rpt.SetDataSource(myDS)
        con = New SqlConnection(cs)
        con.Open()
        cmd = con.CreateCommand()
        cmd.CommandText = "SELECT PrinterName from POSPrinterSetting where PrinterType='Ticket Printer' and IsEnabled='Yes'"
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
            s2 = rdr.GetValue(0)
            rpt.PrintOptions.PrinterName = s2
            rpt.PrintToPrinter(1, False, 0, 0)
        End If
        If (rdr IsNot Nothing) Then
            rdr.Close()
        End If
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub
    Sub Print()
        Try
            PrintFunc1()
            PrintFunc2()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub FillGroup()
        cmbGroup.Text = ""
        con = New SqlConnection(cs)
        con.Open()
        cmd = New SqlCommand("Select distinct RTRIM(GroupName) from TempRestaurantPOS_OrderInfoKOT where TableNo=@d1 order by 1", con)
        cmd.Parameters.AddWithValue("@d1", lblTableNo.Text)
        rdr = cmd.ExecuteReader()
        cmbGroup.Items.Clear()
        While rdr.Read()
            cmbGroup.Items.Add(rdr(0))
        End While
        con.Close()
    End Sub
    Sub Reset()
        DataGridView1.Rows.Clear()
        Clear()
        btnSave.Enabled = True
        btnDelete.Enabled = False
        lblTableNo.Text = ""
        flpCategoriesKOT.Enabled = True
        flpItemsKOT.Enabled = True
        flpTables.Enabled = True
        btnPrint.Enabled = False
        lblSet.Text = ""
        lblBalance.Text = "0.00"
        lblTicketNo.Text = ""
        btnSettle.Enabled = True
        btnNotes.Enabled = False
        btnPlus.Enabled = False
        btnMinus.Enabled = False
        btnChangeTable.Enabled = False
        btnCancel.Enabled = False
        btnChangeQty.Enabled = False
        btnChangeRate.Enabled = False
        cmbGroup.Text = ""
        cmbGroup.Enabled = False
        GetOtherCharges()
        s1 = ""
        s2 = ""
        s3 = ""
        txtNotes.Text = ""
        auto()
        fillTableNo()
        FillAvailableTables()
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        Cursor = Cursors.Default
        Timer2.Enabled = False
    End Sub

    Private Sub btnNewTicket_Click(sender As System.Object, e As System.EventArgs) Handles btnNewTicket.Click
        Reset()
    End Sub

    Private Sub btn1f_Click(sender As System.Object, e As System.EventArgs) Handles btn1f.Click
        If sign_Indicator = 0 Then
            txtCash.Text = txtCash.Text + Convert.ToString(1)
        ElseIf sign_Indicator = 1 Then
            txtCash.Text = Convert.ToString(1)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn2f_Click(sender As System.Object, e As System.EventArgs) Handles btn2f.Click
        If sign_Indicator = 0 Then
            txtCash.Text = txtCash.Text + Convert.ToString(2)
        ElseIf sign_Indicator = 1 Then
            txtCash.Text = Convert.ToString(2)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn3f_Click(sender As System.Object, e As System.EventArgs) Handles btn3f.Click
        If sign_Indicator = 0 Then
            txtCash.Text = txtCash.Text + Convert.ToString(3)
        ElseIf sign_Indicator = 1 Then
            txtCash.Text = Convert.ToString(3)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn4f_Click(sender As System.Object, e As System.EventArgs) Handles btn4f.Click
        If sign_Indicator = 0 Then
            txtCash.Text = txtCash.Text + Convert.ToString(4)
        ElseIf sign_Indicator = 1 Then
            txtCash.Text = Convert.ToString(4)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn5f_Click(sender As System.Object, e As System.EventArgs) Handles btn5f.Click
        If sign_Indicator = 0 Then
            txtCash.Text = txtCash.Text + Convert.ToString(5)
        ElseIf sign_Indicator = 1 Then
            txtCash.Text = Convert.ToString(5)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn6f_Click(sender As System.Object, e As System.EventArgs) Handles btn6f.Click
        If sign_Indicator = 0 Then
            txtCash.Text = txtCash.Text + Convert.ToString(6)
        ElseIf sign_Indicator = 1 Then
            txtCash.Text = Convert.ToString(6)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn7f_Click(sender As System.Object, e As System.EventArgs) Handles btn7f.Click
        If sign_Indicator = 0 Then
            txtCash.Text = txtCash.Text + Convert.ToString(7)
        ElseIf sign_Indicator = 1 Then
            txtCash.Text = Convert.ToString(7)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn8f_Click(sender As System.Object, e As System.EventArgs) Handles btn8f.Click
        If sign_Indicator = 0 Then
            txtCash.Text = txtCash.Text + Convert.ToString(8)
        ElseIf sign_Indicator = 1 Then
            txtCash.Text = Convert.ToString(8)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn9f_Click(sender As System.Object, e As System.EventArgs) Handles btn9f.Click
        If sign_Indicator = 0 Then
            txtCash.Text = txtCash.Text + Convert.ToString(9)
        ElseIf sign_Indicator = 1 Then
            txtCash.Text = Convert.ToString(9)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnDotf_Click(sender As System.Object, e As System.EventArgs) Handles btnDotf.Click
        Dim i As Integer = 0
        Dim chr As Char = ControlChars.NullChar
        Dim decimal_Indicator As Integer = 0
        Dim l As Integer = txtCash.Text.Length - 1
        If sign_Indicator <> 1 Then
            For i = 0 To l
                chr = txtCash.Text(i)
                If chr = "."c Then
                    decimal_Indicator = 1
                End If
            Next

            If decimal_Indicator <> 1 Then
                txtCash.Text = txtCash.Text + Convert.ToString(".")
            End If
        End If
    End Sub
    Sub Calc()
        Dim num As Double
        num = Val(txtCash.Text) - Val(txtGrandTotal.Text)
        num = Math.Round(num, 2)
        If num < 0 Then
            txtChange.Text = ""
        Else
            txtChange.Text = num
        End If
    End Sub
    Sub Calc1()
        Try
            Dim num, num1 As Double
            num1 = Val(txtParcelCharges.Text) + Val(txtSubTotal1.Text)
            num1 = Math.Round(num1, 2)
            txtGrandTotal1.Text = num1
            num = Val(txtCash1.Text) - Val(txtGrandTotal1.Text)
            num = Math.Round(num, 2)
            If num < 0 Then
                txtChange1.Text = ""
            Else
                txtChange1.Text = num
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Calc2()
        Try
            Dim num As Double
            num = Val(txtSubTotal.Text) + Val(txtDeliveryCharges.Text)
            num = Math.Round(num, 2)
            txtGrandTotal2.Text = num
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btn0f_Click(sender As System.Object, e As System.EventArgs) Handles btn0f.Click
        If sign_Indicator = 0 Then
            txtCash.Text = txtCash.Text + Convert.ToString(0)
        ElseIf sign_Indicator = 1 Then
            txtCash.Text = Convert.ToString(0)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnXf_Click(sender As System.Object, e As System.EventArgs) Handles btnXf.Click
        s = txtCash.Text
        Dim l As Integer = s.Length
        For i As Integer = 0 To l - 2
            x += s(i)
        Next
        txtCash.Text = x
        x = ""
    End Sub

    Private Sub btnSave1_Click(sender As System.Object, e As System.EventArgs) Handles btnSave1.Click
        Try
            If DataGridView2.Rows.Count = 0 Then
                MessageBox.Show("sorry no item added to datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If lblPaymentMode.Text = "" Then
                MessageBox.Show("Please select payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lblPaymentMode.Focus()
                Exit Sub
            End If
            If txtCash.Text = "" Then
                MessageBox.Show("Please enter cash", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCash.Focus()
                Exit Sub
            End If
            If Val(txtCash.Text) < Val(txtGrandTotal.Text) Then
                MessageBox.Show("cash can not be less than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into RestaurantPOS_BillingInfoKOT( Id,BillNo, BillDate, GrandTotal,Cash,Change,Operator,PaymentMode) Values (" & txtBillID.Text & ",'" & lblBillNo.Text & "',@d1," & txtGrandTotal.Text & "," & txtCash.Text & "," & txtChange.Text & ",@d2,@d3)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", System.DateTime.Now)
            cmd.Parameters.AddWithValue("@d2", lblUser.Text)
            cmd.Parameters.AddWithValue("@d3", lblPaymentMode.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into RestaurantPOS_OrderedProductBillKOT(BillID,TableNo,Dish,Rate,Quantity,Amount,DiscountPer, DiscountAmount, STPer, STAmount, VATPer, VATAmount,TotalAmount) VALUES (" & txtBillID.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value)
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(2).Value))
                    cmd.Parameters.AddWithValue("@d4", Val(row.Cells(3).Value))
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(4).Value))
                    cmd.Parameters.AddWithValue("@d6", Val(row.Cells(5).Value))
                    cmd.Parameters.AddWithValue("@d7", Val(row.Cells(6).Value))
                    cmd.Parameters.AddWithValue("@d8", Val(row.Cells(7).Value))
                    cmd.Parameters.AddWithValue("@d9", Val(row.Cells(8).Value))
                    cmd.Parameters.AddWithValue("@d10", Val(row.Cells(9).Value))
                    cmd.Parameters.AddWithValue("@d11", Val(row.Cells(10).Value))
                    cmd.Parameters.AddWithValue("@d12", Val(row.Cells(11).Value))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            Dim st As String = "added the new restaurant pos record having bill no. '" & lblBillNo.Text & "'"
            LogFunc(lblUser.Text, st)
            con = New SqlConnection(cs)
            con.Open()
            Dim cb4 As String = "Delete from TempRestaurantPOS_OrderInfoKOT where TableNo=@d1 and GroupName=@d2"
            cmd = New SqlCommand(cb4)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", row.Cells(12).Value)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            For Each row As DataGridViewRow In DataGridView2.Rows
                Dim ctx As String = "Select Count(TableNo) from TempRestaurantPOS_OrderInfoKOT where TableNo=@d1"
                cmd = New SqlCommand(ctx)
                cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    str2 = rdr.GetValue(0)
                    If Val(str2) <= 0 Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb5 As String = "Update R_Table set BkColor=@d1 where TableNo=@d2"
                        cmd = New SqlCommand(cb5)
                        cmd.Connection = con
                        ' Prepare command for repeated execution
                        cmd.Prepare()
                        ' Data to be inserted
                        cmd.Parameters.AddWithValue("@d1", Color.LightGreen.ToArgb())
                        cmd.Parameters.AddWithValue("@d2", row.Cells(0).Value)
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                End If
            Next
            con.Close()
            If lblPaymentMode.Text = "Cash" Then
                LedgerSave(System.DateTime.Now, "Cash Account", lblBillNo.Text, "Restaurant POS", 0, Val(txtGrandTotal.Text), "")
            End If
            If lblPaymentMode.Text = "Credit Card" Or lblPaymentMode.Text = "Debit Card" Then
                LedgerSave(System.DateTime.Now, "Bank Account", lblBillNo.Text, "Restaurant POS", 0, Val(txtGrandTotal.Text), "")
            End If
            btnSave1.Enabled = False
            Print1()
            fillTableNo()
            FillAvailableTables()
            Reset1()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Print1()
        Try
            Cursor = Cursors.WaitCursor
            Timer2.Enabled = True
            Dim rpt As New rptRestaurantPOSFinalBillKOTInvoice 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT RestaurantPOS_OrderedProductBillKOT.OP_ID,Operator,PaymentMode, RestaurantPOS_OrderedProductBillKOT.BillID, RestaurantPOS_OrderedProductBillKOT.Dish, RestaurantPOS_OrderedProductBillKOT.VATPer,RestaurantPOS_OrderedProductBillKOT.VATAmount, RestaurantPOS_OrderedProductBillKOT.STPer, RestaurantPOS_OrderedProductBillKOT.STAmount, RestaurantPOS_OrderedProductBillKOT.DiscountPer, RestaurantPOS_OrderedProductBillKOT.DiscountAmount,RestaurantPOS_OrderedProductBillKOT.Rate, RestaurantPOS_OrderedProductBillKOT.Quantity, RestaurantPOS_OrderedProductBillKOT.Amount, RestaurantPOS_OrderedProductBillKOT.TotalAmount,RestaurantPOS_BillingInfoKOT.ID, RestaurantPOS_BillingInfoKOT.BillNo,RestaurantPOS_OrderedProductBillKOT.TableNo, RestaurantPOS_BillingInfoKOT.BillDate, RestaurantPOS_BillingInfoKOT.GrandTotal,RestaurantPOS_BillingInfoKOT.Cash,RestaurantPOS_BillingInfoKOT.Change FROM RestaurantPOS_OrderedProductBillKOT INNER JOIN  RestaurantPOS_BillingInfoKOT ON RestaurantPOS_OrderedProductBillKOT.BillID = RestaurantPOS_BillingInfoKOT.ID where RestaurantPOS_BillingInfoKOT.ID=" & txtBillID.Text & ""
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "RestaurantPOS_BillingInfoKOT")
            myDA.Fill(myDS, "RestaurantPOS_OrderedProductBillKOT")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT PrinterName from POSPrinterSetting where PrinterType='Invoice Printer' and IsEnabled='Yes'"
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                s3 = rdr.GetValue(0)
                rpt.PrintOptions.PrinterName = s3
                rpt.PrintToPrinter(1, False, 0, 0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Print2Func1()
        Dim CN As New SqlConnection(cs)
        CN.Open()
        adp = New SqlDataAdapter()
        adp.SelectCommand = New SqlCommand("SELECT DISTINCT RTRIM(Kitchen.Kitchenname) FROM Dish INNER JOIN Kitchen ON Dish.Kitchen = Kitchen.Kitchenname INNER JOIN RestaurantPOS_OrderedProductBillTA ON Dish.DishName = RestaurantPOS_OrderedProductBillTA.Dish INNER JOIN RestaurantPOS_BillingInfoTA ON RestaurantPOS_OrderedProductBillTA.BillID = RestaurantPOS_BillingInfoTA.ID where BillNo='" & lblBillNo1.Text & "'", CN)
        ds = New DataSet("ds")
        adp.Fill(ds)
        Dim dtable As DataTable = ds.Tables(0)
        CBox.Items.Clear()
        For Each drow As DataRow In dtable.Rows
            CBox.Items.Add(drow(0).ToString())
        Next
        For Each item As String In CBox.Items
            Cursor = Cursors.WaitCursor
            Timer2.Enabled = True
            Dim rpt As New rptRestaurantPOSTAInvoice_Kitchen 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT distinct RestaurantPOS_OrderedProductBillTA.OP_ID,RestaurantPOS_OrderedProductBillTA.Notes,Operator,PaymentMode,ParcelCharges,SubTotal, RestaurantPOS_OrderedProductBillTA.BillID, RestaurantPOS_OrderedProductBillTA.Dish, RestaurantPOS_OrderedProductBillTA.VATPer,RestaurantPOS_OrderedProductBillTA.VATAmount, RestaurantPOS_OrderedProductBillTA.STPer, RestaurantPOS_OrderedProductBillTA.STAmount, RestaurantPOS_OrderedProductBillTA.DiscountPer, RestaurantPOS_OrderedProductBillTA.DiscountAmount,RestaurantPOS_OrderedProductBillTA.Rate, RestaurantPOS_OrderedProductBillTA.Quantity, RestaurantPOS_OrderedProductBillTA.Amount, RestaurantPOS_OrderedProductBillTA.TotalAmount,RestaurantPOS_BillingInfoTA.ID, RestaurantPOS_BillingInfoTA.BillNo, RestaurantPOS_BillingInfoTA.BillDate, RestaurantPOS_BillingInfoTA.GrandTotal,Cash,Change FROM Dish INNER JOIN Kitchen ON Dish.Kitchen = Kitchen.Kitchenname INNER JOIN RestaurantPOS_OrderedProductBillTA ON Dish.DishName = RestaurantPOS_OrderedProductBillTA.Dish INNER JOIN RestaurantPOS_BillingInfoTA ON RestaurantPOS_OrderedProductBillTA.BillID = RestaurantPOS_BillingInfoTA.ID where BillNo='" & lblBillNo1.Text & "' and KitchenName=@d1"
            MyCommand.Parameters.AddWithValue("@d1", item)
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "RestaurantPOS_BillingInfoTA")
            myDA.Fill(myDS, "Dish")
            myDA.Fill(myDS, "Kitchen")
            myDA.Fill(myDS, "RestaurantPOS_OrderedProductBillTA")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT Printer from Kitchen where KitchenName=@d1 and IsEnabled='Yes'"
            cmd.Parameters.AddWithValue("@d1", item)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                s1 = rdr.GetValue(0)
                rpt.PrintOptions.PrinterName = s1
                rpt.PrintToPrinter(1, False, 0, 0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Next
    End Sub
    Sub Print2Func2()
        Cursor = Cursors.WaitCursor
        Timer2.Enabled = True
        Dim rpt As New rptRestaurantPOSTAInvoice 'The report you created.
        Dim myConnection As SqlConnection
        Dim MyCommand, MyCommand1 As New SqlCommand()
        Dim myDA, myDA1 As New SqlDataAdapter()
        Dim myDS As New DataSet 'The DataSet you created.
        myConnection = New SqlConnection(cs)
        MyCommand.Connection = myConnection
        MyCommand1.Connection = myConnection
        MyCommand.CommandText = "SELECT RestaurantPOS_OrderedProductBillTA.OP_ID,Operator,Notes,PaymentMode,ParcelCharges,SubTotal, RestaurantPOS_OrderedProductBillTA.BillID, RestaurantPOS_OrderedProductBillTA.Dish, RestaurantPOS_OrderedProductBillTA.VATPer,RestaurantPOS_OrderedProductBillTA.VATAmount, RestaurantPOS_OrderedProductBillTA.STPer, RestaurantPOS_OrderedProductBillTA.STAmount, RestaurantPOS_OrderedProductBillTA.DiscountPer, RestaurantPOS_OrderedProductBillTA.DiscountAmount,RestaurantPOS_OrderedProductBillTA.Rate, RestaurantPOS_OrderedProductBillTA.Quantity, RestaurantPOS_OrderedProductBillTA.Amount, RestaurantPOS_OrderedProductBillTA.TotalAmount,RestaurantPOS_BillingInfoTA.ID, RestaurantPOS_BillingInfoTA.BillNo, RestaurantPOS_BillingInfoTA.BillDate, RestaurantPOS_BillingInfoTA.GrandTotal,RestaurantPOS_BillingInfoTA.Cash,RestaurantPOS_BillingInfoTA.Change FROM RestaurantPOS_OrderedProductBillTA INNER JOIN  RestaurantPOS_BillingInfoTA ON RestaurantPOS_OrderedProductBillTA.BillID = RestaurantPOS_BillingInfoTA.ID where RestaurantPOS_BillingInfoTA.ID=" & txtBillID1.Text & ""
        MyCommand1.CommandText = "SELECT * from Hotel"
        MyCommand.CommandType = CommandType.Text
        MyCommand1.CommandType = CommandType.Text
        myDA.SelectCommand = MyCommand
        myDA1.SelectCommand = MyCommand1
        myDA.Fill(myDS, "RestaurantPOS_BillingInfoTA")
        myDA.Fill(myDS, "RestaurantPOS_OrderedProductBillTA")
        myDA1.Fill(myDS, "Hotel")
        rpt.SetDataSource(myDS)
        con = New SqlConnection(cs)
        con.Open()
        cmd = con.CreateCommand()
        cmd.CommandText = "SELECT PrinterName from POSPrinterSetting where PrinterType='Invoice Printer' and IsEnabled='Yes'"
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
            s2 = rdr.GetValue(0)
            rpt.PrintOptions.PrinterName = s2
            rpt.PrintToPrinter(1, False, 0, 0)
        End If
        If (rdr IsNot Nothing) Then
            rdr.Close()
        End If
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub
    Sub Print2()
        Try
            Print2Func1()
            Print2Func2()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Print3Func1()
        Dim CN As New SqlConnection(cs)
        CN.Open()
        adp = New SqlDataAdapter()
        adp.SelectCommand = New SqlCommand("SELECT DISTINCT RTRIM(Kitchen.Kitchenname) FROM Dish INNER JOIN Kitchen ON Dish.Kitchen = Kitchen.Kitchenname INNER JOIN RestaurantPOS_OrderedProductBillHD ON Dish.DishName = RestaurantPOS_OrderedProductBillHD.Dish INNER JOIN RestaurantPOS_BillingInfoHD ON RestaurantPOS_OrderedProductBillHD.BillID = RestaurantPOS_BillingInfoHD.ID where BillNo='" & lblBillNo2.Text & "'", CN)
        ds = New DataSet("ds")
        adp.Fill(ds)
        Dim dtable As DataTable = ds.Tables(0)
        CBox.Items.Clear()
        For Each drow As DataRow In dtable.Rows
            CBox.Items.Add(drow(0).ToString())
        Next
        For Each item As String In CBox.Items
            Cursor = Cursors.WaitCursor
            Timer2.Enabled = True
            Dim rpt As New rptRestaurantPOSHDInvoice_Kitchen 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT RestaurantPOS_BillingInfoHD.Id, RestaurantPOS_BillingInfoHD.BillNo, RestaurantPOS_BillingInfoHD.BillDate, RestaurantPOS_BillingInfoHD.Operator, RestaurantPOS_BillingInfoHD.SubTotal,RestaurantPOS_BillingInfoHD.HomeDeliveryCharges, RestaurantPOS_BillingInfoHD.GrandTotal, RestaurantPOS_BillingInfoHD.CustomerName, RestaurantPOS_BillingInfoHD.Address,RestaurantPOS_BillingInfoHD.ContactNo, RestaurantPOS_BillingInfoHD.Employee_ID, RestaurantPOS_BillingInfoHD.PaymentMode, RestaurantPOS_OrderedProductBillHD.OP_ID,RestaurantPOS_OrderedProductBillHD.BillID, RestaurantPOS_OrderedProductBillHD.Dish, RestaurantPOS_OrderedProductBillHD.Rate, RestaurantPOS_OrderedProductBillHD.Quantity, RestaurantPOS_OrderedProductBillHD.Amount, RestaurantPOS_OrderedProductBillHD.VATPer, RestaurantPOS_OrderedProductBillHD.VATAmount, RestaurantPOS_OrderedProductBillHD.STPer, RestaurantPOS_OrderedProductBillHD.STAmount, RestaurantPOS_OrderedProductBillHD.DiscountPer, RestaurantPOS_OrderedProductBillHD.DiscountAmount, RestaurantPOS_OrderedProductBillHD.TotalAmount, RestaurantPOS_OrderedProductBillHD.Notes, DeliveryPerson.EmpId, DeliveryPerson.EmployeeID, DeliveryPerson.EmployeeName,DeliveryPerson.Address AS Expr1, DeliveryPerson.City, DeliveryPerson.ContactNo AS Expr2, DeliveryPerson.Email, DeliveryPerson.DateOfJoining, DeliveryPerson.Photo,DeliveryPerson.Active, Dish.DishName, Dish.Category, Dish.Rate AS Expr3, Dish.Discount, Dish.BackColor, Dish.Kitchen, Kitchen.Kitchenname, Kitchen.Printer, Kitchen.IsEnabled FROM RestaurantPOS_BillingInfoHD INNER JOIN RestaurantPOS_OrderedProductBillHD ON RestaurantPOS_BillingInfoHD.Id = RestaurantPOS_OrderedProductBillHD.BillID INNER JOIN DeliveryPerson ON RestaurantPOS_BillingInfoHD.Employee_ID = DeliveryPerson.EmpId INNER JOIN Dish ON RestaurantPOS_OrderedProductBillHD.Dish = Dish.DishName INNER JOIN Kitchen ON Dish.Kitchen = Kitchen.Kitchenname where BillNo='" & lblBillNo2.Text & "' and KitchenName=@d1"
            MyCommand.Parameters.AddWithValue("@d1", item)
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "RestaurantPOS_BillingInfoHD")
            myDA.Fill(myDS, "Dish")
            myDA.Fill(myDS, "Kitchen")
            myDA.Fill(myDS, "RestaurantPOS_OrderedProductBillHD")
            myDA.Fill(myDS, "DeliveryPerson")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT Printer from Kitchen where KitchenName=@d1 and IsEnabled='Yes'"
            cmd.Parameters.AddWithValue("@d1", item)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                s1 = rdr.GetValue(0)
                rpt.PrintOptions.PrinterName = s1
                rpt.PrintToPrinter(1, False, 0, 0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Next
    End Sub
    Sub Print3Func2()
        Cursor = Cursors.WaitCursor
        Timer2.Enabled = True
        Dim rpt As New rptRestaurantPOSHDInvoice 'The report you created.
        Dim myConnection As SqlConnection
        Dim MyCommand, MyCommand1 As New SqlCommand()
        Dim myDA, myDA1 As New SqlDataAdapter()
        Dim myDS As New DataSet 'The DataSet you created.
        myConnection = New SqlConnection(cs)
        MyCommand.Connection = myConnection
        MyCommand1.Connection = myConnection
        MyCommand.CommandText = "SELECT RestaurantPOS_BillingInfoHD.Id, RestaurantPOS_BillingInfoHD.BillNo, RestaurantPOS_BillingInfoHD.BillDate, RestaurantPOS_BillingInfoHD.Operator, RestaurantPOS_BillingInfoHD.SubTotal,RestaurantPOS_BillingInfoHD.HomeDeliveryCharges, RestaurantPOS_BillingInfoHD.GrandTotal, RestaurantPOS_BillingInfoHD.CustomerName, RestaurantPOS_BillingInfoHD.Address,RestaurantPOS_BillingInfoHD.ContactNo, RestaurantPOS_BillingInfoHD.Employee_ID, RestaurantPOS_BillingInfoHD.PaymentMode, RestaurantPOS_OrderedProductBillHD.OP_ID,RestaurantPOS_OrderedProductBillHD.BillID, RestaurantPOS_OrderedProductBillHD.Dish, RestaurantPOS_OrderedProductBillHD.Rate, RestaurantPOS_OrderedProductBillHD.Quantity, RestaurantPOS_OrderedProductBillHD.Amount, RestaurantPOS_OrderedProductBillHD.VATPer, RestaurantPOS_OrderedProductBillHD.VATAmount, RestaurantPOS_OrderedProductBillHD.STPer, RestaurantPOS_OrderedProductBillHD.STAmount, RestaurantPOS_OrderedProductBillHD.DiscountPer, RestaurantPOS_OrderedProductBillHD.DiscountAmount, RestaurantPOS_OrderedProductBillHD.TotalAmount, RestaurantPOS_OrderedProductBillHD.Notes, DeliveryPerson.EmpId, DeliveryPerson.EmployeeID, DeliveryPerson.EmployeeName,DeliveryPerson.Address AS Expr1, DeliveryPerson.City, DeliveryPerson.ContactNo AS Expr2, DeliveryPerson.Email, DeliveryPerson.DateOfJoining,DeliveryPerson.Active, Dish.DishName, Dish.Category, Dish.Rate AS Expr3, Dish.Discount, Dish.BackColor, Dish.Kitchen, Kitchen.Kitchenname, Kitchen.Printer, Kitchen.IsEnabled FROM RestaurantPOS_BillingInfoHD INNER JOIN RestaurantPOS_OrderedProductBillHD ON RestaurantPOS_BillingInfoHD.Id = RestaurantPOS_OrderedProductBillHD.BillID INNER JOIN DeliveryPerson ON RestaurantPOS_BillingInfoHD.Employee_ID = DeliveryPerson.EmpId INNER JOIN Dish ON RestaurantPOS_OrderedProductBillHD.Dish = Dish.DishName INNER JOIN Kitchen ON Dish.Kitchen = Kitchen.Kitchenname where RestaurantPOS_BillingInfoHD.ID=" & txtBillID2.Text & ""
        MyCommand1.CommandText = "SELECT * from Hotel"
        MyCommand.CommandType = CommandType.Text
        MyCommand1.CommandType = CommandType.Text
        myDA.SelectCommand = MyCommand
        myDA1.SelectCommand = MyCommand1
        myDA.Fill(myDS, "RestaurantPOS_BillingInfoHD")
        myDA.Fill(myDS, "RestaurantPOS_OrderedProductBillHD")
        myDA.Fill(myDS, "DeliveryPerson")
        myDA1.Fill(myDS, "Hotel")
        rpt.SetDataSource(myDS)
        con = New SqlConnection(cs)
        con.Open()
        cmd = con.CreateCommand()
        cmd.CommandText = "SELECT PrinterName from POSPrinterSetting where PrinterType='Invoice Printer' and IsEnabled='Yes'"
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
            s2 = rdr.GetValue(0)
            rpt.PrintOptions.PrinterName = s2
            rpt.PrintToPrinter(1, False, 0, 0)
        End If
        If (rdr IsNot Nothing) Then
            rdr.Close()
        End If
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub
    Sub Print3()
        Try
            Print3Func1()
            Print3Func2()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnNew1_Click(sender As System.Object, e As System.EventArgs) Handles btnNew1.Click
        Reset1()
    End Sub

    Public Function GrandTotal_Food1() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                sum = sum + r.Cells(11).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function

    Private Sub lvTable_ItemChecked(sender As System.Object, e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvTable.ItemChecked
        Try

            If lvTable.CheckedItems.Count > 0 Then
                Dim Condition As String = ""
                Dim Condition1 As String = ""
                For I = 0 To lvTable.CheckedItems.Count - 1

                    Condition += String.Format("'{0}',", lvTable.CheckedItems(I).Text)
                    Condition1 += String.Format("'{0}',", lvTable.checkedItems(I).SubItems(1).Text)
                Next
                Condition = Condition.Substring(0, Condition.Length - 1)
                Condition1 = Condition1.Substring(0, Condition1.Length - 1)
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "Select RTRIM(TableNo),RTRIM(Dish),(Rate),Sum(Quantity),Sum(Amount),(DiscountPer), Sum(DiscountAmount), RTRIM(STPer), Sum(STAmount), RTRIM(VATPer), Sum(VATAmount),Sum(TotalAmount),RTRIM(GroupName) from TempRestaurantPOS_OrderedProductKOT,TempRestaurantPOS_OrderInfoKOT where TempRestaurantPOS_OrderedProductKOT.TicketID=TempRestaurantPOS_OrderInfoKOT.ID and TableNo in (" & Condition & ") and GroupName in (" & Condition1 & ")   group by TableNo,Dish,Rate,DiscountPer,STPer,VATPer,GroupName order by TableNo"
                cmd = New SqlCommand(sql, con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                DataGridView2.Rows.Clear()
                While (rdr.Read() = True)
                    DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12))
                End While
                con.Close()
                txtGrandTotal.Text = GrandTotal_Food1()
                Calc()
            Else
                txtGrandTotal.Text = ""
                DataGridView2.Rows.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TabControl1_Click(sender As System.Object, e As System.EventArgs) Handles TabControl1.Click
        auto()
        auto1()
        auto2()
        auto3()
    End Sub

    Private Sub txtCash_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCash.TextChanged
        Calc()
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint1.Click
        Print1()
    End Sub
    Sub OSKeyboard()
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
    Private Sub btnDelete1_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete1.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord1()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGetData1_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData1.Click
        frmRestaurantPOSKOTFinalBillRecord.Reset()
        frmRestaurantPOSKOTFinalBillRecord.ShowDialog()
    End Sub

    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        frmRestaurantPOSKOTRecord.Reset()
        frmRestaurantPOSKOTRecord.ShowDialog()
    End Sub

    Private Sub btnNotes_Click(sender As System.Object, e As System.EventArgs) Handles btnNotes.Click
        frmNotes.lblSet.Text = "KOT"
        frmNotes.Reset()
        frmNotes.ShowDialog()
    End Sub

    Private Sub btnKeyboard_Click(sender As System.Object, e As System.EventArgs) Handles btnKeyboard.Click
        OSKeyboard()
    End Sub
    Private Sub btnPrint_Click_1(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Print()
    End Sub

    Private Sub btnChangeTable_Click(sender As System.Object, e As System.EventArgs) Handles btnChangeTable.Click
        Try
            If lblTableNo.Text = "" Then
                MessageBox.Show("Please select table", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select TableNo from R_Table where TableNo=@d1 and BkColor=@d2"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", lblTableNo.Text)
            cmd.Parameters.AddWithValue("@d2", Color.LightGreen.ToArgb())
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                MessageBox.Show("Please select only booked table", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                lblTableNo.Text = ""
                Return
            End If
            frmAvailableTables.lblTable.Text = lblTableNo.Text.Trim()
            frmAvailableTables.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCash_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCash.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtCash.Text
            Dim selectionStart = Me.txtCash.SelectionStart
            Dim selectionLength = Me.txtCash.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub btnPlus1_Click(sender As System.Object, e As System.EventArgs) Handles btnPlus1.Click
        Try
            For Each r As DataGridViewRow In Me.DataGridView3.SelectedRows
                FillData1()
                Compute()
                r.Cells(0).Value = r.Cells(0).Value
                r.Cells(1).Value = txtRate_Food.Text
                r.Cells(2).Value = Val(r.Cells(2).Value) + 1
                r.Cells(3).Value = Val(r.Cells(3).Value) + Val(txtAmt_Food.Text)
                r.Cells(4).Value = Val(txtDiscountPer_Food.Text)
                r.Cells(5).Value = Val(r.Cells(5).Value) + Val(txtDiscountAmount_Food.Text)
                r.Cells(6).Value = Val(txtServiceTaxPer_Food.Text)
                r.Cells(7).Value = Val(r.Cells(7).Value) + Val(txtServiceTaxAmount_Food.Text)
                r.Cells(8).Value = Val(txtVATPer_Food.Text)
                r.Cells(9).Value = Val(r.Cells(9).Value) + Val(txtVATAmt_Food.Text)
                r.Cells(10).Value = Val(r.Cells(10).Value) + Val(txtTotalAmt_Food.Text)
                Dim i As Double = 0
                i = GrandTotal_Food2()
                i = Math.Round(i, 2)
                lblBalance1.Text = i
                txtSubTotal1.Text = i
                Clear1()
                If r.Cells(2).Value > 1 Then
                    btnMinus1.Enabled = True
                Else
                    btnMinus1.Enabled = False
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnMinus1_Click(sender As System.Object, e As System.EventArgs) Handles btnMinus1.Click
        Try
            For Each r As DataGridViewRow In Me.DataGridView3.SelectedRows
                FillData1()
                If r.Cells(2).Value = 1 Then
                    btnMinus1.Enabled = False
                    Exit Sub
                End If
                Compute()
                r.Cells(0).Value = r.Cells(0).Value
                r.Cells(1).Value = txtRate_Food.Text
                r.Cells(2).Value = Val(r.Cells(2).Value) - 1
                r.Cells(3).Value = Val(r.Cells(3).Value) - Val(txtAmt_Food.Text)
                r.Cells(4).Value = Val(txtDiscountPer_Food.Text)
                r.Cells(5).Value = Val(r.Cells(5).Value) - Val(txtDiscountAmount_Food.Text)
                r.Cells(6).Value = Val(txtServiceTaxPer_Food.Text)
                r.Cells(7).Value = Val(r.Cells(7).Value) - Val(txtServiceTaxAmount_Food.Text)
                r.Cells(8).Value = Val(txtVATPer_Food.Text)
                r.Cells(9).Value = Val(r.Cells(9).Value) - Val(txtVATAmt_Food.Text)
                r.Cells(10).Value = Val(r.Cells(10).Value) - Val(txtTotalAmt_Food.Text)
                Dim i As Double = 0
                i = GrandTotal_Food2()
                i = Math.Round(i, 2)
                lblBalance1.Text = i
                txtSubTotal1.Text = i
                Clear1()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnCancel1_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel1.Click
        Try
            For Each row As DataGridViewRow In DataGridView3.SelectedRows
                DataGridView3.Rows.Remove(row)
            Next
            Dim k As Double = 0
            k = GrandTotal_Food2()
            k = Math.Round(k, 2)
            lblBalance1.Text = k
            txtSubTotal1.Text = k
            Compute()
            Clear2()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave2_Click(sender As System.Object, e As System.EventArgs) Handles btnSave2.Click
        Try
            If DataGridView3.Rows.Count = 0 Then
                MessageBox.Show("sorry no item added to datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If lblPaymentMode1.Text = "" Then
                MessageBox.Show("Please select payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lblPaymentMode1.Focus()
                Exit Sub
            End If
            If txtParcelCharges.Text = "" Then
                MessageBox.Show("Please enter parcel charges", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtParcelCharges.Focus()
                Exit Sub
            End If
            If txtCash1.Text = "" Then
                MessageBox.Show("Please enter cash", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCash1.Focus()
                Exit Sub
            End If
            If Val(txtGrandTotal1.Text) > Val(txtCash1.Text) Then
                MessageBox.Show("cash can not be less than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Settle1()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into RestaurantPOS_BillingInfoTA( Id,BillNo, BillDate, GrandTotal,Cash,Change,Operator,SubTotal,ParcelCharges,PaymentMode) Values (" & txtBillID1.Text & ",'" & lblBillNo1.Text & "',@d1," & txtGrandTotal1.Text & "," & txtCash1.Text & "," & txtChange1.Text & ",@d2," & txtSubTotal1.Text & "," & txtParcelCharges.Text & ",@d3)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", System.DateTime.Now)
            cmd.Parameters.AddWithValue("@d2", lblUser.Text)
            cmd.Parameters.AddWithValue("@d3", lblPaymentMode1.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into RestaurantPOS_OrderedProductBillTA(BillID,Dish,Rate,Quantity,Amount,DiscountPer, DiscountAmount, STPer, STAmount, VATPer, VATAmount,TotalAmount,Notes) VALUES (" & txtBillID1.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView3.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(2).Value))
                    cmd.Parameters.AddWithValue("@d4", Val(row.Cells(3).Value))
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(4).Value))
                    cmd.Parameters.AddWithValue("@d6", Val(row.Cells(5).Value))
                    cmd.Parameters.AddWithValue("@d7", Val(row.Cells(6).Value))
                    cmd.Parameters.AddWithValue("@d8", Val(row.Cells(7).Value))
                    cmd.Parameters.AddWithValue("@d9", Val(row.Cells(8).Value))
                    cmd.Parameters.AddWithValue("@d10", Val(row.Cells(9).Value))
                    cmd.Parameters.AddWithValue("@d11", Val(row.Cells(10).Value))
                    If row.Cells(11).Value = "" Then
                        cmd.Parameters.AddWithValue("@d12", "")
                    Else
                        cmd.Parameters.AddWithValue("@d12", row.Cells(11).Value)
                    End If
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            Dim st As String = "added the new restaurant pos(Takeaway) record having bill no. '" & lblBillNo1.Text & "'"
            LogFunc(lblUser.Text, st)
            con.Close()
            If lblPaymentMode1.Text = "Cash" Then
                LedgerSave(System.DateTime.Now, "Cash Account", lblBillNo1.Text, "Restaurant POS(Takeaway)", 0, Val(txtGrandTotal1.Text), "")
            End If
            If lblPaymentMode1.Text = "Credit Card" Or lblPaymentMode1.Text = "Debit Card" Then
                LedgerSave(System.DateTime.Now, "Bank Account", lblBillNo1.Text, "Restaurant POS(Takeaway)", 0, Val(txtGrandTotal1.Text), "")
            End If
            btnSave2.Enabled = False
            Print2()
            Reset2()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNotes1_Click(sender As System.Object, e As System.EventArgs) Handles btnNotes1.Click
        frmNotes.lblSet.Text = "TA"
        frmNotes.Reset()
        frmNotes.ShowDialog()
    End Sub

    Private Sub btnSettle1_Click(sender As System.Object, e As System.EventArgs) Handles btnSettle1.Click
        Try
            If DataGridView3.Rows.Count = 0 Then
                MessageBox.Show("sorry no item added to datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Settle1()
            flpCategoriesTA.Enabled = False
            flpItemsTA.Enabled = False
            lblSet.Text = "Not Allowed"
            DataGridView3.ClearSelection()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnKeyboard1_Click(sender As System.Object, e As System.EventArgs) Handles btnKeyboard1.Click
        OSKeyboard()
    End Sub

    Private Sub DataGridView3_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView3.MouseClick
        If DataGridView3.Rows.Count > 0 Then
            If lblSet.Text = "Not Allowed" Then
                btnPlus1.Enabled = False
                btnCancel1.Enabled = False
                btnChangeRate1.Enabled = False
                btnMinus1.Enabled = False
                btnNotes1.Enabled = False
                btnChangeQty1.Enabled = False
            Else
                For Each row As DataGridViewRow In DataGridView3.SelectedRows
                    btnPlus1.Enabled = True
                    btnCancel1.Enabled = True
                    btnChangeRate1.Enabled = True
                    btnNotes1.Enabled = True
                    btnChangeQty1.Enabled = True
                    If row.Cells(2).Value > 1 Then
                        btnMinus1.Enabled = True
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub btnNewBill2_Click(sender As System.Object, e As System.EventArgs) Handles btnNewBill2.Click
        Reset2()
    End Sub

    Private Sub btnDelete2_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete2.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord2()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGetData2_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData2.Click
        frmRestaurantPOSTARecord.Reset()
        frmRestaurantPOSTARecord.ShowDialog()
    End Sub

    Private Sub btnTA1_Click(sender As System.Object, e As System.EventArgs) Handles btnTA1.Click
        If sign_Indicator = 0 Then
            txtCash1.Text = txtCash1.Text + Convert.ToString(1)
        ElseIf sign_Indicator = 1 Then
            txtCash1.Text = Convert.ToString(1)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA2_Click(sender As System.Object, e As System.EventArgs) Handles btnTA2.Click
        If sign_Indicator = 0 Then
            txtCash1.Text = txtCash1.Text + Convert.ToString(2)
        ElseIf sign_Indicator = 1 Then
            txtCash1.Text = Convert.ToString(2)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA3_Click(sender As System.Object, e As System.EventArgs) Handles btnTA3.Click
        If sign_Indicator = 0 Then
            txtCash1.Text = txtCash1.Text + Convert.ToString(3)
        ElseIf sign_Indicator = 1 Then
            txtCash1.Text = Convert.ToString(3)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA4_Click(sender As System.Object, e As System.EventArgs) Handles btnTA4.Click
        If sign_Indicator = 0 Then
            txtCash1.Text = txtCash1.Text + Convert.ToString(4)
        ElseIf sign_Indicator = 1 Then
            txtCash1.Text = Convert.ToString(4)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA5_Click(sender As System.Object, e As System.EventArgs) Handles btnTA5.Click
        If sign_Indicator = 0 Then
            txtCash1.Text = txtCash1.Text + Convert.ToString(5)
        ElseIf sign_Indicator = 1 Then
            txtCash1.Text = Convert.ToString(5)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA6_Click(sender As System.Object, e As System.EventArgs) Handles btnTA6.Click
        If sign_Indicator = 0 Then
            txtCash1.Text = txtCash1.Text + Convert.ToString(6)
        ElseIf sign_Indicator = 1 Then
            txtCash1.Text = Convert.ToString(6)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA7_Click(sender As System.Object, e As System.EventArgs) Handles btnTA7.Click
        If sign_Indicator = 0 Then
            txtCash1.Text = txtCash1.Text + Convert.ToString(7)
        ElseIf sign_Indicator = 1 Then
            txtCash1.Text = Convert.ToString(7)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA8_Click(sender As System.Object, e As System.EventArgs) Handles btnTA8.Click
        If sign_Indicator = 0 Then
            txtCash1.Text = txtCash1.Text + Convert.ToString(8)
        ElseIf sign_Indicator = 1 Then
            txtCash1.Text = Convert.ToString(8)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA9_Click(sender As System.Object, e As System.EventArgs) Handles btnTA9.Click
        If sign_Indicator = 0 Then
            txtCash1.Text = txtCash1.Text + Convert.ToString(9)
        ElseIf sign_Indicator = 1 Then
            txtCash1.Text = Convert.ToString(9)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTAComma_Click(sender As System.Object, e As System.EventArgs) Handles btnTAComma.Click
        Dim i As Integer = 0
        Dim chr As Char = ControlChars.NullChar
        Dim decimal_Indicator As Integer = 0
        Dim l As Integer = txtCash1.Text.Length - 1
        If sign_Indicator <> 1 Then
            For i = 0 To l
                chr = txtCash1.Text(i)
                If chr = "."c Then
                    decimal_Indicator = 1
                End If
            Next

            If decimal_Indicator <> 1 Then
                txtCash1.Text = txtCash1.Text + Convert.ToString(".")
            End If
        End If
    End Sub

    Private Sub btnTA0_Click(sender As System.Object, e As System.EventArgs) Handles btnTA0.Click
        If sign_Indicator = 0 Then
            txtCash1.Text = txtCash1.Text + Convert.ToString(0)
        ElseIf sign_Indicator = 1 Then
            txtCash1.Text = Convert.ToString(0)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTAx_Click(sender As System.Object, e As System.EventArgs) Handles btnTAx.Click
        s = txtCash1.Text
        Dim l As Integer = s.Length
        For i As Integer = 0 To l - 2
            x += s(i)
        Next
        txtCash1.Text = x
        x = ""
    End Sub

    Private Sub btnHD1_Click(sender As System.Object, e As System.EventArgs) Handles btnHD1.Click
        If sign_Indicator = 0 Then
            txtDeliveryCharges.Text = txtDeliveryCharges.Text + Convert.ToString(1)
        ElseIf sign_Indicator = 1 Then
            txtDeliveryCharges.Text = Convert.ToString(1)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnHD2_Click(sender As System.Object, e As System.EventArgs) Handles btnHD2.Click
        If sign_Indicator = 0 Then
            txtDeliveryCharges.Text = txtDeliveryCharges.Text + Convert.ToString(2)
        ElseIf sign_Indicator = 1 Then
            txtDeliveryCharges.Text = Convert.ToString(2)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnHD3_Click(sender As System.Object, e As System.EventArgs) Handles btnHD3.Click
        If sign_Indicator = 0 Then
            txtDeliveryCharges.Text = txtDeliveryCharges.Text + Convert.ToString(3)
        ElseIf sign_Indicator = 1 Then
            txtDeliveryCharges.Text = Convert.ToString(3)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnHD4_Click(sender As System.Object, e As System.EventArgs) Handles btnHD4.Click
        If sign_Indicator = 0 Then
            txtDeliveryCharges.Text = txtDeliveryCharges.Text + Convert.ToString(4)
        ElseIf sign_Indicator = 1 Then
            txtDeliveryCharges.Text = Convert.ToString(4)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnHD5_Click(sender As System.Object, e As System.EventArgs) Handles btnHD5.Click
        If sign_Indicator = 0 Then
            txtDeliveryCharges.Text = txtDeliveryCharges.Text + Convert.ToString(5)
        ElseIf sign_Indicator = 1 Then
            txtDeliveryCharges.Text = Convert.ToString(5)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnHD6_Click(sender As System.Object, e As System.EventArgs) Handles btnHD6.Click
        If sign_Indicator = 0 Then
            txtDeliveryCharges.Text = txtDeliveryCharges.Text + Convert.ToString(6)
        ElseIf sign_Indicator = 1 Then
            txtDeliveryCharges.Text = Convert.ToString(6)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnHD7_Click(sender As System.Object, e As System.EventArgs) Handles btnHD7.Click
        If sign_Indicator = 0 Then
            txtDeliveryCharges.Text = txtDeliveryCharges.Text + Convert.ToString(7)
        ElseIf sign_Indicator = 1 Then
            txtDeliveryCharges.Text = Convert.ToString(7)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnHD8_Click(sender As System.Object, e As System.EventArgs) Handles btnHD8.Click
        If sign_Indicator = 0 Then
            txtDeliveryCharges.Text = txtDeliveryCharges.Text + Convert.ToString(8)
        ElseIf sign_Indicator = 1 Then
            txtDeliveryCharges.Text = Convert.ToString(8)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnHD9_Click(sender As System.Object, e As System.EventArgs) Handles btnHD9.Click
        If sign_Indicator = 0 Then
            txtDeliveryCharges.Text = txtDeliveryCharges.Text + Convert.ToString(9)
        ElseIf sign_Indicator = 1 Then
            txtDeliveryCharges.Text = Convert.ToString(9)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnHDComma_Click(sender As System.Object, e As System.EventArgs) Handles btnHDComma.Click
        Dim i As Integer = 0
        Dim chr As Char = ControlChars.NullChar
        Dim decimal_Indicator As Integer = 0
        Dim l As Integer = txtDeliveryCharges.Text.Length - 1
        If sign_Indicator <> 1 Then
            For i = 0 To l
                chr = txtDeliveryCharges.Text(i)
                If chr = "."c Then
                    decimal_Indicator = 1
                End If
            Next

            If decimal_Indicator <> 1 Then
                txtDeliveryCharges.Text = txtDeliveryCharges.Text + Convert.ToString(".")
            End If
        End If
    End Sub

    Private Sub btnHD0_Click(sender As System.Object, e As System.EventArgs) Handles btnHD0.Click
        If sign_Indicator = 0 Then
            txtDeliveryCharges.Text = txtDeliveryCharges.Text + Convert.ToString(0)
        ElseIf sign_Indicator = 1 Then
            txtDeliveryCharges.Text = Convert.ToString(0)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnHDx_Click(sender As System.Object, e As System.EventArgs) Handles btnHDx.Click
        s = txtDeliveryCharges.Text
        Dim l As Integer = s.Length
        For i As Integer = 0 To l - 2
            x += s(i)
        Next
        txtDeliveryCharges.Text = x
        x = ""
    End Sub

    Private Sub btnNotes2_Click(sender As System.Object, e As System.EventArgs) Handles btnNotes2.Click
        frmNotes.lblSet.Text = "HD"
        frmNotes.Reset()
        frmNotes.ShowDialog()
    End Sub

    Private Sub btnKeyboard3_Click(sender As System.Object, e As System.EventArgs) Handles btnKeyboard3.Click
        OSKeyboard()
    End Sub

    Private Sub btnDelete3_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete3.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord3()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGetData3_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData3.Click
        frmRestaurantPOSHDRecord.Reset()
        frmRestaurantPOSHDRecord.ShowDialog()
    End Sub

    Private Sub btnNewBill3_Click(sender As System.Object, e As System.EventArgs) Handles btnNewBill3.Click
        Reset3()
    End Sub

    Private Sub btnSave3_Click(sender As System.Object, e As System.EventArgs) Handles btnSave3.Click
        Try
            If DataGridView4.Rows.Count = 0 Then
                MessageBox.Show("sorry no item added to datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If txtCustomerName.Text = "" Then
                MessageBox.Show("Please enter customer name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCustomerName.Focus()
                Exit Sub
            End If
            If txtAddress.Text = "" Then
                MessageBox.Show("Please enter address", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAddress.Focus()
                Exit Sub
            End If
            If txtContactNo.Text = "" Then
                MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtContactNo.Focus()
                Exit Sub
            End If
            If lblPaymentMode2.Text = "" Then
                MessageBox.Show("Please select payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lblPaymentMode2.Focus()
                Exit Sub
            End If
            If txtDeliveryPerson.Text = "" Then
                MessageBox.Show("Please retrieve delivery person", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtDeliveryPerson.Focus()
                Exit Sub
            End If
            If txtDeliveryCharges.Text = "" Then
                MessageBox.Show("Please enter delivery charges", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtDeliveryCharges.Focus()
                Exit Sub
            End If
            Settle2()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into RestaurantPOS_BillingInfoHD( Id,BillNo, BillDate,SubTotal,HomeDeliveryCharges, GrandTotal,Operator,CustomerName,Address,ContactNo,PaymentMode,Employee_ID) Values (" & txtBillID2.Text & ",'" & lblBillNo2.Text & "',@d1," & txtSubTotal.Text & "," & txtDeliveryCharges.Text & "," & txtGrandTotal2.Text & ",@d2,@d3,@d4,@d5,@d6," & txtDeliveryPersonID.Text & ")"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", System.DateTime.Now)
            cmd.Parameters.AddWithValue("@d2", lblUser.Text)
            cmd.Parameters.AddWithValue("@d3", txtCustomerName.Text)
            cmd.Parameters.AddWithValue("@d4", txtAddress.Text)
            cmd.Parameters.AddWithValue("@d5", txtContactNo.Text)
            cmd.Parameters.AddWithValue("@d6", lblPaymentMode2.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into RestaurantPOS_OrderedProductBillHD(BillID,Dish,Rate,Quantity,Amount,DiscountPer, DiscountAmount, STPer, STAmount, VATPer, VATAmount,TotalAmount,Notes) VALUES (" & txtBillID2.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView4.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(2).Value))
                    cmd.Parameters.AddWithValue("@d4", Val(row.Cells(3).Value))
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(4).Value))
                    cmd.Parameters.AddWithValue("@d6", Val(row.Cells(5).Value))
                    cmd.Parameters.AddWithValue("@d7", Val(row.Cells(6).Value))
                    cmd.Parameters.AddWithValue("@d8", Val(row.Cells(7).Value))
                    cmd.Parameters.AddWithValue("@d9", Val(row.Cells(8).Value))
                    cmd.Parameters.AddWithValue("@d10", Val(row.Cells(9).Value))
                    cmd.Parameters.AddWithValue("@d11", Val(row.Cells(10).Value))
                    If row.Cells(11).Value = "" Then
                        cmd.Parameters.AddWithValue("@d12", "")
                    Else
                        cmd.Parameters.AddWithValue("@d12", row.Cells(11).Value)
                    End If
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            Dim st As String = "added the new restaurant pos(home delivery) record having bill no. '" & lblBillNo2.Text & "'"
            LogFunc(lblUser.Text, st)
            con.Close()
            If lblPaymentMode2.Text = "Cash" Then
                LedgerSave(System.DateTime.Now, "Cash Account", lblBillNo2.Text, "Restaurant POS(Home Delivery)", 0, Val(txtGrandTotal2.Text), "")
            End If
            If lblPaymentMode2.Text = "Credit Card" Or lblPaymentMode2.Text = "Debit Card" Then
                LedgerSave(System.DateTime.Now, "Bank Account", lblBillNo2.Text, "Restaurant POS(Home Delivery)", 0, Val(txtGrandTotal2.Text), "")
            End If
            btnSave3.Enabled = False
            Print3()
            Reset3()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSettle2_Click(sender As System.Object, e As System.EventArgs) Handles btnSettle2.Click
        Try
            If DataGridView4.Rows.Count = 0 Then
                MessageBox.Show("sorry no item added to datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Settle2()
            flpCategoriesHD.Enabled = False
            flpItemsHD.Enabled = False
            lblSet.Text = "Not Allowed"
            DataGridView4.ClearSelection()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmRestaurantPOS_Resize(sender As System.Object, e As System.EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Maximized Then
            txtParcelCharges.TextAlign = HorizontalAlignment.Right
            txtSubTotal.TextAlign = HorizontalAlignment.Right
            txtSubTotal1.TextAlign = HorizontalAlignment.Right
            txtGrandTotal1.TextAlign = HorizontalAlignment.Right
            txtDeliveryCharges.TextAlign = HorizontalAlignment.Right
            txtGrandTotal2.TextAlign = HorizontalAlignment.Right
        End If
    End Sub

    Private Sub btnPlus2_Click(sender As System.Object, e As System.EventArgs) Handles btnPlus2.Click
        Try
            For Each r As DataGridViewRow In Me.DataGridView4.SelectedRows
                FillData2()
                Compute()
                r.Cells(0).Value = r.Cells(0).Value
                r.Cells(1).Value = txtRate_Food.Text
                r.Cells(2).Value = Val(r.Cells(2).Value) + 1
                r.Cells(3).Value = Val(r.Cells(3).Value) + Val(txtAmt_Food.Text)
                r.Cells(4).Value = Val(txtDiscountPer_Food.Text)
                r.Cells(5).Value = Val(r.Cells(5).Value) + Val(txtDiscountAmount_Food.Text)
                r.Cells(6).Value = Val(txtServiceTaxPer_Food.Text)
                r.Cells(7).Value = Val(r.Cells(7).Value) + Val(txtServiceTaxAmount_Food.Text)
                r.Cells(8).Value = Val(txtVATPer_Food.Text)
                r.Cells(9).Value = Val(r.Cells(9).Value) + Val(txtVATAmt_Food.Text)
                r.Cells(10).Value = Val(r.Cells(10).Value) + Val(txtTotalAmt_Food.Text)
                Dim i As Double = 0
                i = GrandTotal_Food3()
                i = Math.Round(i, 2)
                lblBalance2.Text = i
                txtSubTotal.Text = i
                Clear1()
                If r.Cells(2).Value > 1 Then
                    btnMinus2.Enabled = True
                Else
                    btnMinus2.Enabled = False
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnMinus2_Click(sender As System.Object, e As System.EventArgs) Handles btnMinus2.Click
        Try
            For Each r As DataGridViewRow In Me.DataGridView4.SelectedRows
                FillData2()
                If r.Cells(2).Value = 1 Then
                    btnMinus2.Enabled = False
                    Exit Sub
                End If
                Compute()
                r.Cells(0).Value = r.Cells(0).Value
                r.Cells(1).Value = txtRate_Food.Text
                r.Cells(2).Value = Val(r.Cells(2).Value) - 1
                r.Cells(3).Value = Val(r.Cells(3).Value) - Val(txtAmt_Food.Text)
                r.Cells(4).Value = Val(txtDiscountPer_Food.Text)
                r.Cells(5).Value = Val(r.Cells(5).Value) - Val(txtDiscountAmount_Food.Text)
                r.Cells(6).Value = Val(txtServiceTaxPer_Food.Text)
                r.Cells(7).Value = Val(r.Cells(7).Value) - Val(txtServiceTaxAmount_Food.Text)
                r.Cells(8).Value = Val(txtVATPer_Food.Text)
                r.Cells(9).Value = Val(r.Cells(9).Value) - Val(txtVATAmt_Food.Text)
                r.Cells(10).Value = Val(r.Cells(10).Value) - Val(txtTotalAmt_Food.Text)
                Dim i As Double = 0
                i = GrandTotal_Food3()
                i = Math.Round(i, 2)
                lblBalance2.Text = i
                txtSubTotal.Text = i
                Clear1()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnCancel2_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel2.Click
        Try
            For Each row As DataGridViewRow In DataGridView4.SelectedRows
                DataGridView4.Rows.Remove(row)
            Next
            Dim k As Double = 0
            k = GrandTotal_Food3()
            k = Math.Round(k, 2)
            lblBalance2.Text = k
            txtSubTotal.Text = k
            Compute()
            Clear3()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnChangeRate1_Click(sender As System.Object, e As System.EventArgs) Handles btnChangeRate1.Click
        Try
            frmChangeRate.lblSet.Text = "Takeaway"
            If DataGridView3.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView3.SelectedRows(0)
                frmChangeRate.txtNotes.Text = dr.Cells(11).Value
            End If
            frmChangeRate.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub DataGridView4_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView4.MouseClick
        If DataGridView4.Rows.Count > 0 Then
            If lblSet.Text = "Not Allowed" Then
                btnPlus2.Enabled = False
                btnCancel2.Enabled = False
                btnChangeRate2.Enabled = False
                btnMinus2.Enabled = False
                btnNotes2.Enabled = False
                btnChangeQty2.Enabled = False
            Else
                For Each row As DataGridViewRow In DataGridView4.SelectedRows
                    btnPlus2.Enabled = True
                    btnCancel2.Enabled = True
                    btnChangeRate2.Enabled = True
                    btnNotes2.Enabled = True
                    btnChangeQty2.Enabled = True
                    If row.Cells(2).Value > 1 Then
                        btnMinus2.Enabled = True
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub txtGrandTotal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtGrandTotal.TextChanged
        Calc()
    End Sub

    Private Sub txtChange_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtChange.TextChanged
        Calc()
    End Sub

    Private Sub txtCash1_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtParcelCharges.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtParcelCharges.Text
            Dim selectionStart = Me.txtParcelCharges.SelectionStart
            Dim selectionLength = Me.txtParcelCharges.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtDeliveryCharges_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDeliveryCharges.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtDeliveryCharges.Text
            Dim selectionStart = Me.txtDeliveryCharges.SelectionStart
            Dim selectionLength = Me.txtDeliveryCharges.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtGrandTotal1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSubTotal1.TextChanged
        Calc1()
    End Sub

    Private Sub txtCash1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtParcelCharges.TextChanged
        Calc1()
    End Sub

    Private Sub txtChange1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtGrandTotal1.TextChanged
        Calc1()
    End Sub

    Private Sub txtSubTotal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSubTotal.TextChanged
        Calc2()
    End Sub

    Private Sub txtDeliveryCharges_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDeliveryCharges.TextChanged
        Calc2()
    End Sub

    Private Sub txtGrandTotal2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtGrandTotal2.TextChanged
        Calc2()
    End Sub

    Private Sub btnPrint2_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint2.Click
        Print2()
    End Sub

    Private Sub btnPrint3_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint3.Click
        Print3()
    End Sub

    Private Sub btnChangeRate2_Click(sender As System.Object, e As System.EventArgs) Handles btnChangeRate2.Click
        Try
            frmChangeRate.lblSet.Text = "Home Delivery"
            If DataGridView4.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView4.SelectedRows(0)
                frmChangeRate.txtNotes.Text = dr.Cells(11).Value
            End If
            frmChangeRate.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnSelection_Click(sender As System.Object, e As System.EventArgs) Handles btnSelection.Click
        frmCustomersRecord.Reset()
        frmCustomersRecord.ShowDialog()
    End Sub

    Private Sub DataGridView3_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView3.MouseDoubleClick
        If DataGridView3.Rows.Count > 0 Then
            frmNotes.lblSet.Text = "TA"
            frmNotes.Reset()
            frmNotes.ShowDialog()
        End If
    End Sub

    Private Sub DataGridView1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles DataGridView1.DoubleClick
        If DataGridView1.Rows.Count > 0 Then
            frmNotes.lblSet.Text = "KOT"
            frmNotes.Reset()
            frmNotes.ShowDialog()
        End If
    End Sub

    Private Sub DataGridView4_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView4.MouseDoubleClick
        If DataGridView4.Rows.Count > 0 Then
            frmNotes.lblSet.Text = "HD"
            frmNotes.Reset()
            frmNotes.ShowDialog()
        End If
    End Sub

    Private Sub btnChangeQty1_Click(sender As System.Object, e As System.EventArgs) Handles btnChangeQty1.Click
        Try
            frmChangeQty.lblSet.Text = "Takeaway"
            If DataGridView3.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView3.SelectedRows(0)
                frmChangeQty.txtNotes.Text = dr.Cells(11).Value
            End If
            frmChangeQty.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnChangeQty2_Click(sender As System.Object, e As System.EventArgs) Handles btnChangeQty2.Click
        Try
            frmChangeQty.lblSet.Text = "Home Delivery"
            If DataGridView4.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView4.SelectedRows(0)
                frmChangeQty.txtNotes.Text = dr.Cells(11).Value
            End If
            frmChangeQty.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnChangeQty_Click(sender As System.Object, e As System.EventArgs) Handles btnChangeQty.Click
        Try
            frmChangeQty.lblSet.Text = "KOT"
            If DataGridView1.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
                frmChangeQty.txtNotes.Text = dr.Cells(11).Value
            End If
            frmChangeQty.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnCash_Click(sender As System.Object, e As System.EventArgs) Handles btnCash.Click
        lblPaymentMode.Text = btnCash.Text
    End Sub

    Private Sub btnCreditCard_Click(sender As System.Object, e As System.EventArgs) Handles btnCreditCard.Click
        lblPaymentMode.Text = btnCreditCard.Text
    End Sub

    Private Sub btnDebitCard_Click(sender As System.Object, e As System.EventArgs) Handles btnDebitCard.Click
        lblPaymentMode.Text = btnDebitCard.Text
    End Sub


    Private Sub txtCash1_TextChanged_1(sender As System.Object, e As System.EventArgs) Handles txtCash1.TextChanged
        Calc1()
    End Sub

    Private Sub txtChange1_TextChanged_1(sender As System.Object, e As System.EventArgs) Handles txtChange1.TextChanged
        Calc1()
    End Sub

    Private Sub btnCash1_Click(sender As System.Object, e As System.EventArgs) Handles btnCash1.Click
        lblPaymentMode1.Text = btnCash1.Text
    End Sub

    Private Sub btnCreditCard1_Click(sender As System.Object, e As System.EventArgs) Handles btnCreditCard1.Click
        lblPaymentMode1.Text = btnCreditCard1.Text
    End Sub

    Private Sub btnDebitCard1_Click(sender As System.Object, e As System.EventArgs) Handles btnDebitCard1.Click
        lblPaymentMode1.Text = btnDebitCard1.Text
    End Sub

    Private Sub txtCash1_KeyPress_1(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCash1.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtCash1.Text
            Dim selectionStart = Me.txtCash1.SelectionStart
            Dim selectionLength = Me.txtCash1.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub btnCash2_Click(sender As System.Object, e As System.EventArgs) Handles btnCash2.Click
        lblPaymentMode2.Text = btnCash2.Text
    End Sub

    Private Sub btnCreditCard2_Click(sender As System.Object, e As System.EventArgs) Handles btnCreditCard2.Click
        lblPaymentMode2.Text = btnCreditCard2.Text
    End Sub

    Private Sub btnDebitCard2_Click(sender As System.Object, e As System.EventArgs) Handles btnDebitCard2.Click
        lblPaymentMode2.Text = btnDebitCard2.Text
    End Sub

    Private Sub btnSelection1_Click(sender As System.Object, e As System.EventArgs) Handles btnSelection1.Click
        frmDeliveryPersonRecord.Reset()
        frmDeliveryPersonRecord.ShowDialog()
    End Sub
End Class