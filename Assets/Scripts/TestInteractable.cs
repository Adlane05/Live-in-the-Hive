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

    private GameObject chara;
    private void Awake()
{
    chara = this.gameObject;
}
    public void Interact()
    {if(!DialogueManager.isInDialogue){
        UnityEngine.Debug.Log("im dead now thanks");
        DialogueManager.Instance.StartStory(chara, inkJSONAsset);
    }
}}
