using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class NodeManager : MonoBehaviour
{
    public GameObject nodePrefab;  // Assign your Node prefab in the Inspector
    public float spawnThreshold = 0.5f;  // How close to target before allowing spawn
    public Material lineMaterial;  // Assign a material in the inspector for the line
    public int maxNodes = 5;  // Number of nodes before reset
    public float returnSpeed = 2f;  // Speed of return to center
    public float centerThreshold = 0.1f;  // How close to center before considering "arrived"
    public float colorTransitionDistance = 4f;  // Distance over which color transition occurs
    public float lineDrawDuration = 3f;  // Duration of the line drawing animation

    [Header("Node Movement Settings")]
    public float proximityThreshold = 1f;
    public float precisionControlDistance = 0.5f; // Distance at which to start precise movement
    public float initialDelay = 1f; // Delay before node becomes controllable
    public float minMoveSpeed = 0.2f; // Minimum movement speed
    public float maxMoveSpeed = 10f; // Maximum movement speed

    public NodeScript currentNode;
    public List<NodeScript> nodeHistory = new List<NodeScript>();
    private List<LineRenderer> lines = new List<LineRenderer>();
    private Controller controller;
    private bool isFirstNode = true;  // Track if this is the first node
    private bool isReturning = false;
    private int nextNodeNumber = 0; // Track the next node number to assign, starting at 0
    private bool isDrawingLine = false;

    private RectTransform rectTransform;
    private Vector3 worldSpaceOffset;

    public static NodeManager S;

    void Awake()
    {
        S = this;
        rectTransform = GetComponent<RectTransform>();
        UpdateWorldSpaceOffset();
    }

    void UpdateWorldSpaceOffset()
    {
        if (rectTransform != null)
        {
            worldSpaceOffset = rectTransform.position;
        }
        else
        {
            worldSpaceOffset = Vector3.zero;
            Debug.LogWarning("NodeManager: RectTransform component not found!");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = FindObjectOfType<Controller>();
        
        if (nodePrefab == null)
        {
            Debug.LogError("Node Prefab not assigned!");
            return;
        }
        SpawnNewNode();  // Spawn initial node
    }
      


    // Update is called once per frame
    void Update()
    {
        if (currentNode != null && !isReturning)
        {
            Vector2 currentPos = currentNode.currentPosition;
            Vector2 targetPos = currentNode.targetPosition;
            float distance = Vector2.Distance(currentPos, targetPos);
            
            // Calculate normalized distance using the larger colorTransitionDistance
            float normalizedDistance = Mathf.Clamp01(distance / colorTransitionDistance);
            
            // Update the material property for all lines
            if (lineMaterial != null)
            {
                lineMaterial.SetFloat("_DistanceToTarget", normalizedDistance);
            }
            
            UpdateLines();
            
            if (distance < spawnThreshold)
            {
                nodeHistory.Add(currentNode);
                CreateNewLine(currentNode.currentPosition);
                // Clear the Filter
                AudioManager.S.NodeClearFilter(currentNode.nodeNumber);
                // Play the Chime
                AudioManager.S.PlayChime();
                
                // Check if we've reached max nodes
                if (nodeHistory.Count >= maxNodes - 1)
                {
                    StartCoroutine(ReturnToCenter());
                }
                else
                {
                    // Spawn a New Node
                    SpawnNewNode();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ReturnToCenter());
        }
    }

    IEnumerator ReturnToCenter()
    {
        // Reset the Node Notes
        AudioManager.S.ResetNodeNotes();
        AudioManager.S.PlayWah();
        
        isReturning = true;
        controller.controlling = false;

        Vector2 center = Vector2.zero;

        currentNode.Deselect();

        while (true)
        {
            bool allAtCenter = true;
            
            // Update and check all lines
            UpdateLines();
            
            // Check if all line endpoints are at center
            foreach (LineRenderer line in lines)
            {
                Vector2 startPos = line.GetPosition(0);
                Vector2 endPos = line.GetPosition(1);
                
                if (Vector2.Distance(startPos, center) > centerThreshold ||
                    Vector2.Distance(endPos, center) > centerThreshold)
                {
                    allAtCenter = false;
                    break;
                }
            }
            
            // If all lines are at center, break the loop
            if (allAtCenter)
            {
                break;
            }
            
            yield return null;
        }

        // Clean up and restart
        foreach (NodeScript node in nodeHistory)
        {
            Destroy(node.gameObject);
        }
        foreach (LineRenderer line in lines)
        {
            Destroy(line.gameObject);
        }
        if (currentNode != null)
        {
            Destroy(currentNode.gameObject);
        }
        
        // Clear lists
        nodeHistory.Clear();
        lines.Clear();
        
        // Reset flags
        isReturning = false;
        isFirstNode = true;
        nextNodeNumber = 0; // Reset the node counter to 0

        // Hide the nodes while the Text is Displayed
        foreach (NodeScript node in nodeHistory)
        {
            node.Deselect();
        }

        // Display the Full Text
        TextManager.S.FadeTextTransition();       

        // Try Playing the Audio Here?
        AudioManager.S.PlayPhrase(GameManager.S.stage);
 
    }

    public void NewSequence()
    {
        // Increase the stage
        GameManager.S.NextStage();
        // Start new sequence
        SpawnNewNode();
        // Get New Text
        TextManager.S.GetText();
        // Reset the distortion effects
        TextEffectManager.S.ResetDistortion(); 
        controller.controlling = true;
 
    }
    

    void CreateNewLine(Vector3 startPos)
    {
        GameObject lineObj = new GameObject("Line_" + lines.Count);
        LineRenderer newLine = lineObj.AddComponent<LineRenderer>();
        
        newLine.material = lineMaterial;
        newLine.startWidth = 0.1f;
        newLine.endWidth = 0.1f;
        newLine.positionCount = 2;
        newLine.useWorldSpace = true;
        newLine.SetPosition(0, startPos + worldSpaceOffset);
        newLine.SetPosition(1, startPos + worldSpaceOffset);  // Start with both points at the same position
        
        lines.Add(newLine);
        
        // Start the line drawing animation
        StartCoroutine(AnimateLineDrawing(newLine, startPos + worldSpaceOffset, Vector3.zero + worldSpaceOffset));
    }

    private IEnumerator AnimateLineDrawing(LineRenderer line, Vector3 startPos, Vector3 endPos)
    {
        controller.controlling = false;
        isDrawingLine = true;
        float elapsedTime = 0f;
        
        while (elapsedTime < lineDrawDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / lineDrawDuration;
            
            // Use a smooth step function for more natural animation
            t = Mathf.SmoothStep(0f, 1f, t);
            
            // Update the end position of the line
            line.SetPosition(1, Vector3.Lerp(startPos, endPos, t));
            
            yield return null;
        }
        
        // Ensure the line ends exactly at the target position
        line.SetPosition(1, endPos);
        isDrawingLine = false;
        controller.controlling = true;
    }

    void UpdateLines()
    {
        for (int i = 0; i < lines.Count; i++)
        {
            if (isReturning)
            {
                // During return sequence, all lines converge to center
                Vector2 startPos = lines[i].GetPosition(0);
                Vector2 newStartPos = Vector2.MoveTowards(startPos, Vector2.zero + (Vector2)worldSpaceOffset, returnSpeed * Time.deltaTime);
                Vector2 endPos = lines[i].GetPosition(1);
                Vector2 newEndPos = Vector2.MoveTowards(endPos, Vector2.zero + (Vector2)worldSpaceOffset, returnSpeed * Time.deltaTime);
                
                lines[i].SetPosition(0, newStartPos);
                lines[i].SetPosition(1, newEndPos);
            }
            else if (!isDrawingLine)  // Only update line positions if we're not currently drawing a new line
            {
                // Normal line updating during gameplay
                if (i < nodeHistory.Count && i + 1 < nodeHistory.Count)
                {
                    lines[i].SetPosition(0, nodeHistory[i].currentPosition + (Vector2)worldSpaceOffset);
                    lines[i].SetPosition(1, nodeHistory[i + 1].currentPosition + (Vector2)worldSpaceOffset);
                }
                else if (i == lines.Count - 1 && currentNode != null)
                {
                    // Update last line to connect to current node
                    lines[i].SetPosition(0, nodeHistory[i].currentPosition + (Vector2)worldSpaceOffset);
                    lines[i].SetPosition(1, currentNode.currentPosition + (Vector2)worldSpaceOffset);
                }
            }
        }
    }

    void SpawnNewNode()
    {
        Debug.Log("SpawnNewNode called");
        
        if (currentNode != null)
        {
            currentNode.Deselect();
        }
        
        GameObject newNode = Instantiate(nodePrefab, Vector3.zero, Quaternion.identity);
        newNode.transform.SetParent(transform, false);
        currentNode = newNode.GetComponent<NodeScript>();
        
        if (currentNode == null)
        {
            Debug.LogError("NodeScript component not found on spawned prefab!");
            return;
        }

        // Assign the node number
        currentNode.SetNodeNumber(nextNodeNumber++);



        // Calculate target position
        Vector2 targetPosition = Vector2.zero;
        if (nodeHistory.Count > 0)
        {
            // Get the last node's target position
            Vector2 lastTargetPos = nodeHistory[nodeHistory.Count - 1].targetPosition;
            
            // Try to find a valid target position
            int attempts = 0;
            const int maxAttempts = 100;
            bool validPositionFound = false;
            
            while (!validPositionFound && attempts < maxAttempts)
            {
                float randomAngle = Random.Range(0f, 360f);
                float randomDistance = Random.Range(2f, 4f); // At least 2 units away, up to 4
                targetPosition = lastTargetPos + (Vector2)(Quaternion.Euler(0, 0, randomAngle) * Vector2.right * randomDistance);
                
                // Check if position is both far enough from last target AND within the 5-unit radius circle
                if (Vector2.Distance(targetPosition, lastTargetPos) >= 2f && 
                    Vector2.Distance(targetPosition, Vector2.zero) <= 5f)
                {
                    validPositionFound = true;
                }
                
                attempts++;
            }
            
            // If we couldn't find a valid position, default to a position on the circle boundary
            if (!validPositionFound)
            {
                Debug.LogWarning("Could not find valid target position, defaulting to circle boundary");
                Vector2 directionFromCenter = (lastTargetPos - Vector2.zero).normalized;
                targetPosition = directionFromCenter * 5f; // Place on the circle boundary
            }
        }
        
        // Set the target position
        currentNode.targetPosition = targetPosition;

        // Select the new node
        currentNode.selected = true;

        // Get the sprite object (first child) and set visibility
        Transform newNodeSprite = newNode.transform.GetChild(0);
        if (newNodeSprite != null)
        {
            SpriteRenderer newNodeRenderer = newNodeSprite.GetComponent<SpriteRenderer>();
            if (newNodeRenderer != null)
            {
                newNodeRenderer.enabled = true; // Always show the sprite now
            }
        }

        isFirstNode = false;

        // Only after it's all set uplay the Node Note
        AudioManager.S.PlayNodeNote(nextNodeNumber-1);
    }
}
