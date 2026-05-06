'Rudy Earnest
'RCET Lab Project
'Universal Remote Control - TX Form
'Opened when TX mode is selected from the main RX form
'testing github
'test

Option Explicit On
Option Strict On

Public Class URCTxForm

    '*********************************************Global Variables******************************************
    Dim txAddress As Byte = 1
    Dim txCommandIndex As Integer = 0   ' 0=0x42, 1=0x4A, 2=0x6A

    ' Button toggle states (replaces CheckBox controls — use plain Buttons that toggle)
    Dim btn1State As Boolean = False
    Dim btn2State As Boolean = False
    Dim btn3State As Boolean = False
    Dim btn4State As Boolean = False
    Dim leftBumperState As Boolean = False
    Dim rightBumperState As Boolean = False
    Dim joy1BtnState As Boolean = False
    Dim joy2BtnState As Boolean = False
    Dim joy3BtnState As Boolean = False

    Public GrowlGrey As Color = Color.FromArgb(130, 130, 130)
    Public Roarange As Color = Color.FromArgb(244, 121, 32)
    Dim buttonOnColor As Color
    Dim buttonOffColor As Color
    Dim joy1PosColor As Brush
    Dim joy2PosColor As Brush
    Dim joy3PosColor As Brush

    '**********************************************Custom Methods*******************************************

    ''' <summary>
    ''' Read UI controls and build buttonByte1 / buttonByte2 from toggle states
    ''' </summary>
    Sub ReadTxInputs(ByRef buttonByte1 As Byte, ByRef buttonByte2 As Byte,
                     ByRef j1UD As Integer, ByRef j1LR As Integer,
                     ByRef j2UD As Integer, ByRef j2LR As Integer,
                     ByRef j3UD As Integer, ByRef j3LR As Integer)

        buttonByte1 = 0
        buttonByte2 = 0
        If btn1State Then buttonByte1 = buttonByte1 Or CByte(1 << 0)
        If btn2State Then buttonByte1 = buttonByte1 Or CByte(1 << 1)
        If btn3State Then buttonByte1 = buttonByte1 Or CByte(1 << 2)
        If btn4State Then buttonByte1 = buttonByte1 Or CByte(1 << 3)
        If leftBumperState Then buttonByte1 = buttonByte1 Or CByte(1 << 4)
        If rightBumperState Then buttonByte1 = buttonByte1 Or CByte(1 << 5)
        If joy1BtnState Then buttonByte1 = buttonByte1 Or CByte(1 << 6)
        If joy2BtnState Then buttonByte1 = buttonByte1 Or CByte(1 << 7)
        If joy3BtnState Then buttonByte2 = buttonByte2 Or CByte(1 << 0)

        j1UD = Joystick1UDTrackBar.Value
        j1LR = Joystick1LRTrackBar.Value
        j2UD = Joystick2UDTrackBar.Value
        j2LR = Joystick2LRTrackBar.Value
        j3UD = Joystick3UDTrackBar.Value
        j3LR = Joystick3LRTrackBar.Value

        txAddress = CByte(TxAddressNumericUpDown.Value)
    End Sub

    ''' <summary>
    ''' Build and transmit one cycling UART packet over the shared serial port.
    ''' Packet: 0x24 | address | cmdByte | d0 | d1 | d2
    '''   0x42 -> buttonByte1, buttonByte2, 0x00
    '''   0x4A -> joy1UD, joy1LR, joy2UD
    '''   0x6A -> joy2LR, joy3UD, joy3LR
    ''' </summary>
    Sub TransmitPacket()
        If Not URCTestForm.COMSerialPort.IsOpen Then
            TxStatusLabel.Text = "Not Connected"
            Return
        End If

        Dim b1 As Byte, b2 As Byte
        Dim j1UD As Integer, j1LR As Integer
        Dim j2UD As Integer, j2LR As Integer
        Dim j3UD As Integer, j3LR As Integer

        ReadTxInputs(b1, b2, j1UD, j1LR, j2UD, j2LR, j3UD, j3LR)

        Dim packet(5) As Byte
        packet(0) = &H24        ' Start byte '$'
        packet(1) = txAddress   ' Address byte

        Select Case txCommandIndex
            Case 0  ' 0x42 'B' - Buttons
                packet(2) = &H42
                packet(3) = b1
                packet(4) = b2
                packet(5) = 0
            Case 1  ' 0x4A 'J' - Joystick upper
                packet(2) = &H4A
                packet(3) = CByte(j1UD)
                packet(4) = CByte(j1LR)
                packet(5) = CByte(j2UD)
            Case 2  ' 0x6A 'j' - Joystick lower
                packet(2) = &H6A
                packet(3) = CByte(j2LR)
                packet(4) = CByte(j3UD)
                packet(5) = CByte(j3LR)
        End Select

        Try
            URCTestForm.COMSerialPort.Write(packet, 0, packet.Length)
        Catch ex As Exception
            TxStatusLabel.Text = "TX Error!"
            Return
        End Try

        ' Advance command index
        txCommandIndex = (txCommandIndex + 1) Mod 3

        ' Update status label with last sent command
        Dim cmdNames() As String = {"0x42 (Buttons)", "0x4A (Joy Upper)", "0x6A (Joy Lower)"}
        Dim lastSent As Integer = If(txCommandIndex = 0, 2, txCommandIndex - 1)
        TxStatusLabel.Text = "TX: " & cmdNames(lastSent)

        ' Refresh joystick displays
        DrawJoystick1(j1LR, j1UD)
        DrawJoystick2(j2LR, j2UD)
        DrawJoystick3(j3LR, j3UD)
    End Sub

    ''' <summary>
    ''' Update a toggle button's appearance based on its on/off state
    ''' </summary>
    Sub UpdateToggleButton(btn As Button, state As Boolean)
        btn.BackColor = If(state, buttonOnColor, buttonOffColor)
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

    Private Sub URCTxForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        buttonOnColor = Roarange
        buttonOffColor = Color.Gray
        joy1PosColor = New SolidBrush(Roarange)
        joy2PosColor = New SolidBrush(Roarange)
        joy3PosColor = New SolidBrush(Roarange)

        ' Address control setup
        TxAddressNumericUpDown.Minimum = 0
        TxAddressNumericUpDown.Maximum = 255
        TxAddressNumericUpDown.Value = 1

        ' Joysticks start at center
        Joystick1LRTrackBar.Minimum = 0
        Joystick1LRTrackBar.Maximum = 255
        Joystick1LRTrackBar.Value = 128
        Joystick1UDTrackBar.Minimum = 0
        Joystick1UDTrackBar.Maximum = 255
        Joystick1UDTrackBar.Value = 128
        Joystick2LRTrackBar.Minimum = 0
        Joystick2LRTrackBar.Maximum = 255
        Joystick2LRTrackBar.Value = 128
        Joystick2UDTrackBar.Minimum = 0
        Joystick2UDTrackBar.Maximum = 255
        Joystick2UDTrackBar.Value = 128
        Joystick3LRTrackBar.Minimum = 0
        Joystick3LRTrackBar.Maximum = 255
        Joystick3LRTrackBar.Value = 128
        Joystick3UDTrackBar.Minimum = 0
        Joystick3UDTrackBar.Maximum = 255
        Joystick3UDTrackBar.Value = 128

        ' Set all toggle buttons to OFF color
        UpdateToggleButton(Button1ToggleButton, btn1State)
        UpdateToggleButton(Button2ToggleButton, btn2State)
        UpdateToggleButton(Button3ToggleButton, btn3State)
        UpdateToggleButton(Button4ToggleButton, btn4State)
        UpdateToggleButton(LeftBumperToggleButton, leftBumperState)
        UpdateToggleButton(RightBumperToggleButton, rightBumperState)
        UpdateToggleButton(Joy1ButtonToggleButton, joy1BtnState)
        UpdateToggleButton(Joy2ButtonToggleButton, joy2BtnState)
        UpdateToggleButton(Joy3ButtonToggleButton, joy3BtnState)

        ' Enable TX timer
        SerialTXTimer.Interval = 20     ' 20ms = 50Hz, full 3-packet cycle every 60ms
        SerialTXTimer.Enabled = True

        ' Draw initial joystick positions
        TxStartUpTimer.Enabled = True
    End Sub

    ''' <summary>
    ''' When TX form is closed, switch the main form back to RX mode
    ''' </summary>
    Private Sub URCTxForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SerialTXTimer.Enabled = False
        ' Switch main form radio button back to RX
        URCTestForm.RxModeRadioButton.Checked = True
    End Sub

    '-- TX Timer --
    Private Sub SerialTXTimer_Tick(sender As Object, e As EventArgs) Handles SerialTXTimer.Tick
        TransmitPacket()
    End Sub

    '-- Startup timer to let PictureBoxes initialize before drawing --
    Private Sub TxStartUpTimer_Tick(sender As Object, e As EventArgs) Handles TxStartUpTimer.Tick
        TxStartUpTimer.Enabled = False
        DrawJoystick1(128, 128)
        DrawJoystick2(128, 128)
        DrawJoystick3(128, 128)
    End Sub

    '-- TrackBar value labels --
    Private Sub Joystick1UDTrackBar_Scroll(sender As Object, e As EventArgs) Handles Joystick1UDTrackBar.Scroll
        Joystick1UDLabel.Text = CStr(Joystick1UDTrackBar.Value)
    End Sub
    Private Sub Joystick1LRTrackBar_Scroll(sender As Object, e As EventArgs) Handles Joystick1LRTrackBar.Scroll
        Joystick1LRLabel.Text = CStr(Joystick1LRTrackBar.Value)
    End Sub
    Private Sub Joystick2UDTrackBar_Scroll(sender As Object, e As EventArgs) Handles Joystick2UDTrackBar.Scroll
        Joystick2UDLabel.Text = CStr(Joystick2UDTrackBar.Value)
    End Sub
    Private Sub Joystick2LRTrackBar_Scroll(sender As Object, e As EventArgs) Handles Joystick2LRTrackBar.Scroll
        Joystick2LRLabel.Text = CStr(Joystick2LRTrackBar.Value)
    End Sub
    Private Sub Joystick3UDTrackBar_Scroll(sender As Object, e As EventArgs) Handles Joystick3UDTrackBar.Scroll
        Joystick3UDLabel.Text = CStr(Joystick3UDTrackBar.Value)
    End Sub
    Private Sub Joystick3LRTrackBar_Scroll(sender As Object, e As EventArgs) Handles Joystick3LRTrackBar.Scroll
        Joystick3LRLabel.Text = CStr(Joystick3LRTrackBar.Value)
    End Sub

    '-- Button Toggles --
    Private Sub Button1ToggleButton_Click(sender As Object, e As EventArgs) Handles Button1ToggleButton.Click
        btn1State = Not btn1State
        UpdateToggleButton(Button1ToggleButton, btn1State)
    End Sub
    Private Sub Button2ToggleButton_Click(sender As Object, e As EventArgs) Handles Button2ToggleButton.Click
        btn2State = Not btn2State
        UpdateToggleButton(Button2ToggleButton, btn2State)
    End Sub
    Private Sub Button3ToggleButton_Click(sender As Object, e As EventArgs) Handles Button3ToggleButton.Click
        btn3State = Not btn3State
        UpdateToggleButton(Button3ToggleButton, btn3State)
    End Sub
    Private Sub Button4ToggleButton_Click(sender As Object, e As EventArgs) Handles Button4ToggleButton.Click
        btn4State = Not btn4State
        UpdateToggleButton(Button4ToggleButton, btn4State)
    End Sub
    Private Sub LeftBumperToggleButton_Click(sender As Object, e As EventArgs) Handles LeftBumperToggleButton.Click
        leftBumperState = Not leftBumperState
        UpdateToggleButton(LeftBumperToggleButton, leftBumperState)
    End Sub
    Private Sub RightBumperToggleButton_Click(sender As Object, e As EventArgs) Handles RightBumperToggleButton.Click
        rightBumperState = Not rightBumperState
        UpdateToggleButton(RightBumperToggleButton, rightBumperState)
    End Sub
    Private Sub Joy1ButtonToggleButton_Click(sender As Object, e As EventArgs) Handles Joy1ButtonToggleButton.Click
        joy1BtnState = Not joy1BtnState
        UpdateToggleButton(Joy1ButtonToggleButton, joy1BtnState)
    End Sub
    Private Sub Joy2ButtonToggleButton_Click(sender As Object, e As EventArgs) Handles Joy2ButtonToggleButton.Click
        joy2BtnState = Not joy2BtnState
        UpdateToggleButton(Joy2ButtonToggleButton, joy2BtnState)
    End Sub
    Private Sub Joy3ButtonToggleButton_Click(sender As Object, e As EventArgs) Handles Joy3ButtonToggleButton.Click
        joy3BtnState = Not joy3BtnState
        UpdateToggleButton(Joy3ButtonToggleButton, joy3BtnState)
    End Sub
End Class