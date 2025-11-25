using System;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class OtherNpcInteractable : MonoBehaviour, IInteractable
{
    public string InteractMessage => objectInteractableMessage;
    [SerializeField]
    string objectInteractableMessage;
    [SerializeField]
    private TextAsset inkJSONAsset = null;
    private int numberOfInteractions = 0;
    private GameObject chara;
    private void Awake()
{
    chara = this.gameObject;
}
    public void Interact()
    {
        /*GetComponentInParent<SimpleRoam>().enabled = (false);
        // Stops the NPC from navigating by setting the destination to where it is already
        GetComponentInParent<NavMeshAgent>().destination = transform.position;*/
        if(!DialogueManager.isInDialogue){
        if (numberOfInteractions == 0)
        {
            DialogueManager.Instance.StartStory(chara, inkJSONAsset);
        }
        else if (numberOfInteractions == 1)
        {
            DialogueManager.Instance.StartStory(chara, inkJSONAsset, "visit2");

        }
        else if (numberOfInteractions == 2)
        {
            DialogueManager.Instance.StartStory(chara, inkJSONAsset, "visit3");
        }
        numberOfInteractions++;
        }
    }
}
