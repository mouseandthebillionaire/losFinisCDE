using UnityEngine;

public class NodeScript : MonoBehaviour
{
    [Header("Settings")]
    [Range(1, 10)]
    public float speedSetting = 5f;
    public float proximityThreshold = 1f;
    public float precisionControlDistance = 0.5f; // Distance at which to start precise movement
    public float precisionSpeedMultiplier = 0.2f; // How much to slow down when near target
    
    [Header("References")]
    public GameObject target;
    
    // Public access needed by NodeManager
    public bool selected;
    public Vector2 currentPosition;
    public Vector2 targetPosition;
    
    private float locX, locY;
    private Transform childTransform;
    private Controller controller;
    
    private float ActualMoveSpeed => Mathf.Lerp(0.001f, 0.005f, (speedSetting - 1f) / 9f);
    private bool movementPaused = false;
    private bool isSnapped = false;
    private Vector2 snappedPosition;

    void Start()
    {
        controller = Controller.S;  // Cache controller reference
        childTransform = transform.GetChild(0);
        SetNewRandomTarget();
    }

    void SetNewRandomTarget()
    {
        float angle = Random.Range(0f, 2f * Mathf.PI);
        float distance = Random.Range(2f, 5f);  // Simplified min/max radius
        
        targetPosition = new Vector2(
            distance * Mathf.Cos(angle),
            distance * Mathf.Sin(angle)
        );
        
        target.transform.localPosition = targetPosition;
    }

    void Update()
    {
        if (!selected || movementPaused) return;

        UpdatePosition();

        // Update visuals
        childTransform.localPosition = new Vector3(locX, locY, 0);
        currentPosition = new Vector2(locX, locY);
    }

    void UpdatePosition()
    {
        float moveSpeed = ActualMoveSpeed;
        float distanceToTarget = Vector2.Distance(new Vector2(locX, locY), targetPosition);

        // Reduce speed when close to target for more precise control
        if (distanceToTarget < precisionControlDistance)
        {
            moveSpeed *= precisionSpeedMultiplier;
        }
        
        switch (controller.GetDialValue(0))  // X movement
        {
            case 1: locX -= moveSpeed; break;
            case 2: locX += moveSpeed; break;
        }
        
        switch (controller.GetDialValue(1))  // Y movement
        {
            case 1: locY -= moveSpeed; break;
            case 2: locY += moveSpeed; break;
        }

        // Update visuals
        childTransform.localPosition = new Vector3(locX, locY, 0);
        currentPosition = new Vector2(locX, locY);
    }

    public void Deselect()
    {
        selected = false;
        Debug.Log("Deselecting node");
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }

    public void PauseMovement()
    {
        movementPaused = true;
    }

    public void ResumeMovement()
    {
        movementPaused = false;
    }
}
