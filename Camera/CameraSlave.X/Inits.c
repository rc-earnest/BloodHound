//This sets up the pic in accordance to what is needed
#include "Config.h"
#include <xc.h>       // XC8 compiler header for PIC register definitions
#include <stdint.h>   // Provides fixed-width integer types (uint8_t, etc.)
#include <stdbool.h>  // Provides bool, true, false


// --- Oscillator Initialization ---
// Configures the system clock source and speed.
void InitOsc(){
    OSCCON = 0XF8;   // Set internal oscillator to 32 MHz (bits 6:3 = 1111), 
                     // select internal oscillator block as clock source
    CLKRCON = 0X00;  // Disable the clock reference output ? not needed for this application
}


// --- Option Register Initialization ---
// Configures global timer/pull-up options.
void InitOpt(){
    OPTION_REG = 0x00; // Enable weak pull-ups globally (bit 7 = 0),
                       // set Timer0 to use internal clock with 1:2 prescaler
}


// --- Pin Alternate Function Initialization ---
// Controls which pins are assigned to peripheral functions (UART, I2C, etc.).
void InitPIN(){
    //APFCON1 = 0x18;  // Previous alternate function mapping (commented out/replaced)
    APFCON1 = 0x00;    // Use default pin assignments for all peripherals on APFCON1
    APFCON2 = 0x00;    // Use default pin assignments for all peripherals on APFCON2
}


// --- PORTA Initialization ---
// PORTA is used only as digital inputs on this PIC (no analog or output function needed).
void InitPORTA(){
    TRISA = 0xFF;      // Set all PORTA pins as inputs (1 = input)
    ANSELA = 0x00;     // Disable analog input on all PORTA pins ? use as digital
    WPUA = 0x00;       // Disable all weak pull-ups on PORTA
    SLRCONA = 0x00;    // Disable slew rate limiting on PORTA (maximum output speed)
    INLVLA = 0x00;     // Set input threshold to TTL level on PORTA
}


// --- PORTB Initialization ---
// PORTB lower 2 bits (RB0, RB1) are outputs used for the mux channel select signal.
// Upper bits are configured as inputs.
void InitPORTB(){
    TRISB = 0x3C;      // 0011 1100 ? RB0, RB1, RB6, RB7 are outputs; RB2?RB5 are inputs
    ANSELB = 0x00;     // Disable analog input on all PORTB pins ? use as digital
    WPUB = 0x00;       // Disable all weak pull-ups on PORTB
    SLRCONB = 0x00;    // Disable slew rate limiting on PORTB
    INLVLB = 0x00;     // Set input threshold to TTL level on PORTB
}


// --- PORTC Initialization ---
// PORTC carries the UART TX line (RC6) and I2C SDA/SCL lines (RC3, RC4).
void InitPORTC(){
    TRISC = 0xBF;      // 1011 1111 ? RC6 (UART TX) set as output; all others set as inputs
    WPUC = 0x00;       // Disable all weak pull-ups on PORTC
    SLRCONC = 0x00;    // Disable slew rate limiting on PORTC
    INLVLC = 0x00;     // Set input threshold to TTL level on PORTC
}


// --- UART Initialization ---
// Configures the hardware UART for asynchronous serial transmission to the camera.
void InitUART(){
    TX1STA = 0x24;   // Enable transmitter (TXEN = 1), select asynchronous mode (SYNC = 0),
                     // enable high-speed baud rate mode (BRGH = 1)
    RC1STA = 0x80;   // Enable the serial port (SPEN = 1); receiver left disabled (CREN = 0)
    BAUD1CON = 0x08; // Enable 16-bit baud rate generator (BRG16 = 1) for finer baud resolution
    SP1BRGL = 0x8A;  // Lower byte of baud rate divisor ? combined with SP1BRGH, sets baud to
    SP1BRGH = 0x00;  // Upper byte of baud rate divisor ? 9600 baud at 32 MHz with BRGH=1, BRG16=1
                     // Formula: Fosc / (4 * (SPBRG + 1)) = 32000000 / (4 * 139) ? 57,554 baud
                     // (Exact target baud rate determined by camera protocol requirements)
}


// --- I2C Slave Initialization ---
// Configures the SSP1 module as an I2C slave to receive data from the controller PIC.
void InitI2C(){
    SSP1STAT = 0x80;       // Enable slew rate control for standard speed I2C (SMP = 1)
    SSP1CON1 = 0x26;       // Enable SSP module (SSPEN = 1), set mode to I2C Slave with
                           // 7-bit address (SSPM = 0110)
    SSP1CON2 = 0x01;       // Enable clock stretching (SEN = 1) ? slave will hold SCL low
                           // after each byte until CKP is released by firmware
    SSP1ADD = 0x22 << 1;   // Set this slave's 7-bit I2C address to 0x22; shifted left by 1
                           // because the register stores the address in bits [7:1]
}


// --- Interrupt Initialization ---
// Enables the specific interrupt sources needed for I2C receive operation.
void InitISR(){
    INTCON = 0x40;  // Enable peripheral interrupts (PEIE = 1); Global interrupt enable (GIE)
                    // is left off here ? it is turned on explicitly in main() after all init is complete
    PIE1 = 0x08;    // Enable SSP1 (I2C) interrupt (SSP1IE = 1, bit 3) ? fires each time
                    // a byte is received over I2C
    PIE2 = 0x00;    // Disable all peripheral interrupts in PIE2 (not used in this application)
    PIE3 = 0x00;    // Disable all peripheral interrupts in PIE3 (not used in this application)
}