Imports System.Data.SqlClient
Public Class frmUserRights
    Dim TotalCheckBoxes As Integer = 0
    Dim TotalCheckedCheckBoxes As Integer = 0
    Dim HeaderCheckBox1 As CheckBox = Nothing
    Dim HeaderCheckBox2 As CheckBox = Nothing
    Dim HeaderCheckBox3 As CheckBox = Nothing
    Dim HeaderCheckBox4 As CheckBox = Nothing
    Dim IsHeaderCheckBoxClicked As Boolean = False
    Private Sub HeaderCheckBoxClick1(HCheckBox As CheckBox)
        IsHeaderCheckBoxClicked = True
        For Each Row As DataGridViewRow In dgw.Rows
            DirectCast(Row.Cells("chkSave"), DataGridViewCheckBoxCell).Value = HCheckBox.Checked
        Next
        dgw.RefreshEdit()
        TotalCheckedCheckBoxes = If(HCheckBox.Checked, TotalCheckBoxes, 0)
        IsHeaderCheckBoxClicked = False
    End Sub
    Private Sub HeaderCheckBoxClick2(HCheckBox As CheckBox)
        IsHeaderCheckBoxClicked = True

        For Each Row As DataGridViewRow In dgw.Rows
            DirectCast(Row.Cells("chkUpdate"), DataGridViewCheckBoxCell).Value = HCheckBox.Checked
        Next

        dgw.RefreshEdit()

        TotalCheckedCheckBoxes = If(HCheckBox.Checked, TotalCheckBoxes, 0)

        IsHeaderCheckBoxClicked = False
    End Sub

    Private Sub HeaderCheckBoxClick3(HCheckBox As CheckBox)
        IsHeaderCheckBoxClicked = True

        For Each Row As DataGridViewRow In dgw.Rows
            DirectCast(Row.Cells("chkDelete"), DataGridViewCheckBoxCell).Value = HCheckBox.Checked
        Next

        dgw.RefreshEdit()

        TotalCheckedCheckBoxes = If(HCheckBox.Checked, TotalCheckBoxes, 0)

        IsHeaderCheckBoxClicked = False
    End Sub
    Private Sub HeaderCheckBoxClick4(HCheckBox As CheckBox)
        IsHeaderCheckBoxClicked = True

        For Each Row As DataGridViewRow In dgw.Rows
            DirectCast(Row.Cells("chkViewRecords"), DataGridViewCheckBoxCell).Value = HCheckBox.Checked
        Next

        dgw.RefreshEdit()

        TotalCheckedCheckBoxes = If(HCheckBox.Checked, TotalCheckBoxes, 0)

        IsHeaderCheckBoxClicked = False
    End Sub
    Private Sub AddHeaderCheckBox1()
        'adding new
        HeaderCheckBox1 = New CheckBox()

        HeaderCheckBox1.Size = New Size(15, 15)

        'Add the CheckBox into the DataGridView
        Me.dgw.Controls.Add(HeaderCheckBox1)


    End Sub

    Private Sub AddHeaderCheckBox2()
        'adding new
        HeaderCheckBox2 = New CheckBox()

        HeaderCheckBox2.Size = New Size(15, 15)

        'Add the CheckBox into the DataGridView
        Me.dgw.Controls.Add(HeaderCheckBox2)
    End Sub

    Private Sub AddHeaderCheckBox3()
        'adding new
        HeaderCheckBox3 = New CheckBox()

        HeaderCheckBox3.Size = New Size(15, 15)

        'Add the CheckBox into the DataGridView
        Me.dgw.Controls.Add(HeaderCheckBox3)
    End Sub

    Private Sub AddHeaderCheckBox4()
        'adding new
        HeaderCheckBox4 = New CheckBox()

        HeaderCheckBox4.Size = New Size(15, 15)

        'Add the CheckBox into the DataGridView
        Me.dgw.Controls.Add(HeaderCheckBox4)
    End Sub

    Private Sub dgw_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs)
        If TypeOf dgw.CurrentCell Is DataGridViewCheckBoxCell Then
            dgw.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub HeaderCheckBox1_MouseClick(sender As Object, e As MouseEventArgs)
        HeaderCheckBoxClick1(DirectCast(sender, CheckBox))
    End Sub

    Private Sub HeaderCheckBox1_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Space Then
            HeaderCheckBoxClick1(DirectCast(sender, CheckBox))
        End If
    End Sub

    Private Sub HeaderCheckBox2_MouseClick(sender As Object, e As MouseEventArgs)
        HeaderCheckBoxClick2(DirectCast(sender, CheckBox))
    End Sub

    Private Sub HeaderCheckBox2_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Space Then
            HeaderCheckBoxClick2(DirectCast(sender, CheckBox))
        End If
    End Sub

    Private Sub frmUserRights_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            AddHeaderCheckBox3()
            AddHeaderCheckBox1()
            AddHeaderCheckBox2()
            AddHeaderCheckBox4()
            AddHandler dgw.CurrentCellDirtyStateChanged, New EventHandler(AddressOf dgw_CurrentCellDirtyStateChanged)
            AddHandler HeaderCheckBox1.KeyUp, New KeyEventHandler(AddressOf HeaderCheckBox1_KeyUp)
            AddHandler HeaderCheckBox1.MouseClick, New MouseEventHandler(AddressOf HeaderCheckBox1_MouseClick)
            AddHandler HeaderCheckBox2.KeyUp, New KeyEventHandler(AddressOf HeaderCheckBox2_KeyUp)
            AddHandler HeaderCheckBox2.MouseClick, New MouseEventHandler(AddressOf HeaderCheckBox2_MouseClick)
            AddHandler HeaderCheckBox3.KeyUp, New KeyEventHandler(AddressOf HeaderCheckBox3_KeyUp)
            AddHandler HeaderCheckBox3.MouseClick, New MouseEventHandler(AddressOf HeaderCheckBox3_MouseClick)
            AddHandler HeaderCheckBox4.KeyUp, New KeyEventHandler(AddressOf HeaderCheckBox4_KeyUp)
            AddHandler HeaderCheckBox4.MouseClick, New MouseEventHandler(AddressOf HeaderCheckBox4_MouseClick)
            AddHandler dgw.CellPainting, New DataGridViewCellPaintingEventHandler(AddressOf dgw_CellPainting)
            AddForms()
            fillUserID()
            dgw.ClearSelection()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillUserID()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT RTRIM(UserID) FROM Registration", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbUserID.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbUserID.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub AddForms()
        dgw.Rows.Add("Hotel Master")
        dgw.Rows.Add("Hotel Plan Master")
        dgw.Rows.Add("Currency Master")
        dgw.Rows.Add("Room Type Master")
        dgw.Rows.Add("Room Master")
        dgw.Rows.Add("ID Type Master")
        dgw.Rows.Add("Guest Master")
        dgw.Rows.Add("Extra Bed Master")
        dgw.Rows.Add("Extra Person Master")
        dgw.Rows.Add("Hall Master")
        dgw.Rows.Add("Garden Master")
        dgw.Rows.Add("Food Category")
        dgw.Rows.Add("Table Master")
        dgw.Rows.Add("Liquor Category")
        dgw.Rows.Add("Liquor Quantity")
        dgw.Rows.Add("Liquor Master")
        dgw.Rows.Add("Liquor Pricing")
        dgw.Rows.Add("Laundry Master")
        dgw.Rows.Add("Expense Type Master")
        dgw.Rows.Add("Expenses Master")
        dgw.Rows.Add("Tax Master")
        dgw.Rows.Add("Other Tax Master")
        dgw.Rows.Add("Restaurant Billing")
        dgw.Rows.Add("Restaurant Billing (KOT)")
        dgw.Rows.Add("Room Reservation")
        dgw.Rows.Add("Hall or Garden Reservation")
        dgw.Rows.Add("Check In")
        dgw.Rows.Add("Check Out")
        dgw.Rows.Add("Stock")
        dgw.Rows.Add("Food and Liquor Order")
        dgw.Rows.Add("Purchased Inventory")
        dgw.Rows.Add("Other Trans")
        dgw.Rows.Add("Voucher")
        dgw.Rows.Add("Bank Master")
        dgw.Rows.Add("Branch Master")
        dgw.Rows.Add("Bank Accounts Register")
        dgw.Rows.Add("Employee Accounts Master")
        dgw.Rows.Add("Bank Account Transaction")
        dgw.Rows.Add("Employee Account Tranaction")
        dgw.Rows.Add("Guest Ledger")
        dgw.Rows.Add("SMS Setting")
    End Sub

    Private Sub dgw_CellPainting(ByVal sender As Object, ByVal e As DataGridViewCellPaintingEventArgs)
        If e.RowIndex = -1 AndAlso e.ColumnIndex = 1 Then
            ResetHeaderCheckBoxLocation1(e.ColumnIndex, e.RowIndex)
        End If

        If e.RowIndex = -1 AndAlso e.ColumnIndex = 2 Then
            ResetHeaderCheckBoxLocation2(e.ColumnIndex, e.RowIndex)
        End If

        If e.RowIndex = -1 AndAlso e.ColumnIndex = 3 Then
            ResetHeaderCheckBoxLocation3(e.ColumnIndex, e.RowIndex)
        End If
        If e.RowIndex = -1 AndAlso e.ColumnIndex = 4 Then
            ResetHeaderCheckBoxLocation4(e.ColumnIndex, e.RowIndex)
        End If
    End Sub

    Private Sub HeaderCheckBox3_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs)
        HeaderCheckBoxClick3(DirectCast(sender, CheckBox))
    End Sub

    Private Sub HeaderCheckBox3_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Space Then
            HeaderCheckBoxClick3(DirectCast(sender, CheckBox))
        End If
    End Sub

    Private Sub HeaderCheckBox4_MouseClick(sender As Object, e As MouseEventArgs)
        HeaderCheckBoxClick4(DirectCast(sender, CheckBox))
    End Sub

    Private Sub HeaderCheckBox4_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Space Then
            HeaderCheckBoxClick4(DirectCast(sender, CheckBox))
        End If
    End Sub

    Private Sub ResetHeaderCheckBoxLocation1(ColumnIndex As Integer, RowIndex As Integer)
        'for cell painting event
        'Get the column header cell bounds
        Dim oRectangle As Rectangle = Me.dgw.GetCellDisplayRectangle(ColumnIndex, RowIndex, True)

        Dim oPoint As New Point()

        oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox1.Width) / 2 + 1
        oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox1.Height) / 2 + 1

        'Change the location of the CheckBox to make it stay on the header
        HeaderCheckBox1.Location = oPoint
    End Sub

    Private Sub ResetHeaderCheckBoxLocation2(ByVal ColumnIndex As Integer, ByVal RowIndex As Integer)
        'for cell painting event
        'Get the column header cell bounds
        Dim oRectangle As Rectangle = Me.dgw.GetCellDisplayRectangle(ColumnIndex, RowIndex, True)

        Dim oPoint As New Point()

        oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox2.Width) / 2 + 1
        oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox2.Height) / 2 + 1

        'Change the location of the CheckBox to make it stay on the header
        HeaderCheckBox2.Location = oPoint
    End Sub

    Private Sub ResetHeaderCheckBoxLocation3(ByVal ColumnIndex As Integer, ByVal RowIndex As Integer)
        'for cell painting event
        'Get the column header cell bounds
        Dim oRectangle As Rectangle = Me.dgw.GetCellDisplayRectangle(ColumnIndex, RowIndex, True)

        Dim oPoint As New Point()

        oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox3.Width) / 2 + 1
        oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox3.Height) / 2 + 1

        'Change the location of the CheckBox to make it stay on the header
        HeaderCheckBox3.Location = oPoint
    End Sub

    Private Sub ResetHeaderCheckBoxLocation4(ByVal ColumnIndex As Integer, ByVal RowIndex As Integer)
        'for cell painting event
        'Get the column header cell bounds
        Dim oRectangle As Rectangle = Me.dgw.GetCellDisplayRectangle(ColumnIndex, RowIndex, True)

        Dim oPoint As New Point()

        oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox3.Width) / 2 + 1
        oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox3.Height) / 2 + 1

        'Change the location of the CheckBox to make it stay on the header
        HeaderCheckBox4.Location = oPoint
    End Sub
    Sub Reset()
        dgw.Rows.Clear()
        AddForms()
        HeaderCheckBox1.Checked = False
        HeaderCheckBox2.Checked = False
        HeaderCheckBox3.Checked = False
        HeaderCheckBox4.Checked = False
        dgw.ClearSelection()
        cmbUserID.SelectedIndex = -1
        txtUserType.Text = ""
        txtName.Text = ""
    End Sub
    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub dgw_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

        If e.RowIndex = 1 Then
            Dim cell As DataGridViewCell = dgw.Rows(18).Cells(1)
            Dim chkCell As DataGridViewCheckBoxCell = TryCast(cell, DataGridViewCheckBoxCell)
            chkCell.Value = False
            chkCell.FlatStyle = FlatStyle.Flat
            chkCell.Style.ForeColor = Color.LightSeaGreen
            cell.[ReadOnly] = True
        End If
        If e.RowIndex = 2 Then
            Dim cell As DataGridViewCell = dgw.Rows(18).Cells(2)
            Dim chkCell As DataGridViewCheckBoxCell = TryCast(cell, DataGridViewCheckBoxCell)
            chkCell.Value = False
            chkCell.FlatStyle = FlatStyle.Flat
            chkCell.Style.ForeColor = Color.MediumPurple
            cell.[ReadOnly] = True
        End If
    End Sub

    Private Sub cmbUserID_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbUserID.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(UserType),RTRIM(Name) FROM Registration WHERE UserID=@d1"
            cmd.Parameters.AddWithValue("@d1", cmbUserID.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtUserType.Text = rdr.GetValue(0)
                txtName.Text = rdr.GetValue(1)
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

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If cmbUserID.Text = "" Then
            MessageBox.Show("Please select user id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbUserID.Focus()
            Return
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select userid from UserRights where userid=@d1"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d1", cmbUserID.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into UserRights(FormName,[Save],[Update],[Delete],[View],UserID) VALUES (@d1,@d2,@3,@d4,@d5,@d6)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In dgw.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value)
                    cmd.Parameters.AddWithValue("@d3", row.Cells(2).Value)
                    cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value)
                    cmd.Parameters.AddWithValue("@d5", row.Cells(4).Value)
                    cmd.Parameters.AddWithValue("@d6", cmbUserID.Text)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            btnSave.Enabled = False
            MessageBox.Show("Successfully granted", "User Rights", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
End Class