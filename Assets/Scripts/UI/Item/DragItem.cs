using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    //public GameObject ItemUICanvas;

    private RectTransform rectTransformSlot;

    private RectTransform rectTransform;
    private Vector2 pointerOffset;
    private GameObject startParentObject;
    private CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        rectTransformSlot = GameObject.FindGameObjectWithTag("DraggingItem").GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out pointerOffset);
        startParentObject = transform.parent.gameObject;
        transform.SetParent(rectTransformSlot);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.SetAsLastSibling();
        //transform.position = eventData.position;
        canvasGroup.blocksRaycasts = false;
        Vector2 localPointerPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransformSlot, Input.mousePosition, eventData.pressEventCamera, out localPointerPosition))
        {
            rectTransform.localPosition = localPointerPosition - pointerOffset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        GameObject dropSlotObject = null;

        if (eventData.pointerEnter.tag.Equals("Slot"))
            dropSlotObject = eventData.pointerEnter.gameObject;

        if (eventData.pointerEnter.tag.Equals("ItemIcon"))
            dropSlotObject = eventData.pointerEnter.transform.parent.parent.gameObject;
        
        if (dropSlotObject != null)
        {

            GameObject Inventory = dropSlotObject.transform.parent.parent.gameObject;


            if (Inventory.CompareTag("MainInventory") && Inventory.GetComponent<InventorySystem>() != null)
            {
                // 인벤토리의 슬롯이라면
                ItemData firstItem = rectTransform.GetComponent<ItemObject>().item;
                ItemData secondItem = dropSlotObject.GetComponentInChildren<ItemData>();
                if (secondItem == null)
                {
                    transform.SetParent(dropSlotObject.transform);
                    transform.localPosition = Vector3.zero;
                }
                else
                {
                    // 비어있지 않다면?
                    // 같은 아이템인지 확인.
                    if(firstItem.itemID == secondItem.itemID)
                    {
                        // 같은 아이템이면 겹칠수 있는 수량인지 확인.
                        if(firstItem.itemValue + secondItem.itemValue > secondItem.maxStack)
                        {
                            // 전부 통과하면 합치기.
                            int leftStack = secondItem.maxStack - secondItem.itemValue;
                            if(leftStack > firstItem.itemValue)
                            {
                                secondItem.itemValue += firstItem.itemValue;
                                Destroy(firstItem.gameObject);
                            }
                            else
                            {
                                firstItem.itemValue -= leftStack;
                                secondItem.itemValue += leftStack;
                                transform.SetParent(startParentObject.transform);
                                transform.localPosition = Vector3.zero;
                            }
                        }
                        else
                        {
                            // 같은 아이템일지라도 수량이 max라면 자리바꾸기.
                            SwapItemSlot(secondItem.transform.parent);
                        }
                    }
                    else
                    {
                        // 다른 아이템이라면 자리바꾸기.
                        SwapItemSlot(secondItem.transform.parent);
                    }
                }
            }



        }
        else
        {
            transform.SetParent(startParentObject.transform);
            transform.localPosition = Vector3.zero;
        }
    }

    void SwapItemSlot(Transform dropSlot)
    {
        GameObject dropItemObject = dropSlot.GetChild(0).gameObject;
        //자기 위치의 부모(slot)으로 옮겨주고
        dropItemObject.transform.SetParent(startParentObject.transform);
        dropItemObject.transform.localPosition = Vector3.zero;
        // 자신을 대상아이템의 슬롯으로 이동
        gameObject.transform.SetParent(dropSlot);
        gameObject.transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
