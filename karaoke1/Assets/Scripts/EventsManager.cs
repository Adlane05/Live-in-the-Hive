using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public DialogueEvents dialogueEvents;
    // Start is called before the first frame update
    void Awake()
    {
        dialogueEvents = new DialogueEvents();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
