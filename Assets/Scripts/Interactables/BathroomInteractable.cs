using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BathroomInteractable : MonoBehaviour, IInteractable
{
    public string InteractMessage => objectInteractableMessage;
    [SerializeField]
    string objectInteractableMessage;
    [SerializeField]
    private TextAsset inkJSONAsset = null;
    [SerializeField]
    public InventoryItem shabloing;
    private int numberOfInteractions;
    public AudioSource goodSound;
    public AudioSource badSound;

     public CanvasGroup fadeCanvasGroup; // Reference to the Canvas Group component
    public float fadeDuration = 2.0f; // Duration of the fade effect

    // Call this function to fade to black
    public void FadeToBlack()
    {
        StartCoroutine(FadeCanvasGroupAlpha(fadeCanvasGroup, 0, 1, fadeDuration));
    }

    // Call this function to fade in from black
    public void FadeFromBlack()
    {
        StartCoroutine(FadeCanvasGroupAlpha(fadeCanvasGroup, 1, 0, fadeDuration));
    }

    // Coroutine to handle the fading
    IEnumerator FadeCanvasGroupAlpha(CanvasGroup cg, float startAlpha, float endAlpha, float duration)
    {
        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            cg.alpha = Mathf.Lerp(startAlpha, endAlpha, t / duration);
            yield return null; 
        }
        cg.alpha = endAlpha;
    }
    public void Interact(){
        if(!DialogueManager.isInDialogue){
            if(InformationManager.Instance.hasInteractedQinyi && numberOfInteractions < 1 && InventoryManager.Instance.HasItem("empty")){
                numberOfInteractions++;
            FadeToBlack();
            goodSound.Play();
            Invoke("FadeFromBlack",4);
            Invoke("readtext",5);
        } else{
            badSound.Play();
        }
    }
    }
    public void readtext(){
        DialogueManager.Instance.StartStory(inkJSONAsset, "BATHROOM");
    }
}
