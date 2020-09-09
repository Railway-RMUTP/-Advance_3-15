#include <Uduino_Wifi.h> // Notice that here we replace  uduino by Uduino_WiFi
#include <Servo.h>
Servo myservo1, myservo2, myservo3, myservo4, myservo5; //ประกาศตัวแปรแทน Servo

Uduino_Wifi uduino("uduinoBoard"); // Notice that here we replace

void setup()
{
  Serial.begin(9600);
  /**************************************************/
  myservo1.attach(15);
  myservo2.attach(13);
  myservo3.attach(12);
  myservo4.attach(14);
  myservo5.attach(2);
  /**************************************************/
  uduino.connectWifi("get", "11443322nb"); // replace
  //... uduino.addCommand ...
  uduino.addCommand("servo", sel_servo);
}

void loop()
{
  uduino.update();
  delay(15);
}

void sel_servo()
{

  int mode_servo = 0;
  char *arg = NULL;
  arg = uduino.next();
  if (arg != NULL)
  {
    mode_servo = atoi(arg);
    Serial.print("mode_servo");
    Serial.println(mode_servo);
  }

  switch (mode_servo)
  {
  case 1:
    control_servo(1);
    break;
  case 2:
    control_servo(2);
    break;
  case 3:
    control_servo(3);
    break;

  default:
    control_servo(0);
    break;
  }
}

void control_servo(int temp_mode)
{

  if (temp_mode == 3)//paper
  {
    Serial.println("mode 3");
    myservo1.write(0); // สั่งให้ Servo หมุนไปองศาที่ 0
    myservo2.write(180);
    myservo3.write(180);
    myservo4.write(180);
    myservo5.write(180); 
  }
  else if (temp_mode == 1) //rock
  {
    Serial.println("mode 1");
    myservo1.write(180); // สั่งให้ Servo หมุนไปองศาที่ 0
    myservo2.write(0);
    myservo3.write(0);
    myservo4.write(0);
    myservo5.write(0); 
  }
  else if (temp_mode == 2) //sci
  {
    Serial.println("mode 2");
    myservo1.write(180); // สั่งให้ Servo หมุนไปองศาที่ 0
    myservo2.write(180);
    myservo3.write(180);
    myservo4.write(0);
    myservo5.write(0); 
  }
  else if (temp_mode == 0)
  {
    Serial.println("mode 0");
    myservo1.write(0); // สั่งให้ Servo หมุนไปองศาที่ 0
    myservo2.write(180);
    myservo3.write(0);
    myservo4.write(0);
    myservo5.write(180); 
  }
}
