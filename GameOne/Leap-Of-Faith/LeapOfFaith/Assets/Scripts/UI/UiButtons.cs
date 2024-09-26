using UnityEngine;
using UnityEngine.SceneManagement;

public class UiButtons : MonoBehaviour
{
    // Method to start the game by loading the SampleScene
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Method to quit the game application
    public void QuitGame()
    {
        Application.Quit();
    }

    // Method to restart the game by reloading the SampleScene
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Method to go back to the main menu by loading the MainMenu scene
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Method to resume the game by setting the timescale to 1 and hiding the pause panel
    public void ResumeGame()
    {
        Time.timeScale = 1;
        GameManager.Instance.TogglePausePanel(false);
    }
}