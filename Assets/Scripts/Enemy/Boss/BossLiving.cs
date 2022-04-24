using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLiving : LivingEntity
{
    public GameObject HudDamageText;
    public Canvas HUDCanvas;


    protected override void Start()
    {
        base.Start();
        HUDCanvas = GameObject.FindGameObjectWithTag("HUDCanvas").GetComponent<Canvas>();

    }

    protected override void Update()
    {
        base.Update();

    }
    public override void GetDamage(int damage)
    {
        base.GetDamage(damage);
        //if (isDead == false)
        //{
        //    animator.SetTrigger("GetHit");
        //}

        GameObject hudText = Instantiate(HudDamageText, HUDCanvas.transform);
        hudText.GetComponent<HUDObject>().target = transform;
        hudText.GetComponentInChildren<DamageText>().damage = damage;

        //enemyHPBar.SetHPBarValue();
    }
    public override void OnDead()
    {
        base.OnDead();

        // 시체 레이어 변경
        gameObject.layer = LayerMask.NameToLayer("EnemyDead");
        foreach (Transform child in transform)
        {
            child.gameObject.layer = LayerMask.NameToLayer("EnemyDead");
        }
        //dropManager.MonsterDropItem(101, transform);


    }
}
