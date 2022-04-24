using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TurtleShellAttack : MonoBehaviour
{
    [SerializeField]
    public bool isAttack;

    public bool isInAtkRange;
    public int Damage = 5;

    private NavMeshAgent agent;
    private TurtleShellDetect tDetect;
    private TurtleShellMove tMove;

    private EnemyLiving enemyLiving;
    private Animator animator;
    private BoxCollider boxCol;
    private GameObject target;

    private float atkDelay = 2f;
    private float atkElapsed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentInParent<NavMeshAgent>();
        tDetect = transform.parent.transform.parent.GetComponentInChildren<TurtleShellDetect>();
        tMove = GetComponentInParent<TurtleShellMove>();
        boxCol = GetComponent<BoxCollider>();
        enemyLiving = GetComponentInParent<EnemyLiving>();

        animator = transform.parent.GetComponent<Animator>();

        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyLiving.isDead)
            return;

        if(tDetect.isDetect)
        {
            CheckTargetDist();
        }

        if(isInAtkRange)
        {
            DoAttack();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStatus pStatus = other.GetComponent<PlayerStatus>();
            pStatus.GetDamage(Damage);

            StartCoroutine(pStatus.OnDamage());
        }
    }
    void CheckTargetDist()
    {
        Vector3 dist = transform.position - target.transform.position;

        if (dist.magnitude <= 1.8f)
        {
            agent.ResetPath();
            //agent.isStopped = true;
            agent.velocity = Vector3.zero;
            isInAtkRange = true;
        }
        else
        {
            isInAtkRange = false;
        }
    }

    void DoAttack()
    {
        agent.ResetPath();

        atkElapsed += Time.deltaTime;
        if (atkElapsed > atkDelay)
        {
            isAttack = true;

            animator.SetTrigger("IsAttack");
            StopCoroutine(Attack(0.1f, 0.2f));
            StartCoroutine(Attack(0.1f, 0.2f));

            atkElapsed = 0f;
        }
    }


    IEnumerator Attack(float colEnableTime, float colDisTime)
    {
        yield return new WaitForSeconds(colEnableTime);
        boxCol.enabled = true;

        yield return new WaitForSeconds(colDisTime);
        boxCol.enabled = false;
        isAttack = false;
    }
}
