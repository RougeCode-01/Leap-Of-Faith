using UnityEngine;

public class Crow : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f; // Speed of the crow
    [SerializeField] private float radius = 5.0f; // Radius of the circular path
    [SerializeField] private float height = 5.0f; // Height variation of the path
    private Vector3 _center; // Center point of the circular path
    private float _angle; // Current angle in the circular path

    private void Start()
    {
        _center = transform.position; // Set the center point to the initial position
    }

    private void Update()
    {
        _angle += speed * Time.deltaTime; // Increment the angle based on speed and time

        // Calculate the offset for circular movement
        var offset = new Vector3(Mathf.Sin(_angle), 0, Mathf.Cos(_angle)) * radius;
        // Update the position with the circular offset and height variation
        transform.position = _center + offset + new Vector3(0, Mathf.Sin(_angle) * height, 0);
    }
}