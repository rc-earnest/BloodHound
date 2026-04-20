/**Rudy Earnest
 RCET Capstone Project
 Spring 2026
 Camera I2C to UART communications*/

//This code takes the I2C from the controller pic and converts them to UART for
//the camera

// Config.h sets up PIC-specific registers (oscillator, pins, peripherals, etc.)
#include "Config.h"
#include <xc.h>       // XC8 compiler header for PIC register definitions
#include <stdint.h>   // Provides fixed-width integer types (uint8_t, etc.)
#include <stdbool.h>  // Provides bool, true, false


// --- Global Variables ---
// These are marked volatile because they are written inside the ISR and read in main()

volatile bool rx_done = 0;       // Flag: set to 1 by ISR when a full 4-byte I2C packet has been received
volatile uint8_t X_Byte = 0x00;  // Raw X-axis joystick value received over I2C
volatile uint8_t Y_Byte = 0x00;  // Raw Y-axis joystick value received over I2C
volatile uint8_t TsABXY = 0x00;  // Raw byte containing Trigger, A, B, X, Y button states from I2C
volatile uint8_t JButtons = 0x00;// Raw byte containing joystick button press states from I2C
volatile uint8_t TxY = 0x00;     // Translated Y-axis command index (maps joystick range to camera tilt command)
volatile uint8_t TxX = 0x00;     // Translated X-axis command index (maps joystick range to camera pan command)
volatile uint8_t TxTL = 0x00;    // Translated Left Trigger command index
volatile uint8_t TxTR = 0x00;    // Translated Right Trigger command index
volatile uint8_t TxA = 0x00;     // Translated A button command index
volatile uint8_t TxB = 0x00;     // Translated B button command index
volatile uint8_t TxBY = 0x00;    // Translated BY (X button, mapped to BY slot) command index
volatile uint8_t TxJ = 0x00;     // Translated joystick button command index
volatile uint8_t j = 0;          // I2C byte counter ? tracks which byte in the current I2C packet is being received
volatile uint8_t mux_select = 0x00; // Tracks current mux channel selection (0?3), output on PORTB lower 2 bits
volatile bool xy_last = 0;       // Edge-detect flag for the XY button ? prevents repeated mux increments while held


// --- Constant Command Tables ---

// 12-byte header prepended to all Pan/Tilt direction commands sent over UART
// This is the PTZ (Pan-Tilt-Zoom) protocol framing used by the camera
const uint8_t header_dir[12] = {
    0x55,0xAA,0x07,0x4D,0x00,0x01,0x00,0x98,0x00,0x47,0x20,0x00
};

// Lookup table for Pan/Tilt movement commands
// Each row corresponds to one direction/speed command
// Column [0] = command index used for lookup; columns [1?6] = payload bytes sent after header_dir
// Rows:  Up .2, Up 1, Up 5, Down .2, Down 1, Down 5,
//        Left .2, Left 1, Left 5, Right .2, Right 1, Right 5
const uint8_t cmd_table[12][7] = {
    {0x00,0x00,0x80,0xDD,0x7F,0x8B,0x0B},// Up .2 uses the header_dir
    {0x01,0x00,0x80,0x51,0x7F,0x4B,0x6F},// Up 1 uses the header_dir
    {0x02,0x00,0x80,0x97,0x7C,0xEA,0x7C},// Up 5 uses the header_dir
    {0x03,0x00,0x80,0x23,0x80,0xAB,0x0B},// Down .2 uses the header_dir
    {0x04,0x00,0x80,0xAF,0x80,0x6B,0x6F},// Down 1 uses the header_dir
    {0x05,0x00,0x80,0x69,0x83,0xCA,0x7C},// Down 5 uses the header_dir
    {0x06,0xDD,0x7F,0x00,0x80,0xC7,0x18},// Left .2 uses the header_dir
    {0x07,0x51,0x7F,0x00,0x80,0x57,0x32},// Left 1 uses the header_dir
    {0x08,0x97,0x7C,0x00,0x80,0xDF,0xFE},// Left 5 uses the header_dir
    {0x09,0x23,0x80,0x00,0x80,0x1F,0x19},// Right .2 uses the header_dir
    {0x0A,0xAF,0x80,0x00,0x80,0x8F,0x33},// Right 1 uses the header_dir
    {0x0B,0x69,0x83,0x00,0x80,0x07,0xFF},// Right 5 uses the header_dir
};

// Lookup table for button-triggered camera commands
// Each row corresponds to one button action
// Column [0] = command index used for lookup; columns [1?9] = payload bytes sent after header_static
// Rows: Zoom In, Zoom Out, Video On, Home, FFC/ADJ, Reset Camera
const uint8_t cmd_button_table [6][10] = {
    {0x00,0x5A,0x01,0x00,0x00,0x00,0x01,0x00,0xF3,0xD8}, //Zoom in uses normal header
    {0x01,0x5A,0xFF,0x00,0x00,0x00,0x01,0x00,0x2D,0xCD}, //Zoom out uses normal header
    {0x02,0x7C,0x00,0x00,0x00,0x00,0x00,0x00,0x70,0x9F}, // Video on uses normal header
    {0x03,0x47,0x4A,0x19,0xB8,0x8B,0x00,0x80,0x31,0x53}, // Home uses normal header
    {0x04,0x6D,0x01,0x03,0x00,0x00,0x00,0x00,0xA0,0xDB}, // FFC/ADJ uses normal header
    {0x05,0x47,0xFE,0x00,0x00,0x00,0x00,0x00,0xED,0x00}, // Reset Camera uses normal header
};

// 9-byte header prepended to all button-triggered camera commands sent over UART
// Shorter than header_dir ? used with the static button command table above
const uint8_t header_static[9] = {
    0x55,0xAA,0x07,0x4D,0x00,0x01,0x00,0x98,0x00
};


// --- UART Transmit Helper ---
// Sends a single byte over UART by waiting until the transmit register is empty,
// then loading the byte into the TX register to begin transmission
static void tx_uart(uint8_t byte){
    //PORTBbits.RB7 ^= 1;          // Debug toggle (commented out)
    while (!PIR1bits.TXIF);        // Spin-wait until TX buffer is ready to accept a new byte
    TX1REG = byte;                 // Load byte into UART transmit register ? hardware sends it automatically
}


// --- Button/Trigger Translation ---
// Decodes the TsABXY byte (received from controller over I2C) into individual
// command indices for each button/trigger, stored in their respective Tx variables.
// 0xFF is used as a sentinel meaning "no command / deadzone ? skip this input."
static void TranslateTABXY(uint8_t byte){

    // Bit 3 (0x08): X button pressed ? map to BY command slot (index 0x04 = Home)
    if (byte & 0x08){
        TxBY = 0x04;
    }
    else{
        TxBY=0xFF;  // Not pressed ? mark as inactive
    }

    // Bit 1 (0x02): B button pressed ? map to command index 0x02 (Video On)
    if (byte & 0x02){
        TxB=0x02;
    }
    else{
        TxB = 0xFF; // Not pressed ? mark as inactive
    }

    // Bit 0 (0x01): A button pressed ? map to command index 0x05 (Reset Camera)
    if (byte & 0x01){
        TxA = 0x05;
    }
    else{
        TxA = 0xFF; // Not pressed ? mark as inactive
    }

    // Bit 4 (0x10): Left Trigger pressed ? map to command index 0x01 (Zoom Out)
    if (byte & 0x10){
        TxTL = 0x01;
    }
    else {
        TxTL = 0xFF; // Not pressed ? mark as inactive
    }

    // Bit 5 (0x20): Right Trigger pressed ? map to command index 0x00 (Zoom In)
    if (byte & 0x20){
        TxTR = 0x00;
    }
    else{
        TxTR = 0xFF; // Not pressed ? mark as inactive
    }

    // Bit 2 (0x04): Y button ? used as a mux channel selector, NOT a camera command
    // xy_last provides edge detection so the channel only advances once per button press,
    // not continuously while the button is held
    if(byte & 0x04){
        if (!xy_last){              // Only act on the rising edge (first frame button is detected as pressed)
            mux_select ++;          // Advance to the next mux channel
            if (mux_select > 0x03){ // Wrap around after channel 3 back to channel 0
                mux_select = 0;
            }
            // Write the new mux channel index to the lower 2 bits of PORTB,
            // preserving the state of the upper 6 bits
            PORTB = (PORTB & 0xFC) | (mux_select & 0x03);
            xy_last = 1;            // Mark button as currently held to suppress further increments
        }
     }
     else{
            xy_last = 0;            // Button released ? reset edge-detect flag, ready for next press
      }
}


// --- Joystick Button Translation ---
// Decodes the JButtons byte into a camera command index for the joystick click button.
// Bit 0 (0x01): joystick button pressed ? map to command index 0x03 (Home position)
static void TranslateJoysticks(uint8_t byte){

    if (byte & 0x01){
        TxJ = 0x03;  // Joystick button pressed ? send Home command
    }
    else{
        TxJ = 0xFF;  // Not pressed ? mark as inactive
    }
}


// --- Y-Axis (Tilt) Translation ---
// Maps the raw 8-bit Y-axis joystick value (0x00?0xFF) to a camera tilt command index.
// The joystick center is approximately 0x80; values are divided into 8 zones:
//   Far up    ? fastest tilt up   (0x05)
//   Mid up    ? medium tilt up    (0x04)
//   Near up   ? slow tilt up      (0x03)
//   Center    ? deadzone          (0xFF = no command)
//   Near down ? slow tilt down    (0x00)
//   Mid down  ? medium tilt down  (0x01)
//   Far down  ? fastest tilt down (0x02)
static void TranslateY(uint8_t byte){

    if (byte <= 0x32){          // Far upward deflection ? fastest tilt up
        TxY = 0x05;
    }
    else if (byte <= 0x5A){     // Moderate upward deflection ? medium tilt up
        TxY = 0x04;
    }
    else if (byte <= 0x7B){     // Slight upward deflection ? slow tilt up
        TxY = 0x03;
    }
    else if (byte <= 0x88){     // Center zone upper half ? deadzone, no command
        TxY = 0xFF;
    }
    else if (byte <= 0x94){     // Center zone lower half ? deadzone, no command
        TxY = 0xFF;
    }
    else if (byte <= 0xB5){     // Slight downward deflection ? slow tilt down
        TxY = 0x00;
    }
    else if (byte <= 0xDD){     // Moderate downward deflection ? medium tilt down
        TxY = 0x01;
    }
    else{                       // Far downward deflection ? fastest tilt down
        TxY = 0x02;
    }
}


// --- X-Axis (Pan) Translation ---
// Maps the raw 8-bit X-axis joystick value (0x00?0xFF) to a camera pan command index.
// Mirror of TranslateY but for left/right pan movement:
//   Far left   ? fastest pan left  (0x08)
//   Mid left   ? medium pan left   (0x07)
//   Near left  ? slow pan left     (0x06)
//   Center     ? deadzone          (0xFF = no command)
//   Near right ? slow pan right    (0x09)
//   Mid right  ? medium pan right  (0x0A)
//   Far right  ? fastest pan right (0x0B)
static void TranslateX(uint8_t byte){

    if (byte <= 0x32){          // Far left deflection ? fastest pan left
        TxX = 0x08;
    }
    else if (byte <= 0x5A){     // Moderate left deflection ? medium pan left
        TxX = 0x07;
    }
    else if (byte <= 0x7B){     // Slight left deflection ? slow pan left
        TxX = 0x06;
    }
    else if (byte <= 0x88){     // Center zone upper half ? deadzone, no command
        TxX = 0xFF;
    }
    else if (byte <= 0x94){     // Center zone lower half ? deadzone, no command
        TxX = 0xFF;
    }
    else if (byte <= 0xB5){     // Slight right deflection ? slow pan right
        TxX = 0x09;
    }
    else if (byte <= 0xDD){     // Moderate right deflection ? medium pan right
        TxX = 0x0A;
    }
    else{                       // Far right deflection ? fastest pan right
        TxX = 0x0B;
    }
}

// --- Send Pan/Tilt Direction Command over UART ---
// Transmits a full camera movement command by first sending the 12-byte PTZ header,
// then sending bytes [1?6] of the matching row from cmd_table (skipping column [0],
// which is only the lookup index, not part of the wire protocol)
static void send_camera_command(uint8_t byte){
    uint8_t i;

    // Send the 12-byte direction header first (framing for PTZ commands)
    for ( i = 0; i < 12u; i++) {
        tx_uart(header_dir[i]);
    }

    // Send the 6 payload bytes from the command table row (columns 1?6)
    for ( i = 1; i < 7u; i++){
        tx_uart(cmd_table[byte][i]);
    }
}

// --- Send Button Command over UART ---
// Transmits a full camera button command by first sending the 9-byte static header,
// then sending bytes [1?9] of the matching row from cmd_button_table (skipping column [0])
static void send_camera_button(uint8_t byte){
    uint8_t i;

    // Send the 9-byte static header first (framing for button commands)
    for ( i = 0; i < 9u; i++){
        tx_uart(header_static[i]);
    }

    // Send the 9 payload bytes from the button table row (columns 1?9)
    for (i =1; i < 10u; i++){
        tx_uart(cmd_button_table[byte][i]);
    }
}

// --- Movement Command Dispatcher ---
// Looks up the given command index in cmd_table and sends the corresponding
// pan/tilt command over UART.
// If cmd == 0xFF (deadzone sentinel), the function returns immediately without sending anything.
static void lookup_and_send_move(uint8_t cmd){
    uint8_t i;
    if (cmd == 0xFF) return; // Deadzone ? joystick is centered, skip transmission
    // Search cmd_table for a row whose index byte (column 0) matches cmd
    for (i = 0; i < 12u; i++){
        if (cmd_table[i][0] == cmd){
            send_camera_command(i); // Found ? send the movement command at row i
            break;                  // Stop searching after the first match
        }
    }
}

// --- Button Command Dispatcher ---
// Looks up the given command index in cmd_button_table and sends the corresponding
// button command over UART.
// If cmd == 0xFF (inactive sentinel), the function returns immediately without sending anything.
static void lookup_and_send_buttons(uint8_t cmd){
    uint8_t i;
    if (cmd == 0xFF) return; // Button not pressed ? skip transmission
    // Search cmd_button_table for a row whose index byte (column 0) matches cmd
    for (i = 0; i < 6u; i ++){
        if (cmd_button_table[i][0] == cmd){
            send_camera_button(i); // Found ? send the button command at row i
            break;                 // Stop searching after the first match
        }
    }
}


// --- Interrupt Service Routine ---
// Handles all I2C (SSP1) receive events.
// The controller PIC sends a 5-byte I2C packet each cycle:
//   Byte 0: address byte (discarded)
//   Byte 1: Y-axis value
//   Byte 2: X-axis value
//   Byte 3: Trigger + ABXY button states
//   Byte 4: Joystick button states
// The variable j tracks which byte is currently being received.
void __interrupt() ISR(){

    // Check if the SSP1 (I2C) interrupt flag is set
    if (PIR1bits.SSP1IF){

        // --- Error Recovery ---
        // If an overflow or write collision occurred, clear the error flags,
        // flush the buffer, and reset the byte counter to resync the packet framing
        if (SSP1CON1bits.SSPOV || SSP1CON1bits.WCOL){
            SSP1CON1bits.SSPOV = 0;    // Clear overflow flag
            SSP1CON1bits.WCOL = 0;     // Clear write collision flag
            (void)SSP1BUF;             // Dummy read to flush the SSP buffer
            j = 0;                     // Reset packet byte counter
        }

        // --- Normal I2C Receive (Write from master: R_nW = 0) ---
        else if (SSP1STATbits.R_nW == 0){

            if (j == 0){
                // Byte 0: the I2C address byte ? discard it and release the clock
                (void)SSP1BUF;
                SSP1CON1bits.CKP = 1;  // Release clock stretch so master can send next byte
            }
            else if (j == 1){
                // Byte 1: Y-axis potentiometer value ? store it
                Y_Byte = SSP1BUF;
                SSP1CON1bits.CKP = 1;  // Release clock stretch
            }
            else if (j == 2){
                // Byte 2: X-axis potentiometer value ? store it
                X_Byte = SSP1BUF;
                SSP1CON1bits.CKP = 1;  // Release clock stretch
            }
            else if (j == 3){
                // Byte 3: Trigger and ABXY button states packed into one byte ? store it
                TsABXY = SSP1BUF;
                SSP1CON1bits.CKP = 1;  // Release clock stretch
            }
            else if (j == 4){
                // Byte 4: Joystick button states ? store it and signal main loop that packet is complete
                JButtons = SSP1BUF;
                rx_done = 1;           // Notify main loop a full packet is ready to process
                SSP1CON1bits.CKP = 0;  // Hold clock low ? main loop will release it after processing
            }

            // Advance byte counter, wrapping back to 0 after byte 4
            j = (j + 1) % 5;
        }
        else{
            // I2C read request from master (unexpected in this application) ? flush buffer and ignore
            (void)SSP1BUF;
        }
    }

    // Clear the SSP1 interrupt flag so the ISR can fire again on the next byte
    PIR1bits.SSP1IF = 0;
}


void main(){

    // --- Peripheral Initialization ---
    // Each Init function configures a specific hardware module as defined in Config.h
    InitOsc();   // Set up the oscillator (system clock frequency)
    InitOpt();   // Configure any option registers
    InitPIN();   // Set pin directions and analog/digital mode
    InitPORTA(); // Initialize PORTA outputs/inputs
    InitPORTB(); // Initialize PORTB (lower 2 bits used for mux channel select output)
    InitPORTC(); // Initialize PORTC (used for UART TX and I2C SDA/SCL)
    InitUART();  // Configure UART baud rate, TX enable
    InitI2C();   // Configure SSP1 in I2C slave mode, set slave address
    InitISR();   // Configure interrupt priorities and enable SSP1 interrupt

    // Enable Global Interrupts ? allows the ISR to fire on I2C events
    INTCONbits.GIE = 1;


    // --- Main Loop ---
    // Spins continuously waiting for the ISR to signal that a full I2C packet has arrived.
    // When rx_done is set, all four data bytes have been received and are ready to process.
    while (1){
        if (rx_done){

            // Step 1: Translate raw I2C values into camera command indices
            TranslateY(Y_Byte);         // Map Y-axis joystick value ? tilt command index (TxY)
            TranslateX(X_Byte);         // Map X-axis joystick value ? pan command index (TxX)
            TranslateTABXY(TsABXY);     // Decode button/trigger byte ? individual Tx command indices
            TranslateJoysticks(JButtons);// Decode joystick button byte ? joystick command index (TxJ)

            // Step 2: Dispatch movement commands over UART
            // Each call looks up the command index in the appropriate table and sends the
            // full framed UART packet; 0xFF indices are silently skipped (deadzone/not pressed)
            lookup_and_send_move(TxY);      // Send tilt (up/down) command if joystick is deflected
            lookup_and_send_move(TxX);      // Send pan (left/right) command if joystick is deflected

            // Step 3: Dispatch button commands over UART
            lookup_and_send_buttons(TxA);   // A button ? Reset Camera (if pressed)
            lookup_and_send_buttons(TxBY);  // X button (BY slot) ? Home position (if pressed)
            lookup_and_send_buttons(TxB);   // B button ? Video On (if pressed)
            lookup_and_send_buttons(TxTR);  // Right Trigger ? Zoom In (if pressed)
            lookup_and_send_buttons(TxTL);  // Left Trigger ? Zoom Out (if pressed)
            lookup_and_send_buttons(TxJ);   // Joystick button ? Home (if pressed)

            // Step 4: Clear the rx_done flag and release the I2C clock stretch
            // so the master PIC can begin sending the next packet
            rx_done = 0;
            SSP1CON1bits.CKP = 1;  // Release clock ? signals master that slave is ready for next transmission
        }
    }
}