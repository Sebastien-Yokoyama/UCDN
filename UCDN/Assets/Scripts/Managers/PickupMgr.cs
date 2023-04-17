using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupMgr : MonoBehaviour
{
    //private Door door_script;

   // public GameObject KeyCount;
    public int KeyAmount = 0;
    public TextMeshProUGUI keyCount;


    void Start()
    {
        SetKeyCountText();
        //door_script = KeyCount.GetComponent<Door>();
    }

    void Update()
    {
        SetKeyCountText();
       /* if (door_script.open)
        {
            KeyAmount--;
        }*/
    }



    private void SetKeyCountText()
    {
        keyCount.text = "Keys: " + KeyAmount.ToString();

    }

	private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("key1"))
        {   
            other.gameObject.SetActive(false);
            KeyAmount++;
            SetKeyCountText();
        }
	}	
}
