using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KristenInteractable : MonoBehaviour, IInteractable
{
    public string InteractMessage => objectInteractableMessage;
    [SerializeField]
    string objectInteractableMessage;
    [SerializeField]
    private TextAsset inkJSONAsset = null;
    private int numberOfInteractions = 0;
    private bool hasInteract3 = false;

    public void Interact(){
        if(!DialogueManager.isInDialogue)
        {
            if(hasInteract3){
                DialogueManager.Instance.StartStory(inkJSONAsset, "Kristen4");
            }
            if(!InformationManager.Instance.hasInteractedQinyi){
                DialogueManager.Instance.StartStory(inkJSONAsset, "Kristen1");
            }
            if(InformationManager.Instance.hasInteractedQinyi && InformationManager.Instance.QinyiQuestDone){
                hasInteract3 = true;
                DialogueManager.Instance.StartStory(inkJSONAsset, "Kristen3");
            }
            if(InformationManager.Instance.hasInteractedQinyi){
                DialogueManager.Instance.StartStory(inkJSONAsset, "Kristen2");
            }
    }
    }
}
