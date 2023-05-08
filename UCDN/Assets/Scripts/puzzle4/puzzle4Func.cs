using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle4Func : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject objectToMove;
    public GameObject objectToMove2;
    public float maxDistance = 10f;
    private bool isLookingAtObject = false;
    private GameObject objectBeingLookedAt;


    public int tally = 0;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, maxDistance))
        {
            if (hit.transform.CompareTag("Deactivatable"))
            {
                isLookingAtObject = true;
                objectBeingLookedAt = hit.transform.gameObject;
            }
            else
            {
                isLookingAtObject = false;
            }
        }
        else
        {
            isLookingAtObject = false;
        }

        if (isLookingAtObject && Input.GetMouseButtonDown(0))
        {
            objectBeingLookedAt.SetActive(false);
            tally++;
        }

        if (tally == 7)
        {
            if (objectToMove.transform.position.y > -4.89)
            {
                Vector3 newPosition = objectToMove.transform.position;
                newPosition.y -= 10f * Time.deltaTime;
                objectToMove.transform.position = newPosition;

            }

            if (objectToMove.transform.position.y <= -4.7)
            {
                if (objectToMove2.transform.position.z < 19.25)
                {
                    Vector3 newPosition = objectToMove2.transform.position;
                    newPosition.z += 5f * Time.deltaTime;
                    objectToMove2.transform.position = newPosition;
                }
                if (objectToMove2.transform.position.x < 133.5)
                {
                    Vector3 newPosition = objectToMove2.transform.position;
                    newPosition.x += 5f * Time.deltaTime;
                    objectToMove2.transform.position = newPosition;
                }
            }
        }
    }
}

