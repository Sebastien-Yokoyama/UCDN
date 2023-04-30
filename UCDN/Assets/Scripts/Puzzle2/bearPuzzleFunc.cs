using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bearPuzzleFunc : MonoBehaviour
{

    public static bearPuzzleFunc inst;
    private void Awake()
    {
        inst = this;
    }

    public bool bear;
    // Start is called before the first frame update
    void Start()
    {
        bear = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bear"))
        {
            bear = true;

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("bear"))
        {
            bear = false;

        }

    }
}