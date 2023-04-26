// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@nevada.unr.edu
// COURSE: CS 328
// ASSIGNMENT: Game 3
// FILE NAME: Key.cs
/* FILE DESCRIPTION: Describes behaviors for a generic key object. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    /*----- PROPERTIES -----*/
    //[SerializeField] Rigidbody rb;

    /*----- METHODS -----*/
    // Start is called before the first frame update
    void Start()
    {
        // Get Rigidbody for collision
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Check for collision with player
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // Player collects key
            PlayerMgr.inst.keyCount++;

            // Destroy this key
            Destroy(gameObject);
        }
    }
}
