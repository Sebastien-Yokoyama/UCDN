using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{
    private PickupMgr pickup_script;

    public GameObject keys;
    public GameObject movingDoor;
    public GameObject LockedPanel = null;
    public GameObject UseKeyPanel = null;

    public float maxOpening = -3f;
    public float maxClosed = 2.5f;
    public float movementSpeed = -5f;

    bool playerIsHere;
    bool open;
    bool opening;
    bool keyAvailable;

    // Start is called before the first frame update
    void Start()
    {
        pickup_script = keys.GetComponent<PickupMgr>();
        playerIsHere = false;
       // opening = false;
        keyAvailable = false;
        LockedPanel.SetActive(false);
        UseKeyPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pickup_script.KeyAmount > 0)
        {
            keyAvailable = true;
        }
        else
        {
            keyAvailable = false;
        }

        if (playerIsHere)
        {
            if (keyAvailable)
            {
                if ((Input.GetKeyDown(KeyCode.E)))
                {
                    pickup_script.KeyAmount--;
                    open = true;
                }
            }

        }

        if (open)
        {
            if (movingDoor.transform.position.y > maxOpening)
            {
                movingDoor.transform.Translate(0f, movementSpeed * Time.deltaTime, 0f);
            }
        }
        if (movingDoor.transform.position.y <= maxOpening)
        {
            open = false;
            LockedPanel.SetActive(false);
            UseKeyPanel.SetActive(false);
        }
    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            playerIsHere = true;

            if (keyAvailable)
            {
                UseKeyPanel.SetActive(true);
                LockedPanel.SetActive(false);
            }
            else
            {
                LockedPanel.SetActive(true);
                UseKeyPanel.SetActive(false);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        { 
            playerIsHere = false;
            LockedPanel.SetActive(false);
            UseKeyPanel.SetActive(false);
        }
    }
    
}
