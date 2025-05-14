using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextManager : MonoBehaviour
{
    private Sprite[] textImages;
    private RectTransform[] children;
    private Image[] childImages;
    private bool isTransitioning = false;

    public static TextManager S;

    void Awake()
    {
        S = this;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        children = transform.GetComponentsInChildren<RectTransform>();
        childImages = new Image[children.Length];
        for (int i = 0; i < children.Length; i++) {
            childImages[i] = children[i].GetComponent<Image>();
            // Set 6th child to be invisible initially
            if (i == 5) {
                Color color = childImages[i].color;
                color.a = 0f;
                childImages[i].color = color;
            }
        }
        GetText();
    }

    public void GetText(){
        int currStage = GameManager.S.stage;
        textImages = Resources.LoadAll<Sprite>($"{currStage}");
        
        for(int i = 0; i < children.Length; i++){  
            children[i].GetComponent<Image>().sprite = textImages[i];
            // Set initial alpha to 0 for all layers
            Color color = childImages[i].color;
            color.a = 0f;
            childImages[i].color = color;
        }
        
        // Start the fade in coroutine
        StartCoroutine(FadeInTextLayers());
    }

    private IEnumerator FadeInTextLayers()
    {
        float fadeDuration = 1.0f;
        float elapsedTime = 0f;
        
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeDuration;
            
            // Fade in all layers except the 6th one (MainText)
            for (int i = 0; i < 5 && i < childImages.Length; i++)
            {
                Color color = childImages[i].color;
                color.a = Mathf.Lerp(0f, 1f, t);
                childImages[i].color = color;
            }
            
            yield return null;
        }
        
        // Ensure final values are set
        for (int i = 0; i < 5 && i < childImages.Length; i++)
        {
            Color color = childImages[i].color;
            color.a = 0.5f;
            childImages[i].color = color;
        }
    }

    public void FadeTextTransition()
    {
        if (!isTransitioning)
        {
            TextEffectManager.S.FadeOutDistortion();
            StartCoroutine(FadeTextTransitionCoroutine());
        }
    }

    private IEnumerator FadeTextTransitionCoroutine()
    {
        isTransitioning = true;
        float fadeDuration = 2.0f;
        float elapsedTime = 0f;
        
        // Store initial alpha values
        float[] initialAlphas = new float[childImages.Length];
        for (int i = 0; i < childImages.Length; i++)
        {
            initialAlphas[i] = childImages[i].color.a;
        }
        
        // Phase 1: Fade out first 5 while fading in 6th
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeDuration;
            
            // Fade out first 5 children
            for (int i = 0; i < 5 && i < childImages.Length; i++)
            {
                Color color = childImages[i].color;
                color.a = Mathf.Lerp(initialAlphas[i], 0f, t);
                childImages[i].color = color;
            }
            
            // Fade in the last child
            if (childImages.Length > 5)
            {
                Color color = childImages[5].color;
                color.a = Mathf.Lerp(0f, 1f, t);
                childImages[5].color = color;
            }
            
            yield return null;
        }
        
        // Phase 2: Wait for 6 seconds
        yield return new WaitForSeconds(6f);

        // Play the Transition Sound
        AudioManager.S.PlayTransition();
        
        // Phase 3: Fade out 6th child
        elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeDuration;
            
            // Fade out the last child
            if (childImages.Length > 5)
            {
                Color color = childImages[5].color;
                color.a = Mathf.Lerp(1f, 0f, t);
                childImages[5].color = color;
            }
            
            yield return null;
        }
        
        // Ensure final values are set
        for (int i = 0; i < 5 && i < childImages.Length; i++)
        {
            Color color = childImages[i].color;
            color.a = 0f;
            childImages[i].color = color;
        }
        
        if (childImages.Length > 5)
        {
            Color color = childImages[5].color;
            color.a = 0f;
            childImages[5].color = color;
        }
        
        isTransitioning = false;
        
        NodeManager.S.NewSequence();
    }
}
