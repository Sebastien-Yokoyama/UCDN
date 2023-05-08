using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasperDialogue : MonoBehaviour
{
    /*----- PROPERTIES -----*/
    [Header("Dialogue Attributes")]
    public List<string> lines;  // Lines that will be said

    [SerializeField] float textSpeed;   // How fast each char is typed in seconds

    int index;  // Keep track of conversation; keep track of line
    private bool triggerEntered = false;


    /*----- METHODS -----*/
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

       /* if (startConvo == 1)
        {
            StartDialogue();
            startConvo = 0;
        }*/
        // Read Left-Click to proceed
        if (Input.GetMouseButtonDown(0))
        {
            if (UIMgr.inst.dialogueText.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                UIMgr.inst.dialogueText.text = lines[index];
            }
        }

        // Read Right-Click to exit
        if (Input.GetMouseButtonDown(1))
        {
            UIMgr.inst.CloseDialogue();
        }
    }



    void StartDialogue()
    {
        StopAllCoroutines();    // Prevent funny text, if player spams 'E'

        UIMgr.inst.dialogueText.text = string.Empty;
        UIMgr.inst.OpenDialogue();

        //index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            UIMgr.inst.dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Count - 1)
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!triggerEntered)
            {
                StartDialogue();
                triggerEntered = true;
            }

        }

    }
}
