using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QinyiInteractable : MonoBehaviour, IInteractable
{
    public string InteractMessage => objectInteractableMessage;
    [SerializeField]
    string objectInteractableMessage;
    [SerializeField]
    private TextAsset inkJSONAsset = null;
    private int numberOfInteractions = 0;
    private bool hasGivenPaint;
    private bool hasGivenPapers;
    private bool hasGivenWater;
    public void Interact()
    
    {
        if(!DialogueManager.isInDialogue)
        {        
            InformationManager.Instance.hasInteractedQinyi = true;
            if(InventoryManager.Instance.HasItem("full") && hasGivenPapers && hasGivenPaint){
                hasGivenPaint = true;
                DialogueManager.Instance.StartStory(inkJSONAsset, "FINALQinyi2");
                InformationManager.Instance.QinyiQuestDone = true;
                
            }
            if(InventoryManager.Instance.HasItem("full") && InventoryManager.Instance.HasItem("papers") && InventoryManager.Instance.HasItem("tubes")){
                hasGivenPapers = true;
                hasGivenPaint = true;
                hasGivenWater = true;
                DialogueManager.Instance.StartStory(inkJSONAsset, "FINALQinyi");
                InformationManager.Instance.QinyiQuestDone = true;

                
            }
            if(InventoryManager.Instance.HasItem("tubes") && InventoryManager.Instance.HasItem("papers") && !hasGivenWater){
                hasGivenPaint = true;
                hasGivenPapers = true;
                DialogueManager.Instance.StartStory(inkJSONAsset, "QinyiWater");
            }
            if(InventoryManager.Instance.HasItem("full") && hasGivenPapers && hasGivenPaint){
                hasGivenPaint = true;
                DialogueManager.Instance.StartStory(inkJSONAsset, "FINALQinyi");
                
            }
            if(InventoryManager.Instance.HasItem("full") && InventoryManager.Instance.HasItem("papers") && InventoryManager.Instance.HasItem("tubes")){
                hasGivenPapers = true;
                hasGivenPaint = true;
                hasGivenWater = true;
                DialogueManager.Instance.StartStory(inkJSONAsset, "FINALQinyi");
                
            }
            if(InventoryManager.Instance.HasItem("papers") && !hasGivenPaint){
                hasGivenPapers = true;
                DialogueManager.Instance.StartStory(inkJSONAsset, "QinyiPaper1");
            }
            
            if(InventoryManager.Instance.HasItem("tubes") && !hasGivenPapers){
                hasGivenPaint = true;
                DialogueManager.Instance.StartStory(inkJSONAsset, "QinyiTubes1");
                
            }
            
            if(InventoryManager.Instance.HasItem("tubes") && hasGivenPapers){
                hasGivenPaint = true;
                DialogueManager.Instance.StartStory(inkJSONAsset, "QinyiTubes2");
                
            }
            if(InventoryManager.Instance.HasItem("papers") && hasGivenPaint){
                hasGivenPapers = true;
                DialogueManager.Instance.StartStory(inkJSONAsset, "QinyiPaper2");
            }
            if(hasGivenPaint && !hasGivenPapers && !hasGivenWater){
                DialogueManager.Instance.StartStory(inkJSONAsset, "QinyiTubes");
                
            }
            if(hasGivenPapers && !hasGivenPaint && !hasGivenWater){
                DialogueManager.Instance.StartStory(inkJSONAsset, "QinyiPaper");
            }
            if(InventoryManager.Instance.HasItem("tubes") && InventoryManager.Instance.HasItem("papers") && !hasGivenWater){
                hasGivenPaint = true;
                hasGivenPapers = true;
                DialogueManager.Instance.StartStory(inkJSONAsset, "QinyiWater");
            }
            if(hasGivenPaint && hasGivenPapers && !hasGivenWater){
                DialogueManager.Instance.StartStory(inkJSONAsset, "QinyiWater2");
            }
            if(!hasGivenPaint && !hasGivenPapers && !hasGivenWater && numberOfInteractions > 0){
                DialogueManager.Instance.StartStory(inkJSONAsset, "Qinyi");
            }
            if(!hasGivenPaint && !hasGivenPapers && !hasGivenWater){
                DialogueManager.Instance.StartStory(inkJSONAsset, "Qinyi1");
                numberOfInteractions++;
            }
           
        }   
    }
}
