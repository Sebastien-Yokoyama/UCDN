// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@nevada.unr.edu
// COURSE: CS 328
// ASSIGNMENT: Game 3
// FILE NAME: SaveSelfInteractable.cs
/* FILE DESCRIPTION: Interactable for the last level, where if the player selects, restart the game. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSelfInteractable : MonoBehaviour, iInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Restart the game from the beginning
    public void Interact()
    {
        Debug.Log("Saving Self");
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }
}
