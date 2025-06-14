using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using UnityEngine;
using Cycling74.RNBOTypes;

//TODO how to share these aliases?
//https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/built-in-types
using Float = System.Double;
using MillisecondTime = System.Double;
using ParameterValue = System.Double;
using ParameterIndex = System.UIntPtr;
using MessageTag = System.UInt32;

public class droneSynthHandle {
    public event EventHandler<ParameterChangedEventArgs> ParameterChangedEvent;
    public event EventHandler<MessageEventArgs> MessageEvent;
    public event EventHandler<TransportEventArgs> TransportEvent;
    public event EventHandler<TempoEventArgs> TempoEvent;
    public event EventHandler<BeatTimeEventArgs> BeatTimeEvent;
    public event EventHandler<TimeSignatureEventArgs> TimeSignatureEvent;
    public event EventHandler<PresetEventArgs> PresetEvent;

    [DllImport("droneSynth")]
    private static extern IntPtr RNBOInstanceCreate(out int key);

    [DllImport("droneSynth")]
    private static extern void RNBOInstanceDestroy(IntPtr instance);

    [DllImport("droneSynth")]
    private static extern void RNBOProcess(IntPtr instance, MillisecondTime now, float[] data, int channels, int nframes, int samplerate);

    [DllImport("droneSynth")]
    private static extern MessageTag RNBOTag(IntPtr tagString);

    [DllImport("droneSynth")]
    private static extern IntPtr RNBOGetDescription();

    [DllImport("droneSynth")]
    private static extern IntPtr RNBOGetPresets();

    [DllImport("droneSynth")]
    private static extern bool RNBOResolveTag(int key, MessageTag tag, out IntPtr tagStr);

    [DllImport("droneSynth")]
    private static extern bool RNBOInstanceMapped(int key);

    [DllImport("droneSynth")]
    private static extern bool RNBOPoll(int key);

    [DllImport("droneSynth")]
    private static extern bool RNBOSetParamValue(int key, ParameterIndex index, ParameterValue value, MillisecondTime attime);

    [DllImport("droneSynth")]
    private static extern bool RNBOGetParamValue(int key, ParameterIndex index, out ParameterValue value);

    [DllImport("droneSynth")]
    private static extern bool RNBOSetParamValueNormalized(int key, ParameterIndex index, ParameterValue value, MillisecondTime attime);

    [DllImport("droneSynth")]
    private static extern bool RNBOGetParamValueNormalized(int key, ParameterIndex index, out ParameterValue value);

    [DllImport("droneSynth", CallingConvention = CallingConvention.StdCall)]
    private static extern bool RNBOClearRegisteredCallbacks(int key);

    [DllImport("droneSynth", CallingConvention = CallingConvention.StdCall)]
    private static extern bool RNBORegisterParameterEventCallback(int key, IntPtr callback, IntPtr handle);

    [DllImport("droneSynth", CallingConvention = CallingConvention.StdCall)]
    private static extern bool RNBORegisterMessageEventCallback(int key, IntPtr callback, IntPtr handle);

    [DllImport("droneSynth", CallingConvention = CallingConvention.StdCall)]
    private static extern bool RNBORegisterTransportEventCallback(int key, IntPtr callback, IntPtr handle);

    [DllImport("droneSynth", CallingConvention = CallingConvention.StdCall)]
    private static extern bool RNBORegisterTempoEventCallback(int key, IntPtr callback, IntPtr handle);

    [DllImport("droneSynth", CallingConvention = CallingConvention.StdCall)]
    private static extern bool RNBORegisterBeatTimeEventCallback(int key, IntPtr callback, IntPtr handle);

    [DllImport("droneSynth", CallingConvention = CallingConvention.StdCall)]
    private static extern bool RNBORegisterTimeSignatureEventCallback(int key, IntPtr callback, IntPtr handle);

    [DllImport("droneSynth", CallingConvention = CallingConvention.StdCall)]
    private static extern bool RNBORegisterGlobalTransportRequestCallback(IntPtr callback, IntPtr handle);

    [DllImport("droneSynth", CallingConvention = CallingConvention.StdCall)]
    private static extern bool RNBORegisterTransportRequestCallback(int key, IntPtr callback, IntPtr handle);

    [DllImport("droneSynth", CallingConvention = CallingConvention.StdCall)]
    private static extern bool RNBORegisterPresetCallback(int key, IntPtr callback, IntPtr handle);

    [DllImport("droneSynth")]
    private static extern bool RNBOSendMessageBang(int key, MessageTag tag, MillisecondTime atTime);

    [DllImport("droneSynth")]
    private static extern bool RNBOSendMessageNumber(int key, MessageTag tag, Float value, MillisecondTime atTime);

    [DllImport("droneSynth")]
    private static extern bool RNBOSendMessageList(int key, MessageTag tag, [MarshalAs(UnmanagedType.LPArray)] Float[] list, IntPtr listlen, MillisecondTime atTime);

    [DllImport("droneSynth")]
    private static extern bool RNBOSendMIDI(int key, [MarshalAs(UnmanagedType.LPArray)] byte[] data, IntPtr dataLen, MillisecondTime atTime);

    [DllImport("droneSynth")]
    private static extern bool RNBOSendTransportEvent(int key, bool running, MillisecondTime atTime);

    [DllImport("droneSynth")]
    private static extern bool RNBOSendTempoEvent(int key, Float bpm, MillisecondTime atTime);

    [DllImport("droneSynth")]
    private static extern bool RNBOSendBeatTimeEvent(int key, Float beattime, MillisecondTime atTime);

    [DllImport("droneSynth")]
    private static extern bool RNBOSendTimeSignatureEvent(int key, int numerator, int denominator, MillisecondTime atTime);

    [DllImport("droneSynth")]
    private static extern bool RNBOCopyLoadDataRef(int key, IntPtr id, [MarshalAs(UnmanagedType.LPArray)] System.Single[] data, IntPtr datalen, IntPtr channels, IntPtr samplerate);

    [DllImport("droneSynth")]
    private static extern bool RNBOUnsafeLoadDataRef(int key, IntPtr id, [MarshalAs(UnmanagedType.LPArray)] System.Single[] data, IntPtr datalen, IntPtr channels, IntPtr samplerate);

    [DllImport("droneSynth")]
    private static extern bool RNBOUnsafeLoadReadOnlyDataRef(int key, IntPtr id, [MarshalAs(UnmanagedType.LPArray)] System.Single[] data, IntPtr datalen, IntPtr channels, IntPtr samplerate);

    [DllImport("droneSynth")]
    private static extern bool RNBOReleaseDataRef(int key, IntPtr id);

    [DllImport("droneSynth")]
    private static extern bool RNBOLoadPreset(int key, IntPtr payload);

    [DllImport("droneSynth")]
    private static extern bool RNBOGetPresetSync(int key, out IntPtr payloadPtr);

    [DllImport("droneSynth")]
    private static extern void RNBOFreePreset(IntPtr payloadPtr);

    [DllImport("droneSynth")]
    private static extern bool RNBOGetPreset(int key);

    [DllImport("droneSynth")]
    private static extern IntPtr RNBOReleaseHandles();


    private static PatcherDescription patcherDescription;
    public static PatcherDescription PatcherDescription {
        get {
            if (patcherDescription == null) {
                string descString = Marshal.PtrToStringAnsi(RNBOGetDescription());
                patcherDescription = JsonUtility.FromJson<PatcherDescription>(descString)!;
            }
            return patcherDescription;
        }
    }

    private static ParameterInfo[] parameters;
    public static ParameterInfo[] Parameters {
        get {
            if (parameters == null) {
                parameters = PatcherDescription.parameters.ToArray();
            }
            return parameters;
        }
    }

    private static Port[] inports;
    public static Port[] Inports {
        get {
            if (inports == null) {
                inports = PatcherDescription.inports.ToArray();
            }
            return inports;
        }
    }

    private static Port[] outports;
    public static Port[] Outports {
        get {
            if (outports == null) {
                outports = PatcherDescription.outports.ToArray();
            }
            return outports;
        }
    }

    private static DataRef[] dataRefs;
    public static DataRef[] DataRefs {
        get {
            if (dataRefs == null) {
                dataRefs = PatcherDescription.externalDataRefs.ToArray();
            }
            return dataRefs;
        }
    }

    private static PresetEntry[] presets;
    public static PresetEntry[] Presets {
        get {
            if (presets == null) {
                string s = Marshal.PtrToStringAnsi(RNBOGetPresets());
                presets = JsonUtility.FromJson<PresetList>(s)!.presets.ToArray();
            }
            return presets;
        }
    }

    public static MessageTag Tag(string v) {
        IntPtr tagPtr = (IntPtr)Marshal.StringToHGlobalAnsi(v);
        var r = RNBOTag(tagPtr);
        Marshal.FreeHGlobal(tagPtr);
        return r;
    }

    //does this handle own the instance
    private IntPtr ownedInstance = (IntPtr)0;
    private bool OwnsInstance => ownedInstance != (IntPtr)0;

    private int sampleRate;

    GCHandle handle;
    private IntPtr Handle {
        get {
            if (!handle.IsAllocated) {
                handle = GCHandle.Alloc(this);
            }
            return GCHandle.ToIntPtr(handle);
        }
    }

    //handles for other objects that need to be cleaned up
    //so far only transport objects
    static HashSet<GCHandle> activeHandles = new HashSet<GCHandle>();

    private static void updateActiveHandles(GCHandle h) {
        lock (activeHandles) {
            activeHandles.Add(h);
        }
    }

    private static void releaseHandle(IntPtr p) {
        lock (activeHandles) {
            GCHandle gch = GCHandle.FromIntPtr(p);
            if (activeHandles.Remove(gch)) {
                //XXX Freeing is causing crashes when restarting the editor.
                //So for now, we leak.. currently this is handle cache is only used for transport, so we should advise people not to create lots of transports
                /*
                if (gch.IsAllocated) {
                    gch.Free();
                }
                */
            }
        }
    }
    
    public droneSynthHandle() {
        int key;
        ownedInstance = RNBOInstanceCreate(out key);
        PluginKey = key;

        /*
         * XXX prepare to process?
        int bufferSize;
        int numBuffers;
        AudioSettings.GetDSPBufferSize(out bufferSize, out numBuffers);
        */

        sampleRate = AudioSettings.outputSampleRate;
        RegisterIfNeeded();
    }
    
    internal droneSynthHandle(int key) {
        PluginKey = key;
    }
    
    ~droneSynthHandle() {
        RNBOClearRegisteredCallbacks(PluginKey);
        if (OwnsInstance) {
            RNBOInstanceDestroy(ownedInstance);
        }
        if (handle.IsAllocated) {
            handle.Free();
        }
    }

    private bool registered = false;
    private void RegisterIfNeeded() {
        if (!registered) {
            registered = RegisterParameterEventDelegate() 
                && RegisterMessageEventDelegate() 
                && RegisterTransportEventDelegate() 
                && RegisterTempoEventDelegate() 
                && RegisterBeatTimeEventDelegate() 
                && RegisterTimeSignatureEventDelegate() 
                && RegisterPresetEventDelegate() 
                ;
        }
    }
    
    public int PluginKey {
        get; internal set;
    }

    void ReleaseHandles() {
        IntPtr p = RNBOReleaseHandles();
        while (!p.Equals(IntPtr.Zero)) {
            releaseHandle(p);
            p = RNBOReleaseHandles();
        }
    }
    
    public void Update() {
        RegisterIfNeeded();
        RNBOPoll(PluginKey);
        ReleaseHandles();
    }

    public MillisecondTime Now {
        get => (MillisecondTime)(AudioSettings.dspTime * 1000.0);
    }

    public void Process(float[] data, int channels) {
        if (!OwnsInstance) {
            throw new InvalidOperationException("Process can only be called on owned instances");
        }

        RNBOProcess(ownedInstance, Now, data, channels, data.Length / channels, sampleRate);
    }

    public bool ResolveTag(MessageTag tag, out string tagStr) {
        IntPtr p;
        var r = RNBOResolveTag(PluginKey, tag, out p);
        if (r) {
            tagStr = Marshal.PtrToStringAnsi(p);
        } else {
            tagStr = string.Empty;
        }
        return r;
    }

    public static ParameterInfo GetParamByIndex(int index) => Array.Find(Parameters, p => p.index == index);
    public static ParameterInfo[] GetParamsByName(string name) => Array.FindAll(Parameters, p => name.Equals(p.name));
    public static ParameterInfo GetParamById(string id) => Array.Find(Parameters, p => id.Equals(p.paramId));

    private static Dictionary<string, int> parameterNameToIndex;
    public static int? GetFirstParamIndexByName(string name) {
        if (parameterNameToIndex == null) {
            parameterNameToIndex = new Dictionary<string, int>();
            foreach (var p in Parameters) {
                if (!parameterNameToIndex.ContainsKey(p.name)) {
                    parameterNameToIndex.Add(p.name, p.index);
                }
            }
        }
        int index = 0;
        if (parameterNameToIndex.TryGetValue(name, out index)) {
            return index;
        }
        return null;
    }

    private static Dictionary<string, int> parameterIdToIndex;
    public static int? GetParamIndexById(string id) {
        if (parameterIdToIndex == null) {
            parameterIdToIndex = new Dictionary<string, int>();
            foreach (var p in Parameters) {
                parameterIdToIndex.Add(p.paramId, p.index);
            }
        }
        int index = 0;
        if (parameterIdToIndex.TryGetValue(id, out index)) {
            return index;
        }
        return null;
    }

    public bool GetParamValue(int index, out ParameterValue value) {
        return RNBOGetParamValue(PluginKey, (ParameterIndex)index, out value);
    }

    public bool SetParamValue(int index, ParameterValue value, MillisecondTime attime = 0) {
        return RNBOSetParamValue(PluginKey, (ParameterIndex)index, value, attime);
    }

    public bool GetParamValueNormalized(int index, out ParameterValue value) {
        return RNBOGetParamValueNormalized(PluginKey, (ParameterIndex)index, out value);
    }

    public bool SetParamValueNormalized(int index, ParameterValue value, MillisecondTime attime = 0) {
        return RNBOSetParamValueNormalized(PluginKey, (ParameterIndex)index, value, attime);
    }

    public bool SendBang(MessageTag tag, MillisecondTime atTime = 0) {
        return RNBOSendMessageBang(PluginKey, tag, atTime);
    }

    public bool SendMessage(MessageTag tag, Float value, MillisecondTime atTime = 0) {
        return RNBOSendMessageNumber(PluginKey, tag, value, atTime);
    }

    public bool SendMessage(MessageTag tag, Float[] values, MillisecondTime atTime = 0) {
        return RNBOSendMessageList(PluginKey, tag, values, (IntPtr)values.Length, atTime);
    }

    public bool SendMIDI(byte[] data, MillisecondTime atTime = 0) {
        return RNBOSendMIDI(PluginKey, data, (IntPtr)data.Length, atTime);
    }

    public bool SendMIDINoteOn(byte channel, byte noteNum, byte velocity, MillisecondTime atTime = 0) {
        Debug.Assert(channel < (byte)16);
        Debug.Assert(noteNum < (byte)128);
        Debug.Assert(velocity < (byte)128);
        byte[] data = new byte[] { (byte)(channel | MIDIHeaders.NOTE_ON), noteNum, velocity };
        return SendMIDI(data, atTime);
    }

    public bool SendMIDINoteOff(byte channel, byte noteNum, byte velocity = (byte)0, MillisecondTime atTime = 0) {
        Debug.Assert(channel < (byte)16);
        Debug.Assert(noteNum < (byte)128);
        Debug.Assert(velocity < (byte)128);
        byte[] data = new byte[] { (byte)(channel | MIDIHeaders.NOTE_OFF), noteNum, velocity };
        return SendMIDI(data, atTime);
    }

    public bool SendMIDICC(byte channel, byte num, byte val, MillisecondTime atTime = 0) {
        Debug.Assert(channel < (byte)16);
        Debug.Assert(num < (byte)128);
        Debug.Assert(val < (byte)128);
        byte[] data = new byte[] { (byte)(channel | MIDIHeaders.CONTROL_CHANGE), num, val };
        return SendMIDI(data, atTime);
    }

    public bool SetTransportRunning(bool on, MillisecondTime atTime = 0) {
        return RNBOSendTransportEvent(PluginKey, on, atTime);
    }

    public bool SetTempo(Float val, MillisecondTime atTime = 0) {
        return RNBOSendTempoEvent(PluginKey, val, atTime);
    }

    public bool SetBeatTime(Float val, MillisecondTime atTime = 0) {
        return RNBOSendBeatTimeEvent(PluginKey, val, atTime);
    }
    
    public bool SetTimeSignature(int numerator, int denominator, MillisecondTime atTime = 0) {
        return RNBOSendTimeSignatureEvent(PluginKey, numerator, denominator, atTime);
    }

    public bool LoadDataRef(string id, float[] data, int channels, int samplerate) {
        IntPtr idPtr = (IntPtr)Marshal.StringToHGlobalAnsi(id);
        var r = RNBOCopyLoadDataRef(PluginKey, idPtr, data, (IntPtr)data.Length, (IntPtr)channels, (IntPtr)samplerate);
        Marshal.FreeHGlobal(idPtr);
        return r;
    }

    private static List<float[]> unsafeDataRefReferences;
    public bool LoadUnsafeReadOnlyDataRef(string id, float[] data, int channels, int samplerate) {
        //keep a reference to the data so it doesn't get cleaned up
        if (unsafeDataRefReferences == null) {
            unsafeDataRefReferences = new List<float[]>();
        }
        unsafeDataRefReferences.Add(data);

        IntPtr idPtr = (IntPtr)Marshal.StringToHGlobalAnsi(id);
        var r = RNBOUnsafeLoadReadOnlyDataRef(PluginKey, idPtr, data, (IntPtr)data.Length, (IntPtr)channels, (IntPtr)samplerate);
        Marshal.FreeHGlobal(idPtr);
        return r;
    }

    public bool ReleaseDataRef(string id) {
        IntPtr idPtr = (IntPtr)Marshal.StringToHGlobalAnsi(id);
        var r = RNBOReleaseDataRef(PluginKey, idPtr);
        Marshal.FreeHGlobal(idPtr);
        return r;
    }

    public bool LoadPreset(string payload) {
        IntPtr p = (IntPtr)Marshal.StringToHGlobalAnsi(payload);
        var r = RNBOLoadPreset(PluginKey, p);
        Marshal.FreeHGlobal(p);
        return r;
    }

    //NOTE: might cause clicks
    public bool CapturePresetSync(out string payload) {
        IntPtr p;

        var r = RNBOGetPresetSync(PluginKey, out p);
        if (r) {
            payload = Marshal.PtrToStringAnsi(p);
        } else {
            payload = string.Empty;
        }
        RNBOFreePreset(p);

        return r;
    }

    //Trigger a preset capture, listen to PresetEvent for the data
    public bool CapturePreset() {
        return RNBOGetPreset(PluginKey);
    }

    private static droneSynthHandle GetInstance(IntPtr handle) {
        GCHandle gch = GCHandle.FromIntPtr(handle);
        return (droneSynthHandle)gch.Target;
    }

    private delegate void ParameterEventDelegate(IntPtr handle, ParameterIndex index, ParameterValue value, MillisecondTime time);
    [AOT.MonoPInvokeCallback(typeof(ParameterEventDelegate))]
    private static void ParameterEventHandler(IntPtr handle, ParameterIndex index, ParameterValue value, MillisecondTime time) {
        var inst = GetInstance(handle);
        var e = inst?.ParameterChangedEvent;
        if (e != null) {
            //cast to int as it is easier to use for unity
            e(inst, new ParameterChangedEventArgs((int)index, value, time));
        }
    }
    private static ParameterEventDelegate parameterEventDelegate = ParameterEventHandler;

    private bool RegisterParameterEventDelegate() {
        return RNBORegisterParameterEventCallback(PluginKey, Marshal.GetFunctionPointerForDelegate(parameterEventDelegate), Handle);
    }

    private delegate void MessageEventDelegate(IntPtr handle, MessageTag tag, IntPtr messageType, IntPtr valuesPtr, IntPtr valueCount, MillisecondTime time);
    [AOT.MonoPInvokeCallback(typeof(MessageEventDelegate))]
    private static void MessageEventHandler(IntPtr handle, MessageTag tag, IntPtr messageType, IntPtr valuesPtr, IntPtr valueCount, MillisecondTime time) {
        var inst = GetInstance(handle);
        var e = inst?.MessageEvent;
        if (e != null) {
            MessageEventType t = MessageEventType.Bang;
            Float[] values = new Float[(int)valueCount];

            if (messageType.Equals(IntPtr.Zero)) {
                Marshal.Copy(valuesPtr, values, 0, 1);
                t = MessageEventType.Number;
            } else if (messageType.Equals((IntPtr)1)) {
                Marshal.Copy(valuesPtr, values, 0, (int)valueCount);
                t = MessageEventType.List;
            }

            e(inst, new MessageEventArgs(tag, t, values, time));
        }
    }
    private static MessageEventDelegate messageEventDelegate = MessageEventHandler;

    private bool RegisterMessageEventDelegate() {
        return RNBORegisterMessageEventCallback(PluginKey, Marshal.GetFunctionPointerForDelegate(messageEventDelegate), Handle);
    }

    private delegate void TransportEventDelegate(IntPtr handle, bool running, MillisecondTime time);
    [AOT.MonoPInvokeCallback(typeof(TransportEventDelegate))]
    private static void TransportEventHandler(IntPtr handle, bool running, MillisecondTime time) {
        var inst = GetInstance(handle);
        var e = inst?.TransportEvent;
        if (e != null) {
            e(inst, new TransportEventArgs(running, time));
        }
    }
    private static TransportEventDelegate transportEventDelegate = TransportEventHandler;

    private bool RegisterTransportEventDelegate() {
        return RNBORegisterTransportEventCallback(PluginKey, Marshal.GetFunctionPointerForDelegate(transportEventDelegate), Handle);
    }

    private delegate void TempoEventDelegate(IntPtr handle, Float bpm, MillisecondTime time);
    [AOT.MonoPInvokeCallback(typeof(TempoEventDelegate))]
    private static void TempoEventHandler(IntPtr handle, Float bpm, MillisecondTime time) {
        var inst = GetInstance(handle);
        var e = inst?.TempoEvent;
        if (e != null) {
            e(inst, new TempoEventArgs(bpm, time));
        }
    }
    private static TempoEventDelegate tempoEventDelegate = TempoEventHandler;

    private bool RegisterTempoEventDelegate() {
        return RNBORegisterTempoEventCallback(PluginKey, Marshal.GetFunctionPointerForDelegate(tempoEventDelegate), Handle);
    }

    private delegate void BeatTimeEventDelegate(IntPtr handle, Float value, MillisecondTime time);
    [AOT.MonoPInvokeCallback(typeof(BeatTimeEventDelegate))]
    private static void BeatTimeEventHandler(IntPtr handle, Float value, MillisecondTime time) {
        var inst = GetInstance(handle);
        var e = inst?.BeatTimeEvent;
        if (e != null) {
            e(inst, new BeatTimeEventArgs(value, time));
        }
    }
    private static BeatTimeEventDelegate beatTimeEventDelegate = BeatTimeEventHandler;

    private bool RegisterBeatTimeEventDelegate() {
        return RNBORegisterBeatTimeEventCallback(PluginKey, Marshal.GetFunctionPointerForDelegate(beatTimeEventDelegate), Handle);
    }

    private delegate void TimeSignatureEventDelegate(IntPtr handle, int numerator, int denominator,  MillisecondTime time);
    [AOT.MonoPInvokeCallback(typeof(TimeSignatureEventDelegate))]
    private static void TimeSignatureEventHandler(IntPtr handle, int numerator, int denominator,  MillisecondTime time) {
        var inst = GetInstance(handle);
        var e = inst?.TimeSignatureEvent;
        if (e != null) {
            e(inst, new TimeSignatureEventArgs(numerator, denominator, time));
        }
    }
    private static TimeSignatureEventDelegate timeSignatureEventDelegate = TimeSignatureEventHandler;

    private bool RegisterTimeSignatureEventDelegate() {
        return RNBORegisterTimeSignatureEventCallback(PluginKey, Marshal.GetFunctionPointerForDelegate(timeSignatureEventDelegate), Handle);
    }

    private delegate void PresetEventDelegate(IntPtr handle, IntPtr payload);
    [AOT.MonoPInvokeCallback(typeof(PresetEventDelegate))]
    private static void PresetEventHandler(IntPtr handle, IntPtr payload) {
        var inst = GetInstance(handle);
        var e = inst?.PresetEvent;
        if (e != null) {
            string spayload = Marshal.PtrToStringAnsi(payload);
            e(inst, new PresetEventArgs(spayload));
        }
    }
    private static PresetEventDelegate presetEventDelegate = PresetEventHandler;

    private bool RegisterPresetEventDelegate() {
        return RNBORegisterPresetCallback(PluginKey, Marshal.GetFunctionPointerForDelegate(presetEventDelegate), Handle);
    }

    private static TransportRequestDelegate transportRequestDelegate = Transport.AudioThreadUpdate;
    public static void RegisterGlobalTransport(Transport transport) {
        if (transport == null) {
            RNBORegisterGlobalTransportRequestCallback(IntPtr.Zero, IntPtr.Zero);
        } else {
            GCHandle handle = GCHandle.Alloc(transport);
            IntPtr hPtr = GCHandle.ToIntPtr(handle);
            IntPtr fPtr = Marshal.GetFunctionPointerForDelegate(transportRequestDelegate);

            RNBORegisterGlobalTransportRequestCallback(fPtr, hPtr);
            updateActiveHandles(handle);
        }
    }

    public bool RegisterTransport(Transport transport) {
        if (transport == null) {
            return RNBORegisterTransportRequestCallback(PluginKey, IntPtr.Zero, IntPtr.Zero);
        } else {
            GCHandle handle = GCHandle.Alloc(transport);
            IntPtr hPtr = GCHandle.ToIntPtr(handle);
            IntPtr fPtr = Marshal.GetFunctionPointerForDelegate(transportRequestDelegate);

            var r = RNBORegisterTransportRequestCallback(PluginKey, fPtr, hPtr);
            if (r) {
                updateActiveHandles(handle);
            }
            return r;
        }
    }
}

public class droneSynthHelper : MonoBehaviour {
    private static Dictionary<int, GameObject> instances = new Dictionary<int, GameObject>();
    public static droneSynthHelper FindById(int key) {
        lock (instances) {
            GameObject go;
            if (!instances.TryGetValue(key, out go)) {
                go = new GameObject(String.Format("droneSynthHelperObject{0}", key));
                DontDestroyOnLoad(go);
                instances.Add(key, go);

                droneSynthHelper helper = go.AddComponent<droneSynthHelper>();
                helper.Plugin = new droneSynthHandle(key);
                return helper;
            }
            return go.GetComponent<droneSynthHelper>();
        }
    }

    public droneSynthHandle Plugin {
        get; internal set;
    }

    public int PluginKey {
        get => Plugin?.PluginKey ?? 0;
    }

    public void Update() {
        if (Plugin != null)
            Plugin.Update();
    }

    public void OnApplicationQuit() {
        //Clear out transport
        //Not sure if this is important, maybe in the editor with plugins still loaded in mixers?
        if (Plugin != null) {
            Plugin.RegisterTransport(null);
            droneSynthHandle.RegisterGlobalTransport(null);
        }
    }
}
