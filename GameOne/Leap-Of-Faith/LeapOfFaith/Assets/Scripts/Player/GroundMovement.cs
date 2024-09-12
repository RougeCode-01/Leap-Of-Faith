using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GroundMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private float jumpCost = 0.5f;
    [SerializeField] private float walkCost = 0.1f;//probably dont need this would make the game to hard/unplayable
    private Rigidbody _rigidbody;
    private Controls _controls;
    private Stamina _stamina;

    private void Awake()
    {
        // Get the Rigidbody component attached to the GameObject
        _rigidbody = GetComponent<Rigidbody>();
        // Get the Stamina component attached to the GameObject
        _stamina = GetComponent<Stamina>();
    }

    public void Initialize(Controls controls)
    {
        // Set the Controls instance
        _controls = controls;
    }

    public void Move()
    {
        // Read input from the Controls instance
        Vector2 input = _controls.Movement.WASD.ReadValue<Vector2>();

        // Check if there is input for movement and enough stamina
        if ((input.x != 0 || input.y != 0) && _stamina.UsingStamina(walkCost))
        {
            // Calculate movement direction and apply speed
            Vector3 direction = new Vector3(input.x, 0, input.y) * speed;

            // Update Rigidbody velocity for movement
            Vector3 velocity = _rigidbody.velocity;
            velocity.x = direction.x;
            velocity.z = direction.z;
            _rigidbody.velocity = velocity;
        }
    }

    public void Jump()
    {
        // Check if there is enough stamina to jump
        if (_stamina.UsingStamina(jumpCost))
        {
            // Apply upward force for jumping
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}