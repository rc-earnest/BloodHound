<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class IRForm
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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.GimbalButton1 = New System.Windows.Forms.Button()
        Me.GimbalButton2 = New System.Windows.Forms.Button()
        Me.GimbalButton3 = New System.Windows.Forms.Button()
        Me.GimbalButton4 = New System.Windows.Forms.Button()
        Me.HomeButton = New System.Windows.Forms.Button()
        Me.VideoOnButton = New System.Windows.Forms.Button()
        Me.VideoOffButton = New System.Windows.Forms.Button()
        Me.FFCButton = New System.Windows.Forms.Button()
        Me.ResetButton = New System.Windows.Forms.Button()
        Me.offModeRadioButton = New System.Windows.Forms.RadioButton()
        Me.directModeRadioButton = New System.Windows.Forms.RadioButton()
        Me.stabilizeModeRadioButton = New System.Windows.Forms.RadioButton()
        Me.upButton = New System.Windows.Forms.Button()
        Me.leftButton = New System.Windows.Forms.Button()
        Me.rightButton = New System.Windows.Forms.Button()
        Me.downButton = New System.Windows.Forms.Button()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.ZoomInButton = New System.Windows.Forms.Button()
        Me.ZoomOutButton = New System.Windows.Forms.Button()
        Me.pointTwoDegreeRadioButton = New System.Windows.Forms.RadioButton()
        Me.oneDegreeRadioButton = New System.Windows.Forms.RadioButton()
        Me.fiveDegreesRadioButton = New System.Windows.Forms.RadioButton()
        Me.fifteenDegreesRadioButton = New System.Windows.Forms.RadioButton()
        Me.twentyFiveDegreesRadioButton = New System.Windows.Forms.RadioButton()
        Me.fourtyFiveDegreesRadioButton = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.modeSelectGroupBox = New System.Windows.Forms.GroupBox()
        Me.cameraSelectGroupBox = New System.Windows.Forms.GroupBox()
        Me.IRCameraRadioButton = New System.Windows.Forms.RadioButton()
        Me.SonyRadioButton = New System.Windows.Forms.RadioButton()
        Me.modeSelectGroupBox.SuspendLayout()
        Me.cameraSelectGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'GimbalButton1
        '
        Me.GimbalButton1.Location = New System.Drawing.Point(539, 9)
        Me.GimbalButton1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GimbalButton1.Name = "GimbalButton1"
        Me.GimbalButton1.Size = New System.Drawing.Size(100, 28)
        Me.GimbalButton1.TabIndex = 3
        Me.GimbalButton1.Text = "0, -70"
        Me.GimbalButton1.UseVisualStyleBackColor = True
        '
        'GimbalButton2
        '
        Me.GimbalButton2.Location = New System.Drawing.Point(540, 44)
        Me.GimbalButton2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GimbalButton2.Name = "GimbalButton2"
        Me.GimbalButton2.Size = New System.Drawing.Size(100, 28)
        Me.GimbalButton2.TabIndex = 4
        Me.GimbalButton2.Text = "180, -70"
        Me.GimbalButton2.UseVisualStyleBackColor = True
        '
        'GimbalButton3
        '
        Me.GimbalButton3.Location = New System.Drawing.Point(540, 80)
        Me.GimbalButton3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GimbalButton3.Name = "GimbalButton3"
        Me.GimbalButton3.Size = New System.Drawing.Size(100, 28)
        Me.GimbalButton3.TabIndex = 5
        Me.GimbalButton3.Text = "90, -25"
        Me.GimbalButton3.UseVisualStyleBackColor = True
        '
        'GimbalButton4
        '
        Me.GimbalButton4.Location = New System.Drawing.Point(540, 116)
        Me.GimbalButton4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GimbalButton4.Name = "GimbalButton4"
        Me.GimbalButton4.Size = New System.Drawing.Size(100, 28)
        Me.GimbalButton4.TabIndex = 6
        Me.GimbalButton4.Text = "270, -25"
        Me.GimbalButton4.UseVisualStyleBackColor = True
        '
        'HomeButton
        '
        Me.HomeButton.Location = New System.Drawing.Point(539, 151)
        Me.HomeButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.HomeButton.Name = "HomeButton"
        Me.HomeButton.Size = New System.Drawing.Size(100, 28)
        Me.HomeButton.TabIndex = 7
        Me.HomeButton.Text = "Home"
        Me.HomeButton.UseVisualStyleBackColor = True
        '
        'VideoOnButton
        '
        Me.VideoOnButton.Location = New System.Drawing.Point(648, 9)
        Me.VideoOnButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.VideoOnButton.Name = "VideoOnButton"
        Me.VideoOnButton.Size = New System.Drawing.Size(100, 28)
        Me.VideoOnButton.TabIndex = 8
        Me.VideoOnButton.Text = "Video On"
        Me.VideoOnButton.UseVisualStyleBackColor = True
        '
        'VideoOffButton
        '
        Me.VideoOffButton.Location = New System.Drawing.Point(648, 44)
        Me.VideoOffButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.VideoOffButton.Name = "VideoOffButton"
        Me.VideoOffButton.Size = New System.Drawing.Size(100, 28)
        Me.VideoOffButton.TabIndex = 9
        Me.VideoOffButton.Text = "Video Off"
        Me.VideoOffButton.UseVisualStyleBackColor = True
        '
        'FFCButton
        '
        Me.FFCButton.Location = New System.Drawing.Point(648, 80)
        Me.FFCButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.FFCButton.Name = "FFCButton"
        Me.FFCButton.Size = New System.Drawing.Size(100, 28)
        Me.FFCButton.TabIndex = 10
        Me.FFCButton.Text = "FFC/Adjust"
        Me.FFCButton.UseVisualStyleBackColor = True
        '
        'ResetButton
        '
        Me.ResetButton.Location = New System.Drawing.Point(648, 116)
        Me.ResetButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(100, 28)
        Me.ResetButton.TabIndex = 11
        Me.ResetButton.Text = "Reset Turret"
        Me.ResetButton.UseVisualStyleBackColor = True
        '
        'offModeRadioButton
        '
        Me.offModeRadioButton.AutoSize = True
        Me.offModeRadioButton.Location = New System.Drawing.Point(22, 22)
        Me.offModeRadioButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.offModeRadioButton.Name = "offModeRadioButton"
        Me.offModeRadioButton.Size = New System.Drawing.Size(44, 20)
        Me.offModeRadioButton.TabIndex = 12
        Me.offModeRadioButton.TabStop = True
        Me.offModeRadioButton.Text = "Off"
        Me.offModeRadioButton.UseVisualStyleBackColor = True
        '
        'directModeRadioButton
        '
        Me.directModeRadioButton.AutoSize = True
        Me.directModeRadioButton.Location = New System.Drawing.Point(22, 51)
        Me.directModeRadioButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.directModeRadioButton.Name = "directModeRadioButton"
        Me.directModeRadioButton.Size = New System.Drawing.Size(63, 20)
        Me.directModeRadioButton.TabIndex = 13
        Me.directModeRadioButton.TabStop = True
        Me.directModeRadioButton.Text = "Direct"
        Me.directModeRadioButton.UseVisualStyleBackColor = True
        '
        'stabilizeModeRadioButton
        '
        Me.stabilizeModeRadioButton.AutoSize = True
        Me.stabilizeModeRadioButton.Location = New System.Drawing.Point(22, 79)
        Me.stabilizeModeRadioButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.stabilizeModeRadioButton.Name = "stabilizeModeRadioButton"
        Me.stabilizeModeRadioButton.Size = New System.Drawing.Size(79, 20)
        Me.stabilizeModeRadioButton.TabIndex = 14
        Me.stabilizeModeRadioButton.TabStop = True
        Me.stabilizeModeRadioButton.Text = "Stabilize"
        Me.stabilizeModeRadioButton.UseVisualStyleBackColor = True
        '
        'upButton
        '
        Me.upButton.Location = New System.Drawing.Point(205, 15)
        Me.upButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.upButton.Name = "upButton"
        Me.upButton.Size = New System.Drawing.Size(100, 28)
        Me.upButton.TabIndex = 15
        Me.upButton.Text = "Up"
        Me.upButton.UseVisualStyleBackColor = True
        '
        'leftButton
        '
        Me.leftButton.Location = New System.Drawing.Point(124, 50)
        Me.leftButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.leftButton.Name = "leftButton"
        Me.leftButton.Size = New System.Drawing.Size(100, 28)
        Me.leftButton.TabIndex = 16
        Me.leftButton.Text = "Left"
        Me.leftButton.UseVisualStyleBackColor = True
        '
        'rightButton
        '
        Me.rightButton.Location = New System.Drawing.Point(292, 50)
        Me.rightButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rightButton.Name = "rightButton"
        Me.rightButton.Size = New System.Drawing.Size(100, 28)
        Me.rightButton.TabIndex = 17
        Me.rightButton.Text = "Right"
        Me.rightButton.UseVisualStyleBackColor = True
        '
        'downButton
        '
        Me.downButton.Location = New System.Drawing.Point(205, 85)
        Me.downButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.downButton.Name = "downButton"
        Me.downButton.Size = New System.Drawing.Size(100, 28)
        Me.downButton.TabIndex = 18
        Me.downButton.Text = "Down"
        Me.downButton.UseVisualStyleBackColor = True
        '
        'ExitButton
        '
        Me.ExitButton.Location = New System.Drawing.Point(647, 151)
        Me.ExitButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(100, 28)
        Me.ExitButton.TabIndex = 19
        Me.ExitButton.Text = "Exit"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'ZoomInButton
        '
        Me.ZoomInButton.Location = New System.Drawing.Point(16, 206)
        Me.ZoomInButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ZoomInButton.Name = "ZoomInButton"
        Me.ZoomInButton.Size = New System.Drawing.Size(100, 28)
        Me.ZoomInButton.TabIndex = 20
        Me.ZoomInButton.Text = "Zoom In"
        Me.ZoomInButton.UseVisualStyleBackColor = True
        '
        'ZoomOutButton
        '
        Me.ZoomOutButton.Location = New System.Drawing.Point(16, 316)
        Me.ZoomOutButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ZoomOutButton.Name = "ZoomOutButton"
        Me.ZoomOutButton.Size = New System.Drawing.Size(100, 28)
        Me.ZoomOutButton.TabIndex = 23
        Me.ZoomOutButton.Text = "Zoom out"
        Me.ZoomOutButton.UseVisualStyleBackColor = True
        '
        'pointTwoDegreeRadioButton
        '
        Me.pointTwoDegreeRadioButton.AutoSize = True
        Me.pointTwoDegreeRadioButton.Location = New System.Drawing.Point(427, 14)
        Me.pointTwoDegreeRadioButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pointTwoDegreeRadioButton.Name = "pointTwoDegreeRadioButton"
        Me.pointTwoDegreeRadioButton.Size = New System.Drawing.Size(92, 20)
        Me.pointTwoDegreeRadioButton.TabIndex = 23
        Me.pointTwoDegreeRadioButton.TabStop = True
        Me.pointTwoDegreeRadioButton.Text = ".2 degrees"
        Me.pointTwoDegreeRadioButton.UseVisualStyleBackColor = True
        '
        'oneDegreeRadioButton
        '
        Me.oneDegreeRadioButton.AutoSize = True
        Me.oneDegreeRadioButton.Location = New System.Drawing.Point(427, 42)
        Me.oneDegreeRadioButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.oneDegreeRadioButton.Name = "oneDegreeRadioButton"
        Me.oneDegreeRadioButton.Size = New System.Drawing.Size(82, 20)
        Me.oneDegreeRadioButton.TabIndex = 24
        Me.oneDegreeRadioButton.TabStop = True
        Me.oneDegreeRadioButton.Text = "1 degree"
        Me.oneDegreeRadioButton.UseVisualStyleBackColor = True
        '
        'fiveDegreesRadioButton
        '
        Me.fiveDegreesRadioButton.AutoSize = True
        Me.fiveDegreesRadioButton.Location = New System.Drawing.Point(427, 70)
        Me.fiveDegreesRadioButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fiveDegreesRadioButton.Name = "fiveDegreesRadioButton"
        Me.fiveDegreesRadioButton.Size = New System.Drawing.Size(89, 20)
        Me.fiveDegreesRadioButton.TabIndex = 25
        Me.fiveDegreesRadioButton.TabStop = True
        Me.fiveDegreesRadioButton.Text = "5 degrees"
        Me.fiveDegreesRadioButton.UseVisualStyleBackColor = True
        '
        'fifteenDegreesRadioButton
        '
        Me.fifteenDegreesRadioButton.AutoSize = True
        Me.fifteenDegreesRadioButton.Location = New System.Drawing.Point(427, 98)
        Me.fifteenDegreesRadioButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fifteenDegreesRadioButton.Name = "fifteenDegreesRadioButton"
        Me.fifteenDegreesRadioButton.Size = New System.Drawing.Size(96, 20)
        Me.fifteenDegreesRadioButton.TabIndex = 26
        Me.fifteenDegreesRadioButton.TabStop = True
        Me.fifteenDegreesRadioButton.Text = "15 degrees"
        Me.fifteenDegreesRadioButton.UseVisualStyleBackColor = True
        '
        'twentyFiveDegreesRadioButton
        '
        Me.twentyFiveDegreesRadioButton.AutoSize = True
        Me.twentyFiveDegreesRadioButton.Location = New System.Drawing.Point(427, 127)
        Me.twentyFiveDegreesRadioButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.twentyFiveDegreesRadioButton.Name = "twentyFiveDegreesRadioButton"
        Me.twentyFiveDegreesRadioButton.Size = New System.Drawing.Size(96, 20)
        Me.twentyFiveDegreesRadioButton.TabIndex = 27
        Me.twentyFiveDegreesRadioButton.TabStop = True
        Me.twentyFiveDegreesRadioButton.Text = "25 degrees"
        Me.twentyFiveDegreesRadioButton.UseVisualStyleBackColor = True
        '
        'fourtyFiveDegreesRadioButton
        '
        Me.fourtyFiveDegreesRadioButton.AutoSize = True
        Me.fourtyFiveDegreesRadioButton.Location = New System.Drawing.Point(427, 155)
        Me.fourtyFiveDegreesRadioButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fourtyFiveDegreesRadioButton.Name = "fourtyFiveDegreesRadioButton"
        Me.fourtyFiveDegreesRadioButton.Size = New System.Drawing.Size(96, 20)
        Me.fourtyFiveDegreesRadioButton.TabIndex = 28
        Me.fourtyFiveDegreesRadioButton.TabStop = True
        Me.fourtyFiveDegreesRadioButton.Text = "45 degrees"
        Me.fourtyFiveDegreesRadioButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(427, 372)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Label1"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(409, 293)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(132, 22)
        Me.TextBox1.TabIndex = 30
        '
        'modeSelectGroupBox
        '
        Me.modeSelectGroupBox.Controls.Add(Me.offModeRadioButton)
        Me.modeSelectGroupBox.Controls.Add(Me.directModeRadioButton)
        Me.modeSelectGroupBox.Controls.Add(Me.stabilizeModeRadioButton)
        Me.modeSelectGroupBox.Location = New System.Drawing.Point(12, 18)
        Me.modeSelectGroupBox.Name = "modeSelectGroupBox"
        Me.modeSelectGroupBox.Size = New System.Drawing.Size(122, 100)
        Me.modeSelectGroupBox.TabIndex = 31
        Me.modeSelectGroupBox.TabStop = False
        Me.modeSelectGroupBox.Text = "Mode Select"
        '
        'cameraSelectGroupBox
        '
        Me.cameraSelectGroupBox.Controls.Add(Me.SonyRadioButton)
        Me.cameraSelectGroupBox.Controls.Add(Me.IRCameraRadioButton)
        Me.cameraSelectGroupBox.Location = New System.Drawing.Point(554, 265)
        Me.cameraSelectGroupBox.Name = "cameraSelectGroupBox"
        Me.cameraSelectGroupBox.Size = New System.Drawing.Size(200, 100)
        Me.cameraSelectGroupBox.TabIndex = 32
        Me.cameraSelectGroupBox.TabStop = False
        Me.cameraSelectGroupBox.Text = "Camera Select"
        '
        'IRCameraRadioButton
        '
        Me.IRCameraRadioButton.AutoSize = True
        Me.IRCameraRadioButton.Location = New System.Drawing.Point(6, 30)
        Me.IRCameraRadioButton.Name = "IRCameraRadioButton"
        Me.IRCameraRadioButton.Size = New System.Drawing.Size(92, 20)
        Me.IRCameraRadioButton.TabIndex = 0
        Me.IRCameraRadioButton.TabStop = True
        Me.IRCameraRadioButton.Text = "IR Camera"
        Me.IRCameraRadioButton.UseVisualStyleBackColor = True
        '
        'SonyRadioButton
        '
        Me.SonyRadioButton.AutoSize = True
        Me.SonyRadioButton.Location = New System.Drawing.Point(6, 74)
        Me.SonyRadioButton.Name = "SonyRadioButton"
        Me.SonyRadioButton.Size = New System.Drawing.Size(59, 20)
        Me.SonyRadioButton.TabIndex = 1
        Me.SonyRadioButton.TabStop = True
        Me.SonyRadioButton.Text = "Sony"
        Me.SonyRadioButton.UseVisualStyleBackColor = True
        '
        'IRForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1108, 580)
        Me.Controls.Add(Me.cameraSelectGroupBox)
        Me.Controls.Add(Me.modeSelectGroupBox)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ZoomOutButton)
        Me.Controls.Add(Me.ZoomInButton)
        Me.Controls.Add(Me.fourtyFiveDegreesRadioButton)
        Me.Controls.Add(Me.twentyFiveDegreesRadioButton)
        Me.Controls.Add(Me.fifteenDegreesRadioButton)
        Me.Controls.Add(Me.fiveDegreesRadioButton)
        Me.Controls.Add(Me.oneDegreeRadioButton)
        Me.Controls.Add(Me.pointTwoDegreeRadioButton)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.downButton)
        Me.Controls.Add(Me.rightButton)
        Me.Controls.Add(Me.leftButton)
        Me.Controls.Add(Me.upButton)
        Me.Controls.Add(Me.ResetButton)
        Me.Controls.Add(Me.FFCButton)
        Me.Controls.Add(Me.VideoOffButton)
        Me.Controls.Add(Me.VideoOnButton)
        Me.Controls.Add(Me.HomeButton)
        Me.Controls.Add(Me.GimbalButton4)
        Me.Controls.Add(Me.GimbalButton3)
        Me.Controls.Add(Me.GimbalButton2)
        Me.Controls.Add(Me.GimbalButton1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "IRForm"
        Me.Text = "IR Control Form"
        Me.modeSelectGroupBox.ResumeLayout(False)
        Me.modeSelectGroupBox.PerformLayout()
        Me.cameraSelectGroupBox.ResumeLayout(False)
        Me.cameraSelectGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents GimbalButton1 As Button
    Friend WithEvents GimbalButton2 As Button
    Friend WithEvents GimbalButton3 As Button
    Friend WithEvents GimbalButton4 As Button
    Friend WithEvents HomeButton As Button
    Friend WithEvents VideoOnButton As Button
    Friend WithEvents VideoOffButton As Button
    Friend WithEvents FFCButton As Button
    Friend WithEvents ResetButton As Button
    Friend WithEvents offModeRadioButton As RadioButton
    Friend WithEvents directModeRadioButton As RadioButton
    Friend WithEvents stabilizeModeRadioButton As RadioButton
    Friend WithEvents upButton As Button
    Friend WithEvents leftButton As Button
    Friend WithEvents rightButton As Button
    Friend WithEvents downButton As Button
    Friend WithEvents ExitButton As Button
    Friend WithEvents ZoomInButton As Button

    Friend WithEvents ZoomOutButton As Button

    Friend WithEvents pointTwoDegreeRadioButton As RadioButton
    Friend WithEvents oneDegreeRadioButton As RadioButton
    Friend WithEvents fiveDegreesRadioButton As RadioButton
    Friend WithEvents fifteenDegreesRadioButton As RadioButton
    Friend WithEvents twentyFiveDegreesRadioButton As RadioButton
    Friend WithEvents fourtyFiveDegreesRadioButton As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents modeSelectGroupBox As GroupBox
    Friend WithEvents cameraSelectGroupBox As GroupBox
    Friend WithEvents SonyRadioButton As RadioButton
    Friend WithEvents IRCameraRadioButton As RadioButton
End Class
