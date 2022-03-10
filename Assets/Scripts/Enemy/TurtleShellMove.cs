using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TurtleShellMove : MonoBehaviour
{

    public bool isMove;



    private NavMeshAgent agent;
    private Animator animator;
    private LivingEntity livingEntity;

    private TurtleShellDetect tDetect;
    private TurtleShellAttack tAttack;
    private GameObject target;



    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        
        animator = GetComponentInChildren<Animator>();
        livingEntity = GetComponent<EnemyLiving>();
        tDetect = GetComponentInChildren<TurtleShellDetect>();
        tAttack = GetComponentInChildren<TurtleShellAttack>();

        target = GameObject.FindGameObjectWithTag("Player");

    }

    // Start is called before the first frame update
    void Start()
    {
        agent.acceleration = 20;
        agent.speed = 2f;
        agent.Warp(transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        if (livingEntity.isDead)
            return;

        if (tDetect.isDetect && tAttack.isAttack == false)
        {
            FollowPlayer();

            SetMoveBlend();
        }
        else
        {
            isMove = false;
        }

    }

    void FollowPlayer()
    {
        if (target == null)
            return;
        agent.SetDestination(target.transform.position);
        isMove = true;
        var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
        if (dir != Vector3.zero)
            animator.transform.forward = dir;
    }


    void SetMoveBlend()
    {
        if (isMove && tAttack.isInAtkRange == false)
        {
            animator.SetFloat("MoveBlend", 1f, 0.1f, Time.deltaTime);
        }
        else
        {
            animator.SetFloat("MoveBlend", 0f, 0.1f, Time.deltaTime);
        }
    }


}
