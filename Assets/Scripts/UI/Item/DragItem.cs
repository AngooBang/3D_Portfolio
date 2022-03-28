using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    //public GameObject ItemUICanvas;

    public RectTransform rectTransformSlot;

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
            dropSlotObject = eventData.pointerEnter.transform.gameObject;
        
        if (dropSlotObject != null)
        {

            GameObject Inventory = dropSlotObject.transform.parent.parent.gameObject;


            if (Inventory.CompareTag("MainInventory") && Inventory.GetComponent<InventorySystem>() != null)
            {
                // �κ��丮�� �����̶��
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
                    // ���� �������̸� ��ĥ�� �ִ� �������� Ȯ��.
                    // ���� ����ϸ� ��ġ��.
                    // ���� ������������ ������ max��� �ڸ��ٲٱ�.
                    // �ٸ� �������̶�� �ڸ��ٲٱ�.
                }
            }



        }
        else
        {
            transform.SetParent(startParentObject.transform);
            transform.localPosition = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
