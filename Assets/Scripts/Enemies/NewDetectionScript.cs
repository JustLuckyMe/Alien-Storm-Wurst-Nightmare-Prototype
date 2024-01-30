using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDetectionScript : MonoBehaviour
{
    PatrolScript patrolScript;

    public float radius = 10f; // Adjust for detection range
    public float directionDistance = 10f; // Distance for raycast
    public float followSpeed = 5f; // Adjust for follow speed


    Vector3 origin;
    Vector3 direction;
    RaycastHit hit;
    bool isFollowingPlayer = false;

    // Start is called before the first frame update
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(origin + direction * directionDistance, radius);
    }

    void Start()
    {
        patrolScript = GetComponent<PatrolScript>();
    }

    // Update is called once per frame
    void Update()
    {
        origin = transform.position;
        direction = transform.forward;
        Debug.DrawRay(origin, direction * directionDistance, Color.red);

        Debug.Log("Current Position: " + transform.position);
        Debug.Log("Target Position: " + (hit.collider.transform.position - transform.forward * 2f));


        PlayerDetected();

        if (isFollowingPlayer)
        {
            FollowPlayer();
        }
        else
        {
            patrolScript.patroling(); // Call the patrolling function from the PatrolScript
        }
    }

    void PlayerDetected()
    {
        if (Physics.SphereCast(origin, radius, direction, out hit, directionDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Let's capture the RoboThreat!");
                isFollowingPlayer = true;
                FollowPlayer();
            }
            else if (hit.collider == null)
            {
                Debug.Log("Continue patrolling the area.");
                patrolScript.patroling();
            }
        }
    }

    void FollowPlayer()
    {
        Debug.Log("Entered Follow player script");
        // Move towards the player while maintaining a safe distance
        transform.position = Vector3.MoveTowards(transform.position, hit.collider.transform.position - transform.forward * 2f, followSpeed * Time.deltaTime);

        // If player is lost, resume patrolling
        if (!Physics.SphereCast(origin, radius, transform.forward, out hit, radius))
        {
            isFollowingPlayer = false;
        }
    }
}
