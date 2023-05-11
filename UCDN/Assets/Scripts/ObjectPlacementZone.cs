// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@nevada.unr.edu
// COURSE: CS 328
// ASSIGNMENT: Game 3
// FILE NAME: ObjectPlacementZone.cs
/* FILE DESCRIPTION: Class that defines an object placement zone for activating doors. */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacementZone : MonoBehaviour
{
    /*----- PROPERTIES -----*/
    public bool isActivated;    // If object is placed or not

    [SerializeField] string tagToCheck;


    /*----- METHODS -----*/
    // Start is called before the first frame update
    void Start()
    {
        isActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == tagToCheck)
        {
            other.transform.position = this.transform.position;

            isActivated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == tagToCheck)
        {
            isActivated = false;
        }
    }
}
