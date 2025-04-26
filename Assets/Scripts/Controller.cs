using System.Collections;
using UnityEngine;
#if UNITY_EDITOR
using System.IO.Ports;
#endif
using System.Threading;

public class Controller : MonoBehaviour {
    // turn this on if we are using the controller
    public bool controllerActive = false;
    
    // Serial data
#if UNITY_EDITOR
    private SerialPort stream;
#endif
    Thread             serialThread;
    string             serialData;
    private bool       serialReceived = false;
    
    
    // Keyboard input
    public KeyCode[] upDials   = new KeyCode[4];
    public KeyCode[] downDials = new KeyCode[4];
    public KeyCode[] pushDials = new KeyCode[4];

    // Global variables
    public  int[]    dials               = new int[4];
    public  int[]    dialDir             = new int[4];
    public  float[,] dialVal             = new float[4,4];

    private bool[]   dialPushed          = new bool[4];
    public  int      launchButton        = 1;
    public bool     launchButtonPressed { get; private set; }
    
    public  string   lightStatus         = "off";
    
    // Dial Control
    public float dialLim = 100;
    public float dialSpeed, dialSpeed_granular;

    // Singleton
    public static Controller S;
    
    // Start is called before the first frame update
    void Awake()
    {
        // Create Singleton
        if (S == null) S = this;
        else Destroy(this);
    }

    void Start()
    {
#if UNITY_EDITOR
        ConnectController();
#endif
        ResetVariables();
    }

    private void ConnectController()
    {
#if UNITY_EDITOR
        string[] ports = SerialPort.GetPortNames();
        string   portName;
        for (int i = 0; i < ports.Length; i++) {
            if (ports[i].Contains("usbmodem"))  {
                portName = ports[i];
                Debug.Log(portName);
                stream = new SerialPort(portName, 115200);
            }
        }
        
        // Initialize serial
        if (!stream.IsOpen && controllerActive) {
            if (SerialPort.GetPortNames().Length > 0) {
                stream.Open();

                serialThread = new Thread(new ThreadStart(ParseData));
                serialThread.Start();

                print("Connected to serial");
            }
        }
#endif
    }

    public void Light(string message)
    {
#if UNITY_EDITOR
        StartCoroutine(SwitchLight(message));
#else
        // In builds, just update the status without sending commands
        lightStatus = message;
#endif
    }

    private IEnumerator SwitchLight(string message)
    {
#if UNITY_EDITOR
        if (message == "on" && lightStatus == "off")
        {
            lightStatus = "on";
            stream.WriteLine("LOCATION_READY");
        }
        if (message == "off" && lightStatus == "on") 
        {
            stream.WriteLine("LOCATION_NOT_READY");
            lightStatus = "off";
        }
        stream.BaseStream.Flush();
#endif
        
        // Buffer to help it stop freaking out?
        // yield return new WaitForSeconds(1);
        yield return null;
    }
    
    // Update is called once per frame
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
            // This is shaking too much. Need to add a second break or so.
            if (!dialPushed[dialNum])
            {
                dialPushed[dialNum] = true;
                // half a second seems good
                yield return new WaitForSeconds(0.5f);
                dialPushed[dialNum] = false;
            }
            yield break;   
        }

        // These are only for debugging. They get overriden by the Controller.cs script and serial input
        // They could be included up in the above if statements, but this way we can get rid of or turn off more easily
        if (!controllerActive)
        {
            if (Input.anyKey)
            {
                // Can I just force these?
                if (Input.GetKey(downDials[dialNum])) dials[dialNum] = 1;
                else if (Input.GetKey(upDials[dialNum])) dials[dialNum] = 2;
            }
            else dials[dialNum] = 0;
        }

        // turned right
        if (dials[dialNum] == 1) dialDir[dialNum] = -1;
        // turned left
        if (dials[dialNum] == 2) dialDir[dialNum] = 1;
        
        yield return null;
    }

    public void ResetVariables() {
        Light("off");
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
        Light("off");
#if UNITY_EDITOR
        if (stream != null && stream.IsOpen) {
            stream.Close();
            serialThread.Abort();
        }
#endif
    }

    void OnApplicationPause() {

    }

    void ParseData() {
#if UNITY_EDITOR
        while(true) {
            serialData = stream.ReadLine();
            
            string[] parsedData = serialData.Split(':');
            // make sure that we're not dealing with a data drop
            // we add one because one is the launch button
            if (parsedData.Length == dials.Length + 1)
            {
                for (int i = 0; i < dials.Length; i++)
                {
                    if (int.TryParse(parsedData[i], out int tmpValue)) dials[i] = tmpValue;
                }
                // and get the button
                if (int.TryParse(parsedData[4], out int tmpBtnValue)) {
                    launchButton = tmpBtnValue;
                    launchButtonPressed = (tmpBtnValue == 0);
                    Debug.Log("launchButtonPressed: " + launchButtonPressed);
                }
            }
        }
#endif
    }
}

