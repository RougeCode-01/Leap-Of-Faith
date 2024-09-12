using System;
using UnityEngine;
using UnityEngine.UI;

public class StaminaUI : MonoBehaviour
{
    [SerializeField] private Slider staminaSlider;
    [SerializeField] private Stamina playerStamina;

    private void Update()
    {
        staminaSlider.value = playerStamina.GetCurrentStamina();
    }
}
