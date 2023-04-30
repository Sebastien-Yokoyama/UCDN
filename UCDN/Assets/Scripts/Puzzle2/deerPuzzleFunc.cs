using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deerPuzzleFunc : MonoBehaviour
{

    public static deerPuzzleFunc inst;
    private void Awake()
    {
        inst = this;
    }

    public bool deer;
    // Start is called before the first frame update
    void Start()
    {
        deer = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("deer"))
        {
            deer = true;

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("deer"))
        {
            deer = false;

        }

    }
}
