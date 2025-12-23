using UnityEngine;
using UnityEngine.SceneManagement; // Required for loading/restarting scenes

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI; 
    void Start()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Function to resume the game, often linked to a "Resume" button's OnClick() event
    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Hide the pause menu UI
        Time.timeScale = 1f;          // Resume normal game time
        GameIsPaused = false;
        // Optional: unlock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }

    // Function to pause the game, called internally or linked to a "Pause" button
    void Pause()
    {
        pauseMenuUI.SetActive(true); // Show the pause menu UI
        Time.timeScale = 0f;         // Stop all time-based operations
        GameIsPaused = true;
        // Optional: show and unlock the cursor so the user can interact with the menu
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Function to load the main menu, linked to a "Main Menu" button's OnClick() event
    public void LoadMenu()
    {
        Time.timeScale = 1f; // Ensure time is normal before loading a new scene
        SceneManager.LoadScene("Start Menu"); // Replace with your main menu scene name
    }

    // Function to quit the game, linked to a "Quit" button's OnClick() event
    public void QuitGame()
    {
        Application.Quit();
    }
}
