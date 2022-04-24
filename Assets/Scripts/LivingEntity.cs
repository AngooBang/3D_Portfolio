using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LivingEntity : MonoBehaviour
{

    public int MaxHP;
    public int CurrentHP;

    public bool isDead = false;
    private Animator animator;

    private Material material;



    private NavMeshAgent agent;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        material = GetComponentInChildren<SkinnedMeshRenderer>().material;
        CurrentHP = MaxHP;
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    virtual public void OnDead()
    {
        isDead = true;
        animator.SetTrigger("IsDead");
        agent.ResetPath();
        agent.enabled = false;

        Destroy(gameObject, 5);
    }
    
    virtual public void GetDamage(int damage)
    {
        if (isDead)
            return;
        CurrentHP -= damage;
        if (CurrentHP <= 0)
        {
            CurrentHP = 0;
            OnDead();
        }
    }

    virtual public IEnumerator OnDamage()
    {
        material.color = Color.red;
        //�з����� ���׼�
        //rigid.AddForce(reactVec.normalized * speed, ForceMode.Impulse);
        yield return new WaitForSeconds(0.1f);

        // �ڷ� �з�����.. navmesh�������� ����x
        //agent.enabled = false;
        //reactVec = reactVec.normalized;
        //reactVec += Vector3.up;
        //rigid.AddForce(reactVec * 5, ForceMode.Impulse);
        //agent.enabled = true;

        material.color = Color.white;
    }


}
