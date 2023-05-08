using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasperMovetoPuzzle2 : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 2.0f;

    private int currentWaypoint = 0;
    public bool isFollowingPlayer = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Waypoint"))
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }
        
        if (other.CompareTag("Player"))
        {
            isFollowingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isFollowingPlayer = false;
        }
    }

    private void FixedUpdate()
    {
        if (isFollowingPlayer)
        {
            if (currentWaypoint < waypoints.Length)
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, moveSpeed * Time.deltaTime);
                transform.LookAt(waypoints[currentWaypoint].position);
            }
        }
    }
}