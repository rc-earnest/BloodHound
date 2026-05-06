<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class URCTxForm
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
        Me.SerialTXTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TxStartUpTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TxAddressNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.TxStatusLabel = New System.Windows.Forms.Label()
        Me.Joystick1UDTrackBar = New System.Windows.Forms.TrackBar()
        Me.Joystick2UDTrackBar = New System.Windows.Forms.TrackBar()
        Me.Joystick3UDTrackBar = New System.Windows.Forms.TrackBar()
        Me.Joystick1LRTrackBar = New System.Windows.Forms.TrackBar()
        Me.Joystick2LRTrackBar = New System.Windows.Forms.TrackBar()
        Me.Joystick3LRTrackBar = New System.Windows.Forms.TrackBar()
        Me.Joystick1UDLabel = New System.Windows.Forms.Label()
        Me.Joystick2UDLabel = New System.Windows.Forms.Label()
        Me.Joystick3UDLabel = New System.Windows.Forms.Label()
        Me.Joystick1LRLabel = New System.Windows.Forms.Label()
        Me.Joystick2LRLabel = New System.Windows.Forms.Label()
        Me.Joystick3LRLabel = New System.Windows.Forms.Label()
        Me.Joystick1PictureBox = New System.Windows.Forms.PictureBox()
        Me.Joystick2PictureBox = New System.Windows.Forms.PictureBox()
        Me.Joystick3PictureBox = New System.Windows.Forms.PictureBox()
        Me.Button1ToggleButton = New System.Windows.Forms.Button()
        Me.Button2ToggleButton = New System.Windows.Forms.Button()
        Me.Button3ToggleButton = New System.Windows.Forms.Button()
        Me.Button4ToggleButton = New System.Windows.Forms.Button()
        Me.LeftBumperToggleButton = New System.Windows.Forms.Button()
        Me.RightBumperToggleButton = New System.Windows.Forms.Button()
        Me.Joy1ButtonToggleButton = New System.Windows.Forms.Button()
        Me.Joy2ButtonToggleButton = New System.Windows.Forms.Button()
        Me.Joy3ButtonToggleButton = New System.Windows.Forms.Button()
        Me.AddressLabel = New System.Windows.Forms.Label()
        CType(Me.TxAddressNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Joystick1UDTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Joystick2UDTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Joystick3UDTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Joystick1LRTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Joystick2LRTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Joystick3LRTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Joystick1PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Joystick2PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Joystick3PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SerialTXTimer
        '
        Me.SerialTXTimer.Interval = 20
        '
        'TxStartUpTimer
        '
        Me.TxStartUpTimer.Interval = 200
        '
        'TxAddressNumericUpDown
        '
        Me.TxAddressNumericUpDown.Location = New System.Drawing.Point(60, 19)
        Me.TxAddressNumericUpDown.Name = "TxAddressNumericUpDown"
        Me.TxAddressNumericUpDown.Size = New System.Drawing.Size(120, 22)
        Me.TxAddressNumericUpDown.TabIndex = 0
        '
        'TxStatusLabel
        '
        Me.TxStatusLabel.AutoSize = True
        Me.TxStatusLabel.Location = New System.Drawing.Point(239, 19)
        Me.TxStatusLabel.Name = "TxStatusLabel"
        Me.TxStatusLabel.Size = New System.Drawing.Size(48, 16)
        Me.TxStatusLabel.TabIndex = 1
        Me.TxStatusLabel.Text = "Label1"
        '
        'Joystick1UDTrackBar
        '
        Me.Joystick1UDTrackBar.Location = New System.Drawing.Point(41, 91)
        Me.Joystick1UDTrackBar.Maximum = 255
        Me.Joystick1UDTrackBar.Name = "Joystick1UDTrackBar"
        Me.Joystick1UDTrackBar.Size = New System.Drawing.Size(104, 56)
        Me.Joystick1UDTrackBar.TabIndex = 2
        '
        'Joystick2UDTrackBar
        '
        Me.Joystick2UDTrackBar.Location = New System.Drawing.Point(41, 153)
        Me.Joystick2UDTrackBar.Maximum = 255
        Me.Joystick2UDTrackBar.Name = "Joystick2UDTrackBar"
        Me.Joystick2UDTrackBar.Size = New System.Drawing.Size(104, 56)
        Me.Joystick2UDTrackBar.TabIndex = 3
        '
        'Joystick3UDTrackBar
        '
        Me.Joystick3UDTrackBar.Location = New System.Drawing.Point(41, 215)
        Me.Joystick3UDTrackBar.Maximum = 255
        Me.Joystick3UDTrackBar.Name = "Joystick3UDTrackBar"
        Me.Joystick3UDTrackBar.Size = New System.Drawing.Size(104, 56)
        Me.Joystick3UDTrackBar.TabIndex = 4
        '
        'Joystick1LRTrackBar
        '
        Me.Joystick1LRTrackBar.Location = New System.Drawing.Point(164, 91)
        Me.Joystick1LRTrackBar.Maximum = 255
        Me.Joystick1LRTrackBar.Name = "Joystick1LRTrackBar"
        Me.Joystick1LRTrackBar.Size = New System.Drawing.Size(104, 56)
        Me.Joystick1LRTrackBar.TabIndex = 5
        '
        'Joystick2LRTrackBar
        '
        Me.Joystick2LRTrackBar.Location = New System.Drawing.Point(164, 153)
        Me.Joystick2LRTrackBar.Maximum = 255
        Me.Joystick2LRTrackBar.Name = "Joystick2LRTrackBar"
        Me.Joystick2LRTrackBar.Size = New System.Drawing.Size(104, 56)
        Me.Joystick2LRTrackBar.TabIndex = 6
        '
        'Joystick3LRTrackBar
        '
        Me.Joystick3LRTrackBar.Location = New System.Drawing.Point(164, 215)
        Me.Joystick3LRTrackBar.Maximum = 255
        Me.Joystick3LRTrackBar.Name = "Joystick3LRTrackBar"
        Me.Joystick3LRTrackBar.Size = New System.Drawing.Size(104, 56)
        Me.Joystick3LRTrackBar.TabIndex = 7
        '
        'Joystick1UDLabel
        '
        Me.Joystick1UDLabel.AutoSize = True
        Me.Joystick1UDLabel.Location = New System.Drawing.Point(57, 72)
        Me.Joystick1UDLabel.Name = "Joystick1UDLabel"
        Me.Joystick1UDLabel.Size = New System.Drawing.Size(86, 16)
        Me.Joystick1UDLabel.TabIndex = 8
        Me.Joystick1UDLabel.Text = "Joystick1 UD"
        '
        'Joystick2UDLabel
        '
        Me.Joystick2UDLabel.AutoSize = True
        Me.Joystick2UDLabel.Location = New System.Drawing.Point(57, 131)
        Me.Joystick2UDLabel.Name = "Joystick2UDLabel"
        Me.Joystick2UDLabel.Size = New System.Drawing.Size(86, 16)
        Me.Joystick2UDLabel.TabIndex = 9
        Me.Joystick2UDLabel.Text = "Joystick2 UD"
        '
        'Joystick3UDLabel
        '
        Me.Joystick3UDLabel.AutoSize = True
        Me.Joystick3UDLabel.Location = New System.Drawing.Point(57, 193)
        Me.Joystick3UDLabel.Name = "Joystick3UDLabel"
        Me.Joystick3UDLabel.Size = New System.Drawing.Size(86, 16)
        Me.Joystick3UDLabel.TabIndex = 10
        Me.Joystick3UDLabel.Text = "Joystick3 UD"
        '
        'Joystick1LRLabel
        '
        Me.Joystick1LRLabel.AutoSize = True
        Me.Joystick1LRLabel.Location = New System.Drawing.Point(172, 72)
        Me.Joystick1LRLabel.Name = "Joystick1LRLabel"
        Me.Joystick1LRLabel.Size = New System.Drawing.Size(83, 16)
        Me.Joystick1LRLabel.TabIndex = 11
        Me.Joystick1LRLabel.Text = "Joystick1 LR"
        '
        'Joystick2LRLabel
        '
        Me.Joystick2LRLabel.AutoSize = True
        Me.Joystick2LRLabel.Location = New System.Drawing.Point(172, 131)
        Me.Joystick2LRLabel.Name = "Joystick2LRLabel"
        Me.Joystick2LRLabel.Size = New System.Drawing.Size(83, 16)
        Me.Joystick2LRLabel.TabIndex = 12
        Me.Joystick2LRLabel.Text = "Joystick2 LR"
        '
        'Joystick3LRLabel
        '
        Me.Joystick3LRLabel.AutoSize = True
        Me.Joystick3LRLabel.Location = New System.Drawing.Point(172, 196)
        Me.Joystick3LRLabel.Name = "Joystick3LRLabel"
        Me.Joystick3LRLabel.Size = New System.Drawing.Size(83, 16)
        Me.Joystick3LRLabel.TabIndex = 13
        Me.Joystick3LRLabel.Text = "Joystick3 LR"
        '
        'Joystick1PictureBox
        '
        Me.Joystick1PictureBox.Location = New System.Drawing.Point(60, 253)
        Me.Joystick1PictureBox.Name = "Joystick1PictureBox"
        Me.Joystick1PictureBox.Size = New System.Drawing.Size(85, 85)
        Me.Joystick1PictureBox.TabIndex = 14
        Me.Joystick1PictureBox.TabStop = False
        '
        'Joystick2PictureBox
        '
        Me.Joystick2PictureBox.Location = New System.Drawing.Point(183, 253)
        Me.Joystick2PictureBox.Name = "Joystick2PictureBox"
        Me.Joystick2PictureBox.Size = New System.Drawing.Size(85, 85)
        Me.Joystick2PictureBox.TabIndex = 15
        Me.Joystick2PictureBox.TabStop = False
        '
        'Joystick3PictureBox
        '
        Me.Joystick3PictureBox.Location = New System.Drawing.Point(281, 253)
        Me.Joystick3PictureBox.Name = "Joystick3PictureBox"
        Me.Joystick3PictureBox.Size = New System.Drawing.Size(85, 85)
        Me.Joystick3PictureBox.TabIndex = 16
        Me.Joystick3PictureBox.TabStop = False
        '
        'Button1ToggleButton
        '
        Me.Button1ToggleButton.Location = New System.Drawing.Point(374, 72)
        Me.Button1ToggleButton.Name = "Button1ToggleButton"
        Me.Button1ToggleButton.Size = New System.Drawing.Size(75, 23)
        Me.Button1ToggleButton.TabIndex = 17
        Me.Button1ToggleButton.Text = "A"
        Me.Button1ToggleButton.UseVisualStyleBackColor = True
        '
        'Button2ToggleButton
        '
        Me.Button2ToggleButton.Location = New System.Drawing.Point(374, 101)
        Me.Button2ToggleButton.Name = "Button2ToggleButton"
        Me.Button2ToggleButton.Size = New System.Drawing.Size(75, 23)
        Me.Button2ToggleButton.TabIndex = 18
        Me.Button2ToggleButton.Text = "B"
        Me.Button2ToggleButton.UseVisualStyleBackColor = True
        '
        'Button3ToggleButton
        '
        Me.Button3ToggleButton.Location = New System.Drawing.Point(455, 72)
        Me.Button3ToggleButton.Name = "Button3ToggleButton"
        Me.Button3ToggleButton.Size = New System.Drawing.Size(75, 23)
        Me.Button3ToggleButton.TabIndex = 19
        Me.Button3ToggleButton.Text = "X"
        Me.Button3ToggleButton.UseVisualStyleBackColor = True
        '
        'Button4ToggleButton
        '
        Me.Button4ToggleButton.Location = New System.Drawing.Point(455, 101)
        Me.Button4ToggleButton.Name = "Button4ToggleButton"
        Me.Button4ToggleButton.Size = New System.Drawing.Size(75, 23)
        Me.Button4ToggleButton.TabIndex = 20
        Me.Button4ToggleButton.Text = "Y"
        Me.Button4ToggleButton.UseVisualStyleBackColor = True
        '
        'LeftBumperToggleButton
        '
        Me.LeftBumperToggleButton.Location = New System.Drawing.Point(306, 43)
        Me.LeftBumperToggleButton.Name = "LeftBumperToggleButton"
        Me.LeftBumperToggleButton.Size = New System.Drawing.Size(75, 23)
        Me.LeftBumperToggleButton.TabIndex = 21
        Me.LeftBumperToggleButton.Text = "LT"
        Me.LeftBumperToggleButton.UseVisualStyleBackColor = True
        '
        'RightBumperToggleButton
        '
        Me.RightBumperToggleButton.Location = New System.Drawing.Point(531, 43)
        Me.RightBumperToggleButton.Name = "RightBumperToggleButton"
        Me.RightBumperToggleButton.Size = New System.Drawing.Size(75, 23)
        Me.RightBumperToggleButton.TabIndex = 22
        Me.RightBumperToggleButton.Text = "RT"
        Me.RightBumperToggleButton.UseVisualStyleBackColor = True
        '
        'Joy1ButtonToggleButton
        '
        Me.Joy1ButtonToggleButton.Location = New System.Drawing.Point(70, 344)
        Me.Joy1ButtonToggleButton.Name = "Joy1ButtonToggleButton"
        Me.Joy1ButtonToggleButton.Size = New System.Drawing.Size(75, 23)
        Me.Joy1ButtonToggleButton.TabIndex = 23
        Me.Joy1ButtonToggleButton.Text = "Joy1"
        Me.Joy1ButtonToggleButton.UseVisualStyleBackColor = True
        '
        'Joy2ButtonToggleButton
        '
        Me.Joy2ButtonToggleButton.Location = New System.Drawing.Point(193, 344)
        Me.Joy2ButtonToggleButton.Name = "Joy2ButtonToggleButton"
        Me.Joy2ButtonToggleButton.Size = New System.Drawing.Size(75, 23)
        Me.Joy2ButtonToggleButton.TabIndex = 24
        Me.Joy2ButtonToggleButton.Text = "Joy2"
        Me.Joy2ButtonToggleButton.UseVisualStyleBackColor = True
        '
        'Joy3ButtonToggleButton
        '
        Me.Joy3ButtonToggleButton.Location = New System.Drawing.Point(291, 344)
        Me.Joy3ButtonToggleButton.Name = "Joy3ButtonToggleButton"
        Me.Joy3ButtonToggleButton.Size = New System.Drawing.Size(75, 23)
        Me.Joy3ButtonToggleButton.TabIndex = 25
        Me.Joy3ButtonToggleButton.Text = "Joy3"
        Me.Joy3ButtonToggleButton.UseVisualStyleBackColor = True
        '
        'AddressLabel
        '
        Me.AddressLabel.AutoSize = True
        Me.AddressLabel.Location = New System.Drawing.Point(57, 0)
        Me.AddressLabel.Name = "AddressLabel"
        Me.AddressLabel.Size = New System.Drawing.Size(58, 16)
        Me.AddressLabel.TabIndex = 26
        Me.AddressLabel.Text = "Address"
        '
        'URCTxForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.AddressLabel)
        Me.Controls.Add(Me.Joy3ButtonToggleButton)
        Me.Controls.Add(Me.Joy2ButtonToggleButton)
        Me.Controls.Add(Me.Joy1ButtonToggleButton)
        Me.Controls.Add(Me.RightBumperToggleButton)
        Me.Controls.Add(Me.LeftBumperToggleButton)
        Me.Controls.Add(Me.Button4ToggleButton)
        Me.Controls.Add(Me.Button3ToggleButton)
        Me.Controls.Add(Me.Button2ToggleButton)
        Me.Controls.Add(Me.Button1ToggleButton)
        Me.Controls.Add(Me.Joystick3PictureBox)
        Me.Controls.Add(Me.Joystick2PictureBox)
        Me.Controls.Add(Me.Joystick1PictureBox)
        Me.Controls.Add(Me.Joystick3LRLabel)
        Me.Controls.Add(Me.Joystick2LRLabel)
        Me.Controls.Add(Me.Joystick1LRLabel)
        Me.Controls.Add(Me.Joystick3UDLabel)
        Me.Controls.Add(Me.Joystick2UDLabel)
        Me.Controls.Add(Me.Joystick1UDLabel)
        Me.Controls.Add(Me.Joystick3LRTrackBar)
        Me.Controls.Add(Me.Joystick2LRTrackBar)
        Me.Controls.Add(Me.Joystick1LRTrackBar)
        Me.Controls.Add(Me.Joystick3UDTrackBar)
        Me.Controls.Add(Me.Joystick2UDTrackBar)
        Me.Controls.Add(Me.Joystick1UDTrackBar)
        Me.Controls.Add(Me.TxStatusLabel)
        Me.Controls.Add(Me.TxAddressNumericUpDown)
        Me.Name = "URCTxForm"
        Me.Text = "URCTxForm"
        CType(Me.TxAddressNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Joystick1UDTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Joystick2UDTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Joystick3UDTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Joystick1LRTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Joystick2LRTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Joystick3LRTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Joystick1PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Joystick2PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Joystick3PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SerialTXTimer As Timer
    Friend WithEvents TxStartUpTimer As Timer
    Friend WithEvents TxAddressNumericUpDown As NumericUpDown
    Friend WithEvents TxStatusLabel As Label
    Friend WithEvents Joystick1UDTrackBar As TrackBar
    Friend WithEvents Joystick2UDTrackBar As TrackBar
    Friend WithEvents Joystick3UDTrackBar As TrackBar
    Friend WithEvents Joystick1LRTrackBar As TrackBar
    Friend WithEvents Joystick2LRTrackBar As TrackBar
    Friend WithEvents Joystick3LRTrackBar As TrackBar
    Friend WithEvents Joystick1UDLabel As Label
    Friend WithEvents Joystick2UDLabel As Label
    Friend WithEvents Joystick3UDLabel As Label
    Friend WithEvents Joystick1LRLabel As Label
    Friend WithEvents Joystick2LRLabel As Label
    Friend WithEvents Joystick3LRLabel As Label
    Friend WithEvents Joystick1PictureBox As PictureBox
    Friend WithEvents Joystick2PictureBox As PictureBox
    Friend WithEvents Joystick3PictureBox As PictureBox
    Friend WithEvents Button1ToggleButton As Button
    Friend WithEvents Button2ToggleButton As Button
    Friend WithEvents Button3ToggleButton As Button
    Friend WithEvents Button4ToggleButton As Button
    Friend WithEvents LeftBumperToggleButton As Button
    Friend WithEvents RightBumperToggleButton As Button
    Friend WithEvents Joy1ButtonToggleButton As Button
    Friend WithEvents Joy2ButtonToggleButton As Button
    Friend WithEvents Joy3ButtonToggleButton As Button
    Friend WithEvents AddressLabel As Label
End Class
