; CONFIG1
  CONFIG  FOSC = INTOSC         ; Oscillator Selection (INTOSC oscillator: I/O function on CLKIN pin)
  CONFIG  WDTE = OFF            ; Watchdog Timer Enable (WDT disabled)
  CONFIG  PWRTE = ON            ; Power-up Timer Enable (PWRT enabled)
  CONFIG  MCLRE = ON            ; MCLR Pin Function Select (MCLR/VPP pin function is MCLR)
  CONFIG  CP = OFF              ; Flash Program Memory Code Protection (Program memory code protection is disabled)
  CONFIG  CPD = OFF             ; Data Memory Code Protection (Data memory code protection is disabled)
  CONFIG  BOREN = ON            ; Brown-out Reset Enable (Brown-out Reset enabled)
  CONFIG  CLKOUTEN = OFF        ; Clock Out Enable (CLKOUT function is disabled. I/O or oscillator function on the CLKOUT pin)
  CONFIG  IESO = OFF            ; Internal/External Switchover (Internal/External Switchover mode is disabled)
  CONFIG  FCMEN = OFF           ; Fail-Safe Clock Monitor Enable (Fail-Safe Clock Monitor is disabled)

; CONFIG2
  CONFIG  WRT = OFF             ; Flash Memory Self-Write Protection (Write protection off)
  CONFIG  VCAPEN = OFF          ; Voltage Regulator Capacitor Enable bit (Vcap functionality is disabled on RA6.)
  CONFIG  PLLEN = ON            ; PLL Enable (4x PLL enabled)
  CONFIG  STVREN = ON           ; Stack Overflow/Underflow Reset Enable (Stack Overflow or Underflow will cause a Reset)
  CONFIG  BORV = LO             ; Brown-out Reset Voltage Selection (Brown-out Reset Voltage (Vbor), low trip point selected.)
  CONFIG  LPBOR = OFF           ; Low Power Brown-Out Reset Enable Bit (Low power brown-out is disabled)
  CONFIG  DEBUG = OFF           ; In-Circuit Debugger Mode (In-Circuit Debugger disabled, ICSPCLK and ICSPDAT are general purpose I/O pins)
  CONFIG  LVP = OFF             ; Low-Voltage Programming Enable (High-voltage on MCLR/VPP must be used for programming)
// config statements should precede project file includes.
#include <xc.inc>

  
  ;Baud Rate 9604 @32MHz =, sync = 0, brgh = 1, brg16 = 1, spbrg = 832 in decimal
  ;tmr1 overflow to turn on rx reception
  ;tmr1 prescale at 8, with a built in delay loop of 15 to account for about 1 sec
  ;rx will only store data once the handshake is locked in, and it will only store the latitude and longitude data for now
  ;a dummy read for the data that I don't need will be enabled, and rx reception will be disabled when the end message is sent
  
;Reset vector
PSECT resetVect,class=CODE,delta=2  ; address 0000h -presetVect=0000h
GOTO Setup
  ;-Wl,-presetVect=0000h,-pisrVect=0004h,-code=0008h  
;ISR vector
PSECT isrVect,class=CODE,delta=2  ; address 0004h -pisrVect=0004h
GOTO InterruptHandler
PSECT code,class=CODE,delta=2  ; address 0008h -code=0008h
;setup
Setup:
    ;***Register Set up***
    DATA_FLAG	EQU 0x70		;Set up necessary registers
    LAT_COUNT	EQU 0x71
    LONG_COUNT	EQU 0x72
    END_1	EQU 0x73
    Delay	EQU 0x74
    DATA_BUFFER	EQU 0x75
    W_TEMP	EQU 0x76
    STATUS_TEMP	EQU 0x77
    FLAGS	EQU 0x78
    LAT_1	EQU 0x20
    LAT_2	EQU 0x21
    LAT_3	EQU 0x22
    LAT_4	EQU 0x23
    LAT_5	EQU 0x24
    LAT_6	EQU 0x25
    LAT_7	EQU 0x26
    LAT_8	EQU 0x27
    LAT_9	EQU 0x28
    LAT_10	EQU 0x29
    LAT_11	EQU 0x2A
    LAT_12	EQU 0x2B
    LAT_NS	EQU 0x2C
    LONG_1	EQU 0x2D
    LONG_2	EQU 0x2E
    LONG_3	EQU 0x2F
    LONG_4	EQU 0x30
    LONG_5	EQU 0x31
    LONG_6	EQU 0x32
    LONG_7	EQU 0x33
    LONG_8	EQU 0x34
    LONG_9	EQU 0x35
    LONG_10	EQU 0x36
    LONG_11	EQU 0x37
    LONG_12	EQU 0x38
    LONG_13	EQU 0x39
    LONG_EW	EQU 0x3A
    ;***Oscillator Set up****
    BANKSEL	OSCCON
    MOVLW	0xF0
    MOVWF	OSCCON			;Set Internal Oscilator to 32Mhz
    
    BANKSEL	OSCTUNE
    MOVLW	0x1F
    MOVWF	OSCTUNE

    BANKSEL	CLKRCON
    MOVLW	0x00
    MOVWF	CLKRCON			;Disable Output CLock Reference
 
    BANKSEL	OSCSTAT
    BTFSS	OSCSTAT,4
    GOTO	$-1
    BTFSS	OSCSTAT,6
    GOTO	$-1
    
 
;*** SET OPTION_REG: ****
    BANKSEL	OPTION_REG
    CLRF	OPTION_REG		;Weak Pull Up Disabled, Interrupt Edge Selection, Timer Clock Set-Up
    
    
;*** SET CCPXCON REG: **
    BANKSEL	CCP1CON
    CLRF	CCP1CON			;DISABLE PWM & CCP
    
    BANKSEL	CCP2CON
    CLRF	CCP2CON
    
    BANKSEL	CCP3CON
    CLRF	CCP3CON
;*** TIMER 1 SETUP *****
    BANKSEL	T1CON
    CLRF	T1CON			;clears controls
    MOVLW	0x31			;should run at about 1 sec
    MOVWF	T1CON			;Turns on tmr1 and sets prescale to 1:8 with the instruction clock
    
    ;*** PORT A SETUP ****
    BANKSEL	ANSELA
    CLRF	ANSELA			;Disable Analog Input
    
    BANKSEL	WPUA
    CLRF	WPUA			;Disable Weak Pull Ups
    
    BANKSEL	ODCONA
    CLRF	ODCONA			;Disable Open Drain
    
    BANKSEL	SLRCONA
    CLRF	SLRCONA			;Disable Slew Rate Limit
    
    BANKSEL	INLVLA
    MOVLW	0xFF
    MOVWF	INLVLA			;Set Input Threshold Voltage to CMOS Levels
    
    BANKSEL	LATA
    MOVLW	0xFF
    MOVWF	LATA			;Clear Input Latches
    
    BANKSEL	TRISA
    MOVLW	0x00
    MOVWF	TRISA 			;SET Port A as Output
    
    BANKSEL	PORTA
    MOVLW	0x00
    MOVWF	PORTA			;Initialize with Port A all low
    
;*** PORT B SETUP **** 
    BANKSEL	ANSELB
    CLRF	ANSELB			;Disable Analog Input
    
    BANKSEL	WPUB
    CLRF	WPUB			;Disable Weak Pull Ups
    
    BANKSEL	ODCONB
    CLRF	ODCONB			;Disable Open Drain
    
    BANKSEL	SLRCONB
    CLRF	SLRCONB			;Disable Slew Rate Limit
    
    BANKSEL	INLVLB
    MOVLW	0xFF
    MOVWF	INLVLB			;Set Input Threshold Voltage to CMOS Levels
    
    BANKSEL	LATB
    CLRF	LATB			;Clear Input Latches
    
    BANKSEL	TRISB
    MOVLW	0xFF
    MOVWF	TRISB 			;SET Port B as Inputs
    
;*** PORT C SETUP **** 
    BANKSEL	ANSELC
    CLRF	ANSELC			;Disable Analog Input
    
    BANKSEL	WPUC
    CLRF	WPUC			;Disable Weak Pull Ups
    
    BANKSEL	ODCONC
    CLRF	ODCONC			;Disable Open Drain
    
    BANKSEL	SLRCONC
    CLRF	SLRCONC			;Disable Slew Rate Limit
    
    BANKSEL	INLVLC
    MOVLW	0xFF
    MOVWF	INLVLC			;Set Input Threshold Voltage to CMOS Levels
    
    BANKSEL	LATC
    CLRF	LATC			;Clear Input Latches
    
    BANKSEL	TRISC
    MOVLW	0xFF
    MOVWF	TRISC 			;SET Port C as Slave Inputs and Rx inputs
    
    BANKSEL	PORTC
    BSF		PORTC,3
    BSF		PORTC,4
    BSF		PORTC,7
    
;*** PORT E SETUP ****
;28 Pin Package Does Not Have Port E
    
    
;*** Interrupt Set-Up : ****
    BANKSEL	INTCON
    MOVLW	0x40			;Enable Peripheral Interrupts (Wait On Global)
    MOVWF	INTCON
    
    BANKSEL	PIE1
    MOVLW	0x21
    MOVWF	PIE1			;Enable UART and Timer 1 Interrupts
 
    BANKSEL	PIE2
    MOVLW	0x00
    MOVWF	PIE2			;Disable Interrupts
    
    BANKSEL	PIE3
    BCF		PIE3, 4			;Disable CCP3 Interrupt
    
    BANKSEL	PIE4
    MOVLW	0x00
    MOVWF	PIE4			;Disable Interrupts
    
    ;*** UART Set Up: *****
    BANKSEL	TX1STA
    MOVLW	0x06
    MOVWF	TX1STA			;Async, 8 Bit Tx, No Break Char, BRGH High (Wait On enable)
    
    BANKSEL	RC1STA
    MOVLW	0x90
    MOVWF	RC1STA			;Serial Port Enable, 8 Bit Rx, Disable Adress Selection (Wait for Cont. Rx Enable)
    
    BANKSEL	RC1REG
    MOVF	RC1REG, W		; dummy read
    
    BANKSEL	BAUD1CON
    MOVLW	0x08
    MOVWF	BAUD1CON		;Tx Non-Inverted, Baud Rate Gen 16 Bit, Auto Baud Detect Off
    
    BANKSEL	SP1BRGL
    MOVLW	0x40
    MOVWF	SP1BRGL			
    
    BANKSEL	SP1BRGH
    MOVLW	0x03
    MOVWF	SP1BRGH			;Set Baud Rate to 9600  ((32MHz/9600)/4) - 1 = 832 
    
    ;***Pin Configuration***
    BANKSEL	APFCON1
    MOVLW	0x00
    MOVWF	APFCON1
    
    MOVLW	0x00
    MOVWF	FLAGS
    MOVWF	DATA_FLAG
    MOVWF	LAT_COUNT
    MOVWF	LONG_COUNT
    MOVWF	END_1
    MOVWF	DATA_BUFFER
    BANKSEL	TMR1H
    MOVWF	TMR1H
    BANKSEL	TMR1L
    MOVWF	TMR1L
    MOVLW	0x10
    MOVWF	Delay
    BANKSEL	INTCON
    BSF		INTCON,7		;sets global interrupts
    GOTO	Main
  Main:
    BTFSS	END_1,7
    GOTO	Main
    BTFSS	FLAGS,0
    GOTO	Main			;main loop waits
    
    BCF		FLAGS,0
    CALL	PARSER
    GOTO	Main
 
;Subroutines
    
  PARSER:
    MOVF	DATA_BUFFER,W
    XORLW	0x00			;checks for end data 
    BTFSC	STATUS,2
    GOTO	UART_RESET
    BTFSC	FLAGS,1
    GOTO	G1_TEST
    MOVF	DATA_BUFFER,W
    XORLW	0x24			;checks for handshake 
    BTFSS	STATUS,2
    RETURN
    BSF		FLAGS,1
    BANKSEL	PORTA
    BSF		PORTA,0
    RETURN
  G1_TEST:
    BTFSC	FLAGS,2
    GOTO	P_TEST
    MOVF	DATA_BUFFER,W
    XORLW	0x47			;checks for handshake in case of error
    BTFSS	STATUS,2
    RETURN
    BSF		FLAGS,2
    RETURN
  P_TEST:
    BTFSC	FLAGS,3
    GOTO	G2_TEST
    MOVF	DATA_BUFFER,W
    XORLW	0x50			;checks for handshake in case of error
    BTFSS	STATUS,2
    RETURN
    BSF		FLAGS,3
    RETURN
  G2_TEST:
    BTFSC	FLAGS,4
    GOTO	G3_TEST
    MOVF	DATA_BUFFER,W
    XORLW	0x47			;checks for handshake in case of error
    BTFSS	STATUS,2
    RETURN
    BSF		FLAGS,4
    RETURN
  G3_TEST:
    BTFSC	FLAGS,5
    GOTO	A_TEST
    MOVF	DATA_BUFFER,W
    XORLW	0x53			;checks for handshake in case of error
    BTFSS	STATUS,2
    RETURN
    BSF		FLAGS,5
    RETURN
  A_TEST:
    BTFSC	FLAGS,6
    GOTO	U_TEST
    MOVF	DATA_BUFFER,W
    XORLW	0x41			;checks for handshake in case of error
    BTFSS	STATUS,2
    RETURN
    BSF		FLAGS,6
    RETURN
  U_TEST:
    BTFSC	FLAGS,7
    GOTO	DATA_PARSE
    MOVF	DATA_BUFFER,W
    XORLW	0x2C			;checks for handshake in case of error
    BTFSS	STATUS,2
    RETURN
    BSF		FLAGS,7
    RETURN
   
  DATA_PARSE:
    BTFSS	DATA_FLAG,0
    CALL	LAT_LOG
    BTFSS	DATA_FLAG,1
    CALL	LONG_LOG
    BTFSS	DATA_FLAG,2
    CALL	DATA_ENDCHECK_1
    BTFSS	DATA_FLAG,3
    CALL	DATA_ENDCHECK_2
    
    RETURN
  TMR1_Overflow:
    BCF		PIR1,0
    MOVLW	0x00
    BANKSEL	TMR1H
    MOVWF	TMR1H
    MOVLW	0x00
    BANKSEL	TMR1L
    MOVWF	TMR1L
    DECFSZ	Delay			;delays tmr1 for about 1 sec
    GOTO	LeaveISR 
    MOVLW	0x10			;reloads 1 sec for delay
    MOVWF	Delay
    BSF		END_1,7
    GOTO	LeaveISR
  
  HANDSHAKE_TEST:
    
    BANKSEL	RC1STA
    BTFSC	RC1STA,1			;checks for overrun, skips if clear
    GOTO	CLEAR_OVERRUN
    
    BTFSC	RC1STA,2			;checks for framing error, skips if clear
    GOTO	DISCARD_BYTE
    
    BANKSEL	RC1REG
    MOVF	RC1REG,W			;pulls data from rc register
    MOVWF	DATA_BUFFER		;loads data into buffer as a precaution
    BSF		FLAGS,0
    GOTO	LeaveISR
    
    
  CLEAR_OVERRUN:
    BCF		RC1STA,4
    BSF		RC1STA,4
    MOVF	RC1REG,0			;clears rx register if there is an overrun
    GOTO	LeaveISR
    
  DISCARD_BYTE:
    MOVF	RC1REG,0			;clears rx register if there was a framing error
    GOTO	LeaveISR
    
  LAT_LOG:
    BANKSEL	LAT_1
    MOVF	DATA_BUFFER,W
    XORLW	0x2C
    BTFSC	STATUS,2 
    GOTO	DATA_CLEAR
    INCF	LAT_COUNT
    MOVF	LAT_COUNT,W
    ADDWF	PCL,1
    RETURN
    GOTO	LAT_1_LOG
    GOTO	LAT_2_LOG
    GOTO	LAT_3_LOG
    GOTO	LAT_4_LOG
    GOTO	LAT_5_LOG
    GOTO	LAT_6_LOG
    GOTO	LAT_7_LOG
    GOTO	LAT_8_LOG
    GOTO	LAT_9_LOG
    GOTO	LAT_10_LOG
    GOTO	LAT_11_LOG
    GOTO	LAT_12_LOG
    GOTO	LAT_INDC
    
  LAT_1_LOG:
    BANKSEL	LAT_1
    MOVF	DATA_BUFFER,W
    MOVWF	LAT_1
    GOTO	DATA_CLEAR
    
  LAT_2_LOG:
    BANKSEL	LAT_2
    MOVF	DATA_BUFFER,W
    MOVWF	LAT_2
    GOTO	DATA_CLEAR
    
  LAT_3_LOG:
    BANKSEL	LAT_3
    MOVF	DATA_BUFFER,W
    MOVWF	LAT_3
    GOTO	DATA_CLEAR
    
  LAT_4_LOG:
    BANKSEL	LAT_4
    MOVF	DATA_BUFFER,W
    MOVWF	LAT_4
    GOTO	DATA_CLEAR
    
  LAT_5_LOG:
    BANKSEL	LAT_5
    MOVF	DATA_BUFFER,W
    MOVWF	LAT_5
    GOTO	DATA_CLEAR
    
  LAT_6_LOG:
    BANKSEL	LAT_6
    MOVF	DATA_BUFFER,W
    MOVWF	LAT_6
    GOTO	DATA_CLEAR
    
  LAT_7_LOG:
    BANKSEL	LAT_7
    MOVF	DATA_BUFFER,W
    MOVWF	LAT_7
    GOTO	DATA_CLEAR
    
  LAT_8_LOG:
    BANKSEL	LAT_8
    MOVF	DATA_BUFFER,W
    MOVWF	LAT_8
    GOTO	DATA_CLEAR
    
  LAT_9_LOG:
    BANKSEL	LAT_9
    MOVF	DATA_BUFFER,W
    MOVWF	LAT_9
    GOTO	DATA_CLEAR
    
  LAT_10_LOG:
    BANKSEL	LAT_10
    MOVF	DATA_BUFFER,W
    MOVWF	LAT_10
    GOTO	DATA_CLEAR
    
  LAT_11_LOG:
    BANKSEL	LAT_11
    MOVF	DATA_BUFFER,W
    MOVWF	LAT_11
    GOTO	DATA_CLEAR
    
  LAT_12_LOG:
    BANKSEL	LAT_12
    MOVF	DATA_BUFFER,W
    MOVWF	LAT_12
    GOTO	DATA_CLEAR
    
  LAT_INDC:
    BANKSEL	LAT_NS
    MOVF	DATA_BUFFER,W
    MOVWF	LAT_NS
    CLRF	LAT_COUNT
    BSF		DATA_FLAG,0		;sets LAT flag
    GOTO	DATA_CLEAR
    
  LONG_LOG:
    BANKSEL	LONG_1
    MOVF	DATA_BUFFER,W
    XORLW	0x2C
    BTFSC	STATUS,2  
    GOTO	DATA_CLEAR
    INCF	LONG_COUNT
    MOVF	LONG_COUNT,W
    ADDWF	PCL,1
    RETURN
    GOTO	LONG_1_LOG
    GOTO	LONG_2_LOG
    GOTO	LONG_3_LOG
    GOTO	LONG_4_LOG
    GOTO	LONG_5_LOG
    GOTO	LONG_6_LOG
    GOTO	LONG_7_LOG
    GOTO	LONG_8_LOG
    GOTO	LONG_9_LOG
    GOTO	LONG_10_LOG
    GOTO	LONG_11_LOG
    GOTO	LONG_12_LOG
    GOTO	LONG_13_LOG
    GOTO	LONG_INDC

    
  LONG_1_LOG:
    BANKSEL	LONG_1
    MOVF	DATA_BUFFER,W
    MOVWF	LONG_1
    GOTO	DATA_CLEAR
    
  LONG_2_LOG:
    BANKSEL	LONG_2
    MOVF	DATA_BUFFER,W
    MOVWF	LONG_2
    GOTO	DATA_CLEAR
    
  LONG_3_LOG:
    BANKSEL	LONG_3
    MOVF	DATA_BUFFER,W
    MOVWF	LONG_3
    GOTO	DATA_CLEAR
    
  LONG_4_LOG:
    BANKSEL	LONG_4
    MOVF	DATA_BUFFER,W
    MOVWF	LONG_4
    GOTO	DATA_CLEAR
    
  LONG_5_LOG:
    BANKSEL	LONG_5
    MOVF	DATA_BUFFER,W
    MOVWF	LONG_5
    GOTO	DATA_CLEAR
    
  LONG_6_LOG:
    BANKSEL	LONG_6
    MOVF	DATA_BUFFER,W
    MOVWF	LONG_6
    GOTO	DATA_CLEAR
    
  LONG_7_LOG:
    BANKSEL	LONG_7
    MOVF	DATA_BUFFER,W
    MOVWF	LONG_7
    GOTO	DATA_CLEAR
    
  LONG_8_LOG:
    BANKSEL	LONG_8
    MOVF	DATA_BUFFER,W
    MOVWF	LONG_8
    GOTO	DATA_CLEAR
    
  LONG_9_LOG:
    BANKSEL	LONG_9
    MOVF	DATA_BUFFER,W
    MOVWF	LONG_9
    GOTO	DATA_CLEAR
    
  LONG_10_LOG:
    BANKSEL	LONG_10
    MOVF	DATA_BUFFER,W
    MOVWF	LONG_10
    GOTO	DATA_CLEAR
    
  LONG_11_LOG:
    BANKSEL	LONG_11
    MOVF	DATA_BUFFER,W
    MOVWF	LONG_11
    GOTO	DATA_CLEAR
    
  LONG_12_LOG:
    BANKSEL	LONG_12
    MOVF	DATA_BUFFER,W
    MOVWF	LONG_12
    GOTO	DATA_CLEAR
    
  LONG_13_LOG:
    BANKSEL	LONG_13
    MOVF	DATA_BUFFER,W
    MOVWF	LONG_13
    GOTO	DATA_CLEAR
    
  LONG_INDC:
    BANKSEL	LONG_EW
    MOVF	DATA_BUFFER,W
    MOVWF	LONG_EW
    CLRF	LONG_COUNT
    BSF		DATA_FLAG,1		;sets LONG flag
    GOTO	DATA_CLEAR
    
  DATA_CLEAR:
    RETURN    
    
  DATA_ENDCHECK_1:
    MOVF	DATA_BUFFER,W
    XORLW	0x0D
    BTFSC	STATUS,2 
    BSF		DATA_FLAG,2			;sets end start flag
    GOTO	DATA_CLEAR
    
  DATA_ENDCHECK_2:
    MOVF	DATA_BUFFER,W
    XORLW	0x0A
    BTFSS	STATUS,2 
    GOTO	DATA_CLEAR
    CLRF	DATA_FLAG
    CLRF	FLAGS
    CLRF	END_1
    
    BANKSEL	PORTA
    BCF		PORTA,0
    RETURN
    
  UART_RESET:
    CLRF	DATA_FLAG
    CLRF	FLAGS
    RETURN
    
  InterruptHandler:
    MOVWF	W_TEMP			;stores W
    SWAPF	STATUS, W 
    MOVWF	STATUS_TEMP		;stores status
    BANKSEL	PIR1
    BTFSC	PIR1,5
    GOTO	HANDSHAKE_TEST		;stores GPS data from uart
    BTFSC	PIR1,0
    GOTO	TMR1_Overflow		;runs logic for TMR1
    GOTO	LeaveISR
    
 LeaveISR:
    SWAPF	STATUS_TEMP,W
    MOVWF	STATUS			;restores status
    SWAPF	W_TEMP,F
    SWAPF	W_TEMP,W		;restores w
    RETFIE				;returns from interrupt and enables global interrupt
END