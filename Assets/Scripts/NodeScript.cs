using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NodeScript : MonoBehaviour
{
    [Header("References")]
    public GameObject target;
    public GameObject textImage;
    
    // Public access needed by NodeManager
    public bool selected;
    public Vector2 currentPosition;
    public Vector2 targetPosition;
    public int nodeNumber; // The node's assigned number
    
    private float locX, locY;
    private Transform childTransform;
    private Controller controller;
    private float currentRotation;
    private float targetRotation;
    
    private float ActualMoveSpeed => NodeManager.S.maxMoveSpeed;
    private bool movementPaused = false;
    private bool isSnapped = false;
    private Vector2 snappedPosition;
    private bool canMove = false;

    void Start()
    {
        controller = Controller.S;  // Cache controller reference
        childTransform = transform.GetChild(0);
        
        // Initialize node position at (0,0)
        locX = 0;
        locY = 0;
        currentPosition = Vector2.zero;
        childTransform.localPosition = Vector2.zero;
        
        // Set random target position
        SetNewRandomTarget();
        
        textImage = GameObject.Find($"Image {nodeNumber}");

        // Start the delay coroutine
        StartCoroutine(EnableMovementAfterDelay());
    }

    private IEnumerator EnableMovementAfterDelay()
    {
        yield return new WaitForSeconds(NodeManager.S.initialDelay);
        canMove = true;
    }

    public void SetNodeNumber(int number)
    {
        nodeNumber = number;
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
        if (!selected || !canMove) return;

        // Always update rotation if we have a text image, regardless of movement
        if (textImage != null)
        {
            Vector2 currentPos = new Vector2(locX, locY);
            float xDistance = Mathf.Abs(targetPosition.x - currentPos.x);
            float yDistance = Mathf.Abs(targetPosition.y - currentPos.y);
            Vector2 distanceToTarget = new Vector2(xDistance, yDistance);
            float actualDistance = distanceToTarget.magnitude;
            textImage.GetComponent<TextTransform>().UpdateRotation(distanceToTarget);
        }

        // Only update position if not paused
        if (controller.controlling)
        {
            UpdatePosition();
        }

        // Update visuals
        childTransform.localPosition = new Vector3(locX, locY, 0);
        currentPosition = new Vector2(locX, locY);
    }

    void UpdatePosition()
    {
        float moveSpeed = ActualMoveSpeed;
        Vector2 currentPos = new Vector2(locX, locY);
        
        // Calculate normalized direction to target
        Vector2 directionToTarget = (targetPosition - currentPos).normalized;
        
        // Calculate distances for rotation
        float xDistance = Mathf.Abs(targetPosition.x - currentPos.x);
        float yDistance = Mathf.Abs(targetPosition.y - currentPos.y);
        Vector2 distanceToTarget = targetPosition - currentPos;  // Use actual vector difference

        // Calculate distortion amount based on distance (1 when far, 0 when close)
        float maxDistance = 10f; // Increased maximum distance for full distortion
        float distortionAmount = Mathf.Clamp01(distanceToTarget.magnitude / maxDistance);

        // This should probably happen in the TextEffectManager, but for now we're triggering it here
        TextEffectManager.S.SetDistortion(nodeNumber, distortionAmount);
        // Same
        AudioManager.S.NodeFilter(nodeNumber, distortionAmount);

        // Store old position in case we need to revert
        float oldX = locX;
        float oldY = locY;

        // Smoothly reduce speed as we get closer to target
        // Start slowdown at 2x precision distance, reach min speed at precision distance
        float slowdownStartDistance = NodeManager.S.precisionControlDistance * 2f;
        float distanceRatio = Mathf.Clamp01((distanceToTarget.magnitude - NodeManager.S.precisionControlDistance) / 
                                          (slowdownStartDistance - NodeManager.S.precisionControlDistance));
        float originalSpeed = moveSpeed;
        // Use minMoveSpeed as the base for precision movement instead of a multiplier
        float precisionSpeed = NodeManager.S.minMoveSpeed;
        moveSpeed = Mathf.Lerp(precisionSpeed, moveSpeed, distanceRatio);
        
        // Apply Time.deltaTime to make movement frame-rate independent
        float frameSpeed = moveSpeed * Time.deltaTime;
    
        
        switch (controller.GetDialValue(0))  // X movement
        {
            case 1: locX -= frameSpeed; break;
            case 2: locX += frameSpeed; break;
        }
        
        switch (controller.GetDialValue(1))  // Y movement
        {
            case 1: locY -= frameSpeed; break;
            case 2: locY += frameSpeed; break;
        }

        // Check if new position is within visible space (5 unit radius circle)
        Vector2 newPos = new Vector2(locX, locY);
        if (newPos.magnitude > 5f)
        {
            // If outside bounds, revert to old position
            locX = oldX;
            locY = oldY;
        }
    }

    public void Deselect()
    {
        selected = false;
        // "Mostly" turn off the associated distortion effect
        TextEffectManager.S.SetDistortion(nodeNumber, 0.1f);
        // Disable the image
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }

}
