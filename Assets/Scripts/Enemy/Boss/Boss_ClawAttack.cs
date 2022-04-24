using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss_ClawAttack : MonoBehaviour
{
    public bool IsAttack = false;
    public int Damage;

    public GameObject AttackBox;
    public BoxCollider collider;

    private Transform target;

    private Animator animator;
    private Rigidbody rigid;
    private NavMeshAgent agent;
    private bool IsAttackRangeIn = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        rigid = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAttack)
        {
            float dist = Vector3.Distance(target.position, transform.position);
            
            Vector3 forward = transform.forward;
            Vector3 toTarget = target.position - transform.position;

            float dot = Vector3.Dot(forward, toTarget);
            float angle = Mathf.Acos(dot / toTarget.magnitude);
            angle = angle * Mathf.Rad2Deg;
            //Debug.Log(angle + " : ªÁ¿’∞¢");

            if (dist < 12f && angle < 10f && IsAttackRangeIn == false)
            {
                rigid.velocity = Vector3.zero;
                agent.ResetPath();
                //transform.LookAt(target.position);
                AttackBox.SetActive(true);
                PlayClawAni();
                IsAttackRangeIn = true;
            }
            else
            {
                if (IsAttackRangeIn == false)
                    agent.destination = target.position;
            }

            if (dist < 12f)
            {
                animator.SetFloat("MoveBlend", 0f, 0.1f, Time.deltaTime);
            }
            else
            {
                animator.SetFloat("MoveBlend", 1f, 0.1f, Time.deltaTime);
            }
        }
    }

    void PlayClawAni()
    {
        animator.SetTrigger("DoClawAttack");

    }
    public void PlayAttack()
    {
        agent.destination = target.position;
        IsAttack = true;
        IsAttackRangeIn = false;
    }

    void ClawAttackEvent(string s)
    {
        if(s == "Start")
        {
            AttackBox.SetActive(true);
        }

        if(s == "Attack")
        {
            AttackBox.SetActive(false);
            collider.enabled = true;
        }

        if(s == "AttackEnd")
        {
            collider.enabled = false;
        }
        if(s == "End")
        {
            IsAttack = false;
        }
    }
}
