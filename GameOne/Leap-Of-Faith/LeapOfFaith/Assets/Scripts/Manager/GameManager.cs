using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseGame();
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            QuitGame();
        }
    }

    private void TogglePauseGame()
    {
        _isPaused = !_isPaused;
        Time.timeScale = _isPaused ? 0 : 1;
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        SceneManager.LoadScene("GameFinished");
    }
}