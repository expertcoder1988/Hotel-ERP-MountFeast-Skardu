Imports System.Data.SqlClient

Public Class frmRestaurantBillingRecord1
    Sub fillBillNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(BillNo) FROM Restaurant_OrderInfo", CN)
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
    Sub fillFoodCategory()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(CategoryName) FROM Category", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbFoodCategory.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbFoodCategory.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillLiquorCategory()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(CategoryName) FROM Category_Liquor", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbLiquorCategory.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbLiquorCategory.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(Restaurant_OrderInfo.BillNo) as [Bill No.], Convert(DateTime,Restaurant_OrderInfo.BillDate,131) as [Bill Date],RTRIM(Restaurant_OrderedProduct.Dish_Liquor) as [Item Description], RTRIM(Restaurant_OrderedProduct.Volumn) as [Volumn (in ML)],RTRIM(Restaurant_OrderedProduct.Rate) as [Rate], RTRIM(Restaurant_OrderedProduct.Quantity) as [Quantity], RTRIM(Restaurant_OrderedProduct.DiscountPer) as [Discount %], RTRIM(Restaurant_OrderedProduct.DiscountAmount) as [Discount Amount], RTRIM(Restaurant_OrderedProduct.VATPer) as [VAT %], RTRIM(Restaurant_OrderedProduct.VATAmount) as [VAT Amount], RTRIM(Restaurant_OrderedProduct.STPer) as [Service Tax %], RTRIM(Restaurant_OrderedProduct.STAmount) as [Service Tax Amount],RTRIM(Restaurant_OrderedProduct.TotalAmount) as [Total Amount] FROM Restaurant_OrderedProduct INNER JOIN Restaurant_OrderInfo ON Restaurant_OrderedProduct.BillID = Restaurant_OrderInfo.ID order by BillDate", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Restaurant_OrderInfo")
            dgw.DataSource = myDataSet.Tables("Restaurant_OrderInfo").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
        fillBillNo()
        fillFoodCategory()
        fillLiquorCategory()
    End Sub
    Sub Reset()
        cmbBillNo.Text = ""
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Now
        DateTimePicker1.Text = Now
        DateTimePicker2.Text = Today
        DateTimePicker3.Text = Now
        DateTimePicker4.Text = Today
        cmbFoodCategory.SelectedIndex = -1
        cmbLiquorCategory.SelectedIndex = -1
        GetData()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub


    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
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
            cmd = New SqlCommand("SELECT RTRIM(Restaurant_OrderInfo.BillNo) as [Bill No.], Convert(DateTime,Restaurant_OrderInfo.BillDate,131) as [Bill Date],RTRIM(Restaurant_OrderedProduct.Dish_Liquor) as [Item Description], RTRIM(Restaurant_OrderedProduct.Volumn) as [Volumn (in ML)],RTRIM(Restaurant_OrderedProduct.Rate) as [Rate], RTRIM(Restaurant_OrderedProduct.Quantity) as [Quantity], RTRIM(Restaurant_OrderedProduct.DiscountPer) as [Discount %], RTRIM(Restaurant_OrderedProduct.DiscountAmount) as [Discount Amount], RTRIM(Restaurant_OrderedProduct.VATPer) as [VAT %], RTRIM(Restaurant_OrderedProduct.VATAmount) as [VAT Amount], RTRIM(Restaurant_OrderedProduct.STPer) as [Service Tax %], RTRIM(Restaurant_OrderedProduct.STAmount) as [Service Tax Amount],RTRIM(Restaurant_OrderedProduct.TotalAmount) as [Total Amount] FROM Restaurant_OrderedProduct INNER JOIN Restaurant_OrderInfo ON Restaurant_OrderedProduct.BillID = Restaurant_OrderInfo.ID where BillDate between @d1 and @d2 order by BillDate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "BillDate").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "BillDate").Value = dtpDateTo.Value
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Restaurant_OrderInfo")
            dgw.DataSource = myDataSet.Tables("Restaurant_OrderInfo").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbBillNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBillNo.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(Restaurant_OrderInfo.BillNo) as [Bill No.], Convert(DateTime,Restaurant_OrderInfo.BillDate,131) as [Bill Date],RTRIM(Restaurant_OrderedProduct.Dish_Liquor) as [Item Description], RTRIM(Restaurant_OrderedProduct.Volumn) as [Volumn (in ML)],RTRIM(Restaurant_OrderedProduct.Rate) as [Rate], RTRIM(Restaurant_OrderedProduct.Quantity) as [Quantity], RTRIM(Restaurant_OrderedProduct.DiscountPer) as [Discount %], RTRIM(Restaurant_OrderedProduct.DiscountAmount) as [Discount Amount], RTRIM(Restaurant_OrderedProduct.VATPer) as [VAT %], RTRIM(Restaurant_OrderedProduct.VATAmount) as [VAT Amount], RTRIM(Restaurant_OrderedProduct.STPer) as [Service Tax %], RTRIM(Restaurant_OrderedProduct.STAmount) as [Service Tax Amount],RTRIM(Restaurant_OrderedProduct.TotalAmount) as [Total Amount] FROM Restaurant_OrderedProduct INNER JOIN Restaurant_OrderInfo ON Restaurant_OrderedProduct.BillID = Restaurant_OrderInfo.ID where BillNo='" & cmbBillNo.Text & "' order by BillDate", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Restaurant_OrderInfo")
            dgw.DataSource = myDataSet.Tables("Restaurant_OrderInfo").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        Try
            If Len(Trim(cmbFoodCategory.Text)) = 0 Then
                MessageBox.Show("Please select food category", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbFoodCategory.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(Restaurant_OrderInfo.BillNo) as [Bill No.], Convert(DateTime,Restaurant_OrderInfo.BillDate,131) as [Bill Date],RTRIM(Restaurant_OrderedProduct.Dish_Liquor) as [Item Description], RTRIM(Restaurant_OrderedProduct.Volumn) as [Volumn (in ML)],RTRIM(Restaurant_OrderedProduct.Rate) as [Rate], RTRIM(Restaurant_OrderedProduct.Quantity) as [Quantity], RTRIM(Restaurant_OrderedProduct.DiscountPer) as [Discount %], RTRIM(Restaurant_OrderedProduct.DiscountAmount) as [Discount Amount], RTRIM(Restaurant_OrderedProduct.VATPer) as [VAT %], RTRIM(Restaurant_OrderedProduct.VATAmount) as [VAT Amount], RTRIM(Restaurant_OrderedProduct.STPer) as [Service Tax %], RTRIM(Restaurant_OrderedProduct.STAmount) as [Service Tax Amount],RTRIM(Restaurant_OrderedProduct.TotalAmount) as [Total Amount] FROM Restaurant_OrderedProduct,Restaurant_OrderInfo,Dish,Category where Restaurant_OrderedProduct.BillID = Restaurant_OrderInfo.ID and Category.categoryName=Dish.Category and Dish.DishName=Restaurant_OrderedProduct.Dish_Liquor and BillDate between @d1 and @d2 and Dish.Category=@d3 order by BillDate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "BillDate").Value = DateTimePicker2.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "BillDate").Value = DateTimePicker1.Value
            cmd.Parameters.Add("@d3", SqlDbType.NChar, 200, "Category").Value = cmbFoodCategory.Text
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Restaurant_OrderInfo")
            dgw.DataSource = myDataSet.Tables("Restaurant_OrderInfo").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Try
            If Len(Trim(cmbLiquorCategory.Text)) = 0 Then
                MessageBox.Show("Please select liquor category", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbLiquorCategory.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(Restaurant_OrderInfo.BillNo) as [Bill No.], Convert(DateTime,Restaurant_OrderInfo.BillDate,131) as [Bill Date],RTRIM(Restaurant_OrderedProduct.Dish_Liquor) as [Item Description], RTRIM(Restaurant_OrderedProduct.Volumn) as [Volumn (in ML)],RTRIM(Restaurant_OrderedProduct.Rate) as [Rate], RTRIM(Restaurant_OrderedProduct.Quantity) as [Quantity], RTRIM(Restaurant_OrderedProduct.DiscountPer) as [Discount %], RTRIM(Restaurant_OrderedProduct.DiscountAmount) as [Discount Amount], RTRIM(Restaurant_OrderedProduct.VATPer) as [VAT %], RTRIM(Restaurant_OrderedProduct.VATAmount) as [VAT Amount], RTRIM(Restaurant_OrderedProduct.STPer) as [Service Tax %], RTRIM(Restaurant_OrderedProduct.STAmount) as [Service Tax Amount],RTRIM(Restaurant_OrderedProduct.TotalAmount) as [Total Amount] FROM Restaurant_OrderedProduct,Restaurant_OrderInfo,Liquor,Category_Liquor where Restaurant_OrderedProduct.BillID = Restaurant_OrderInfo.ID and Category_Liquor.categoryName=Liquor.Category and Liquor.LiquorName=Restaurant_OrderedProduct.Dish_Liquor and BillDate between @d1 and @d2 and Category_Liquor.CategoryName=@d3 order by BillDate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "BillDate").Value = DateTimePicker4.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "BillDate").Value = DateTimePicker3.Value
            cmd.Parameters.Add("@d3", SqlDbType.NChar, 200, "Category").Value = cmbLiquorCategory.Text
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Restaurant_OrderInfo")
            dgw.DataSource = myDataSet.Tables("Restaurant_OrderInfo").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbBillNo_Format(sender As System.Object, e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbBillNo.Format
        If (e.DesiredType Is GetType(String)) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub
End Class
