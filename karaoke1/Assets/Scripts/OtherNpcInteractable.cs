using System;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class OtherNpcInteractable : MonoBehaviour, IInteractable
{
    public string InteractMessage => objectInteractableMessage;
    [SerializeField]
    string objectInteractableMessage;
    	[SerializeField]
	private TextAsset inkJSONAsset = null;
    public void Interact()
    {
        UnityEngine.Debug.Log("the wilderness type shit");
        DialogueMana.Instance.StartStory(inkJSONAsset);
    }
}
