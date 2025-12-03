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
    public GameObject character;
}
public class InformationManager : MonoBehaviour
{
   public static InformationManager Instance;
    [SerializeField]
    public FriendshipStruct[] friendshipDictionary;
    public String StandChoice = "null"
   void Awake()
    {
        Instance = this;


    }
    public FriendshipStruct GetFriendshipStruct( string name)
    
    {
        name = name.Trim(' ');
        Debug.Log("Search for friend");
        foreach ( FriendshipStruct friend in friendshipDictionary)
        {
            if (friend.name == name)
            {
                Debug.Log(friend.name);
                return friend;

            }
        }
        Debug.Log("Cant find struct");
        return null;   
    }
}
