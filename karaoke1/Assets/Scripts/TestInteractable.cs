using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TestInteractable : MonoBehaviour, IInteractable
{
    public string InteractMessage => objectInteractableMessage;
    [SerializeField]
    string objectInteractableMessage;
    public void Interact()
    {
        UnityEngine.Debug.Log("im dead now thanks");
    }
}
