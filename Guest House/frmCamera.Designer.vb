<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCamera
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCamera))
        Me.Button_Save = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ComboBox_Devices = New System.Windows.Forms.ComboBox()
        Me.lblCamera = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox_FrameSize = New System.Windows.Forms.ComboBox()
        Me.Button_Connect = New System.Windows.Forms.Button()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button_Save
        '
        Me.Button_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Save.Image = CType(resources.GetObject("Button_Save.Image"), System.Drawing.Image)
        Me.Button_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button_Save.Location = New System.Drawing.Point(414, 382)
        Me.Button_Save.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Save.Name = "Button_Save"
        Me.Button_Save.Size = New System.Drawing.Size(147, 47)
        Me.Button_Save.TabIndex = 11
        Me.Button_Save.Text = "Capture"
        Me.Button_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button_Save.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(337, 74)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(298, 300)
        Me.PictureBox2.TabIndex = 10
        Me.PictureBox2.TabStop = False
        '
        'ComboBox_Devices
        '
        Me.ComboBox_Devices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Devices.FormattingEnabled = True
        Me.ComboBox_Devices.Location = New System.Drawing.Point(17, 41)
        Me.ComboBox_Devices.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox_Devices.Name = "ComboBox_Devices"
        Me.ComboBox_Devices.Size = New System.Drawing.Size(297, 24)
        Me.ComboBox_Devices.TabIndex = 8
        '
        'lblCamera
        '
        Me.lblCamera.AutoSize = True
        Me.lblCamera.Location = New System.Drawing.Point(16, 21)
        Me.lblCamera.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCamera.Name = "lblCamera"
        Me.lblCamera.Size = New System.Drawing.Size(108, 17)
        Me.lblCamera.TabIndex = 7
        Me.lblCamera.Text = "Select Camera :"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(17, 74)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(298, 300)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(333, 54)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 17)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Picture Preview :"
        '
        'ComboBox_FrameSize
        '
        Me.ComboBox_FrameSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_FrameSize.FormattingEnabled = True
        Me.ComboBox_FrameSize.Location = New System.Drawing.Point(34, 455)
        Me.ComboBox_FrameSize.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox_FrameSize.Name = "ComboBox_FrameSize"
        Me.ComboBox_FrameSize.Size = New System.Drawing.Size(297, 24)
        Me.ComboBox_FrameSize.TabIndex = 13
        '
        'Button_Connect
        '
        Me.Button_Connect.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Connect.Image = CType(resources.GetObject("Button_Connect.Image"), System.Drawing.Image)
        Me.Button_Connect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button_Connect.Location = New System.Drawing.Point(96, 382)
        Me.Button_Connect.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Connect.Name = "Button_Connect"
        Me.Button_Connect.Size = New System.Drawing.Size(128, 47)
        Me.Button_Connect.TabIndex = 14
        Me.Button_Connect.Text = "Connect"
        Me.Button_Connect.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button_Connect.UseVisualStyleBackColor = True
        '
        'frmCamera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.BurlyWood
        Me.ClientSize = New System.Drawing.Size(653, 446)
        Me.Controls.Add(Me.Button_Connect)
        Me.Controls.Add(Me.ComboBox_FrameSize)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button_Save)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.ComboBox_Devices)
        Me.Controls.Add(Me.lblCamera)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCamera"
        Me.Text = "Webcam"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents Button_Save As System.Windows.Forms.Button
    Private WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Private WithEvents saveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Private WithEvents ComboBox_Devices As System.Windows.Forms.ComboBox
    Private WithEvents lblCamera As System.Windows.Forms.Label
    Private WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents ComboBox_FrameSize As ComboBox
    Private WithEvents Button_Connect As Button
End Class
