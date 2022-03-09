using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LivingEntity : MonoBehaviour
{
    public Animator animator;


    public int HP;

    public bool isDead = false;


    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public void GetDamage(int damage)
    {
        if (isDead)
            return;
        HP -= damage;
        if (HP <= 0)
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
