using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager S;
    private RectTransform canvasRect;

    void Awake()
    {
        S = this;
        canvasRect = GetComponent<RectTransform>();
    }

    public void SetCanvasXPosition(float xPosition)
    {
        if (canvasRect != null)
        {
            Vector2 currentPosition = canvasRect.anchoredPosition;
            currentPosition.x = xPosition;
            canvasRect.anchoredPosition = currentPosition;
        }
    }
} 