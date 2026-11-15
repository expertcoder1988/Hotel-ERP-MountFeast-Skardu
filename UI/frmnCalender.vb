Imports System.Data.SqlClient

Public Class frmnCalender
    Dim dtDates = New DataTable()
    Private Sub frmnCalender_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim dtBookings = New DataTable()

            Dim startDate = txtDateIn.Text
            Dim endDate = txtDateOut.Text
            Dim dt = Convert.ToDateTime(startDate)
            Dim currDate As DateTime = Convert.ToDateTime(startDate)

            Dim diff = Convert.ToDateTime(endDate) - Convert.ToDateTime(startDate)

            Dim drSeries As DataRow

            If IsNothing(dtDates) Then
                dtDates = New DataTable()
                dtDates.Columns.Add("RoomType")
                dtDates.Columns.Add("Room")

                For a = 1 To diff.TotalDays + 1
                    dtDates.Columns.Add(currDate.ToShortDateString)
                    currDate = dt.AddDays(a)
                Next
            Else
                dtDates.Columns.Add("RoomType")
                dtDates.Columns.Add("Room")

                For a = 1 To diff.TotalDays + 1
                    dtDates.Columns.Add(currDate.ToShortDateString)
                    currDate = dt.AddDays(a)
                Next
            End If


            con = New SqlConnection(cs)
            con.Open()
            Dim sql1 As String = "SELECT RTRIM(R.RoomType), RTRIM(R.RoomNo) FROM Room as R where R.active = 'Yes' order by R.RoomType"

            cmd = New SqlCommand(sql1, con)
            rdr = cmd.ExecuteReader()

            While (rdr.Read() = True)
                dtDates.Rows.Add(rdr(0), rdr(1))
            End While
            con.Close()

            For itm1 = 0 To dtDates.Rows.Count - 1
                For Each itm As DataColumn In dtDates.Columns
                    'For Each itm1 As DataRow In dtDates.Rows
                    If (itm.ToString <> "RoomType" And itm.ToString <> "Room") Then
                        drSeries = dtDates.Rows(itm1)
                        con = New SqlConnection(cs)
                        con.Open()
                        sql1 = "select status from Reservation r1 inner join room r2 on r1.RoomID = r2.R_ID where r2.RoomNo = '" & drSeries(1).ToString & "' and r1.datein = '" & itm.ToString() & "' "
                        cmd = New SqlCommand(sql1, con)
                        rdr = cmd.ExecuteReader()

                        While (rdr.Read() = True)
                            dtDates.Rows(itm1)(itm) = rdr(0)
                        End While
                        con.Close()

                    End If
                Next itm
            Next

            dgw.ClearSelection()
            dgw.Refresh()
            dgw.ScrollBars = ScrollBars.Both
            dgw.DataSource = dtDates


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        dtDates = Nothing
        dgw.DataSource = Nothing
        dgw.Refresh()
        Me.Close()
    End Sub

    Private Sub dgw_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgw.DataBindingComplete


        For i As Integer = 0 To dgw.Rows.Count - 1
            For ColNo As Integer = 2 To dgw.Columns.Count - 1
                If Not dgw.Rows(i).Cells(ColNo).Value Is DBNull.Value Then
                    If Trim(dgw.Rows(i).Cells(ColNo).Value) = "Reserved" Then
                        dgw.Rows(i).Cells(ColNo).Style.BackColor = Color.Red
                        dgw.Rows(i).Cells(ColNo).Style.ForeColor = Color.White
                    ElseIf Trim(dgw.Rows(i).Cells(ColNo).Value) = "Confirmed" Then
                        dgw.Rows(i).Cells(ColNo).Style.BackColor = Color.Blue
                        dgw.Rows(i).Cells(ColNo).Style.ForeColor = Color.White
                    ElseIf Trim(dgw.Rows(i).Cells(ColNo).Value) = "Checked Out" Then
                        dgw.Rows(i).Cells(ColNo).Style.BackColor = Color.Green
                        dgw.Rows(i).Cells(ColNo).Style.ForeColor = Color.White
                    End If
                End If
            Next
        Next

        'Dim roomType = ""
        'If Not dgw.Rows(0).Cells(0).Value Is DBNull.Value Then
        '    roomType = Trim(dgw.Rows(0).Cells(0).Value)
        'End If

        'For i As Integer = 0 To dgw.Rows.Count - 1
        '    If Not dgw.Rows(i).Cells(0).Value Is DBNull.Value Then
        '        If Trim(dgw.Rows(i).Cells(0).Value) = roomType Then
        '            dgw.Rows(i).Cells(0).Value = ""
        '        Else
        '            roomType = Trim(dgw.Rows(i).Cells(0).Value)
        '        End If
        '    End If
        'Next i
    End Sub
End Class