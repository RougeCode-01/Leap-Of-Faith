using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f; // Speed of the player on the ground
    [SerializeField] private float jumpForce = 10.0f; // Force applied when the player jumps
    [SerializeField] private float jumpCost = 0.5f; // Stamina cost for jumping
    [SerializeField] private float walkCost = 0.1f; // Stamina cost for walking
    private Rigidbody _rigidbody; // Reference to the Rigidbody component
    private Controls _controls; // Reference to the Controls component
    private Stamina _stamina; // Reference to the Stamina component

    private void Awake()
    {
        // Get the Rigidbody and Stamina components
        _rigidbody = GetComponent<Rigidbody>();
        _stamina = GetComponent<Stamina>();
    }

    public void Initialize(Controls controls)
    {
        // Initialize the controls
        _controls = controls;
    }

    public void Move()
    {
        // Read the input for movement
        Vector2 input = _controls.Movement.WASD.ReadValue<Vector2>();

        // Check if there is input and enough stamina for walking
        if ((input.x != 0 || input.y != 0) && _stamina.UsingStamina(walkCost))
        {
            // Calculate the direction and set the velocity
            Vector3 direction = new Vector3(input.x, 0, input.y) * speed;
            Vector3 velocity = _rigidbody.velocity;
            velocity.x = direction.x;
            velocity.z = direction.z;
            _rigidbody.velocity = velocity;
        }
    }

    public void Jump()
    {
        // Check if there is enough stamina for jumping
        if (_stamina.UsingStamina(jumpCost))
        {
            // Apply force for jumping
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}