using System.Collections;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class Controller : MonoBehaviour {
    // turn this on if we are using the controller
    public bool controllerActive = false;
    
    // Serial data
    private SerialPort stream;
    Thread serialThread;
    string serialData;
    private bool serialReceived = false;
    
    // Keyboard input
    public KeyCode[] upDials   = new KeyCode[2];
    public KeyCode[] downDials = new KeyCode[2];
    public KeyCode[] pushDials = new KeyCode[2];

    // Global variables
    public  int[]    dials               = new int[2];
    public  int[]    dialDir             = new int[2];
    public  float[,] dialVal             = new float[2,4];

    private bool[]   dialPushed          = new bool[2];
    public  string   lightStatus         = "off";
    
    // Dial Control
    public float dialLim = 100;
    public float dialSpeed, dialSpeed_granular;

    // Singleton
    public static Controller S;
    
    void Awake()
    {
        // Create Singleton
        if (S == null) S = this;
        else Destroy(this);
    }

    void Start()
    {
        ConnectController();
        ResetVariables();
    }

    private void ConnectController()
    {
        string[] ports = SerialPort.GetPortNames();
        string   portName;
        for (int i = 0; i < ports.Length; i++) {
            if (ports[i].Contains("usbmodem"))  {
                portName = ports[i];
                stream = new SerialPort(portName, 115200);
            }
        }
        
        // Initialize serial
        if (!stream.IsOpen && controllerActive) {
            if (SerialPort.GetPortNames().Length > 0) {
                stream.Open();

                serialThread = new Thread(new ThreadStart(ParseData));
                serialThread.Start();
            }
        }
    }
    
    void Update()
    {
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
        // pressed
        if (dials[dialNum] == 3 || Input.GetKeyDown(pushDials[dialNum]))
        {
            if (!dialPushed[dialNum])
            {
                dialPushed[dialNum] = true;
                yield return new WaitForSeconds(0.5f);
                dialPushed[dialNum] = false;
            }
            yield break;   
        }

        // These are only for debugging. They get overriden by the Controller.cs script and serial input
        if (!controllerActive)
        {
            if (Input.anyKey)
            {
                if (Input.GetKey(downDials[dialNum])) dials[dialNum] = 1;
                else if (Input.GetKey(upDials[dialNum])) dials[dialNum] = 2;
            }
            else dials[dialNum] = 0;
        }

        // turned right
        if (dials[dialNum] == 1) {
            dialDir[dialNum] = -1;
        }
        // turned left
        if (dials[dialNum] == 2) {
            dialDir[dialNum] = 1;
        }
        
        yield return null;
    }

    public void ResetVariables() {
        if (!serialReceived) {
            // Reset variables
            for (int i = 0; i < dials.Length; i++)
            {
                dials[i] = 0;
                dialPushed[i] = false;
            }
        }
        else serialReceived = false;
    }

    void OnApplicationQuit()
    {

        if (stream != null && stream.IsOpen) {
            try {
                stream.Close();
                if (serialThread != null) {
                    serialThread.Abort();
                }
            }
            catch (System.Exception e) {
                Debug.LogError($"Error closing serial port: {e.Message}");
            }
        }
    }

    void OnApplicationPause() {
    }

    void ParseData() {
        while(true) {
            try {
                if (stream != null && stream.IsOpen) {
                    serialData = stream.ReadLine();
                    
                    string[] parsedData = serialData.Split(':');
                    if (parsedData.Length >= dials.Length)
                    {
                        for (int i = 0; i < dials.Length; i++)
                        {
                            if (int.TryParse(parsedData[i], out int tmpValue)) {
                                dials[i] = tmpValue;
                            }
                        }
                    }
                }
            }
            catch (System.Exception e) {
                Debug.LogError($"Error reading serial data: {e.Message}");
                break;
            }
        }
    }
}


