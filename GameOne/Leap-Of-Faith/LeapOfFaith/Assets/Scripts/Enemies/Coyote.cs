using UnityEngine;
using UnityEngine.AI;

public class Coyote : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f; // Speed of the coyote while patrolling
    [SerializeField] private Transform[] waypoints; // Array of waypoints for patrolling
    [SerializeField] private float chaseSpeed = 5.0f; // Speed of the coyote while chasing
    [SerializeField] private float detectionRange = 10.0f; // Range within which the coyote can detect the player
    [SerializeField] private float chaseDelay = 2.0f; // Delay before the coyote starts chasing
    [SerializeField] private AudioClip chaseSound; // Sound to play when the coyote starts chasing
    private int _currentWaypointIndex; // the current waypoint
    private NavMeshAgent _navMeshAgent; // NavMeshAgent component for navigation
    private Transform _player; // Reference to the player
    private AudioSource _audioSource; // AudioSource component for playing sounds
    private enum State { Patrolling, Chasing } // Enum for the coyote's states
    private State _currentState = State.Patrolling; // Current state of the coyote
    private float _chaseTimer; // Timer to track the delay before chasing

    private void Awake()
    {
        // Get the NavMeshAgent and AudioSource components
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _audioSource = GetComponent<AudioSource>();
        // Find the player by tag
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Switch between states
        switch (_currentState)
        {
            case State.Patrolling:
                Patrol();
                break;
            case State.Chasing:
                Chase();
                break;
        }

        // Detect the player
        DetectPlayer();
    }

    private void Patrol()
    {
        // Return if there are no waypoints
        if (waypoints.Length == 0) return;

        // Set the speed for patrolling
        _navMeshAgent.speed = speed;
        // Set the destination to the current waypoint
        _navMeshAgent.destination = waypoints[_currentWaypointIndex].position;

        // Check if the coyote is close to the current waypoint
        if (Vector3.Distance(transform.position, waypoints[_currentWaypointIndex].position) < 0.1f)
        {
            // Move to the next waypoint
            _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    private void Chase()
    {
        // Set the speed for chasing
        _navMeshAgent.speed = chaseSpeed;
        // Set the destination to the player's position
        _navMeshAgent.destination = _player.position;
    }

    private void DetectPlayer()
    {
        // Check if the player is within detection range
        if (Vector3.Distance(transform.position, _player.position) <= detectionRange)
        {
            // If the coyote is patrolling, start the chase timer
            if (_currentState == State.Patrolling)
            {
                _chaseTimer += Time.deltaTime;
                // If the chase timer exceeds the delay, start chasing
                if (_chaseTimer >= chaseDelay)
                {
                    // Play the chase sound
                    _audioSource.PlayOneShot(chaseSound);
                    // Switch to chasing state
                    _currentState = State.Chasing;
                }
            }
        }
        else
        {
            // Reset the chase timer and switch to patrolling state
            _chaseTimer = 0;
            _currentState = State.Patrolling;
        }
    }
}