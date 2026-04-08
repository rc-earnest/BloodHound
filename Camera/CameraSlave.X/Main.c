/**Rudy Earnest
 RCET Capstone Project
 Spring 2026
 Camera I2C to UART communications*/

//This code takes the I2C from the controller pic and converts them to UART for
//the camera

//config sets up the PIC and 
#include "Config.h"
#include <xc.h>
#include <stdint.h>
#include <stdbool.h>


//Variable declarations for global purposes
volatile bool rx_done = 0;
volatile uint8_t X_Byte = 0x00;
volatile uint8_t Y_Byte = 0x00;
volatile uint8_t TsABXY = 0x00;
volatile uint8_t JButtons = 0x00;
volatile uint8_t TxY = 0x00;
volatile uint8_t TxX = 0x00;
volatile uint8_t TxTL = 0x00;
volatile uint8_t TxTR = 0x00;
volatile uint8_t TxA = 0x00;
volatile uint8_t TxB = 0x00;
volatile uint8_t TxBY = 0x00;
volatile uint8_t TxJ = 0x00;
volatile uint8_t j = 0;


const uint8_t header_dir[12] = { //header for PT instructions (PTZ)
    0x55,0xAA,0x07,0x4D,0x00,0x01,0x00,0x98,0x00,0x47,0x20,0x00
};


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

const uint8_t cmd_button_table [6][10] = {
    {0x00,0x5A,0x01,0x00,0x00,0x00,0x01,0x00,0xF3,0xD8}, //Zoom in uses normal header
    {0x01,0x5A,0xFF,0x00,0x00,0x00,0x01,0x00,0x2D,0xCD}, //Zoom out uses normal header
    {0x02,0x7C,0x00,0x00,0x00,0x00,0x00,0x00,0x70,0x9F}, // Video on uses normal header
    {0x03,0x47,0x4A,0x19,0xB8,0x8B,0x00,0x80,0x31,0x53}, // Home uses normal header
    {0x04,0x6D,0x01,0x03,0x00,0x00,0x00,0x00,0xA0,0xDB}, // FFC/ADJ uses normal header
    {0x05,0x47,0xFE,0x00,0x00,0x00,0x00,0x00,0xED,0x00}, // Reset Camera uses normal header
};


const uint8_t header_static[9] = { // header for everything
    0x55,0xAA,0x07,0x4D,0x00,0x01,0x00,0x98,0x00
};


static void tx_uart(uint8_t byte){ // TX over UART
    PORTBbits.RB7 ^= 1;
    while (!PIR1bits.TXIF);
    TX1REG = byte;
    
}


static void TranslateTABXY(uint8_t byte){
   
    if (byte & 0x08){
        TxBY = 0x04;
    }
    else{
        TxBY=0xFF;
    }
    if (byte & 0x02){
        TxB=0x02;
    }
    else{
        TxB = 0xFF;
    }
    if (byte & 0x01){
        TxA = 0x05;
    }
    else{
        TxA = 0xFF;
    }
    if (byte & 0x10){
        TxTL = 0x01;
    }
    else {
        TxTL = 0xFF;
    }
    if (byte & 0x20){
        TxTR = 0x00;
    }
    else{
        TxTR = 0xFF;
    }
    
}


static void TranslateJoysticks(uint8_t byte){
    
    if (byte & 0x01){
        TxJ = 0x03;
    }
    else{
        TxJ = 0xFF;
    }
    
}


static void TranslateY(uint8_t byte){
   
    if (byte <= 0x32){  // 0x00 to 0x32
        TxY = 0x05;
    }
    
    else if (byte <= 0x5A){ // 0x33 to 0x5A
        TxY = 0x04;
    }
    
    else if (byte <= 0x7B){ // 0x5B to 0x7B
        TxY = 0x03;
    }
    
    else if (byte <= 0x88){ // 0x7C to 0x88
        TxY = 0xFF;
    }
    
    else if (byte <= 0x94){ // 0x89 to 0x94
        TxY = 0xFF;
    }
    
    else if (byte <= 0xB5){ // 0x95 to 0xB5
        TxY = 0x00;
    }
    
    else if (byte <= 0xDD){ // 0xB6 to 0xDD
        TxY = 0x01;
    }
    else                  { // 0xDE to 0xFF
        TxY = 0x02;
    }
    
}


static void TranslateX(uint8_t byte){
    
    if (byte <= 0x32){  // 0x00 to 0x32
        TxX = 0x08;
    }
    
    else if (byte <= 0x5A){ // 0x33 to 0x5A
        TxX = 0x07;
    }
    
    else if (byte <= 0x7B){ // 0x5B to 0x7B
        TxX = 0x06;
    }
    
    else if (byte <= 0x88){ // 0x7C to 0x88
        TxX = 0xFF;
    }
    
    else if (byte <= 0x94){ // 0x89 to 0x94
        TxX = 0xFF;
    }
    
    else if (byte <= 0xB5){ // 0x95 to 0xB5
        TxX = 0x09;
    }
    
    else if (byte <= 0xDD){ // 0xB6 to 0xDD
        TxX = 0x0A;
    }
    else                  { // 0xDE to 0xFF
        TxX = 0x0B;
    }
    
}

static void send_camera_command(uint8_t byte){
    uint8_t i;
    
    for ( i = 0; i < 12u; i++) {
        tx_uart(header_dir[i]);
    }
    
    for ( i = 1; i < 7u; i++){
        tx_uart(cmd_table[byte][i]);
    }
    
}

static void send_camera_button(uint8_t byte){
    uint8_t i;
    for ( i = 0; i < 9u; i++){
        tx_uart(header_static[i]);
    }
    
    for (i =1; i < 10u; i++){
        tx_uart(cmd_button_table[byte][i]);
    }
}

static void lookup_and_send_move(uint8_t cmd){
    uint8_t i;
    if (cmd == 0xFF) return; // deadzone, don't send anything
    for (i = 0; i < 12u; i++){
        if (cmd_table[i][0] == cmd){
            send_camera_command(i);
            break;
        }
    }
}

static void lookup_and_send_buttons(uint8_t cmd){
    uint8_t i;
    if (cmd == 0xFF) return;
    for (i = 0; i < 6u; i ++){
        if (cmd_button_table[i][0] == cmd){
            send_camera_button(i);
            break;
        }
    }
}


void __interrupt() ISR(){
    
    if (PIR1bits.SSP1IF){
        
        if (SSP1CON1bits.SSPOV || SSP1CON1bits.WCOL){
            SSP1CON1bits.SSPOV = 0;
            SSP1CON1bits.WCOL = 0;
            (void)SSP1BUF; // flush
            j = 0;
        }      
        
        else if (SSP1STATbits.R_nW == 0){ //First byte should be the Y axis pot
            if (j == 0){
                (void)SSP1BUF;
                SSP1CON1bits.CKP = 1;
            }
            else if (j == 1){
                Y_Byte = SSP1BUF;
                SSP1CON1bits.CKP = 1;
            }
            else if (j == 2){ // Second should be the X axis pot
                X_Byte = SSP1BUF;
                SSP1CON1bits.CKP = 1;
            }
            else if (j == 3){ // Third should contain the Triggers and ABXY buttons
                TsABXY = SSP1BUF;
                SSP1CON1bits.CKP = 1;
            }
            else if (j == 4){ // Last should be the joystick buttons
                JButtons = SSP1BUF;
                rx_done = 1;
                SSP1CON1bits.CKP = 0;
            }
            j = (j + 1) % 5;
        }
        else{
            (void)SSP1BUF;
        }
    }
    PIR1bits.SSP1IF = 0;
    
}


void main(){
    //inits
    InitOsc();
    InitOpt();
    InitPIN();
    InitPORTA();
    InitPORTB();
    InitPORTC();
    InitUART();
    InitI2C();
    InitISR();
    
    //init gie
    INTCONbits.GIE = 1;
    
    
    while (1){
        if (rx_done){
            TranslateY(Y_Byte);
            TranslateX(X_Byte);
            TranslateTABXY(TsABXY);
            TranslateJoysticks(JButtons);
            lookup_and_send_move(TxY);
            lookup_and_send_move(TxX);
            lookup_and_send_buttons(TxA);
            lookup_and_send_buttons(TxBY);
            lookup_and_send_buttons(TxB);
            lookup_and_send_buttons(TxTR);
            lookup_and_send_buttons(TxTL);
            lookup_and_send_buttons(TxJ);
            rx_done = 0;
            SSP1CON1bits.CKP = 1;
        }
    }
}
