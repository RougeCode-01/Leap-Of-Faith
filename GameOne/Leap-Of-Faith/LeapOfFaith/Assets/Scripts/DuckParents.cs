using System.Collections;
using UnityEngine;

public class DuckParents : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints; // Array of waypoints
    [SerializeField] private float speed = 2.0f; // Speed of movement
    [SerializeField] private AudioSource duckCall; // AudioSource for duck call

    private int currentWaypointIndex = 0; // Current waypoint index
    private bool waitingForPlayer = false; // Flag to check if waiting for player

    private void Start()
    {
        // Start moving to the first waypoint
        StartCoroutine(MoveToNextWaypoint());
    }

    private IEnumerator MoveToNextWaypoint()
    {
        while (true)
        {
            if (!waitingForPlayer)
            {
                // Move towards the current waypoint
                Transform targetWaypoint = waypoints[currentWaypointIndex];
                while (Vector3.Distance(transform.position, targetWaypoint.position) > 0.1f)
                {
                    // Look at the target waypoint
                    transform.LookAt(targetWaypoint.position);
                    // Move towards the target waypoint
                    transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);
                    yield return null;
                }

                // Wait for player collision
                waitingForPlayer = true;
                duckCall.Play(); // Play duck call sound
            }
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (waitingForPlayer && other.CompareTag("Player"))
        {
            // Player collided, move to the next waypoint
            waitingForPlayer = false;
            duckCall.Stop(); // Stop duck call sound
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}