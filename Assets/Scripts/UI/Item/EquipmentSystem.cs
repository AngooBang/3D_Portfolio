using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSystem : MonoBehaviour
{
    public GameObject helmetSlotObject;
    public GameObject bodySlotObject;
    public GameObject shoesSlotObject;
    public GameObject weaponSlotObject;

    public PlayerStatus pStatus;

    public Text hpText;
    public Text spText;
    public Text damageText;
    public Text shieldText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = $"HP : {pStatus.CurrentHP} / {pStatus.MaxHP}";
        spText.text = $"SP : {pStatus.CurrentSP} / {pStatus.MaxSP}";
        damageText.text = $"공격력 : {pStatus.Damage}";
        shieldText.text = $"방어력 : {pStatus.Shield}";
    }

    public bool GetIsFullEquiped()
    {
        if(helmetSlotObject.GetComponentInChildren<ItemData>() != null &&
            bodySlotObject.GetComponentInChildren<ItemData>() != null &&
            shoesSlotObject.GetComponentInChildren<ItemData>() != null &&
            weaponSlotObject.GetComponentInChildren<ItemData>() != null)
        {
            return true;
        }
        return false;
    }

}
