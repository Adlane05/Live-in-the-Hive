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
    if (DialogueManager.isInDialogue)
        return;

    bool hasBoth =
        InventoryManager.Instance.HasItem("Shabloing") &&
        InventoryManager.Instance.HasItem("Shabloing1");

    int interactionIndex = Mathf.Min(numberOfInteractions + 1, maxNumberInteraction);

    if (hasBoth)
    {
        DialogueManager.Instance.StartStory(
            inkJSONAsset,
            knotName2 + interactionIndex
        );
    }
    else
    {
        DialogueManager.Instance.StartStory(
            inkJSONAsset,
            knotName + interactionIndex
        );
    }

    numberOfInteractions++;
}

}
