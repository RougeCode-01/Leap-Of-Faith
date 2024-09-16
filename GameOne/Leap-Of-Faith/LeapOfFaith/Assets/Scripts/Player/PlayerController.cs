using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool _isGrounded;
    private GroundMovement _groundMovement;
    private AirMovement _airMovement;
    private Controls _controls;

    private void Awake()
    {
        _groundMovement = GetComponent<GroundMovement>();
        _airMovement = GetComponent<AirMovement>();
        _controls = new Controls(); // Initialize the Controls object
        _groundMovement.Initialize(_controls);
        _airMovement.Initialize(_controls);
    }

    private void OnEnable()
    {
        _controls.Enable(); // Enable the Controls object
    }

    private void OnDisable()
    {
        _controls.Disable(); // Disable the Controls object
    }

    private void FixedUpdate()
    {
        // Update movements based on ground check
        if (_isGrounded)
        {
            Debug.Log("Player is grounded. Calling Move.");
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }

    public bool IsGrounded()
    {
        return _isGrounded;
    }
}