/*
 * built on the adafruit seesaw multiple_encoders example
 */

#include "Adafruit_seesaw.h"
#include <seesaw_neopixel.h>
#include <Wire.h>

#define SS_SWITCH        24      // this is the pin on the encoder connected to switch
#define SS_NEOPIX        6       // this is the pin on the encoder connected to neopixel

String outputString;

// create 4 encoders!
Adafruit_seesaw encoders[2];
// create 4 encoder pixels with reduced memory usage
seesaw_NeoPixel encoder_pixels[2] = {
  seesaw_NeoPixel(1, SS_NEOPIX, NEO_GRB + NEO_KHZ800),
  seesaw_NeoPixel(1, SS_NEOPIX, NEO_GRB + NEO_KHZ800)
};

// Reduce memory usage by using smaller data types
int16_t encoder_positions[] = {0, 0};
// Original Prototype
// int32_t encoderAddresses[] = {54, 61, 59, 60};
// A MAZE Build
uint8_t encoderAddresses[] = {0x3B, 0x3C};  // 59, 60 in decimal
bool found_encoders[] = {false, false};
bool encoder_pressed[] = {false, false};

// Button
const int buttonPin = 2;
int buttonState = 0;

// LED
const int ledPin = 13;
int ledState = LOW;
unsigned long previousMillis = 0;
const long interval = 500;
bool blink = false;

// Use the correct addresses for your encoders
#define SEESAW_ADDR1     0x37
#define SEESAW_ADDR2     0x38

Adafruit_seesaw ss;
seesaw_NeoPixel sspixel = seesaw_NeoPixel(1, SS_NEOPIX, NEO_GRB + NEO_KHZ800);

void scanI2C() {
  Serial.println("Scanning I2C bus...");
  Serial.println("Checking common Seesaw addresses...");
  
  // Common Seesaw addresses to check
  byte addresses[] = {0x36, 0x37, 0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D};
  int deviceCount = 0;
  
  // First try the common addresses
  for(byte address : addresses) {
    Serial.print("Checking 0x");
    if (address < 16) Serial.print("0");
    Serial.print(address, HEX);
    Serial.print("... ");
    
    Wire.beginTransmission(address);
    delay(10);  // Add small delay
    byte error = Wire.endTransmission();
    delay(10);  // Add small delay
    
    if (error == 0) {
      Serial.println("Found!");
      deviceCount++;
    } else {
      Serial.println("Not found");
    }
  }
  
  if (deviceCount == 0) {
    Serial.println("\nNo I2C devices found! Please check:");
    Serial.println("1. I2C connections (SDA, SCL)");
    Serial.println("2. Power connections (VCC, GND)");
    Serial.println("3. Pull-up resistors (if not using internal ones)");
  } else {
    Serial.print("\nFound ");
    Serial.print(deviceCount);
    Serial.println(" device(s)");
  }
}

void testI2C() {
  Serial.println(F("Testing I2C bus..."));
  delay(1000);  // Give time for serial to initialize
  
  // Test 1: Check I2C pins
  #if defined(ARDUINO_AVR_MEGA2560) || defined(ARDUINO_AVR_MEGA)
    pinMode(20, INPUT);
    pinMode(21, INPUT);
    Serial.print(F("SDA:"));
    Serial.println(digitalRead(20) ? F("HIGH") : F("LOW"));
    Serial.print(F("SCL:"));
    Serial.println(digitalRead(21) ? F("HIGH") : F("LOW"));
  #else
    pinMode(A4, INPUT);
    pinMode(A5, INPUT);
    Serial.print(F("SDA:"));
    Serial.println(digitalRead(A4) ? F("HIGH") : F("LOW"));
    Serial.print(F("SCL:"));
    Serial.println(digitalRead(A5) ? F("HIGH") : F("LOW"));
  #endif
  delay(1000);  // Give time to read the output

  // Test 2: Initialize I2C with slower clock
  Wire.begin();
  Wire.setClock(10000);  // Try 10kHz instead of 5kHz
  Serial.println(F("I2C initialized at 10kHz"));
  delay(1000);

  // Test 3: Try to read from expected encoder addresses
  Serial.println(F("Testing encoder addresses..."));
  delay(1000);
  
  // Common Seesaw addresses to try
  byte addresses[] = {0x37, 0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D};
  
  for(byte address : addresses) {
    Serial.print(F("Trying 0x"));
    if (address < 16) Serial.print(F("0"));
    Serial.print(address, HEX);
    Serial.print(F("... "));
    
    Wire.beginTransmission(address);
    byte error = Wire.endTransmission();
    
    if (error == 0) {
      Serial.println(F("OK"));
    } else {
      Serial.print(F("Error "));
      Serial.println(error);
    }
    
    delay(500);  // Give more time between attempts
  }
  
  // Test 4: Try a basic I2C write/read test
  Serial.println(F("\nTesting basic I2C communication..."));
  delay(1000);
  
  byte testAddress = 0x36;  // First Seesaw address
  
  Serial.print(F("Writing to 0x"));
  Serial.print(testAddress, HEX);
  Serial.print(F("... "));
  
  Wire.beginTransmission(testAddress);
  Wire.write(0x00);  // Try to write a byte
  byte error = Wire.endTransmission();
  
  if (error == 0) {
    Serial.println(F("Write OK"));
    
    // Try to read
    Serial.print(F("Reading from 0x"));
    Serial.print(testAddress, HEX);
    Serial.print(F("... "));
    
    Wire.requestFrom(testAddress, (byte)1);
    if (Wire.available()) {
      byte data = Wire.read();
      Serial.print(F("Read OK: 0x"));
      Serial.println(data, HEX);
    } else {
      Serial.println(F("No data"));
    }
  } else {
    Serial.print(F("Write failed: "));
    Serial.println(error);
  }
  
  // Test 5: Check I2C pins after test
  Serial.println(F("\nFinal I2C pin states:"));
  delay(1000);
  
  #if defined(ARDUINO_AVR_MEGA2560) || defined(ARDUINO_AVR_MEGA)
    Serial.print(F("SDA:"));
    Serial.println(digitalRead(20) ? F("HIGH") : F("LOW"));
    Serial.print(F("SCL:"));
    Serial.println(digitalRead(21) ? F("HIGH") : F("LOW"));
  #else
    Serial.print(F("SDA:"));
    Serial.println(digitalRead(A4) ? F("HIGH") : F("LOW"));
    Serial.print(F("SCL:"));
    Serial.println(digitalRead(A5) ? F("HIGH") : F("LOW"));
  #endif
  
  Serial.println(F("\nI2C test complete"));
  delay(1000);
}

void setup() {
  Serial.begin(115200);
  delay(2000);  // Give more time for serial to stabilize
  
  Serial.println(F("I2C Encoder Test"));
  Serial.println(F("---------------"));
  
  // Initialize I2C
  Wire.begin();
  Wire.setClock(10000);  // 10kHz
  
  // Try first address
  Serial.print(F("Trying address 0x"));
  Serial.print(SEESAW_ADDR1, HEX);
  Serial.println(F("..."));
  
  if (!ss.begin(SEESAW_ADDR1)) {
    Serial.println(F("Failed to initialize at first address"));
    
    // Try second address
    Serial.print(F("Trying address 0x"));
    Serial.print(SEESAW_ADDR2, HEX);
    Serial.println(F("..."));
    
    if (!ss.begin(SEESAW_ADDR2)) {
      Serial.println(F("Failed to initialize at second address"));
      Serial.println(F("Please check:"));
      Serial.println(F("1. Wiring (VIN, GND, SDA, SCL)"));
      Serial.println(F("2. Power supply voltage"));
      Serial.println(F("3. I2C connections"));
      while(1) delay(100);
    }
  }
  
  // If we get here, we found the device
  Serial.println(F("Found encoder!"));
  
  // Get version
  uint32_t version = ((ss.getVersion() >> 16) & 0xFFFF);
  Serial.print(F("Version: 0x"));
  Serial.println(version, HEX);
  
  if (version != 4991) {
    Serial.println(F("Warning: Unexpected version number"));
  }
  
  // Initialize encoder
  ss.pinMode(SS_SWITCH, INPUT_PULLUP);
  ss.enableEncoderInterrupt();
  
  Serial.println(F("Setup complete"));
}

void loop() {
  // Read encoder position
  int32_t position = ss.getEncoderPosition();
  Serial.print(F("Position: "));
  Serial.println(position);
  
  // Read button state
  bool button = !ss.digitalRead(SS_SWITCH);
  if (button) {
    Serial.println(F("Button pressed!"));
  }
  
  delay(100);
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
