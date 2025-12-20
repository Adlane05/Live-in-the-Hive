using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    public TextAsset inkJSONAsset = null;

      private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
             DialogueManager.Instance.StartStory(inkJSONAsset, "Kristen1");
             this.gameObject.SetActive(false);
        }
        
    }
}
