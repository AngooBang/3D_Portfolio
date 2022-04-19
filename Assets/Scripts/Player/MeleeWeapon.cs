using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public GameObject hitEffect;
    public enum WeaponType { Sword, GreatSword };
    public WeaponType type;
    public int damage;
    public float attackDelay;
    public BoxCollider meleeArea;
    public TrailRenderer trailEffect;

    private float attackDelayElapsed = 0f;
    private PlayerStatus pStatus;

    private void Start()
    {
        pStatus = GetComponentInParent<PlayerStatus>();
        //damage = pStatus.Damage;
    }

    private void Update()
    {
        attackDelayElapsed += Time.deltaTime;
        damage = pStatus.Damage;
    }
    public void Use(int atkCount)
    {
        if(attackDelayElapsed >= attackDelay)
        {
            if (type == WeaponType.Sword)
            {
                if (atkCount == 1)
                {
                    StopCoroutine(Swing(0.1f, 0f, 0.15f, 0.0f));
                    StartCoroutine(Swing(0.1f, 0f, 0.15f, 0.0f));
                }
                
                if (atkCount == 2)
                {
                    StopCoroutine(Swing(0.15f, 0f, 0.15f, 0.0f));
                    StartCoroutine(Swing(0.15f, 0f, 0.15f, 0.0f));
                }

                if (atkCount == 3)
                {
                    StopCoroutine(Swing(0.4f, 0.0f, 0.2f, 0.0f));
                    StartCoroutine(Swing(0.4f, 0.0f, 0.2f, 0.0f));
                }
            }
            attackDelayElapsed = 0f;
        }
    }

    IEnumerator Swing(float effectEnableTime, float colEnableTime, float colDisTime, float effectDisTime)
    {
        yield return new WaitForSeconds(effectEnableTime);
        trailEffect.enabled = true;

        yield return new WaitForSeconds(colEnableTime);
        meleeArea.enabled = true;

        yield return new WaitForSeconds(colDisTime);
        meleeArea.enabled = false;

        yield return new WaitForSeconds(effectDisTime);
        trailEffect.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {

            EnemyLiving enemyLiving = other.transform.GetComponent<EnemyLiving>();
            enemyLiving.GetDamage(damage);

            //Debug.Log("거북이가 아파요!!!");
            //Vector3 reactVec = transform.position - other.transform.position;

            Vector3 colPos = other.GetComponent<Transform>().position;


            GameObject curhit = Instantiate(hitEffect);
            curhit.transform.position = colPos;



            if (enemyLiving.isDead == false)
            {
                other.GetComponentInChildren<Animator>().SetTrigger("GetHit");
            }
            StartCoroutine(enemyLiving.OnDamage());


            pStatus.HitEnemy();
        }
    }
}
