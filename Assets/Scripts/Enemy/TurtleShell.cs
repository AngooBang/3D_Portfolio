using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TurtleShell : MonoBehaviour
{
    public GameObject Target;

    private bool isMove;
    private bool isAttack;

    private float atkDelay = 2f;
    private float atkElapsed = 0f;

    private NavMeshAgent enemyAgent;
    private Animator animator;
    private LivingEntity livingEntity;

    private TurtleShellDetect turtleShellDetect;

    private Rigidbody rigid;
    private Material material;


    private void Awake()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyAgent.updateRotation = false;
        
        animator = GetComponent<Animator>();
        livingEntity = GetComponent<LivingEntity>();
        turtleShellDetect = GetComponentInParent<TurtleShellDetect>();

        rigid = GetComponent<Rigidbody>();
        material = GetComponentInChildren<SkinnedMeshRenderer>().material;

        Target = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyAgent.acceleration = 20;
        enemyAgent.speed = 2f;
        enemyAgent.Warp(transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        if (livingEntity.isDead)
            return;

        if (turtleShellDetect.isDetect)
        {
            FollowPlayer();
            CheckTargetDist();

            SetMoveBlend();
        }

    }

    void FollowPlayer()
    {
        if (Target == null)
            return;
        enemyAgent.SetDestination(Target.transform.position);
        isMove = true;
        var dir = new Vector3(enemyAgent.steeringTarget.x, transform.position.y, enemyAgent.steeringTarget.z) - transform.position;
        if (dir != Vector3.zero)
            animator.transform.forward = dir;
    }

    void CheckTargetDist()
    {
        Vector3 dist = transform.position - Target.transform.position;

        if(dist.magnitude <= 1.5f)
        {
            isMove = false;
            enemyAgent.ResetPath();

            atkElapsed += Time.deltaTime;
            if(atkElapsed > atkDelay)
            {
                isAttack = true;
                animator.SetTrigger("IsAttack");
                atkElapsed = 0f;
            }
        }
    }

    void SetMoveBlend()
    {
        if (isMove)
        {
            animator.SetFloat("MoveBlend", 1f, 0.1f, Time.deltaTime);
        }
        else
        {
            animator.SetFloat("MoveBlend", 0f, 0.1f, Time.deltaTime);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (livingEntity.isDead)
        {
            enemyAgent.enabled = false;
            return;
        }
        if (other.CompareTag("MeleeWeapon"))
        {            
            Debug.Log("거북이가 아파요!!!");
            Vector3 reactVec = transform.position - other.transform.position;
            livingEntity.GetDamage(other.GetComponent<MeleeWeapon>().damage);
            animator.SetTrigger("GetHit");
            StartCoroutine(OnDamage(reactVec));
        }
    }

    IEnumerator OnDamage(Vector3 reactVec)
    {
        material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        enemyAgent.enabled = false;
        reactVec = reactVec.normalized;
        reactVec += Vector3.up;
        rigid.AddForce(reactVec * 5, ForceMode.Impulse);

        enemyAgent.enabled = true;
        material.color = Color.white;
    }
}
