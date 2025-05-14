# Raspberry Pi Build Instructions

This document provides instructions on how to build and run the PiTest scene on a Raspberry Pi.

## Prerequisites

1. Unity 2020.3 LTS or newer
2. Raspberry Pi 3 or 4 (recommended)
3. Raspberry Pi OS (64-bit recommended)
4. I2C STEMMA encoders connected to the Raspberry Pi

## Building the Project

1. Open the project in Unity
2. Go to File > Build Settings
3. Select "Linux" as the target platform
4. Click "Switch Platform" if you're not already on Linux
5. Make sure the PiTest scene is included in the build
6. Click "Player Settings" and configure:
   - Set "Scripting Backend" to "Mono"
   - Set "API Compatibility Level" to ".NET Standard 2.0" or ".NET 4.x"
   - Make sure "Allow 'unsafe' Code" is checked
7. Click "Build" and choose a directory to save the build

## Transferring to Raspberry Pi

### Option 1: Using SCP

```bash
scp -r /path/to/your/build username@raspberry-pi-ip:/home/username/
```

### Option 2: Using a USB Drive

1. Copy the build folder to a USB drive
2. Connect the USB drive to your Raspberry Pi
3. Copy the files from the USB drive to your Raspberry Pi

## Setting Up the Raspberry Pi

1. Enable I2C:
   ```bash
   sudo raspi-config
   # Navigate to Interface Options -> I2C -> Enable
   ```

2. Install required dependencies:
   ```bash
   sudo apt-get update
   sudo apt-get install -y libmono-2.0-dev libmono-dev
   ```

3. Connect the I2C STEMMA encoders according to the instructions in `Assets/Scripts/PiController_Wiring.md`

## Running the Application

1. Navigate to the directory where you transferred the build
2. Make the executable file executable:
   ```bash
   chmod +x ./PiTestBuild
   ```
3. Run the application:
   ```bash
   ./PiTestBuild
   ```

## Troubleshooting

### If the application doesn't start:
- Check if you have the correct permissions to run the executable
- Make sure all dependencies are installed
- Check the logs for any error messages

### If the encoders aren't detected:
- Verify I2C is enabled on Raspberry Pi
- Check power connections
- Verify I2C addresses with `i2cdetect -y 1`
- Check for loose connections

### If the encoders read erratically:
- Check power supply stability
- Verify I2C connections
- Try shorter wires
- Check for interference from other devices 