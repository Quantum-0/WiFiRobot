#include <AFMotor.h>
AF_DCMotor motorFL(2, MOTOR12_64KHZ);
AF_DCMotor motorFR(1, MOTOR12_64KHZ);
AF_DCMotor motorBL(3, MOTOR34_64KHZ);
AF_DCMotor motorBR(4, MOTOR34_64KHZ);
AF_DCMotor * motors;

void setSpeedAll(byte s)
{
  motorFL.setSpeed(s);
  motorFR.setSpeed(s);
  motorBL.setSpeed(s);
  motorBR.setSpeed(s);
}
void setModeAll(byte m)
{
  motorBR.run(m);
  motorBL.run(m);
  motorFL.run(m);
  motorFR.run(m);
}

void setup() {
  pinMode(14, OUTPUT);
  pinMode(17, OUTPUT);
  digitalWrite(14, HIGH);
      delay(100);
      digitalWrite(14, LOW);
      delay(100);
      
  Serial.begin(115200);
  motorFL.setSpeed(100); // set the speed to 200/255
  motorFR.setSpeed(100);
  motorBL.setSpeed(100); // set the speed to 200/255
  motorBR.setSpeed(100);
  motors = malloc(sizeof(AF_DCMotor)*4);
}

void loop()
{
  if (Serial.available() > 2)
  {
    // CMD = motor + speed/mode + value
    // EXAPMLE = 1Sя, 2MF, 3S\0, AMR
    
    char m = Serial.read(); // motor
    char a = Serial.read(); // action
    char v = Serial.read(); // value
    byte motors_count = 0;

    if (m == 'B' && a == 'E') // BEP (Beep)
    {
      digitalWrite(14, HIGH);
      delay(100);
      digitalWrite(14, LOW);
      delay(100);
      return;
    }

    if (a == 'M')
    {
      if (v == 'F')
        v = FORWARD;
      else if (v == 'B')
        v = BACKWARD;
      else if (v == 'R')
        v = RELEASE;
      else
        Serial.println("Invalid motor mode value");
    }

    if (m == '1')
    {
      motors_count = 1;
      motors[0] = motorFR;
    }
    if (m == '2')
    {
      motors_count = 1;
      motors[0] = motorFL;
    }
    if (m == '3')
    {
      motors_count = 1;
      motors[0] = motorBL;
    }
    if (m == '4')
    {
      motors_count = 1;
      motors[0] = motorBR;
    }
    if (m == 'L')
    {
      motors_count = 2;
      motors[0] = motorBL;
      motors[1] = motorFL;
    }
    if (m == 'R')
    {
      motors_count = 2;
      motors[0] = motorBR;
      motors[1] = motorFR;
    }
    if (m == 'F')
    {
      motors_count = 2;
      motors[0] = motorFL;
      motors[1] = motorFR;
    }
    if (m == 'B')
    {
      motors_count = 2;
      motors[0] = motorBL;
      motors[1] = motorBR;
    }
    if (m == 'A')
    {
      motors_count = 4;
      motors[0] = motorFL;
      motors[1] = motorFR;
      motors[2] = motorBL;
      motors[3] = motorBR;
    }

    if (a == 'S')
    {
      for(byte i = 0; i < motors_count; i++)
      {
        Serial.print('1');
        motors[i].setSpeed(v);
      }
      Serial.print("SET SPEED ");
      Serial.print((uint8_t)v);
      Serial.print(" FOR MOTOR(S) ");
      Serial.println(m);
    }
    else if (a == 'M')
    {
      for(byte i = 0; i < motors_count; i++)
        motors[i].run(v);
      Serial.print("SET MODE ");
      Serial.print((uint8_t)v);
      Serial.print(" FOR MOTOR(S) ");
      Serial.println(m);
    }
  }
}
