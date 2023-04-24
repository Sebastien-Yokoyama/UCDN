// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@nevada.unr.edu
// COURSE: CS 328
// ASSIGNMENT: Game 3
// FILE NAME: UIMgr.cs
/* FILE DESCRIPTION: Manages the player's screen overlay UI elements. */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    /*----- AWAKE -----*/
    // Static Instance of UIMgr for global usage
    public static UIMgr inst;
    private void Awake()
    {
        inst = this;
    }


    /*----- PROPERTIES -----*/
    [Header("UI Elements")]
    public TextMeshProUGUI keyCount;


    /*----- METHDOS -----*/
    // Start is called before the first frame update
    void Start()
    {
        SetKeyCount();
    }

    // Update is called once per frame
    void Update()
    {
        SetKeyCount();
    }

    void SetKeyCount()
    {
        keyCount.text = "Keys: " + PlayerMgr.inst.keyCount.ToString();
    }
}
