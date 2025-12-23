using System;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class LostInteractable : MonoBehaviour, IInteractable
{
    public string InteractMessage => objectInteractableMessage;
    [SerializeField]
    string objectInteractableMessage;
    [SerializeField]
    private TextAsset inkJSONAsset = null;
    public int numberOfInteractions = 0;
    public bool hasHelped;
    public void Interact()
{
    if (DialogueManager.isInDialogue)
        return;

    if (InformationManager.Instance.IsHelping &&
        InventoryManager.Instance.HasItem("Shabloing1"))
    {
        numberOfInteractions = 0;
        hasHelped = true;

        DialogueManager.Instance.StartStory(inkJSONAsset, "lostOne5");
        return;
    }

    if (hasHelped && !InventoryManager.Instance.HasItem("Shabloing"))
    {
        DialogueManager.Instance.StartStory(
            inkJSONAsset,
            numberOfInteractions == 0 ? "lostOneNoShabloing" : "lostOneNoShabloing1"
        );

        numberOfInteractions++;
        return;
    }

    if (hasHelped && InventoryManager.Instance.HasItem("Shabloing"))
    {
        DialogueManager.Instance.StartStory(
            inkJSONAsset,
            numberOfInteractions == 0 ? "lostOneShabloing" : "lostOneShabloing1"
        );

        numberOfInteractions++;
        return;
    }

    if (InformationManager.Instance.IsHelping)
    {
        if (numberOfInteractions == 0)
            DialogueManager.Instance.StartStory(inkJSONAsset, "lostOne2");
        else if (numberOfInteractions == 1)
            DialogueManager.Instance.StartStory(inkJSONAsset, "lostOne3");
        else
            DialogueManager.Instance.StartStory(inkJSONAsset, "lostOne4");

        numberOfInteractions++;
        return;
    }

    // NOT HELPING
    DialogueManager.Instance.StartStory(inkJSONAsset, "lostOne1");
}

}