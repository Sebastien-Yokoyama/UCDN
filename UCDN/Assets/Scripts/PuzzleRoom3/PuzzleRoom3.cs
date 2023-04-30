using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRoom3 : MonoBehaviour
{

    bool playerIsHere;

    // Start is called before the first frame update
    void Start()
    {
        floorFall();
    }

    // Update is called once per frame
    void Update()
    {
        floorFall();
    }

    void floorFall()
    {
        if (playerIsHere)
        {
           
                transform.Translate(0f, 0f, -20f * Time.deltaTime);
           
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsHere = true;

        }

    }
}
