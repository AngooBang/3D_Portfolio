using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashSkill : MonoBehaviour
{
    public Transform weaponTrans;
    public PlayerStatus pStatus;
    public int damage;
    public float skillDamageMultiplier;

    public GameObject hitEffect;
    

    // Start is called before the first frame update
    void Start()
    { 
        damage = (int)(pStatus.Damage * skillDamageMultiplier);
    }

    // Update is called once per frame
    void Update()
    {
        damage = (int)(pStatus.Damage * skillDamageMultiplier);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {

            EnemyLiving enemyLiving = other.transform.GetComponent<EnemyLiving>();
            enemyLiving.GetDamage(damage);

            //Debug.Log("거북이가 아파요!!!");
            //Vector3 reactVec = weaponTrans.position - other.transform.position;
            //enemyLiving.GetDamage(other.GetComponent<MeleeWeapon>().damage);

            Vector3 colPos = other.GetComponent<Transform>().position;
            //other.GetComponent<Rigidbody>().velocity = reactVec * 0.5f;


            GameObject curhit = Instantiate(hitEffect);
            curhit.transform.position = colPos;



            if (enemyLiving.isDead == false)
            {
                other.GetComponentInChildren<Animator>().SetTrigger("GetHit");
            }
            StartCoroutine(enemyLiving.OnDamage());


            //pStatus.HitEnemy();
        }
        if (other.CompareTag("BossEnemy"))
        {
            LivingEntity bossLiving = other.GetComponentInParent<LivingEntity>();
            bossLiving.GetDamage(damage);

            GameObject curhit = Instantiate(hitEffect);
            curhit.transform.position = other.bounds.ClosestPoint(transform.position);


            StartCoroutine(bossLiving.OnDamage());
            //pStatus.HitEnemy();
        }
    }
}
