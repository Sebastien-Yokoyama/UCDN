using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasperAppearAndDoor : MonoBehaviour
{
    public GameObject objectToMove;
    public GameObject objectToMoveDoor;
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

            if (objectToMoveDoor.transform.position.y < -0.6)
            {
                Vector3 newPosition = objectToMoveDoor.transform.position;
                newPosition.y -= moveDistance * Time.deltaTime;
                objectToMoveDoor.transform.position = newPosition;
            }
        }
    }
}