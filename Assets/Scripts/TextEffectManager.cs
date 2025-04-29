using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TextEffectManager : MonoBehaviour
{
    private Volume v;

    private Distortion_10 e10;
    private Distortion_9 e9;
    private Distortion_6 e6;
    private Distortion_4 e4;

    // Store the current distortion values
    private float currentDistortion10 = 2f;
    private float currentDistortion9 = 1f;
    private float currentDistortion6 = 1f;
    private float currentDistortion4 = 1f;

    public static TextEffectManager S;

    private void Awake(){
        S = this;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        v = GetComponent<Volume>();
        if (v == null)
        {
            Debug.LogError("Volume component not found on TextEffectManager!");
            return;
        }
        v.enabled = true;
        Distortion_10 tmp_e10;
        if(v.profile.TryGet<Distortion_10>(out tmp_e10)){
            e10 = tmp_e10;
            Debug.Log("Found Distortion_10");
        }
        Distortion_9 tmp_e9;
        if(v.profile.TryGet<Distortion_9>(out tmp_e9)){
            e9 = tmp_e9;
            Debug.Log("Found Distortion_9");
        }
        Distortion_6 tmp_e6;
        if(v.profile.TryGet<Distortion_6>(out tmp_e6)){
            e6 = tmp_e6;
            Debug.Log("Found Distortion_6");
        }
        Distortion_4 tmp_e4;
        if(v.profile.TryGet<Distortion_4>(out tmp_e4)){
            e4 = tmp_e4;
            Debug.Log("Found Distortion_4");
        }   
    }

    void FixedUpdate()
    {
        // Apply the stored distortion values
        if (e10 != null) e10.Intensity.Override(currentDistortion10 * 2f);
        if (e9 != null) e9.fade.Override(currentDistortion9);
        if (e6 != null) e6.fade.Override(currentDistortion6);
        if (e4 != null) e4.fade.Override(currentDistortion4);

        v.enabled = false;
        v.enabled = true;
    }

    public void SetDistortion(string distortion, float amount){
        Debug.Log($"Setting distortion: {distortion} with amount: {amount}");
        switch(distortion){
            case "Distortion_10":
                currentDistortion10 = amount;
                break;
            case "Distortion_9":
                currentDistortion9 = amount;
                break;
            case "Distortion_6":
                currentDistortion6 = amount;
                break;
            case "Distortion_4":
                currentDistortion4 = amount;
                break;
            default:
                Debug.LogError($"Invalid distortion: {distortion}");
                break;
        }
    }           
}
