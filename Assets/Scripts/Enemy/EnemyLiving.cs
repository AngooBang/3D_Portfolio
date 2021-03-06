using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLiving : LivingEntity
{
    public GameObject HudDamageText;
    public Canvas HUDCanvas;

    public ItemDropManager dropManager;



    private Animator animator;
    private EnemyHPBar enemyHPBar;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        enemyHPBar = gameObject.GetComponent<EnemyHPBar>();
        animator = GetComponentInChildren<Animator>();
        HUDCanvas = GameObject.FindGameObjectWithTag("HUDCanvas").GetComponent<Canvas>();

        dropManager = GameObject.FindGameObjectWithTag("DropManager").GetComponent<ItemDropManager>();
    }

    protected override void Update()
    {
        base.Update();

    }


    public override void GetDamage(int damage)
    {
        base.GetDamage(damage);
        if (isDead == false)
        {
            animator.SetTrigger("GetHit");
        }

        GameObject hudText = Instantiate(HudDamageText, HUDCanvas.transform);
        hudText.GetComponent<HUDObject>().target = transform;
        hudText.GetComponentInChildren<DamageText>().damage = damage;

        enemyHPBar.SetHPBarValue();
    }

    public override void OnDead()
    {
        base.OnDead();

        gameObject.layer = LayerMask.NameToLayer("EnemyDead");
        foreach (Transform child in transform)
        {
            child.gameObject.layer = LayerMask.NameToLayer("EnemyDead");
        }
        dropManager.MonsterDropItem(101, transform);


    }

}
