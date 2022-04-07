using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
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

    public void SetItemData(ItemData item)
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

    public ItemData(int id)
    {
        if(id == 1)
        {
            itemName = "목제 투구";
            itemID = 1;
            itemDesc = "목제로 제작된 투구이다. \n\n 방어력 +3";
            itemIcon = Resources.Load<Sprite>("Textures/Cap_68");
            itemValue = 1;
            itemType = ItemType.Helmet;
            maxStack = 1;
            itemStats = 3;
            DropItemPrefab = Resources.Load<GameObject>("Prefabs/ItemChest");
        }
        if (id == 2)
        {
            itemName = "철제 투구";
            itemID = 2;
            itemDesc = "철제로 제작된 투구이다. \n\n 방어력 +6";
            itemIcon = Resources.Load<Sprite>("Textures/Cap_63");
            itemValue = 1;
            itemType = ItemType.Helmet;
            maxStack = 1;
            itemStats = 6;
            DropItemPrefab = Resources.Load<GameObject>("Prefabs/ItemChest");
        }

        if (id == 3)
        {
            itemName = "목제 갑옷";
            itemID = 3;
            itemDesc = "목제로 제작된 갑옷이다. \n\n 방어력 +4";
            itemIcon = Resources.Load<Sprite>("Textures/Coat_61");
            itemValue = 1;
            itemType = ItemType.Body;
            maxStack = 1;
            itemStats = 4;
            DropItemPrefab = Resources.Load<GameObject>("Prefabs/ItemChest");
        }
        if (id == 4)
        {
            itemName = "철제 갑옷";
            itemID = 4;
            itemDesc = "철로 제작된 갑옷이다. \n\n 방어력 +8";
            itemIcon = Resources.Load<Sprite>("Textures/Coat_64");
            itemValue = 1;
            itemType = ItemType.Body;
            maxStack = 1;
            itemStats = 8;
            DropItemPrefab = Resources.Load<GameObject>("Prefabs/ItemChest");
        }

        if (id == 5)
        {
            itemName = "목제 신발";
            itemID = 5;
            itemDesc = "목제로 제작된 신발이다. \n\n 방어력 +3";
            itemIcon = Resources.Load<Sprite>("Textures/Boots_72");
            itemValue = 1;
            itemType = ItemType.Shoes;
            maxStack = 1;
            itemStats = 3;
            DropItemPrefab = Resources.Load<GameObject>("Prefabs/ItemChest");
        }
        if (id == 6)
        {
            itemName = "철제 신발";
            itemID = 6;
            itemDesc = "철로 제작된 신발이다. \n\n 방어력 +6";
            itemIcon = Resources.Load<Sprite>("Textures/Boots_64");
            itemValue = 1;
            itemType = ItemType.Shoes;
            maxStack = 1;
            itemStats = 6;
            DropItemPrefab = Resources.Load<GameObject>("Prefabs/ItemChest");
        }

        if (id == 7)
        {
            itemName = "초보자의 검";
            itemID = 7;
            itemDesc = "여행을 시작하는 초보자의 검. \n\n 공격력 +10";
            itemIcon = Resources.Load<Sprite>("Textures/Weapon_59");
            itemValue = 1;
            itemType = ItemType.Weapon;
            maxStack = 1;
            itemStats = 10;
            DropItemPrefab = Resources.Load<GameObject>("Prefabs/ItemChest");
        }
        if (id == 8)
        {
            itemName = "용사의 검";
            itemID = 8;
            itemDesc = "마을을 위기에서 구해낼 용사의 검. \n\n 공격력 +20";
            itemIcon = Resources.Load<Sprite>("Textures/Weapon_60");
            itemValue = 1;
            itemType = ItemType.Weapon;
            maxStack = 1;
            itemStats = 20;
            DropItemPrefab = Resources.Load<GameObject>("Prefabs/ItemChest");
        }

        if (id == 11)
        {
            itemName = "체력 포션";
            itemID = 11;
            itemDesc = "체력을 회복시켜주는 포션 \n\n 생명력 +30";
            itemIcon = Resources.Load<Sprite>("Textures/Potion_4");
            itemValue = 1;
            itemType = ItemType.Consumable;
            maxStack = 5;
            itemStats = 30;
            DropItemPrefab = Resources.Load<GameObject>("Prefabs/ItemChest");
        }
        if (id == 21)
        {
            itemName = "파랑 거북이 등껍질";
            itemID = 21;
            itemDesc = "파랑 거북이의 등껍질이다. \n\n 퀘스트 아이템.";
            itemIcon = Resources.Load<Sprite>("Textures/Treasure bag_6");
            itemValue = 1;
            itemType = ItemType.Quest;
            maxStack = 3;
            itemStats = 0;
            DropItemPrefab = Resources.Load<GameObject>("Prefabs/ItemChest");
        }
    }

}
