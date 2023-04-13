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

    [Header("Ground Check")]
    public float playerHeight;
    [SerializeField] bool isGrounded;

    [Header("Movement Properties")]
    public float movementSpeed;
    public float groundDrag;
    [SerializeField] Vector3 moveDirection;

    [Header("Jump Properties")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    // Start is called before the first frame update
    void Start()
    {
        playerRb.freezeRotation = true;

        readyToJump = true;
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
    }

    private void FixedUpdate()
    {
        // Rigidbody movement is physics-based, so FixedUpdate is necessary
        MovePlayer();
    }

    public void MovePlayer()
    {
        // Calculate movement direction
        moveDirection = playerObject.transform.forward * InputMgr.inst.verticalInput + playerObject.transform.right * InputMgr.inst.horizontalInput;

        if(isGrounded)
        {
            playerRb.AddForce(moveDirection.normalized * movementSpeed * 10f, ForceMode.Force);
        }
        else
        {
            playerRb.AddForce(moveDirection.normalized * movementSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    public void SpeedControl()
    {
        Vector3 flatVel = new Vector3(playerRb.velocity.x, 0f, playerRb.velocity.z);

        // Limit Velocity
        if(flatVel.magnitude > movementSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * movementSpeed;
            playerRb.velocity = new Vector3(limitedVel.x, playerRb.velocity.y, limitedVel.z);
        }
    }

    void Jump()
    {
        // Prevent double-jumping
        readyToJump = false;

        // Reset y-velocity
        playerRb.velocity = new Vector3(playerRb.velocity.x, 0f, playerRb.velocity.z);

        playerRb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void ResetJump()
    {
        readyToJump = true;
    }

    public void DoJump()
    {
        // Jump if grounded and able to
        if (readyToJump && isGrounded)
        {
            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }
}
