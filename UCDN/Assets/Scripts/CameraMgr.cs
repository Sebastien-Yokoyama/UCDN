// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@nevada.unr.edu
// COURSE: CS 328
// ASSIGNMENT: Game 3
// FILE NAME: CameraMgr.cs
/* FILE DESCRIPTION: Manages the player's camera in the game. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMgr : MonoBehaviour
{
    /*----- AWAKE -----*/
    // Static Instance of CameraMgr for global usage
    public static CameraMgr inst;
    private void Awake()
    {
        inst = this;
    }


    /*----- PROPERTIES -----*/
    [Header("Player Camera")]
    public Camera playerCam;
}
