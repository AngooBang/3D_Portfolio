using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSibling : MonoBehaviour
{
    RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.SetAsLastSibling();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
