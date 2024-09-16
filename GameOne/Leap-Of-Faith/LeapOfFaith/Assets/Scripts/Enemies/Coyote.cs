using UnityEngine;

public class Coyote : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f; // Speed of the coyote
    [SerializeField] private Transform[] waypoints; // Array of waypoints for movement
    private int _currentWaypointIndex; // Index of the current waypoint

    private void Update()
    {
        // Return if there are no waypoints
        if (waypoints.Length == 0) return;

        // Get the target waypoint
        Transform targetWaypoint = waypoints[_currentWaypointIndex];
        // Calculate direction to the target waypoint
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;
        // Rotate the coyote to look at the target waypoint
        transform.LookAt(targetWaypoint.position);
        // Move towards the target waypoint
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // Check if the coyote is close to the target waypoint
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // Move to the next waypoint
            _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}