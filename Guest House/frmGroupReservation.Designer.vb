<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGroupReservation
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Label12 As System.Windows.Forms.Label
        Dim FolioNumberLabel As System.Windows.Forms.Label
        Dim Label21 As System.Windows.Forms.Label
        Dim Label23 As System.Windows.Forms.Label
        Dim Label20 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label53 As System.Windows.Forms.Label
        Dim Label52 As System.Windows.Forms.Label
        Dim Label33 As System.Windows.Forms.Label
        Dim Label47 As System.Windows.Forms.Label
        Dim Label22 As System.Windows.Forms.Label
        Dim DateOutLabel As System.Windows.Forms.Label
        Dim DateInLabel As System.Windows.Forms.Label
        Dim RoomNumberLabel As System.Windows.Forms.Label
        Dim Label51 As System.Windows.Forms.Label
        Dim Label50 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label14 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label15 As System.Windows.Forms.Label
        Dim Label48 As System.Windows.Forms.Label
        Dim Label49 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGroupReservation))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.btnCheckOut = New System.Windows.Forms.Button()
        Me.btnCheckedIN = New System.Windows.Forms.Button()
        Me.btnCancelReservationReceipt = New System.Windows.Forms.Button()
        Me.btnCancelReservation = New System.Windows.Forms.Button()
        Me.txtGroupTax = New System.Windows.Forms.TextBox()
        Me.txtGuestContactNo = New System.Windows.Forms.TextBox()
        Me.txti2 = New System.Windows.Forms.TextBox()
        Me.txti1 = New System.Windows.Forms.TextBox()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.txtReservationID = New System.Windows.Forms.TextBox()
        Me.txtRoomID = New System.Windows.Forms.TextBox()
        Me.cmbRoomNo1 = New System.Windows.Forms.ComboBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtGuestEnterHere = New System.Windows.Forms.TextBox()
        Me.txtExtraBedC = New System.Windows.Forms.TextBox()
        Me.txtExtraPersonC = New System.Windows.Forms.TextBox()
        Me.txtRoomType = New System.Windows.Forms.TextBox()
        Me.txtCheckInID = New System.Windows.Forms.TextBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtTotalRoomCharges = New System.Windows.Forms.TextBox()
        Me.txtDiscountAmount = New System.Windows.Forms.TextBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.txtGrandTotal = New System.Windows.Forms.TextBox()
        Me.txtServiceTaxPer = New System.Windows.Forms.TextBox()
        Me.txtExtraPersonCharges = New System.Windows.Forms.TextBox()
        Me.txtExtraBedCharges = New System.Windows.Forms.TextBox()
        Me.txtLuxuryTaxAmount = New System.Windows.Forms.TextBox()
        Me.txtSubTotal = New System.Windows.Forms.TextBox()
        Me.txtLuxuryTaxPer = New System.Windows.Forms.TextBox()
        Me.txtDiscountPer = New System.Windows.Forms.TextBox()
        Me.txtServiceTaxAmount = New System.Windows.Forms.TextBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.RoomID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RoomNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExtraPersonCharges = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExtraBedCharges = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RoomCharges = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiscountAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalRoomCharges = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnListReset1 = New System.Windows.Forms.Button()
        Me.btnListUpdate1 = New System.Windows.Forms.Button()
        Me.dtpPaymentDate = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtPayment = New System.Windows.Forms.TextBox()
        Me.cmbPaymentMode = New System.Windows.Forms.ComboBox()
        Me.btnRemove1 = New System.Windows.Forms.Button()
        Me.btnAdd1 = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtGroupBalance = New System.Windows.Forms.TextBox()
        Me.GroupBoxRateInfo = New System.Windows.Forms.GroupBox()
        Me.txtRoomOrderCharges = New System.Windows.Forms.TextBox()
        Me.txtLaundryCharges = New System.Windows.Forms.TextBox()
        Me.btnAddRooms = New System.Windows.Forms.Button()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.txtPlanName = New System.Windows.Forms.TextBox()
        Me.cmbPlanCode = New System.Windows.Forms.ComboBox()
        Me.txtGuestLedgerID = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.hsExtraBed = New System.Windows.Forms.HScrollBar()
        Me.hsExtraPerson = New System.Windows.Forms.HScrollBar()
        Me.hsKids = New System.Windows.Forms.HScrollBar()
        Me.txtNoOfExtraBed = New System.Windows.Forms.TextBox()
        Me.txtNoOfExtraPerson = New System.Windows.Forms.TextBox()
        Me.txtNoOfKids = New System.Windows.Forms.TextBox()
        Me.txtNoOfDays = New System.Windows.Forms.TextBox()
        Me.txtRoomCharges = New System.Windows.Forms.TextBox()
        Me.hsFemales = New System.Windows.Forms.HScrollBar()
        Me.txtNoOfFemales = New System.Windows.Forms.TextBox()
        Me.txtNoOfMales = New System.Windows.Forms.TextBox()
        Me.dtpDateOut = New System.Windows.Forms.DateTimePicker()
        Me.cmbRoomNo = New System.Windows.Forms.ComboBox()
        Me.hsMales = New System.Windows.Forms.HScrollBar()
        Me.dtpDateIn = New System.Windows.Forms.DateTimePicker()
        Me.txtGroupTotal = New System.Windows.Forms.TextBox()
        Me.GroupBoxGuestInfo = New System.Windows.Forms.GroupBox()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.txtGuestName = New System.Windows.Forms.TextBox()
        Me.txtGuestID = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dtpReservationDate = New System.Windows.Forms.DateTimePicker()
        Me.txtReservationNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBalance = New System.Windows.Forms.TextBox()
        Me.txtTotalPaid = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtBillNo = New System.Windows.Forms.TextBox()
        Me.txtBillID = New System.Windows.Forms.TextBox()
        Me.txtSaved = New System.Windows.Forms.TextBox()
        Label12 = New System.Windows.Forms.Label()
        FolioNumberLabel = New System.Windows.Forms.Label()
        Label21 = New System.Windows.Forms.Label()
        Label23 = New System.Windows.Forms.Label()
        Label20 = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label53 = New System.Windows.Forms.Label()
        Label52 = New System.Windows.Forms.Label()
        Label33 = New System.Windows.Forms.Label()
        Label47 = New System.Windows.Forms.Label()
        Label22 = New System.Windows.Forms.Label()
        DateOutLabel = New System.Windows.Forms.Label()
        DateInLabel = New System.Windows.Forms.Label()
        RoomNumberLabel = New System.Windows.Forms.Label()
        Label51 = New System.Windows.Forms.Label()
        Label50 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Label14 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label15 = New System.Windows.Forms.Label()
        Label48 = New System.Windows.Forms.Label()
        Label49 = New System.Windows.Forms.Label()
        Label8 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBoxRateInfo.SuspendLayout()
        Me.GroupBoxGuestInfo.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label12
        '
        Label12.AutoSize = True
        Label12.ForeColor = System.Drawing.Color.Black
        Label12.Location = New System.Drawing.Point(15, 59)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(95, 17)
        Label12.TabIndex = 271
        Label12.Text = "Guest Name :"
        '
        'FolioNumberLabel
        '
        FolioNumberLabel.AutoSize = True
        FolioNumberLabel.ForeColor = System.Drawing.Color.Black
        FolioNumberLabel.Location = New System.Drawing.Point(15, 28)
        FolioNumberLabel.Name = "FolioNumberLabel"
        FolioNumberLabel.Size = New System.Drawing.Size(71, 17)
        FolioNumberLabel.TabIndex = 261
        FolioNumberLabel.Text = "Guest ID :"
        '
        'Label21
        '
        Label21.AutoSize = True
        Label21.ForeColor = System.Drawing.Color.Black
        Label21.Location = New System.Drawing.Point(672, 698)
        Label21.Name = "Label21"
        Label21.Size = New System.Drawing.Size(111, 17)
        Label21.TabIndex = 335
        Label21.Text = "Group Balance :"
        '
        'Label23
        '
        Label23.AutoSize = True
        Label23.ForeColor = System.Drawing.Color.Black
        Label23.Location = New System.Drawing.Point(673, 726)
        Label23.Name = "Label23"
        Label23.Size = New System.Drawing.Size(92, 17)
        Label23.TabIndex = 334
        Label23.Text = "Group Total :"
        '
        'Label20
        '
        Label20.AutoSize = True
        Label20.ForeColor = System.Drawing.Color.Black
        Label20.Location = New System.Drawing.Point(19, 58)
        Label20.Name = "Label20"
        Label20.Size = New System.Drawing.Size(81, 17)
        Label20.TabIndex = 328
        Label20.Text = "Plan Code :"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.ForeColor = System.Drawing.Color.Black
        Label7.Location = New System.Drawing.Point(273, 180)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(93, 17)
        Label7.TabIndex = 316
        Label7.Text = "No. Of Days :"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.ForeColor = System.Drawing.Color.Black
        Label6.Location = New System.Drawing.Point(19, 178)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(122, 17)
        Label6.TabIndex = 315
        Label6.Text = "No. Of Extra Bed :"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.ForeColor = System.Drawing.Color.Black
        Label5.Location = New System.Drawing.Point(273, 151)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(142, 17)
        Label5.TabIndex = 314
        Label5.Text = "No. Of Extra Person :"
        '
        'Label53
        '
        Label53.AutoSize = True
        Label53.ForeColor = System.Drawing.Color.Black
        Label53.Location = New System.Drawing.Point(359, 728)
        Label53.Name = "Label53"
        Label53.Size = New System.Drawing.Size(67, 17)
        Label53.TabIndex = 301
        Label53.Text = "Balance :"
        Label53.Visible = False
        '
        'Label52
        '
        Label52.AutoSize = True
        Label52.ForeColor = System.Drawing.Color.Black
        Label52.Location = New System.Drawing.Point(673, 668)
        Label52.Name = "Label52"
        Label52.Size = New System.Drawing.Size(80, 17)
        Label52.TabIndex = 299
        Label52.Text = "Total Paid :"
        '
        'Label33
        '
        Label33.AutoSize = True
        Label33.ForeColor = System.Drawing.Color.Black
        Label33.Location = New System.Drawing.Point(19, 149)
        Label33.Name = "Label33"
        Label33.Size = New System.Drawing.Size(88, 17)
        Label33.TabIndex = 279
        Label33.Text = "No. Of Kids :"
        '
        'Label47
        '
        Label47.AutoSize = True
        Label47.ForeColor = System.Drawing.Color.Black
        Label47.Location = New System.Drawing.Point(273, 118)
        Label47.Name = "Label47"
        Label47.Size = New System.Drawing.Size(114, 17)
        Label47.TabIndex = 276
        Label47.Text = "No. Of Females :"
        '
        'Label22
        '
        Label22.AutoSize = True
        Label22.ForeColor = System.Drawing.Color.Black
        Label22.Location = New System.Drawing.Point(19, 120)
        Label22.Name = "Label22"
        Label22.Size = New System.Drawing.Size(98, 17)
        Label22.TabIndex = 274
        Label22.Text = "No. Of Males :"
        '
        'DateOutLabel
        '
        DateOutLabel.AutoSize = True
        DateOutLabel.ForeColor = System.Drawing.Color.Black
        DateOutLabel.Location = New System.Drawing.Point(273, 87)
        DateOutLabel.Name = "DateOutLabel"
        DateOutLabel.Size = New System.Drawing.Size(73, 17)
        DateOutLabel.TabIndex = 249
        DateOutLabel.Text = "Date Out :"
        '
        'DateInLabel
        '
        DateInLabel.AutoSize = True
        DateInLabel.ForeColor = System.Drawing.Color.Black
        DateInLabel.Location = New System.Drawing.Point(19, 91)
        DateInLabel.Name = "DateInLabel"
        DateInLabel.Size = New System.Drawing.Size(61, 17)
        DateInLabel.TabIndex = 247
        DateInLabel.Text = "Date In :"
        '
        'RoomNumberLabel
        '
        RoomNumberLabel.AutoSize = True
        RoomNumberLabel.ForeColor = System.Drawing.Color.Black
        RoomNumberLabel.Location = New System.Drawing.Point(19, 28)
        RoomNumberLabel.Name = "RoomNumberLabel"
        RoomNumberLabel.Size = New System.Drawing.Size(79, 17)
        RoomNumberLabel.TabIndex = 235
        RoomNumberLabel.Text = "Room No. :"
        '
        'Label51
        '
        Label51.AutoSize = True
        Label51.ForeColor = System.Drawing.Color.Black
        Label51.Location = New System.Drawing.Point(23, 205)
        Label51.Name = "Label51"
        Label51.Size = New System.Drawing.Size(92, 17)
        Label51.TabIndex = 341
        Label51.Text = "Grand Total :"
        Label51.Visible = False
        '
        'Label50
        '
        Label50.AutoSize = True
        Label50.ForeColor = System.Drawing.Color.Black
        Label50.Location = New System.Drawing.Point(23, 248)
        Label50.Name = "Label50"
        Label50.Size = New System.Drawing.Size(77, 17)
        Label50.TabIndex = 340
        Label50.Text = "Sub Total :"
        Label50.Visible = False
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.ForeColor = System.Drawing.Color.Black
        Label4.Location = New System.Drawing.Point(22, 188)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(146, 17)
        Label4.TabIndex = 336
        Label4.Text = "Total Room Charges :"
        Label4.Visible = False
        '
        'Label14
        '
        Label14.AutoSize = True
        Label14.ForeColor = System.Drawing.Color.Black
        Label14.Location = New System.Drawing.Point(24, 171)
        Label14.Name = "Label14"
        Label14.Size = New System.Drawing.Size(134, 17)
        Label14.TabIndex = 345
        Label14.Text = "Extra Bed Charges :"
        Label14.Visible = False
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.ForeColor = System.Drawing.Color.Black
        Label2.Location = New System.Drawing.Point(25, 44)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(71, 17)
        Label2.TabIndex = 337
        Label2.Text = "Discount :"
        '
        'Label15
        '
        Label15.AutoSize = True
        Label15.ForeColor = System.Drawing.Color.Black
        Label15.Location = New System.Drawing.Point(22, 218)
        Label15.Name = "Label15"
        Label15.Size = New System.Drawing.Size(154, 17)
        Label15.TabIndex = 346
        Label15.Text = "Extra Person Charges :"
        Label15.Visible = False
        '
        'Label48
        '
        Label48.AutoSize = True
        Label48.ForeColor = System.Drawing.Color.Black
        Label48.Location = New System.Drawing.Point(25, 74)
        Label48.Name = "Label48"
        Label48.Size = New System.Drawing.Size(80, 17)
        Label48.TabIndex = 338
        Label48.Text = "KPRA Tax :"
        '
        'Label49
        '
        Label49.AutoSize = True
        Label49.ForeColor = System.Drawing.Color.Black
        Label49.Location = New System.Drawing.Point(24, 105)
        Label49.Name = "Label49"
        Label49.Size = New System.Drawing.Size(94, 17)
        Label49.TabIndex = 339
        Label49.Text = "Other Taxes :"
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.ForeColor = System.Drawing.Color.Black
        Label8.Location = New System.Drawing.Point(673, 638)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(75, 17)
        Label8.TabIndex = 360
        Label8.Text = "Total Tax :"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.TextBox5)
        Me.Panel1.Controls.Add(Me.TextBox4)
        Me.Panel1.Controls.Add(Me.btnCheckOut)
        Me.Panel1.Controls.Add(Me.btnCheckedIN)
        Me.Panel1.Controls.Add(Me.btnCancelReservationReceipt)
        Me.Panel1.Controls.Add(Me.btnCancelReservation)
        Me.Panel1.Controls.Add(Me.txtGroupTax)
        Me.Panel1.Controls.Add(Label8)
        Me.Panel1.Controls.Add(Me.txtGuestContactNo)
        Me.Panel1.Controls.Add(Me.txti2)
        Me.Panel1.Controls.Add(Me.txti1)
        Me.Panel1.Controls.Add(Me.lblUser)
        Me.Panel1.Controls.Add(Me.txtReservationID)
        Me.Panel1.Controls.Add(Me.txtRoomID)
        Me.Panel1.Controls.Add(Me.cmbRoomNo1)
        Me.Panel1.Controls.Add(Me.lblStatus)
        Me.Panel1.Controls.Add(Me.txtGuestEnterHere)
        Me.Panel1.Controls.Add(Me.txtExtraBedC)
        Me.Panel1.Controls.Add(Me.txtExtraPersonC)
        Me.Panel1.Controls.Add(Me.txtRoomType)
        Me.Panel1.Controls.Add(Me.txtCheckInID)
        Me.Panel1.Controls.Add(Me.txtID)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.btnPrint)
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.btnNew)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.DataGridView2)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.txtGroupBalance)
        Me.Panel1.Controls.Add(Me.GroupBoxRateInfo)
        Me.Panel1.Controls.Add(Me.txtGroupTotal)
        Me.Panel1.Controls.Add(Me.GroupBoxGuestInfo)
        Me.Panel1.Controls.Add(Label21)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Label23)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Label52)
        Me.Panel1.Controls.Add(Me.txtBalance)
        Me.Panel1.Controls.Add(Label53)
        Me.Panel1.Controls.Add(Me.txtTotalPaid)
        Me.Panel1.Location = New System.Drawing.Point(9, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1292, 754)
        Me.Panel1.TabIndex = 0
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(540, 631)
        Me.TextBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(111, 22)
        Me.TextBox4.TabIndex = 365
        Me.TextBox4.Text = "0"
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox4.Visible = False
        '
        'btnCheckOut
        '
        Me.btnCheckOut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCheckOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckOut.Image = CType(resources.GetObject("btnCheckOut.Image"), System.Drawing.Image)
        Me.btnCheckOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCheckOut.Location = New System.Drawing.Point(429, 686)
        Me.btnCheckOut.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCheckOut.Name = "btnCheckOut"
        Me.btnCheckOut.Size = New System.Drawing.Size(172, 57)
        Me.btnCheckOut.TabIndex = 364
        Me.btnCheckOut.Text = "Check Out"
        Me.btnCheckOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCheckOut.UseVisualStyleBackColor = True
        Me.btnCheckOut.Visible = False
        '
        'btnCheckedIN
        '
        Me.btnCheckedIN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCheckedIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckedIN.Image = CType(resources.GetObject("btnCheckedIN.Image"), System.Drawing.Image)
        Me.btnCheckedIN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCheckedIN.Location = New System.Drawing.Point(429, 630)
        Me.btnCheckedIN.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCheckedIN.Name = "btnCheckedIN"
        Me.btnCheckedIN.Size = New System.Drawing.Size(172, 52)
        Me.btnCheckedIN.TabIndex = 363
        Me.btnCheckedIN.Text = "&Check IN"
        Me.btnCheckedIN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCheckedIN.UseVisualStyleBackColor = True
        Me.btnCheckedIN.Visible = False
        '
        'btnCancelReservationReceipt
        '
        Me.btnCancelReservationReceipt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancelReservationReceipt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelReservationReceipt.Enabled = False
        Me.btnCancelReservationReceipt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelReservationReceipt.Image = Global.Hotel_Management_System.My.Resources.Resources.Printer_icon
        Me.btnCancelReservationReceipt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelReservationReceipt.Location = New System.Drawing.Point(282, 686)
        Me.btnCancelReservationReceipt.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancelReservationReceipt.Name = "btnCancelReservationReceipt"
        Me.btnCancelReservationReceipt.Size = New System.Drawing.Size(141, 57)
        Me.btnCancelReservationReceipt.TabIndex = 362
        Me.btnCancelReservationReceipt.Text = "Cancel " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Receipt"
        Me.btnCancelReservationReceipt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelReservationReceipt.UseVisualStyleBackColor = True
        '
        'btnCancelReservation
        '
        Me.btnCancelReservation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancelReservation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelReservation.Enabled = False
        Me.btnCancelReservation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelReservation.Image = CType(resources.GetObject("btnCancelReservation.Image"), System.Drawing.Image)
        Me.btnCancelReservation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelReservation.Location = New System.Drawing.Point(282, 630)
        Me.btnCancelReservation.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancelReservation.Name = "btnCancelReservation"
        Me.btnCancelReservation.Size = New System.Drawing.Size(141, 51)
        Me.btnCancelReservation.TabIndex = 361
        Me.btnCancelReservation.Text = "&Cancel" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Reservation"
        Me.btnCancelReservation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelReservation.UseVisualStyleBackColor = True
        '
        'txtGroupTax
        '
        Me.txtGroupTax.Location = New System.Drawing.Point(784, 633)
        Me.txtGroupTax.Margin = New System.Windows.Forms.Padding(4)
        Me.txtGroupTax.Name = "txtGroupTax"
        Me.txtGroupTax.ReadOnly = True
        Me.txtGroupTax.Size = New System.Drawing.Size(99, 22)
        Me.txtGroupTax.TabIndex = 359
        Me.txtGroupTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGuestContactNo
        '
        Me.txtGuestContactNo.Location = New System.Drawing.Point(553, 659)
        Me.txtGuestContactNo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtGuestContactNo.Name = "txtGuestContactNo"
        Me.txtGuestContactNo.Size = New System.Drawing.Size(86, 22)
        Me.txtGuestContactNo.TabIndex = 358
        Me.txtGuestContactNo.Visible = False
        '
        'txti2
        '
        Me.txti2.Location = New System.Drawing.Point(318, 657)
        Me.txti2.Margin = New System.Windows.Forms.Padding(4)
        Me.txti2.Name = "txti2"
        Me.txti2.Size = New System.Drawing.Size(47, 22)
        Me.txti2.TabIndex = 357
        Me.txti2.Visible = False
        '
        'txti1
        '
        Me.txti1.Location = New System.Drawing.Point(318, 627)
        Me.txti1.Margin = New System.Windows.Forms.Padding(4)
        Me.txti1.Name = "txti1"
        Me.txti1.Size = New System.Drawing.Size(47, 22)
        Me.txti1.TabIndex = 356
        Me.txti1.Visible = False
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(550, 686)
        Me.lblUser.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(51, 17)
        Me.lblUser.TabIndex = 355
        Me.lblUser.Text = "Label8"
        Me.lblUser.Visible = False
        '
        'txtReservationID
        '
        Me.txtReservationID.Location = New System.Drawing.Point(624, 677)
        Me.txtReservationID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtReservationID.Name = "txtReservationID"
        Me.txtReservationID.Size = New System.Drawing.Size(36, 22)
        Me.txtReservationID.TabIndex = 354
        Me.txtReservationID.Visible = False
        '
        'txtRoomID
        '
        Me.txtRoomID.Location = New System.Drawing.Point(540, 728)
        Me.txtRoomID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRoomID.Name = "txtRoomID"
        Me.txtRoomID.Size = New System.Drawing.Size(85, 22)
        Me.txtRoomID.TabIndex = 353
        Me.txtRoomID.Visible = False
        '
        'cmbRoomNo1
        '
        Me.cmbRoomNo1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbRoomNo1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRoomNo1.FormattingEnabled = True
        Me.cmbRoomNo1.Location = New System.Drawing.Point(648, 721)
        Me.cmbRoomNo1.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbRoomNo1.Name = "cmbRoomNo1"
        Me.cmbRoomNo1.Size = New System.Drawing.Size(23, 24)
        Me.cmbRoomNo1.TabIndex = 352
        Me.cmbRoomNo1.Visible = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(585, 638)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(48, 17)
        Me.lblStatus.TabIndex = 351
        Me.lblStatus.Text = "Status"
        Me.lblStatus.Visible = False
        '
        'txtGuestEnterHere
        '
        Me.txtGuestEnterHere.Location = New System.Drawing.Point(434, 633)
        Me.txtGuestEnterHere.Margin = New System.Windows.Forms.Padding(4)
        Me.txtGuestEnterHere.Name = "txtGuestEnterHere"
        Me.txtGuestEnterHere.Size = New System.Drawing.Size(36, 22)
        Me.txtGuestEnterHere.TabIndex = 350
        Me.txtGuestEnterHere.Visible = False
        '
        'txtExtraBedC
        '
        Me.txtExtraBedC.Location = New System.Drawing.Point(523, 686)
        Me.txtExtraBedC.Margin = New System.Windows.Forms.Padding(4)
        Me.txtExtraBedC.Name = "txtExtraBedC"
        Me.txtExtraBedC.Size = New System.Drawing.Size(36, 22)
        Me.txtExtraBedC.TabIndex = 348
        Me.txtExtraBedC.Visible = False
        '
        'txtExtraPersonC
        '
        Me.txtExtraPersonC.Location = New System.Drawing.Point(569, 686)
        Me.txtExtraPersonC.Margin = New System.Windows.Forms.Padding(4)
        Me.txtExtraPersonC.Name = "txtExtraPersonC"
        Me.txtExtraPersonC.Size = New System.Drawing.Size(36, 22)
        Me.txtExtraPersonC.TabIndex = 349
        Me.txtExtraPersonC.Visible = False
        '
        'txtRoomType
        '
        Me.txtRoomType.Location = New System.Drawing.Point(380, 677)
        Me.txtRoomType.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRoomType.Name = "txtRoomType"
        Me.txtRoomType.Size = New System.Drawing.Size(36, 22)
        Me.txtRoomType.TabIndex = 347
        Me.txtRoomType.Visible = False
        '
        'txtCheckInID
        '
        Me.txtCheckInID.Location = New System.Drawing.Point(516, 631)
        Me.txtCheckInID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCheckInID.Name = "txtCheckInID"
        Me.txtCheckInID.Size = New System.Drawing.Size(36, 22)
        Me.txtCheckInID.TabIndex = 345
        Me.txtCheckInID.Visible = False
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(595, 691)
        Me.txtID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(36, 22)
        Me.txtID.TabIndex = 346
        Me.txtID.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTotalRoomCharges)
        Me.GroupBox1.Controls.Add(Me.txtDiscountAmount)
        Me.GroupBox1.Controls.Add(Me.Label58)
        Me.GroupBox1.Controls.Add(Me.Label56)
        Me.GroupBox1.Controls.Add(Me.Label55)
        Me.GroupBox1.Controls.Add(Me.txtGrandTotal)
        Me.GroupBox1.Controls.Add(Me.txtServiceTaxPer)
        Me.GroupBox1.Controls.Add(Label51)
        Me.GroupBox1.Controls.Add(Label50)
        Me.GroupBox1.Controls.Add(Me.txtExtraPersonCharges)
        Me.GroupBox1.Controls.Add(Label4)
        Me.GroupBox1.Controls.Add(Me.txtExtraBedCharges)
        Me.GroupBox1.Controls.Add(Label14)
        Me.GroupBox1.Controls.Add(Label2)
        Me.GroupBox1.Controls.Add(Me.txtLuxuryTaxAmount)
        Me.GroupBox1.Controls.Add(Me.txtSubTotal)
        Me.GroupBox1.Controls.Add(Label15)
        Me.GroupBox1.Controls.Add(Label48)
        Me.GroupBox1.Controls.Add(Me.txtLuxuryTaxPer)
        Me.GroupBox1.Controls.Add(Me.txtDiscountPer)
        Me.GroupBox1.Controls.Add(Label49)
        Me.GroupBox1.Controls.Add(Me.txtServiceTaxAmount)
        Me.GroupBox1.Location = New System.Drawing.Point(894, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(387, 151)
        Me.GroupBox1.TabIndex = 344
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Discount && Taxes"
        '
        'txtTotalRoomCharges
        '
        Me.txtTotalRoomCharges.Location = New System.Drawing.Point(202, 183)
        Me.txtTotalRoomCharges.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalRoomCharges.Name = "txtTotalRoomCharges"
        Me.txtTotalRoomCharges.ReadOnly = True
        Me.txtTotalRoomCharges.Size = New System.Drawing.Size(163, 22)
        Me.txtTotalRoomCharges.TabIndex = 325
        Me.txtTotalRoomCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalRoomCharges.Visible = False
        '
        'txtDiscountAmount
        '
        Me.txtDiscountAmount.Location = New System.Drawing.Point(203, 39)
        Me.txtDiscountAmount.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDiscountAmount.Name = "txtDiscountAmount"
        Me.txtDiscountAmount.ReadOnly = True
        Me.txtDiscountAmount.Size = New System.Drawing.Size(161, 22)
        Me.txtDiscountAmount.TabIndex = 329
        Me.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.Location = New System.Drawing.Point(172, 43)
        Me.Label58.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(24, 20)
        Me.Label58.TabIndex = 344
        Me.Label58.Text = "%"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(169, 104)
        Me.Label56.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(24, 20)
        Me.Label56.TabIndex = 343
        Me.Label56.Text = "%"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(173, 75)
        Me.Label55.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(24, 20)
        Me.Label55.TabIndex = 342
        Me.Label55.Text = "%"
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.Location = New System.Drawing.Point(201, 203)
        Me.txtGrandTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtGrandTotal.Name = "txtGrandTotal"
        Me.txtGrandTotal.ReadOnly = True
        Me.txtGrandTotal.Size = New System.Drawing.Size(161, 22)
        Me.txtGrandTotal.TabIndex = 335
        Me.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGrandTotal.Visible = False
        '
        'txtServiceTaxPer
        '
        Me.txtServiceTaxPer.Location = New System.Drawing.Point(127, 72)
        Me.txtServiceTaxPer.Margin = New System.Windows.Forms.Padding(4)
        Me.txtServiceTaxPer.Name = "txtServiceTaxPer"
        Me.txtServiceTaxPer.Size = New System.Drawing.Size(39, 22)
        Me.txtServiceTaxPer.TabIndex = 331
        Me.txtServiceTaxPer.Text = "5"
        Me.txtServiceTaxPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtExtraPersonCharges
        '
        Me.txtExtraPersonCharges.Location = New System.Drawing.Point(201, 213)
        Me.txtExtraPersonCharges.Margin = New System.Windows.Forms.Padding(4)
        Me.txtExtraPersonCharges.Name = "txtExtraPersonCharges"
        Me.txtExtraPersonCharges.ReadOnly = True
        Me.txtExtraPersonCharges.Size = New System.Drawing.Size(163, 22)
        Me.txtExtraPersonCharges.TabIndex = 327
        Me.txtExtraPersonCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtExtraPersonCharges.Visible = False
        '
        'txtExtraBedCharges
        '
        Me.txtExtraBedCharges.Location = New System.Drawing.Point(204, 151)
        Me.txtExtraBedCharges.Margin = New System.Windows.Forms.Padding(4)
        Me.txtExtraBedCharges.Name = "txtExtraBedCharges"
        Me.txtExtraBedCharges.ReadOnly = True
        Me.txtExtraBedCharges.Size = New System.Drawing.Size(161, 22)
        Me.txtExtraBedCharges.TabIndex = 326
        Me.txtExtraBedCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtExtraBedCharges.Visible = False
        '
        'txtLuxuryTaxAmount
        '
        Me.txtLuxuryTaxAmount.Location = New System.Drawing.Point(202, 103)
        Me.txtLuxuryTaxAmount.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLuxuryTaxAmount.Name = "txtLuxuryTaxAmount"
        Me.txtLuxuryTaxAmount.ReadOnly = True
        Me.txtLuxuryTaxAmount.Size = New System.Drawing.Size(163, 22)
        Me.txtLuxuryTaxAmount.TabIndex = 334
        Me.txtLuxuryTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Location = New System.Drawing.Point(201, 244)
        Me.txtSubTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.Size = New System.Drawing.Size(163, 22)
        Me.txtSubTotal.TabIndex = 330
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSubTotal.Visible = False
        '
        'txtLuxuryTaxPer
        '
        Me.txtLuxuryTaxPer.Location = New System.Drawing.Point(125, 102)
        Me.txtLuxuryTaxPer.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLuxuryTaxPer.Name = "txtLuxuryTaxPer"
        Me.txtLuxuryTaxPer.Size = New System.Drawing.Size(38, 22)
        Me.txtLuxuryTaxPer.TabIndex = 333
        Me.txtLuxuryTaxPer.Text = "0"
        Me.txtLuxuryTaxPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDiscountPer
        '
        Me.txtDiscountPer.Location = New System.Drawing.Point(127, 41)
        Me.txtDiscountPer.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDiscountPer.Name = "txtDiscountPer"
        Me.txtDiscountPer.Size = New System.Drawing.Size(39, 22)
        Me.txtDiscountPer.TabIndex = 328
        Me.txtDiscountPer.Text = "0"
        Me.txtDiscountPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtServiceTaxAmount
        '
        Me.txtServiceTaxAmount.Location = New System.Drawing.Point(203, 71)
        Me.txtServiceTaxAmount.Margin = New System.Windows.Forms.Padding(4)
        Me.txtServiceTaxAmount.Name = "txtServiceTaxAmount"
        Me.txtServiceTaxAmount.ReadOnly = True
        Me.txtServiceTaxAmount.Size = New System.Drawing.Size(161, 22)
        Me.txtServiceTaxAmount.TabIndex = 332
        Me.txtServiceTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnPrint
        '
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.Enabled = False
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.Location = New System.Drawing.Point(148, 689)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(127, 52)
        Me.btnPrint.TabIndex = 343
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(12, 689)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(128, 52)
        Me.btnDelete.TabIndex = 342
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(148, 629)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(128, 52)
        Me.btnSave.TabIndex = 341
        Me.btnSave.Text = "Reserve"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNew.Location = New System.Drawing.Point(12, 629)
        Me.btnNew.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(128, 52)
        Me.btnNew.TabIndex = 340
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.YellowGreen
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ColumnHeadersHeight = 24
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RoomID, Me.RoomNum, Me.ExtraPersonCharges, Me.ExtraBedCharges, Me.RoomCharges, Me.STAmount, Me.DiscountAmount, Me.TotalRoomCharges})
        Me.DataGridView1.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.GridColor = System.Drawing.Color.White
        Me.DataGridView1.Location = New System.Drawing.Point(7, 280)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Orange
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSeaGreen
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.RowHeadersWidth = 25
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSeaGreen
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.RowTemplate.Height = 18
        Me.DataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(876, 339)
        Me.DataGridView1.TabIndex = 339
        '
        'RoomID
        '
        Me.RoomID.HeaderText = "RoomID"
        Me.RoomID.MinimumWidth = 6
        Me.RoomID.Name = "RoomID"
        Me.RoomID.ReadOnly = True
        Me.RoomID.Width = 125
        '
        'RoomNum
        '
        Me.RoomNum.HeaderText = "Room Num"
        Me.RoomNum.MinimumWidth = 6
        Me.RoomNum.Name = "RoomNum"
        Me.RoomNum.ReadOnly = True
        Me.RoomNum.Width = 125
        '
        'ExtraPersonCharges
        '
        Me.ExtraPersonCharges.HeaderText = "Extra Person Charges"
        Me.ExtraPersonCharges.MinimumWidth = 6
        Me.ExtraPersonCharges.Name = "ExtraPersonCharges"
        Me.ExtraPersonCharges.ReadOnly = True
        Me.ExtraPersonCharges.Width = 125
        '
        'ExtraBedCharges
        '
        Me.ExtraBedCharges.HeaderText = "Extra Bed Charges"
        Me.ExtraBedCharges.MinimumWidth = 6
        Me.ExtraBedCharges.Name = "ExtraBedCharges"
        Me.ExtraBedCharges.ReadOnly = True
        Me.ExtraBedCharges.Width = 125
        '
        'RoomCharges
        '
        Me.RoomCharges.HeaderText = "Room Charges"
        Me.RoomCharges.MinimumWidth = 6
        Me.RoomCharges.Name = "RoomCharges"
        Me.RoomCharges.ReadOnly = True
        Me.RoomCharges.Width = 125
        '
        'STAmount
        '
        Me.STAmount.HeaderText = "KPRA"
        Me.STAmount.MinimumWidth = 6
        Me.STAmount.Name = "STAmount"
        Me.STAmount.ReadOnly = True
        Me.STAmount.Width = 125
        '
        'DiscountAmount
        '
        Me.DiscountAmount.HeaderText = "Discount Amount"
        Me.DiscountAmount.MinimumWidth = 6
        Me.DiscountAmount.Name = "DiscountAmount"
        Me.DiscountAmount.ReadOnly = True
        Me.DiscountAmount.Width = 125
        '
        'TotalRoomCharges
        '
        Me.TotalRoomCharges.HeaderText = "Room Total"
        Me.TotalRoomCharges.MinimumWidth = 6
        Me.TotalRoomCharges.Name = "TotalRoomCharges"
        Me.TotalRoomCharges.ReadOnly = True
        Me.TotalRoomCharges.Width = 125
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.YellowGreen
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView2.ColumnHeadersHeight = 24
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column8, Me.Column15, Me.Column16, Me.Column1})
        Me.DataGridView2.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView2.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridView2.EnableHeadersVisualStyles = False
        Me.DataGridView2.GridColor = System.Drawing.Color.White
        Me.DataGridView2.Location = New System.Drawing.Point(894, 453)
        Me.DataGridView2.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.Orange
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.LightSeaGreen
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridView2.RowHeadersWidth = 25
        Me.DataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.LightSeaGreen
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White
        Me.DataGridView2.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridView2.RowTemplate.Height = 18
        Me.DataGridView2.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(387, 288)
        Me.DataGridView2.TabIndex = 338
        '
        'Column8
        '
        Me.Column8.HeaderText = "Payment Mode"
        Me.Column8.MinimumWidth = 6
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 120
        '
        'Column15
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.Column15.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column15.HeaderText = "Payment"
        Me.Column15.MinimumWidth = 6
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        Me.Column15.Width = 125
        '
        'Column16
        '
        DataGridViewCellStyle9.Format = "dd/MM/yyyy"
        Me.Column16.DefaultCellStyle = DataGridViewCellStyle9
        Me.Column16.HeaderText = "Payment Date"
        Me.Column16.MinimumWidth = 6
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        Me.Column16.Width = 125
        '
        'Column1
        '
        Me.Column1.HeaderText = "Status"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        Me.Column1.Width = 125
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnListReset1)
        Me.GroupBox2.Controls.Add(Me.btnListUpdate1)
        Me.GroupBox2.Controls.Add(Me.dtpPaymentDate)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtPayment)
        Me.GroupBox2.Controls.Add(Me.cmbPaymentMode)
        Me.GroupBox2.Controls.Add(Me.btnRemove1)
        Me.GroupBox2.Controls.Add(Me.btnAdd1)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Location = New System.Drawing.Point(894, 218)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(387, 227)
        Me.GroupBox2.TabIndex = 337
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Payment Info"
        '
        'btnListReset1
        '
        Me.btnListReset1.Image = CType(resources.GetObject("btnListReset1.Image"), System.Drawing.Image)
        Me.btnListReset1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnListReset1.Location = New System.Drawing.Point(80, 123)
        Me.btnListReset1.Margin = New System.Windows.Forms.Padding(4)
        Me.btnListReset1.Name = "btnListReset1"
        Me.btnListReset1.Size = New System.Drawing.Size(109, 38)
        Me.btnListReset1.TabIndex = 3
        Me.btnListReset1.Text = "Reset"
        Me.btnListReset1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnListReset1.UseVisualStyleBackColor = True
        '
        'btnListUpdate1
        '
        Me.btnListUpdate1.Enabled = False
        Me.btnListUpdate1.Image = CType(resources.GetObject("btnListUpdate1.Image"), System.Drawing.Image)
        Me.btnListUpdate1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnListUpdate1.Location = New System.Drawing.Point(212, 171)
        Me.btnListUpdate1.Margin = New System.Windows.Forms.Padding(4)
        Me.btnListUpdate1.Name = "btnListUpdate1"
        Me.btnListUpdate1.Size = New System.Drawing.Size(109, 38)
        Me.btnListUpdate1.TabIndex = 6
        Me.btnListUpdate1.Text = "Update"
        Me.btnListUpdate1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnListUpdate1.UseVisualStyleBackColor = True
        Me.btnListUpdate1.Visible = False
        '
        'dtpPaymentDate
        '
        Me.dtpPaymentDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPaymentDate.Location = New System.Drawing.Point(190, 90)
        Me.dtpPaymentDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpPaymentDate.Name = "dtpPaymentDate"
        Me.dtpPaymentDate.Size = New System.Drawing.Size(160, 22)
        Me.dtpPaymentDate.TabIndex = 2
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(11, 99)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(105, 17)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "Payment Date :"
        '
        'txtPayment
        '
        Me.txtPayment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPayment.Location = New System.Drawing.Point(189, 57)
        Me.txtPayment.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPayment.Name = "txtPayment"
        Me.txtPayment.Size = New System.Drawing.Size(160, 23)
        Me.txtPayment.TabIndex = 1
        Me.txtPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbPaymentMode
        '
        Me.cmbPaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPaymentMode.FormattingEnabled = True
        Me.cmbPaymentMode.Items.AddRange(New Object() {"By Cash", "By Card", "By Online"})
        Me.cmbPaymentMode.Location = New System.Drawing.Point(189, 26)
        Me.cmbPaymentMode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPaymentMode.Name = "cmbPaymentMode"
        Me.cmbPaymentMode.Size = New System.Drawing.Size(160, 24)
        Me.cmbPaymentMode.TabIndex = 0
        '
        'btnRemove1
        '
        Me.btnRemove1.Image = CType(resources.GetObject("btnRemove1.Image"), System.Drawing.Image)
        Me.btnRemove1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemove1.Location = New System.Drawing.Point(212, 123)
        Me.btnRemove1.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRemove1.Name = "btnRemove1"
        Me.btnRemove1.Size = New System.Drawing.Size(109, 38)
        Me.btnRemove1.TabIndex = 5
        Me.btnRemove1.Text = "Remove"
        Me.btnRemove1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRemove1.UseVisualStyleBackColor = True
        '
        'btnAdd1
        '
        Me.btnAdd1.Image = CType(resources.GetObject("btnAdd1.Image"), System.Drawing.Image)
        Me.btnAdd1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd1.Location = New System.Drawing.Point(79, 171)
        Me.btnAdd1.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd1.Name = "btnAdd1"
        Me.btnAdd1.Size = New System.Drawing.Size(109, 38)
        Me.btnAdd1.TabIndex = 4
        Me.btnAdd1.Text = "Add"
        Me.btnAdd1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd1.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(11, 33)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(110, 17)
        Me.Label17.TabIndex = 11
        Me.Label17.Text = "Payment Mode :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(11, 67)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(71, 17)
        Me.Label18.TabIndex = 22
        Me.Label18.Text = "Payment :"
        '
        'txtGroupBalance
        '
        Me.txtGroupBalance.Location = New System.Drawing.Point(782, 693)
        Me.txtGroupBalance.Margin = New System.Windows.Forms.Padding(4)
        Me.txtGroupBalance.Name = "txtGroupBalance"
        Me.txtGroupBalance.ReadOnly = True
        Me.txtGroupBalance.Size = New System.Drawing.Size(101, 22)
        Me.txtGroupBalance.TabIndex = 333
        Me.txtGroupBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBoxRateInfo
        '
        Me.GroupBoxRateInfo.Controls.Add(Me.txtRoomOrderCharges)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtLaundryCharges)
        Me.GroupBoxRateInfo.Controls.Add(Me.btnAddRooms)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtStatus)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtPlanName)
        Me.GroupBoxRateInfo.Controls.Add(Me.cmbPlanCode)
        Me.GroupBoxRateInfo.Controls.Add(Label20)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtGuestLedgerID)
        Me.GroupBoxRateInfo.Controls.Add(Me.TextBox3)
        Me.GroupBoxRateInfo.Controls.Add(Me.TextBox2)
        Me.GroupBoxRateInfo.Controls.Add(Me.TextBox1)
        Me.GroupBoxRateInfo.Controls.Add(Me.hsExtraBed)
        Me.GroupBoxRateInfo.Controls.Add(Me.hsExtraPerson)
        Me.GroupBoxRateInfo.Controls.Add(Me.hsKids)
        Me.GroupBoxRateInfo.Controls.Add(Label7)
        Me.GroupBoxRateInfo.Controls.Add(Label6)
        Me.GroupBoxRateInfo.Controls.Add(Label5)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtNoOfExtraBed)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtNoOfExtraPerson)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtNoOfKids)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtNoOfDays)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtRoomCharges)
        Me.GroupBoxRateInfo.Controls.Add(Label33)
        Me.GroupBoxRateInfo.Controls.Add(Me.hsFemales)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtNoOfFemales)
        Me.GroupBoxRateInfo.Controls.Add(Label47)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtNoOfMales)
        Me.GroupBoxRateInfo.Controls.Add(Label22)
        Me.GroupBoxRateInfo.Controls.Add(Me.dtpDateOut)
        Me.GroupBoxRateInfo.Controls.Add(Me.cmbRoomNo)
        Me.GroupBoxRateInfo.Controls.Add(Me.hsMales)
        Me.GroupBoxRateInfo.Controls.Add(DateOutLabel)
        Me.GroupBoxRateInfo.Controls.Add(Me.dtpDateIn)
        Me.GroupBoxRateInfo.Controls.Add(DateInLabel)
        Me.GroupBoxRateInfo.Controls.Add(RoomNumberLabel)
        Me.GroupBoxRateInfo.Location = New System.Drawing.Point(343, 57)
        Me.GroupBoxRateInfo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBoxRateInfo.Name = "GroupBoxRateInfo"
        Me.GroupBoxRateInfo.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBoxRateInfo.Size = New System.Drawing.Size(542, 208)
        Me.GroupBoxRateInfo.TabIndex = 8
        Me.GroupBoxRateInfo.TabStop = False
        Me.GroupBoxRateInfo.Text = "Rate Information"
        '
        'txtRoomOrderCharges
        '
        Me.txtRoomOrderCharges.Location = New System.Drawing.Point(470, 58)
        Me.txtRoomOrderCharges.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRoomOrderCharges.Name = "txtRoomOrderCharges"
        Me.txtRoomOrderCharges.ReadOnly = True
        Me.txtRoomOrderCharges.Size = New System.Drawing.Size(50, 22)
        Me.txtRoomOrderCharges.TabIndex = 332
        Me.txtRoomOrderCharges.Text = "0"
        Me.txtRoomOrderCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRoomOrderCharges.Visible = False
        '
        'txtLaundryCharges
        '
        Me.txtLaundryCharges.Location = New System.Drawing.Point(475, 23)
        Me.txtLaundryCharges.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLaundryCharges.Name = "txtLaundryCharges"
        Me.txtLaundryCharges.ReadOnly = True
        Me.txtLaundryCharges.Size = New System.Drawing.Size(50, 22)
        Me.txtLaundryCharges.TabIndex = 331
        Me.txtLaundryCharges.Text = "0"
        Me.txtLaundryCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLaundryCharges.Visible = False
        '
        'btnAddRooms
        '
        Me.btnAddRooms.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.btnAddRooms.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnAddRooms.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddRooms.Location = New System.Drawing.Point(328, 21)
        Me.btnAddRooms.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddRooms.Name = "btnAddRooms"
        Me.btnAddRooms.Size = New System.Drawing.Size(87, 26)
        Me.btnAddRooms.TabIndex = 330
        Me.btnAddRooms.Text = "Add Room"
        Me.btnAddRooms.UseVisualStyleBackColor = True
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(546, 165)
        Me.txtStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(45, 22)
        Me.txtStatus.TabIndex = 300
        Me.txtStatus.Visible = False
        '
        'txtPlanName
        '
        Me.txtPlanName.Location = New System.Drawing.Point(252, 54)
        Me.txtPlanName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPlanName.Name = "txtPlanName"
        Me.txtPlanName.ReadOnly = True
        Me.txtPlanName.Size = New System.Drawing.Size(163, 22)
        Me.txtPlanName.TabIndex = 4
        '
        'cmbPlanCode
        '
        Me.cmbPlanCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbPlanCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPlanCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlanCode.Enabled = False
        Me.cmbPlanCode.FormattingEnabled = True
        Me.cmbPlanCode.Location = New System.Drawing.Point(151, 54)
        Me.cmbPlanCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPlanCode.Name = "cmbPlanCode"
        Me.cmbPlanCode.Size = New System.Drawing.Size(92, 24)
        Me.cmbPlanCode.TabIndex = 3
        '
        'txtGuestLedgerID
        '
        Me.txtGuestLedgerID.Location = New System.Drawing.Point(543, 37)
        Me.txtGuestLedgerID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtGuestLedgerID.Name = "txtGuestLedgerID"
        Me.txtGuestLedgerID.Size = New System.Drawing.Size(45, 22)
        Me.txtGuestLedgerID.TabIndex = 319
        Me.txtGuestLedgerID.Visible = False
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(546, 133)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(43, 22)
        Me.TextBox3.TabIndex = 327
        Me.TextBox3.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(546, 101)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(43, 22)
        Me.TextBox2.TabIndex = 326
        Me.TextBox2.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(546, 69)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(43, 22)
        Me.TextBox1.TabIndex = 325
        Me.TextBox1.Visible = False
        '
        'hsExtraBed
        '
        Me.hsExtraBed.Cursor = System.Windows.Forms.Cursors.Default
        Me.hsExtraBed.LargeChange = 1
        Me.hsExtraBed.Location = New System.Drawing.Point(206, 172)
        Me.hsExtraBed.Maximum = 32767
        Me.hsExtraBed.Name = "hsExtraBed"
        Me.hsExtraBed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsExtraBed.Size = New System.Drawing.Size(31, 24)
        Me.hsExtraBed.TabIndex = 16
        Me.hsExtraBed.TabStop = True
        '
        'hsExtraPerson
        '
        Me.hsExtraPerson.Cursor = System.Windows.Forms.Cursors.Default
        Me.hsExtraPerson.LargeChange = 1
        Me.hsExtraPerson.Location = New System.Drawing.Point(471, 145)
        Me.hsExtraPerson.Maximum = 32767
        Me.hsExtraPerson.Name = "hsExtraPerson"
        Me.hsExtraPerson.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsExtraPerson.Size = New System.Drawing.Size(31, 24)
        Me.hsExtraPerson.TabIndex = 14
        Me.hsExtraPerson.TabStop = True
        '
        'hsKids
        '
        Me.hsKids.Cursor = System.Windows.Forms.Cursors.Default
        Me.hsKids.LargeChange = 1
        Me.hsKids.Location = New System.Drawing.Point(206, 144)
        Me.hsKids.Maximum = 32767
        Me.hsKids.Name = "hsKids"
        Me.hsKids.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsKids.Size = New System.Drawing.Size(31, 24)
        Me.hsKids.TabIndex = 12
        Me.hsKids.TabStop = True
        '
        'txtNoOfExtraBed
        '
        Me.txtNoOfExtraBed.Location = New System.Drawing.Point(151, 175)
        Me.txtNoOfExtraBed.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNoOfExtraBed.Name = "txtNoOfExtraBed"
        Me.txtNoOfExtraBed.ReadOnly = True
        Me.txtNoOfExtraBed.Size = New System.Drawing.Size(44, 22)
        Me.txtNoOfExtraBed.TabIndex = 15
        Me.txtNoOfExtraBed.Text = "0"
        Me.txtNoOfExtraBed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoOfExtraPerson
        '
        Me.txtNoOfExtraPerson.Location = New System.Drawing.Point(416, 148)
        Me.txtNoOfExtraPerson.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNoOfExtraPerson.Name = "txtNoOfExtraPerson"
        Me.txtNoOfExtraPerson.ReadOnly = True
        Me.txtNoOfExtraPerson.Size = New System.Drawing.Size(44, 22)
        Me.txtNoOfExtraPerson.TabIndex = 13
        Me.txtNoOfExtraPerson.Text = "0"
        Me.txtNoOfExtraPerson.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoOfKids
        '
        Me.txtNoOfKids.Location = New System.Drawing.Point(151, 146)
        Me.txtNoOfKids.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNoOfKids.Name = "txtNoOfKids"
        Me.txtNoOfKids.ReadOnly = True
        Me.txtNoOfKids.Size = New System.Drawing.Size(44, 22)
        Me.txtNoOfKids.TabIndex = 11
        Me.txtNoOfKids.Text = "0"
        Me.txtNoOfKids.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoOfDays
        '
        Me.txtNoOfDays.Location = New System.Drawing.Point(416, 178)
        Me.txtNoOfDays.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNoOfDays.Name = "txtNoOfDays"
        Me.txtNoOfDays.ReadOnly = True
        Me.txtNoOfDays.Size = New System.Drawing.Size(44, 22)
        Me.txtNoOfDays.TabIndex = 17
        Me.txtNoOfDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRoomCharges
        '
        Me.txtRoomCharges.Location = New System.Drawing.Point(252, 23)
        Me.txtRoomCharges.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRoomCharges.Name = "txtRoomCharges"
        Me.txtRoomCharges.Size = New System.Drawing.Size(68, 22)
        Me.txtRoomCharges.TabIndex = 1
        Me.txtRoomCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'hsFemales
        '
        Me.hsFemales.Cursor = System.Windows.Forms.Cursors.Default
        Me.hsFemales.LargeChange = 1
        Me.hsFemales.Location = New System.Drawing.Point(470, 114)
        Me.hsFemales.Maximum = 32767
        Me.hsFemales.Name = "hsFemales"
        Me.hsFemales.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsFemales.Size = New System.Drawing.Size(31, 24)
        Me.hsFemales.TabIndex = 10
        Me.hsFemales.TabStop = True
        '
        'txtNoOfFemales
        '
        Me.txtNoOfFemales.Location = New System.Drawing.Point(415, 117)
        Me.txtNoOfFemales.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNoOfFemales.Name = "txtNoOfFemales"
        Me.txtNoOfFemales.ReadOnly = True
        Me.txtNoOfFemales.Size = New System.Drawing.Size(44, 22)
        Me.txtNoOfFemales.TabIndex = 9
        Me.txtNoOfFemales.Text = "0"
        Me.txtNoOfFemales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoOfMales
        '
        Me.txtNoOfMales.Location = New System.Drawing.Point(151, 117)
        Me.txtNoOfMales.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNoOfMales.Name = "txtNoOfMales"
        Me.txtNoOfMales.ReadOnly = True
        Me.txtNoOfMales.Size = New System.Drawing.Size(44, 22)
        Me.txtNoOfMales.TabIndex = 7
        Me.txtNoOfMales.Text = "0"
        Me.txtNoOfMales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpDateOut
        '
        Me.dtpDateOut.CustomFormat = "dd/MM/yyyy"
        Me.dtpDateOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateOut.Location = New System.Drawing.Point(415, 87)
        Me.dtpDateOut.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpDateOut.Name = "dtpDateOut"
        Me.dtpDateOut.Size = New System.Drawing.Size(110, 22)
        Me.dtpDateOut.TabIndex = 6
        '
        'cmbRoomNo
        '
        Me.cmbRoomNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbRoomNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRoomNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRoomNo.FormattingEnabled = True
        Me.cmbRoomNo.Location = New System.Drawing.Point(151, 23)
        Me.cmbRoomNo.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbRoomNo.Name = "cmbRoomNo"
        Me.cmbRoomNo.Size = New System.Drawing.Size(92, 24)
        Me.cmbRoomNo.TabIndex = 0
        '
        'hsMales
        '
        Me.hsMales.Cursor = System.Windows.Forms.Cursors.Default
        Me.hsMales.LargeChange = 1
        Me.hsMales.Location = New System.Drawing.Point(206, 114)
        Me.hsMales.Maximum = 32767
        Me.hsMales.Name = "hsMales"
        Me.hsMales.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsMales.Size = New System.Drawing.Size(31, 24)
        Me.hsMales.TabIndex = 8
        Me.hsMales.TabStop = True
        '
        'dtpDateIn
        '
        Me.dtpDateIn.CustomFormat = "dd/MM/yyyy"
        Me.dtpDateIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateIn.Location = New System.Drawing.Point(151, 87)
        Me.dtpDateIn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpDateIn.Name = "dtpDateIn"
        Me.dtpDateIn.Size = New System.Drawing.Size(110, 22)
        Me.dtpDateIn.TabIndex = 5
        '
        'txtGroupTotal
        '
        Me.txtGroupTotal.Location = New System.Drawing.Point(782, 721)
        Me.txtGroupTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtGroupTotal.Name = "txtGroupTotal"
        Me.txtGroupTotal.ReadOnly = True
        Me.txtGroupTotal.Size = New System.Drawing.Size(101, 22)
        Me.txtGroupTotal.TabIndex = 332
        Me.txtGroupTotal.Text = "0"
        Me.txtGroupTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBoxGuestInfo
        '
        Me.GroupBoxGuestInfo.Controls.Add(Me.Button13)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtGuestName)
        Me.GroupBoxGuestInfo.Controls.Add(Label12)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtGuestID)
        Me.GroupBoxGuestInfo.Controls.Add(FolioNumberLabel)
        Me.GroupBoxGuestInfo.Location = New System.Drawing.Point(7, 171)
        Me.GroupBoxGuestInfo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxGuestInfo.Name = "GroupBoxGuestInfo"
        Me.GroupBoxGuestInfo.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxGuestInfo.Size = New System.Drawing.Size(329, 94)
        Me.GroupBoxGuestInfo.TabIndex = 7
        Me.GroupBoxGuestInfo.TabStop = False
        Me.GroupBoxGuestInfo.Text = "Guest Information"
        '
        'Button13
        '
        Me.Button13.Image = CType(resources.GetObject("Button13.Image"), System.Drawing.Image)
        Me.Button13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button13.Location = New System.Drawing.Point(189, 19)
        Me.Button13.Margin = New System.Windows.Forms.Padding(4)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(132, 26)
        Me.Button13.TabIndex = 279
        Me.Button13.Text = "List Of Guests"
        Me.Button13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button13.UseVisualStyleBackColor = True
        '
        'txtGuestName
        '
        Me.txtGuestName.Location = New System.Drawing.Point(123, 53)
        Me.txtGuestName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtGuestName.Name = "txtGuestName"
        Me.txtGuestName.Size = New System.Drawing.Size(198, 22)
        Me.txtGuestName.TabIndex = 1
        '
        'txtGuestID
        '
        Me.txtGuestID.Location = New System.Drawing.Point(123, 21)
        Me.txtGuestID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtGuestID.Name = "txtGuestID"
        Me.txtGuestID.ReadOnly = True
        Me.txtGuestID.Size = New System.Drawing.Size(57, 22)
        Me.txtGuestID.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.dtpReservationDate)
        Me.GroupBox3.Controls.Add(Me.txtReservationNo)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 57)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(329, 104)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Reservation Info"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(15, 63)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(126, 17)
        Me.Label13.TabIndex = 299
        Me.Label13.Text = "Reservation Date :"
        '
        'dtpReservationDate
        '
        Me.dtpReservationDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpReservationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpReservationDate.Location = New System.Drawing.Point(176, 63)
        Me.dtpReservationDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpReservationDate.Name = "dtpReservationDate"
        Me.dtpReservationDate.Size = New System.Drawing.Size(133, 22)
        Me.dtpReservationDate.TabIndex = 1
        '
        'txtReservationNo
        '
        Me.txtReservationNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReservationNo.Location = New System.Drawing.Point(176, 32)
        Me.txtReservationNo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtReservationNo.Name = "txtReservationNo"
        Me.txtReservationNo.ReadOnly = True
        Me.txtReservationNo.Size = New System.Drawing.Size(133, 23)
        Me.txtReservationNo.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 35)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 17)
        Me.Label3.TabIndex = 297
        Me.Label3.Text = "Reservation No. :"
        '
        'btnClose
        '
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(1183, 7)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(99, 42)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.YellowGreen
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.txtSaved)
        Me.Panel2.Controls.Add(Me.txtBillID)
        Me.Panel2.Controls.Add(Me.txtBillNo)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(7, 7)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1168, 42)
        Me.Panel2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(449, 2)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(231, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Group Reservation"
        '
        'txtBalance
        '
        Me.txtBalance.Location = New System.Drawing.Point(433, 721)
        Me.txtBalance.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.Size = New System.Drawing.Size(99, 22)
        Me.txtBalance.TabIndex = 30
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtBalance.Visible = False
        '
        'txtTotalPaid
        '
        Me.txtTotalPaid.Location = New System.Drawing.Point(782, 663)
        Me.txtTotalPaid.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalPaid.Name = "txtTotalPaid"
        Me.txtTotalPaid.ReadOnly = True
        Me.txtTotalPaid.Size = New System.Drawing.Size(101, 22)
        Me.txtTotalPaid.TabIndex = 29
        Me.txtTotalPaid.Text = "0"
        Me.txtTotalPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(540, 661)
        Me.TextBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(111, 22)
        Me.TextBox5.TabIndex = 366
        Me.TextBox5.Text = "0"
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox5.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(427, 631)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 17)
        Me.Label9.TabIndex = 367
        Me.Label9.Text = "Laundry:"
        Me.Label9.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(430, 664)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 17)
        Me.Label10.TabIndex = 368
        Me.Label10.Text = "Room Services:"
        Me.Label10.Visible = False
        '
        'txtBillNo
        '
        Me.txtBillNo.Location = New System.Drawing.Point(176, 11)
        Me.txtBillNo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBillNo.Name = "txtBillNo"
        Me.txtBillNo.Size = New System.Drawing.Size(36, 22)
        Me.txtBillNo.TabIndex = 355
        Me.txtBillNo.Visible = False
        '
        'txtBillID
        '
        Me.txtBillID.Location = New System.Drawing.Point(252, 11)
        Me.txtBillID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBillID.Name = "txtBillID"
        Me.txtBillID.Size = New System.Drawing.Size(36, 22)
        Me.txtBillID.TabIndex = 356
        Me.txtBillID.Visible = False
        '
        'txtSaved
        '
        Me.txtSaved.Location = New System.Drawing.Point(912, 9)
        Me.txtSaved.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSaved.Name = "txtSaved"
        Me.txtSaved.Size = New System.Drawing.Size(36, 22)
        Me.txtSaved.TabIndex = 357
        Me.txtSaved.Text = "0"
        Me.txtSaved.Visible = False
        '
        'frmGroupReservation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1309, 772)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmGroupReservation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmGroupReservation"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBoxRateInfo.ResumeLayout(False)
        Me.GroupBoxRateInfo.PerformLayout()
        Me.GroupBoxGuestInfo.ResumeLayout(False)
        Me.GroupBoxGuestInfo.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents dtpReservationDate As DateTimePicker
    Friend WithEvents txtReservationNo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBoxGuestInfo As GroupBox
    Friend WithEvents Button13 As Button
    Friend WithEvents txtGuestName As TextBox
    Friend WithEvents txtGuestID As TextBox
    Friend WithEvents GroupBoxRateInfo As GroupBox
    Friend WithEvents txtGroupBalance As TextBox
    Friend WithEvents txtGroupTotal As TextBox
    Friend WithEvents btnAddRooms As Button
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents txtPlanName As TextBox
    Friend WithEvents cmbPlanCode As ComboBox
    Friend WithEvents txtGuestLedgerID As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Public WithEvents hsExtraBed As HScrollBar
    Public WithEvents hsExtraPerson As HScrollBar
    Public WithEvents hsKids As HScrollBar
    Friend WithEvents txtBalance As TextBox
    Friend WithEvents txtNoOfExtraBed As TextBox
    Friend WithEvents txtNoOfExtraPerson As TextBox
    Friend WithEvents txtNoOfKids As TextBox
    Friend WithEvents txtTotalPaid As TextBox
    Friend WithEvents txtNoOfDays As TextBox
    Friend WithEvents txtRoomCharges As TextBox
    Public WithEvents hsFemales As HScrollBar
    Friend WithEvents txtNoOfFemales As TextBox
    Friend WithEvents txtNoOfMales As TextBox
    Friend WithEvents dtpDateOut As DateTimePicker
    Friend WithEvents cmbRoomNo As ComboBox
    Public WithEvents hsMales As HScrollBar
    Friend WithEvents dtpDateIn As DateTimePicker
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnListReset1 As Button
    Friend WithEvents btnListUpdate1 As Button
    Friend WithEvents dtpPaymentDate As DateTimePicker
    Friend WithEvents Label16 As Label
    Friend WithEvents txtPayment As TextBox
    Friend WithEvents cmbPaymentMode As ComboBox
    Friend WithEvents btnRemove1 As Button
    Friend WithEvents btnAdd1 As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column15 As DataGridViewTextBoxColumn
    Friend WithEvents Column16 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnNew As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtTotalRoomCharges As TextBox
    Friend WithEvents txtDiscountAmount As TextBox
    Friend WithEvents Label58 As Label
    Friend WithEvents Label56 As Label
    Friend WithEvents Label55 As Label
    Friend WithEvents txtGrandTotal As TextBox
    Friend WithEvents txtServiceTaxPer As TextBox
    Friend WithEvents txtExtraPersonCharges As TextBox
    Friend WithEvents txtExtraBedCharges As TextBox
    Friend WithEvents txtLuxuryTaxAmount As TextBox
    Friend WithEvents txtSubTotal As TextBox
    Friend WithEvents txtLuxuryTaxPer As TextBox
    Friend WithEvents txtDiscountPer As TextBox
    Friend WithEvents txtServiceTaxAmount As TextBox
    Friend WithEvents txtGuestEnterHere As TextBox
    Friend WithEvents txtExtraBedC As TextBox
    Friend WithEvents txtExtraPersonC As TextBox
    Friend WithEvents txtRoomType As TextBox
    Friend WithEvents txtCheckInID As TextBox
    Friend WithEvents txtID As TextBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents txtRoomID As TextBox
    Friend WithEvents cmbRoomNo1 As ComboBox
    Friend WithEvents txtReservationID As TextBox
    Friend WithEvents lblUser As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents txti2 As TextBox
    Friend WithEvents txti1 As TextBox
    Friend WithEvents txtGuestContactNo As TextBox
    Friend WithEvents txtGroupTax As TextBox
    Friend WithEvents RoomID As DataGridViewTextBoxColumn
    Friend WithEvents RoomNum As DataGridViewTextBoxColumn
    Friend WithEvents ExtraPersonCharges As DataGridViewTextBoxColumn
    Friend WithEvents ExtraBedCharges As DataGridViewTextBoxColumn
    Friend WithEvents RoomCharges As DataGridViewTextBoxColumn
    Friend WithEvents STAmount As DataGridViewTextBoxColumn
    Friend WithEvents DiscountAmount As DataGridViewTextBoxColumn
    Friend WithEvents TotalRoomCharges As DataGridViewTextBoxColumn
    Public WithEvents btnCancelReservation As Button
    Public WithEvents btnCancelReservationReceipt As Button
    Public WithEvents btnCheckedIN As Button
    Friend WithEvents btnCheckOut As Button
    Friend WithEvents txtLaundryCharges As TextBox
    Friend WithEvents txtRoomOrderCharges As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtBillID As TextBox
    Friend WithEvents txtBillNo As TextBox
    Friend WithEvents txtSaved As TextBox
End Class
