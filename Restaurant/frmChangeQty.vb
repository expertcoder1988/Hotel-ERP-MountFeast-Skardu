Public Class frmChangeQty
    Dim sign_Indicator As Integer = 0
    Dim variable1 As Double
    Dim variable2 As Double
    Dim fl As Boolean = False
    Dim s, x As String
    Private Sub btnOkay_Click(sender As System.Object, e As System.EventArgs) Handles btnOkay.Click
        Try
            If txtQty.Text = "" Then
                MessageBox.Show("Please enter the quantity", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtQty.Focus()
                Exit Sub
            End If
            If lblSet.Text = "Takeaway" Then
                If frmRestaurantPOS.DataGridView3.Rows.Count > 0 Then
                    Me.Hide()
                    Dim dr As DataGridViewRow = frmRestaurantPOS.DataGridView3.SelectedRows(0)
                    frmRestaurantPOS.txtFoodName.Text = dr.Cells(0).Value.ToString()
                    frmRestaurantPOS.txtRate_Food.Text = dr.Cells(1).Value.ToString()
                    frmRestaurantPOS.txtQty_Food.Text = Val(txtQty.Text)
                    frmRestaurantPOS.txtAmt_Food.Text = dr.Cells(3).Value.ToString()
                    frmRestaurantPOS.txtDiscountPer_Food.Text = dr.Cells(4).Value.ToString()
                    frmRestaurantPOS.txtDiscountAmount_Food.Text = dr.Cells(5).Value.ToString()
                    frmRestaurantPOS.txtServiceTaxPer_Food.Text = dr.Cells(6).Value.ToString()
                    frmRestaurantPOS.txtServiceTaxAmount_Food.Text = dr.Cells(7).Value.ToString()
                    frmRestaurantPOS.txtVATPer_Food.Text = dr.Cells(8).Value.ToString()
                    frmRestaurantPOS.txtVATAmt_Food.Text = dr.Cells(9).Value.ToString()
                    frmRestaurantPOS.txtTotalAmt_Food.Text = dr.Cells(10).Value.ToString()
                End If
                frmRestaurantPOS.Compute()
                For Each r As DataGridViewRow In frmRestaurantPOS.DataGridView3.SelectedRows
                    frmRestaurantPOS.DataGridView3.Rows.Remove(r)
                Next
                frmRestaurantPOS.DataGridView3.Rows.Add(frmRestaurantPOS.txtFoodName.Text, Val(frmRestaurantPOS.txtRate_Food.Text), Val(frmRestaurantPOS.txtQty_Food.Text), Val(frmRestaurantPOS.txtAmt_Food.Text), Val(frmRestaurantPOS.txtDiscountPer_Food.Text), Val(frmRestaurantPOS.txtDiscountAmount_Food.Text), Val(frmRestaurantPOS.txtServiceTaxPer_Food.Text), Val(frmRestaurantPOS.txtServiceTaxAmount_Food.Text), Val(frmRestaurantPOS.txtVATPer_Food.Text), Val(frmRestaurantPOS.txtVATAmt_Food.Text), Val(frmRestaurantPOS.txtTotalAmt_Food.Text), txtNotes.Text)
                Dim k As Double = 0
                k = frmRestaurantPOS.GrandTotal_Food2()
                k = Math.Round(k, 2)
                frmRestaurantPOS.lblBalance1.Text = k
                frmRestaurantPOS.txtSubTotal1.Text = k
                frmRestaurantPOS.Clear1()
                txtQty.Text = ""
                txtNotes.Text = ""
            End If

            If lblSet.Text = "Home Delivery" Then
                If frmRestaurantPOS.DataGridView4.Rows.Count > 0 Then
                    Me.Hide()
                    Dim dr As DataGridViewRow = frmRestaurantPOS.DataGridView4.SelectedRows(0)
                    frmRestaurantPOS.txtFoodName.Text = dr.Cells(0).Value.ToString()
                    frmRestaurantPOS.txtRate_Food.Text = dr.Cells(1).Value.ToString()
                    frmRestaurantPOS.txtQty_Food.Text = Val(txtQty.Text)
                    frmRestaurantPOS.txtAmt_Food.Text = dr.Cells(3).Value.ToString()
                    frmRestaurantPOS.txtDiscountPer_Food.Text = dr.Cells(4).Value.ToString()
                    frmRestaurantPOS.txtDiscountAmount_Food.Text = dr.Cells(5).Value.ToString()
                    frmRestaurantPOS.txtServiceTaxPer_Food.Text = dr.Cells(6).Value.ToString()
                    frmRestaurantPOS.txtServiceTaxAmount_Food.Text = dr.Cells(7).Value.ToString()
                    frmRestaurantPOS.txtVATPer_Food.Text = dr.Cells(8).Value.ToString()
                    frmRestaurantPOS.txtVATAmt_Food.Text = dr.Cells(9).Value.ToString()
                    frmRestaurantPOS.txtTotalAmt_Food.Text = dr.Cells(10).Value.ToString()
                End If
                frmRestaurantPOS.Compute()
                For Each r As DataGridViewRow In frmRestaurantPOS.DataGridView4.SelectedRows
                    frmRestaurantPOS.DataGridView4.Rows.Remove(r)
                Next
                frmRestaurantPOS.DataGridView4.Rows.Add(frmRestaurantPOS.txtFoodName.Text, Val(frmRestaurantPOS.txtRate_Food.Text), Val(frmRestaurantPOS.txtQty_Food.Text), Val(frmRestaurantPOS.txtAmt_Food.Text), Val(frmRestaurantPOS.txtDiscountPer_Food.Text), Val(frmRestaurantPOS.txtDiscountAmount_Food.Text), Val(frmRestaurantPOS.txtServiceTaxPer_Food.Text), Val(frmRestaurantPOS.txtServiceTaxAmount_Food.Text), Val(frmRestaurantPOS.txtVATPer_Food.Text), Val(frmRestaurantPOS.txtVATAmt_Food.Text), Val(frmRestaurantPOS.txtTotalAmt_Food.Text), txtNotes.Text)
                Dim k As Double = 0
                k = frmRestaurantPOS.GrandTotal_Food3()
                k = Math.Round(k, 2)
                frmRestaurantPOS.lblBalance2.Text = k
                frmRestaurantPOS.txtSubTotal.Text = k
                frmRestaurantPOS.Clear1()
                txtQty.Text = ""
                txtNotes.Text = ""
            End If
            If lblSet.Text = "KOT" Then
                If frmRestaurantPOS.DataGridView1.Rows.Count > 0 Then
                    Me.Hide()
                    Dim dr As DataGridViewRow = frmRestaurantPOS.DataGridView1.SelectedRows(0)
                    frmRestaurantPOS.txtFoodName.Text = dr.Cells(0).Value.ToString()
                    frmRestaurantPOS.txtRate_Food.Text = dr.Cells(1).Value.ToString()
                    frmRestaurantPOS.txtQty_Food.Text = Val(txtQty.Text)
                    frmRestaurantPOS.txtAmt_Food.Text = dr.Cells(3).Value.ToString()
                    frmRestaurantPOS.txtDiscountPer_Food.Text = dr.Cells(4).Value.ToString()
                    frmRestaurantPOS.txtDiscountAmount_Food.Text = dr.Cells(5).Value.ToString()
                    frmRestaurantPOS.txtServiceTaxPer_Food.Text = dr.Cells(6).Value.ToString()
                    frmRestaurantPOS.txtServiceTaxAmount_Food.Text = dr.Cells(7).Value.ToString()
                    frmRestaurantPOS.txtVATPer_Food.Text = dr.Cells(8).Value.ToString()
                    frmRestaurantPOS.txtVATAmt_Food.Text = dr.Cells(9).Value.ToString()
                    frmRestaurantPOS.txtTotalAmt_Food.Text = dr.Cells(10).Value.ToString()
                End If
                frmRestaurantPOS.Compute()
                For Each r As DataGridViewRow In frmRestaurantPOS.DataGridView1.SelectedRows
                    frmRestaurantPOS.DataGridView1.Rows.Remove(r)
                Next
                frmRestaurantPOS.DataGridView1.Rows.Add(frmRestaurantPOS.txtFoodName.Text, Val(frmRestaurantPOS.txtRate_Food.Text), Val(frmRestaurantPOS.txtQty_Food.Text), Val(frmRestaurantPOS.txtAmt_Food.Text), Val(frmRestaurantPOS.txtDiscountPer_Food.Text), Val(frmRestaurantPOS.txtDiscountAmount_Food.Text), Val(frmRestaurantPOS.txtServiceTaxPer_Food.Text), Val(frmRestaurantPOS.txtServiceTaxAmount_Food.Text), Val(frmRestaurantPOS.txtVATPer_Food.Text), Val(frmRestaurantPOS.txtVATAmt_Food.Text), Val(frmRestaurantPOS.txtTotalAmt_Food.Text), txtNotes.Text)
                Dim k As Double = 0
                k = frmRestaurantPOS.GrandTotal_Food()
                k = Math.Round(k, 2)
                frmRestaurantPOS.lblBalance.Text = k
                frmRestaurantPOS.Clear()
                txtQty.Text = ""
                txtNotes.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub txtRate_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub frmChangeRate_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnTA1_Click(sender As System.Object, e As System.EventArgs) Handles btnTA1.Click
        If sign_Indicator = 0 Then
            txtQty.Text = txtQty.Text + Convert.ToString(1)
        ElseIf sign_Indicator = 1 Then
            txtQty.Text = Convert.ToString(1)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA2_Click(sender As System.Object, e As System.EventArgs) Handles btnTA2.Click
        If sign_Indicator = 0 Then
            txtQty.Text = txtQty.Text + Convert.ToString(2)
        ElseIf sign_Indicator = 1 Then
            txtQty.Text = Convert.ToString(2)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA3_Click(sender As System.Object, e As System.EventArgs) Handles btnTA3.Click
        If sign_Indicator = 0 Then
            txtQty.Text = txtQty.Text + Convert.ToString(3)
        ElseIf sign_Indicator = 1 Then
            txtQty.Text = Convert.ToString(3)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA4_Click(sender As System.Object, e As System.EventArgs) Handles btnTA4.Click
        If sign_Indicator = 0 Then
            txtQty.Text = txtQty.Text + Convert.ToString(4)
        ElseIf sign_Indicator = 1 Then
            txtQty.Text = Convert.ToString(4)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA5_Click(sender As System.Object, e As System.EventArgs) Handles btnTA5.Click
        If sign_Indicator = 0 Then
            txtQty.Text = txtQty.Text + Convert.ToString(5)
        ElseIf sign_Indicator = 1 Then
            txtQty.Text = Convert.ToString(5)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA6_Click(sender As System.Object, e As System.EventArgs) Handles btnTA6.Click
        If sign_Indicator = 0 Then
            txtQty.Text = txtQty.Text + Convert.ToString(6)
        ElseIf sign_Indicator = 1 Then
            txtQty.Text = Convert.ToString(6)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA7_Click(sender As System.Object, e As System.EventArgs) Handles btnTA7.Click
        If sign_Indicator = 0 Then
            txtQty.Text = txtQty.Text + Convert.ToString(7)
        ElseIf sign_Indicator = 1 Then
            txtQty.Text = Convert.ToString(7)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA8_Click(sender As System.Object, e As System.EventArgs) Handles btnTA8.Click
        If sign_Indicator = 0 Then
            txtQty.Text = txtQty.Text + Convert.ToString(8)
        ElseIf sign_Indicator = 1 Then
            txtQty.Text = Convert.ToString(8)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA9_Click(sender As System.Object, e As System.EventArgs) Handles btnTA9.Click
        If sign_Indicator = 0 Then
            txtQty.Text = txtQty.Text + Convert.ToString(9)
        ElseIf sign_Indicator = 1 Then
            txtQty.Text = Convert.ToString(9)
            sign_Indicator = 0
        End If
        fl = True
    End Sub


    Private Sub btnTA0_Click(sender As System.Object, e As System.EventArgs) Handles btnTA0.Click
        If sign_Indicator = 0 Then
            txtQty.Text = txtQty.Text + Convert.ToString(0)
        ElseIf sign_Indicator = 1 Then
            txtQty.Text = Convert.ToString(0)
            sign_Indicator = 0
        End If
        fl = True
    End Sub


    Private Sub btnX_Click(sender As System.Object, e As System.EventArgs) Handles btnX.Click
        s = txtQty.Text
        Dim l As Integer = s.Length
        For i As Integer = 0 To l - 2
            x += s(i)
        Next
        txtQty.Text = x
        x = ""
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        txtQty.Text = ""
    End Sub
End Class