using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuyShopItem : MonoBehaviour, IPointerClickHandler
{
    public int ProductPrice;
    public int ProductID;
    private InventorySystem inventorySystem;
    private ItemDropManager dropManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            if(inventorySystem.goldValue >= ProductPrice)
            {
                dropManager.CreateItemInInventory(ProductID);
                inventorySystem.goldValue -= ProductPrice;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        inventorySystem = GameObject.FindGameObjectWithTag("MainInventory").GetComponent<InventorySystem>();
        dropManager = GameObject.FindGameObjectWithTag("DropManager").GetComponent<ItemDropManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
