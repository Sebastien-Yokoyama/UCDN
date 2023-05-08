using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1Mgr : MonoBehaviour
{
    /*----- AWAKE -----*/
    // Static Instance of Puzzle1Mgr for global usage
    public static Puzzle1Mgr inst;
    private void Awake()
    {
        inst = this;
    }


    /*----- PROPERTIES -----*/
    [SerializeField] Lever redLever;
    [SerializeField] Lever greenLever;
    [SerializeField] Lever blueLever;
    [SerializeField] Lever yellowLever;

    [SerializeField] int leversActive;

    [SerializeField] bool isCompleted;

    [SerializeField] GameObject door;
    [SerializeField] GameObject gasper;

    [SerializeField] GameObject interactMessage;

    /*----- METHODS -----*/
    // Start is called before the first frame update
    void Start()
    {
        isCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetNumActiveLevers();
        DoorControl();

        if (isCompleted && door.transform.position.y > -10)
        {
            door.transform.Translate(0f, -5f * Time.deltaTime, 0f);
        }
        
        if(isCompleted && gasper.transform.position.y < 0)
        {
            gasper.transform.Translate(0f, 5f * Time.deltaTime, 0f);
        }
    }

    void DoorControl()
    {
        switch (leversActive)
        {
            case 1:
                if(!redLever.activated) { ResetLevers(); }
                break;
            case 2:
                if(!(redLever.activated && yellowLever.activated)) { ResetLevers(); }
                break;
            case 3:
                if(blueLever.activated) { ResetLevers(); }
                break;
            case 4:
                isCompleted = true;
                break;
            default:
                break;
        }
    }

    void ResetLevers()
    {
        redLever.activated = false;
        greenLever.activated = false;
        blueLever.activated = false;
        yellowLever.activated = false;
    }

    void GetNumActiveLevers()
    {
        leversActive = 0;

        if (redLever.activated) { leversActive++; }

        if (greenLever.activated) { leversActive++; }

        if (blueLever.activated) { leversActive++; }

        if (yellowLever.activated) { leversActive++; }

        if (leversActive > 0) { interactMessage.SetActive(false); }
    }
}
