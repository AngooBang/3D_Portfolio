using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TurtleShellDetect : MonoBehaviour
{
    [SerializeField]
    public bool isDetect = false;

    private Animator animator;
    private NavMeshAgent agent;
    private EnemyLiving enemyLiving;
    // Start is called before the first frame update
    void Start()
    {
        animator = transform.parent.GetComponentInChildren<Animator>();
        agent = GetComponentInParent<NavMeshAgent>();
        enemyLiving = GetComponentInParent<EnemyLiving>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("IsDetect", true);
            isDetect = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (enemyLiving.isDead)
            return;
        if (other.CompareTag("Player"))
        {
            animator.SetBool("IsDetect", false);
            agent.ResetPath();
            isDetect = false;
        }
    }
}
