using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel; // Reference to the pause panel UI
    private bool _isPaused = false; // Flag to check if the game is paused
    public static GameManager Instance { get; private set; } // Singleton instance of GameManager

    private void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist GameManager across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameManager
        }

        // Initialize the pause panel state
        pausePanel.SetActive(_isPaused);
    }

    private void Update()
    {
        // Toggle pause state when Escape or P is pressed
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseGame();
        }
        // Quit game when F5 is pressed
        if (Input.GetKeyDown(KeyCode.F5))
        {
            QuitGame();
        }
    }

    public void TogglePauseGame()
    {
        // Toggle the pause state
        _isPaused = !_isPaused;
        // Set the time scale to 0 if paused, 1 if not
        Time.timeScale = _isPaused ? 0 : 1;
        // Show or hide the pause panel
        TogglePausePanel(_isPaused);
    }

    public void TogglePausePanel(bool show)
    {
        // Set the active state of the pause panel
        pausePanel.SetActive(show);
    }

    private void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // End the game if the player collides with the GameManager
        if (collision.gameObject.CompareTag("Player"))
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        // Load the GameFinished scene
        SceneManager.LoadScene("GameFinished");
    }
}