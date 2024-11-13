using UnityEngine;
using TMPro;

public class TimerGameOver : MonoBehaviour
{
    public float startTimeInSeconds = 180f;  // Starting time (3 minutes)
    public TextMeshProUGUI timerText;  // TextMeshProUGUI component to display the timer
    private float remainingTime;
    private bool timerRunning = true;
    public GameObject showThis;
    public GameObject pauseMenu;
    public PlayerControl playerControl;
    private bool isPaused = false;  // Initialize as false
    public bool canPaused = false;  // Can be paused or not, depending on your conditions

    private void Start()
    {
        remainingTime = startTimeInSeconds;  // Initialize remaining time to 3 minutes
        UpdateTimerDisplay();  // Update the timer display at the start
        showThis.SetActive(false);
        playerControl.enabled = true;
        canPaused = false;

        // Ensure Time.timeScale is reset at the start of the game
        Time.timeScale = 1f;
    }

    private void Update()
    {
        // Handle the timer countdown
        if (timerRunning)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                remainingTime = 0;
                timerRunning = false;
                UpdateTimerDisplay();
                GameOver();  // Trigger Game Over when the time is up
            }
        }

        // Pausing functionality
        if (Input.GetKeyDown(KeyCode.Escape) && canPaused)
        {
            TogglePause();  
        }
    }

    private void TogglePause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f;  
            pauseMenu.SetActive(true);  
            Debug.Log("Game Paused");
            isPaused = true;  
        }
        else
        {
            Time.timeScale = 1f;  
            pauseMenu.SetActive(false);  
            Debug.Log("Game Unpaused");
            isPaused = false;
        }
    }

    public void CanPauseTG()
    {
        // This function allows the game to pause depending on other game conditions
        canPaused = true;
    }

    private void UpdateTimerDisplay()
    {
        // Convert remaining time to minutes and seconds
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        // Update the timer text in MM:SS format
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void GameOver()
    {
        // Handle Game Over
        canPaused = false;
        showThis.SetActive(true);  // Show Game Over UI
        Time.timeScale = 0f;  // Pause the game when time's up
        playerControl.enabled = false;  // Disable player movement
    }
}