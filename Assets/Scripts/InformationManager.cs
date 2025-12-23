using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[Serializable]
public class FriendshipStruct
{
    public string name;
    public int friendshipScore;
    public string[] inkFilePath;  
    
}
public class InformationManager : MonoBehaviour
{

   public static InformationManager Instance;
    [SerializeField]
    public FriendshipStruct[] friendshipDictionary;
    public List<InventoryItem> allItems = new List<InventoryItem>();
    public bool hasInteractedQinyi = false;
    public bool QinyiQuestDone;
    public bool IsHelping;
    public String PlayerName;

    private Dictionary<string, CharResources> activeCharacters = new Dictionary<string, CharResources>();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public FriendshipStruct GetFriendshipStruct(string name)
    {
        return friendshipDictionary.FirstOrDefault(f => f.name == name);
    }

    public void RegisterCharacter(string name, CharResources character)
    {
        activeCharacters[name] = character;
    }

    public void UnregisterCharacter(string name)
    {
        activeCharacters.Remove(name);
    }

    public CharResources GetCharacter(string name)
    {
        activeCharacters.TryGetValue(name, out var character);
        return character;
    }
}

