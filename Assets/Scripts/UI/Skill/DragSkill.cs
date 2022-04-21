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
        // �巡�� ���۽� draggingskill �� skillPrefab�� ���������ش�.
        createSkillObject = Instantiate(SkillPrefab, draggingSkillRect);
        createSkillObject.GetComponent<SkillData>().SetSkillData(GetComponent<SkillData>());
        createSkillRect = createSkillObject.GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // ������ �������� RectTransform�� ���콺 ��ġ�� �˸°� ����.
        createSkillRect.SetAsLastSibling();

        Vector2 localPointerPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(draggingSkillRect, Input.mousePosition, eventData.pressEventCamera, out localPointerPosition))
        {
            createSkillRect.localPosition = localPointerPosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // �ֹٿ��� ��������. �ֹٰ� �ƴ϶�� destroy
        GameObject dropSlotObject = null;

        Destroy(createSkillObject);
    }

}
