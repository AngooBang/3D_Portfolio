using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss_FlameAttack : MonoBehaviour
{
    public bool IsAttack = false;
    public int Damage;

    public GameObject AttackBox;
    public CapsuleCollider collider;

    public Transform BressSpot;
    public GameObject BressEffect;

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
            if (dist < 12f && angle < 15f && IsAttackRangeIn == false)
            {
                rigid.velocity = Vector3.zero;
                agent.ResetPath();
                AttackBox.SetActive(true);
                Invoke("PlayFlameAni", 1.5f);
                IsAttackRangeIn = true;
            }
            else
            {
                if (IsAttackRangeIn == false)
                    agent.destination = target.position;
            }

            if (dist < 15f)
            {
                animator.SetFloat("MoveBlend", 0f, 0.1f, Time.deltaTime);
            }
            else
            {
                animator.SetFloat("MoveBlend", 1f, 0.1f, Time.deltaTime);
            }
        }
    }
    public void PlayAttack()
    {
        agent.destination = target.position;
        IsAttack = true;
        IsAttackRangeIn = false;
    }

    void PlayFlameAni()
    {
        animator.SetTrigger("DoFlameAttack");

    }
    void FlameAttackEvent(string s)
    {
        if (s == "Start")
        {
        }

        if (s == "Attack")
        {
            AttackBox.SetActive(false);
            collider.enabled = true;
            Instantiate(BressEffect, BressSpot);
        }

        if (s == "End")
        {
            IsAttack = false;
            collider.enabled = false;
        }
    }
}
