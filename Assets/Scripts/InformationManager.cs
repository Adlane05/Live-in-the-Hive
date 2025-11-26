using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FriendshipStruct
{
    public string name;
    public int friendshipScore;
    public string[] inkFilePath;  
    public GameObject characterPrefab;
}
public class InformationManager : MonoBehaviour
{
   public static InformationManager Instance;
    [SerializeField]
    public FriendshipStruct[] friendshipDictionary;
   public int FriendshipShauna = 0;

   void Awake()
    {
        Instance = this;


    }
    public FriendshipStruct GetFriendshipStruct( string name)
    
    {
        foreach ( FriendshipStruct friend in friendshipDictionary)
        {
            if (friend.name == name)
            {
                return friend;
            }
        }
        return null;   
    }
}
