using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLiving : LivingEntity
{
    public GameObject HudDamageText;
    public ItemDropManager dropManager;

    public Canvas HUDCanvas;

    private Animator animator;
    private Material material;
    private EnemyHPBar enemyHPBar;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        enemyHPBar = gameObject.GetComponent<EnemyHPBar>();
        animator = GetComponentInChildren<Animator>();
        material = GetComponentInChildren<SkinnedMeshRenderer>().material;
        HUDCanvas = GameObject.FindGameObjectWithTag("HUDCanvas").GetComponent<Canvas>();

        dropManager = GameObject.FindGameObjectWithTag("DropManager").GetComponent<ItemDropManager>();
    }


    public override void GetDamage(int damage)
    {
        base.GetDamage(damage);
        if(isDead == false)
        {
            animator.SetTrigger("GetHit");
        }

        GameObject hudText = Instantiate(HudDamageText, HUDCanvas.transform);
        hudText.GetComponent<HUDObject>().target = transform;
        //hudText.transform.position = HudPos.position;
        hudText.GetComponentInChildren<DamageText>().damage = damage;

        enemyHPBar.SetHPBarValue();
    }

    public override void OnDead()
    {
        base.OnDead();

        gameObject.layer = 14;
        dropManager.MonsterDropItem(101, transform);


    }

    public IEnumerator OnDamage(Vector3 reactVec)
    {
        material.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        // 뒤로 밀려나게.. navmesh때문인지 동작x
        //agent.enabled = false;
        //reactVec = reactVec.normalized;
        //reactVec += Vector3.up;
        //rigid.AddForce(reactVec * 5, ForceMode.Impulse);
        //agent.enabled = true;

        material.color = Color.white;
    }
}
