<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Expense_IssuerFormControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Expense_IssuerFormControl))
        Me.grdExpenseIssuer = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlSearchItemName = New System.Windows.Forms.Panel()
        Me.cboSearchItemName = New System.Windows.Forms.ComboBox()
        Me.chkItemName = New System.Windows.Forms.CheckBox()
        Me.pnlSearchDate = New System.Windows.Forms.Panel()
        Me.pnlSearchListOfOptionForDates = New System.Windows.Forms.Panel()
        Me.rdbNoOfDays = New System.Windows.Forms.RadioButton()
        Me.rdbDay = New System.Windows.Forms.RadioButton()
        Me.rdbYear = New System.Windows.Forms.RadioButton()
        Me.chkDate = New System.Windows.Forms.CheckBox()
        Me.pnlSelectADay = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpSearchSelectADay = New System.Windows.Forms.DateTimePicker()
        Me.pnlSelectNoOfDays = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dtpSearchEndingDate = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dtpSearchStartingDate = New System.Windows.Forms.DateTimePicker()
        Me.pnlSelectAYear = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtpSearchSelectAYear = New System.Windows.Forms.DateTimePicker()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txtItemName = New System.Windows.Forms.TextBox()
        Me.cboItemName = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpDateOfUsed = New System.Windows.Forms.DateTimePicker()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUsedFor = New System.Windows.Forms.TextBox()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnGetReport = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtRecordPosition = New System.Windows.Forms.TextBox()
        Me.btnMoveLast = New System.Windows.Forms.Button()
        Me.btnMoveNext = New System.Windows.Forms.Button()
        Me.btnMovePrevious = New System.Windows.Forms.Button()
        Me.btnMoveFirst = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        CType(Me.grdExpenseIssuer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.pnlSearchItemName.SuspendLayout()
        Me.pnlSearchDate.SuspendLayout()
        Me.pnlSearchListOfOptionForDates.SuspendLayout()
        Me.pnlSelectADay.SuspendLayout()
        Me.pnlSelectNoOfDays.SuspendLayout()
        Me.pnlSelectAYear.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdExpenseIssuer
        '
        Me.grdExpenseIssuer.AllowUserToAddRows = False
        Me.grdExpenseIssuer.AllowUserToDeleteRows = False
        Me.grdExpenseIssuer.AllowUserToOrderColumns = True
        Me.grdExpenseIssuer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grdExpenseIssuer.BackgroundColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdExpenseIssuer.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.grdExpenseIssuer.ColumnHeadersHeight = 30
        Me.grdExpenseIssuer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdExpenseIssuer.EnableHeadersVisualStyles = False
        Me.grdExpenseIssuer.Location = New System.Drawing.Point(4, 308)
        Me.grdExpenseIssuer.Margin = New System.Windows.Forms.Padding(4)
        Me.grdExpenseIssuer.Name = "grdExpenseIssuer"
        Me.grdExpenseIssuer.ReadOnly = True
        Me.grdExpenseIssuer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdExpenseIssuer.Size = New System.Drawing.Size(1422, 402)
        Me.grdExpenseIssuer.TabIndex = 97
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.FlowLayoutPanel2)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.GroupBox2.Location = New System.Drawing.Point(923, 66)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(492, 219)
        Me.GroupBox2.TabIndex = 103
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Search"
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel2.Controls.Add(Me.pnlSearchItemName)
        Me.FlowLayoutPanel2.Controls.Add(Me.pnlSearchDate)
        Me.FlowLayoutPanel2.Controls.Add(Me.pnlSelectADay)
        Me.FlowLayoutPanel2.Controls.Add(Me.pnlSelectNoOfDays)
        Me.FlowLayoutPanel2.Controls.Add(Me.pnlSelectAYear)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnSearch)
        Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(8, 18)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(4)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(472, 284)
        Me.FlowLayoutPanel2.TabIndex = 75
        '
        'pnlSearchItemName
        '
        Me.pnlSearchItemName.BackColor = System.Drawing.Color.Transparent
        Me.pnlSearchItemName.Controls.Add(Me.cboSearchItemName)
        Me.pnlSearchItemName.Controls.Add(Me.chkItemName)
        Me.pnlSearchItemName.Location = New System.Drawing.Point(4, 4)
        Me.pnlSearchItemName.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlSearchItemName.Name = "pnlSearchItemName"
        Me.pnlSearchItemName.Size = New System.Drawing.Size(459, 34)
        Me.pnlSearchItemName.TabIndex = 73
        '
        'cboSearchItemName
        '
        Me.cboSearchItemName.DropDownHeight = 139
        Me.cboSearchItemName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchItemName.FormattingEnabled = True
        Me.cboSearchItemName.IntegralHeight = False
        Me.cboSearchItemName.Location = New System.Drawing.Point(164, 2)
        Me.cboSearchItemName.Margin = New System.Windows.Forms.Padding(4)
        Me.cboSearchItemName.Name = "cboSearchItemName"
        Me.cboSearchItemName.Size = New System.Drawing.Size(289, 29)
        Me.cboSearchItemName.TabIndex = 53
        Me.cboSearchItemName.Visible = False
        '
        'chkItemName
        '
        Me.chkItemName.AutoSize = True
        Me.chkItemName.Location = New System.Drawing.Point(8, 6)
        Me.chkItemName.Margin = New System.Windows.Forms.Padding(4)
        Me.chkItemName.Name = "chkItemName"
        Me.chkItemName.Size = New System.Drawing.Size(118, 27)
        Me.chkItemName.TabIndex = 79
        Me.chkItemName.Text = "Item Name"
        Me.chkItemName.UseVisualStyleBackColor = True
        '
        'pnlSearchDate
        '
        Me.pnlSearchDate.BackColor = System.Drawing.Color.Transparent
        Me.pnlSearchDate.Controls.Add(Me.pnlSearchListOfOptionForDates)
        Me.pnlSearchDate.Controls.Add(Me.chkDate)
        Me.pnlSearchDate.Location = New System.Drawing.Point(4, 46)
        Me.pnlSearchDate.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlSearchDate.Name = "pnlSearchDate"
        Me.pnlSearchDate.Size = New System.Drawing.Size(459, 34)
        Me.pnlSearchDate.TabIndex = 80
        '
        'pnlSearchListOfOptionForDates
        '
        Me.pnlSearchListOfOptionForDates.BackColor = System.Drawing.Color.Transparent
        Me.pnlSearchListOfOptionForDates.Controls.Add(Me.rdbNoOfDays)
        Me.pnlSearchListOfOptionForDates.Controls.Add(Me.rdbDay)
        Me.pnlSearchListOfOptionForDates.Controls.Add(Me.rdbYear)
        Me.pnlSearchListOfOptionForDates.Location = New System.Drawing.Point(164, 0)
        Me.pnlSearchListOfOptionForDates.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlSearchListOfOptionForDates.Name = "pnlSearchListOfOptionForDates"
        Me.pnlSearchListOfOptionForDates.Size = New System.Drawing.Size(291, 34)
        Me.pnlSearchListOfOptionForDates.TabIndex = 82
        Me.pnlSearchListOfOptionForDates.Visible = False
        '
        'rdbNoOfDays
        '
        Me.rdbNoOfDays.AutoSize = True
        Me.rdbNoOfDays.Location = New System.Drawing.Point(84, 5)
        Me.rdbNoOfDays.Margin = New System.Windows.Forms.Padding(4)
        Me.rdbNoOfDays.Name = "rdbNoOfDays"
        Me.rdbNoOfDays.Size = New System.Drawing.Size(119, 27)
        Me.rdbNoOfDays.TabIndex = 76
        Me.rdbNoOfDays.TabStop = True
        Me.rdbNoOfDays.Text = "No. of Days"
        Me.rdbNoOfDays.UseVisualStyleBackColor = True
        '
        'rdbDay
        '
        Me.rdbDay.AutoSize = True
        Me.rdbDay.Location = New System.Drawing.Point(223, 5)
        Me.rdbDay.Margin = New System.Windows.Forms.Padding(4)
        Me.rdbDay.Name = "rdbDay"
        Me.rdbDay.Size = New System.Drawing.Size(60, 27)
        Me.rdbDay.TabIndex = 81
        Me.rdbDay.TabStop = True
        Me.rdbDay.Text = "Day"
        Me.rdbDay.UseVisualStyleBackColor = True
        '
        'rdbYear
        '
        Me.rdbYear.AutoSize = True
        Me.rdbYear.Location = New System.Drawing.Point(4, 5)
        Me.rdbYear.Margin = New System.Windows.Forms.Padding(4)
        Me.rdbYear.Name = "rdbYear"
        Me.rdbYear.Size = New System.Drawing.Size(63, 27)
        Me.rdbYear.TabIndex = 77
        Me.rdbYear.TabStop = True
        Me.rdbYear.Text = "Year"
        Me.rdbYear.UseVisualStyleBackColor = True
        '
        'chkDate
        '
        Me.chkDate.AutoSize = True
        Me.chkDate.Location = New System.Drawing.Point(8, 5)
        Me.chkDate.Margin = New System.Windows.Forms.Padding(4)
        Me.chkDate.Name = "chkDate"
        Me.chkDate.Size = New System.Drawing.Size(68, 27)
        Me.chkDate.TabIndex = 80
        Me.chkDate.Text = "Date"
        Me.chkDate.UseVisualStyleBackColor = True
        '
        'pnlSelectADay
        '
        Me.pnlSelectADay.BackColor = System.Drawing.Color.Transparent
        Me.pnlSelectADay.Controls.Add(Me.Label10)
        Me.pnlSelectADay.Controls.Add(Me.dtpSearchSelectADay)
        Me.pnlSelectADay.Location = New System.Drawing.Point(4, 88)
        Me.pnlSelectADay.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlSelectADay.Name = "pnlSelectADay"
        Me.pnlSelectADay.Size = New System.Drawing.Size(459, 34)
        Me.pnlSelectADay.TabIndex = 74
        Me.pnlSelectADay.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(28, 9)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 23)
        Me.Label10.TabIndex = 55
        Me.Label10.Text = "Select a Day:"
        '
        'dtpSearchSelectADay
        '
        Me.dtpSearchSelectADay.Location = New System.Drawing.Point(164, 1)
        Me.dtpSearchSelectADay.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpSearchSelectADay.Name = "dtpSearchSelectADay"
        Me.dtpSearchSelectADay.Size = New System.Drawing.Size(289, 29)
        Me.dtpSearchSelectADay.TabIndex = 54
        Me.dtpSearchSelectADay.Value = New Date(2014, 12, 1, 7, 54, 12, 0)
        '
        'pnlSelectNoOfDays
        '
        Me.pnlSelectNoOfDays.BackColor = System.Drawing.Color.Transparent
        Me.pnlSelectNoOfDays.Controls.Add(Me.Label14)
        Me.pnlSelectNoOfDays.Controls.Add(Me.dtpSearchEndingDate)
        Me.pnlSelectNoOfDays.Controls.Add(Me.Label13)
        Me.pnlSelectNoOfDays.Controls.Add(Me.dtpSearchStartingDate)
        Me.pnlSelectNoOfDays.Location = New System.Drawing.Point(4, 130)
        Me.pnlSelectNoOfDays.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlSelectNoOfDays.Name = "pnlSelectNoOfDays"
        Me.pnlSelectNoOfDays.Size = New System.Drawing.Size(459, 65)
        Me.pnlSelectNoOfDays.TabIndex = 76
        Me.pnlSelectNoOfDays.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(29, 39)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(108, 23)
        Me.Label14.TabIndex = 57
        Me.Label14.Text = "Ending Date:"
        '
        'dtpSearchEndingDate
        '
        Me.dtpSearchEndingDate.Location = New System.Drawing.Point(164, 34)
        Me.dtpSearchEndingDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpSearchEndingDate.Name = "dtpSearchEndingDate"
        Me.dtpSearchEndingDate.Size = New System.Drawing.Size(289, 29)
        Me.dtpSearchEndingDate.TabIndex = 56
        Me.dtpSearchEndingDate.Value = New Date(2014, 12, 1, 7, 54, 12, 0)
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(28, 6)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(114, 23)
        Me.Label13.TabIndex = 55
        Me.Label13.Text = "Starting Date:"
        '
        'dtpSearchStartingDate
        '
        Me.dtpSearchStartingDate.Location = New System.Drawing.Point(164, 1)
        Me.dtpSearchStartingDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpSearchStartingDate.Name = "dtpSearchStartingDate"
        Me.dtpSearchStartingDate.Size = New System.Drawing.Size(289, 29)
        Me.dtpSearchStartingDate.TabIndex = 54
        Me.dtpSearchStartingDate.Value = New Date(2014, 12, 1, 7, 54, 12, 0)
        '
        'pnlSelectAYear
        '
        Me.pnlSelectAYear.BackColor = System.Drawing.Color.Transparent
        Me.pnlSelectAYear.Controls.Add(Me.Label12)
        Me.pnlSelectAYear.Controls.Add(Me.dtpSearchSelectAYear)
        Me.pnlSelectAYear.Location = New System.Drawing.Point(4, 203)
        Me.pnlSelectAYear.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlSelectAYear.Name = "pnlSelectAYear"
        Me.pnlSelectAYear.Size = New System.Drawing.Size(459, 34)
        Me.pnlSelectAYear.TabIndex = 75
        Me.pnlSelectAYear.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(29, 9)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(110, 23)
        Me.Label12.TabIndex = 55
        Me.Label12.Text = "Select a Year:"
        '
        'dtpSearchSelectAYear
        '
        Me.dtpSearchSelectAYear.CustomFormat = """yyyy"""
        Me.dtpSearchSelectAYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSearchSelectAYear.Location = New System.Drawing.Point(164, 1)
        Me.dtpSearchSelectAYear.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpSearchSelectAYear.Name = "dtpSearchSelectAYear"
        Me.dtpSearchSelectAYear.ShowUpDown = True
        Me.dtpSearchSelectAYear.Size = New System.Drawing.Size(289, 29)
        Me.dtpSearchSelectAYear.TabIndex = 54
        Me.dtpSearchSelectAYear.Value = New Date(2014, 6, 24, 0, 0, 0, 0)
        '
        'btnSearch
        '
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.Enabled = False
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnSearch.FlatAppearance.BorderSize = 5
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(4, 245)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Padding = New System.Windows.Forms.Padding(53, 0, 33, 0)
        Me.btnSearch.Size = New System.Drawing.Size(205, 34)
        Me.btnSearch.TabIndex = 81
        Me.btnSearch.TabStop = False
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(527, 25)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(412, 37)
        Me.Label9.TabIndex = 101
        Me.Label9.Text = "EXPENSE-ISSUER FORM"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.FlowLayoutPanel1)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(21, 66)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(893, 219)
        Me.GroupBox3.TabIndex = 102
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Expense-Issuer"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel5)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel4)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel6)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel1)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel11)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel2)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel3)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel7)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(9, 20)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(877, 183)
        Me.FlowLayoutPanel1.TabIndex = 50
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.Controls.Add(Me.txtItemName)
        Me.Panel5.Controls.Add(Me.cboItemName)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Location = New System.Drawing.Point(4, 4)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(429, 38)
        Me.Panel5.TabIndex = 55
        '
        'txtItemName
        '
        Me.txtItemName.Location = New System.Drawing.Point(133, 4)
        Me.txtItemName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtItemName.MaxLength = 50
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(289, 29)
        Me.txtItemName.TabIndex = 80
        Me.txtItemName.Visible = False
        '
        'cboItemName
        '
        Me.cboItemName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemName.FormattingEnabled = True
        Me.cboItemName.Location = New System.Drawing.Point(133, 4)
        Me.cboItemName.Margin = New System.Windows.Forms.Padding(4)
        Me.cboItemName.Name = "cboItemName"
        Me.cboItemName.Size = New System.Drawing.Size(289, 29)
        Me.cboItemName.TabIndex = 81
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 7)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 23)
        Me.Label5.TabIndex = 80
        Me.Label5.Text = "Item Name:"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.dtpDateOfUsed)
        Me.Panel4.Location = New System.Drawing.Point(4, 50)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(429, 38)
        Me.Panel4.TabIndex = 58
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 7)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 23)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Date:"
        '
        'dtpDateOfUsed
        '
        Me.dtpDateOfUsed.Location = New System.Drawing.Point(133, 4)
        Me.dtpDateOfUsed.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpDateOfUsed.Name = "dtpDateOfUsed"
        Me.dtpDateOfUsed.Size = New System.Drawing.Size(289, 29)
        Me.dtpDateOfUsed.TabIndex = 83
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.Controls.Add(Me.Label11)
        Me.Panel6.Controls.Add(Me.txtQuantity)
        Me.Panel6.Location = New System.Drawing.Point(4, 96)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(429, 38)
        Me.Panel6.TabIndex = 59
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(5, 7)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 23)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Quantity:"
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(133, 4)
        Me.txtQuantity.Margin = New System.Windows.Forms.Padding(4)
        Me.txtQuantity.MaxLength = 10
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(289, 29)
        Me.txtQuantity.TabIndex = 79
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtUsedFor)
        Me.Panel1.Location = New System.Drawing.Point(441, 4)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(429, 38)
        Me.Panel1.TabIndex = 65
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 7)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 23)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "Used For:"
        '
        'txtUsedFor
        '
        Me.txtUsedFor.Location = New System.Drawing.Point(133, 4)
        Me.txtUsedFor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUsedFor.MaxLength = 255
        Me.txtUsedFor.Name = "txtUsedFor"
        Me.txtUsedFor.Size = New System.Drawing.Size(289, 29)
        Me.txtUsedFor.TabIndex = 92
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.Transparent
        Me.Panel11.Controls.Add(Me.btnSave)
        Me.Panel11.Controls.Add(Me.btnClear)
        Me.Panel11.Location = New System.Drawing.Point(441, 50)
        Me.Panel11.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(429, 38)
        Me.Panel11.TabIndex = 76
        '
        'btnSave
        '
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(217, 1)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Padding = New System.Windows.Forms.Padding(53, 0, 47, 0)
        Me.btnSave.Size = New System.Drawing.Size(207, 34)
        Me.btnSave.TabIndex = 58
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.Transparent
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClear.Location = New System.Drawing.Point(4, 1)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Padding = New System.Windows.Forms.Padding(47, 0, 53, 0)
        Me.btnClear.Size = New System.Drawing.Size(205, 34)
        Me.btnClear.TabIndex = 59
        Me.btnClear.TabStop = False
        Me.btnClear.Text = "Clear"
        Me.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.btnGetReport)
        Me.Panel2.Controls.Add(Me.btnView)
        Me.Panel2.Location = New System.Drawing.Point(441, 96)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(429, 38)
        Me.Panel2.TabIndex = 74
        '
        'btnGetReport
        '
        Me.btnGetReport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGetReport.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnGetReport.Location = New System.Drawing.Point(217, 0)
        Me.btnGetReport.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGetReport.Name = "btnGetReport"
        Me.btnGetReport.Size = New System.Drawing.Size(205, 34)
        Me.btnGetReport.TabIndex = 60
        Me.btnGetReport.Text = "Get Report"
        Me.btnGetReport.UseVisualStyleBackColor = True
        Me.btnGetReport.Visible = False
        '
        'btnView
        '
        Me.btnView.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnView.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnView.FlatAppearance.BorderSize = 5
        Me.btnView.Image = CType(resources.GetObject("btnView.Image"), System.Drawing.Image)
        Me.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnView.Location = New System.Drawing.Point(5, 1)
        Me.btnView.Margin = New System.Windows.Forms.Padding(4)
        Me.btnView.Name = "btnView"
        Me.btnView.Padding = New System.Windows.Forms.Padding(53, 0, 53, 0)
        Me.btnView.Size = New System.Drawing.Size(205, 34)
        Me.btnView.TabIndex = 4
        Me.btnView.TabStop = False
        Me.btnView.Text = "View"
        Me.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnView.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.txtRecordPosition)
        Me.Panel3.Controls.Add(Me.btnMoveLast)
        Me.Panel3.Controls.Add(Me.btnMoveNext)
        Me.Panel3.Controls.Add(Me.btnMovePrevious)
        Me.Panel3.Controls.Add(Me.btnMoveFirst)
        Me.Panel3.Location = New System.Drawing.Point(878, 4)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(429, 38)
        Me.Panel3.TabIndex = 75
        '
        'txtRecordPosition
        '
        Me.txtRecordPosition.Enabled = False
        Me.txtRecordPosition.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecordPosition.Location = New System.Drawing.Point(107, 4)
        Me.txtRecordPosition.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRecordPosition.Name = "txtRecordPosition"
        Me.txtRecordPosition.Size = New System.Drawing.Size(216, 29)
        Me.txtRecordPosition.TabIndex = 63
        Me.txtRecordPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnMoveLast
        '
        Me.btnMoveLast.Enabled = False
        Me.btnMoveLast.Image = CType(resources.GetObject("btnMoveLast.Image"), System.Drawing.Image)
        Me.btnMoveLast.Location = New System.Drawing.Point(383, 1)
        Me.btnMoveLast.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMoveLast.Name = "btnMoveLast"
        Me.btnMoveLast.Size = New System.Drawing.Size(43, 34)
        Me.btnMoveLast.TabIndex = 62
        Me.btnMoveLast.TabStop = False
        Me.btnMoveLast.UseVisualStyleBackColor = True
        '
        'btnMoveNext
        '
        Me.btnMoveNext.Enabled = False
        Me.btnMoveNext.Image = CType(resources.GetObject("btnMoveNext.Image"), System.Drawing.Image)
        Me.btnMoveNext.Location = New System.Drawing.Point(332, 1)
        Me.btnMoveNext.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMoveNext.Name = "btnMoveNext"
        Me.btnMoveNext.Size = New System.Drawing.Size(43, 34)
        Me.btnMoveNext.TabIndex = 61
        Me.btnMoveNext.TabStop = False
        Me.btnMoveNext.UseVisualStyleBackColor = True
        '
        'btnMovePrevious
        '
        Me.btnMovePrevious.Enabled = False
        Me.btnMovePrevious.Image = CType(resources.GetObject("btnMovePrevious.Image"), System.Drawing.Image)
        Me.btnMovePrevious.Location = New System.Drawing.Point(56, 1)
        Me.btnMovePrevious.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMovePrevious.Name = "btnMovePrevious"
        Me.btnMovePrevious.Size = New System.Drawing.Size(43, 34)
        Me.btnMovePrevious.TabIndex = 60
        Me.btnMovePrevious.TabStop = False
        Me.btnMovePrevious.UseVisualStyleBackColor = True
        '
        'btnMoveFirst
        '
        Me.btnMoveFirst.Enabled = False
        Me.btnMoveFirst.Image = CType(resources.GetObject("btnMoveFirst.Image"), System.Drawing.Image)
        Me.btnMoveFirst.Location = New System.Drawing.Point(5, 1)
        Me.btnMoveFirst.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMoveFirst.Name = "btnMoveFirst"
        Me.btnMoveFirst.Size = New System.Drawing.Size(43, 34)
        Me.btnMoveFirst.TabIndex = 59
        Me.btnMoveFirst.TabStop = False
        Me.btnMoveFirst.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Transparent
        Me.Panel7.Controls.Add(Me.btnDelete)
        Me.Panel7.Controls.Add(Me.btnRefresh)
        Me.Panel7.Location = New System.Drawing.Point(878, 50)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(429, 38)
        Me.Panel7.TabIndex = 77
        '
        'btnDelete
        '
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Enabled = False
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnDelete.FlatAppearance.BorderSize = 5
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(4, 2)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Padding = New System.Windows.Forms.Padding(47, 0, 40, 0)
        Me.btnDelete.Size = New System.Drawing.Size(207, 34)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnRefresh.FlatAppearance.BorderSize = 5
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(219, 2)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Padding = New System.Windows.Forms.Padding(53, 0, 33, 0)
        Me.btnRefresh.Size = New System.Drawing.Size(205, 34)
        Me.btnRefresh.TabIndex = 59
        Me.btnRefresh.TabStop = False
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Expense_IssuerFormControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.grdExpenseIssuer)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Expense_IssuerFormControl"
        Me.Size = New System.Drawing.Size(1430, 714)
        CType(Me.grdExpenseIssuer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.pnlSearchItemName.ResumeLayout(False)
        Me.pnlSearchItemName.PerformLayout()
        Me.pnlSearchDate.ResumeLayout(False)
        Me.pnlSearchDate.PerformLayout()
        Me.pnlSearchListOfOptionForDates.ResumeLayout(False)
        Me.pnlSearchListOfOptionForDates.PerformLayout()
        Me.pnlSelectADay.ResumeLayout(False)
        Me.pnlSelectADay.PerformLayout()
        Me.pnlSelectNoOfDays.ResumeLayout(False)
        Me.pnlSelectNoOfDays.PerformLayout()
        Me.pnlSelectAYear.ResumeLayout(False)
        Me.pnlSelectAYear.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdExpenseIssuer As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents pnlSearchItemName As Panel
    Friend WithEvents cboSearchItemName As ComboBox
    Friend WithEvents chkItemName As CheckBox
    Friend WithEvents pnlSearchDate As Panel
    Friend WithEvents pnlSearchListOfOptionForDates As Panel
    Friend WithEvents rdbNoOfDays As RadioButton
    Friend WithEvents rdbDay As RadioButton
    Friend WithEvents rdbYear As RadioButton
    Friend WithEvents chkDate As CheckBox
    Friend WithEvents pnlSelectADay As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents dtpSearchSelectADay As DateTimePicker
    Friend WithEvents pnlSelectNoOfDays As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents dtpSearchEndingDate As DateTimePicker
    Friend WithEvents Label13 As Label
    Friend WithEvents dtpSearchStartingDate As DateTimePicker
    Friend WithEvents pnlSelectAYear As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents dtpSearchSelectAYear As DateTimePicker
    Friend WithEvents btnSearch As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents txtItemName As TextBox
    Friend WithEvents cboItemName As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents dtpDateOfUsed As DateTimePicker
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents txtUsedFor As TextBox
    Friend WithEvents Panel11 As Panel
    Friend WithEvents btnSave As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnGetReport As Button
    Friend WithEvents btnView As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtRecordPosition As TextBox
    Friend WithEvents btnMoveLast As Button
    Friend WithEvents btnMoveNext As Button
    Friend WithEvents btnMovePrevious As Button
    Friend WithEvents btnMoveFirst As Button
    Friend WithEvents Panel7 As Panel
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnRefresh As Button
End Class
