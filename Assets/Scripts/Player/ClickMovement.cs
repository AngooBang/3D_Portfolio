using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickMovement : MonoBehaviour
{
    private Camera camera;
    private Animator animator;
    private NavMeshAgent agent;
    private bool isMove;
    private bool isClick = false;
    private Vector3 destination;

    public GameObject clickParticleObject;
    public float WalkSpeed = 4f;

    private void Awake()
    {
        camera = Camera.main;
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
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
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Dodge") == false &&
            animator.GetCurrentAnimatorStateInfo(0).IsName("NormalAttack") == false)
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    SetDestination(hit.point);
                    if(isClick == false)
                        Instantiate(clickParticleObject, hit.point, Quaternion.identity);
                }
                isClick = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                isClick = false;
            }
            LookMoveDirection();
        }
    }


    private void SetDestination(Vector3 dest)
    {
        agent.SetDestination(dest);
        destination = dest;
        isMove = true;
        animator.SetBool("IsMove", true);
    }

    private void LookMoveDirection()
    {
        if(isMove)
        {
            if (agent.velocity.magnitude == 0f)
            {
                isMove = false;
                animator.SetBool("IsMove", false);
                return;
            }
            var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
            if(dir != Vector3.zero)
                animator.transform.forward = dir;
            //transform.position += dir.normalized * Time.deltaTime * WalkSpeed;
        }
    }
}
