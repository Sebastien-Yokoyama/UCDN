using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gasper : MonoBehaviour
{
    public float speed = 5f; // The speed at which to move the object

    private bool playerFollowing = false; // Whether the player is following the object
    public Transform target; // The target location to move the object to
    private Rigidbody rb; // The Rigidbody component attached to the object

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    private void FixedUpdate()
    {
        if (playerFollowing)
        {
            // Calculate the direction from the object to the target location
            Vector3 direction = target.position - transform.position;
            direction.y = 0f; // Project the direction onto the XZ plane

            // Move the object towards the target location using physics
            rb.AddForce(direction.normalized * speed, ForceMode.VelocityChange);

            // Rotate the object to face the player
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerFollowing = true;
            rb.isKinematic = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerFollowing = false;
            rb.isKinematic = true;
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}







