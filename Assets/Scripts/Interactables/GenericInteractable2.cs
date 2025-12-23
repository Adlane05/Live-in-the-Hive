using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericInterable2 : MonoBehaviour, IInteractable
{
    public string InteractMessage => objectInteractableMessage;
    [SerializeField]
    string objectInteractableMessage;
    [SerializeField]
    private TextAsset inkJSONAsset = null;
    private int numberOfInteractions = 0;
    public int maxNumberInteraction = 0;
    public string knotName ="visit";
    public string knotName2 ="visit";

    private GameObject chara;
    private void Awake()
    {
        chara = this.gameObject;
    }
    public void Interact()
    {
        if(!DialogueManager.isInDialogue)
        { 
            if (!InventoryManager.Instance.HasItem("Shabloing") && !InventoryManager.Instance.HasItem("Shabloing1") && numberOfInteractions < maxNumberInteraction)
            {
                DialogueManager.Instance.StartStory(inkJSONAsset, knotName + (numberOfInteractions + 1));
            }
            else 
            {
                DialogueManager.Instance.StartStory(inkJSONAsset, knotName + maxNumberInteraction);
            }
             if (InventoryManager.Instance.HasItem("Shabloing") && InventoryManager.Instance.HasItem("Shabloing1") && numberOfInteractions < maxNumberInteraction)
            {
                DialogueManager.Instance.StartStory(inkJSONAsset, knotName2 + (numberOfInteractions + 1));
            }
            else 
            {
                DialogueManager.Instance.StartStory(inkJSONAsset, knotName2 + maxNumberInteraction);
            }
            numberOfInteractions++;
            
        }   
    }
}
