Imports System.Data.SqlClient
Public Class frmAvailableTables
    Dim UserButtons As List(Of Button) = New List(Of Button)
    Private Sub frmAvailableTables_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        con = New SqlConnection(cs)
        con.Open()
        Dim cmdText1 As String = "SELECT distinct RTRIM(R_Table.TableNo),BkColor from R_Table where BkColor=@d1 and Status='Activate'"
        cmd = New SqlCommand(cmdText1)
        cmd.Parameters.AddWithValue("@d1", Color.LightGreen.ToArgb())
        cmd.Connection = con
        rdr = cmd.ExecuteReader()
        FlowLayoutPanel3.Controls.Clear()
        Do While (rdr.Read())
            Dim btn As New Button
            btn.Text = rdr.GetValue(0)
            btn.TextAlign = ContentAlignment.MiddleCenter
            Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
            btn.BackColor = btnColor
            btn.FlatStyle = FlatStyle.Popup
            btn.Width = 80
            btn.Height = 40
            btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            UserButtons.Add(btn)
            FlowLayoutPanel3.Controls.Add(btn)
            AddHandler btn.Click, AddressOf Me.Button2_Click
        Loop
        con.Close()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text.Trim()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update RestaurantPOS_OrderInfoKOT set TableNo=@d1 where TableNo=@d2"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", str)
            cmd.Parameters.AddWithValue("@d2", lblTable.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cl As String = "Update TempRestaurantPOS_OrderInfoKOT set TableNo=@d1 where TableNo=@d2"
            cmd = New SqlCommand(cl)
            cmd.Parameters.AddWithValue("@d1", str)
            cmd.Parameters.AddWithValue("@d2", lblTable.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cbX As String = "Update R_Table set BkColor=@d2 where TableNo=@d1"
            cmd = New SqlCommand(cbX)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", str)
            cmd.Parameters.AddWithValue("@d2", Color.Red.ToArgb())
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cbX1 As String = "Update R_Table set BkColor=@d2 where TableNo=@d1"
            cmd = New SqlCommand(cbX1)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", lblTable.Text)
            cmd.Parameters.AddWithValue("@d2", Color.LightGreen.ToArgb())
            cmd.ExecuteReader()
            con.Close()
            MessageBox.Show("Successfully changed", "Table", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Hide()
            frmRestaurantPOS.FillAvailableTables()
            frmRestaurantPOS.fillTableNo()
            frmRestaurantPOS.lblTableNo.Text = ""
            frmRestaurantPOS.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
End Class