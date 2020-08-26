#include<Uduino.h>
#include<Servo.h>
Uduino uduino("advancedBoard");

Servo myservo1;
Servo myservo2;
Servo myservo3;
Servo myservo4;
Servo myservo5;

void setup()
{
  Serial.begin(9600);
  myservo1.attach(3);
  myservo2.attach(5);
  myservo3.attach(9);
  myservo4.attach(10);
  myservo5.attach(11);

  uduino.addCommand("paper", paper);
  uduino.addCommand("rock", rock);
  uduino.addCommand("scissor", scissor);
  uduino.addCommand("off", disable);
}

void paper() {
  // we retreive the argument by looking at the pointer,
  // but we could use "uduino.getParameter(0)"
  //  uduino.getParameter(180);
  char *arg;
  arg = uduino.next();
  myservo1.write(0);
  myservo2.write(120);
  myservo3.write(120);
  myservo4.write(120);
  myservo5.write(120);
}

void rock() {
  // we retreive the argument by looking at the pointer,
  // but we could use "uduino.getParameter(0)"
  //  uduino.getParameter(180);
  char *arg;
  arg = uduino.next();
  myservo1.write(120);
  myservo2.write(0);
  myservo3.write(0);
  myservo4.write(0);
  myservo5.write(0);
}

void scissor() {
  // we retreive the argument by looking at the pointer,
  // but we could use "uduino.getParameter(0)"
  //  uduino.getParameter(180);
  char *arg;
  arg = uduino.next();
  myservo1.write(120);
  myservo2.write(120);
  myservo3.write(120);
  myservo4.write(0);
  myservo5.write(0);
}

void disable() {
  digitalWrite(13, LOW);
}

void loop()
{
  uduino.update();
  delay(15);
}
