using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySystem : MonoBehaviour
{

    public GameObject SlotsObject;

    public GameObject testItemPrefab;

    public TextMeshProUGUI goldText;

    public int goldValue;
    // Start is called before the first frame update
    void Start()
    {
        goldText = transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();
        goldValue = 0;

        
    }

    // Update is called once per frame
    void Update()
    {

        goldText.text = goldValue.ToString();
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            AddItem(Instantiate(testItemPrefab));
        }
    }

    public void AddItem(GameObject AddItemObject)
    {
        ItemData addItemData = AddItemObject.GetComponent<ItemData>();

        foreach (Transform childSlot in SlotsObject.transform)
        {
            ItemData childSlotItemData = childSlot.gameObject.GetComponentInChildren<ItemData>();
            // 같은 아이템이 있는지 있다면 겹칠수 있는지.
            if (childSlotItemData != null)
            {
                if(childSlotItemData.itemID == addItemData.itemID)
                {
                    int leftStack = childSlotItemData.maxStack - childSlotItemData.itemValue;

                    if(leftStack >= addItemData.itemValue)
                    {
                        childSlotItemData.itemValue += addItemData.itemValue;
                        Destroy(addItemData.gameObject);
                        return;
                    }
                    else
                    {
                        // 잔여공간 부족? 그냥 빈곳에 넣자.
                        Debug.Log("가방에 공간이 부족.");
                    }
                }
            }
        }
        // 같은 아이템이 없었거나 넣을수 없었다면 빈곳을 찾아 넣자.
        foreach (Transform childSlot in SlotsObject.transform)
        {            
            // 빈 슬롯이라면.
            if(childSlot.gameObject.GetComponentInChildren<ItemData>() == null)
            {
                AddItemObject.transform.SetParent(childSlot);
                AddItemObject.transform.localPosition = Vector3.zero;
                AddItemObject.transform.localScale= new Vector3(0.2f, 0.2f, 0.2f);
                AddItemObject.name = "Item";
                return;
            }
        }

        // 빈 공간이 없어서 여기까지오면. 로그를띄워보자.
        Debug.Log("인벤토리에 빈 공간이 없습니다.");
        Destroy(AddItemObject);
    }

    public int CheckHaveItemValues(int itemID)
    {
        int totItemValues = 0;
        foreach (Transform childSlot in SlotsObject.transform)
        {
            ItemData childSlotItemData = childSlot.gameObject.GetComponentInChildren<ItemData>();
            if(childSlotItemData != null)
            {
                if(childSlotItemData.itemID == itemID)
                {
                    totItemValues += childSlotItemData.itemValue;
                }
            }
        }
        return totItemValues;
    }

    public void GetCoin(int num)
    {
        goldValue += num;
    }
}
