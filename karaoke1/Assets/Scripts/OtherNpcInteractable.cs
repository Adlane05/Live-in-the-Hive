using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class OtherNpcInteractable : MonoBehaviour, IInteractable
{
    public string InteractMessage => objectInteractableMessage;
    [SerializeField]
    string objectInteractableMessage;
    public void Interact()
    {
        UnityEngine.Debug.Log("the wilderness type shit");
    }
}
