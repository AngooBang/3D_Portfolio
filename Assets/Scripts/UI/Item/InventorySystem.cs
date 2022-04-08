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
            // ���� �������� �ִ��� �ִٸ� ��ĥ�� �ִ���.
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
                        // �ܿ����� ����? �׳� ����� ����.
                        Debug.Log("���濡 ������ ����.");
                    }
                }
            }
        }
        // ���� �������� �����ų� ������ �����ٸ� ����� ã�� ����.
        foreach (Transform childSlot in SlotsObject.transform)
        {            
            // �� �����̶��.
            if(childSlot.gameObject.GetComponentInChildren<ItemData>() == null)
            {
                AddItemObject.transform.SetParent(childSlot);
                AddItemObject.transform.localPosition = Vector3.zero;
                AddItemObject.transform.localScale= new Vector3(0.2f, 0.2f, 0.2f);
                AddItemObject.name = "Item";
                return;
            }
        }

        // �� ������ ��� �����������. �α׸��������.
        Debug.Log("�κ��丮�� �� ������ �����ϴ�.");
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
