using System.Collections;
using UnityEngine;
using System.Runtime.InteropServices;

public class PiController : MonoBehaviour {
    // turn this on if we are using the controller
    public bool controllerActive = false;
    
    // Platform specific imports for Raspberry Pi
    #if UNITY_STANDALONE_LINUX
    [DllImport("libi2c")]
    private static extern int i2c_init();
    [DllImport("libi2c")]
    private static extern int i2c_open(int bus, int address);
    [DllImport("libi2c")]
    private static extern int i2c_read(int handle, byte[] buffer, int length);
    [DllImport("libi2c")]
    private static extern int i2c_close(int handle);
    #endif

    // I2C addresses for the encoders (default is 0x36, can be changed with solder jumper)
    private int[] encoderAddresses = new int[2] { 0x36, 0x37 };
    private int[] encoderHandles = new int[2];
    
    // Global variables
    public  int[]    dials               = new int[2];
    public  int[]    dialDir             = new int[2];
    public  float[,] dialVal             = new float[2,4];

    private bool[]   dialPushed          = new bool[2];
    public  int      launchButton        = 1;
    public bool     launchButtonPressed { get; private set; }
    
    public  string   lightStatus         = "off";
    
    // Dial Control
    public float dialLim = 100;
    public float dialSpeed, dialSpeed_granular;

    // Singleton
    public static PiController S;
    
    void Awake()
    {
        // Create Singleton
        if (S == null) S = this;
        else Destroy(this);
    }

    void Start()
    {
        #if UNITY_STANDALONE_LINUX
        if (controllerActive)
        {
            InitializeI2C();
        }
        #endif
        ResetVariables();
    }

    private void InitializeI2C()
    {
        #if UNITY_STANDALONE_LINUX
        if (i2c_init() != 0)
        {
            Debug.LogError("Failed to initialize I2C");
            return;
        }

        // Open I2C connections to each encoder
        for (int i = 0; i < 2; i++)
        {
            encoderHandles[i] = i2c_open(1, encoderAddresses[i]); // Using I2C bus 1
            if (encoderHandles[i] < 0)
            {
                Debug.LogError($"Failed to open I2C connection to encoder {i}");
            }
        }
        #endif
    }

    private void ReadEncoderInputs()
    {
        #if UNITY_STANDALONE_LINUX
        for (int i = 0; i < 2; i++)
        {
            if (encoderHandles[i] < 0) continue;

            byte[] buffer = new byte[4]; // 4 bytes: position (2 bytes), button (1 byte), reserved (1 byte)
            if (i2c_read(encoderHandles[i], buffer, 4) == 4)
            {
                // Convert 2 bytes to signed 16-bit integer for position
                int position = (buffer[1] << 8) | buffer[0];
                if (position > 32767) position -= 65536; // Handle negative numbers
                
                // Update dial direction based on position change
                if (position > 0) dials[i] = 2;      // Clockwise
                else if (position < 0) dials[i] = 1; // Counter-clockwise
                else dials[i] = 0;                   // No rotation

                // Check button state (bit 0 of button byte)
                if ((buffer[2] & 0x01) == 0)
                {
                    dials[i] = 3; // Button pressed
                }
            }
        }
        #endif
    }

    public void Light(string message)
    {
        // Note: This is a placeholder. You might want to implement
        // LED control via I2C if needed
        lightStatus = message;
    }

    void Update()
    {
        if (controllerActive)
        {
            #if UNITY_STANDALONE_LINUX
            ReadEncoderInputs();
            #endif
        }

        for (int i = 0; i < dials.Length; i++)
        {
            StartCoroutine(UpdateDial(i));
        }
    }

    public int GetDialValue(int dialNum)
    {
        return dials[dialNum];
    }   

    private IEnumerator UpdateDial(int dialNum)
    {
        dialDir[dialNum] = 0;
        
        // if we pressed, don't do the rest of this stuff 
        if (dials[dialNum] == 3)
        {
            if (!dialPushed[dialNum])
            {
                dialPushed[dialNum] = true;
                yield return new WaitForSeconds(0.5f);
                dialPushed[dialNum] = false;
            }
            yield break;   
        }

        // turned right
        if (dials[dialNum] == 1) dialDir[dialNum] = -1;
        // turned left
        if (dials[dialNum] == 2) dialDir[dialNum] = 1;
        
        yield return null;
    }

    public void ResetVariables() {
        Light("off");
        for (int i = 0; i < dials.Length; i++)
        {
            dials[i] = 0;
            dialPushed[i] = false;
        }
    }

    void OnApplicationQuit()
    {
        Light("off");
        #if UNITY_STANDALONE_LINUX
        // Close all I2C connections
        for (int i = 0; i < 2; i++)
        {
            if (encoderHandles[i] >= 0)
            {
                i2c_close(encoderHandles[i]);
            }
        }
        #endif
    }
} 