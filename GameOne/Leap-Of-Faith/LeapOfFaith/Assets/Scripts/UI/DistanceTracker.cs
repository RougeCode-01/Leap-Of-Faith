using UnityEngine;
using UnityEngine.UI;

public class DistanceTracker : MonoBehaviour
{
    [SerializeField] private Slider distanceSlider; // Reference to the distance slider
    [SerializeField] private Transform player; // Reference to the player transform
    [SerializeField] private Transform startPoint; // Reference to the start point transform
    [SerializeField] private Transform endPoint; // Reference to the end point transform

    private float totalDistance; // Total distance between start and end points

    private void Start()
    {
        // Calculate the total distance between start and end points
        totalDistance = Vector3.Distance(startPoint.position, endPoint.position);
        // Initialize the slider max value
        distanceSlider.maxValue = totalDistance;
    }

    private void Update()
    {
        // Calculate the distance traveled by the player
        float distanceTraveled = Vector3.Distance(startPoint.position, player.position);
        // Update the slider value
        distanceSlider.value = distanceTraveled;
    }
}