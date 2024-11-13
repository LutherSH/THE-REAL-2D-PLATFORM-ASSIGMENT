using UnityEngine;

public class CCTVMec : MonoBehaviour
{
    public Transform room1CameraPoint;      
    public Transform room2CameraPoint;
    public Transform room3CameraPoint;
    public Transform room4CameraPoint;
    public Transform mainCamera;  // The camera that will move to each room's position
    public Transform player;
    public GameObject cctvUI;  // UI containing room buttons (enable only in trigger zone)
    public CamFollow camFollow;

    public Animator cctvAN;
    //public bool interacted = false;
    
    private bool isPlayerInTrigger = false;

    private void Start()
    {
        cctvUI.SetActive(true);  // Hide CCTV UI at the start
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            //cctvUI.SetActive(true);  // Show CCTV UI when player enters the trigger
            cctvAN.SetBool("cctvON?" , true);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //if(interacted == true)
            //{
                isPlayerInTrigger = false;
                //cctvUI.SetActive(false);
                cctvAN.SetBool("cctvON?" , false);
                ResetCamera();  // Reset camera to default view when player leaves the trigger               
            //}

            //if(interacted == false)
            //{
                //isPlayerInTrigger = false;
                //cctvUI.SetActive(false);  // Hide CCTV UI when player exits the trigger                
            //}
        }

    }

    public void ViewRoom1()
    {
        if (isPlayerInTrigger)
        {
            camFollow.enabled = false;
            mainCamera.position = room1CameraPoint.position;  // Move camera to room 1
        }
    }

    public void ViewRoom2()
    {
        if (isPlayerInTrigger)
        {
            camFollow.enabled = false;
            mainCamera.position = room2CameraPoint.position;  // Move camera to room 2
        }
    }

    public void ViewRoom3()
    {
        if (isPlayerInTrigger)
        {
            camFollow.enabled = false;
            mainCamera.position = room3CameraPoint.position;  // Move camera to room 2
        }
    }

    public void ViewRoom4()
    {
        if (isPlayerInTrigger)
        {
            camFollow.enabled = false;
            mainCamera.position = room4CameraPoint.position;  // Move camera to room 2
        }
    }

    public void ResetCamera()
    {
        // You can set this to any default position you want
        //mainCamera.localPosition = player.position;
        camFollow.enabled = true;
    }
}