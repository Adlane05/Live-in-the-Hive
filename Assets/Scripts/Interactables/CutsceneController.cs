using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
            public TextAsset inkJSONAsset = null;

    void Start()
    {
        DialogueManager.Instance.StartStory(inkJSONAsset, "intro");

    }

    // Update is called once per frame
    
}
