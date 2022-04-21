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
        // 드래그 시작시 draggingskill 에 skillPrefab을 생성시켜준다.
        createSkillObject = Instantiate(SkillPrefab, draggingSkillRect);
        createSkillObject.GetComponent<SkillData>().SetSkillData(GetComponent<SkillData>());
        createSkillRect = createSkillObject.GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (SkillPrefab == null) return;

        // 생성한 프리펩의 RectTransform을 마우스 위치에 알맞게 갱신.
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
        // 핫바에만 착지가능. 핫바가 아니라면 destroy
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
            //핫바에 슬롯에만 동작
            if((slotParentUI.CompareTag("Hotbar") && slotParentUI.GetComponent<HotBarSystem>() != null))
            {
                // 슬롯에 아무것도 없는지 검사
                if(dropSlotObject.GetComponentInChildren<ItemData>() == null && dropSlotObject.GetComponentInChildren<SkillData>() == null)
                {
                    createSkillObject.transform.SetParent(dropSlotObject.transform);
                    createSkillObject.transform.localPosition = Vector3.zero;

                    dropSlotObject.transform.GetChild(0).transform.SetAsLastSibling();
                }
                else
                {
                    // 퀵슬롯에 무언가 있을때
                    Destroy(createSkillObject);
                }
            }
        }
        createSkillObject.GetComponent<Image>().raycastTarget = true;
    }

}
