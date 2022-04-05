using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TooltipSystem tooltipSystem;


    public Vector3 inventoryTooltipOffset;
    public Vector3 hotbarTooltipOffset;

    private ItemData itemData;

    
    // Start is called before the first frame update
    void Start()
    {
        tooltipSystem = GameObject.FindGameObjectWithTag("Tooltip").GetComponent<TooltipSystem>();
        itemData = GetComponent<ItemData>();
        inventoryTooltipOffset = new Vector3(25, -25, 0);
        hotbarTooltipOffset = new Vector3(23, 27, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltipSystem.isShowTooltip = true;
        tooltipSystem.TooltipItemIcon.sprite = itemData.itemIcon;
        tooltipSystem.TooltipItemName.text = itemData.itemName;
        tooltipSystem.TooltipItemDescription.text = itemData.itemDesc;

        if(transform.parent.parent.parent.parent.gameObject.GetComponent<InventorySystem>() != null ||
            transform.parent.parent.parent.gameObject.GetComponent<EquipmentSystem>() != null)
        {
            //인벤토리일때 위치지정
            tooltipSystem.gameObject.transform.position = transform.position + inventoryTooltipOffset;
            tooltipSystem.isInventoryTooltip = true;
            tooltipSystem.isHotbarTooltip = false;
            tooltipSystem.isSkillTooltip = false;

        }

        if (transform.parent.parent.parent.gameObject.GetComponent<HotBarSystem>() != null)
        {
            //핫바일때 위치지정
            tooltipSystem.gameObject.transform.position = transform.position + hotbarTooltipOffset;
            tooltipSystem.isInventoryTooltip = false;
            tooltipSystem.isHotbarTooltip = true;
            tooltipSystem.isSkillTooltip = false;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipSystem.isShowTooltip = false;
    }
}
