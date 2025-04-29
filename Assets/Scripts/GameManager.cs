using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager S;

    public int stage = 0;
    
    public int nodeCount = 0;
    public int maxNodeCount = 5;
        
    
    public void Awake()
    {
        S = this;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
