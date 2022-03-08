using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TuttleShell : MonoBehaviour
{
    public GameObject Target;

    private bool isMove;
    [SerializeField]
    private bool isDetect = false;
    private bool isAttack;

    private float atkDelay = 2f;
    private float atkElapsed = 0f;

    private NavMeshAgent enemyAgent;
    private Animator animator;
    private LivingEntity livingEntity;


    private Rigidbody rigid;
    private Material material;

    private SphereCollider detectCol;

    private void Awake()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyAgent.updateRotation = false;
        
        animator = GetComponent<Animator>();
        livingEntity = GetComponent<LivingEntity>();

        detectCol = GetComponent<SphereCollider>();

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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(!isDetect)
                isDetect = true;
            else
                isDetect = false;
        }

        if (isDetect)
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
        if (other.CompareTag("Player"))
        {
            isDetect = true;
            animator.SetBool("IsDetect", true);
        }
        if (other.CompareTag("MeleeWeapon"))
        {
            Debug.Log("거북이가 아파요!!!");
            Vector3 reactVec = transform.position - other.transform.position;
            animator.SetTrigger("GetHit");
            livingEntity.GetDamage(other.GetComponent<MeleeWeapon>().damage);
            StartCoroutine(OnDamage(reactVec));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isDetect = false;
            animator.SetBool("IsDetect", false);
            enemyAgent.ResetPath();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("거북이 콜리전 검사 됨?");

    }
    IEnumerator OnDamage(Vector3 reactVec)
    {
        material.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        reactVec = reactVec.normalized;
        reactVec += Vector3.up;
        rigid.AddForce(reactVec * 5, ForceMode.Impulse);

        material.color = Color.white;
    }
}
