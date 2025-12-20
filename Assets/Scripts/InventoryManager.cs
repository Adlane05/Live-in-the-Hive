using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InventoryItem
{
    public string itemId;
    public Sprite icon;
}

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory Settings")]
    public int maxItems = 3;

    [Header("UI")]
    public Image[] inventorySlots;        // 3 UI Images
    public Sprite emptySlotSprite;         // Default empty sprite

    private List<InventoryItem> inventory = new List<InventoryItem>();
    public static InventoryManager Instance;

    void Start()
    {
        UpdateUI();
    }

    void Awake()
    {
        Instance = this;


    }
    // ADD ITEM
    public bool AddItem(InventoryItem item)
    {
        if (inventory.Count >= maxItems)
            return false;

        inventory.Add(item);
        UpdateUI();
        return true;
    }

    // REMOVE ITEM BY ID
    public bool RemoveItem(string itemId)
    {
        InventoryItem item = inventory.Find(i => i.itemId == itemId);
        if (item == null)
            return false;

        inventory.Remove(item);
        UpdateUI();
        return true;
    }

    // CHECK IF PLAYER HAS ITEM
    public bool HasItem(string itemId)
    {
        return inventory.Exists(i => i.itemId == itemId);
    }

    private void UpdateUI()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (i < inventory.Count)
            {
                inventorySlots[i].sprite = inventory[i].icon;
            }
            else
            {
                inventorySlots[i].sprite = emptySlotSprite;
            }
        }
    }
}
