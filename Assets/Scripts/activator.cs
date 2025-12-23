using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activator : MonoBehaviour
{
    public GameObject Object;
    public TextAsset inkJSONAsset = null;
    public string knot;

      private void OnTriggerEnter(Collider other)
    {
        if(InventoryManager.Instance.HasItem("Shabloing") &&
        InventoryManager.Instance.HasItem("Shabloing1") && InventoryManager.Instance.HasItem("Shabloing2") ){
            knot = "access2";
        }
        if (other.CompareTag("Player"))
        {   if(inkJSONAsset != null)
             DialogueManager.Instance.StartStory(inkJSONAsset, knot);
            if(Object != null ){
            Object.SetActive(true);
            GameObject.Find("badsound").GetComponent<AudioSource>().Play();}
             this.gameObject.SetActive(false);
        }
        
    }
}
