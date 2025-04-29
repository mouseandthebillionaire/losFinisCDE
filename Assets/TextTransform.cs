using UnityEngine;

public class TextTransform : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float maxRotationAngle = 45f;
    public float rotationSpeed = 2f;
    
    private float originalRotation;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetRandomRotation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetRandomRotation(){
        float randomRotation = Random.Range(-maxRotationAngle, maxRotationAngle);
        transform.rotation = Quaternion.Euler(0, 0, randomRotation);
        originalRotation = randomRotation;
    }

    public void UpdateRotation(float distanceToTarget){
        float rotationProgress = Mathf.Clamp01(1f - (distanceToTarget / 5f)); // 5f is max distance
        float targetRotation = Mathf.LerpAngle(originalRotation, 0f, rotationProgress * rotationSpeed);
        transform.rotation = Quaternion.Euler(0, 0, targetRotation);
    }
}
