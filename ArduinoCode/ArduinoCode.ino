//Libraries
#include <SPI.h>
#include <Ethernet.h>
#include <EthernetUdp.h>
#include <Servo.h>
#include <dht11.h>
#include "HUSKYLENS.h"
#include "SoftwareSerial.h"

//UDP mac address, IP address, and port number
byte MAC[] = { 0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED }; // Mac address of the Arduino
IPAddress IPArduino(10, 1, 1, 150); // Arduino IP address
IPAddress IPGUI(10, 1, 1, 10); // GUI IP address
unsigned int UDPPort = 8080; // Router port used for communication

//UDP setup
EthernetUDP Udp;  
String UDPinputString = "";
char packetBuffer[UDP_TX_PACKET_MAX_SIZE];
char replyBuffer[] = "";

//Data
String readData, Tmp, Tmp1, Tmp2;
int commaIndex = 0;
int secondCommaIndex = 0;

//Servo
Servo servoMotor;
byte servoVal;

//RGB LED
#define RED 6
#define GREEN 5
#define BLUE 3

//Motion detector
byte motionDetectorPin = 7;
int motiondetectorValue;

//Temperature Humidity Sensor
byte DHT11pin = 2;
dht11 DHT11;
byte temperature = 0;
byte humidity = 0;
byte data[40] = { 0 };
unsigned long previousMillis = 0;
const long interval = 5000;

//Huksylens
HUSKYLENS husky;
void printResult(HUSKYLENSResult result);
SoftwareSerial mySerial(11, 12);

  int Blink = 0;

void setup() {
  Serial.begin(115200);
  mySerial.begin(9600);
  while (!husky.begin(mySerial)) {
    Serial.println(F("Begin failed!"));
    Serial.println(F("1.Please recheck the \"Protocol Type\" in HUSKYLENS (General Settings>>Protocol Type>>Serial 9600)"));
    Serial.println(F("2.Please recheck the connection."));
    delay(100);
  }

  //UDP Setup
  UDPinputString.reserve(200);      //Allocate a buffer in memory for manipulation of strings
  Ethernet.begin(MAC, IPArduino);   //Start Ethernet and UDP
  Udp.beginPacket(IPGUI, UDPPort);  //Start UDP with IP and local port
  Udp.begin(UDPPort);

  //Servo
  servoMotor.attach(9);
  servoMotor.write(90);

  //RGB LED
  pinMode(RED, OUTPUT);
  pinMode(GREEN, OUTPUT);
  pinMode(BLUE, OUTPUT);

  //Motion Detector
  pinMode(motionDetectorPin, INPUT);
}

void loop() {
  int packetSize = Udp.parsePacket();
  IPAddress remote = Udp.remoteIP();
  Udp.read(packetBuffer, UDP_TX_PACKET_MAX_SIZE);
  Tmp = packetBuffer;

  commaIndex = Tmp.indexOf(',');  //Splits Tmp at every comma
  secondCommaIndex = Tmp.indexOf(',', commaIndex + 1);
  Tmp1 = Tmp.substring(0, commaIndex);
  Tmp2 = Tmp.substring(commaIndex + 1, secondCommaIndex);

  //---------------------------SEND DATA TO GUI---------------------------
  unsigned long currentMillis = millis();

  if (currentMillis - previousMillis >= interval) {
    previousMillis = currentMillis;
    int chkT = DHT11.read(DHT11pin);
    Serial.println("Code executed");
    Udp.beginPacket(IPGUI, UDPPort);
    Udp.print("T," + (String)DHT11.temperature + "," + (String)DHT11.humidity + ",");
    Serial.println("Packet processed");
    Udp.endPacket();
  }


  motiondetectorValue = digitalRead(motionDetectorPin);
  if (motiondetectorValue == 1) {
    Udp.beginPacket(IPGUI, UDPPort);
    Udp.print("M,,");
    Udp.endPacket();
  } else if (motiondetectorValue == 0) {
    Udp.beginPacket(IPGUI, UDPPort);
    Udp.print("m,,");
    Udp.endPacket();
  }

  //--------------------------RECEIVE DATA FROM HUSKYLENS--------------------------
  if (husky.available()) {
    HUSKYLENSResult result = husky.read();
    printResult(result);
  }



  //---------------------------RECEIVE DATA FROM GUI---------------------------
  if (Tmp1 == "C") {
    delay(4);  //added a delay so the Arduino can keep up with the speed, Can be set to 0 if using an Arduino DUE for multi-processing.

    Udp.beginPacket(IPGUI, UDPPort);  //Initialize UDP with IP and local port
    Udp.print("C," + Tmp2 + ",");     //Send String with protocol UDP
    Udp.endPacket();                  //Stop UDP

    Blink = 0;
  } else if (Tmp1 == "Stop") {
    while (Blink < 10) {
      digitalWrite(13, HIGH);
      delay(70);
      digitalWrite(13, LOW);
      delay(70);
      Blink++;
    }
  } else if (Tmp1 == "Servo") {  //SERVO
    if (Tmp2 == "Lock") {
      digitalWrite(RED, HIGH);
      digitalWrite(GREEN, LOW);
      digitalWrite(BLUE, LOW);
      servoMotor.write(90);
    } else if (Tmp2 == "Unlock") {
      digitalWrite(RED, LOW);
      digitalWrite(GREEN, HIGH);
      digitalWrite(BLUE, LOW);
      servoMotor.write(10);
    }
  }
}

void printResult(HUSKYLENSResult result) {
  if (result.command == COMMAND_RETURN_BLOCK) {
    //servoMotor.write(10);
    //String id = (String)result.ID;
    //Serial.println(String() + F("ID: ") + result.ID);
    Serial.println(String()+F("Block:xCenter=")+result.xCenter+F(",yCenter=")+result.yCenter+F(",width=")+result.width+F(",height=")+result.height+F(",ID=")+result.ID);
  }
}
