using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleShell : MonoBehaviour
{
    private Animator animator;
    private EnemyLiving enemyLiving;

    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyLiving = GetComponentInParent<EnemyLiving>();

        material = GetComponentInChildren<SkinnedMeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enemyLiving.isDead)
        {
            return;
        }
        if (other.CompareTag("MeleeWeapon"))
        {
            Debug.Log("거북이가 아파요!!!");
            Vector3 reactVec = transform.position - other.transform.position;
            enemyLiving.GetDamage(other.GetComponent<MeleeWeapon>().damage);

            if (enemyLiving.isDead == false)
            {
                animator.SetTrigger("GetHit");
            }
            StartCoroutine(OnDamage(reactVec));
        }
    }

    IEnumerator OnDamage(Vector3 reactVec)
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
