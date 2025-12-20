using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsInteractable : MonoBehaviour,  IInteractable
{
    public string InteractMessage => objectInteractableMessage;
    [SerializeField]
    string objectInteractableMessage;
    [SerializeField]
    private TextAsset inkJSONAsset = null;
    private int numberOfInteractions = 0;
    public string knotname;
    public string itemID;
    public void Interact()
    {if(!DialogueManager.isInDialogue){
        if(!InformationManager.Instance.hasInteractedQinyi){
            DialogueManager.Instance.badSound.Play();
        }
        if(InformationManager.Instance.hasInteractedQinyi){
        if (numberOfInteractions == 0)
        {
            DialogueManager.Instance.StartStory(inkJSONAsset, knotname);

        } 
        
        if(InventoryManager.Instance.HasItem(itemID)){
            DialogueManager.Instance.StartStory(inkJSONAsset, "done");
        }
        numberOfInteractions++;
        }}
}

}
