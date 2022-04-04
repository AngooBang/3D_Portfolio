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


    private void Start()
    {
        TooltipItemName = transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        TooltipItemDescription = transform.GetChild(0).transform.GetChild(2).GetComponent<TextMeshProUGUI>();
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
