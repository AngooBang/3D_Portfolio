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



    private NavMeshAgent agent;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        CurrentHP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    virtual public void GetDamage(int damage)
    {
        if (isDead)
            return;
        CurrentHP -= damage;
        if (CurrentHP <= 0)
        {
            isDead = true;
            animator.SetTrigger("IsDead");
            agent.ResetPath();
            agent.enabled = false;
            gameObject.layer = 14;

            Destroy(gameObject, 5);
        }
    }


}
