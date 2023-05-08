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
    [SerializeField] bool activated;    // If lever is activated or not


    /*----- METHODS -----*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // When player interacts, switch lever
    public void Interact()
    {
        Debug.Log(gameObject);
    }

    void OpenLever()
    {

    }

    void CloseLever()
    {

    }

    void ToggleLever()
    {

    }
}
