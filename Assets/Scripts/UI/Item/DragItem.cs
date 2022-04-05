using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    //public GameObject ItemUICanvas;
    public LayerMask WorldLayerMask;

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

        // ������ ���� ����� �������� ���ܻ�Ȳ.
        if (eventData.pointerEnter == null)
        {
            Debug.Log("���忡 �����۶�����.");
            //transform.SetParent(startParentObject.transform);
            //transform.localPosition = Vector3.zero;

            ItemData firstItem = rectTransform.GetComponent<ItemData>();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, 100f, WorldLayerMask);
           

            GameObject dropItemObject = Instantiate(firstItem.DropItemPrefab, hit.point, Quaternion.identity);
            transform.SetParent(dropItemObject.transform);
        
            dropItemObject.GetComponent<ItemChestController>().SetItemData();
            return;
        }
        if (eventData.pointerEnter.tag.Equals("Slot") || 
            eventData.pointerEnter.tag.Equals("HelmetSlot") ||
            eventData.pointerEnter.tag.Equals("BodySlot") || 
            eventData.pointerEnter.tag.Equals("ShoesSlot") ||
            eventData.pointerEnter.tag.Equals("WeaponSlot"))
        {
            dropSlotObject = eventData.pointerEnter.gameObject;
        }

        if (eventData.pointerEnter.tag.Equals("ItemIcon"))
        {
            dropSlotObject = eventData.pointerEnter.transform.parent.parent.gameObject;
        }
        
        if (dropSlotObject != null)
        {

            GameObject slotParentUI = dropSlotObject.transform.parent.parent.gameObject;


            // �κ��丮�� �����̶��
            if ((slotParentUI.CompareTag("MainInventory") && slotParentUI.transform.parent.GetComponent<InventorySystem>() != null) ||
                (slotParentUI.CompareTag("Hotbar") && slotParentUI.GetComponent<HotBarSystem>() != null))
            {
                ItemData firstItem = rectTransform.GetComponent<ItemObject>().item;
                ItemData secondItem = dropSlotObject.GetComponentInChildren<ItemData>();
                if (secondItem == null)
                {
                    transform.SetParent(dropSlotObject.transform);
                    transform.localPosition = Vector3.zero;
                }
                else
                {
                    // ������� �ʴٸ�?
                    // ���� ���������� Ȯ��.
                    if(firstItem.itemID == secondItem.itemID)
                    {
                        // ��ĥ �� �ִ� ���� Ȯ��
                        int leftStack = secondItem.maxStack - secondItem.itemValue;

                        if(leftStack >= firstItem.itemValue)
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
                        if(leftStack == 0)
                        {
                            // ���� ������������ ������ max��� �ڸ��ٲٱ�.
                            SwapItemSlot(dropSlotObject.transform, startParentObject);
                        }
                    }
                    else
                    {
                        // �ٸ� �������̶�� �ڸ��ٲٱ�.
                        SwapItemSlot(dropSlotObject.transform, startParentObject);
                    }
                }
            }

            if(slotParentUI.CompareTag("EquipmentSystem") && slotParentUI.GetComponent<EquipmentSystem>() != null)
            {
                ItemData firstItem = GetComponent<ItemData>();
                ItemData secondItem = dropSlotObject.GetComponentInChildren<ItemData>();

                if(dropSlotObject.CompareTag("HelmetSlot") && firstItem.itemType == ItemType.Helmet)
                {
                    EquipItemUse(dropSlotObject, startParentObject);
                    return;
                }


                if (dropSlotObject.CompareTag("BodySlot") && firstItem.itemType == ItemType.Body)
                {
                    EquipItemUse(dropSlotObject, startParentObject);
                    return;
                }
                

                if (dropSlotObject.CompareTag("ShoesSlot") && firstItem.itemType == ItemType.Shoes)
                {
                    EquipItemUse(dropSlotObject, startParentObject);
                    return;
                }

                if (dropSlotObject.CompareTag("WeaponSlot") && firstItem.itemType == ItemType.Weapon)
                {
                    EquipItemUse(dropSlotObject, startParentObject);
                    return;
                }

                SetDefaultSlot();
            }



        }
        else
        {
            SetDefaultSlot();
        }
    }

    void SwapItemSlot(Transform dropSlot, GameObject parentObject)
    {
        GameObject dropItemObject = dropSlot.GetChild(0).gameObject;
        //�ڱ� ��ġ�� �θ�(slot)���� �Ű��ְ�
        dropItemObject.transform.SetParent(parentObject.transform);
        dropItemObject.transform.localPosition = Vector3.zero;
        // �ڽ��� ���������� �������� �̵�
        gameObject.transform.SetParent(dropSlot);
        gameObject.transform.localPosition = Vector3.zero;
    }

    public void EquipItemUse(GameObject equipSlotObject, GameObject parentObject)
    {
        ItemData equipItem = equipSlotObject.GetComponentInChildren<ItemData>();
        if (equipItem == null)
        {
            transform.SetParent(equipSlotObject.transform);
            transform.localPosition = Vector3.zero;
        }
        else
        {
            SwapItemSlot(equipSlotObject.transform, parentObject);
        }
    }

    void SetDefaultSlot()
    {
        transform.SetParent(startParentObject.transform);
        transform.localPosition = Vector3.zero;
    }

    void DropItem()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
