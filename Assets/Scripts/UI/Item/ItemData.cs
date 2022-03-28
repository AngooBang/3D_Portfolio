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
    public int indexItemInList = 999;

    //[SerializeField]
    //public List<ItemAttribute> itemAttributes = new List<ItemAttribute>();

    public ItemData() { }

    public ItemData(string name, int id, string desc, Sprite icon, int maxStack, ItemType type, string sendmessagetext/*, List<ItemAttribute> itemAttributes*/)                 //function to create a instance of the Item
    {
        itemName = name;
        itemID = id;
        itemDesc = desc;
        itemIcon = icon;
        itemType = type;
        this.maxStack = maxStack;
        //this.itemAttributes = itemAttributes;
    }

    public ItemData getCopy()
    {
        return (ItemData)this.MemberwiseClone();
    }
}
