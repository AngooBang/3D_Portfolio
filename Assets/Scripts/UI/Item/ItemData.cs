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
            itemName = "���� ����";
            itemID = 1;
            itemDesc = "������ ���۵� �����̴�. \n\n ���� +3";
            itemIcon = Resources.Load<Sprite>("Textures/Cap_68");
            itemValue = 1;
            itemType = ItemType.Helmet;
            maxStack = 1;
            itemStats = 3;
            DropItemPrefab = Resources.Load<GameObject>("Prefabs/ItemChest");
        }
        if (id == 2)
        {
            itemName = "ö�� ����";
            itemID = 2;
            itemDesc = "ö���� ���۵� �����̴�. \n\n ���� +6";
            itemIcon = Resources.Load<Sprite>("Textures/Cap_63");
            itemValue = 1;
            itemType = ItemType.Helmet;
            maxStack = 1;
            itemStats = 6;
            DropItemPrefab = Resources.Load<GameObject>("Prefabs/ItemChest");
        }

        if (id == 3)
        {
            itemName = "���� ����";
            itemID = 3;
            itemDesc = "������ ���۵� �����̴�. \n\n ���� +4";
            itemIcon = Resources.Load<Sprite>("Textures/Coat_61");
            itemValue = 1;
            itemType = ItemType.Body;
            maxStack = 1;
            itemStats = 4;
            DropItemPrefab = Resources.Load<GameObject>("Prefabs/ItemChest");
        }
        if (id == 4)
        {
            itemName = "ö�� ����";
            itemID = 4;
            itemDesc = "ö�� ���۵� �����̴�. \n\n ���� +8";
            itemIcon = Resources.Load<Sprite>("Textures/Coat_64");
            itemValue = 1;
            itemType = ItemType.Body;
            maxStack = 1;
            itemStats = 8;
            DropItemPrefab = Resources.Load<GameObject>("Prefabs/ItemChest");
        }

        if (id == 5)
        {
            itemName = "���� �Ź�";
            itemID = 5;
            itemDesc = "������ ���۵� �Ź��̴�. \n\n ���� +3";
            itemIcon = Resources.Load<Sprite>("Textures/Boots_72");
            itemValue = 1;
            itemType = ItemType.Shoes;
            maxStack = 1;
            itemStats = 3;
            DropItemPrefab = Resources.Load<GameObject>("Prefabs/ItemChest");
        }
        if (id == 6)
        {
            itemName = "ö�� �Ź�";
            itemID = 6;
            itemDesc = "ö�� ���۵� �Ź��̴�. \n\n ���� +6";
            itemIcon = Resources.Load<Sprite>("Textures/Boots_64");
            itemValue = 1;
            itemType = ItemType.Shoes;
            maxStack = 1;
            itemStats = 6;
            DropItemPrefab = Resources.Load<GameObject>("Prefabs/ItemChest");
        }

        if (id == 7)
        {
            itemName = "�ʺ����� ��";
            itemID = 7;
            itemDesc = "������ �����ϴ� �ʺ����� ��. \n\n ���ݷ� +10";
            itemIcon = Resources.Load<Sprite>("Textures/Weapon_59");
            itemValue = 1;
            itemType = ItemType.Weapon;
            maxStack = 1;
            itemStats = 10;
            DropItemPrefab = Resources.Load<GameObject>("Prefabs/ItemChest");
        }
        if (id == 8)
        {
            itemName = "����� ��";
            itemID = 8;
            itemDesc = "������ ���⿡�� ���س� ����� ��. \n\n ���ݷ� +20";
            itemIcon = Resources.Load<Sprite>("Textures/Weapon_60");
            itemValue = 1;
            itemType = ItemType.Weapon;
            maxStack = 1;
            itemStats = 20;
            DropItemPrefab = Resources.Load<GameObject>("Prefabs/ItemChest");
        }

        if (id == 11)
        {
            itemName = "ü�� ����";
            itemID = 11;
            itemDesc = "ü���� ȸ�������ִ� ���� \n\n ����� +30";
            itemIcon = Resources.Load<Sprite>("Textures/Potion_4");
            itemValue = 1;
            itemType = ItemType.Consumable;
            maxStack = 5;
            itemStats = 30;
            DropItemPrefab = Resources.Load<GameObject>("Prefabs/ItemChest");
        }
        if (id == 21)
        {
            itemName = "�Ķ� �ź��� ���";
            itemID = 21;
            itemDesc = "�Ķ� �ź����� ����̴�. \n\n ����Ʈ ������.";
            itemIcon = Resources.Load<Sprite>("Textures/Treasure bag_6");
            itemValue = 1;
            itemType = ItemType.Quest;
            maxStack = 3;
            itemStats = 0;
            DropItemPrefab = Resources.Load<GameObject>("Prefabs/ItemChest");
        }
    }

}
