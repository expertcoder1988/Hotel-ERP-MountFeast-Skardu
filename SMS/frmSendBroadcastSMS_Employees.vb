Imports System
Imports System.IO
Imports System.Net
Imports System.Data.SqlClient

Public Class frmSendBroadcastSMS_Employees
    Dim st1, st2, st3 As String
    Sub Reset()
        listView1.Items.Clear()
        txtMessage.Text = ""
    End Sub

    Private Sub frmSendSMS_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(EmployeeID),RTRIM(Employeename),RTRIM(Designation),RTRIM(ContactNo) from EmployeeRegistration order by Employeename", con)
            rdr = cmd.ExecuteReader()
            listView1.Items.Clear()
            While rdr.Read()
                Dim item = New ListViewItem()
                item.Text = rdr(0).ToString().Trim()
                item.SubItems.Add(rdr(1).ToString().Trim())
                item.SubItems.Add(rdr(2).ToString().Trim())
                item.SubItems.Add(rdr(3).ToString().Trim())
                listView1.Items.Add(item)
            End While
            For i = 0 To listView1.Items.Count - 1
                listView1.Items(i).Checked = True
            Next

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSendSMS_Click(sender As System.Object, e As System.EventArgs) Handles btnSendSMS.Click
        Try
            If Len(Trim(txtMessage.Text)) = 0 Then
                MessageBox.Show("Please enter message", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtMessage.Focus()
                Exit Sub
            End If
            If listView1.Items.Count = 0 Then
                MessageBox.Show("Please retrieve employee's list", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If listView1.CheckedItems.Count = 0 Then
                MessageBox.Show("Please select at least one employee", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If CheckForInternetConnection() = True Then
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                con = New SqlConnection(cs)
                con.Open()
                Dim ctn As String = "select RTRIM(APIURL) from SMSSetting where IsDefault='Yes' and IsEnabled='Yes'"
                cmd = New SqlCommand(ctn)
                cmd.Connection = con
                Dim rdr1 As SqlDataReader = cmd.ExecuteReader()
                If rdr1.Read() Then
                    st2 = rdr1.GetValue(0)
                st1 = ""
                For i = 0 To listView1.Items.Count - 1
                    If listView1.Items(i).Checked = True Then
                        st1 += listView1.Items(i).SubItems(3).Text & "" & ","
                    End If
                Next
                st1 = st1.Trim().Remove(st1.Length - 1)
                SMSFunc(st1, txtMessage.Text, st2)
            End If
            End If
            Reset()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub btnReset_Click_1(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub
End Class