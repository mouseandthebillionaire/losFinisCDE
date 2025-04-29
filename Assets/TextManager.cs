using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    private Sprite[] textImages;
    private RectTransform[] children;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        children = transform.GetComponentsInChildren<RectTransform>();
        GetText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetText(){
        int currStage = GameManager.S.stage;
        textImages = Resources.LoadAll<Sprite>($"{currStage}");
        
        for(int i = 0; i < children.Length; i++){  
            children[i].GetComponent<Image>().sprite = textImages[i];
        }
    }

}
