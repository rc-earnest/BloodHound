/* 
 * File:   Config.h
 * Author: rudyd
 *
 * Created on March 12, 2026, 10:51 AM
 */

// Header guard ? prevents this file from being included more than once
// during compilation, avoiding duplicate definition errors
#ifndef CONFIG_H
#define CONFIG_H


// ============================================================
// PIC16F1788 Configuration Bit Settings
// These #pragma config statements are processed by the XC8
// compiler at build time and are burned into the PIC's
// configuration words during programming ? they are NOT
// runtime-changeable register writes.
// ============================================================

// --- CONFIG1 ---

#pragma config FOSC = INTOSC    // Use the internal oscillator as the system clock;
                                 // the CLKIN pin is freed for use as a general I/O pin

#pragma config WDTE = OFF       // Disable the Watchdog Timer ? the WDT will not
                                 // automatically reset the PIC if the firmware stalls

#pragma config PWRTE = OFF      // Disable the Power-up Timer ? the PIC will begin
                                 // executing immediately after VDD stabilizes

#pragma config MCLRE = ON       // The MCLR/VPP pin functions as the Master Clear reset input,
                                 // allowing external hardware or a programmer to reset the PIC

#pragma config CP = OFF         // Disable flash program memory code protection ?
                                 // the firmware can be read back by a programmer

#pragma config CPD = OFF        // Disable data memory (EEPROM) code protection ?
                                 // EEPROM contents can be read back by a programmer

#pragma config BOREN = OFF      // Disable Brown-out Reset ? the PIC will not automatically
                                 // reset if VDD drops below the brown-out threshold voltage

#pragma config CLKOUTEN = OFF   // Disable the CLKOUT function ? the pin that would output
                                 // the system clock is freed for use as a general I/O pin

#pragma config IESO = OFF       // Disable Internal/External Switchover mode ? the clock
                                 // source will not automatically switch between internal
                                 // and external oscillators at startup

#pragma config FCMEN = OFF      // Disable the Fail-Safe Clock Monitor ? the PIC will not
                                 // automatically switch to the internal oscillator if the
                                 // external clock fails


// --- CONFIG2 ---

#pragma config WRT = OFF        // Disable flash self-write protection ? firmware running
                                 // on the PIC is permitted to write to its own program memory

#pragma config VCAPEN = OFF     // Disable the internal voltage regulator capacitor function
                                 // on RA6 ? pin is freed for use as general I/O

#pragma config PLLEN = OFF      // Disable the 4x PLL ? the oscillator frequency is NOT
                                 // multiplied; system clock runs at the raw INTOSC frequency
                                 // (set to 32 MHz via OSCCON in InitOsc)

#pragma config STVREN = OFF     // Disable Stack Overflow/Underflow Reset ? a call stack
                                 // overflow or underflow will NOT trigger an automatic reset

#pragma config BORV = LO        // Set Brown-out Reset threshold to the low trip point ?
                                 // relevant only if BOREN is ever enabled

#pragma config LPBOR = OFF      // Disable Low Power Brown-out Reset ? the low-power BOR
                                 // circuit is not active during Sleep mode

#pragma config DEBUG = OFF      // Disable In-Circuit Debugger mode ? ICSPCLK and ICSPDAT
                                 // pins are freed for use as general purpose I/O pins

#pragma config LVP = OFF        // Disable Low-Voltage Programming ? a high voltage on
                                 // MCLR/VPP is required to enter programming mode,
                                 // preventing accidental reprogramming during normal operation


// ============================================================
// Includes, Type Definitions, and Function Prototypes
// ============================================================

// #pragma config statements should precede project file includes.
// Use project enums instead of #define for ON and OFF.
#include <xc.h>  // XC8 compiler header ? provides all PIC16F1788 register
                 // and bit-field definitions used throughout the project

// Additional #define statements will go below

// Type definition shorthand ? allows 'uchar' to be used in place of
// 'unsigned char' throughout the project for brevity
typedef unsigned char uchar;


// --- Function Prototypes ---
// Declares all hardware initialization functions defined in Config.c
// so they can be called from main.c and any other source file that
// includes this header

void InitOsc(void);   // Configure internal oscillator speed
void InitOpt(void);   // Configure option register (pull-ups, Timer0)
void InitPIN(void);   // Configure alternate pin function assignments
void InitPORTA(void); // Configure PORTA direction, analog/digital, pull-ups
void InitPORTB(void); // Configure PORTB direction, analog/digital, pull-ups
void InitPORTC(void); // Configure PORTC direction, pull-ups (UART TX, I2C)
void InitUART(void);  // Configure UART baud rate and transmitter settings
void InitI2C(void);   // Configure SSP1 as I2C slave with address and clock stretching
void InitISR(void);   // Configure and enable SSP1 interrupt for I2C receive


#endif  /* CONFIG_H */
// End of header guard ? closes the #ifndef CONFIG_H block at the top of the file