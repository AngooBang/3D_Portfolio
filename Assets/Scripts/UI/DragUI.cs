using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragUI : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private Vector2 pointerOffset;                        
    private RectTransform canvasRectTransform;            
    private RectTransform panelRectTransform;

    public void OnDrag(PointerEventData eventData)
    {
        if (panelRectTransform == null)                                     //and no RectTransform from the inventory is there 
            return;                                                         //the function will break out

        Vector2 localPointerPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, Input.mousePosition, eventData.pressEventCamera, out localPointerPosition))
        {
            panelRectTransform.localPosition = localPointerPosition - pointerOffset;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
       panelRectTransform, eventData.position, eventData.pressEventCamera, out pointerOffset);
    }

    private void Awake()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas != null)
        {
            canvasRectTransform = canvas.transform as RectTransform;          //instantiated
            panelRectTransform = transform as RectTransform;           //instantiated
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
