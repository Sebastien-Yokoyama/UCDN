// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@nevada.unr.edu
// COURSE: CS 328
// ASSIGNMENT: Game 3
// FILE NAME: PlayerMgr.cs
/* FILE DESCRIPTION: Manages attributes and properties associated with the player. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMgr : MonoBehaviour
{
    /*----- AWAKE -----*/
    // Static Instance of PlayerMgr for global usage
    public static PlayerMgr inst;
    private void Awake()
    {
        inst = this;
    }


    /*----- PROPERTIES -----*/
    [Header("Player Objects")]
    public GameObject playerObject;
    [SerializeField] Rigidbody playerRb;
    public Transform orientation;

    [Header("Ground Check")]
    [SerializeField] float playerHeight;
    [SerializeField] bool isGrounded;

    [Header("Movement Properties")]
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float groundDrag;
    Vector3 moveDirection;

    public bool isRunning;

    [Header("Jump Properties")]
    [SerializeField] float jumpForce;
    [SerializeField] float jumpCooldown;
    [SerializeField] float airMultiplier;
    bool readyToJump;

    [Header("Interaction Properties")]
    [SerializeField] float interactDistance = 3f;
    [SerializeField] LayerMask interactLayerMask;

    public Transform objectGrabPointTransform;
    public Grabbable objectGrabbable;
    public bool isHolding;

    public bool isTalking;

    [Header("Inventory")]
    public int keyCount;
    public int rustKeyCount;


    /*----- METHODS -----*/
    // Start is called before the first frame update
    void Start()
    {
        // Prevent the rigidbody from falling over sideways
        playerRb.freezeRotation = true;

        // Initialize ability to jump
        readyToJump = true;

        // Initialize running
        isRunning = false;

        // Initialize if carrying something
        isHolding = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.Raycast(playerObject.transform.position, Vector3.down, playerHeight * 0.5f + 0.1f);

        // Control speed
        SpeedControl();

        // Handle Drag
        if(isGrounded) { playerRb.drag = groundDrag; }
        else { playerRb.drag = 0f; }

        // Check if holding something
        isHolding = objectGrabbable;
    }

    // Update for physics calculations
    void FixedUpdate()
    {
        // Rigidbody movement is physics-based, so FixedUpdate is necessary
        MovePlayer();
    }

    // Moves the player by applying forces to the player RigidBody
    public void MovePlayer()
    {
        // Calculate movement direction
        moveDirection = orientation.forward * InputMgr.inst.verticalInput + orientation.right * InputMgr.inst.horizontalInput;

        // Check if running or walking
        var speed = isRunning ? runSpeed : walkSpeed;
        Debug.Log("Speed: " + speed.ToString());

        if(isGrounded)
        {
            playerRb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);
        }
        else
        {
            playerRb.AddForce(moveDirection.normalized * speed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    // Helper method that caps the player's speed
    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(playerRb.velocity.x, 0f, playerRb.velocity.z);

        // Check if running or walking
        var speed = isRunning ? runSpeed : walkSpeed;

        // Limit Velocity
        if(flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            playerRb.velocity = new Vector3(limitedVel.x, playerRb.velocity.y, limitedVel.z);
        }
    }

    // Allows the player to jump by applying a vertical force to the player RigidBody
    void Jump()
    {
        // Prevent double-jumping
        readyToJump = false;

        // Reset y-velocity
        playerRb.velocity = new Vector3(playerRb.velocity.x, 0f, playerRb.velocity.z);

        playerRb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    // Helper method that resets the status for the player's ability to jump
    void ResetJump()
    {
        readyToJump = true;
    }

    /* Method that attempts to jump.
     If the player is grounded and is ready to jump, the player will jump, using the Jump() method.
    If the player is neither grounded nor ready to jump, nothing will happen. */
    public void DoJump()
    {
        // Jump if grounded and able to
        if (readyToJump && isGrounded)
        {
            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }
	
    // Method that allows player to interact with objects
    public void Interact()
    {
        if(Physics.Raycast(CameraMgr.inst.playerCam.ViewportPointToRay(Vector3.one/2f),
            out RaycastHit hit, interactDistance) && !isHolding)
        {
            if(hit.transform.TryGetComponent(out iInteractable interactable))
            {
                interactable.Interact();
            }
        }
        else if(isHolding)
        {
            objectGrabbable.Drop();
        }
    }
}
