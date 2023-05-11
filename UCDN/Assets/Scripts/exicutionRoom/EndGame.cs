using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject endGameUI;
    public GameObject resetGameUI;
    // public float maxDistance = 5f;
    public KeyCode endGameKey = KeyCode.E;

   // private bool isLookingAtObject = false;
    //public GameObject objectInSight;

    void Update()
    {
        // Check if player is looking at object
       /* RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            if (hit.collider.gameObject == gameObject)
            {
                isLookingAtObject = true;
                objectInSight = hit.collider.gameObject;
            }
            else
            {
                isLookingAtObject = false;
                objectInSight = null;
            }
        }
        else
        {
            isLookingAtObject = false;
            objectInSight = null;
        }

        // Prompt player to press key to end game if looking at object
        if (isLookingAtObject)
        {
            endGameUI.SetActive(true);
            if (Input.GetKeyDown(endGameKey))
            {
                // End game
                Application.Quit();
            }
        }
        else
        {
            endGameUI.SetActive(false);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SaveSelf"))
        {
            endGameUI.SetActive(true);
            //if (Input.GetKeyDown(endGameKey))
            //{
            //    // End game
            //    Application.Quit();
            //}

        }
        if (other.CompareTag("SaveAll"))
        {

            resetGameUI.SetActive(true);
            //if (Input.GetKeyDown(endGameKey))
            //{
            //    // End game
            //    SceneManager.LoadScene(0);
            //}
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SaveSelf"))
        {
            endGameUI.SetActive(false);

        }
        if (other.CompareTag("SaveAll"))
        {
            resetGameUI.SetActive(false);

        }

    }
}