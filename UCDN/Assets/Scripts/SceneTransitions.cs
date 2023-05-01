using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public GameObject toPuzzleRoomPanel = null;

    private Vector3 spawnPosition; // the position where the player should respawn

    bool playerIsHere1;
    bool playerIsHere2;
    bool playerIsHere3;
    bool playerIsHere4;
    bool playerIsHere5;

    // Start is called before the first frame update
    void Start()
    {
        playerIsHere1 = false;
        playerIsHere2 = false;
        playerIsHere3 = false;
        playerIsHere4 = false;
        playerIsHere5 = false;

        toPuzzleRoomPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(playerIsHere1 && Input.GetKeyDown(KeyCode.E))
        {
            LoadSceneByName("TestPuzzleRoom");

        }

        if (playerIsHere2 && Input.GetKeyDown(KeyCode.E))
        {
            LoadSceneByName("mainTo2");
        }

        if (playerIsHere3 && Input.GetKeyDown(KeyCode.E))
        {
            LoadSceneByName("Puzzle 2");
        }

        if (playerIsHere4 && Input.GetKeyDown(KeyCode.E))
        {
            LoadSceneByName("mainTo3");
        }
        if (playerIsHere5 && Input.GetKeyDown(KeyCode.E))
        {
            LoadSceneByName("Puzzle 3");
        }




    }
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }





    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PuzzleRoom1"))
        {
            
            playerIsHere1 = true;
            toPuzzleRoomPanel.SetActive(true);
            
        }

        if (other.gameObject.CompareTag("ToMain"))
        {

            playerIsHere2 = true;
        }
        if (other.gameObject.CompareTag("ToPuzzle2"))
        {

            playerIsHere3 = true;
        }
        if (other.gameObject.CompareTag("ToMainTo3"))
        {

            playerIsHere4 = true;
        }
        if (other.gameObject.CompareTag("ToPuzzle3"))
        {

            playerIsHere5 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PuzzleRoom1"))
        {
            playerIsHere1 = false;
            toPuzzleRoomPanel.SetActive(false);

        }

        if (other.gameObject.CompareTag("ToMain"))
        {

            playerIsHere2 = false;
        }
    }

}
