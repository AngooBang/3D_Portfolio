using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    public GameObject HPprefab;
    public GameObject SPprefab;
    public GameObject InteractiveImg;

    public GameObject InventoryCanvas;
    public GameObject EquipmentCanvas;
    public GameObject SkillCanvas;

    public TooltipSystem tooltipSystem;


    public bool isInventoryEnable = false;
    public bool isEquipmentEnable = false;
    public bool isSkillEnable = false;

    private PlayerInput playerInput;
    private Slider hpSlider;
    private Slider spSlider;

    private PlayerStatus pStatus;
    // Start is called before the first frame update
    void Start()
    {
        pStatus = GetComponent<PlayerStatus>();
        playerInput = GetComponent<PlayerInput>();
        hpSlider = HPprefab.GetComponent<Slider>();
        spSlider = SPprefab.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInput.inventory)
        {
            InventoryCanvas.SetActive(isInventoryEnable = !isInventoryEnable);
            if(tooltipSystem.isInventoryTooltip)
            {
                if(isInventoryEnable == false)
                    tooltipSystem.isShowTooltip = isInventoryEnable;
            }
        }

        if(playerInput.equipment)
        {
            EquipmentCanvas.SetActive(isEquipmentEnable = !isEquipmentEnable);
            if (tooltipSystem.isInventoryTooltip)
            {
                if (isEquipmentEnable == false)
                    tooltipSystem.isShowTooltip = isEquipmentEnable;
            }
        }

        if (playerInput.skill)
        {
            SkillCanvas.SetActive(isSkillEnable = !isSkillEnable);
            //if (tooltipSystem.isInventoryTooltip)
            //{
            //    if (isSkillEnable == false)
            //        tooltipSystem.isShowTooltip = isSkillEnable;
            //}
        }
    }

    public void SetHPBarValue()
    {
        hpSlider.value = (float)pStatus.CurrentHP / pStatus.MaxHP;
    }

    public void SetSPBarValue()
    {
        spSlider.value = (float)pStatus.CurrentSP / pStatus.MaxSP;
    }

    public void ShowInteractiveImg()
    {
        InteractiveImg.SetActive(true);
    }

    public void HideInteractiveImg()
    {
        InteractiveImg.SetActive(false);
    }
}
