using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool _isGrounded; // Flag to check if the player is grounded
    private GroundMovement _groundMovement; // Reference to the GroundMovement component
    private AirMovement _airMovement; // Reference to the AirMovement component
    private Controls _controls; // Reference to the Controls component

    private void Awake()
    {
        // Get the GroundMovement and AirMovement components
        _groundMovement = GetComponent<GroundMovement>();
        _airMovement = GetComponent<AirMovement>();
        _controls = new Controls(); // Initialize the Controls object
        _groundMovement.Initialize(_controls);
        _airMovement.Initialize(_controls);
    }

    private void OnEnable()
    {
        // Enable the Controls object
        _controls.Enable();
    }

    private void OnDisable()
    {
        // Disable the Controls object
        _controls.Disable();
    }

    private void FixedUpdate()
    {
        // Update movements based on ground check
        if (_isGrounded)
        {
            _groundMovement.Move();
        }
        else
        {
            _airMovement.HandleAirMovement();
        }
    }

    private void Update()
    {
        // Handle jumping in Update to ensure it responds to input
        if (_isGrounded && _controls.Movement.Jump.triggered)
        {
            _groundMovement.Jump();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if collided with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // Check if staying in contact with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if exited contact with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }

    public bool IsGrounded()
    {
        // Return the grounded state
        return _isGrounded;
    }
}