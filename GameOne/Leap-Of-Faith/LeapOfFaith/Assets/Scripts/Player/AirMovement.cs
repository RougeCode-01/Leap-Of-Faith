using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirMovement : MonoBehaviour
{
    [SerializeField] private float _rollSpeed = 5.0f;
    [SerializeField] private float _diveSpeed = 5.0f;
    [SerializeField] private float _drag = 2.0f; // Drag force for slowing down
    private Rigidbody _rigidbody;
    private Controls _controls;
    private bool _isDiving = false;

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

    public void Roll()
    {
        // Read input from the Controls instance
        Vector2 input = _controls.Movement.WASD.ReadValue<Vector2>();

        // Check if there is horizontal input for rolling
        if (input.x != 0)
        {
            // Calculate roll direction (left and right only) and apply roll speed
            Vector3 roll = new Vector3(input.x, 0, 0) * _rollSpeed;

            // Apply force for rolling
            _rigidbody.AddForce(roll, ForceMode.Force);
        }
    }

    public void Dive()
    {
        // Check if W key is pressed
        if (_controls.Movement.WASD.ReadValue<Vector2>().y > 0)
        {
            if (!_isDiving)
            {
                // Apply downward force for diving
                _rigidbody.AddForce(Vector3.down * _diveSpeed, ForceMode.Impulse);
                _isDiving = true;
            }
        }
        // Check if S key is pressed to stop diving
        else if (_controls.Movement.WASD.ReadValue<Vector2>().y < 0)
        {
            if (_isDiving)
            {
                // Apply drag force to slow down gradually
                _rigidbody.drag = _drag;
                _isDiving = false;
                StartCoroutine(ResetDrag());
            }
        }
    }

    private IEnumerator ResetDrag()
    {
        // Wait for a short duration to simulate gradual slowing down
        yield return new WaitForSeconds(0.5f);

        // Reset drag to default value
        _rigidbody.drag = 0;
    }
}