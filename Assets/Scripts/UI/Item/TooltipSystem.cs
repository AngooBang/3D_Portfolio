using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TooltipSystem : MonoBehaviour
{
    
    [SerializeField]
    public Image TooltipItemIcon;
    [SerializeField]
    public TextMeshProUGUI TooltipItemName;
    [SerializeField]
    public TextMeshProUGUI TooltipItemDescription;

    public GameObject tooltipObject;
    //public InventorySystem inventorySystem;



    public bool isShowTooltip = false;

    public bool isInventoryTooltip = false;
    public bool isHotbarTooltip = false;
    public bool isSkillTooltip = false;
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI[] textMeshProUGUIs = GetComponentsInChildren<TextMeshProUGUI>();
        TooltipItemName = textMeshProUGUIs[0];
        TooltipItemDescription = textMeshProUGUIs[1];
    }

    // Update is called once per frame
    void Update()
    {
        tooltipObject.SetActive(isShowTooltip);
        //if(inventorySystem.gameObject.active == false)
        //{
        //    tooltipObject.SetActive(false);
        //    isShowTooltip = false;
        //}
    }
}
