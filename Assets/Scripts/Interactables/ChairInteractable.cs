using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairInteractable : MonoBehaviour, IInteractable
{
    public string InteractMessage => objectInteractableMessage;
    [SerializeField]
    string objectInteractableMessage;
    bool happened = false;
    [SerializeField]
    private TextAsset inkJSONAsset = null;
    public void Interact(){
        if(!DialogueManager.isInDialogue){
            if(InformationManager.Instance.QinyiQuestDone && happened == false){
                happened = true;
                DialogueManager.Instance.StartStory(inkJSONAsset, "event");
                objectInteractableMessage = "let them be";
            }
        }
    }
}
