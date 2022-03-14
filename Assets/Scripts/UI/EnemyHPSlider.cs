using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPSlider : MonoBehaviour
{
    private Canvas canvas;
    private Camera hpCamera;
    private RectTransform rectParent;
    private RectTransform rectHP;

    public Vector3 offset = Vector3.zero;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        hpCamera = canvas.worldCamera;

        rectParent = canvas.GetComponent<RectTransform>();
        rectHP = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if(Camera.main != null)
        {

            var screenPosition = Camera.main.WorldToScreenPoint(target.position + offset);
            if (screenPosition.z < 0.0f)
            {
                screenPosition *= -1.0f;
            }

            Vector2 localPos = Vector2.zero;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectParent, screenPosition, hpCamera, out localPos);


            rectHP.localPosition = localPos;
        }

    }
}
