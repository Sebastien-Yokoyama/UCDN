using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public GameObject toPuzzleRoomPanel = null;

    bool playerIsHere1;
    bool playerIsHere2;

    // Start is called before the first frame update
    void Start()
    {
        playerIsHere1 = false;
        playerIsHere2 = false;
        toPuzzleRoomPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(playerIsHere1 && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if(playerIsHere2 && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
        }






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

            playerIsHere2 = true;
        }
    }

}
