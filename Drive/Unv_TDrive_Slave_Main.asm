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
    
;    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;    ;-- Check if motor duty elapsed (right motor on RB0) --
;    BANKSEL	MOTOR_DUTY_COUNT
;    MOVFW	MOTOR_DUTY_COUNT
;    BANKSEL	MOTOR_COUNT
;    XORWF	MOTOR_COUNT,0
;    BANKSEL	STATUS
;    BTFSC	STATUS,2
;    ;GOTO	RIGHT_MOTOR_PW_END
;    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
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
    
;RIGHT_MOTOR_PW_END
;    BANKSEL	PORTB
;    BCF		PORTB,0          ; Right motor PWM low
;    GOTO	TMR2_INTERRUPT_END

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
;*** DETERMINE_ACTUATOR_STATE: incremental servo stepping on RA4.	    ***
;***								    ***
;*** JOY1_LR > UPPER_THRESHOLD: step SERVO_POS +1 toward FORWARD_COUNT.    ***
;*** JOY1_LR < LOWER_THRESHOLD: step SERVO_POS -1 toward REVERSE_COUNT.    ***
;*** Deadband: snap to STOP_COUNT (exact center, no drift).		    ***
;***								    ***
;*** With PR2=50 (0.1mS ticks), servo counts are half the old values:	    ***
;***   FORWARD_COUNT = 18 ticks = 1.8mS					    ***
;***   STOP_COUNT    = 15 ticks = 1.5mS					    ***
;***   REVERSE_COUNT = 12 ticks = 1.2mS					    ***
;*** These are set in INITIALIZE in the setup file.			    ***
;*******************************************************************************
DETERMINE_ACTUATOR_STATE
    ;---- Check if joystick is past upper threshold (steer right) ----
    BANKSEL	UPPER_THRESHOLD
    MOVFW	UPPER_THRESHOLD
    ;BANKSEL	JOY1_LR
    ;SUBWF	JOY1_LR,0		;W = JOY2_LR - UPPER_THRESHOLD
    BANKSEL	JOY2_LR
    SUBWF	JOY2_LR,0		;W = JOY2_LR - UPPER_THRESHOLD
    BANKSEL	STATUS
    BTFSC	STATUS,0		;Carry set = pushed right
    GOTO	SERVO_INCREMENT

    ;---- Check if joystick is past lower threshold (steer left) ----
    BANKSEL	LOWER_THRESHOLD
    MOVFW	LOWER_THRESHOLD
    ;BANKSEL	JOY1_LR
    ;SUBWF	JOY1_LR,0		;W = JOY2_LR - LOWER_THRESHOLD
    BANKSEL	JOY2_LR
    SUBWF	JOY2_LR,0		;W = JOY2_LR - LOWER_THRESHOLD
    BANKSEL	STATUS
    BTFSS	STATUS,0		;Carry clear = pushed left
    GOTO	SERVO_DECREMENT

    GOTO	SERVO_RETURN_CENTER	;In deadband -- snap to center

SERVO_INCREMENT
    ;-- Step one tick right, clamp to FORWARD_COUNT (hard right limit) --
    BANKSEL	SERVO_POS
    INCF	SERVO_POS,F
    BANKSEL	FORWARD_COUNT
    MOVFW	FORWARD_COUNT
    BANKSEL	SERVO_POS
    SUBWF	SERVO_POS,0		;W = SERVO_POS - FORWARD_COUNT
    BANKSEL	STATUS
    BTFSS	STATUS,0		;Carry clear = under limit, no clamp needed
    GOTO	SERVO_UPDATE
    BANKSEL	FORWARD_COUNT
    MOVFW	FORWARD_COUNT
    BANKSEL	SERVO_POS
    MOVWF	SERVO_POS		;Clamp to hard right limit
    GOTO	SERVO_UPDATE

SERVO_DECREMENT
    ;-- Step one tick left, clamp to REVERSE_COUNT (hard left limit) --
    BANKSEL	SERVO_POS
    DECF	SERVO_POS,F
    BANKSEL	REVERSE_COUNT
    MOVFW	REVERSE_COUNT
    BANKSEL	SERVO_POS
    SUBWF	SERVO_POS,0		;W = SERVO_POS - REVERSE_COUNT
    BANKSEL	STATUS
    BTFSC	STATUS,0		;Carry set = above limit, no clamp needed
    GOTO	SERVO_UPDATE
    BANKSEL	REVERSE_COUNT
    MOVFW	REVERSE_COUNT
    BANKSEL	SERVO_POS
    MOVWF	SERVO_POS		;Clamp to hard left limit
    GOTO	SERVO_UPDATE

SERVO_RETURN_CENTER
    ;-- Deadband: snap directly to STOP_COUNT -- guaranteed exact center, no drift --
    BANKSEL	STOP_COUNT
    MOVFW	STOP_COUNT
    BANKSEL	SERVO_POS
    MOVWF	SERVO_POS		;SERVO_POS = center, no stepping, no overshoot

SERVO_UPDATE
    ;-- Write SERVO_POS into ACTUATOR_MOTOR_STATUS for TMR2 to use --
    BANKSEL	SERVO_POS
    MOVFW	SERVO_POS
    BANKSEL	ACTUATOR_MOTOR_STATUS
    MOVWF	ACTUATOR_MOTOR_STATUS

DETERMINE_ACTUATOR_STATE_END
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
;DETERMINE_DRIVE_STATE
;;-- Forward check
;    BANKSEL	UPPER_THRESHOLD
;    MOVF	UPPER_THRESHOLD,0
;    BANKSEL	JOY1_UD
;    SUBWF	JOY1_UD,0	;W = UPPER_THRESHOLD - JOY1_UD 
;    BANKSEL	STATUS
;    BTFSC	STATUS,0	;Carry set = forward zone
;    GOTO	MOTOR_FORWARD
;
;     ;-- Reverse check: borrow fires when JOY1_UD < LOWER_THRESHOLD --
;    BANKSEL	LOWER_THRESHOLD
;    MOVF	LOWER_THRESHOLD,0
;    BANKSEL	JOY1_UD
;    SUBWF	JOY1_UD,0	;W = JOY1_UD - LOWER_THRESHOLD
;    BANKSEL	STATUS
;    BTFSS	STATUS,0	;Carry clear = reverse zone
;    GOTO	MOTOR_REVERSE
;
;    ;--- Deadband: stop ---
;    BANKSEL	MOTOR_DUTY_COUNT
;    MOVLW	D'3'              ; 15% duty = 0.8V brake
;    MOVWF	MOTOR_DUTY_COUNT
;    
;    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;    BANKSEL PORTA
;    BCF PORTA,5	    ;BRAKE OFF WHEN JOYSTICK NUETRAL
;    
;    BANKSEL DIRECTION_FLAG
;    MOVLW 0x01
;    MOVWF DIRECTION_FLAG         ; 1 = neutral ? next reverse is allowed
;    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;    
;    GOTO	DETERMINE_DRIVE_STATE_END
;    
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;;*******************************************************************************
;;*** BRAKE_SUB: separate subroutine that ONLY handles braking               ***
;;*** Sets RA5 high (your brake SSR) and forces motor duty to 0.             ***
;;*** Called from forward-to-brake path so it never interferes with          ***
;;*** actual MOTOR_REVERSE drive logic.                                       ***
;;*******************************************************************************
;BRAKE_SUB
;    BANKSEL PORTA
;    BSF PORTA,5                  ; brake ON (your actual RA5 pin)
;    BANKSEL MOTOR_DUTY_COUNT
;    MOVLW D'0'
;    MOVWF MOTOR_DUTY_COUNT       ; force motor stop
;    RETURN
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;    
;MOTOR_FORWARD
;    BANKSEL	PORTA
;    BSF		PORTA,1
;    ;;;;;;;;;;;;;;;;;;;;
;    BCF PORTA,5	    ;BRAKE OFF IN FORWARD
;    
;    BANKSEL DIRECTION_FLAG
;    CLRF DIRECTION_FLAG          ; 0 = was forward ? brake only on next pull-back
;    ;;;;;;;;;;;;;;;;;;;;
;    
;    BANKSEL	JOY1_UD
;    MOVF	JOY1_UD,0
;    
;    XORLW	D'161'	;161
;    
;    ADDLW	D'7'	    ;7
;    MOVWF	MOTOR_DUTY_COUNT
;    
;    GOTO	DETERMINE_DRIVE_STATE_END
;    
;MOTOR_REVERSE
;    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;    BANKSEL DIRECTION_FLAG
;    BTFSC DIRECTION_FLAG,0       ; if 1 (was neutral) ? allow reverse drive
;    GOTO BRAKE_ONLY
;    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;    ;--- Reverse drive allowed ---
;    BANKSEL	PORTA
;    BCF		PORTA,1
;    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;    BCF PORTA,5                  ; brake OFF
;    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;    
;    BANKSEL	JOY1_UD
;    MOVF	JOY1_UD,0
;    
;    XORLW	D'79'	    ;79
;    
;    ADDLW	D'7'	    ;7
;    MOVWF	MOTOR_DUTY_COUNT
;    
;    GOTO	DETERMINE_DRIVE_STATE_END
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;;BRAKE_ONLY
;;    ;--- Braking while coming from forward ---
;;    BANKSEL PORTA
;;    BCF PORTA,1                  ; direction doesn't matter
;;    BSF PORTA,5                  ; brake ON
;;    BANKSEL MOTOR_DUTY_COUNT
;;    MOVLW D'0'                   ; force motor stop
;;    MOVWF MOTOR_DUTY_COUNT
;;    BANKSEL DIRECTION_FLAG
;;    CLRF DIRECTION_FLAG
;;    ; DIRECTION_FLAG stays 0 so we keep braking until neutral
;;    GOTO DETERMINE_DRIVE_STATE_END
;BRAKE_ONLY
;    CALL BRAKE_SUB               ; use the new separate subroutine
;    ; DIRECTION_FLAG stays 0 so we keep braking until neutral
;    GOTO DETERMINE_DRIVE_STATE_END
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;
;DETERMINE_DRIVE_STATE_END
;    RETURN