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

    [SerializeField]
    private bool isInventoryEnable = false;
    private bool isEquipmentEnable = false;

    private Slider hpSlider;
    private Slider spSlider;

    private PlayerStatus pStatus;
    // Start is called before the first frame update
    void Start()
    {
        pStatus = GetComponent<PlayerStatus>();

        hpSlider = HPprefab.GetComponent<Slider>();
        spSlider = SPprefab.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Inventory"))
        {
            InventoryCanvas.SetActive(isInventoryEnable = !isInventoryEnable);
        }

        if(Input.GetButtonDown("Equipment"))
        {
            EquipmentCanvas.SetActive(isEquipmentEnable = !isEquipmentEnable);
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
