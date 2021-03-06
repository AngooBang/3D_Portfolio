using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickMovement : MonoBehaviour
{

    public GameObject ClickParticleObject;
    public float WalkSpeed = 4f;
    public LayerMask WorldLayerMask;
    public GameManager gameManager;

    private PlayerInput playerInput;
    private Rigidbody rigid;
    private Camera camera;
    private Animator animator;
    private NavMeshAgent agent;
    [SerializeField]
    private bool isMove;
    private bool isClick = false;
    private Vector3 destination;


    private void Awake()
    {
        camera = Camera.main;
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        playerInput = GetComponent<PlayerInput>();
        rigid = GetComponent<Rigidbody>();

        agent.updateRotation = false;
        //agent.updatePosition = false;

    }
    // Start is called before the first frame update
    void Start()
    {
        agent.acceleration = 20;

        agent.speed = WalkSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 worldDeltaPosition = agent.nextPosition - transform.position;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Dodge") == false &&
            animator.GetCurrentAnimatorStateInfo(0).IsName("WeaponComboAttack.NormalAttack01") == false &&
            animator.GetCurrentAnimatorStateInfo(0).IsName("WeaponComboAttack.NormalAttack02") == false &&
            animator.GetCurrentAnimatorStateInfo(0).IsName("WeaponComboAttack.NormalAttack03") == false &&
            animator.GetCurrentAnimatorStateInfo(0).IsName("CrashSkill") == false &&
            animator.GetCurrentAnimatorStateInfo(0).IsName("BuffSkill") == false &&
            gameManager.isAction == false)
        {
            if (playerInput.move)
            {
                agent.ResetPath();

                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100f, WorldLayerMask))
                {
                    //Debug.DrawRay(hit.point, Vector3.down, Color.red);
                    SetDestination(hit.point);


                    if (isClick == false)
                        Instantiate(ClickParticleObject, agent.destination, Quaternion.identity);
                }
                isClick = true;
            }
            if (Input.GetMouseButtonUp(1))
            {
                isClick = false;
            }
            LookMoveDirection();

            if (isMove)
            {
                animator.SetFloat("MoveBlend", 1f, 0.1f, Time.deltaTime);
            }
            else
            {
                animator.SetFloat("MoveBlend", 0f, 0.1f, Time.deltaTime);
            }
        }

    }
    

    private void SetDestination(Vector3 dest)
    {
        agent.ResetPath();
        if(agent.SetDestination(dest))
        {
            destination = dest;
            isMove = true;
        }
        //animator.SetFloat("MoveBlend", 1f);
    }

    private void LookMoveDirection()
    {
        if(isMove)
        {
            Vector3 dist = transform.position - agent.destination;
            //Debug.Log($"{agent.velocity.magnitude}");
            //Debug.Log("???? ???? : " + dist);
            //if (agent.velocity.magnitude == 0f)
            if (dist.magnitude == 0f)
            {
                isMove = false;
                rigid.velocity = Vector3.zero;
                //animator.SetFloat("MoveBlend", 0f);
                return;
            }
            var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
            if(dir != Vector3.zero)
            {
                //agent.enabled = false;
                animator.transform.forward = dir;
                //agent.enabled = true;
            }
            //transform.position += dir.normalized * Time.deltaTime * WalkSpeed;
        }
    }

}
