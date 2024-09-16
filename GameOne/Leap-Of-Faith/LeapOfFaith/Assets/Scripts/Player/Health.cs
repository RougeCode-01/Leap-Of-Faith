using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] public int healthPoints = 3; // Initial health points
    [SerializeField] public int eggAmount = 3; // Initial egg amount
    [SerializeField] private Transform startingPosition; // Reference to the starting position

    private void Update()
    {
        // Check if health points are zero or less
        if (healthPoints <= 0)
        {
            HealthDepletion();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if collided with an enemy
        if (collision.gameObject.CompareTag("Enemies"))
        {
            healthPoints -= 3; // Decrease health points by 3
        }
        // Check if collided with a cliff
        if (collision.gameObject.CompareTag("Cliff"))
        {
            healthPoints--; // Decrease health points by 1
        }
    }

    private void HealthDepletion()
    {
        // Decrease egg amount
        eggAmount--;

        // Check if egg amount is zero
        if (eggAmount <= 0)
        {
            EndGame(); // End the game
        }
        else
        {
            ResetPlayer(); // Reset player's position and health points
        }
    }

    public void ResetPlayer()
    {
        // Reset player's position and health points
        transform.position = startingPosition.position;
        healthPoints = 3;
    }

    private void EndGame()
    {
        // Log game over message and load the GameOver scene
        Debug.Log("Game Over!");
        SceneManager.LoadScene("GameOver");
    }
}