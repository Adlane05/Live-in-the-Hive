using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
public class InteractionController : MonoBehaviour
{
    [SerializeField]
    Camera playerCamera;
    [SerializeField]
    Text interactionText;
    [SerializeField]
    float interactionDistance = 5f;
    bool hasInteractedWhileLooking = false;

    IInteractable currentTargetedInteractable;

    public void Update()
    {
        UpdateCurrentInteractable();

        UpdateInteractionText();

        CheckForInteractionInput();
    }

    void UpdateCurrentInteractable()
{
    var ray = playerCamera.ViewportPointToRay(new UnityEngine.Vector2(0.5f, 0.5f));
    Physics.Raycast(ray, out var hit, interactionDistance);

    var newTarget = hit.collider?.GetComponent<IInteractable>();

    if (newTarget != currentTargetedInteractable)
    {
        hasInteractedWhileLooking = false;
    }

    currentTargetedInteractable = newTarget;
}

    void UpdateInteractionText()
{
    if (currentTargetedInteractable == null)
    {
        interactionText.text = string.Empty;
        return;
    }

    if (hasInteractedWhileLooking)
    {
        interactionText.text = string.Empty;
        return;
    }

    interactionText.text = currentTargetedInteractable.InteractMessage;
}

    void CheckForInteractionInput()
{
    if (Input.GetKeyDown(KeyCode.E) && currentTargetedInteractable != null)
    {
        currentTargetedInteractable.Interact();

        hasInteractedWhileLooking = true;

        interactionText.text = string.Empty;
    }
}

}
