// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@nevada.unr.edu
// COURSE: CS 328
// ASSIGNMENT: Game 3
// FILE NAME: SaveEveryoneInteractable.cs
/* FILE DESCRIPTION: Interactable for the last level, where if the player selects, quit the game. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveEveryoneInteractable : MonoBehaviour, iInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Quit the game
    public void Interact()
    {
        Debug.Log("Saving Everyone");
        Application.Quit();
    }
}
