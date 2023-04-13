// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@nevada.unr.edu
// COURSE: CS 328
// ASSIGNMENT: Game 3
// FILE NAME: PlayerMgr.cs
/* FILE DESCRIPTION: Manages attributes, properties associated with the game.
 * These attributes and properties can be used to control the game's rules. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    /*----- AWAKE -----*/
    // Static Instance of GameMgr for global usage
    public static GameMgr inst;
    private void Awake()
    {
        inst = this;
    }


    /*----- PROPERTIES -----*/
    Vector3 gravity = new Vector3(0f, -9.81f * 2, 0f);


    /*----- METHODS -----*/
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = gravity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
