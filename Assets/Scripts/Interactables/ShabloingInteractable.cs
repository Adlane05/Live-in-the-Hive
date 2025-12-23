using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShabloingInteractable : MonoBehaviour,  IInteractable
{
    public string InteractMessage => objectInteractableMessage;
    [SerializeField]
    string objectInteractableMessage;
    [SerializeField]
    private TextAsset inkJSONAsset = null;
    private int numberOfInteractions = 0;
    [SerializeField]
    public InventoryItem shabloing;
    public AudioSource goodSound;
    public AudioSource badSound;

      public void Interact()
    {if(!DialogueManager.isInDialogue){
     
        if (numberOfInteractions == 0)
        {
            DialogueManager.Instance.StartStory(inkJSONAsset, "visit1");
            objectInteractableMessage = "pick up";

        } else if (numberOfInteractions > 0)
        {
            if(InventoryManager.Instance.AddItem(shabloing)){
            this.gameObject.SetActive(false);
            goodSound.Play();
            } else{
                badSound.Play();
            }
            

        }
        numberOfInteractions++;
        }else{
            badSound.Play();
        }
    }
}




