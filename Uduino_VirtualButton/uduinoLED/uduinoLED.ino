#include<Uduino.h>
Uduino uduino("Unity LED");

void setup()
{
  Serial.begin(9600);
  uduino.addCommand("led", setLED);
}

void setLED() {
  int pinmode = uduino.charToInt(uduino.getParameter(0));
  int val1 = uduino.charToInt(uduino.getParameter(1));

  pinMode(pinmode, OUTPUT);

  delay(50);

  if (val1 == 1) {
    digitalWrite(pinmode, HIGH);

  } else {
    digitalWrite(pinmode, LOW);
  }
}

void loop()
{
  uduino.update();
}
