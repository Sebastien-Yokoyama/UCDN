using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public GameObject movingDoor;

    public float maxOpening = -2.5f;

    public float movementSpeed = -1f;
    bool playerIsHere;
    bool opening;

    // Start is called before the first frame update
    void Start()
    {
        playerIsHere = false;
        opening = false;
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyUp(KeyCode.E)))
        {
            opening = true;
        }

        if (playerIsHere && opening)
        {
            if(movingDoor.transform.position.y > maxOpening)
            {
                movingDoor.transform.Translate(0f, movementSpeed * Time.deltaTime, 0f);
            }
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerIsHere = true;
        }
    }
}
