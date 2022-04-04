using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData : MonoBehaviour
{
    public string itemName;                   
    public int itemID;                        
    public string itemDesc;                   
    public Sprite itemIcon;                    
    public int itemValue = 1;                 
    public ItemType itemType;                 
    public int maxStack = 1;
    public int itemStats;
    public GameObject DropItemPrefab;

    public ItemData(ItemData item)
    {
        this.itemName = item.itemName;
        this.itemID = item.itemID;
        this.itemDesc = item.itemDesc;
        this.itemIcon = item.itemIcon;
        this.itemValue = item.itemValue;
        this.itemType = item.itemType;
        this.maxStack = item.maxStack;
        this.itemStats = item.itemStats;
        this.DropItemPrefab = item.DropItemPrefab;
    }

}
