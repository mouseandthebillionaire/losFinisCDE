using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class TextEffectManager : MonoBehaviour
{
    private Volume v;

    private Distortion_10 e10;
    private Distortion_9 e9;
    private Distortion_6 e6;
    private Distortion_4 e4;
    private LimitlessGlitch6 lg6;

    // Store the current distortion values
    private float currentDistortion10 = 2f;
    private float currentDistortion9 = 1f;
    private float currentDistortion6 = 1f;
    private float currentDistortion4 = 1f;
    private float currentLimitlessGlitch6 = 200f;
    
    public string[] effectOrder = {"LimitlessGlitch_6", "Distortion_4", "Distortion_10", "Distortion_9", "Distortion_6"}; // Which distortion effect to use


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
        }
        Distortion_9 tmp_e9;
        if(v.profile.TryGet<Distortion_9>(out tmp_e9)){
            e9 = tmp_e9;
        }
        Distortion_6 tmp_e6;
        if(v.profile.TryGet<Distortion_6>(out tmp_e6)){
            e6 = tmp_e6;
        }
        Distortion_4 tmp_e4;
        if(v.profile.TryGet<Distortion_4>(out tmp_e4)){
            e4 = tmp_e4;
        }  
        LimitlessGlitch6 tmp_lg6;
        if(v.profile.TryGet<LimitlessGlitch6>(out tmp_lg6)){
            lg6 = tmp_lg6;
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

    public void SetDistortion(int nodeNumber, float amount){
        string distortion = effectOrder[nodeNumber];

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
            case "LimitlessGlitch_6":
                currentLimitlessGlitch6 = amount;
                if (lg6 != null) lg6.amount.Override(currentLimitlessGlitch6 * 20f);
                break;
            default:
                Debug.LogError($"Invalid distortion: {distortion}");
                break;
        }
    }     

    public void FadeOutDistortion(){
        StartCoroutine(FadeOutDistortionCoroutine());
    }

    private IEnumerator FadeOutDistortionCoroutine()
    {
        float fadeDuration = 1.0f;
        float elapsedTime = 0f;
        float targetDistortion10 = .01f;
        float targetDistortion9 = 0.1f;
        float targetDistortion6 = 0.1f;
        float targetDistortion4 = 0.1f;   
        float targetLimitlessGlitch6 = 0.1f;      
        
        // Store initial values
        float startDistortion10 = currentDistortion10;
        float startDistortion9 = currentDistortion9;
        float startDistortion6 = currentDistortion6;
        float startDistortion4 = currentDistortion4;
        float startLimitlessGlitch6 = currentLimitlessGlitch6;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeDuration;
            
            // Interpolate distortion values
            currentDistortion10 = Mathf.Lerp(startDistortion10, targetDistortion10, t);
            currentDistortion9 = Mathf.Lerp(startDistortion9, targetDistortion9, t);
            currentDistortion6 = Mathf.Lerp(startDistortion6, targetDistortion6, t);
            currentDistortion4 = Mathf.Lerp(startDistortion4, targetDistortion4, t);
            currentLimitlessGlitch6 = Mathf.Lerp(startLimitlessGlitch6, targetLimitlessGlitch6, t);
            yield return null;
        }
        
        // Ensure final values are set
        currentDistortion10 = targetDistortion10;
        currentDistortion9 = targetDistortion9;
        currentDistortion6 = targetDistortion6;
        currentDistortion4 = targetDistortion4;
        currentLimitlessGlitch6 = targetLimitlessGlitch6;
    }
    
    public void ResetDistortion(){
        // Not sure if this is necessary
        currentDistortion9 = 1f;
        currentDistortion6 = 1f;
        currentDistortion4 = 1f;
        currentLimitlessGlitch6 = 200f;
    }
}
