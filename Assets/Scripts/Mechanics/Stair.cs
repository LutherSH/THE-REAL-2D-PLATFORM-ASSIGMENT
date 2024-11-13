using System.Security.Cryptography;
using UnityEngine;

public class Stair : MonoBehaviour
{
    // Adjustable offset for how much higher the player will teleport
    public float teleportHeight = 5f;
    public float teleportHeight2 = 5f;
    public bool bottomPart;
    public bool topPart;

    // Reference to the player GameObject (assign in Inspector)
    public GameObject player;

    // Boolean to check if player is in the trigger zone
    private bool isPlayerInTrigger = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T) && isPlayerInTrigger == true)
        {
            TeleportPlayerUpwards();
        }

        if(Input.GetKeyDown(KeyCode.G) && isPlayerInTrigger == true)
        {
            TeleportPlayerDownwards();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has entered the trigger zone
        if (other.gameObject == player)
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player has exited the trigger zone
        if (other.gameObject == player)
        {
            isPlayerInTrigger = false;
        }
    }

    // Method to teleport the player upwards if they're in the trigger zone
    public void TeleportPlayerUpwards()
    {
        if (isPlayerInTrigger && topPart != true)
        {
            // Calculate the new position by adding the offset to the player's current position
            Vector3 newPosition = player.transform.position + new Vector3(0, teleportHeight, 0);

            // Set the player's position to the new position
            player.transform.position = newPosition;
        }
    }

        public void TeleportPlayerDownwards()
    {
        if (isPlayerInTrigger && bottomPart != true)
        {
            // Calculate the new position by adding the offset to the player's current position
            Vector3 newPosition = player.transform.position + new Vector3(0, -teleportHeight2, 0);

            // Set the player's position to the new position
            player.transform.position = newPosition;
        }
    }
}
