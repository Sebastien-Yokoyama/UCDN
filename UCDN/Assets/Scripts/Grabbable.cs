// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@nevada.unr.edu
// COURSE: CS 328
// ASSIGNMENT: Game 3
// FILE NAME: Grabbable.cs
/* FILE DESCRIPTION: Class that defines a 'grabbable' behavior for generic objects. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour, iInteractable, iGrabbable
{
    /*----- PROPERTIES -----*/
    Rigidbody rb;
    Transform objectGrabPointTransform;

    /*----- METHODS -----*/
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(objectGrabPointTransform != null)
        {
            rb.MovePosition(objectGrabPointTransform.position);
            transform.rotation = CameraMgr.inst.playerCam.transform.rotation;
        }
    }

    public void Interact()
    {
        if (!PlayerMgr.inst.isHolding)
        {
            Grab();
        }
        else
        {
            Drop();
        }
    }

    public void Grab()
    {
        this.objectGrabPointTransform = PlayerMgr.inst.objectGrabPointTransform;
        PlayerMgr.inst.objectGrabbable = this;

        ResetObject();

        rb.useGravity = false;
        rb.freezeRotation = true;
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        PlayerMgr.inst.objectGrabbable = null;

        rb.useGravity = true;
        rb.freezeRotation = false;
    }

    // Helper method to reset orientation of the object
    public void ResetObject()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
