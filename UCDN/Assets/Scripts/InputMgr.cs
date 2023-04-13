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
        
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse Input
        ReadMouseInput();

        // Keyboard Input
        ReadKeyboardInput();
    }

    void ReadMouseInput()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;    // Horizontal
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;    // Vertical

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        CameraMgr.inst.playerCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerMgr.inst.playerObject.transform.Rotate(Vector3.up * mouseX);
    }

    void ReadKeyboardInput()
    {
        // Quit Game if ESC is pressed
        if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }

        // Read WASD for movement
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
}
