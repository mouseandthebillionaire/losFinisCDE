# Raspberry Pi Controller Wiring Guide (I2C STEMMA Encoders)

## Hardware Requirements
- 2x Adafruit I2C STEMMA Rotary Encoders
- Jumper wires
- Raspberry Pi (any model with I2C support)
- Optional: STEMMA QT / Qwiic cables for easier connection

## I2C Address Configuration
Each encoder needs a unique I2C address. The default address is 0x36, but you can change it using the solder jumper on each encoder:
- Encoder 1: 0x36 (default)
- Encoder 2: 0x37 (change solder jumper)

## Wiring Diagram
```
Raspberry Pi I2C Pins
┌───┐
│3V3│  ┌─────────┐
│5V │  │         │
│SDA│◄──┼────────┼─── SDA (All encoders)
│SCL│◄──┼────────┼─── SCL (All encoders)
│GND│◄──┼────────┼─── GND (All encoders)
└───┘  └─────────┘

Adafruit STEMMA Encoder
┌─────────────┐
│   Encoder   │
│  ┌───────┐  │
│  │  VCC  ├──┼─── To 3V3
│  │  GND  ├──┼─── To GND
│  │  SDA  ├──┼─── To SDA
│  │  SCL  ├──┼─── To SCL
│  └───────┘  │
└─────────────┘
```

## Detailed Connection Instructions

### For Each Encoder:

1. **Power Connections**:
   - VCC → 3V3
   - GND → GND

2. **I2C Connections**:
   - SDA → SDA (GPIO2 on Raspberry Pi)
   - SCL → SCL (GPIO3 on Raspberry Pi)

### Address Configuration:

For encoder 2, you'll need to modify its I2C address:
1. Locate the solder jumper on the encoder (labeled "ADR")
2. For encoder 2: Bridge one pad to set address to 0x37

## Raspberry Pi Setup

1. Enable I2C:
   ```bash
   sudo raspi-config
   # Navigate to Interface Options -> I2C -> Enable
   ```

2. Install I2C tools:
   ```bash
   sudo apt-get update
   sudo apt-get install -y python3-smbus i2c-tools
   ```

3. Verify I2C is working:
   ```bash
   i2cdetect -y 1
   # Should show your encoders at their respective addresses
   ```

## Important Notes:
1. All encoders share the same I2C bus (SDA/SCL lines)
2. Each encoder must have a unique I2C address
3. The STEMMA QT / Qwiic connectors make wiring much easier
4. No pull-up resistors needed (they're built into the encoders)
5. Keep wires as short as possible to minimize noise
6. Consider using a breadboard for easier prototyping

## Troubleshooting:
1. If encoders aren't detected:
   - Verify I2C is enabled on Raspberry Pi
   - Check power connections
   - Verify I2C addresses with `i2cdetect -y 1`
   - Check for loose connections

2. If encoders read erratically:
   - Check power supply stability
   - Verify I2C connections
   - Try shorter wires
   - Check for interference from other devices

3. If nothing works:
   - Verify power connections
   - Check all GND connections
   - Verify I2C addresses in code match physical configuration
   - Check I2C bus speed (default should work fine) 