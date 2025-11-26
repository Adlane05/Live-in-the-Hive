using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharResources : MonoBehaviour
{
    public FriendshipStruct info;
    public string name;

    public void Start()
    {
        info = InformationManager.Instance.GetFriendshipStruct(name);
    }
}
