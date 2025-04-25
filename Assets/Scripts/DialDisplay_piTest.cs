using UnityEngine;
using UnityEngine.UI; // For UI elements
using TMPro; // For TextMeshPro

public class DialDisplay_piTest : MonoBehaviour
{
    // Reference to the PiController
    private PiController piController;
    
    // UI elements to display dial values
    public TextMeshProUGUI[] dialTexts; // Array of text components for each dial
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get reference to the PiController singleton
        piController = PiController.S;
        
        // Check if we have enough text components for our dials
        if (dialTexts == null || dialTexts.Length < 2)
        {
            Debug.LogWarning("DialDisplay_piTest: Not enough text components assigned for the dials!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Only update if PiController is available and active
        if (piController != null && piController.controllerActive)
        {
            // Update text for each dial
            for (int i = 0; i < 2; i++) // We now have 2 dials
            {
                if (i < dialTexts.Length && dialTexts[i] != null)
                {
                    int dialValue = piController.GetDialValue(i);
                    string directionText = "";
                    
                    // Convert dial value to readable text
                    switch (dialValue)
                    {
                        case 0:
                            directionText = "No rotation";
                            break;
                        case 1:
                            directionText = "Counter-clockwise";
                            break;
                        case 2:
                            directionText = "Clockwise";
                            break;
                        case 3:
                            directionText = "Button pressed";
                            break;
                        default:
                            directionText = "Unknown";
                            break;
                    }
                    
                    dialTexts[i].text = $"Dial {i+1}: {directionText}";
                }
            }
        }
        else
        {
            // Display message if controller is not available
            for (int i = 0; i < dialTexts.Length; i++)
            {
                if (dialTexts[i] != null)
                {
                    dialTexts[i].text = $"Dial {i+1}: Controller not active";
                }
            }
        }
    }
}
