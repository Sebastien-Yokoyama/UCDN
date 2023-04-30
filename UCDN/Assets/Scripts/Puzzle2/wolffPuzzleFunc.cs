using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolffPuzzleFunc : MonoBehaviour
{
    public static wolffPuzzleFunc inst;
    private void Awake()
    {
        inst = this;
    }

    public bool wolf;
    // Start is called before the first frame update
    void Start()
    {
        wolf = false;

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("wolf"))
        {
            wolf = true;

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("wolf"))
        {
            wolf = false;

        }

    }
}
