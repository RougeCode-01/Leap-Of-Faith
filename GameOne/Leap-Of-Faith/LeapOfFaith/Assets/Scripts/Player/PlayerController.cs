using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GroundMovement _groundMovement;
    private AirMovement _airMovement;
    private Controls _controls;
    private bool _isGrounded;

    private void Awake()
    {
        // Get references to GroundMovement and AirMovement components
        _groundMovement = GetComponent<GroundMovement>();
        _airMovement = GetComponent<AirMovement>();
        
        // Initialize the Controls instance
        _controls = new Controls();
        
        // Pass the Controls instance to GroundMovement and AirMovement
        _groundMovement.Initialize(_controls);
        _airMovement.Initialize(_controls);
    }

    private void OnEnable()
    {
        // Enable the Controls instance
        _controls.Enable();
    }

    private void OnDisable()
    {
        // Disable the Controls instance
        _controls.Disable();
    }

    private void Update()
    {
        if (_isGrounded)
        {
            // Handle ground movement
            _groundMovement.Move();
            
            // Check for jump input
            if (_controls.Movement.Jump.triggered)
            {
                _groundMovement.Jump();
                _isGrounded = false;
            }
        }
        else
        {
            // Handle air movement
            _airMovement.Roll();
            _airMovement.Dive();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // Check if the player has landed on the ground
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }
}