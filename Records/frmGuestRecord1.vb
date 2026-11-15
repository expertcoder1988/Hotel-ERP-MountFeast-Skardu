Imports System.Data.SqlClient

Public Class frmGuestRecord1

  

    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID) as [ID],RTRIM(GuestID)as [Guest ID],RTRIM(Guestname) as [Guest Name],RTRIM(Gender) as [Gender],RTRIM(Religion) as [Religion],RTRIM(Occupation) as [Company],RTRIM(address) as [Address],RTRIM(city) as [City],RTRIM(Country) as [Country],RTRIM(ContactNo) as [Contact No],RTRIM(Email) as [Email],RTRIM(IDType) as [ID Type],RTRIM(IDNumber) as [ID Number],RTRIM(Company) as [Company],RTRIM(Model) as [Model],RTRIM(VehicleNo) as [Vehicle No.],RTRIM(Color) as [Color],RTRIM(Notes) as [Notes] from Guest order by GuestName", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
    End Sub
    Sub Reset()
        txtGuestName.Text = ""
        txtCity.Text = ""
        txtContactNo.Text = ""
        GetData()
    End Sub


    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                If lblSet.Text = "Reservation_HallOrGarden" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    Me.Hide()
                    frmReservation_HallorGarden.Show()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmReservation_HallorGarden.txtID.Text = dr.Cells(0).Value.ToString()
                    frmReservation_HallorGarden.txtGuestID.Text = dr.Cells(1).Value.ToString()
                    frmReservation_HallorGarden.txtGuestName.Text = dr.Cells(2).Value.ToString()
                    frmReservation_HallorGarden.txtGender.Text = dr.Cells(3).Value.ToString()
                    frmReservation_HallorGarden.txtReligion.Text = dr.Cells(4).Value.ToString()
                    frmReservation_HallorGarden.txtOccupation.Text = dr.Cells(5).Value.ToString()
                    frmReservation_HallorGarden.txtGuestAddress.Text = dr.Cells(6).Value.ToString()
                    frmReservation_HallorGarden.txtGuestCity.Text = dr.Cells(7).Value.ToString()
                    frmReservation_HallorGarden.txtCountry.Text = dr.Cells(8).Value.ToString()
                    frmReservation_HallorGarden.txtGuestContactNo.Text = dr.Cells(9).Value.ToString()
                    frmReservation_HallorGarden.txtIDType.Text = dr.Cells(11).Value.ToString()
                    frmReservation_HallorGarden.txtIDNumber.Text = dr.Cells(12).Value.ToString()
                    lblSet.Text = ""
                End If
                If lblSet.Text = "Check In" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    Me.Hide()
                    frmCheckIN_Room.Show()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmCheckIN_Room.txtID.Text = dr.Cells(0).Value.ToString()
                    frmCheckIN_Room.txtGuestID.Text = dr.Cells(1).Value.ToString()
                    frmCheckIN_Room.txtGuestName.Text = dr.Cells(2).Value.ToString()
                    frmCheckIN_Room.txtGender.Text = dr.Cells(3).Value.ToString()
                    frmCheckIN_Room.txtReligion.Text = dr.Cells(4).Value.ToString()
                    frmCheckIN_Room.txtOccupation.Text = dr.Cells(5).Value.ToString()
                    frmCheckIN_Room.txtGuestAddress.Text = dr.Cells(6).Value.ToString()
                    frmCheckIN_Room.txtGuestCity.Text = dr.Cells(7).Value.ToString()
                    frmCheckIN_Room.txtCountry.Text = dr.Cells(8).Value.ToString()
                    frmCheckIN_Room.txtGuestContactNo.Text = dr.Cells(9).Value.ToString()
                    frmCheckIN_Room.txtIDType.Text = dr.Cells(11).Value.ToString()
                    frmCheckIN_Room.txtIDNumber.Text = dr.Cells(12).Value.ToString()
                    lblSet.Text = ""
                End If
                If lblSet.Text = "Reservation" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    Me.Hide()
                    frmReservation.Show()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmReservation.txtID.Text = dr.Cells(0).Value.ToString()
                    frmReservation.txtGuestID.Text = dr.Cells(1).Value.ToString()
                    frmReservation.txtGuestName.Text = dr.Cells(2).Value.ToString()
                    frmReservation.txtGender.Text = dr.Cells(3).Value.ToString()
                    frmReservation.txtReligion.Text = dr.Cells(4).Value.ToString()
                    frmReservation.txtOccupation.Text = dr.Cells(5).Value.ToString()
                    frmReservation.txtGuestAddress.Text = dr.Cells(6).Value.ToString()
                    frmReservation.txtGuestCity.Text = dr.Cells(7).Value.ToString()
                    frmReservation.txtCountry.Text = dr.Cells(8).Value.ToString()
                    frmReservation.txtGuestContactNo.Text = dr.Cells(9).Value.ToString()
                    frmReservation.txtIDType.Text = dr.Cells(11).Value.ToString()
                    frmReservation.txtIDNumber.Text = dr.Cells(12).Value.ToString()
                    lblSet.Text = ""
                End If
                If lblSet.Text = "Group Reservation" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    Me.Hide()
                    frmGroupReservation.Show()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmGroupReservation.txtID.Text = dr.Cells(0).Value.ToString()
                    frmGroupReservation.txtGuestID.Text = dr.Cells(1).Value.ToString()
                    frmGroupReservation.txtGuestName.Text = dr.Cells(2).Value.ToString()
                    'frmGroupReservation.txtGender.Text = dr.Cells(3).Value.ToString()
                    'frmGroupReservation.txtReligion.Text = dr.Cells(4).Value.ToString()
                    'frmGroupReservation.txtOccupation.Text = dr.Cells(5).Value.ToString()
                    ' frmGroupReservation.txtGuestAddress.Text = dr.Cells(6).Value.ToString()
                    ' frmGroupReservation.txtGuestCity.Text = dr.Cells(7).Value.ToString()
                    ' frmGroupReservation.txtCountry.Text = dr.Cells(8).Value.ToString()
                    frmGroupReservation.txtGuestContactNo.Text = dr.Cells(9).Value.ToString()
                    '  frmGroupReservation.txtIDType.Text = dr.Cells(11).Value.ToString()
                    '  frmGroupReservation.txtIDNumber.Text = dr.Cells(12).Value.ToString()
                    lblSet.Text = ""
                End If
                If lblSet.Text = "Group Invoice" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    Me.Hide()
                    frmGroupInv.Show()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmGroupInv.txtID.Text = dr.Cells(0).Value.ToString()
                    frmGroupInv.txtGuestName.Text = dr.Cells(2).Value.ToString()
                    lblSet.Text = ""
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


    Private Sub txtGuestName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGuestName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID) as [ID],RTRIM(GuestID)as [Guest ID],RTRIM(Guestname) as [Guest Name],RTRIM(Gender) as [Gender],RTRIM(Religion) as [Religion],RTRIM(Occupation) as [Company],RTRIM(address) as [Address],RTRIM(city) as [City],RTRIM(Country) as [Country],RTRIM(ContactNo) as [Contact No],RTRIM(Email) as [Email],RTRIM(IDType) as [ID Type],RTRIM(IDNumber) as [ID Number],RTRIM(Company) as [Company],RTRIM(Model) as [Model],RTRIM(VehicleNo) as [Vehicle No.],RTRIM(Color) as [Color],RTRIM(Notes) as [Notes] from Guest where GuestName like '%" & txtGuestName.Text & "%' order by GuestName", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCity_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCity.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID) as [ID],RTRIM(GuestID)as [Guest ID],RTRIM(Guestname) as [Guest Name],RTRIM(Gender) as [Gender],RTRIM(Religion) as [Religion],RTRIM(Occupation) as [Company],RTRIM(address) as [Address],RTRIM(city) as [City],RTRIM(Country) as [Country],RTRIM(ContactNo) as [Contact No],RTRIM(Email) as [Email],RTRIM(IDType) as [ID Type],RTRIM(IDNumber) as [ID Number],RTRIM(Company) as [Company],RTRIM(Model) as [Model],RTRIM(VehicleNo) as [Vehicle No.],RTRIM(Color) as [Color],RTRIM(Notes) as [Notes] from Guest where City like '%" & txtCity.Text & "%' order by GuestName", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtContactNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtContactNo.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID) as [ID],RTRIM(GuestID)as [Guest ID],RTRIM(Guestname) as [Guest Name],RTRIM(Gender) as [Gender],RTRIM(Religion) as [Religion],RTRIM(Occupation) as [Company],RTRIM(address) as [Address],RTRIM(city) as [City],RTRIM(Country) as [Country],RTRIM(ContactNo) as [Contact No],RTRIM(Email) as [Email],RTRIM(IDType) as [ID Type],RTRIM(IDNumber) as [ID Number],RTRIM(Company) as [Company],RTRIM(Model) as [Model],RTRIM(VehicleNo) as [Vehicle No.],RTRIM(Color) as [Color],RTRIM(Notes) as [Notes] from Guest where ContactNo like '%" & txtContactNo.Text & "%' order by GuestName", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReset_Click_1(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
