using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss_DetectPlayer : MonoBehaviour
{
    public bool IsDetect;
    public bool IsScream;
    private Animator animator;
    private NavMeshAgent agent;
    private Transform target;
    private BossHPBarController HPcontroller;
    private BossLiving bossLiving;
    // Start is called before the first frame update
    void Start()
    {
        IsDetect = false;
        IsScream = false;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        HPcontroller = GetComponent<BossHPBarController>();
        agent = GetComponent<NavMeshAgent>();
        bossLiving = GetComponent<BossLiving>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bossLiving.isDead) return;
        float dist = Vector3.Distance(transform.position, target.position);

        //Debug.Log(dist + " 만큼의 거리.");
        if (dist < 18f)
        {
            if (IsDetect == false)
                IsScream = true;
            IsDetect = true;

            HPcontroller.HPBarObject.SetActive(true);
            animator.SetBool("IsDetect", true);
        }
        else
        {
            IsDetect = false;
            agent.ResetPath();

            HPcontroller.HPBarObject.SetActive(false);
            animator.SetBool("IsDetect", false);
        }
        if (IsScream == true)
        {
            agent.ResetPath();
        }

    }

    void ScreamEvent(string s)
    {
        if(s == "End")
        {
            IsScream = false;
        }
    }
}
