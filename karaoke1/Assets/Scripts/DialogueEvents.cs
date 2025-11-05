using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogueEvents
{
    public event Action<String> onEnterDialogue;
    public void EnterDialogue(string knotName)
    {
        if(onEnterDialogue != null)
        {
            onEnterDialogue(knotName);
        }
    }
}
