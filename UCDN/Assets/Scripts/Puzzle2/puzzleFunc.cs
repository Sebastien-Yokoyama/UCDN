using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleFunc : MonoBehaviour
{



    private bearPuzzleFunc bear_script;
    private wolffPuzzleFunc wolf_script;
    private deerPuzzleFunc deer_script;

    public GameObject wolf;
    public GameObject bear;
    public GameObject deer;
    public GameObject Gasper;

    public bool complete;

    public GameObject Door;
    // Start is called before the first frame update
    void Start()
    {
        complete = false;
        
        wolf_script = wolf.GetComponent<wolffPuzzleFunc>();
        bear_script = bear.GetComponent<bearPuzzleFunc>();
        deer_script = deer.GetComponent<deerPuzzleFunc>();
        puzzleComplete();
    }

    // Update is called once per frame
    void Update()
    {
        puzzleComplete();

    }

    void puzzleComplete()
    {
        if (wolf_script.wolf && bear_script.bear && deer_script.deer)
        {
            if (Door.transform.position.y > -15)
            {
            Door.transform.Translate(0f, -10f * Time.deltaTime, 0f);
            }
            complete = true;
        }
        else
        {
            if (Door.transform.position.y < 6.46)
            {
                Door.transform.Translate(0f, 10f * Time.deltaTime, 0f);
            }
            complete = false;
        }
        
    }

}
