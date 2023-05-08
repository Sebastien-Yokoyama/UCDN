// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@nevada.unr.edu
// COURSE: CS 328
// ASSIGNMENT: Game 3
// FILE NAME: UIMgr.cs
/* FILE DESCRIPTION: Manages the player's screen overlay UI elements. */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    /*----- AWAKE -----*/
    // Static Instance of UIMgr for global usage
    public static UIMgr inst;
    private void Awake()
    {
        inst = this;
    }


    /*----- PROPERTIES -----*/
    [Header("Key Count UI Elements")]
    public GameObject keyCountPanel;
    public TextMeshProUGUI keyCount;

    [Header("Inventory UI Elements")]
    public GameObject inventoryPanel;

    public bool inventoryOpen;

    public TextMeshProUGUI rustKeyCount;

    [Header("Dialogue UI Elements")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;


    /*----- METHDOS -----*/
    // Start is called before the first frame update
    void Start()
    {
        // Initialize key count
        SetKeyCount();

        // Display key count
        keyCountPanel.SetActive(true);

        // Ensure inventory is closed
        inventoryOpen = false;
        inventoryPanel.SetActive(false);

        // Ensure dialogue is closed
        dialoguePanel.SetActive(false);
        // Ensure dialogue text is empty
        dialogueText.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        SetKeyCount();

        SetRustKeyCount();
    }

    public void SetKeyCount()
    {
        keyCount.text = "Keys: " + PlayerMgr.inst.keyCount.ToString();
    }

    public void OpenInventory()
    {
        inventoryOpen = true;
        inventoryPanel.SetActive(true);

        keyCountPanel.gameObject.SetActive(false);
    }

    public void CloseInventory()
    {
        inventoryOpen = false;
        inventoryPanel.SetActive(false);

        keyCountPanel.gameObject.SetActive(true);
    }

    void SetRustKeyCount()
    {
        rustKeyCount.text = "x " + PlayerMgr.inst.rustKeyCount.ToString();
    }

    public void OpenDialogue()
    {
        dialoguePanel.SetActive(true);
        
        PlayerMgr.inst.isTalking = true;
    }

    public void CloseDialogue()
    {
        dialoguePanel.SetActive(false);

        PlayerMgr.inst.isTalking = false;
    }
}
