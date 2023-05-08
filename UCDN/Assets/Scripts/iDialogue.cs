// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@nevada.unr.edu
// COURSE: CS 328
// ASSIGNMENT: Game 3
// FILE NAME: iDialogue.cs
/* FILE DESCRIPTION: Interface that defines and enforces a 'dialogue' behavior. */

using System.Collections.Generic;
using UnityEngine;

public interface iDialogue
{
    List<string> lines { get; set; }
    float textSpeed { get; set; }
    int index { get; set; }

    void StartDialogue();
}
