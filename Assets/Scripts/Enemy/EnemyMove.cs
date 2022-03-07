using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public GameObject Target;

    private bool isMove;
    private bool isDetect = false;


    private NavMeshAgent enemyAgent;
    private Animator animator;

    private SphereCollider detectCol;

    private void Awake()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyAgent.updateRotation = false;
        
        animator = GetComponent<Animator>();

        detectCol = GetComponent<SphereCollider>();

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
        if(isMove)
        {
            animator.SetFloat("MoveBlend", 1f, 0.1f, Time.deltaTime);
        }
        else
        {
            animator.SetFloat("MoveBlend", 0f, 0.1f, Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(!isDetect)
                isDetect = true;
            else
                isDetect = false;
        }

        if (isDetect)
        {
            FollowPlayer();
        }
        else
        {
            Vector3 leftDest = transform.position - enemyAgent.destination;
            if(leftDest.magnitude <= 0f)
            {
                isMove = false;
            }
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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("감지하고있니?");
        //if(other.tag == "Player")
        //{
        //    Debug.Log("플레이어 태그로 감지됨.");
        //    enemyAgent.SetDestination(Target.transform.position);
        //    isMove = true;
        //}
        if(other.CompareTag("Player"))
        {
            Debug.Log("플레이어 콤페어 태그로 감지됨.");
            enemyAgent.SetDestination(Target.transform.position);
            isMove = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("감지 하고있는 중이니??");
    }
}
