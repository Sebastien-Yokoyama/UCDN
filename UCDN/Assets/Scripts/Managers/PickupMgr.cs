using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMgr : MonoBehaviour
{
	
	private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("key1"))
        {   
            other.gameObject.SetActive(false);
          
        }
	}	
}
