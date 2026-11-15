Imports System.Data.SqlClient

Public Class frmRestaurantPOSHDRecord
    Sub fillBillNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(BillNo) FROM RestaurantPOS_BillingInfoHD order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbBillNo.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbBillNo.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(RestaurantPOS_BillingInfoHD.Id), RTRIM(BillNo),BillDate,RTRIM(Customername),RTRIM(RestaurantPOS_BillingInfoHD.Address),RTRIM(RestaurantPOS_BillingInfoHD.ContactNo),(RestaurantPOS_BillingInfoHD.SubTotal),HomeDeliveryCharges,GrandTotal,Employee_ID,RTRIM(EmployeeName),RTRIM(PaymentMode),RTRIM(Operator) from RestaurantPOS_BillingInfoHD,DeliveryPerson where RestaurantPOS_BillingInfoHD.Employee_ID=DeliveryPerson.EmpID  order by BillDate"
            cmd = New SqlCommand(sql, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
        fillBillNo()
    End Sub
    Sub Reset()
        cmbBillNo.Text = ""
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Now
        GetData()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try

            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                Me.Hide()
                frmRestaurantPOS.Show()
                ' or simply use column name instead of index
                'dr.Cells["id"].Value.ToString();
                frmRestaurantPOS.txtBillID2.Text = dr.Cells(0).Value.ToString()
                frmRestaurantPOS.lblBillNo2.Text = dr.Cells(1).Value.ToString()
                frmRestaurantPOS.txtCustomerName.Text = dr.Cells(3).Value.ToString()
                frmRestaurantPOS.txtAddress.Text = dr.Cells(4).Value.ToString()
                frmRestaurantPOS.txtContactNo.Text = dr.Cells(5).Value.ToString()
                frmRestaurantPOS.txtSubTotal.Text = dr.Cells(6).Value.ToString()
                frmRestaurantPOS.txtDeliveryCharges.Text = dr.Cells(7).Value.ToString()
                frmRestaurantPOS.txtGrandTotal2.Text = dr.Cells(8).Value.ToString()
                frmRestaurantPOS.txtDeliveryPersonID.Text = dr.Cells(9).Value.ToString()
                frmRestaurantPOS.txtDeliveryPerson.Text = dr.Cells(10).Value.ToString()
                frmRestaurantPOS.lblPaymentMode2.Text = dr.Cells(11).Value.ToString()
                frmRestaurantPOS.btnSave3.Enabled = False
                frmRestaurantPOS.btnDelete3.Enabled = True
                frmRestaurantPOS.btnPrint3.Enabled = True
                frmRestaurantPOS.lblSet.Text = "Not Allowed"
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "Select RTRIM(Dish),RTRIM(Rate),RTRIM(Quantity),RTRIM(Amount),RTRIM(DiscountPer), RTRIM(DiscountAmount), RTRIM(STPer), RTRIM(STAmount), RTRIM(VATPer), RTRIM(VATAmount),RTRIM(TotalAmount),RTRIM(Notes) from RestaurantPOS_BillingInfoHD,RestaurantPOS_OrderedProductBillHD where RestaurantPOS_BillingInfoHD.Id=RestaurantPOS_OrderedProductBillHD.BillID and RestaurantPOS_BillingInfoHD.ID=" & dr.Cells(0).Value & " order by Dish"
                cmd = New SqlCommand(sql, con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                frmRestaurantPOS.DataGridView4.Rows.Clear()
                While (rdr.Read() = True)
                    frmRestaurantPOS.DataGridView4.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11))
                End While
                con.Close()
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(RestaurantPOS_BillingInfoHD.Id), RTRIM(BillNo),BillDate,RTRIM(Customername),RTRIM(RestaurantPOS_BillingInfoHD.Address),RTRIM(RestaurantPOS_BillingInfoHD.ContactNo),(RestaurantPOS_BillingInfoHD.SubTotal),HomeDeliveryCharges,GrandTotal,Employee_ID,RTRIM(EmployeeName),RTRIM(PaymentMode),RTRIM(Operator) from RestaurantPOS_BillingInfoHD,DeliveryPerson where RestaurantPOS_BillingInfoHD.Employee_ID=DeliveryPerson.EmpID and BillDate between @d1 and @d2 order by BillDate"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "BillDate").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "BillDate").Value = dtpDateTo.Value
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbBillNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBillNo.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(RestaurantPOS_BillingInfoHD.Id), RTRIM(BillNo),BillDate,RTRIM(Customername),RTRIM(RestaurantPOS_BillingInfoHD.Address),RTRIM(RestaurantPOS_BillingInfoHD.ContactNo),(RestaurantPOS_BillingInfoHD.SubTotal),HomeDeliveryCharges,GrandTotal,Employee_ID,RTRIM(EmployeeName),RTRIM(PaymentMode),RTRIM(Operator) from RestaurantPOS_BillingInfoHD,DeliveryPerson where RestaurantPOS_BillingInfoHD.Employee_ID=DeliveryPerson.EmpID and BillNo=@d1 order by BillDate"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@d1", cmbBillNo.Text)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbBillNo_Format(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbBillNo.Format
        If (e.DesiredType Is GetType(String)) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub

End Class

