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
    // ENUMERATION for Key TYPES
    public enum KeyType
    {
        Rust,    // 0
        Test    // 1
    }

    /*----- PROPERTIES -----*/
    [Header("Key Properties")]
    [SerializeField] KeyType keyType;   // Set value in inspector


    /*----- METHODS -----*/
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // When collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        // Check for player collision
        if(collision.gameObject.tag == "Player")
        {
            // Player collects key
            PlayerMgr.inst.keyCount++;

            // Destroy this key
            Destroy(gameObject);
        }
    }
}
