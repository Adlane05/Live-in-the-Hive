using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericInterable : MonoBehaviour, IInteractable
{
    public string InteractMessage => objectInteractableMessage;
    [SerializeField]
    string objectInteractableMessage;
    [SerializeField]
    private TextAsset inkJSONAsset = null;
    private int numberOfInteractions = 0;
    public int maxNumberInteraction = 0;
    public string knotName ="visit";

    private GameObject chara;
    private void Awake()
    {
        chara = this.gameObject;
    }
    public void Interact()
    {
        if(!DialogueManager.isInDialogue)
        {
            if (numberOfInteractions < maxNumberInteraction)
            {
                Debug.Log("GenericInteract bellow");
                DialogueManager.Instance.StartStory(inkJSONAsset, knotName + (numberOfInteractions + 1));
            }
            else 
            {
                Debug.Log("GenericInteract above");
                DialogueManager.Instance.StartStory(inkJSONAsset, knotName + maxNumberInteraction);
            }
            numberOfInteractions++;
        }   
    }
}
