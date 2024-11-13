using UnityEditor.Callbacks;
using UnityEngine;

public class opening : MonoBehaviour
{/// <summary>
/// /////////////////////////////////////////////////////////////////////////////////
/// </summary>
    public GameObject player;               public GameObject cldEvready;
    public Transform object1;               public Animator taskPopAN;
    public Transform object2;               public TimerGameOver timerGameOver;
    public GameObject showThis;
    public GameObject elDoor;
    public GameObject barrier;
    public float floatDuration = 5f;  
    public float layerChangeDelay = 1.5f;
    private float elapsedTime = 0f;
    private bool isFloating = true;
    public GameObject insideEV;
    public Animator animator;

/// <summary>
/// ////////////////////////////////////////////////////////////////////////////////////
/// </summary>
    private BoxCollider2D playerCollider;
    private MonoBehaviour playerMovementScript;  // The player's movement script type
    //private Rigidbody2D rb;

    private void Start()
    {
        // Get references to the player's components
        playerCollider = player.GetComponent<BoxCollider2D>();
        playerMovementScript = player.GetComponent<PlayerControl>();
        //rb = player.GetComponent<Rigidbody2D>();

        // Set the player's position to the starting point (Object1)
        player.transform.position = object1.position;

        // Disable movement and collider
        if (playerMovementScript != null) playerMovementScript.enabled = false;
        if (playerCollider != null) playerCollider.enabled = false;
        insideEV.SetActive(true);
        animator.SetBool("isRLX?" , true);
        cldEvready.SetActive(true);
        //if (rb != null) rb.enabled = false;
    }

    private void Update()
{
        // Handle floating from Object1 to Object2
        if (isFloating)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / floatDuration;
            player.transform.position = Vector3.Lerp(object1.position, object2.position, t);

            // Check if floating time is complete
            if (elapsedTime >= floatDuration)
            {
                isFloating = false;
                EnablePlayerControls();

                // Start the delayed layer change for Paint
                Invoke("ChangePaintLayer", layerChangeDelay);
            }
        }
    }

    private void EnablePlayerControls()
    {
        // Re-enable the player's movement script and collider
        if (playerMovementScript != null) playerMovementScript.enabled = true;
        if (playerCollider != null) playerCollider.enabled = true;
        insideEV.SetActive(false);
        showThis.SetActive(true);
        animator.SetBool("isRLX?" , false);
        taskPopAN.SetBool("StartPop?" , true);
        timerGameOver.CanPauseTG();
    }

     private void ChangePaintLayer()
    {
        // Change the sorting layer of the Paint object
        SpriteRenderer paintRenderer = elDoor.GetComponent<SpriteRenderer>();
        if (paintRenderer != null)
        {
            paintRenderer.sortingOrder = 0;  // Set this to the desired layer order
        }
        barrier.SetActive(false);
    }
}
