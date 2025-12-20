using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairInteractable : MonoBehaviour, IInteractable
{
    public string InteractMessage => objectInteractableMessage;
    [SerializeField]
    string objectInteractableMessage;
    [SerializeField]
    private TextAsset inkJSONAsset = null;
    public void Interact(){
        if(!DialogueManager.isInDialogue){
            if(InformationManager.Instance.QinyiQuestDone){
                DialogueManager.Instance.StartStory(inkJSONAsset, "event");
            }
        }
    }
}
