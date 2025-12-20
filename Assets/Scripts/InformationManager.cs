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
    public List<InventoryItem> allItems = new List<InventoryItem>();
    public bool hasInteractedQinyi = false;
    public bool QinyiQuestDone;
    public GameObject tableContents;
   void Awake()
    {
        Instance = this;


    }
    public void Update(){
        if(QinyiQuestDone){
            tableContents.SetActive(true);
        }
    }
    public FriendshipStruct GetFriendshipStruct( string name)
    
    {
        name = name.Trim(' ');
        foreach ( FriendshipStruct friend in friendshipDictionary)
        {
            if (friend.name == name)
            {
                return friend;

            }
        }
        Debug.Log("Cant find struct");
        return null;   
    }
}
