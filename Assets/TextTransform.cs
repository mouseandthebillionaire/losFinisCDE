using UnityEngine;

public class TextTransform : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float maxRotationAngle = 45f;
    public float rotationSpeed = 2f;
    
    private Vector2 originalRotation;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetRandomRotation();
    }

    private void SetRandomRotation(){
        float randomZRotation = Random.Range(-maxRotationAngle, maxRotationAngle);
        float randomYRotation = Random.Range(-maxRotationAngle, maxRotationAngle);
        transform.rotation = Quaternion.Euler(0, randomYRotation, randomZRotation);
        originalRotation = new Vector2(randomZRotation, randomYRotation);
    }

    public void UpdateRotation(Vector2 distanceToTarget){
        // Calculate rotation progress for both Z and Y axes
        float zRotationProgress = Mathf.Clamp01(1f - (Mathf.Abs(distanceToTarget.x) / 5f));
        float yRotationProgress = Mathf.Clamp01(1f - (Mathf.Abs(distanceToTarget.y) / 5f));
        
        // Calculate target rotations
        float targetZRotation = Mathf.LerpAngle(originalRotation.x, 0f, zRotationProgress);
        float targetYRotation = Mathf.LerpAngle(originalRotation.y, 0f, yRotationProgress);
        
        // Apply the rotations
        transform.rotation = Quaternion.Euler(0, targetYRotation, targetZRotation);
    }
}
