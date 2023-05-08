// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@nevada.unr.edu
// COURSE: CS 328
// ASSIGNMENT: Game 3
// FILE NAME: LevelExit.cs
/* FILE DESCRIPTION: Class that defines a level exit object, used to change levels. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    /*----- PROPERTIES -----*/
    [SerializeField] int sceneToLoadIndex;


    /*----- METHODS -----*/
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            LoadSceneByIndex();
        }
    }

    void LoadSceneByIndex()
    {
        // Check if index is in range
        if((sceneToLoadIndex + 1) < SceneManager.sceneCountInBuildSettings)
        {
            // Load to new scene
            SceneManager.LoadSceneAsync(sceneToLoadIndex, LoadSceneMode.Single);
        }
        else
        {
            // Return to main menu

        }
    }
}
