// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@nevada.unr.edu
// COURSE: CS 328
// ASSIGNMENT: Game 3
// FILE NAME: InputMgr.cs
/* FILE DESCRIPTION: Manages the player's input and executes different functions depending on the received input. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMgr : MonoBehaviour
{
    /*----- AWAKE -----*/
    // Static Instance of InputMgr for global usage
    public static InputMgr inst;
    private void Awake()
    {
        inst = this;
    }


    /*----- PROPERTIES -----*/
    [Header("Mouse Properties")]
    public float mouseSensitivity = 100f;
    float xRotation, yRotation;

    [Header("Keyboard Properties")]
    public float horizontalInput, verticalInput;


    /*----- METHODS -----*/
    // Start is called before the first frame update
    void Start()
    {
        // Lock and Hide cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse Input
        ReadMouseInput();
        ReadMouseClick();

        // Keyboard Input
        ReadKeyboardInput();
    }

    // Reads the user's mouse input
    void ReadMouseInput()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;    // Horizontal
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;    // Vertical

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //CameraMgr.inst.playerCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //PlayerMgr.inst.playerObject.transform.Rotate(Vector3.up * mouseX);

        CameraMgr.inst.playerCam.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        PlayerMgr.inst.orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    // Reads the user's mouse click input
    void ReadMouseClick()
    {

    }

    // Reads the user's keyboard input
    void ReadKeyboardInput()
    {
        // Quit Game if ESC is pressed
        if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }

        // Read WASD for movement
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Read for jump
        if (Input.GetKeyDown(KeyCode.Space)){ PlayerMgr.inst.DoJump(); }

        // Read Q for inventory
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // If closed
            if (!UIMgr.inst.inventoryOpen)
            {
                UIMgr.inst.OpenInventory();
            }
            // If open
            else
            {
                UIMgr.inst.CloseInventory();
            }
        }

        // Read E for interaction
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerMgr.inst.Interact();
        }
    }
}
