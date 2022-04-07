using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropManager : MonoBehaviour
{
    public GameObject CoinPrefab;
    public GameObject ItemObjectPrefab;
    public InventorySystem inventorySystem;

    public Dictionary<int, ItemData> itemList;
    private void Awake()
    {
        itemList = new Dictionary<int, ItemData>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateItemData(1);
        GenerateItemData(2);
        GenerateItemData(3);
        GenerateItemData(4);
        GenerateItemData(5);
        GenerateItemData(6);
        GenerateItemData(7);
        GenerateItemData(8);
        GenerateItemData(11);
        inventorySystem = GameObject.FindGameObjectWithTag("MainInventory").GetComponent<InventorySystem>();

        CreateItemInInventory(1);
        CreateItemInInventory(3);
        CreateItemInInventory(5);
        CreateItemInInventory(7);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad0))
        {
            CreateItemOnWorld(1, new Vector3(0, 0, 0));
        }


        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            CreateItemInInventory(11);
        }
    }

    void GenerateItemData(int itemID)
    {
        ItemData item = new ItemData(itemID);
        itemList.Add(itemID, item);
    }
    void DropGold(Transform dropTrans)
    {
        Instantiate(CoinPrefab, dropTrans);
    }

    void MonsterDropItem(int monsterID, Transform dropTrans)
    {
        // json�� ���� mosterID�� �ش��ϴ� (����Ҽ� �ִ� �ּ� ���, �ִ� ���, ������ID, Ȯ�� �� �����´�)
        // ���� ��������Ϳ��� �޾ƿ� ������ ���� �����۵����͸���Ʈ�� ������ ���忡 ������ ����
    }

    void CreateItemOnWorld(int itemID, Vector3 worldVec)
    {
        // itemId�� �޾ƿ� �ش� ���̵� �˸´� �������� �ش� transform�� ������Ŵ.
        if(itemList.ContainsKey(itemID))
        {
            //�������� �켱 ����� ����������Ʈ�� �־������
            GameObject itemObject = Instantiate(ItemObjectPrefab);

            ItemData createItem = itemObject.GetComponent<ItemData>();

            createItem.SetItemData(itemList[itemID]);


            GameObject createDropObject = Instantiate(createItem.DropItemPrefab, worldVec, Quaternion.identity);

            itemObject.transform.SetParent(createDropObject.transform);

            createDropObject.GetComponent<ItemChestController>().SetItemData();
        }
    }

    void CreateItemInInventory(int itemID)
    {
        if (itemList.ContainsKey(itemID))
        {

            GameObject itemObject = Instantiate(ItemObjectPrefab);
            ItemData createItem = itemObject.GetComponent<ItemData>();

            createItem.SetItemData(itemList[itemID]);

            inventorySystem.AddItem(itemObject);
        }

    }
}
