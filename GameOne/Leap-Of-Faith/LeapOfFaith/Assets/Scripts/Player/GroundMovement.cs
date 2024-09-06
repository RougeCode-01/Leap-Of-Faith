using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _jumpForce = 10.0f;
    private Rigidbody _rigidbody;
    private Controls _controls;

    private void Awake()
    {
        // Get the Rigidbody component attached to the GameObject
        _rigidbody = GetComponent<Rigidbody>();
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
        
        // Calculate movement direction and apply speed
        Vector3 direction = new Vector3(input.x, 0, input.y) * _speed;
        
        // Update Rigidbody velocity for movement
        Vector3 velocity = _rigidbody.velocity;
        velocity.x = direction.x;
        velocity.z = direction.z;
        _rigidbody.velocity = velocity;
    }

    public void Jump()
    {
        // Apply upward force for jumping
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }
}