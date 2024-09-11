using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image[] healthImages; // Array of Image components for health
    [SerializeField] private Image[] eggImages; // Array of Image components for eggs
    [SerializeField] private Sprite fullHealthSprite; // Sprite for full health
    [SerializeField] private Sprite emptyHealthSprite; // Sprite for empty health
    [SerializeField] private Sprite fullEggSprite; // Sprite for full egg
    [SerializeField] private Sprite emptyEggSprite; // Sprite for empty egg
    [SerializeField] private Health playerHealth; // Reference to the player's Health script

    // Update is called once per frame
    void Update()
    {
        // Update the health images
        for (int i = 0; i < healthImages.Length; i++)
        {
            if (i < playerHealth.healthPoints)
            {
                healthImages[i].sprite = fullHealthSprite;
            }
            else
            {
                healthImages[i].sprite = emptyHealthSprite;
            }
        }

        // Update the egg images
        for (int i = 0; i < eggImages.Length; i++)
        {
            if (i < playerHealth.eggAmount)
            {
                eggImages[i].sprite = fullEggSprite;
            }
            else
            {
                eggImages[i].sprite = emptyEggSprite;
            }
        }
    }
}