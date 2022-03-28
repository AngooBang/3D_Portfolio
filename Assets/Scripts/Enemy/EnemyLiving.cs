using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLiving : LivingEntity
{
    public GameObject HudDamageText;
    public Transform HudPos;

    private EnemyHPBar enemyHPBar;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        enemyHPBar = gameObject.GetComponent<EnemyHPBar>();
    }


    public override void GetDamage(int damage)
    {
        base.GetDamage(damage);
        GameObject hudText = Instantiate(HudDamageText);
        hudText.transform.position = HudPos.position;
        hudText.GetComponent<DamageText>().damage = damage;
        enemyHPBar.SetHPBarValue();
    }
}
