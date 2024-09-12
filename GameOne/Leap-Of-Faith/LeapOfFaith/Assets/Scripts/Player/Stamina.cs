using System;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    [SerializeField] private float maxStamina = 100.0f; // Maximum stamina value
    [SerializeField] private float foodGain = 20.0f; // Stamina gained from food
    private float currentStamina = 100.0f;
    private Health _health;
    
    private void Awake()
    {
        _health = GetComponent<Health>();
    }
    
    private void Start()
    {
        currentStamina = maxStamina; // Set current stamina to maximum stamina
    }
    
    private void Update()
    {
        //respawn player if stamina is 0
        if (currentStamina <= 0)
        {
            _health.ResetPlayer();
        }
    }
    
    public bool UsingStamina(float amount)
    {
        // Check if the player has enough stamina to use
        if (currentStamina >= amount)
        {
            currentStamina -= amount; // Decrease current stamina by the amount used
            return true;
        }
        return false;
    }
    
    public float GetCurrentStamina()
    {
        return currentStamina; // Return the current stamina value
    }
    
    private void GainStamina(float amount)
    {
        currentStamina += amount; // Increase current stamina by the amount gained
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if collided with a food item
        if (other.CompareTag("Food"))
        {
            GainStamina(foodGain); // Increase stamina by 10
            Destroy(other.gameObject); // Destroy the food item
        }
    }
}
