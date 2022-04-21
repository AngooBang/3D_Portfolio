using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        // 드래그 시작시 draggingskill 에 skillPrefab을 생성시켜준다.
        createSkillObject = Instantiate(SkillPrefab, draggingSkillRect);
        createSkillObject.GetComponent<SkillData>().SetSkillData(GetComponent<SkillData>());
        createSkillRect = createSkillObject.GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 생성한 프리펩의 RectTransform을 마우스 위치에 알맞게 갱신.
        createSkillRect.SetAsLastSibling();

        Vector2 localPointerPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(draggingSkillRect, Input.mousePosition, eventData.pressEventCamera, out localPointerPosition))
        {
            createSkillRect.localPosition = localPointerPosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 핫바에만 착지가능. 핫바가 아니라면 destroy
        GameObject dropSlotObject = null;

        Destroy(createSkillObject);
    }

}
