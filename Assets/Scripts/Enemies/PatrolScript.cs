using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust movement speed as needed
    public Transform[] patrolPoints; // Array of patrol waypoint positions
    private int currentPointIndex = 0;


    public void patroling()
    {
        // Move towards the current waypoint
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, moveSpeed * Time.deltaTime);

        // Check if reached the waypoint
        if (Vector3.Distance(transform.position, patrolPoints[currentPointIndex].position) < 1f) // Tolerance for reaching the point
        {
            // Move to the next waypoint in the list
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
        }
    }
}
