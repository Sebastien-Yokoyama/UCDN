using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasperAppearAndDoor : MonoBehaviour
{
    public GameObject objectToMove;
    public float moveDistance = 10f;

    private bool hasPlayerEntered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            hasPlayerEntered = true;
        }
    }

    private void Update()
    {
        if (hasPlayerEntered)
        {
            if (objectToMove.transform.position.z < -44)
            { 
            Vector3 newPosition = objectToMove.transform.position;
            newPosition.z += moveDistance * Time.deltaTime;
            objectToMove.transform.position = newPosition;
             }
        }
    }
}