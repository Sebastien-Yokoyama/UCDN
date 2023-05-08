using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChest : MonoBehaviour, iInteractable
{
    /*----- PROPERTIES -----*/
    [SerializeField] GameObject messagePanel;

    /*----- METHODS -----*/
    // Start is called before the first frame update
    void Start()
    {
        messagePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        UIMgr.inst.dialogueText.text = string.Empty;
        ToggleText();
    }

    void ToggleText()
    {
        messagePanel.SetActive(!messagePanel.activeSelf);
    }

    void StartDialogue()
    {

    }
}
