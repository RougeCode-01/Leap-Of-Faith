using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] public int healthPoints = 3; // Initial health points
    [SerializeField] public int eggAmount = 3; // Initial egg amount
    [SerializeField] private Transform startingPosition; // Reference to the starting position
    [SerializeField] private float fallDamageThreshold = -10f; // Threshold for fall damage

    private Rigidbody _rigidbody;
    private float _lastYVelocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Check if health points are zero or less
        if (healthPoints <= 0)
        {
            HealthDepletion();
        }

        // Track the player's vertical velocity
        _lastYVelocity = _rigidbody.velocity.y;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        // Check if collided with an enemy
        if (collision.gameObject.CompareTag("Enemies"))
        {
            healthPoints -= 3; // Decrease health points by 3
        }
        // Check if collided with a cliff
        else if (collision.gameObject.CompareTag("Cliff"))
        {
            healthPoints--; // Decrease health points by 1
        }
        // Check if collided with the ground
        else if (collision.gameObject.CompareTag("Ground"))
        {
            if (_lastYVelocity < fallDamageThreshold)
            {
                TakeFallDamage();
            }
        }
    }
    
    private void TakeFallDamage()
    {
        healthPoints--; // Decrease health points by 1 for fall damage
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
        SceneManager.LoadScene("GameOver");
    }
}