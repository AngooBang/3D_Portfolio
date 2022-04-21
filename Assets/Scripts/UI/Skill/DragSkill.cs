using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragSkill : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public GameObject SkillPrefab;

    private GameObject createSkillObject;
    private RectTransform draggingSkillRect;
    private RectTransform createSkillRect;

    private void Start()
    {
        draggingSkillRect = GameObject.FindGameObjectWithTag("SkillUI").transform.GetChild(0).GetChild(2).GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (SkillPrefab == null) return;
        if(createSkillObject != null)
        {
            Destroy(createSkillObject);
        }
        // �巡�� ���۽� draggingskill �� skillPrefab�� ���������ش�.
        createSkillObject = Instantiate(SkillPrefab, draggingSkillRect);
        createSkillObject.GetComponent<SkillData>().SetSkillData(GetComponent<SkillData>());
        createSkillRect = createSkillObject.GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (SkillPrefab == null) return;

        // ������ �������� RectTransform�� ���콺 ��ġ�� �˸°� ����.
        createSkillRect.SetAsLastSibling();
        createSkillObject.GetComponent<Image>().raycastTarget = false;
        Vector2 localPointerPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(draggingSkillRect, Input.mousePosition, eventData.pressEventCamera, out localPointerPosition))
        {
            createSkillRect.localPosition = localPointerPosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (SkillPrefab == null) return;
        // �ֹٿ��� ��������. �ֹٰ� �ƴ϶�� destroy
        GameObject dropSlotObject = null;


        if (eventData.pointerEnter.tag.Equals("Slot"))
        {
            dropSlotObject = eventData.pointerEnter.gameObject;
        }
        else
        {
            Destroy(createSkillObject);
        }

        if(dropSlotObject != null)
        {

            GameObject slotParentUI = dropSlotObject.transform.parent.parent.gameObject;
            //�ֹٿ� ���Կ��� ����
            if((slotParentUI.CompareTag("Hotbar") && slotParentUI.GetComponent<HotBarSystem>() != null))
            {
                // ���Կ� �ƹ��͵� ������ �˻�
                if(dropSlotObject.GetComponentInChildren<ItemData>() == null && dropSlotObject.GetComponentInChildren<SkillData>() == null)
                {
                    createSkillObject.transform.SetParent(dropSlotObject.transform);
                    createSkillObject.transform.localPosition = Vector3.zero;

                    dropSlotObject.transform.GetChild(0).transform.SetAsLastSibling();
                }
                else
                {
                    // �����Կ� ���� ������
                    Destroy(createSkillObject);
                }
            }
        }
        createSkillObject.GetComponent<Image>().raycastTarget = true;
    }

}
