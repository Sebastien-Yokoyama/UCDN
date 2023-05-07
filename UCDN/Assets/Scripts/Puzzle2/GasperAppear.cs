using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasperAppear : MonoBehaviour
{
    public GameObject objectToMove;
    public float moveDistance = 10f;
   // public bool completeBool;
    //public puzzleFunc puzzle2;
    private bool hasPlayerEntered = false;
    private bool completeAndEntered = false;

    public GameObject Gasper;
    private puzzleFunc puzFun;

    void Start()
    {
        puzFun = Gasper.GetComponent<puzzleFunc>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            hasPlayerEntered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            hasPlayerEntered = false;
        }
    }



    private void Update()
    {
       /* if(puzzle2 != null)
        {
            completeBool = puzzle2.complete;
        }*/

        if (puzFun.complete)
        {
            if(hasPlayerEntered)
            {
                completeAndEntered = true;


            }

        }
        if (completeAndEntered)
        {
            if (objectToMove.transform.position.y < 1)
            {
                Vector3 newPosition = objectToMove.transform.position;
                newPosition.y += moveDistance * Time.deltaTime;
                objectToMove.transform.position = newPosition;
            }
        }
    }
}
