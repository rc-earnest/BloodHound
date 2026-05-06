<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class URCTestForm
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.COMSelectToolStripComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ConnectCOMToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DisconnetToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.COMSerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.SerialCOMTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Joystick1UDLabel = New System.Windows.Forms.Label()
        Me.Joystick1LRLabel = New System.Windows.Forms.Label()
        Me.Joystick2LRLabel = New System.Windows.Forms.Label()
        Me.Joystick2UDLabel = New System.Windows.Forms.Label()
        Me.Joystick3LRLabel = New System.Windows.Forms.Label()
        Me.Joystick3UDLabel = New System.Windows.Forms.Label()
        Me.RobotAddressDecLabel = New System.Windows.Forms.Label()
        Me.Joystick1LRTrackBar = New System.Windows.Forms.TrackBar()
        Me.Joystick1UDTrackBar = New System.Windows.Forms.TrackBar()
        Me.Joystick2LRTrackBar = New System.Windows.Forms.TrackBar()
        Me.Joystick2UDTrackBar = New System.Windows.Forms.TrackBar()
        Me.Joystick3LRTrackBar = New System.Windows.Forms.TrackBar()
        Me.Joystick3UDTrackBar = New System.Windows.Forms.TrackBar()
        Me.AddressLabel = New System.Windows.Forms.Label()
        Me.Joystick1Label = New System.Windows.Forms.Label()
        Me.Joystick2Label = New System.Windows.Forms.Label()
        Me.Joystick3Label = New System.Windows.Forms.Label()
        Me.Button1Indicator = New System.Windows.Forms.Button()
        Me.Button1Label = New System.Windows.Forms.Label()
        Me.Button2Label = New System.Windows.Forms.Label()
        Me.Button2Indicator = New System.Windows.Forms.Button()
        Me.Button3Label = New System.Windows.Forms.Label()
        Me.Button3Indicator = New System.Windows.Forms.Button()
        Me.Button4Label = New System.Windows.Forms.Label()
        Me.Button4Indicator = New System.Windows.Forms.Button()
        Me.LeftBumperLabel = New System.Windows.Forms.Label()
        Me.LeftBumperIndicatorButton = New System.Windows.Forms.Button()
        Me.RightBumperLabel = New System.Windows.Forms.Label()
        Me.RightBumperIndicatorButton = New System.Windows.Forms.Button()
        Me.Joystick1ButtonLabel = New System.Windows.Forms.Label()
        Me.Joystick1IndicatorButton = New System.Windows.Forms.Button()
        Me.Joystick2ButtonLabel = New System.Windows.Forms.Label()
        Me.Joystick2IndicatorButton = New System.Windows.Forms.Button()
        Me.Joystick3ButtonLabel = New System.Windows.Forms.Label()
        Me.Joystick3IndicatorButton = New System.Windows.Forms.Button()
        Me.StartUpTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConnectMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisconnectMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Joystick1MenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Joy1ToggleLeftRightDataMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Joy1ToggleLeftRightTrackBarMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Joy1ToggleUpDownDataMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Joy1ToggleUpDownTrackBarMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Joy1TogglePositionGraphMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Joy1ChangPositionDotColorMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Joy1SetDefaultJoystickDisplayMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Jostick2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Joy2ToggleLeftRightDataMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Joy2ToggleLeftRightTrackBarMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Joy2ToggleUpDownDataMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Joy2ToggleUpDownTrackBarMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Joy2TogglePositionGraphMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Joy2ChangePositionDotColorMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Joy2SetDefaultJoystickDisplayMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Joystick3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Joy3ToggleLeftRightDataMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Joy3ToggleLeftRightTrackBarMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Joy3ToggleUpDownDataMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Joy3ToggleUpDownTrackBarMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Joy3TogglePositionGraphMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Joy3ChangePositionDotColorMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Joy3SetDefaultJoystickDisplayMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ButtonsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeButtonOffColorMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeButtonOnColorMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetDefaultButtonColorsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackgroundImageMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PCBBackgroundMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CaseBackgroundMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NoneBackroundMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColorDialog = New System.Windows.Forms.ColorDialog()
        Me.RobotAddressHexLabel = New System.Windows.Forms.Label()
        Me.DecmalLabel = New System.Windows.Forms.Label()
        Me.HexLabel = New System.Windows.Forms.Label()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ClockStatusStripLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BlankStatusStripLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.COMStatusStripLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ClockTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ISULogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.Joystick3PictureBox = New System.Windows.Forms.PictureBox()
        Me.Joystick2PictureBox = New System.Windows.Forms.PictureBox()
        Me.Joystick1PictureBox = New System.Windows.Forms.PictureBox()
        Me.CaseBackgroundPictureBox = New System.Windows.Forms.PictureBox()
        Me.PCBBackgroundPictureBox = New System.Windows.Forms.PictureBox()
        Me.URCLabel = New System.Windows.Forms.Label()
        Me.TxModeRadioButton = New System.Windows.Forms.RadioButton()
        Me.RxModeRadioButton = New System.Windows.Forms.RadioButton()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.Joystick1LRTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Joystick1UDTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Joystick2LRTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Joystick2UDTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Joystick3LRTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Joystick3UDTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        CType(Me.ISULogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Joystick3PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Joystick2PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Joystick1PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaseBackgroundPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCBBackgroundPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.COMSelectToolStripComboBox, Me.ToolStripSeparator1, Me.ConnectCOMToolStripButton, Me.ToolStripSeparator2, Me.DisconnetToolStripButton, Me.ToolStripSeparator3, Me.RefreshToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 30)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(944, 31)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'COMSelectToolStripComboBox
        '
        Me.COMSelectToolStripComboBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.COMSelectToolStripComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.COMSelectToolStripComboBox.Name = "COMSelectToolStripComboBox"
        Me.COMSelectToolStripComboBox.Size = New System.Drawing.Size(121, 31)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'ConnectCOMToolStripButton
        '
        Me.ConnectCOMToolStripButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.ConnectCOMToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ConnectCOMToolStripButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConnectCOMToolStripButton.Image = Global.Universal_Remote_Control_Test_Software.My.Resources.Resources.icons8_usb_connector_30
        Me.ConnectCOMToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ConnectCOMToolStripButton.Name = "ConnectCOMToolStripButton"
        Me.ConnectCOMToolStripButton.Size = New System.Drawing.Size(29, 28)
        Me.ConnectCOMToolStripButton.Text = "ToolStripButton1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'DisconnetToolStripButton
        '
        Me.DisconnetToolStripButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.DisconnetToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DisconnetToolStripButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DisconnetToolStripButton.Image = Global.Universal_Remote_Control_Test_Software.My.Resources.Resources.icons8_disconnect_30
        Me.DisconnetToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DisconnetToolStripButton.Name = "DisconnetToolStripButton"
        Me.DisconnetToolStripButton.Size = New System.Drawing.Size(29, 28)
        Me.DisconnetToolStripButton.Text = "ToolStripButton1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'RefreshToolStripButton
        '
        Me.RefreshToolStripButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.RefreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RefreshToolStripButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefreshToolStripButton.Image = Global.Universal_Remote_Control_Test_Software.My.Resources.Resources.icons8_refresh_24
        Me.RefreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RefreshToolStripButton.Name = "RefreshToolStripButton"
        Me.RefreshToolStripButton.Size = New System.Drawing.Size(29, 28)
        Me.RefreshToolStripButton.Text = "ToolStripButton1"
        '
        'COMSerialPort
        '
        Me.COMSerialPort.ReadTimeout = 250
        Me.COMSerialPort.WriteTimeout = 250
        '
        'ExitButton
        '
        Me.ExitButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.ExitButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ExitButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ExitButton.Location = New System.Drawing.Point(840, 554)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(90, 52)
        Me.ExitButton.TabIndex = 1
        Me.ExitButton.Text = "Exit"
        Me.ExitButton.UseVisualStyleBackColor = False
        '
        'SerialCOMTimer
        '
        '
        'Joystick1UDLabel
        '
        Me.Joystick1UDLabel.AutoSize = True
        Me.Joystick1UDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Joystick1UDLabel.Location = New System.Drawing.Point(293, 511)
        Me.Joystick1UDLabel.Name = "Joystick1UDLabel"
        Me.Joystick1UDLabel.Size = New System.Drawing.Size(32, 18)
        Me.Joystick1UDLabel.TabIndex = 2
        Me.Joystick1UDLabel.Text = "128"
        '
        'Joystick1LRLabel
        '
        Me.Joystick1LRLabel.AutoSize = True
        Me.Joystick1LRLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Joystick1LRLabel.Location = New System.Drawing.Point(194, 418)
        Me.Joystick1LRLabel.Name = "Joystick1LRLabel"
        Me.Joystick1LRLabel.Size = New System.Drawing.Size(32, 18)
        Me.Joystick1LRLabel.TabIndex = 3
        Me.Joystick1LRLabel.Text = "128"
        Me.Joystick1LRLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Joystick2LRLabel
        '
        Me.Joystick2LRLabel.AutoSize = True
        Me.Joystick2LRLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Joystick2LRLabel.Location = New System.Drawing.Point(681, 406)
        Me.Joystick2LRLabel.Name = "Joystick2LRLabel"
        Me.Joystick2LRLabel.Size = New System.Drawing.Size(32, 18)
        Me.Joystick2LRLabel.TabIndex = 5
        Me.Joystick2LRLabel.Text = "128"
        Me.Joystick2LRLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Joystick2UDLabel
        '
        Me.Joystick2UDLabel.AutoSize = True
        Me.Joystick2UDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Joystick2UDLabel.Location = New System.Drawing.Point(785, 500)
        Me.Joystick2UDLabel.Name = "Joystick2UDLabel"
        Me.Joystick2UDLabel.Size = New System.Drawing.Size(32, 18)
        Me.Joystick2UDLabel.TabIndex = 4
        Me.Joystick2UDLabel.Text = "128"
        '
        'Joystick3LRLabel
        '
        Me.Joystick3LRLabel.AutoSize = True
        Me.Joystick3LRLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Joystick3LRLabel.Location = New System.Drawing.Point(794, 207)
        Me.Joystick3LRLabel.Name = "Joystick3LRLabel"
        Me.Joystick3LRLabel.Size = New System.Drawing.Size(32, 18)
        Me.Joystick3LRLabel.TabIndex = 7
        Me.Joystick3LRLabel.Text = "128"
        Me.Joystick3LRLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Joystick3UDLabel
        '
        Me.Joystick3UDLabel.AutoSize = True
        Me.Joystick3UDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Joystick3UDLabel.Location = New System.Drawing.Point(898, 304)
        Me.Joystick3UDLabel.Name = "Joystick3UDLabel"
        Me.Joystick3UDLabel.Size = New System.Drawing.Size(32, 18)
        Me.Joystick3UDLabel.TabIndex = 6
        Me.Joystick3UDLabel.Text = "128"
        '
        'RobotAddressDecLabel
        '
        Me.RobotAddressDecLabel.AutoSize = True
        Me.RobotAddressDecLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RobotAddressDecLabel.Location = New System.Drawing.Point(492, 255)
        Me.RobotAddressDecLabel.Name = "RobotAddressDecLabel"
        Me.RobotAddressDecLabel.Size = New System.Drawing.Size(107, 18)
        Me.RobotAddressDecLabel.TabIndex = 8
        Me.RobotAddressDecLabel.Text = "Robot Address"
        Me.RobotAddressDecLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Joystick1LRTrackBar
        '
        Me.Joystick1LRTrackBar.Location = New System.Drawing.Point(160, 433)
        Me.Joystick1LRTrackBar.Maximum = 255
        Me.Joystick1LRTrackBar.Name = "Joystick1LRTrackBar"
        Me.Joystick1LRTrackBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Joystick1LRTrackBar.Size = New System.Drawing.Size(110, 56)
        Me.Joystick1LRTrackBar.TabIndex = 9
        Me.Joystick1LRTrackBar.TabStop = False
        '
        'Joystick1UDTrackBar
        '
        Me.Joystick1UDTrackBar.Location = New System.Drawing.Point(255, 469)
        Me.Joystick1UDTrackBar.Maximum = 255
        Me.Joystick1UDTrackBar.Name = "Joystick1UDTrackBar"
        Me.Joystick1UDTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.Joystick1UDTrackBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Joystick1UDTrackBar.Size = New System.Drawing.Size(56, 110)
        Me.Joystick1UDTrackBar.TabIndex = 10
        Me.Joystick1UDTrackBar.TabStop = False
        Me.Joystick1UDTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        '
        'Joystick2LRTrackBar
        '
        Me.Joystick2LRTrackBar.Location = New System.Drawing.Point(649, 422)
        Me.Joystick2LRTrackBar.Maximum = 255
        Me.Joystick2LRTrackBar.Name = "Joystick2LRTrackBar"
        Me.Joystick2LRTrackBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Joystick2LRTrackBar.Size = New System.Drawing.Size(110, 56)
        Me.Joystick2LRTrackBar.TabIndex = 11
        Me.Joystick2LRTrackBar.TabStop = False
        '
        'Joystick2UDTrackBar
        '
        Me.Joystick2UDTrackBar.Location = New System.Drawing.Point(747, 452)
        Me.Joystick2UDTrackBar.Maximum = 255
        Me.Joystick2UDTrackBar.Name = "Joystick2UDTrackBar"
        Me.Joystick2UDTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.Joystick2UDTrackBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Joystick2UDTrackBar.Size = New System.Drawing.Size(56, 110)
        Me.Joystick2UDTrackBar.TabIndex = 12
        Me.Joystick2UDTrackBar.TabStop = False
        Me.Joystick2UDTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        '
        'Joystick3LRTrackBar
        '
        Me.Joystick3LRTrackBar.Location = New System.Drawing.Point(763, 223)
        Me.Joystick3LRTrackBar.Maximum = 255
        Me.Joystick3LRTrackBar.Name = "Joystick3LRTrackBar"
        Me.Joystick3LRTrackBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Joystick3LRTrackBar.Size = New System.Drawing.Size(110, 56)
        Me.Joystick3LRTrackBar.TabIndex = 13
        Me.Joystick3LRTrackBar.TabStop = False
        '
        'Joystick3UDTrackBar
        '
        Me.Joystick3UDTrackBar.Location = New System.Drawing.Point(859, 257)
        Me.Joystick3UDTrackBar.Maximum = 255
        Me.Joystick3UDTrackBar.Name = "Joystick3UDTrackBar"
        Me.Joystick3UDTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.Joystick3UDTrackBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Joystick3UDTrackBar.Size = New System.Drawing.Size(56, 110)
        Me.Joystick3UDTrackBar.TabIndex = 14
        Me.Joystick3UDTrackBar.TabStop = False
        Me.Joystick3UDTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        '
        'AddressLabel
        '
        Me.AddressLabel.AutoSize = True
        Me.AddressLabel.BackColor = System.Drawing.Color.Transparent
        Me.AddressLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddressLabel.Location = New System.Drawing.Point(407, 233)
        Me.AddressLabel.Name = "AddressLabel"
        Me.AddressLabel.Size = New System.Drawing.Size(120, 20)
        Me.AddressLabel.TabIndex = 15
        Me.AddressLabel.Text = "Robot Address"
        Me.AddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Joystick1Label
        '
        Me.Joystick1Label.AutoSize = True
        Me.Joystick1Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Joystick1Label.Location = New System.Drawing.Point(165, 393)
        Me.Joystick1Label.Name = "Joystick1Label"
        Me.Joystick1Label.Size = New System.Drawing.Size(84, 20)
        Me.Joystick1Label.TabIndex = 16
        Me.Joystick1Label.Text = "Joystick 1"
        '
        'Joystick2Label
        '
        Me.Joystick2Label.AutoSize = True
        Me.Joystick2Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Joystick2Label.Location = New System.Drawing.Point(649, 382)
        Me.Joystick2Label.Name = "Joystick2Label"
        Me.Joystick2Label.Size = New System.Drawing.Size(84, 20)
        Me.Joystick2Label.TabIndex = 17
        Me.Joystick2Label.Text = "Joystick 2"
        '
        'Joystick3Label
        '
        Me.Joystick3Label.AutoSize = True
        Me.Joystick3Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Joystick3Label.Location = New System.Drawing.Point(762, 183)
        Me.Joystick3Label.Name = "Joystick3Label"
        Me.Joystick3Label.Size = New System.Drawing.Size(84, 20)
        Me.Joystick3Label.TabIndex = 18
        Me.Joystick3Label.Text = "Joystick 3"
        '
        'Button1Indicator
        '
        Me.Button1Indicator.BackColor = System.Drawing.Color.Gray
        Me.Button1Indicator.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1Indicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1Indicator.Location = New System.Drawing.Point(107, 359)
        Me.Button1Indicator.Name = "Button1Indicator"
        Me.Button1Indicator.Size = New System.Drawing.Size(17, 19)
        Me.Button1Indicator.TabIndex = 19
        Me.Button1Indicator.UseVisualStyleBackColor = False
        '
        'Button1Label
        '
        Me.Button1Label.AutoSize = True
        Me.Button1Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1Label.Location = New System.Drawing.Point(86, 381)
        Me.Button1Label.Name = "Button1Label"
        Me.Button1Label.Size = New System.Drawing.Size(63, 18)
        Me.Button1Label.TabIndex = 20
        Me.Button1Label.Text = "Button 1"
        '
        'Button2Label
        '
        Me.Button2Label.AutoSize = True
        Me.Button2Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2Label.Location = New System.Drawing.Point(148, 311)
        Me.Button2Label.Name = "Button2Label"
        Me.Button2Label.Size = New System.Drawing.Size(63, 18)
        Me.Button2Label.TabIndex = 22
        Me.Button2Label.Text = "Button 2"
        '
        'Button2Indicator
        '
        Me.Button2Indicator.BackColor = System.Drawing.Color.Gray
        Me.Button2Indicator.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button2Indicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2Indicator.Location = New System.Drawing.Point(169, 289)
        Me.Button2Indicator.Name = "Button2Indicator"
        Me.Button2Indicator.Size = New System.Drawing.Size(17, 19)
        Me.Button2Indicator.TabIndex = 21
        Me.Button2Indicator.UseVisualStyleBackColor = False
        '
        'Button3Label
        '
        Me.Button3Label.AutoSize = True
        Me.Button3Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3Label.Location = New System.Drawing.Point(23, 311)
        Me.Button3Label.Name = "Button3Label"
        Me.Button3Label.Size = New System.Drawing.Size(63, 18)
        Me.Button3Label.TabIndex = 24
        Me.Button3Label.Text = "Button 3"
        '
        'Button3Indicator
        '
        Me.Button3Indicator.BackColor = System.Drawing.Color.Gray
        Me.Button3Indicator.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button3Indicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3Indicator.Location = New System.Drawing.Point(44, 289)
        Me.Button3Indicator.Name = "Button3Indicator"
        Me.Button3Indicator.Size = New System.Drawing.Size(17, 19)
        Me.Button3Indicator.TabIndex = 23
        Me.Button3Indicator.UseVisualStyleBackColor = False
        '
        'Button4Label
        '
        Me.Button4Label.AutoSize = True
        Me.Button4Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4Label.Location = New System.Drawing.Point(86, 245)
        Me.Button4Label.Name = "Button4Label"
        Me.Button4Label.Size = New System.Drawing.Size(63, 18)
        Me.Button4Label.TabIndex = 26
        Me.Button4Label.Text = "Button 4"
        '
        'Button4Indicator
        '
        Me.Button4Indicator.BackColor = System.Drawing.Color.Gray
        Me.Button4Indicator.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button4Indicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4Indicator.Location = New System.Drawing.Point(107, 223)
        Me.Button4Indicator.Name = "Button4Indicator"
        Me.Button4Indicator.Size = New System.Drawing.Size(17, 19)
        Me.Button4Indicator.TabIndex = 25
        Me.Button4Indicator.UseVisualStyleBackColor = False
        '
        'LeftBumperLabel
        '
        Me.LeftBumperLabel.AutoSize = True
        Me.LeftBumperLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LeftBumperLabel.Location = New System.Drawing.Point(63, 156)
        Me.LeftBumperLabel.Name = "LeftBumperLabel"
        Me.LeftBumperLabel.Size = New System.Drawing.Size(88, 18)
        Me.LeftBumperLabel.TabIndex = 28
        Me.LeftBumperLabel.Text = "Left Bumper"
        '
        'LeftBumperIndicatorButton
        '
        Me.LeftBumperIndicatorButton.BackColor = System.Drawing.Color.Gray
        Me.LeftBumperIndicatorButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LeftBumperIndicatorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LeftBumperIndicatorButton.Location = New System.Drawing.Point(94, 134)
        Me.LeftBumperIndicatorButton.Name = "LeftBumperIndicatorButton"
        Me.LeftBumperIndicatorButton.Size = New System.Drawing.Size(17, 19)
        Me.LeftBumperIndicatorButton.TabIndex = 27
        Me.LeftBumperIndicatorButton.UseVisualStyleBackColor = False
        '
        'RightBumperLabel
        '
        Me.RightBumperLabel.AutoSize = True
        Me.RightBumperLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RightBumperLabel.Location = New System.Drawing.Point(797, 145)
        Me.RightBumperLabel.Name = "RightBumperLabel"
        Me.RightBumperLabel.Size = New System.Drawing.Size(98, 18)
        Me.RightBumperLabel.TabIndex = 30
        Me.RightBumperLabel.Text = "Right Bumper"
        '
        'RightBumperIndicatorButton
        '
        Me.RightBumperIndicatorButton.BackColor = System.Drawing.Color.Gray
        Me.RightBumperIndicatorButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RightBumperIndicatorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RightBumperIndicatorButton.Location = New System.Drawing.Point(834, 123)
        Me.RightBumperIndicatorButton.Name = "RightBumperIndicatorButton"
        Me.RightBumperIndicatorButton.Size = New System.Drawing.Size(17, 19)
        Me.RightBumperIndicatorButton.TabIndex = 29
        Me.RightBumperIndicatorButton.UseVisualStyleBackColor = False
        '
        'Joystick1ButtonLabel
        '
        Me.Joystick1ButtonLabel.AutoSize = True
        Me.Joystick1ButtonLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Joystick1ButtonLabel.Location = New System.Drawing.Point(148, 590)
        Me.Joystick1ButtonLabel.Name = "Joystick1ButtonLabel"
        Me.Joystick1ButtonLabel.Size = New System.Drawing.Size(122, 18)
        Me.Joystick1ButtonLabel.TabIndex = 32
        Me.Joystick1ButtonLabel.Text = "Joystick 1 Button"
        '
        'Joystick1IndicatorButton
        '
        Me.Joystick1IndicatorButton.BackColor = System.Drawing.Color.Gray
        Me.Joystick1IndicatorButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Joystick1IndicatorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Joystick1IndicatorButton.Location = New System.Drawing.Point(197, 568)
        Me.Joystick1IndicatorButton.Name = "Joystick1IndicatorButton"
        Me.Joystick1IndicatorButton.Size = New System.Drawing.Size(17, 19)
        Me.Joystick1IndicatorButton.TabIndex = 31
        Me.Joystick1IndicatorButton.UseVisualStyleBackColor = False
        '
        'Joystick2ButtonLabel
        '
        Me.Joystick2ButtonLabel.AutoSize = True
        Me.Joystick2ButtonLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Joystick2ButtonLabel.Location = New System.Drawing.Point(620, 582)
        Me.Joystick2ButtonLabel.Name = "Joystick2ButtonLabel"
        Me.Joystick2ButtonLabel.Size = New System.Drawing.Size(122, 18)
        Me.Joystick2ButtonLabel.TabIndex = 34
        Me.Joystick2ButtonLabel.Text = "Joystick 2 Button"
        '
        'Joystick2IndicatorButton
        '
        Me.Joystick2IndicatorButton.BackColor = System.Drawing.Color.Gray
        Me.Joystick2IndicatorButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Joystick2IndicatorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Joystick2IndicatorButton.Location = New System.Drawing.Point(694, 560)
        Me.Joystick2IndicatorButton.Name = "Joystick2IndicatorButton"
        Me.Joystick2IndicatorButton.Size = New System.Drawing.Size(17, 19)
        Me.Joystick2IndicatorButton.TabIndex = 33
        Me.Joystick2IndicatorButton.UseVisualStyleBackColor = False
        '
        'Joystick3ButtonLabel
        '
        Me.Joystick3ButtonLabel.AutoSize = True
        Me.Joystick3ButtonLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Joystick3ButtonLabel.Location = New System.Drawing.Point(760, 381)
        Me.Joystick3ButtonLabel.Name = "Joystick3ButtonLabel"
        Me.Joystick3ButtonLabel.Size = New System.Drawing.Size(122, 18)
        Me.Joystick3ButtonLabel.TabIndex = 36
        Me.Joystick3ButtonLabel.Text = "Joystick 3 Button"
        '
        'Joystick3IndicatorButton
        '
        Me.Joystick3IndicatorButton.BackColor = System.Drawing.Color.Gray
        Me.Joystick3IndicatorButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Joystick3IndicatorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Joystick3IndicatorButton.Location = New System.Drawing.Point(813, 359)
        Me.Joystick3IndicatorButton.Name = "Joystick3IndicatorButton"
        Me.Joystick3IndicatorButton.Size = New System.Drawing.Size(17, 19)
        Me.Joystick3IndicatorButton.TabIndex = 35
        Me.Joystick3IndicatorButton.UseVisualStyleBackColor = False
        '
        'StartUpTimer
        '
        Me.StartUpTimer.Interval = 1
        '
        'MenuStrip
        '
        Me.MenuStrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnectionToolStripMenuItem, Me.ViewToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(944, 30)
        Me.MenuStrip.TabIndex = 40
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'ConnectionToolStripMenuItem
        '
        Me.ConnectionToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.ConnectionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnectMenuItem, Me.DisconnectMenuItem})
        Me.ConnectionToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConnectionToolStripMenuItem.Name = "ConnectionToolStripMenuItem"
        Me.ConnectionToolStripMenuItem.Size = New System.Drawing.Size(107, 26)
        Me.ConnectionToolStripMenuItem.Text = "Connection"
        '
        'ConnectMenuItem
        '
        Me.ConnectMenuItem.Name = "ConnectMenuItem"
        Me.ConnectMenuItem.Size = New System.Drawing.Size(177, 26)
        Me.ConnectMenuItem.Text = "Connect"
        '
        'DisconnectMenuItem
        '
        Me.DisconnectMenuItem.Name = "DisconnectMenuItem"
        Me.DisconnectMenuItem.Size = New System.Drawing.Size(177, 26)
        Me.DisconnectMenuItem.Text = "Disconnect"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Joystick1MenuItem, Me.Jostick2ToolStripMenuItem, Me.Joystick3ToolStripMenuItem, Me.ButtonsMenuItem, Me.BackgroundImageMenuItem})
        Me.ViewToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(59, 26)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'Joystick1MenuItem
        '
        Me.Joystick1MenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Joy1ToggleLeftRightDataMenuItem, Me.Joy1ToggleLeftRightTrackBarMenuItem, Me.Joy1ToggleUpDownDataMenuItem, Me.Joy1ToggleUpDownTrackBarMenuItem, Me.Joy1TogglePositionGraphMenuItem, Me.Joy1ChangPositionDotColorMenuItem, Me.Joy1SetDefaultJoystickDisplayMenuItem})
        Me.Joystick1MenuItem.Name = "Joystick1MenuItem"
        Me.Joystick1MenuItem.Size = New System.Drawing.Size(231, 26)
        Me.Joystick1MenuItem.Text = "Joystick 1"
        '
        'Joy1ToggleLeftRightDataMenuItem
        '
        Me.Joy1ToggleLeftRightDataMenuItem.Name = "Joy1ToggleLeftRightDataMenuItem"
        Me.Joy1ToggleLeftRightDataMenuItem.Size = New System.Drawing.Size(303, 26)
        Me.Joy1ToggleLeftRightDataMenuItem.Text = "Toggle Left-Right Data"
        '
        'Joy1ToggleLeftRightTrackBarMenuItem
        '
        Me.Joy1ToggleLeftRightTrackBarMenuItem.Name = "Joy1ToggleLeftRightTrackBarMenuItem"
        Me.Joy1ToggleLeftRightTrackBarMenuItem.Size = New System.Drawing.Size(303, 26)
        Me.Joy1ToggleLeftRightTrackBarMenuItem.Text = "Toggle Left-Right Track Bar"
        '
        'Joy1ToggleUpDownDataMenuItem
        '
        Me.Joy1ToggleUpDownDataMenuItem.Name = "Joy1ToggleUpDownDataMenuItem"
        Me.Joy1ToggleUpDownDataMenuItem.Size = New System.Drawing.Size(303, 26)
        Me.Joy1ToggleUpDownDataMenuItem.Text = "Toggle Up-Down Data"
        '
        'Joy1ToggleUpDownTrackBarMenuItem
        '
        Me.Joy1ToggleUpDownTrackBarMenuItem.Name = "Joy1ToggleUpDownTrackBarMenuItem"
        Me.Joy1ToggleUpDownTrackBarMenuItem.Size = New System.Drawing.Size(303, 26)
        Me.Joy1ToggleUpDownTrackBarMenuItem.Text = "Toggle Up-Down Track Bar"
        '
        'Joy1TogglePositionGraphMenuItem
        '
        Me.Joy1TogglePositionGraphMenuItem.Name = "Joy1TogglePositionGraphMenuItem"
        Me.Joy1TogglePositionGraphMenuItem.Size = New System.Drawing.Size(303, 26)
        Me.Joy1TogglePositionGraphMenuItem.Text = "Toggle Position Graph"
        '
        'Joy1ChangPositionDotColorMenuItem
        '
        Me.Joy1ChangPositionDotColorMenuItem.Name = "Joy1ChangPositionDotColorMenuItem"
        Me.Joy1ChangPositionDotColorMenuItem.Size = New System.Drawing.Size(303, 26)
        Me.Joy1ChangPositionDotColorMenuItem.Text = "Chang Position Dot Color"
        '
        'Joy1SetDefaultJoystickDisplayMenuItem
        '
        Me.Joy1SetDefaultJoystickDisplayMenuItem.Name = "Joy1SetDefaultJoystickDisplayMenuItem"
        Me.Joy1SetDefaultJoystickDisplayMenuItem.Size = New System.Drawing.Size(303, 26)
        Me.Joy1SetDefaultJoystickDisplayMenuItem.Text = "Set Default Joystick Display"
        '
        'Jostick2ToolStripMenuItem
        '
        Me.Jostick2ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Joy2ToggleLeftRightDataMenuItem, Me.Joy2ToggleLeftRightTrackBarMenuItem, Me.Joy2ToggleUpDownDataMenuItem, Me.Joy2ToggleUpDownTrackBarMenuItem, Me.Joy2TogglePositionGraphMenuItem, Me.Joy2ChangePositionDotColorMenuItem, Me.Joy2SetDefaultJoystickDisplayMenuItem})
        Me.Jostick2ToolStripMenuItem.Name = "Jostick2ToolStripMenuItem"
        Me.Jostick2ToolStripMenuItem.Size = New System.Drawing.Size(231, 26)
        Me.Jostick2ToolStripMenuItem.Text = "Joystick 2"
        '
        'Joy2ToggleLeftRightDataMenuItem
        '
        Me.Joy2ToggleLeftRightDataMenuItem.Name = "Joy2ToggleLeftRightDataMenuItem"
        Me.Joy2ToggleLeftRightDataMenuItem.Size = New System.Drawing.Size(303, 26)
        Me.Joy2ToggleLeftRightDataMenuItem.Text = "Toggle Left-Right Data"
        '
        'Joy2ToggleLeftRightTrackBarMenuItem
        '
        Me.Joy2ToggleLeftRightTrackBarMenuItem.Name = "Joy2ToggleLeftRightTrackBarMenuItem"
        Me.Joy2ToggleLeftRightTrackBarMenuItem.Size = New System.Drawing.Size(303, 26)
        Me.Joy2ToggleLeftRightTrackBarMenuItem.Text = "Toggle Left-Right Track Bar"
        '
        'Joy2ToggleUpDownDataMenuItem
        '
        Me.Joy2ToggleUpDownDataMenuItem.Name = "Joy2ToggleUpDownDataMenuItem"
        Me.Joy2ToggleUpDownDataMenuItem.Size = New System.Drawing.Size(303, 26)
        Me.Joy2ToggleUpDownDataMenuItem.Text = "Toggle Up-Down Data"
        '
        'Joy2ToggleUpDownTrackBarMenuItem
        '
        Me.Joy2ToggleUpDownTrackBarMenuItem.Name = "Joy2ToggleUpDownTrackBarMenuItem"
        Me.Joy2ToggleUpDownTrackBarMenuItem.Size = New System.Drawing.Size(303, 26)
        Me.Joy2ToggleUpDownTrackBarMenuItem.Text = "Toggle Up-Down Track Bar"
        '
        'Joy2TogglePositionGraphMenuItem
        '
        Me.Joy2TogglePositionGraphMenuItem.Name = "Joy2TogglePositionGraphMenuItem"
        Me.Joy2TogglePositionGraphMenuItem.Size = New System.Drawing.Size(303, 26)
        Me.Joy2TogglePositionGraphMenuItem.Text = "Toggle Position Graph"
        '
        'Joy2ChangePositionDotColorMenuItem
        '
        Me.Joy2ChangePositionDotColorMenuItem.Name = "Joy2ChangePositionDotColorMenuItem"
        Me.Joy2ChangePositionDotColorMenuItem.Size = New System.Drawing.Size(303, 26)
        Me.Joy2ChangePositionDotColorMenuItem.Text = "Change Position Dot Color"
        '
        'Joy2SetDefaultJoystickDisplayMenuItem
        '
        Me.Joy2SetDefaultJoystickDisplayMenuItem.Name = "Joy2SetDefaultJoystickDisplayMenuItem"
        Me.Joy2SetDefaultJoystickDisplayMenuItem.Size = New System.Drawing.Size(303, 26)
        Me.Joy2SetDefaultJoystickDisplayMenuItem.Text = "Set Default Joystick Display"
        '
        'Joystick3ToolStripMenuItem
        '
        Me.Joystick3ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Joy3ToggleLeftRightDataMenuItem, Me.Joy3ToggleLeftRightTrackBarMenuItem, Me.Joy3ToggleUpDownDataMenuItem, Me.Joy3ToggleUpDownTrackBarMenuItem, Me.Joy3TogglePositionGraphMenuItem, Me.Joy3ChangePositionDotColorMenuItem, Me.Joy3SetDefaultJoystickDisplayMenuItem})
        Me.Joystick3ToolStripMenuItem.Name = "Joystick3ToolStripMenuItem"
        Me.Joystick3ToolStripMenuItem.Size = New System.Drawing.Size(231, 26)
        Me.Joystick3ToolStripMenuItem.Text = "Joystick 3"
        '
        'Joy3ToggleLeftRightDataMenuItem
        '
        Me.Joy3ToggleLeftRightDataMenuItem.Name = "Joy3ToggleLeftRightDataMenuItem"
        Me.Joy3ToggleLeftRightDataMenuItem.Size = New System.Drawing.Size(303, 26)
        Me.Joy3ToggleLeftRightDataMenuItem.Text = "Toggle Left-Right Data"
        '
        'Joy3ToggleLeftRightTrackBarMenuItem
        '
        Me.Joy3ToggleLeftRightTrackBarMenuItem.Name = "Joy3ToggleLeftRightTrackBarMenuItem"
        Me.Joy3ToggleLeftRightTrackBarMenuItem.Size = New System.Drawing.Size(303, 26)
        Me.Joy3ToggleLeftRightTrackBarMenuItem.Text = "Toggle Left-Right Track Bar"
        '
        'Joy3ToggleUpDownDataMenuItem
        '
        Me.Joy3ToggleUpDownDataMenuItem.Name = "Joy3ToggleUpDownDataMenuItem"
        Me.Joy3ToggleUpDownDataMenuItem.Size = New System.Drawing.Size(303, 26)
        Me.Joy3ToggleUpDownDataMenuItem.Text = "Toggle Up-Down Data"
        '
        'Joy3ToggleUpDownTrackBarMenuItem
        '
        Me.Joy3ToggleUpDownTrackBarMenuItem.Name = "Joy3ToggleUpDownTrackBarMenuItem"
        Me.Joy3ToggleUpDownTrackBarMenuItem.Size = New System.Drawing.Size(303, 26)
        Me.Joy3ToggleUpDownTrackBarMenuItem.Text = "Toggle Up-Down Track Bar"
        '
        'Joy3TogglePositionGraphMenuItem
        '
        Me.Joy3TogglePositionGraphMenuItem.Name = "Joy3TogglePositionGraphMenuItem"
        Me.Joy3TogglePositionGraphMenuItem.Size = New System.Drawing.Size(303, 26)
        Me.Joy3TogglePositionGraphMenuItem.Text = "Toggle Position Graph"
        '
        'Joy3ChangePositionDotColorMenuItem
        '
        Me.Joy3ChangePositionDotColorMenuItem.Name = "Joy3ChangePositionDotColorMenuItem"
        Me.Joy3ChangePositionDotColorMenuItem.Size = New System.Drawing.Size(303, 26)
        Me.Joy3ChangePositionDotColorMenuItem.Text = "Change Position Dot Color"
        '
        'Joy3SetDefaultJoystickDisplayMenuItem
        '
        Me.Joy3SetDefaultJoystickDisplayMenuItem.Name = "Joy3SetDefaultJoystickDisplayMenuItem"
        Me.Joy3SetDefaultJoystickDisplayMenuItem.Size = New System.Drawing.Size(303, 26)
        Me.Joy3SetDefaultJoystickDisplayMenuItem.Text = "Set Default Joystick Display"
        '
        'ButtonsMenuItem
        '
        Me.ButtonsMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeButtonOffColorMenuItem, Me.ChangeButtonOnColorMenuItem, Me.SetDefaultButtonColorsMenuItem})
        Me.ButtonsMenuItem.Name = "ButtonsMenuItem"
        Me.ButtonsMenuItem.Size = New System.Drawing.Size(231, 26)
        Me.ButtonsMenuItem.Text = "Buttons"
        '
        'ChangeButtonOffColorMenuItem
        '
        Me.ChangeButtonOffColorMenuItem.Name = "ChangeButtonOffColorMenuItem"
        Me.ChangeButtonOffColorMenuItem.Size = New System.Drawing.Size(284, 26)
        Me.ChangeButtonOffColorMenuItem.Text = "Change Button Off Color"
        '
        'ChangeButtonOnColorMenuItem
        '
        Me.ChangeButtonOnColorMenuItem.Name = "ChangeButtonOnColorMenuItem"
        Me.ChangeButtonOnColorMenuItem.Size = New System.Drawing.Size(284, 26)
        Me.ChangeButtonOnColorMenuItem.Text = "Change Button On Color"
        '
        'SetDefaultButtonColorsMenuItem
        '
        Me.SetDefaultButtonColorsMenuItem.Name = "SetDefaultButtonColorsMenuItem"
        Me.SetDefaultButtonColorsMenuItem.Size = New System.Drawing.Size(284, 26)
        Me.SetDefaultButtonColorsMenuItem.Text = "Set Default Button Colors"
        '
        'BackgroundImageMenuItem
        '
        Me.BackgroundImageMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PCBBackgroundMenuItem, Me.CaseBackgroundMenuItem, Me.NoneBackroundMenuItem})
        Me.BackgroundImageMenuItem.Name = "BackgroundImageMenuItem"
        Me.BackgroundImageMenuItem.Size = New System.Drawing.Size(231, 26)
        Me.BackgroundImageMenuItem.Text = "Background Image"
        '
        'PCBBackgroundMenuItem
        '
        Me.PCBBackgroundMenuItem.Name = "PCBBackgroundMenuItem"
        Me.PCBBackgroundMenuItem.Size = New System.Drawing.Size(131, 26)
        Me.PCBBackgroundMenuItem.Text = "PCB"
        '
        'CaseBackgroundMenuItem
        '
        Me.CaseBackgroundMenuItem.Name = "CaseBackgroundMenuItem"
        Me.CaseBackgroundMenuItem.Size = New System.Drawing.Size(131, 26)
        Me.CaseBackgroundMenuItem.Text = "Case"
        '
        'NoneBackroundMenuItem
        '
        Me.NoneBackroundMenuItem.Name = "NoneBackroundMenuItem"
        Me.NoneBackroundMenuItem.Size = New System.Drawing.Size(131, 26)
        Me.NoneBackroundMenuItem.Text = "None"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.AboutToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(66, 26)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'RobotAddressHexLabel
        '
        Me.RobotAddressHexLabel.AutoSize = True
        Me.RobotAddressHexLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RobotAddressHexLabel.Location = New System.Drawing.Point(492, 280)
        Me.RobotAddressHexLabel.Name = "RobotAddressHexLabel"
        Me.RobotAddressHexLabel.Size = New System.Drawing.Size(107, 18)
        Me.RobotAddressHexLabel.TabIndex = 43
        Me.RobotAddressHexLabel.Text = "Robot Address"
        Me.RobotAddressHexLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DecmalLabel
        '
        Me.DecmalLabel.AutoSize = True
        Me.DecmalLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DecmalLabel.Location = New System.Drawing.Point(416, 255)
        Me.DecmalLabel.Name = "DecmalLabel"
        Me.DecmalLabel.Size = New System.Drawing.Size(66, 18)
        Me.DecmalLabel.TabIndex = 44
        Me.DecmalLabel.Text = "Decimal:"
        Me.DecmalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'HexLabel
        '
        Me.HexLabel.AutoSize = True
        Me.HexLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HexLabel.Location = New System.Drawing.Point(438, 280)
        Me.HexLabel.Name = "HexLabel"
        Me.HexLabel.Size = New System.Drawing.Size(38, 18)
        Me.HexLabel.TabIndex = 45
        Me.HexLabel.Text = "Hex:"
        Me.HexLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'StatusStrip
        '
        Me.StatusStrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.StatusStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClockStatusStripLabel, Me.BlankStatusStripLabel, Me.COMStatusStripLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 614)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(944, 26)
        Me.StatusStrip.TabIndex = 46
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ClockStatusStripLabel
        '
        Me.ClockStatusStripLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.ClockStatusStripLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClockStatusStripLabel.Name = "ClockStatusStripLabel"
        Me.ClockStatusStripLabel.Size = New System.Drawing.Size(100, 20)
        Me.ClockStatusStripLabel.Text = "Time of Day"
        '
        'BlankStatusStripLabel
        '
        Me.BlankStatusStripLabel.Name = "BlankStatusStripLabel"
        Me.BlankStatusStripLabel.Size = New System.Drawing.Size(181, 20)
        Me.BlankStatusStripLabel.Text = "                                           "
        '
        'COMStatusStripLabel
        '
        Me.COMStatusStripLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.COMStatusStripLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.COMStatusStripLabel.Name = "COMStatusStripLabel"
        Me.COMStatusStripLabel.Size = New System.Drawing.Size(120, 20)
        Me.COMStatusStripLabel.Text = "Not Connected"
        '
        'ClockTimer
        '
        Me.ClockTimer.Enabled = True
        Me.ClockTimer.Interval = 1000
        '
        'ISULogoPictureBox
        '
        Me.ISULogoPictureBox.BackgroundImage = Global.Universal_Remote_Control_Test_Software.My.Resources.Resources.Gear2020
        Me.ISULogoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ISULogoPictureBox.Location = New System.Drawing.Point(397, 332)
        Me.ISULogoPictureBox.Name = "ISULogoPictureBox"
        Me.ISULogoPictureBox.Size = New System.Drawing.Size(188, 172)
        Me.ISULogoPictureBox.TabIndex = 47
        Me.ISULogoPictureBox.TabStop = False
        '
        'Joystick3PictureBox
        '
        Me.Joystick3PictureBox.Location = New System.Drawing.Point(774, 268)
        Me.Joystick3PictureBox.Name = "Joystick3PictureBox"
        Me.Joystick3PictureBox.Size = New System.Drawing.Size(85, 85)
        Me.Joystick3PictureBox.TabIndex = 39
        Me.Joystick3PictureBox.TabStop = False
        '
        'Joystick2PictureBox
        '
        Me.Joystick2PictureBox.Location = New System.Drawing.Point(661, 461)
        Me.Joystick2PictureBox.Name = "Joystick2PictureBox"
        Me.Joystick2PictureBox.Size = New System.Drawing.Size(85, 85)
        Me.Joystick2PictureBox.TabIndex = 38
        Me.Joystick2PictureBox.TabStop = False
        '
        'Joystick1PictureBox
        '
        Me.Joystick1PictureBox.Location = New System.Drawing.Point(169, 477)
        Me.Joystick1PictureBox.Name = "Joystick1PictureBox"
        Me.Joystick1PictureBox.Size = New System.Drawing.Size(85, 85)
        Me.Joystick1PictureBox.TabIndex = 37
        Me.Joystick1PictureBox.TabStop = False
        '
        'CaseBackgroundPictureBox
        '
        Me.CaseBackgroundPictureBox.BackgroundImage = Global.Universal_Remote_Control_Test_Software.My.Resources.Resources.URC_Case_1
        Me.CaseBackgroundPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CaseBackgroundPictureBox.Location = New System.Drawing.Point(6, 64)
        Me.CaseBackgroundPictureBox.Name = "CaseBackgroundPictureBox"
        Me.CaseBackgroundPictureBox.Size = New System.Drawing.Size(935, 550)
        Me.CaseBackgroundPictureBox.TabIndex = 42
        Me.CaseBackgroundPictureBox.TabStop = False
        Me.CaseBackgroundPictureBox.Visible = False
        '
        'PCBBackgroundPictureBox
        '
        Me.PCBBackgroundPictureBox.BackgroundImage = Global.Universal_Remote_Control_Test_Software.My.Resources.Resources.URC_PCB_1
        Me.PCBBackgroundPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PCBBackgroundPictureBox.Location = New System.Drawing.Point(6, 64)
        Me.PCBBackgroundPictureBox.Name = "PCBBackgroundPictureBox"
        Me.PCBBackgroundPictureBox.Size = New System.Drawing.Size(935, 550)
        Me.PCBBackgroundPictureBox.TabIndex = 41
        Me.PCBBackgroundPictureBox.TabStop = False
        Me.PCBBackgroundPictureBox.Visible = False
        '
        'URCLabel
        '
        Me.URCLabel.AutoSize = True
        Me.URCLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.URCLabel.Location = New System.Drawing.Point(287, 101)
        Me.URCLabel.Name = "URCLabel"
        Me.URCLabel.Size = New System.Drawing.Size(365, 102)
        Me.URCLabel.TabIndex = 48
        Me.URCLabel.Text = "Universal Remote" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Controller"
        Me.URCLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxModeRadioButton
        '
        Me.TxModeRadioButton.AutoSize = True
        Me.TxModeRadioButton.Location = New System.Drawing.Point(495, 12)
        Me.TxModeRadioButton.Name = "TxModeRadioButton"
        Me.TxModeRadioButton.Size = New System.Drawing.Size(78, 20)
        Me.TxModeRadioButton.TabIndex = 49
        Me.TxModeRadioButton.TabStop = True
        Me.TxModeRadioButton.Text = "TxMode"
        Me.TxModeRadioButton.UseVisualStyleBackColor = True
        '
        'RxModeRadioButton
        '
        Me.RxModeRadioButton.AutoSize = True
        Me.RxModeRadioButton.Location = New System.Drawing.Point(610, 12)
        Me.RxModeRadioButton.Name = "RxModeRadioButton"
        Me.RxModeRadioButton.Size = New System.Drawing.Size(79, 20)
        Me.RxModeRadioButton.TabIndex = 50
        Me.RxModeRadioButton.TabStop = True
        Me.RxModeRadioButton.Text = "RxMode"
        Me.RxModeRadioButton.UseVisualStyleBackColor = True
        '
        'URCTestForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(944, 640)
        Me.Controls.Add(Me.RxModeRadioButton)
        Me.Controls.Add(Me.TxModeRadioButton)
        Me.Controls.Add(Me.URCLabel)
        Me.Controls.Add(Me.ISULogoPictureBox)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.HexLabel)
        Me.Controls.Add(Me.DecmalLabel)
        Me.Controls.Add(Me.RobotAddressHexLabel)
        Me.Controls.Add(Me.Joystick3PictureBox)
        Me.Controls.Add(Me.Joystick2PictureBox)
        Me.Controls.Add(Me.Joystick1PictureBox)
        Me.Controls.Add(Me.Joystick3ButtonLabel)
        Me.Controls.Add(Me.Joystick3IndicatorButton)
        Me.Controls.Add(Me.Joystick2ButtonLabel)
        Me.Controls.Add(Me.Joystick2IndicatorButton)
        Me.Controls.Add(Me.Joystick1ButtonLabel)
        Me.Controls.Add(Me.Joystick1IndicatorButton)
        Me.Controls.Add(Me.RightBumperLabel)
        Me.Controls.Add(Me.RightBumperIndicatorButton)
        Me.Controls.Add(Me.LeftBumperLabel)
        Me.Controls.Add(Me.LeftBumperIndicatorButton)
        Me.Controls.Add(Me.Button4Label)
        Me.Controls.Add(Me.Button4Indicator)
        Me.Controls.Add(Me.Button3Label)
        Me.Controls.Add(Me.Button3Indicator)
        Me.Controls.Add(Me.Button2Label)
        Me.Controls.Add(Me.Button2Indicator)
        Me.Controls.Add(Me.Button1Label)
        Me.Controls.Add(Me.Button1Indicator)
        Me.Controls.Add(Me.Joystick3Label)
        Me.Controls.Add(Me.Joystick2Label)
        Me.Controls.Add(Me.Joystick1Label)
        Me.Controls.Add(Me.AddressLabel)
        Me.Controls.Add(Me.Joystick3UDLabel)
        Me.Controls.Add(Me.Joystick3UDTrackBar)
        Me.Controls.Add(Me.Joystick3LRTrackBar)
        Me.Controls.Add(Me.Joystick2UDLabel)
        Me.Controls.Add(Me.Joystick2UDTrackBar)
        Me.Controls.Add(Me.Joystick2LRTrackBar)
        Me.Controls.Add(Me.Joystick1UDLabel)
        Me.Controls.Add(Me.Joystick1UDTrackBar)
        Me.Controls.Add(Me.Joystick1LRTrackBar)
        Me.Controls.Add(Me.RobotAddressDecLabel)
        Me.Controls.Add(Me.Joystick3LRLabel)
        Me.Controls.Add(Me.Joystick2LRLabel)
        Me.Controls.Add(Me.Joystick1LRLabel)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.CaseBackgroundPictureBox)
        Me.Controls.Add(Me.PCBBackgroundPictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "URCTestForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Universal Remote Controller Testing"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.Joystick1LRTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Joystick1UDTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Joystick2LRTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Joystick2UDTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Joystick3LRTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Joystick3UDTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.ISULogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Joystick3PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Joystick2PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Joystick1PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaseBackgroundPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCBBackgroundPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents COMSelectToolStripComboBox As ToolStripComboBox
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ConnectCOMToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents DisconnetToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents COMSerialPort As IO.Ports.SerialPort
    Friend WithEvents ExitButton As Button
    Friend WithEvents SerialCOMTimer As Timer
    Friend WithEvents Joystick1UDLabel As Label
    Friend WithEvents Joystick1LRLabel As Label
    Friend WithEvents Joystick2LRLabel As Label
    Friend WithEvents Joystick2UDLabel As Label
    Friend WithEvents Joystick3LRLabel As Label
    Friend WithEvents Joystick3UDLabel As Label
    Friend WithEvents RobotAddressDecLabel As Label
    Friend WithEvents Joystick1LRTrackBar As TrackBar
    Friend WithEvents Joystick1UDTrackBar As TrackBar
    Friend WithEvents Joystick2LRTrackBar As TrackBar
    Friend WithEvents Joystick2UDTrackBar As TrackBar
    Friend WithEvents Joystick3LRTrackBar As TrackBar
    Friend WithEvents Joystick3UDTrackBar As TrackBar
    Friend WithEvents AddressLabel As Label
    Friend WithEvents Joystick1Label As Label
    Friend WithEvents Joystick2Label As Label
    Friend WithEvents Joystick3Label As Label
    Friend WithEvents Button1Indicator As Button
    Friend WithEvents Button1Label As Label
    Friend WithEvents Button2Label As Label
    Friend WithEvents Button2Indicator As Button
    Friend WithEvents Button3Label As Label
    Friend WithEvents Button3Indicator As Button
    Friend WithEvents Button4Label As Label
    Friend WithEvents Button4Indicator As Button
    Friend WithEvents LeftBumperLabel As Label
    Friend WithEvents LeftBumperIndicatorButton As Button
    Friend WithEvents RightBumperLabel As Label
    Friend WithEvents RightBumperIndicatorButton As Button
    Friend WithEvents Joystick1ButtonLabel As Label
    Friend WithEvents Joystick1IndicatorButton As Button
    Friend WithEvents Joystick2ButtonLabel As Label
    Friend WithEvents Joystick2IndicatorButton As Button
    Friend WithEvents Joystick3ButtonLabel As Label
    Friend WithEvents Joystick3IndicatorButton As Button
    Friend WithEvents Joystick1PictureBox As PictureBox
    Friend WithEvents StartUpTimer As Timer
    Friend WithEvents Joystick2PictureBox As PictureBox
    Friend WithEvents Joystick3PictureBox As PictureBox
    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents ConnectionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConnectMenuItem As ToolStripMenuItem
    Friend WithEvents DisconnectMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Joystick1MenuItem As ToolStripMenuItem
    Friend WithEvents Joy1ToggleLeftRightDataMenuItem As ToolStripMenuItem
    Friend WithEvents Joy1ToggleLeftRightTrackBarMenuItem As ToolStripMenuItem
    Friend WithEvents Jostick2ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Joystick3ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Joy1ToggleUpDownDataMenuItem As ToolStripMenuItem
    Friend WithEvents Joy1ToggleUpDownTrackBarMenuItem As ToolStripMenuItem
    Friend WithEvents Joy1TogglePositionGraphMenuItem As ToolStripMenuItem
    Friend WithEvents Joy2ToggleLeftRightDataMenuItem As ToolStripMenuItem
    Friend WithEvents Joy2ToggleLeftRightTrackBarMenuItem As ToolStripMenuItem
    Friend WithEvents Joy2ToggleUpDownDataMenuItem As ToolStripMenuItem
    Friend WithEvents Joy2ToggleUpDownTrackBarMenuItem As ToolStripMenuItem
    Friend WithEvents Joy2TogglePositionGraphMenuItem As ToolStripMenuItem
    Friend WithEvents Joy3ToggleLeftRightDataMenuItem As ToolStripMenuItem
    Friend WithEvents Joy3ToggleLeftRightTrackBarMenuItem As ToolStripMenuItem
    Friend WithEvents Joy3ToggleUpDownDataMenuItem As ToolStripMenuItem
    Friend WithEvents Joy3ToggleUpDownTrackBarMenuItem As ToolStripMenuItem
    Friend WithEvents Joy3TogglePositionGraphMenuItem As ToolStripMenuItem
    Friend WithEvents ButtonsMenuItem As ToolStripMenuItem
    Friend WithEvents ChangeButtonOffColorMenuItem As ToolStripMenuItem
    Friend WithEvents ChangeButtonOnColorMenuItem As ToolStripMenuItem
    Friend WithEvents ColorDialog As ColorDialog
    Friend WithEvents SetDefaultButtonColorsMenuItem As ToolStripMenuItem
    Friend WithEvents Joy1ChangPositionDotColorMenuItem As ToolStripMenuItem
    Friend WithEvents Joy2ChangePositionDotColorMenuItem As ToolStripMenuItem
    Friend WithEvents Joy3ChangePositionDotColorMenuItem As ToolStripMenuItem
    Friend WithEvents Joy1SetDefaultJoystickDisplayMenuItem As ToolStripMenuItem
    Friend WithEvents Joy2SetDefaultJoystickDisplayMenuItem As ToolStripMenuItem
    Friend WithEvents Joy3SetDefaultJoystickDisplayMenuItem As ToolStripMenuItem
    Friend WithEvents PCBBackgroundPictureBox As PictureBox
    Friend WithEvents BackgroundImageMenuItem As ToolStripMenuItem
    Friend WithEvents PCBBackgroundMenuItem As ToolStripMenuItem
    Friend WithEvents CaseBackgroundMenuItem As ToolStripMenuItem
    Friend WithEvents NoneBackroundMenuItem As ToolStripMenuItem
    Friend WithEvents CaseBackgroundPictureBox As PictureBox
    Friend WithEvents RobotAddressHexLabel As Label
    Friend WithEvents DecmalLabel As Label
    Friend WithEvents HexLabel As Label
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents ClockStatusStripLabel As ToolStripStatusLabel
    Friend WithEvents BlankStatusStripLabel As ToolStripStatusLabel
    Friend WithEvents COMStatusStripLabel As ToolStripStatusLabel
    Friend WithEvents ClockTimer As Timer
    Friend WithEvents RefreshToolStripButton As ToolStripButton
    Friend WithEvents ISULogoPictureBox As PictureBox
    Friend WithEvents URCLabel As Label
    Friend WithEvents TxModeRadioButton As RadioButton
    Friend WithEvents RxModeRadioButton As RadioButton
End Class
