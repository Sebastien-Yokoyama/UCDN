// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@nevada.unr.edu
// COURSE: CS 328
// ASSIGNMENT: Game 3
// FILE NAME: MoveCamera.cs
/* FILE DESCRIPTION: Moves the player's camera object to keep it attached to the player body. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    /*----- PROPERTIES -----*/
    [SerializeField] Transform cameraPosition;


    /*----- METHODS -----*/
    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
