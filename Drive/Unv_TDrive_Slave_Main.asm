;;****************************************************************************
;;									    *
;;	    File Name:	Unv_TDrive_Slave_Main.asm			    *
;;	    Date: 1/28/25						    *
;;	    File Version: 1						    *
;;	    Author:    Zac Christensen					    *
;;	    Company:   Idaho State University; RCET			    *
;;	    Description: Slave Board for the Universal Control System	    *
;;			    "Tank Drive" Board.				    *
;;									    *
;;****************************************************************************
;;									    *
;;	    Revision History:						    *
;;     1.Added I2C Receive Interrupt Routine; 1/29/25			    *
;;     2.Added "working" I2C Receive Routine; 2/10/25			    *
;;     3.Added Timer 2 Interrupt Routines; 2/11/25			    *
;;     4.Moved interrupt flag clearing into routines; 2/12/25		    *
;;     5.Added Timer 1 Interrupts for I2C COM Timeout; 2/12/25		    *
;;     6.Added COM Timeout Functionality;  2/13/25			    *
;;     7.Added Set Motor State Routine; 2/13/25				    *
;;     8.Added Determine Motor State and Joystick Thresholds; 2/18/25	    *
;;     9.Slow I2C COM Timeout For More Peripherals; 3/3/25		    *
;;     10.Add Comments and Update register names for Template; 4/30/25	    *
;;     _.								    *
;;									    *
;;****************************************************************************
;    
;;****************************************************************************************
;;****			     CURRENT_DRIVE_STATE Bit Map			      ***
;;****************************************************************************************
;;****  Current Drive State is Set up so that the lower Nibble(Bits 0-3) indicate the  ***
;;***    right motor Function and the upper nibble(Bits 4-7) indicate the left motor   ***
;;***    function.  Looking at the nibbles individually, a decimal 0=Stop, 1=Forward,  ***
;;***	and 2=Reverse.								      ***
;;****************************************************************************************
;;***_________________________________________________________________________________ ***
;;***| Hex Value	 |	Mode Name         |	       Motor Function		    | ***
;;***|	 0x00	 |      All Stop          | Right Motor Stop, Left Motor Stop	    | ***
;;***|	 0x11	 |    Drive Forward       | Right Motor Forward, Left Motor Forward | ***
;;***|	 0x22	 |    Drive Reverse       | Right Motor Reverse, Left Motor Reverse | ***       
;;***|	 0x10	 |  Turn Right Forward    | Right Motor Stop, Left Motor Forward    | ***    
;;***|	 0x02	 |  Turn Right Reverse    | Right Motor Reverse, Left Motor Stop    | ***
;;***|	 0x12	 | Zero-Point Turn Right  | Right Motor Reverse, Left Motor Forward | ***    
;;***|	 0x01	 |  Turn Left Forward     | Right Motor Forward, Left Motor Stop    | ***    
;;***|	 0x20	 |  Turn Left Reverse     | Right Motor Stop, Left Motor Reverse    | ***
;;***|	 0x21	 | Zero-Point Turn Left   | Right Motor Forward, Left Motor Reverse | ***
;;***|	 0x__	 | Unrecognized; All Stop | Right Motor Stop, Left Motor Stop	    | ***
;;***_________________________________________________________________________________ ***
;;****************************************************************************************
;    

#INCLUDE <p16f1788.inc>
#INCLUDE <Unv_TDrive_Slave_PIC_SetUp.inc>
#INCLUDE <Unv_Slave_I2C_SetUp.inc>
;LIST	 P=16f1788
;errorlevel -302,-207,-305,-206,-203

;******************************************    
;Configuration
;******************************************
 __CONFIG _CONFIG1, _FOSC_INTOSC & _WDTE_OFF & _PWRTE_OFF & _MCLRE_ON & _CP_OFF & _CPD_OFF & _BOREN_OFF & _CLKOUTEN_OFF & _IESO_OFF & _FCMEN_OFF
 __CONFIG _CONFIG2, _WRT_OFF & _VCAPEN_OFF & _PLLEN_OFF & _STVREN_ON & _BORV_LO & _LPBOR_OFF & _LVP_OFF

;******************************************		
;Interrupt Vectors
;******************************************
    ORG H'00'					
    GOTO SETUP
    ORG H'04'
    GOTO INTERRUPT
    
;******************************************
;Setup Routine
;******************************************
SETUP
    CALL	INITIALIZE
    CALL	I2C_SETUP_SLAVE
    
    BANKSEL	INTCON
    BSF		INTCON,7	    ;Enable Global Interrupts
    
    BANKSEL	T1CON
    BSF		T1CON,0		    ;Enable Timer 1 (I2C COM timeout safety)
    
    BANKSEL	T2CON
    BSF		T2CON,2		    ;Enable Timer 2 (PWM output timing)
    
    BANKSEL MOTOR_PERIOD
    MOVLW	 D'35'
    MOVWF	 MOTOR_PERIOD	    ;Motor period: 35 ticks * 0.1mS = 3.5mS
    BANKSEL SERVO_PERIOD
    MOVLW	 D'195'
    MOVWF	 SERVO_PERIOD	    ;Servo period: 195 ticks * 0.1mS = 19.5mS (~20mS)
    BANKSEL MOTOR_COUNT
    MOVLW	 H'00'
    MOVWF	 MOTOR_COUNT
    BANKSEL SERVO_COUNT
    MOVLW	 H'00'
    MOVWF	 SERVO_COUNT
    
    GOTO	MAIN
    
;******************************************
;Interrupt Service Routine
;******************************************
INTERRUPT    
	BANKSEL	    PIR1
	BTFSC	    PIR1,3
	CALL	    I2C_RECEIVE		;MSSP interrupt: I2C byte received
	
	BANKSEL	    PIR1
	BTFSC	    PIR1,0
	CALL	    I2C_COM_TIMEOUT	;Timer 1 overflow: check for COM loss
	
	BANKSEL	    PIR1
	BTFSC	    PIR1,1
	CALL	    TMR2_INT	;Timer 2: PWM pulse timing
	
	RETFIE
    
;;******************************************
;;Sub Routines
;;******************************************
;*******************************************************************************
      
TMR2_INT
    BANKSEL	MOTOR_COUNT
    INCF	MOTOR_COUNT,F		;MOTOR_COUNT++
    BANKSEL	SERVO_COUNT
    INCF	SERVO_COUNT,F		;SERVO_COUNT++
    
    GOTO SERVO_PWM
   
SERVO_PWM
    ;-- Check if servo period elapsed (SERVO_COUNT == SERVO_PERIOD) --
    BANKSEL	SERVO_PERIOD
    MOVFW	SERVO_PERIOD
    BANKSEL	SERVO_COUNT
    XORWF	SERVO_COUNT,0		;W = SERVO_COUNT XOR SERVO_PERIOD
    BANKSEL	STATUS
    BTFSC	STATUS,2		;Z set = match = period done
    GOTO	RESET_SERVO
 
    ;-- Check if servo pulse width elapsed (SERVO_COUNT == ACTUATOR_MOTOR_STATUS) --
    BANKSEL	ACTUATOR_MOTOR_STATUS
    MOVFW	ACTUATOR_MOTOR_STATUS	;W = current servo pulse width in ticks
    BANKSEL	SERVO_COUNT
    XORWF	SERVO_COUNT,0		;W = SERVO_COUNT XOR ACTUATOR_MOTOR_STATUS
    BANKSEL	STATUS
    BTFSC	STATUS,2		;Z set = match = pulse width done
    GOTO	SERVO_PW_END
 
    GOTO	MOTOR_PWM
    
RESET_SERVO
    BANKSEL	SERVO_COUNT
    CLRF	SERVO_COUNT
    BANKSEL	PORTA
    BSF		PORTA,4
    GOTO	MOTOR_PWM
    
MOTOR_PWM
    ;-- Check if motor period elapsed (MOTOR_COUNT == MOTOR_PERIOD) --
    BANKSEL	MOTOR_PERIOD
    MOVFW	MOTOR_PERIOD
    BANKSEL	MOTOR_COUNT
    XORWF	MOTOR_COUNT,0		;W = MOTOR_COUNT XOR MOTOR_PERIOD
    BANKSEL	STATUS
    BTFSC	STATUS,2		;Z set = match = period done
    GOTO	RESET_MOTOR
 
    ;-- Check if motor duty elapsed (MOTOR_COUNT == MOTOR_DUTY_COUNT) --
    BANKSEL	MOTOR_DUTY_COUNT
    MOVFW	MOTOR_DUTY_COUNT	;W = current motor duty in ticks (0-35)
    BANKSEL	MOTOR_COUNT
    XORWF	MOTOR_COUNT,0		;W = MOTOR_COUNT XOR MOTOR_DUTY_COUNT
    BANKSEL	STATUS
    BTFSC	STATUS,2		;Z set = match = duty done
    GOTO	MOTOR_PW_END
    
    GOTO	TMR2_INTERRUPT_END
    
RESET_MOTOR
    BANKSEL	MOTOR_COUNT
    CLRF	MOTOR_COUNT
    BANKSEL	PORTA
    BSF		PORTA,0
    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
    BANKSEL	PORTB
    BSF		PORTB,0          ; Right motor PWM high
    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
    GOTO	TMR2_INTERRUPT_END
    
SERVO_PW_END
    BANKSEL	PORTA
    BCF		PORTA,4
    GOTO	MOTOR_PWM
    
MOTOR_PW_END
    BANKSEL	PORTA
    BCF		PORTA,0
    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
    BANKSEL	PORTB
    BCF		PORTB,0          ; Right motor PWM low ? both cleared together
    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
    GOTO	TMR2_INTERRUPT_END

TMR2_INTERRUPT_END
    BANKSEL	PIR1
    BCF		PIR1,1
    RETURN
;**********************************************************************************************
;*** I2C_COM_TIMEOUT: fires on Timer 1 overflow (~130mS each).			    ***
;*** Timer 1 is cleared in I2C_RECEIVE each time a full packet arrives.		    ***
;*** If 2 overflows pass (~260mS) with no packet, all outputs forced to STOP.	    ***
;*** This stops the Bloodhound if the wired connection is broken.		    ***
;********************************************************************************************** 
I2C_COM_TIMEOUT
    BANKSEL	I2C_TIMEOUT_COUNT
    DECFSZ	I2C_TIMEOUT_COUNT
    GOTO	I2C_COM_TIMEOUT_END
    MOVLW	H'02'
    MOVWF	I2C_TIMEOUT_COUNT	;Reset timeout counter
    BANKSEL	STOP_COUNT
    MOVFW	STOP_COUNT
    BANKSEL	ACTUATOR_MOTOR_STATUS
    MOVWF	ACTUATOR_MOTOR_STATUS	;Steering to center
    ;;;;;;;;;;;;;;;;;;;;;;
    BANKSEL	SERVO_POS
    MOVWF	SERVO_POS
    ;;;;;;;;;;;;;;;;;;;;;;;
    
    BANKSEL	R_MOTOR_STATUS
    MOVWF	R_MOTOR_STATUS		;Right motor stop
    BANKSEL	L_MOTOR_STATUS
    MOVWF	L_MOTOR_STATUS		;Left motor stop
    
    ;;;;;;;;;;;;;;;;;;;;;;;;;;
    BANKSEL	MOTOR_DUTY_COUNT
    MOVLW	D'0'
    MOVWF	MOTOR_DUTY_COUNT	;Motor to zero duty (stop)
    ;;;;;;;;;;;;;;;;;;;;;;;;;;;
    BANKSEL PORTA
    BSF PORTA,5	    ;FORCE BRAKE ON IMMEDIETLY ON TIMEOUT 
    
    BANKSEL PORTB
    BSF PORTB,2	    ;FORCE BRAKE ON IMMEDIETLY ON TIMEOUT
    
I2C_COM_TIMEOUT_END
    BANKSEL	PIR1
    BCF		PIR1,0
    RETURN
    
;****************************************************************************************************
;*** UPDATE_DRIVE_STATUS: called whenever a complete 4-byte I2C packet is received.		  ***
;****************************************************************************************************    
UPDATE_DRIVE_STATUS
    CALL	SAVE_I2C_DATA
    CALL	DETERMINE_DRIVE_STATE	    ;JOY1_UD -> both motor counts
    CALL	DETERMINE_ACTUATOR_STATE    ;JOY2_LR -> steering servo count
    CALL	CHECK_HEADLIGHTS
    BANKSEL	I2C_RX_COMPLETE
    CLRF	I2C_RX_COMPLETE
    RETURN
   
;*************************************************************************************************
;*** SAVE_I2C_DATA: maps raw I2C receive buffers to named registers.			       ***
;***									    	       ***
;***   Byte 1 -> JOY1_UD  DRIVE THROTTLE  (joystick 1 up/down)		       ***
;***   Byte 2 -> JOY1_LR  unused					       ***
;***   Byte 3 -> JOY2_UD  BRAKE					       ***
;***   Byte 4 -> JOY2_LR  STEERING        (joystick 2 left/right)	       ***
;*************************************************************************************************
SAVE_I2C_DATA
    BANKSEL	I2C_RX_TEMP_1
    MOVFW	I2C_RX_TEMP_1
    BANKSEL	JOY1_UD
    MOVWF	JOY1_UD			;Drive throttle
    BANKSEL	I2C_RX_TEMP_2
    MOVFW	I2C_RX_TEMP_2
    BANKSEL	JOY1_LR	
    MOVWF	JOY1_LR			;Unused
    BANKSEL	I2C_RX_TEMP_3
    MOVFW	I2C_RX_TEMP_3
    BANKSEL	JOY2_UD
    MOVWF	JOY2_UD			;Unused
    BANKSEL	I2C_RX_TEMP_4
    MOVFW	I2C_RX_TEMP_4
    BANKSEL	JOY2_LR
    MOVWF	JOY2_LR			;Steering
    RETURN
   
;*******************************************************************************
DETERMINE_DRIVE_STATE
;-- JOY1_UD forward zone ? forward drive
    BANKSEL UPPER_THRESHOLD
    MOVF UPPER_THRESHOLD,0
    BANKSEL JOY1_UD
    SUBWF JOY1_UD,0
    BANKSEL STATUS
    BTFSC STATUS,0
    GOTO MOTOR_FORWARD

;-- JOY1_UD pulled back ? reverse drive
    BANKSEL LOWER_THRESHOLD
    MOVF LOWER_THRESHOLD,0
    BANKSEL JOY1_UD
    SUBWF JOY1_UD,0
    BANKSEL STATUS
    BTFSS STATUS,0
    GOTO MOTOR_REVERSE

;-- JOY2_UD pulled back ? brake
    BANKSEL LOWER_THRESHOLD
    MOVF LOWER_THRESHOLD,0
    BANKSEL JOY2_UD
    SUBWF JOY2_UD,0
    BANKSEL STATUS
    BTFSS STATUS,0
    GOTO BRAKE

;-- Deadband on both joysticks ? neutral, brake OFF
    BANKSEL MOTOR_DUTY_COUNT
    MOVLW D'3'
    MOVWF MOTOR_DUTY_COUNT
    BANKSEL PORTA
    BCF PORTA,5
    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
    BANKSEL PORTB
    BCF PORTB,2
    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
    GOTO DETERMINE_DRIVE_STATE_END

MOTOR_FORWARD
    BANKSEL PORTA
    BSF PORTA,1                  ; forward direction
    BCF PORTA,5                  ; brake OFF
    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
    BANKSEL PORTB
    BSF PORTB,1                  ; Right forward
    BCF PORTB,2                  ; Right brake OFF
    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
    BANKSEL JOY1_UD
    MOVF JOY1_UD,0
    XORLW D'161'
    ADDLW D'7'
    MOVWF MOTOR_DUTY_COUNT
    GOTO DETERMINE_DRIVE_STATE_END

MOTOR_REVERSE
    BANKSEL PORTA
    BCF PORTA,1                  ; reverse direction
    BCF PORTA,5                  ; brake OFF
    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
    BANKSEL PORTB
    BCF PORTB,1                  ; Right reverse
    BCF PORTB,2                  ; Right brake OFF
    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
    BANKSEL JOY1_UD
    MOVF JOY1_UD,0
    XORLW D'79'
    ADDLW D'7'
    MOVWF MOTOR_DUTY_COUNT
    GOTO DETERMINE_DRIVE_STATE_END

BRAKE
    BANKSEL PORTA
    BSF PORTA,5                  ; brake ON (RA5)
    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
    BANKSEL PORTB
    BSF PORTB,2                  ; Right brake ON
    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
    BANKSEL MOTOR_DUTY_COUNT
    MOVLW D'0'
    MOVWF MOTOR_DUTY_COUNT       ; force motor stop
    GOTO DETERMINE_DRIVE_STATE_END

DETERMINE_DRIVE_STATE_END
    RETURN        

    
;*******************************************************************************
;*** CHECK_HEADLIGHTS: Toggles RA6 when Joystick 2 is pushed UP
;*** JOY2_UD > 200 triggers the toggle.
;*******************************************************************************
CHECK_HEADLIGHTS
    BANKSEL JOY2_UD
    MOVLW   D'200'           ; Set a high threshold for the "Up" push
    SUBWF   JOY2_UD, W       ; W = JOY2_UD - 200
    BANKSEL STATUS
    BTFSS   STATUS, 0        ; If Carry is clear, JOY2_UD < 200 (Not pushed up)
    GOTO    UP_NOT_PRESSED

    ;-- Joystick IS pushed UP --
    BANKSEL LAST_BTN_STATE
    BTFSC   LAST_BTN_STATE, 0 ; Was it already up in the last packet?
    RETURN                    ; Yes, ignore until it's released and pushed again

    ;-- NEW UP-PUSH Detected! Toggle RA6 --
    BANKSEL LATA
    MOVLW   B'01000000'      ; Mask for RA6
    XORWF   LATA, F          ; Flip the headlight state

    ;-- Mark as "Held" --
    BANKSEL LAST_BTN_STATE
    BSF     LAST_BTN_STATE, 0
    RETURN

UP_NOT_PRESSED
    ;-- Clear the state once stick returns to center/down --
    BANKSEL LAST_BTN_STATE
    BCF     LAST_BTN_STATE, 0
    RETURN
    
;*******************************************************************************
;*** DETERMINED_ACTUATOR_STATE: Proportional Steering Mapping
;*** Maps JOY2_LR (0-255) to Pulse Width (12-19 ticks)
;*** 1.2ms (Right) = 12 ticks | 1.5ms (Center) = 15 ticks | 1.9ms (Left) = 19 ticks
;*******************************************************************************
DETERMINE_ACTUATOR_STATE
    BANKSEL JOY2_LR
    MOVFW   JOY2_LR          ; Get raw joystick value (0-255)
    
    ;-- Linear Mapping Logic --
    ; Divide joystick by 32 to get a value from 0 to 7
    ; (Right shift 5 times)
    MOVWF   SERVO_POS        ; Use SERVO_POS as temporary math register
    LSRF    SERVO_POS, F
    LSRF    SERVO_POS, F
    LSRF    SERVO_POS, F
    LSRF    SERVO_POS, F
    LSRF    SERVO_POS, F     ; SERVO_POS is now 0 to 7
    
    ; Now add the offset for the lowest pulse width (1.2ms = 12 ticks)
    MOVLW   D'12'
    ADDWF   SERVO_POS, W     ; W = (0 to 7) + 12 = 12 to 19
    
    ;-- Inversion Check --
    ; If joystick 0 was supposed to be 1.9ms (Left) and 255 was 1.2ms (Right)
    ; we might need to flip the result. Based on your current values:
    ; 12 = Right, 19 = Left.
    ; High Joy value (255) results in 19 (Left). 
    ; Low Joy value (0) results in 12 (Right).
    
    BANKSEL ACTUATOR_MOTOR_STATUS
    MOVWF   ACTUATOR_MOTOR_STATUS ; Update the pulse width for the ISR
    
    RETURN
    
;******************************************
;Main Code
;******************************************
MAIN
    BANKSEL	I2C_RX_COMPLETE
    BTFSC	I2C_RX_COMPLETE,0
    CALL	UPDATE_DRIVE_STATUS
    GOTO	MAIN
    
    
    END
