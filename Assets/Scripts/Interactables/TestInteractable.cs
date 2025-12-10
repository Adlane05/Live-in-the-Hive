using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TestInteractable : MonoBehaviour, IInteractable
{
    public string InteractMessage => objectInteractableMessage;
    [SerializeField]
    string objectInteractableMessage;
    [SerializeField]
    private TextAsset inkJSONAsset = null;
    private int numberOfInteractions = 0;


    private GameObject chara;
    private void Awake()
{
    chara = this.gameObject;
}
    public void Interact()
    {
        if(numberOfInteractions> 0)
        InformationManager.Instance.hasInteractedCabinet = true;
        if(!DialogueManager.isInDialogue){
        if (numberOfInteractions == 0)
        {
            DialogueManager.Instance.StartStory(inkJSONAsset, "visit1");
        }
        else if (numberOfInteractions >= 1)
        {
            DialogueManager.Instance.StartStory(inkJSONAsset, "visit2");

        }
        numberOfInteractions++;
        }
}}
