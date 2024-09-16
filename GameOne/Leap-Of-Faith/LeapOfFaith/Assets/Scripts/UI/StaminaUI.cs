using System;
using UnityEngine;
using UnityEngine.UI;

public class StaminaUI : MonoBehaviour
{
    [SerializeField] private Slider staminaSlider;// Reference to the Stamina Slider
    [SerializeField] private Stamina playerStamina;// Reference to the player's Stamina script
    
    private void Update()
    {
        staminaSlider.value = playerStamina.GetCurrentStamina();
    }
}
