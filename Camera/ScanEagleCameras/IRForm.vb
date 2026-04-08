'Carson Bogart and Dane Davids
'Drone Camera control

'Shane Slack

'Spring 2023

'This program is used to control the scaneagle drone cameras using a byte array to send
'commands derived from reading information sent from an already existing test program.
'Whenever a button is pressed from within the form the byte array is populated with the
'corresponding command and then sent to a rs-232 to TTL converter then to the camera.

Option Explicit On
Option Strict On

Imports System.Text

Public Class IRForm

    Dim headerByte(17) As Byte

    Dim directModeBool, stabalizeModeBool, offModeBool, pointtwoDegreeBool,
        oneDegreeBool, fiveDegreeBool, fifteenDegreeBool, twentyFiveDegreeBool,
        fourtyFiveDegreeBool, upButtonBool, leftButtonBool, downButtonBool, rightButtonBool As Boolean

    Private Sub IRForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        'opens the named port at the designated bit rate, Size, And parity
        SerialPort1.PortName = "COM3"              'name serial port
        SerialPort1.BaudRate = 57600                'set baud rate 57.6k
        SerialPort1.DataBits = 8                    'number of data bits is 8
        SerialPort1.StopBits = IO.Ports.StopBits.One  'one stop bit
        SerialPort1.Parity = IO.Ports.Parity.None   'no parity bits
        SerialPort1.Open()                          'initialize and open port

        'setting default values for the global variables that will be edited throughout the program

        offModeRadioButton.Checked = True   'defaults the off button as checked which disables controls on the main form

        fiveDegreesRadioButton.Checked = True   'defaults the button as checked to enable the camera to move at 5 degrees per event

        pointtwoDegreeBool = False
        oneDegreeBool = False   'defaults the 5 degree mode ON so that the camera will move at this level per event
        fiveDegreeBool = True
        fifteenDegreeBool = False
        twentyFiveDegreeBool = False
        fourtyFiveDegreeBool = False

        directionalButtonsOff()  'calls sub that makes sure that the buttons are disabled on loading of the form
        offModeEnabled()
        fiveDegreeMode()

        'filling the array with default values on load -- bytes 8-17 are altered throughout the program
        headerByte(0) = &H55
        headerByte(1) = &HAA
        headerByte(2) = &H7
        headerByte(3) = &H4D
        headerByte(4) = &H0
        headerByte(5) = &H1
        headerByte(6) = &H0
        headerByte(7) = &H98
        headerByte(8) = &H0
        headerByte(9) = &H0
        headerByte(10) = &H0
        headerByte(11) = &H0
        headerByte(12) = &H0
        headerByte(13) = &H0
        headerByte(14) = &H0
        headerByte(15) = &H0
        headerByte(16) = &H0
        headerByte(17) = &H0

        'calls the sub that turns off all of the buttons if neither camera option is selected
        '-- as of 4/27/2023 there is no difference between cameras and their functionality of the
        'program so it doesn't matter which one is selected
        If IRCameraRadioButton.Checked = False Or SonyRadioButton.Checked = False Then
            allButtonsOff()
        End If

    End Sub

    'vv turns the buttons/controls on the form OFF
    Private Sub allButtonsOff()
        ZoomInButton.Enabled = False
        ZoomOutButton.Enabled = False
        modeSelectGroupBox.Enabled = False
        pointTwoDegreeRadioButton.Enabled = False
        oneDegreeRadioButton.Enabled = False
        fiveDegreesRadioButton.Enabled = False
        fifteenDegreesRadioButton.Enabled = False
        twentyFiveDegreesRadioButton.Enabled = False
        fourtyFiveDegreesRadioButton.Enabled = False
        GimbalButton1.Enabled = False
        GimbalButton2.Enabled = False
        GimbalButton3.Enabled = False
        GimbalButton4.Enabled = False
        HomeButton.Enabled = False
        VideoOffButton.Enabled = False
        VideoOnButton.Enabled = False
        FFCButton.Enabled = False
        ResetButton.Enabled = False
    End Sub

    'vv turns the buttons/controls on the form ON when the IR Camera is selected
    Private Sub IRCameraRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles IRCameraRadioButton.CheckedChanged
        ZoomInButton.Enabled = True
        ZoomOutButton.Enabled = True
        modeSelectGroupBox.Enabled = True
        pointTwoDegreeRadioButton.Enabled = True
        oneDegreeRadioButton.Enabled = True
        fiveDegreesRadioButton.Enabled = True
        fifteenDegreesRadioButton.Enabled = True
        twentyFiveDegreesRadioButton.Enabled = True
        fourtyFiveDegreesRadioButton.Enabled = True
        GimbalButton1.Enabled = True
        GimbalButton2.Enabled = True
        GimbalButton3.Enabled = True
        GimbalButton4.Enabled = True
        HomeButton.Enabled = True
        VideoOffButton.Enabled = True
        VideoOnButton.Enabled = True
        FFCButton.Enabled = True
        ResetButton.Enabled = True
    End Sub

    'vv turns the buttons/controls on the form ON when the Sony Camera is selected
    Private Sub SonyRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles SonyRadioButton.CheckedChanged
        ZoomInButton.Enabled = True
        ZoomOutButton.Enabled = True
        modeSelectGroupBox.Enabled = True
        pointTwoDegreeRadioButton.Enabled = True
        oneDegreeRadioButton.Enabled = True
        fiveDegreesRadioButton.Enabled = True
        fifteenDegreesRadioButton.Enabled = True
        twentyFiveDegreesRadioButton.Enabled = True
        fourtyFiveDegreesRadioButton.Enabled = True
        GimbalButton1.Enabled = True
        GimbalButton2.Enabled = True
        GimbalButton3.Enabled = True
        GimbalButton4.Enabled = True
        HomeButton.Enabled = True
        VideoOffButton.Enabled = True
        VideoOnButton.Enabled = True
        FFCButton.Enabled = True
        ResetButton.Enabled = True
    End Sub

    'vv changes the last 8 bytes of the array and then writes it out to move the camera to the designated position
    Private Sub GimbalButton1_Click(sender As Object, e As EventArgs) Handles GimbalButton1.Click, HomeButton.Click
        headerByte(9) = &H47
        headerByte(10) = &H4A
        headerByte(11) = &H19
        headerByte(12) = &HB8
        headerByte(13) = &H8B
        headerByte(14) = &H0
        headerByte(15) = &H80
        headerByte(16) = &H31
        headerByte(17) = &H53
        SerialPort1.Write(headerByte, 0, 18)
    End Sub

    'vv changes the last 8 bytes of the array and then writes it out to move the camera to the designated position
    Private Sub GimbalButton2_Click(sender As Object, e As EventArgs) Handles GimbalButton2.Click
        headerByte(9) = &H47
        headerByte(10) = &H4A
        headerByte(11) = &H19
        headerByte(12) = &H48
        headerByte(13) = &H74
        headerByte(14) = &H0
        headerByte(15) = &H80
        headerByte(16) = &H1
        headerByte(17) = &H50
        SerialPort1.Write(headerByte, 0, 18)
    End Sub

    'vv changes the last 8 bytes of the array and then writes it out to move the camera to the designated position
    Private Sub GimbalButton3_Click(sender As Object, e As EventArgs) Handles GimbalButton3.Click
        headerByte(9) = &H47
        headerByte(10) = &H4A
        headerByte(11) = &H19
        headerByte(12) = &H0
        headerByte(13) = &H80
        headerByte(14) = &H22
        headerByte(15) = &H99
        headerByte(16) = &H39
        headerByte(17) = &HDF
        SerialPort1.Write(headerByte, 0, 18)
    End Sub

    'vv changes the last 8 bytes of the array and then writes it out to move the camera to the designated position
    Private Sub GimbalButton4_Click(sender As Object, e As EventArgs) Handles GimbalButton4.Click
        headerByte(9) = &H47
        headerByte(10) = &H4A
        headerByte(11) = &H19
        headerByte(12) = &H0
        headerByte(13) = &H80
        headerByte(14) = &HDE
        headerByte(15) = &H66
        headerByte(16) = &H79
        headerByte(17) = &HDE
        SerialPort1.Write(headerByte, 0, 18)
    End Sub

    'vv changes the last 8 bytes of the array and then writes it out to turn the video from the camera ON
    Private Sub VideoOnButton_Click(sender As Object, e As EventArgs) Handles VideoOnButton.Click
        headerByte(9) = &H7C
        headerByte(10) = &H0
        headerByte(11) = &H0
        headerByte(12) = &H0
        headerByte(13) = &H0
        headerByte(14) = &H0
        headerByte(15) = &H0
        headerByte(16) = &H70
        headerByte(17) = &H9F
        SerialPort1.Write(headerByte, 0, 18)
    End Sub

    'vv changes the last 8 bytes of the array and then writes it out to turn the video from the camera OFF
    Private Sub VideoOffButton_Click(sender As Object, e As EventArgs) Handles VideoOffButton.Click
        headerByte(9) = &H6F
        headerByte(10) = &H0
        headerByte(11) = &H0
        headerByte(12) = &H0
        headerByte(13) = &H0
        headerByte(14) = &H0
        headerByte(15) = &H0
        headerByte(16) = &HB1
        headerByte(17) = &HBD
        SerialPort1.Write(headerByte, 0, 18)
    End Sub

    'vv changes the last 8 bytes of the array and then writes it out to adjust the Flat Field Correction (FFC)
    Private Sub FFCButton_Click(sender As Object, e As EventArgs) Handles FFCButton.Click
        headerByte(9) = &H6D
        headerByte(10) = &H1
        headerByte(11) = &H3
        headerByte(12) = &H0
        headerByte(13) = &H0
        headerByte(14) = &H0
        headerByte(15) = &H0
        headerByte(16) = &HA0
        headerByte(17) = &HDB
        SerialPort1.Write(headerByte, 0, 18)
    End Sub

    'vv changes the last 8 bytes of the array and then writes it out to reset the camera position and video signal
    Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
        headerByte(9) = &H47
        headerByte(10) = &HFE
        headerByte(11) = &H0
        headerByte(12) = &H0
        headerByte(13) = &H0
        headerByte(14) = &H0
        headerByte(15) = &H0
        headerByte(16) = &HED
        headerByte(17) = &H0
        SerialPort1.Write(headerByte, 0, 18)
    End Sub

    'vv when the off mode radio button changes this sub checks if it was changed to enabled (true).
    'If enabled, disables the other buttons and associated controls.
    Private Sub offModeRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles offModeRadioButton.CheckedChanged
        If offModeRadioButton.Checked = True Then
            directModeRadioButton.Checked = False
            stabilizeModeRadioButton.Checked = False
            upButton.Enabled = False
            downButton.Enabled = False
            leftButton.Enabled = False
            rightButton.Enabled = False
            offModeEnabled()
        End If
    End Sub

    'vv when the direct mode radio button changes this sub checks if it was changed to enabled (true).
    'If enabled, disables the other buttons and enables associated controls and modes.
    Private Sub directModeRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles directModeRadioButton.CheckedChanged
        If directModeRadioButton.Checked = True Then
            offModeRadioButton.Checked = False
            stabilizeModeRadioButton.Checked = False
            directModeEnabled()
        End If
        directionalButtonsOn()
    End Sub

    'vv when the stabilize mode radio button changes this sub checks if it was changed to enabled (true).
    'If enabled, disables the other buttons and enables associated controls and modes.
    Private Sub stabilizeModeRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles stabilizeModeRadioButton.CheckedChanged
        If stabilizeModeRadioButton.Checked = True Then
            offModeRadioButton.Checked = False
            directModeRadioButton.Checked = False
            stabalizeModeEnabled()
        End If
        directionalButtonsOn()
    End Sub

    'vv when the point two degree radio button changes this sub checks if it was changed to enabled (true).
    Private Sub pointtwoDegreeRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles pointTwoDegreeRadioButton.CheckedChanged
        If pointTwoDegreeRadioButton.Checked = True Then
            oneDegreeRadioButton.Checked = False
            fiveDegreesRadioButton.Checked = False
            fifteenDegreesRadioButton.Checked = False
            twentyFiveDegreesRadioButton.Checked = False
            fourtyFiveDegreesRadioButton.Checked = False
            pointtwoDegreeMode()
        End If
    End Sub

    'vv when the one degree radio button changes this sub checks if it was changed to enabled (true).
    Private Sub oneDegreeRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles oneDegreeRadioButton.CheckedChanged
        If oneDegreeRadioButton.Checked = True Then
            pointTwoDegreeRadioButton.Checked = False
            fiveDegreesRadioButton.Checked = False
            fifteenDegreesRadioButton.Checked = False
            twentyFiveDegreesRadioButton.Checked = False
            fourtyFiveDegreesRadioButton.Checked = False
            oneDegreeMode()
        End If
    End Sub

    'vv when the five degree radio button changes this sub checks if it was changed to enabled (true).
    Private Sub fiveDegreesRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles fiveDegreesRadioButton.CheckedChanged
        If fiveDegreesRadioButton.Checked = True Then
            pointTwoDegreeRadioButton.Checked = False
            oneDegreeRadioButton.Checked = False
            fifteenDegreesRadioButton.Checked = False
            twentyFiveDegreesRadioButton.Checked = False
            fourtyFiveDegreesRadioButton.Checked = False
            fiveDegreeMode()
        End If
    End Sub

    'vv when the fifteen degree radio button changes this sub checks if it was changed to enabled (true).
    Private Sub fifteenDegreesRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles fifteenDegreesRadioButton.CheckedChanged
        If fifteenDegreesRadioButton.Checked Then
            pointTwoDegreeRadioButton.Checked = False
            oneDegreeRadioButton.Checked = False
            fiveDegreesRadioButton.Checked = False
            twentyFiveDegreesRadioButton.Checked = False
            fourtyFiveDegreesRadioButton.Checked = False
            fifteenDegreeMode()
        End If
    End Sub

    'vv when the twenty five degree radio button changes this sub checks if it was changed to enabled (true).
    Private Sub twentyFiveDegreesRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles twentyFiveDegreesRadioButton.CheckedChanged
        If twentyFiveDegreesRadioButton.Checked = True Then
            pointTwoDegreeRadioButton.Checked = False
            oneDegreeRadioButton.Checked = False
            fiveDegreesRadioButton.Checked = False
            fifteenDegreesRadioButton.Checked = False
            fourtyFiveDegreesRadioButton.Checked = False
            twentyFiveDegreeMode()
        End If
    End Sub

    'vv when the forty five degree radio button changes this sub checks if it was changed to enabled (true).
    Private Sub fourtyFiveDegreesRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles fourtyFiveDegreesRadioButton.CheckedChanged
        If fourtyFiveDegreesRadioButton.Checked = True Then
            pointTwoDegreeRadioButton.Checked = False
            oneDegreeRadioButton.Checked = False
            fiveDegreesRadioButton.Checked = False
            fifteenDegreesRadioButton.Checked = False
            twentyFiveDegreesRadioButton.Checked = False
            fourtyFiveDegreeMode()
        End If
    End Sub

    'vv up button click to move the camera up
    Private Sub upButton_Click(sender As Object, e As EventArgs) Handles upButton.Click
        upButtonBool = True     'sets a variable as true and disables others to prevent unwanted edits
        leftButtonBool = False
        downButtonBool = False
        rightButtonBool = False

        headerByte(9) = &H47    'edits the byte to communicate it is a pan or tilt control

        If directModeBool = True Then   'checking which mode and calling a sub to determine angle
            whichAngleDirectUp()
            headerByte(10) = &H10
        ElseIf stabalizeModeBool = True Then
            whichAngleStabalizeUp()
            headerByte(10) = &H20
        End If

        headerByte(11) = &H0    'filling bytes for up/down control
        headerByte(12) = &H0
        headerByte(13) = &H80

        SerialPort1.Write(headerByte, 0, 18)    'serial writes the command to the camera
    End Sub

    'vv left button click to move the camera left
    Private Sub leftButton_Click(sender As Object, e As EventArgs) Handles leftButton.Click
        upButtonBool = False    'sets a variable as true and disables others to prevent unwanted edits
        leftButtonBool = True
        downButtonBool = False
        rightButtonBool = False

        headerByte(9) = &H47    'edits the byte to communicate it is a pan or tilt control

        If directModeBool = True Then   'checking which mode and calling a sub to determine angle
            whichAngleDirectLeft()
            headerByte(10) = &H10
        ElseIf stabalizeModeBool = True Then
            whichAngleStabalizeLeft()
            headerByte(10) = &H20
        End If

        headerByte(11) = &H0    'filling bytes for left/right control
        headerByte(14) = &H0
        headerByte(15) = &H80

        SerialPort1.Write(headerByte, 0, 18)    'serial writes the command to the camera
    End Sub

    'vv down button click to move the camera down
    Private Sub downButton_Click(sender As Object, e As EventArgs) Handles downButton.Click
        upButtonBool = False    'sets a variable as true and disables others to prevent unwanted edits
        leftButtonBool = False
        downButtonBool = True
        rightButtonBool = False

        headerByte(9) = &H47    'edits the byte to communicate it is a pan or tilt control

        If directModeBool = True Then   'checking which mode and calling a sub to determine angle
            whichAngleDirectDown()
            headerByte(10) = &H10
        ElseIf stabalizeModeBool = True Then
            whichAngleStabalizeDown()
            headerByte(10) = &H20
        End If

        headerByte(11) = &H0    'filling bytes for up/down control
        headerByte(12) = &H0
        headerByte(13) = &H80

        SerialPort1.Write(headerByte, 0, 18)
    End Sub

    'vv right button click to move the camera right
    Private Sub rightButton_Click(sender As Object, e As EventArgs) Handles rightButton.Click
        upButtonBool = False    'sets a variable as true and disables others to prevent unwanted edits
        leftButtonBool = False
        downButtonBool = False
        rightButtonBool = True

        headerByte(9) = &H47    'edits the byte to communicate it is a pan or tilt control

        If directModeBool = True Then   'checking which mode and calling a sub to determine angle
            whichAngleDirectRight()
            headerByte(10) = &H10
        ElseIf stabalizeModeBool = True Then
            whichAngleStabalizeRight()
            headerByte(10) = &H20
        End If

        headerByte(11) = &H0    'filling bytes for left/right control
        headerByte(14) = &H0
        headerByte(15) = &H80

        SerialPort1.Write(headerByte, 0, 18)    'serial writes the command to the camera
    End Sub

    'vv closes the program when the exit button on the form is pressed
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    'vv fills the array with the necessary command bytes to stop the zooming of the camera
    Private Sub zoomStop(sender As Object, e As EventArgs) Handles ZoomInButton.MouseUp, ZoomOutButton.MouseUp
        headerByte(9) = &H5A
        headerByte(10) = &H0
        headerByte(11) = &H0
        headerByte(12) = &H0
        headerByte(13) = &H0
        headerByte(14) = &H0
        headerByte(15) = &H0
        headerByte(16) = &HB2
        headerByte(17) = &HD8
        SerialPort1.Write(headerByte, 0, 18)
    End Sub

    'vv begins zooming in by filling the array with the necessary bytes and then sending them
    Private Sub ZoomInButton_MouseDown(sender As Object, e As MouseEventArgs) Handles ZoomInButton.MouseDown
        headerByte(9) = &H5A
        headerByte(10) = &H1
        headerByte(11) = &H0
        headerByte(12) = &H0
        headerByte(13) = &H0
        headerByte(14) = &H1
        headerByte(15) = &H0
        headerByte(16) = &HF3
        headerByte(17) = &HD8
        SerialPort1.Write(headerByte, 0, 18)
    End Sub

    'vv begins zooming out by filling the array with the necessary bytes and then sending them
    Private Sub ZoomOutButton_MouseDown(sender As Object, e As MouseEventArgs) Handles ZoomOutButton.MouseDown
        headerByte(9) = &H5A
        headerByte(10) = &HFF
        headerByte(11) = &H0
        headerByte(12) = &H0
        headerByte(13) = &H0
        headerByte(14) = &H1
        headerByte(15) = &H0
        headerByte(16) = &H2D
        headerByte(17) = &HCD
        SerialPort1.Write(headerByte, 0, 18)
    End Sub

    'vv enables the direction buttons to control the camera
    Private Sub directionalButtonsOn()
        upButton.Enabled = True
        downButton.Enabled = True
        leftButton.Enabled = True
        rightButton.Enabled = True
    End Sub

    'vv disables the direction buttons to control the camera
    Private Sub directionalButtonsOff()
        upButton.Enabled = False
        downButton.Enabled = False
        leftButton.Enabled = False
        rightButton.Enabled = False
    End Sub

    'vv alters the boolean variables to reflect which mode the camera is in and edits the array byte
    Private Sub offModeEnabled()
        offModeBool = True
        directModeBool = False
        stabalizeModeBool = False
        headerByte(10) = &H0
    End Sub

    'vv alters the boolean variables to reflect which mode the camera is in
    Private Sub directModeEnabled()
        offModeBool = False
        directModeBool = True
        stabalizeModeBool = False
    End Sub

    'vv alters the boolean variables to reflect which mode the camera is in
    Private Sub stabalizeModeEnabled()
        offModeBool = False
        directModeBool = False
        stabalizeModeBool = True
    End Sub

    'vv altering the global variables for program communication for which angle the camera is moving at
    Private Sub pointtwoDegreeMode()
        pointtwoDegreeBool = True
        oneDegreeBool = False
        fiveDegreeBool = False
        fifteenDegreeBool = False
        twentyFiveDegreeBool = False
        fourtyFiveDegreeBool = False
    End Sub

    'vv altering the global variables for program communication for which angle the camera is moving at
    Private Sub oneDegreeMode()
        pointtwoDegreeBool = False
        oneDegreeBool = True
        fiveDegreeBool = False
        fifteenDegreeBool = False
        twentyFiveDegreeBool = False
        fourtyFiveDegreeBool = False
    End Sub

    'vv altering the global variables for program communication for which angle the camera is moving at
    Private Sub fiveDegreeMode()
        pointtwoDegreeBool = False
        oneDegreeBool = False
        fiveDegreeBool = True
        fifteenDegreeBool = False
        twentyFiveDegreeBool = False
        fourtyFiveDegreeBool = False
    End Sub

    'vv altering the global variables for program communication for which angle the camera is moving at
    Private Sub fifteenDegreeMode()
        pointtwoDegreeBool = False
        oneDegreeBool = False
        fiveDegreeBool = False
        fifteenDegreeBool = True
        twentyFiveDegreeBool = False
        fourtyFiveDegreeBool = False
    End Sub

    'vv altering the global variables for program communication for which angle the camera is moving at
    Private Sub twentyFiveDegreeMode()
        pointtwoDegreeBool = False
        oneDegreeBool = False
        fiveDegreeBool = False
        fifteenDegreeBool = False
        twentyFiveDegreeBool = True
        fourtyFiveDegreeBool = False
    End Sub

    'vv altering the global variables for program communication for which angle the camera is moving at
    Private Sub fourtyFiveDegreeMode()
        pointtwoDegreeBool = False
        oneDegreeBool = False
        fiveDegreeBool = False
        fifteenDegreeBool = False
        twentyFiveDegreeBool = False
        fourtyFiveDegreeBool = True
    End Sub

    'vv using if statements to check which degree mode was selected and filling in the array bytes with needed data
    Private Sub whichAngleDirectUp()
        If pointtwoDegreeBool = True Then
            headerByte(14) = &HDD
            headerByte(15) = &H7F
            headerByte(16) = &H7B
            headerByte(17) = &HE
        ElseIf oneDegreeBool = True Then
            headerByte(14) = &H51
            headerByte(15) = &H7F
            headerByte(16) = &HBB
            headerByte(17) = &H6A
        ElseIf fiveDegreeBool = True Then
            headerByte(14) = &H97
            headerByte(15) = &H7C
            headerByte(16) = &H1A
            headerByte(17) = &H79
        ElseIf fifteenDegreeBool = True Then
            headerByte(14) = &HC6
            headerByte(15) = &H75
            headerByte(16) = &H8C
            headerByte(17) = &H84
        ElseIf twentyFiveDegreeBool = True Then
            headerByte(14) = &HF5
            headerByte(15) = &H6E
            headerByte(16) = &H77
            headerByte(17) = &HD0
        ElseIf fourtyFiveDegreeBool = True Then
            headerByte(14) = &H52
            headerByte(15) = &H61
            headerByte(16) = &H43
            headerByte(17) = &HEA
        End If
    End Sub

    'vv using if statements to check which degree mode was selected and filling in the array bytes with needed data
    Private Sub whichAngleDirectLeft()
        If pointtwoDegreeBool = True Then
            headerByte(12) = &HDD
            headerByte(13) = &H7F
            headerByte(16) = &H37
            headerByte(17) = &H1D
        ElseIf oneDegreeBool = True Then
            headerByte(12) = &H51
            headerByte(13) = &H7F
            headerByte(16) = &HA7
            headerByte(17) = &H37
        ElseIf fiveDegreeBool = True Then
            headerByte(12) = &H97
            headerByte(13) = &H7C
            headerByte(16) = &H2F
            headerByte(17) = &HFB
        ElseIf fifteenDegreeBool = True Then
            headerByte(12) = &HC6
            headerByte(13) = &H75
            headerByte(16) = &HD1
            headerByte(17) = &H3B
        ElseIf twentyFiveDegreeBool = True Then
            headerByte(12) = &HF5
            headerByte(13) = &H6E
            headerByte(16) = &H92
            headerByte(17) = &H44
        ElseIf fourtyFiveDegreeBool = True Then
            headerByte(12) = &H52
            headerByte(13) = &H61
            headerByte(16) = &HE5
            headerByte(17) = &H57
        End If
    End Sub

    'vv using if statements to check which degree mode was selected and filling in the array bytes with needed data
    Private Sub whichAngleDirectDown()
        If pointtwoDegreeBool = True Then
            headerByte(14) = &H23
            headerByte(15) = &H80
            headerByte(16) = &H5B
            headerByte(17) = &HE
        ElseIf oneDegreeBool = True Then
            headerByte(14) = &HAF
            headerByte(15) = &H80
            headerByte(16) = &H9B
            headerByte(17) = &H6A
        ElseIf fiveDegreeBool = True Then
            headerByte(14) = &H69
            headerByte(15) = &H83
            headerByte(16) = &H3A
            headerByte(17) = &H79
        ElseIf fifteenDegreeBool = True Then
            headerByte(14) = &H3A
            headerByte(15) = &H8A
            headerByte(16) = &HCC
            headerByte(17) = &H85
        ElseIf twentyFiveDegreeBool = True Then
            headerByte(14) = &HB
            headerByte(15) = &H91
            headerByte(16) = &H57
            headerByte(17) = &HD0
        ElseIf fourtyFiveDegreeBool = True Then
            headerByte(14) = &HAE
            headerByte(15) = &H9E
            headerByte(16) = &H3
            headerByte(17) = &HEB
        End If
    End Sub

    'vv using if statements to check which degree mode was selected and filling in the array bytes with needed data
    Private Sub whichAngleDirectRight()
        If pointtwoDegreeBool = True Then
            headerByte(12) = &H23
            headerByte(13) = &H80
            headerByte(16) = &HEF
            headerByte(17) = &H1C
        ElseIf oneDegreeBool = True Then
            headerByte(12) = &HAF
            headerByte(13) = &H80
            headerByte(16) = &H7F
            headerByte(17) = &H36
        ElseIf fiveDegreeBool = True Then
            headerByte(12) = &H69
            headerByte(13) = &H83
            headerByte(16) = &HF7
            headerByte(17) = &HFA
        ElseIf fifteenDegreeBool = True Then
            headerByte(12) = &H3A
            headerByte(13) = &H8A
            headerByte(16) = &HB1
            headerByte(17) = &H3B
        ElseIf twentyFiveDegreeBool = True Then
            headerByte(12) = &HB
            headerByte(13) = &H91
            headerByte(16) = &H4A
            headerByte(17) = &H45
        ElseIf fourtyFiveDegreeBool = True Then
            headerByte(12) = &HAE
            headerByte(13) = &H9E
            headerByte(16) = &H85
            headerByte(17) = &H57
        End If
    End Sub

    'vv using if statements to check which degree mode was selected and filling in the array bytes with needed data
    Private Sub whichAngleStabalizeUp()
        If pointtwoDegreeBool = True Then
            headerByte(14) = &HDD
            headerByte(15) = &H7F
            headerByte(16) = &H8B
            headerByte(17) = &HB
        ElseIf oneDegreeBool = True Then
            headerByte(14) = &H51
            headerByte(15) = &H7F
            headerByte(16) = &H4B
            headerByte(17) = &H6F
        ElseIf fiveDegreeBool = True Then
            headerByte(14) = &H97
            headerByte(15) = &H7C
            headerByte(16) = &HEA
            headerByte(17) = &H7C
        ElseIf fifteenDegreeBool = True Then
            headerByte(14) = &HC6
            headerByte(15) = &H75
            headerByte(16) = &H7C
            headerByte(17) = &H81
        ElseIf twentyFiveDegreeBool = True Then
            headerByte(14) = &HF5
            headerByte(15) = &H6E
            headerByte(16) = &H87
            headerByte(17) = &HD5
        ElseIf fourtyFiveDegreeBool = True Then
            headerByte(14) = &H52
            headerByte(15) = &H61
            headerByte(16) = &HB3
            headerByte(17) = &HEF
        End If
    End Sub

    'vv using if statements to check which degree mode was selected and filling in the array bytes with needed data
    Private Sub whichAngleStabalizeLeft()
        If pointtwoDegreeBool = True Then
            headerByte(12) = &HDD
            headerByte(13) = &H7F
            headerByte(16) = &HC7
            headerByte(17) = &H18
        ElseIf oneDegreeBool = True Then
            headerByte(12) = &H51
            headerByte(13) = &H7F
            headerByte(16) = &H57
            headerByte(17) = &H32
        ElseIf fiveDegreeBool = True Then
            headerByte(12) = &H97
            headerByte(13) = &H7C
            headerByte(16) = &HDF
            headerByte(17) = &HFE
        ElseIf fifteenDegreeBool = True Then
            headerByte(12) = &HC6
            headerByte(13) = &H75
            headerByte(16) = &H21
            headerByte(17) = &H3E
        ElseIf twentyFiveDegreeBool = True Then
            headerByte(12) = &HF5
            headerByte(13) = &H6E
            headerByte(16) = &H62
            headerByte(17) = &H41
        ElseIf fourtyFiveDegreeBool = True Then
            headerByte(12) = &H52
            headerByte(13) = &H61
            headerByte(16) = &H15
            headerByte(17) = &H52
        End If
    End Sub

    'vv using if statements to check which degree mode was selected and filling in the array bytes with needed data
    Private Sub whichAngleStabalizeDown()
        If pointtwoDegreeBool = True Then
            headerByte(14) = &H23
            headerByte(15) = &H80
            headerByte(16) = &HAB
            headerByte(17) = &HB
        ElseIf oneDegreeBool = True Then
            headerByte(14) = &HAF
            headerByte(15) = &H80
            headerByte(16) = &H6B
            headerByte(17) = &H6F
        ElseIf fiveDegreeBool = True Then
            headerByte(14) = &H69
            headerByte(15) = &H83
            headerByte(16) = &HCA
            headerByte(17) = &H7C
        ElseIf fifteenDegreeBool = True Then
            headerByte(14) = &H3A
            headerByte(15) = &H8A
            headerByte(16) = &H3C
            headerByte(17) = &H80
        ElseIf twentyFiveDegreeBool = True Then
            headerByte(14) = &HB
            headerByte(15) = &H91
            headerByte(16) = &HA7
            headerByte(17) = &HD5
        ElseIf fourtyFiveDegreeBool = True Then
            headerByte(14) = &HAE
            headerByte(15) = &H9E
            headerByte(16) = &HF3
            headerByte(17) = &HEE
        End If
    End Sub

    'vv using if statements to check which degree mode was selected and filling in the array bytes with needed data
    Private Sub whichAngleStabalizeRight()
        If pointtwoDegreeBool = True Then
            headerByte(12) = &H23
            headerByte(13) = &H80
            headerByte(16) = &H1F
            headerByte(17) = &H19
        ElseIf oneDegreeBool = True Then
            headerByte(12) = &HAF
            headerByte(13) = &H80
            headerByte(16) = &H8F
            headerByte(17) = &H33
        ElseIf fiveDegreeBool = True Then
            headerByte(12) = &H69
            headerByte(13) = &H83
            headerByte(16) = &H7
            headerByte(17) = &HFF
        ElseIf fifteenDegreeBool = True Then
            headerByte(12) = &H3A
            headerByte(13) = &H8A
            headerByte(16) = &H41
            headerByte(17) = &H3E
        ElseIf twentyFiveDegreeBool = True Then
            headerByte(12) = &HB
            headerByte(13) = &H91
            headerByte(16) = &HBA
            headerByte(17) = &H40
        ElseIf fourtyFiveDegreeBool = True Then
            headerByte(12) = &HAE
            headerByte(13) = &H9E
            headerByte(16) = &H75
            headerByte(17) = &H52
        End If
    End Sub

End Class
