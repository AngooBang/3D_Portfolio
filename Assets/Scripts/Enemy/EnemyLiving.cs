using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLiving : LivingEntity
{
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
        
        enemyHPBar.SetHPBarValue();
    }
}
