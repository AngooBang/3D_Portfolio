using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss_BasicAttack : MonoBehaviour
{
    public bool IsAttack = false;
    public int Damage;

    public GameObject AttackBox;
    public BoxCollider collider;


    private Transform target;
    private NavMeshAgent agent;
    private Animator animator;
    private Rigidbody rigid;

    private bool IsAttackRangeIn = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        rigid = GetComponentInChildren<Rigidbody>();
        //agent.updateRotation = false;
    }


    // Update is called once per frame
    void Update()
    {
        if(IsAttack)
        {
            float dist = Vector3.Distance(target.position, transform.position);
            if(dist < 5f && IsAttackRangeIn == false)
            {
                animator.SetFloat("MoveBlend", 0f, 0.1f, Time.deltaTime);
                rigid.velocity = Vector3.zero;
                agent.ResetPath();
                //transform.LookAt(target.position);
                AttackBox.SetActive(true);
                Invoke("PlayBasicAni", 0.7f);
                IsAttackRangeIn = true;
            }
            else
            {
                animator.SetFloat("MoveBlend", 1f, 0.1f, Time.deltaTime);
                if (IsAttackRangeIn == false)
                    agent.destination = target.position;
            }
        }
    }
    public void PlayAttack()
    {
        agent.destination = target.position;
        IsAttack = true;
        IsAttackRangeIn = false;
    }
    void PlayBasicAni()
    {
        animator.SetTrigger("DoBasicAttack");

    }
    void BasicAttackEvent(string s)
    {
        if (s == "Start")
        {
        }

        if (s == "Attack")
        {
            AttackBox.SetActive(false);
            collider.enabled = true;
        }

        if (s == "End")
        {
            IsAttack = false;
            collider.enabled = false;
        }
    }
}
