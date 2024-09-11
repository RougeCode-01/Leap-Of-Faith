using UnityEngine;

public class Crow : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f; // Speed of the crow
    [SerializeField] private float radius = 5.0f; // Radius of the circular path
    [SerializeField] private float height = 5.0f; // Height variation of the path
    [SerializeField] private Transform centerPoint; // Center point of the circular path
    private float _angle; // Current angle in the circular path

    private void Start()
    {
        if (centerPoint == null)
        {
            centerPoint = new GameObject("CenterPoint").transform;
            centerPoint.position = transform.position; // Set the center point to the initial position if not assigned
        }
    }

    private void Update()
    {
        _angle += speed * Time.deltaTime; // Increment the angle based on speed and time

        // Calculate the new position for circular movement
        Vector3 offset = new Vector3(Mathf.Cos(_angle), Mathf.Sin(_angle) * height, Mathf.Sin(_angle)) * radius;
        Vector3 newPosition = centerPoint.position + offset;

        // Update the position with the new calculated position
        transform.position = newPosition;

        // Make the bird look at the next position
        transform.LookAt(centerPoint.position + new Vector3(Mathf.Cos(_angle + 0.1f), Mathf.Sin(_angle + 0.1f) * height, Mathf.Sin(_angle + 0.1f)) * radius);
    }
}