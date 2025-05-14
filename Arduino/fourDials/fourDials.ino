/*
 * built on the adafruit seesaw multiple_encoders example
 */

#include "Adafruit_seesaw.h"
#include <seesaw_neopixel.h>

#define SS_SWITCH        24      // this is the pin on the encoder connected to switch
#define SS_NEOPIX        6       // this is the pin on the encoder connected to neopixel

String outputString;

// create 4 encoders!
Adafruit_seesaw encoders[4];
// create 4 encoder pixels
seesaw_NeoPixel encoder_pixels[4] = {
  seesaw_NeoPixel(1, SS_NEOPIX, NEO_GRB + NEO_KHZ800),
  seesaw_NeoPixel(1, SS_NEOPIX, NEO_GRB + NEO_KHZ800),
  seesaw_NeoPixel(1, SS_NEOPIX, NEO_GRB + NEO_KHZ800),
  seesaw_NeoPixel(1, SS_NEOPIX, NEO_GRB + NEO_KHZ800)
};

int32_t encoder_positions[] = {0, 0, 0, 0};
// Original Prototype
// int32_t encoderAddresses[] = {54, 61, 59, 60};
// A MAZE Build
int32_t encoderAddresses[] = {56, 55, 57, 58};
bool found_encoders[] = {false, false, false, false};
bool encoder_pressed[] = {false, false, false, false};

// Button
const int buttonPin = 2;
int buttonState = 0;

// LED
const int ledPin = 13;
int ledState = LOW;
unsigned long previousMillis = 0;
const long interval = 500;
bool blink = false;

void setup() {
  Serial.begin(115200);

  // LED
  pinMode(ledPin, OUTPUT);
  // Button
  pinMode(buttonPin, INPUT_PULLUP);

  // wait for serial port to open
  while (!Serial) delay(10);

  for (uint8_t enc=0; enc<sizeof(found_encoders); enc++) {
    // See if we can find encoders on this address
    if (! encoders[enc].begin(encoderAddresses[enc]) ||
        ! encoder_pixels[enc].begin(encoderAddresses[enc])) {
      Serial.print("Couldn't find encoder #");
      Serial.print(enc);
      Serial.print(" at adress #");
      Serial.println(encoderAddresses[enc]);
    } else {
      Serial.print("Found encoder + pixel #");
      Serial.print(enc);
      Serial.print(" at adress #");
      Serial.println(encoderAddresses[enc]);

      uint32_t version = ((encoders[enc].getVersion() >> 16) & 0xFFFF);
      if (version != 4991){
        Serial.print("Wrong firmware loaded? ");
        Serial.println(version);
        while(1) delay(10);
      }
      // use a pin for the built in encoder switch
      encoders[enc].pinMode(SS_SWITCH, INPUT_PULLUP);

      // get starting position
      encoder_positions[enc] = encoders[enc].getEncoderPosition();

      Serial.println("Turning on interrupts");
      delay(10);
      encoders[enc].setGPIOInterrupts((uint32_t)1 << SS_SWITCH, 1);
      encoders[enc].enableEncoderInterrupt();

      // set not so bright!
      encoder_pixels[enc].setBrightness(30);
      encoder_pixels[enc].show();

      found_encoders[enc] = true;
    }
  }

}

void loop() {

    // Blinking LED
  if(blink == true){
    unsigned long currentMillis = millis();

    if (currentMillis - previousMillis >= interval) {
      // save the last time you blinked the LED
      previousMillis = currentMillis;

      // if the LED is off turn it on and vice-versa:
      if (ledState == LOW) {
        ledState = HIGH;
      } else {
        ledState = LOW;
      }

      // set the LED with the ledState of the variable:
      digitalWrite(ledPin, ledState);
    }
  } else {
    digitalWrite(ledPin, LOW);
  }

  outputString = "";

  for (uint8_t enc=0; enc<sizeof(found_encoders); enc++) {
    
     if (found_encoders[enc] == false) continue;

     int32_t new_position = encoders[enc].getEncoderPosition();
     // did we move around?
     if (encoder_positions[enc] != new_position) {
       if (new_position > encoder_positions[enc]) outputString += "1";
       if (new_position < encoder_positions[enc]) outputString += "2";
       encoder_positions[enc] = new_position;

       // change the neopixel color, mulitply the new positiion by 4 to speed it up
       encoder_pixels[enc].setPixelColor(0, Wheel((new_position*4) & 0xFF));
       encoder_pixels[enc].show();
     } 
     // did the button get pressed?
     else if(! encoders[enc].digitalRead(SS_SWITCH) && !encoder_pressed[enc]){
      outputString += "3";
      encoder_pressed[enc] = true;
     }
     else outputString += "0";
     outputString += ":";

    // clear the press
    if(encoders[enc].digitalRead(SS_SWITCH)) encoder_pressed[enc] = false;

    }

  
  // Button
  buttonState = digitalRead(buttonPin);
  if(buttonState == 0){
    blink = false;
    digitalWrite(ledPin, LOW);
  }
  outputString += buttonState;

  Serial.println(outputString); 

  // Input
  if(Serial.available()){
    String serialData = Serial.readString();
    serialData.trim();
    if(serialData == "LOCATION_READY"){
      blink = true;
    } 
    if(serialData == "LOCATION_NOT_READY"){
      blink = false;
      digitalWrite(ledPin, LOW);
    } 
  }

    delay(200);
  }

uint32_t Wheel(byte WheelPos) {
  WheelPos = 255 - WheelPos;
  if (WheelPos < 85) {
    return seesaw_NeoPixel::Color(255 - WheelPos * 3, 0, WheelPos * 3);
  }
  if (WheelPos < 170) {
    WheelPos -= 85;
    return seesaw_NeoPixel::Color(0, WheelPos * 3, 255 - WheelPos * 3);
  }
  WheelPos -= 170;
  return seesaw_NeoPixel::Color(WheelPos * 3, 255 - WheelPos * 3, 0);
}
