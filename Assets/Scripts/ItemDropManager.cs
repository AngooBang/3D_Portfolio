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
        inventorySystem = GameObject.FindGameObjectWithTag("MainInventory").GetComponent<InventorySystem>();

        GenerateItemData(1);
        GenerateItemData(2);
        GenerateItemData(3);
        GenerateItemData(4);
        GenerateItemData(5);
        GenerateItemData(6);
        GenerateItemData(7);
        GenerateItemData(8);
        GenerateItemData(11);
        GenerateItemData(12);
        GenerateItemData(21);
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
            CreateItemInInventory(21);
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

    public void MonsterDropItem(int monsterID, Transform dropTrans)
    {
        // json을 통해 mosterID에 해당하는 (드랍할수 있는 최소 골드, 최대 골드, 아이템ID, 확률 을 가져온다)
        // 몬스터 드랍데이터에서 받아온 정보를 토대로 아이템데이터리스트에 접근해 월드에 아이템 생성

        MonsterDropData dropData = GetComponent<MonsterDropDataJsonMaker>().ExtractToDropDataOfMonsterID(monsterID);
        int goldNum = Random.Range(dropData.minGold, dropData.maxGold);
        for(int i = 0; i < goldNum; ++i)
        {
            DropGold(dropTrans);
        }

        for(int i = 0; i < dropData.dropItems.Length; ++i)
        {
            int dropRandNum = Random.Range(0, 100);
            if(dropRandNum < dropData.itemDropPercents[i])
            {
                Debug.Log($"{dropData.itemDropPercents[i]}% 확률로 {dropData.dropItems[i]}의 아이템 드랍.");
                CreateItemOnWorld(dropData.dropItems[i], dropTrans.position);
            }
        }
    }

    public void CreateItemOnWorld(int itemID, Vector3 worldVec)
    {
        // itemId를 받아와 해당 아이디에 알맞는 아이템을 해당 transform에 생성시킴.
        if(itemList.ContainsKey(itemID))
        {
            //아이템을 우선 만들고 ㄷ랍오브젝트에 넣어줘야해
            GameObject itemObject = Instantiate(ItemObjectPrefab);

            ItemData createItem = itemObject.GetComponent<ItemData>();

            createItem.SetItemData(itemList[itemID]);


            GameObject createDropObject = Instantiate(createItem.DropItemPrefab, worldVec, Quaternion.identity);

            itemObject.transform.SetParent(createDropObject.transform);

            createDropObject.GetComponent<ItemChestController>().SetItemData();
        }
    }

    public void CreateItemInInventory(int itemID)
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
