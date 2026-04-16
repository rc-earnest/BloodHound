//This sets up the pic in accordance to what is needed

#include "Config.h"
#include <xc.h>
#include <stdint.h>
#include <stdbool.h>

void InitOsc(){
    OSCCON = 0XF8;
    CLKRCON = 0X00;
}

void InitOpt(){
    OPTION_REG = 0x00;
}

void InitPIN(){
    //APFCON1 = 0x18;
    APFCON1 = 0x00;
    APFCON2 = 0x00;
}

void InitPORTA(){
    TRISA = 0xFF;
    ANSELA = 0x00;
    WPUA = 0x00;
    SLRCONA = 0x00;
    INLVLA = 0x00;
}

void InitPORTB(){
    TRISB = 0x3C;
    ANSELB = 0x00;
    WPUB = 0x00;
    SLRCONB = 0x00;
    INLVLB = 0x00;
}

void InitPORTC(){
    TRISC = 0xBF;
    WPUC = 0x00;
    SLRCONC = 0x00;
    INLVLC = 0x00;
}

void InitUART(){
    TX1STA = 0x24;
    RC1STA = 0x80;
    BAUD1CON = 0x08;
    SP1BRGL = 0x8A;
    SP1BRGH = 0x00;
}

void InitI2C(){
    SSP1STAT = 0x80;
    SSP1CON1 = 0x26;
    SSP1CON2 = 0x01;
    SSP1ADD = 0x22 << 1;
}

void InitISR(){
    INTCON = 0x40;
    PIE1 = 0x08;
    PIE2 = 0x00;
    PIE3 = 0x00;
}