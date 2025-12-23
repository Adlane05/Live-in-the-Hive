using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharResources : MonoBehaviour
{
    public string characterName;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        if (InformationManager.Instance != null)
        {
            InformationManager.Instance.RegisterCharacter(characterName, this);
        }
        else
        {
            Debug.LogError(
                $"InformationManager not found when registering {characterName}",
                this
            );
        }
    }

    void OnDestroy()
    {
        if (InformationManager.Instance != null)
        {
            InformationManager.Instance.UnregisterCharacter(characterName);
        }
    }

    public Animator GetAnimator()
    {
        return animator;
    }
}
