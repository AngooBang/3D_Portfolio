using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UseItem : MonoBehaviour, IPointerClickHandler
{

    public PlayerStatus pStatus;
    public EquipmentSystem equipmentSystem;

    public GameObject startParentObject;
    private ItemData itemData;
    // Start is called before the first frame update
    void Start()
    {

        itemData = GetComponent<ItemData>();

        pStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        equipmentSystem = GameObject.FindGameObjectWithTag("InterfaceUI").transform.GetChild(2).GetComponent<EquipmentSystem>();
        // ������������ �޾ƿ´� 
        // ��Ŭ�� �Է½� ���Ǵ� �Լ��� ����
        // ������ Ÿ�� �� ���̵� ���� �ٸ��� ����Ǵ� �Լ��� ����
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            startParentObject = transform.parent.gameObject;
            Use();
        }
    }

    public void Use()
    {
        //������ �������� ������Ÿ����
        switch (itemData.itemType)
        {
            // ���������϶�
            case ItemType.Consumable:
                ConsumableItemUse();
                break;
            case ItemType.Helmet:
                GetComponent<DragItem>().EquipItemUse(equipmentSystem.helmetSlotObject, startParentObject);
                break;
            case ItemType.Body:
                GetComponent<DragItem>().EquipItemUse(equipmentSystem.bodySlotObject, startParentObject);
                break;
            case ItemType.Shoes:
                GetComponent<DragItem>().EquipItemUse(equipmentSystem.shoesSlotObject, startParentObject);
                break;
            case ItemType.Weapon:
                GetComponent<DragItem>().EquipItemUse(equipmentSystem.weaponSlotObject, startParentObject);
                break;
        }

    }

    void ConsumableItemUse()
    {
        //ü�� ����
        if(itemData.itemID == 11)
        {
            pStatus.HealthRecovery(itemData.itemStats);
            itemData.itemValue--;
            if(itemData.itemValue == 0)
            {
                Destroy(gameObject);
            }
        }

        if(itemData.itemID == 12)
        {
            pStatus.CurrentSP += itemData.itemStats;
            if (pStatus.CurrentSP > pStatus.MaxSP)
            {
                pStatus.CurrentSP = pStatus.MaxSP;
            }
        }
    }

}
