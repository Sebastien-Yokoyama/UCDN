// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@nevada.unr.edu
// COURSE: CS 328
// ASSIGNMENT: Game 3
// FILE NAME: PlayerMgr.cs
/* FILE DESCRIPTION: Manages attributes and properties associated with the player. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : MonoBehaviour
{
    /*----- AWAKE -----*/
    // Static Instance of PlayerMgr for global usage
    public static PlayerMgr inst;
    private void Awake()
    {
        inst = this;
    }


    /*----- PROPERTIES -----*/
    public GameObject playerObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
