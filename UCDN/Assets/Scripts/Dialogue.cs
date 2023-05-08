// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@nevada.unr.edu
// COURSE: CS 328
// ASSIGNMENT: Game 3
// FILE NAME: Dialogue.cs
/* FILE DESCRIPTION: Class that defines 'dialogue' behavior for an object. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour, iInteractable
{
    [Header("Dialogue Attributes")]
    public List<string> lines;

    [SerializeField] float textSpeed;

    int index;  // Keep track of conversation

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(UIMgr.inst.dialogueText.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                UIMgr.inst.dialogueText.text = lines[index];
            }
        }
    }

    public void Interact()
    {
        StartDialogue();
    }

    void StartDialogue()
    {
        UIMgr.inst.dialogueText.text = string.Empty;
        UIMgr.inst.OpenDialogue();

        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            UIMgr.inst.dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < lines.Count - 1)
        {
            index++;
            UIMgr.inst.dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            UIMgr.inst.CloseDialogue();
        }
    }
}
