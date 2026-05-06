'Zachary Christensen
'RCET Lab Project
'12/2/24
'Universal Remote Control Test Software - RX Form (with TX mode launch)
'GitHub: https://github.com/Minidude140/Universal-Remote-Control-Test-Software

Option Explicit On
Option Strict On
Imports System.Threading
Public Class URCTestForm
    '*********************************************Global Variables******************************************
    Dim robotAddress As Integer
    Dim currentCommand As Integer
    Dim joystick1UD As Integer
    Dim joystick1LR As Integer
    Dim joystick2UD As Integer
    Dim joystick2LR As Integer
    Dim joystick3UD As Integer
    Dim Joystick3LR As Integer
    Dim buttonByte1 As Byte
    Dim buttonByte2 As Byte
    Dim buttonOnColor As Color
    Dim buttonOffColor As Color
    Dim joy1PosColor As Brush
    Dim joy2PosColor As Brush
    Dim joy3PosColor As Brush
    Public GrowlGreyLight As Color = Color.FromArgb(230, 231, 232)
    Public GrowlGreyMed As Color = Color.FromArgb(167, 167, 167)
    Public GrowlGrey As Color = Color.FromArgb(130, 130, 130)
    Public Roarange As Color = Color.FromArgb(244, 121, 32)

    '**********************************************Custom Methods*******************************************

    Sub PopulateCOMSelect()
        For Each portName In COMSerialPort.GetPortNames
            COMSelectToolStripComboBox.Items.Add(portName)
        Next
        COMSelectToolStripComboBox.SelectedIndex = 0
    End Sub

    Sub OpenCOM()
        COMSerialPort.PortName = CStr(COMSelectToolStripComboBox.SelectedItem)
        COMSerialPort.BaudRate = 115200
        Try
            COMSerialPort.Open()
            SerialCOMTimer.Enabled = True
            ConnectCOMToolStripButton.Enabled = False
            DisconnetToolStripButton.Enabled = True
            COMStatusStripLabel.Text = "Connected to: " & COMSerialPort.PortName
        Catch ex As Exception
            MsgBox("Sorry, the selected COM port could not be connected.")
        End Try
    End Sub

    Sub CloseCOM()
        SerialCOMTimer.Enabled = False
        COMSerialPort.Close()
        ConnectCOMToolStripButton.Enabled = True
        DisconnetToolStripButton.Enabled = False
        COMStatusStripLabel.Text = "Not Connected"
    End Sub

    Sub UpdateDisplay()
        RobotAddressDecLabel.Text = CStr(robotAddress)
        RobotAddressHexLabel.Text = CStr(Hex(robotAddress))
        Joystick1UDLabel.Text = CStr(joystick1UD)
        Joystick1LRLabel.Text = CStr(joystick1LR)
        Joystick1UDTrackBar.Value = joystick1UD
        Joystick1LRTrackBar.Value = joystick1LR
        Joystick2UDLabel.Text = CStr(joystick2UD)
        Joystick2LRLabel.Text = CStr(joystick2LR)
        Joystick2UDTrackBar.Value = joystick2UD
        Joystick2LRTrackBar.Value = joystick2LR
        Joystick3UDLabel.Text = CStr(joystick3UD)
        Joystick3LRLabel.Text = CStr(Joystick3LR)
        Joystick3UDTrackBar.Value = joystick3UD
        Joystick3LRTrackBar.Value = Joystick3LR
        TestButtons()
        DrawJoystick1(joystick1LR, joystick1UD)
        DrawJoystick2(joystick2LR, joystick2UD)
        DrawJoystick3(Joystick3LR, joystick3UD)
    End Sub

    Function TestBit(data As Byte, index As Integer) As Boolean
        Dim testArray As New BitArray({data})
        Return testArray(index)
    End Function

    Sub TestButtons()
        Button1Indicator.BackColor = If(TestBit(buttonByte1, 0), buttonOnColor, buttonOffColor)
        Button2Indicator.BackColor = If(TestBit(buttonByte1, 1), buttonOnColor, buttonOffColor)
        Button3Indicator.BackColor = If(TestBit(buttonByte1, 2), buttonOnColor, buttonOffColor)
        Button4Indicator.BackColor = If(TestBit(buttonByte1, 3), buttonOnColor, buttonOffColor)
        LeftBumperIndicatorButton.BackColor = If(TestBit(buttonByte1, 4), buttonOnColor, buttonOffColor)
        RightBumperIndicatorButton.BackColor = If(TestBit(buttonByte1, 5), buttonOnColor, buttonOffColor)
        Joystick1IndicatorButton.BackColor = If(TestBit(buttonByte1, 6), buttonOnColor, buttonOffColor)
        Joystick2IndicatorButton.BackColor = If(TestBit(buttonByte1, 7), buttonOnColor, buttonOffColor)
        Joystick3IndicatorButton.BackColor = If(TestBit(buttonByte2, 0), buttonOnColor, buttonOffColor)
    End Sub

    Sub DrawJoystick1(x As Integer, y As Integer)
        Joystick1PictureBox.Refresh()
        Dim g As Graphics = Joystick1PictureBox.CreateGraphics
        Dim pen As New Pen(Color.Black, 4)
        g.DrawRectangle(pen, 0, 0, Joystick1PictureBox.Width, Joystick1PictureBox.Height)
        Dim sX As Single = CSng(Joystick1PictureBox.Width / 255)
        Dim sY As Single = CSng(Joystick1PictureBox.Height / 255)
        g.ScaleTransform(sX, sY)
        g.FillEllipse(joy1PosColor, ((255 - x) - 20), ((255 - y) - 20), 40, 40)
    End Sub

    Sub DrawJoystick2(x As Integer, y As Integer)
        Joystick2PictureBox.Refresh()
        Dim g As Graphics = Joystick2PictureBox.CreateGraphics
        Dim pen As New Pen(Color.Black, 4)
        g.DrawRectangle(pen, 0, 0, Joystick2PictureBox.Width, Joystick2PictureBox.Height)
        Dim sX As Single = CSng(Joystick2PictureBox.Width / 255)
        Dim sY As Single = CSng(Joystick2PictureBox.Height / 255)
        g.ScaleTransform(sX, sY)
        g.FillEllipse(joy2PosColor, ((255 - x) - 20), ((255 - y) - 20), 40, 40)
    End Sub

    Sub DrawJoystick3(x As Integer, y As Integer)
        Joystick3PictureBox.Refresh()
        Dim g As Graphics = Joystick3PictureBox.CreateGraphics
        Dim pen As New Pen(Color.Black, 4)
        g.DrawRectangle(pen, 0, 0, Joystick3PictureBox.Width, Joystick3PictureBox.Height)
        Dim sX As Single = CSng(Joystick3PictureBox.Width / 255)
        Dim sY As Single = CSng(Joystick3PictureBox.Height / 255)
        g.ScaleTransform(sX, sY)
        g.FillEllipse(joy3PosColor, ((255 - x) - 20), ((255 - y) - 20), 40, 40)
    End Sub

    '**********************************************Event Handlers*******************************************

    Private Sub URCTestForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        PopulateCOMSelect()
        DisconnetToolStripButton.Enabled = False
        MenuStrip.BackColor = GrowlGrey
        buttonOnColor = Roarange
        buttonOffColor = Color.Gray
        Dim tempBrush As New SolidBrush(Roarange)
        joy1PosColor = tempBrush
        joy2PosColor = tempBrush
        joy3PosColor = tempBrush
        Joystick1LRTrackBar.Value = 128
        Joystick1UDTrackBar.Value = 128
        Joystick2LRTrackBar.Value = 128
        Joystick2UDTrackBar.Value = 128
        Joystick3LRTrackBar.Value = 128
        Joystick3UDTrackBar.Value = 128
        ' Default to RX mode selected
        RxModeRadioButton.Checked = True
        StartUpTimer.Enabled = True
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    '-- Mode Radio Buttons --

    ''' <summary>
    ''' RX mode selected: make sure the TX form is closed and RX timer is running
    ''' </summary>
    Public Sub RxModeRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles RxModeRadioButton.CheckedChanged
        If RxModeRadioButton.Checked Then
            ' Close TX form if it is open
            If Not URCTxForm.IsDisposed AndAlso URCTxForm.Visible Then
                URCTxForm.SerialTXTimer.Enabled = False
                URCTxForm.Hide()
            End If
            ' Re-enable RX timer if COM is open
            If COMSerialPort.IsOpen Then
                SerialCOMTimer.Enabled = True
                COMStatusStripLabel.Text = "Connected to: " & COMSerialPort.PortName & " [RX]"
            End If
        End If
    End Sub

    ''' <summary>
    ''' TX mode selected: pause RX timer and open the TX form.
    ''' The COM port stays open and is shared — URCTxForm writes to it directly.
    ''' </summary>
    Private Sub TxModeRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles TxModeRadioButton.CheckedChanged
        If TxModeRadioButton.Checked Then
            ' Pause RX timer so we don't fight over the buffer
            SerialCOMTimer.Enabled = False
            If COMSerialPort.IsOpen Then
                COMStatusStripLabel.Text = "Connected to: " & COMSerialPort.PortName & " [TX]"
            End If
            ' Show (or re-show) the TX form
            URCTxForm.Show()
            URCTxForm.BringToFront()
        End If
    End Sub

    Private Sub ConnectCOMToolStripButton_Click(sender As Object, e As EventArgs) Handles ConnectCOMToolStripButton.Click,
                                                                                          ConnectMenuItem.Click
        OpenCOM()
    End Sub

    Private Sub DisconnetToolStripButton_Click(sender As Object, e As EventArgs) Handles DisconnetToolStripButton.Click,
                                                                                         DisconnectMenuItem.Click
        CloseCOM()
    End Sub

    Private Sub SerialCOMTimer_Tick(sender As Object, e As EventArgs) Handles SerialCOMTimer.Tick
        Try
            Dim data(COMSerialPort.BytesToRead) As Byte
            COMSerialPort.Read(data, 0, COMSerialPort.BytesToRead)
            If data(0) = &H24 Then
                robotAddress = data(1)
                Select Case data(2)
                    Case 74    ' 0x4A 'J'
                        joystick1UD = data(3)
                        joystick1LR = data(4)
                        joystick2UD = data(5)
                    Case 106   ' 0x6A 'j'
                        joystick2LR = data(3)
                        joystick3UD = data(4)
                        Joystick3LR = data(5)
                    Case 66    ' 0x42 'B'
                        buttonByte1 = data(3)
                        buttonByte2 = data(4)
                    Case Else
                End Select
            Else
                COMSerialPort.DiscardInBuffer()
            End If
        Catch ex As Exception
            COMSerialPort.DiscardInBuffer()
            MsgBox("A connection error has occurred.")
        End Try
        COMSerialPort.DiscardInBuffer()
        UpdateDisplay()
    End Sub

    Private Sub StartUpTimer_Tick(sender As Object, e As EventArgs) Handles StartUpTimer.Tick
        StartUpTimer.Enabled = False
        DrawJoystick1(128, 128)
        DrawJoystick2(128, 128)
        DrawJoystick3(128, 128)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        URCAboutForm.Show()
    End Sub

    '************************Joystick GUI Controls*************************************
    ' Joystick 1
    Private Sub ToggleLeftRightDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Joy1ToggleLeftRightDataMenuItem.Click
        Joystick1LRLabel.Visible = Not Joystick1LRLabel.Visible
    End Sub
    Private Sub ToggleLeftRightTrackBarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Joy1ToggleLeftRightTrackBarMenuItem.Click
        Joystick1LRTrackBar.Visible = Not Joystick1LRTrackBar.Visible
    End Sub
    Private Sub ToggleUpDownDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Joy1ToggleUpDownDataMenuItem.Click
        Joystick1UDLabel.Visible = Not Joystick1UDLabel.Visible
    End Sub
    Private Sub ToggleUpDownTrackBarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Joy1ToggleUpDownTrackBarMenuItem.Click
        Joystick1UDTrackBar.Visible = Not Joystick1UDTrackBar.Visible
    End Sub
    Private Sub TogglePositionGraphToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Joy1TogglePositionGraphMenuItem.Click
        If Joystick1PictureBox.Visible Then
            Joystick1PictureBox.Visible = False
        Else
            Joystick1PictureBox.Visible = True
            DrawJoystick1(128, 128)
        End If
    End Sub
    Private Sub Joy1ChangPositionDotColorMenuItem_Click(sender As Object, e As EventArgs) Handles Joy1ChangPositionDotColorMenuItem.Click
        ColorDialog.ShowDialog()
        joy1PosColor = New SolidBrush(ColorDialog.Color)
        DrawJoystick1(128, 128)
    End Sub
    Private Sub Joy1SetDefaultJoystickDisplayMenuItem_Click(sender As Object, e As EventArgs) Handles Joy1SetDefaultJoystickDisplayMenuItem.Click
        joy1PosColor = New SolidBrush(Roarange)
        Joystick1LRLabel.Visible = True : Joystick1LRTrackBar.Visible = True
        Joystick1UDLabel.Visible = True : Joystick1UDTrackBar.Visible = True
        Joystick1PictureBox.Visible = True
        DrawJoystick1(128, 128)
    End Sub
    ' Joystick 2
    Private Sub Joy2ToggleLeftRightDataMenuItem_Click(sender As Object, e As EventArgs) Handles Joy2ToggleLeftRightDataMenuItem.Click
        Joystick2LRLabel.Visible = Not Joystick2LRLabel.Visible
    End Sub
    Private Sub Joy2ToggleLeftRightTrackBarMenuItem_Click(sender As Object, e As EventArgs) Handles Joy2ToggleLeftRightTrackBarMenuItem.Click
        Joystick2LRTrackBar.Visible = Not Joystick2LRTrackBar.Visible
    End Sub
    Private Sub Joy2ToggleUpDownDataMenuItem_Click(sender As Object, e As EventArgs) Handles Joy2ToggleUpDownDataMenuItem.Click
        Joystick2UDLabel.Visible = Not Joystick2UDLabel.Visible
    End Sub
    Private Sub Joy2ToggleUpDownTrackBarMenuItem_Click(sender As Object, e As EventArgs) Handles Joy2ToggleUpDownTrackBarMenuItem.Click
        Joystick2UDTrackBar.Visible = Not Joystick2UDTrackBar.Visible
    End Sub
    Private Sub Joy2TogglePositionGraphMenuItem_Click(sender As Object, e As EventArgs) Handles Joy2TogglePositionGraphMenuItem.Click
        If Joystick2PictureBox.Visible Then
            Joystick2PictureBox.Visible = False
        Else
            Joystick2PictureBox.Visible = True
            DrawJoystick2(128, 128)
        End If
    End Sub
    Private Sub Joy2ChangePositionDotColorMenuItem_Click(sender As Object, e As EventArgs) Handles Joy2ChangePositionDotColorMenuItem.Click
        ColorDialog.ShowDialog()
        joy2PosColor = New SolidBrush(ColorDialog.Color)
        DrawJoystick2(128, 128)
    End Sub
    Private Sub Joy2SetDefaultJoystickDisplayMenuItem_Click(sender As Object, e As EventArgs) Handles Joy2SetDefaultJoystickDisplayMenuItem.Click
        joy2PosColor = New SolidBrush(Roarange)
        Joystick2LRLabel.Visible = True : Joystick2LRTrackBar.Visible = True
        Joystick2UDLabel.Visible = True : Joystick2UDTrackBar.Visible = True
        Joystick2PictureBox.Visible = True
        DrawJoystick2(128, 128)
    End Sub
    ' Joystick 3
    Private Sub Joy3ToggleLeftRightDataMenuItem_Click(sender As Object, e As EventArgs) Handles Joy3ToggleLeftRightDataMenuItem.Click
        Joystick3LRLabel.Visible = Not Joystick3LRLabel.Visible
    End Sub
    Private Sub Joy3ToggleLeftRightTrackBarMenuItem_Click(sender As Object, e As EventArgs) Handles Joy3ToggleLeftRightTrackBarMenuItem.Click
        Joystick3LRTrackBar.Visible = Not Joystick3LRTrackBar.Visible
    End Sub
    Private Sub Joy3ToggleUpDownDataMenuItem_Click(sender As Object, e As EventArgs) Handles Joy3ToggleUpDownDataMenuItem.Click
        Joystick3UDLabel.Visible = Not Joystick3UDLabel.Visible
    End Sub
    Private Sub Joy3ToggleUpDownTrackBarMenuItem_Click(sender As Object, e As EventArgs) Handles Joy3ToggleUpDownTrackBarMenuItem.Click
        Joystick3UDTrackBar.Visible = Not Joystick3UDTrackBar.Visible
    End Sub
    Private Sub Joy3TogglePositionGraphMenuItem_Click(sender As Object, e As EventArgs) Handles Joy3TogglePositionGraphMenuItem.Click
        If Joystick3PictureBox.Visible Then
            Joystick3PictureBox.Visible = False
        Else
            Joystick3PictureBox.Visible = True
            DrawJoystick3(128, 128)
        End If
    End Sub
    Private Sub Joy3ChangePositionDotColorMenuItem_Click(sender As Object, e As EventArgs) Handles Joy3ChangePositionDotColorMenuItem.Click
        ColorDialog.ShowDialog()
        joy3PosColor = New SolidBrush(ColorDialog.Color)
        DrawJoystick3(128, 128)
    End Sub
    Private Sub Joy3SetDefaultJoystickDisplayMenuItem_Click(sender As Object, e As EventArgs) Handles Joy3SetDefaultJoystickDisplayMenuItem.Click
        joy3PosColor = New SolidBrush(Roarange)
        Joystick3LRLabel.Visible = True : Joystick3LRTrackBar.Visible = True
        Joystick3UDLabel.Visible = True : Joystick3UDTrackBar.Visible = True
        Joystick3PictureBox.Visible = True
        DrawJoystick3(128, 128)
    End Sub

    '************************Change Button Colors*************************************
    Private Sub ChangeButtonOffColorMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeButtonOffColorMenuItem.Click
        ColorDialog.ShowDialog()
        buttonOffColor = ColorDialog.Color
        TestButtons()
    End Sub
    Private Sub ChangeButtonOnColorMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeButtonOnColorMenuItem.Click
        ColorDialog.ShowDialog()
        buttonOnColor = ColorDialog.Color
        TestButtons()
    End Sub
    Private Sub SetDefaultButtonColorsMenuItem_Click(sender As Object, e As EventArgs) Handles SetDefaultButtonColorsMenuItem.Click
        buttonOnColor = Roarange
        buttonOffColor = Color.Gray
        TestButtons()
    End Sub

    '************************Change Background Image**********************************
    Private Sub PCBBackgroundMenuItem_Click(sender As Object, e As EventArgs) Handles PCBBackgroundMenuItem.Click
        PCBBackgroundPictureBox.Visible = True
        CaseBackgroundPictureBox.Visible = False
        ISULogoPictureBox.Visible = False
        URCLabel.Visible = False
    End Sub
    Private Sub NoneBackroundMenuItem_Click(sender As Object, e As EventArgs) Handles NoneBackroundMenuItem.Click
        PCBBackgroundPictureBox.Visible = False
        CaseBackgroundPictureBox.Visible = False
        ISULogoPictureBox.Visible = True
        URCLabel.Visible = True
    End Sub
    Private Sub CaseBackgroundMenuItem_Click(sender As Object, e As EventArgs) Handles CaseBackgroundMenuItem.Click
        CaseBackgroundPictureBox.Visible = True
        PCBBackgroundPictureBox.Visible = False
        ISULogoPictureBox.Visible = False
        URCLabel.Visible = False
    End Sub

    Private Sub ClockTimer_Tick(sender As Object, e As EventArgs) Handles ClockTimer.Tick
        ClockStatusStripLabel.Text = FormatDateTime(TimeOfDay)
    End Sub

    Private Sub RefreshToolStripButton_Click(sender As Object, e As EventArgs) Handles RefreshToolStripButton.Click
        PopulateCOMSelect()
    End Sub
End Class