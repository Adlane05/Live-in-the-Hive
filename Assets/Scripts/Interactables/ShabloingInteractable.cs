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


      public void Interact()
    {if(!DialogueManager.isInDialogue){
        if (InformationManager.Instance.hasInteractedCabinet)
        {
            DialogueManager.Instance.StartStory(inkJSONAsset, "visit3");
        }
        else if (numberOfInteractions == 0)
        {
            DialogueManager.Instance.StartStory(inkJSONAsset, "visit1");

        } else if (numberOfInteractions > 0)
        {
            DialogueManager.Instance.StartStory(inkJSONAsset, "visit2");

        }
        numberOfInteractions++;
        }
}

}


