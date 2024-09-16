using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private float jumpCost = 0.5f;
    [SerializeField] private float walkCost = 0.1f;
    private Rigidbody _rigidbody;
    private Controls _controls;
    private Stamina _stamina;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _stamina = GetComponent<Stamina>();
    }

    public void Initialize(Controls controls)
    {
        _controls = controls;
    }

    public void Move()
    {
        Vector2 input = _controls.Movement.WASD.ReadValue<Vector2>();

        if ((input.x != 0 || input.y != 0) && _stamina.UsingStamina(walkCost))
        {
            Vector3 direction = new Vector3(input.x, 0, input.y) * speed;
            Vector3 velocity = _rigidbody.velocity;
            velocity.x = direction.x;
            velocity.z = direction.z;
            _rigidbody.velocity = velocity;
        }
    }

    public void Jump()
    {
        if (_stamina.UsingStamina(jumpCost))
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}