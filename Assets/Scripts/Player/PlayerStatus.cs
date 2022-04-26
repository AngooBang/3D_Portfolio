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

    public GameObject HudDamageText;
    public Canvas HUDCanvas;

    private Animator animator;
    private PlayerUIController uiController;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        CurrentSP = 0;

        animator = GetComponent<Animator>();
        uiController = GetComponent<PlayerUIController>();

        HUDCanvas = GameObject.FindGameObjectWithTag("HUDCanvas").GetComponent<Canvas>();

        uiController.SetHPBarValue();
        uiController.SetSPBarValue();
    }

    // Update is called once per frame
    void Update()
    {
        //SetEquipmentData();

        if(Input.GetKeyDown(KeyCode.F3))
        {
            CurrentHP += 30;
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            CurrentSP += 30;
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            Damage += 10;
        }
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

        GameObject hudText = Instantiate(HudDamageText, HUDCanvas.transform);
        hudText.GetComponent<HUDObject>().target = transform;
        hudText.GetComponentInChildren<DamageText>().damage = damage;


        uiController.SetHPBarValue();
    }

    public void HealthRecovery(int healValue)
    {
        // 체력회복 이펙트 생성
        // 체력회복 플로팅텍스트 생성
        // 체력회복.
        CurrentHP += healValue;
        if (CurrentHP > MaxHP)
        {
            CurrentHP = MaxHP;
        }
        uiController.SetHPBarValue();
    }

    public void SPRecovery(int recValue)
    {
        CurrentSP += recValue;
        if (CurrentSP > MaxSP)
        {
            CurrentSP = MaxSP;
        }
        uiController.SetSPBarValue();
    }

    public void SetEquipmentData()
    {
        ItemData weaponData = equipmentSystem.weaponSlotObject.GetComponentInChildren<ItemData>();

        if(weaponData != null)
        {
            Damage = weaponData.itemStats;
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
