Imports System.Data.SqlClient

Public Class frmStock
    Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(ID) as [Stock ID],RTRIM(LiquorName) as [Liquor Name],Volumn as [Quantity(in ML)],NoOfBottles as [No. Of Bottles],Convert(Datetime,Date,103) as [Stock Date] from Stock order by Date", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Stock")
            dgw.DataSource = myDataSet.Tables("Stock").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub auto()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM Stock")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtStockID.Text = Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtStockID.Text = Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub
    Sub Reset()
        txtNoOfBottles.Text = ""
        txtStockID.Text = ""
        cmbLiquorName.Text = ""
        cmbQuantity.SelectedIndex = -1
        dtpDate.Text = Now
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        cmbLiquorName.Enabled = True
        cmbQuantity.Enabled = True
        dtpDate.Enabled = True
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Len(Trim(cmbLiquorName.Text)) = 0 Then
                MessageBox.Show("Please enter Liquor name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbLiquorName.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbQuantity.Text)) = 0 Then
                MessageBox.Show("Please select quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbQuantity.Focus()
                Exit Sub
            End If

            If txtNoOfBottles.Text = "" Then
                MessageBox.Show("Please enter no. of bottles", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNoOfBottles.Focus()
                Return
            End If
            con = New SqlConnection(cs)
            con.Open()

            Dim ct As String = "select LiquorName,Volumn from temp_Stock where LiquorName=@d1 and Volumn=@d2"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbLiquorName.Text)
            cmd.Parameters.AddWithValue("@d2", Val(cmbQuantity.Text))
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                con = New SqlConnection(cs)
                con.Open()
                Dim cb2 As String = "Update Temp_Stock set NoOfBottles=NoOfBottles + " & txtNoOfBottles.Text & ",TotalVolumn=TotalVolumn + " & Val(txtNoOfBottles.Text) * Val(cmbQuantity.Text) & " where LiquorName=@d1 and Volumn=@d2"
                cmd = New SqlCommand(cb2)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", cmbLiquorName.Text)
                cmd.Parameters.AddWithValue("@d2", Val(cmbQuantity.Text))
                cmd.ExecuteReader()
                con.Close()

            Else
                con = New SqlConnection(cs)
                con.Open()
                Dim cb3 As String = "insert into Temp_Stock(LiquorName,Volumn,NoOfBottles,TotalVolumn) VALUES (@d1,@d2," & txtNoOfBottles.Text & ",@d3)"
                cmd = New SqlCommand(cb3)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", cmbLiquorName.Text)
                cmd.Parameters.AddWithValue("@d2", Val(cmbQuantity.Text))
                cmd.Parameters.AddWithValue("@d3", Val(txtNoOfBottles.Text) * Val(cmbQuantity.Text))
                cmd.ExecuteReader()
                con.Close()
            End If
            auto()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Stock(ID,LiquorName,Volumn,NoOfBottles,Date) VALUES (" & txtStockID.Text & ",@d1,@d2," & txtNoOfBottles.Text & ",@d3)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbLiquorName.Text)
            cmd.Parameters.AddWithValue("@d2", Val(cmbQuantity.Text))
            cmd.Parameters.AddWithValue("@d3", dtpDate.Value)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "added the Stock of Liquor '" & cmbLiquorName.Text & "' and quantity '" & cmbQuantity.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            auto()
            Getdata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtStockID.Text = dr.Cells(0).Value.ToString()
                cmbLiquorName.Text = dr.Cells(1).Value.ToString()
                cmbQuantity.Text = dr.Cells(2).Value.ToString()
                txtNoOfBottles.Text = dr.Cells(3).Value.ToString()
                txtNoOfBottles1.Text = dr.Cells(3).Value.ToString()
                dtpDate.Text = dr.Cells(4).Value.ToString()
                btnUpdate.Enabled = True
                cmbQuantity.Enabled = False
                cmbLiquorName.Enabled = False
                btnDelete.Enabled = True
                btnSave.Enabled = False
                dtpDate.Enabled = False
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

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            If Len(Trim(cmbLiquorName.Text)) = 0 Then
                MessageBox.Show("Please enter Liquor name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbLiquorName.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbQuantity.Text)) = 0 Then
                MessageBox.Show("Please select quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbQuantity.Focus()
                Exit Sub
            End If

            If txtNoOfBottles.Text = "" Then
                MessageBox.Show("Please enter no. of bottles", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNoOfBottles.Focus()
                Return
            End If
            con = New SqlConnection(cs)
            con.Open()

            Dim ct As String = "select LiquorName,Volumn from temp_Stock where LiquorName=@d1 and Volumn=@d2"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbLiquorName.Text)
            cmd.Parameters.AddWithValue("@d2", Val(cmbQuantity.Text))
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                con = New SqlConnection(cs)
                con.Open()
                Dim cb2 As String = "Update Temp_Stock set NoOfBottles=NoOfBottles + " & txtNoOfBottles.Text & " - " & txtNoOfBottles1.Text & ",TotalVolumn=TotalVolumn + " & Val(txtNoOfBottles.Text) * Val(cmbQuantity.Text) & " - " & Val(txtNoOfBottles1.Text) * Val(cmbQuantity.Text) & " where LiquorName=@d1 and Volumn=@d2"
                cmd = New SqlCommand(cb2)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", cmbLiquorName.Text)
                cmd.Parameters.AddWithValue("@d2", Val(cmbQuantity.Text))
                cmd.ExecuteReader()
                con.Close()

            Else
                con = New SqlConnection(cs)
                con.Open()
                Dim cb3 As String = "insert into Temp_Stock(LiquorName,Volumn,NoOfBottles,TotalVolumn) VALUES (@d1,@d2," & txtNoOfBottles.Text & ",@d3)"
                cmd = New SqlCommand(cb3)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", cmbLiquorName.Text)
                cmd.Parameters.AddWithValue("@d2", Val(cmbQuantity.Text))
                cmd.Parameters.AddWithValue("@d3", Val(txtNoOfBottles.Text) * Val(cmbQuantity.Text))
                cmd.ExecuteReader()
                con.Close()
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update Stock set LiquorName=@d1,Volumn=@d2,NoOfBottles=" & txtNoOfBottles.Text & " where ID=" & txtStockID.Text & ""
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbLiquorName.Text)
            cmd.Parameters.AddWithValue("@d2", Val(cmbQuantity.Text))
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "updated the Stock of Liquor '" & cmbLiquorName.Text & "' and quantity '" & cmbQuantity.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            GetData()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DeleteRecord()

        Try

            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cb2 As String = "Update Temp_Stock set NoOfBottles=NoOfBottles - " & txtNoOfBottles.Text & ",TotalVolumn=TotalVolumn - " & Val(txtNoOfBottles.Text) * Val(cmbQuantity.Text) & " where LiquorName=@d1 and Volumn=@d2"
            cmd = New SqlCommand(cb2)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbLiquorName.Text)
            cmd.Parameters.AddWithValue("@d2", Val(cmbQuantity.Text))
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from Stock where ID=" & txtStockID.Text & ""
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the Stock of Liquor '" & cmbLiquorName.Text & "' and quantity '" & cmbQuantity.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Getdata()
                Reset()
            Else
                MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If dgw.RowCount = Nothing Then
            MessageBox.Show("Sorry nothing to export into excel sheet.." & vbCrLf & "Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        ExportExcel(dgw)
    End Sub
    Sub fillLiquor()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(LiquorName) FROM Liquor", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbLiquorName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbLiquorName.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
 
    Sub fillQuantity()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Volumn) FROM Liquor_Volumn", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbQuantity.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbQuantity.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtNoOfBottles_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoOfBottles.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub frmStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillLiquor()
        fillQuantity()
        GetData()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        txtLiquorName.Text = ""
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Now
        GetData()
    End Sub

    Private Sub txtLiquorName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLiquorName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(ID) as [Stock ID],RTRIM(LiquorName) as [Liquor Name],Volumn as [Quantity(in ML)],NoOfBottles as [No. Of Bottles],Convert(Datetime,Date,131) as [Stock Date] from Stock where LiquorName like '%" & txtLiquorName.Text & "%' order by Date", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Stock")
            dgw.DataSource = myDataSet.Tables("Stock").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(ID) as [Stock ID],RTRIM(LiquorName) as [Liquor Name],Volumn as [Quantity(in ML)],NoOfBottles as [No. Of Bottles],Convert(Datetime,Date,131) as [Stock Date] from Stock where date between @d1 and @d2 order by Date", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Stock")
            dgw.DataSource = myDataSet.Tables("Stock").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
