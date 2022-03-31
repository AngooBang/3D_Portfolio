using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : LivingEntity
{
    public int MaxSP;
    public int CurrentSP;
    public int Damage;
    public int Shield;
    public EquipmentSystem equipmentSystem;

    private Animator animator;
    private PlayerUIController uiController;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        CurrentSP = 0;

        animator = GetComponent<Animator>();
        uiController = GetComponent<PlayerUIController>();

        uiController.SetHPBarValue();
        uiController.SetSPBarValue();
    }

    // Update is called once per frame
    void Update()
    {
        SetEquipmentData();
    }

    public void HitEnemy()
    {
        CurrentSP += 10;
        if(CurrentSP > MaxSP)
        {
            CurrentSP = MaxSP;
        }
        uiController.SetSPBarValue();
    }

    public override void GetDamage(int damage)
    {
        damage -= Shield;
        base.GetDamage(damage);
        animator.SetTrigger("GetHit");
        uiController.SetHPBarValue();
    }

    public void SetEquipmentData()
    {
        ItemData weaponData = equipmentSystem.weaponSlotObject.GetComponentInChildren<ItemData>();

        if(weaponData != null)
        {
            Damage = weaponData.itemStats;
        }
        else
        {
            Damage = 0;
        }

        int totShield = 0;

        ItemData helmetData = equipmentSystem.helmetSlotObject.GetComponentInChildren<ItemData>();
        if(helmetData != null)
        {
            totShield += helmetData.itemStats;
        }
        ItemData bodyData = equipmentSystem.bodySlotObject.GetComponentInChildren<ItemData>();
        if (bodyData != null)
        {
            totShield += bodyData.itemStats;
        }
        ItemData shoesData = equipmentSystem.shoesSlotObject.GetComponentInChildren<ItemData>();
        if (shoesData != null)
        {
            totShield += shoesData.itemStats;
        }

        Shield = totShield;
    }
}
