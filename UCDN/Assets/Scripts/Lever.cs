// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@nevada.unr.edu
// COURSE: CS 328
// ASSIGNMENT: Game 3
// FILE NAME: Lever.cs
/* FILE DESCRIPTION: Class that defines a lever object. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, iInteractable
{
    /*----- PROPERTIES -----*/
    [SerializeField] GameObject pivot;

    public bool activated;    // If lever is activated or not


    /*----- METHODS -----*/
    // Start is called before the first frame update
    void Start()
    {
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Open Lever
        if (activated && (pivot.transform.localEulerAngles.z <= 60))
        {
            pivot.transform.Rotate(new Vector3(0f, 0f, 30f) * Time.deltaTime);
        }
        // Close Lever
        else if(!activated && (pivot.transform.localEulerAngles.z >= 1))
        {
            pivot.transform.Rotate(new Vector3(0f, 0f, -30f) * Time.deltaTime);
        }
    }

    // When player interacts, switch lever
    public void Interact()
    {
        activated = !activated;
    }
}
