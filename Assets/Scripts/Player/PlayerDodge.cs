using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerDodge : MonoBehaviour
{
    public float DodgeCoolTime;
    public LayerMask WorldLayerMask;

    private float dodgeElapsedTime;

    private Camera camera;
    private PlayerInput playerInput;
    private Rigidbody playerRigid;
    private Animator playerAnimator;
    private NavMeshAgent agent;


    private void Awake()
    {
        camera = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        playerRigid = GetComponent<Rigidbody>();

        dodgeElapsedTime = DodgeCoolTime;
    }

    // Update is called once per frame
    void Update()
    {
        dodgeElapsedTime += Time.deltaTime;
        if(dodgeElapsedTime > DodgeCoolTime)
        {
            if (playerInput.dodge)
            {
                if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Dodge") == false)
                {
                    Dodge();
                }
            }
        }
    }

    void Dodge()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit, 100f, WorldLayerMask))
        {
            transform.LookAt(hit.point);

            Vector3 forceVec = transform.position - hit.point;
            Debug.Log(forceVec);
            //playerRigid.MovePosition(forceVec);
            playerRigid.AddForce(forceVec.normalized * 20f, ForceMode.Impulse);

            //playerRigid.velocity = forceVec.normalized * 20f;
        }
        dodgeElapsedTime = 0f;
        playerAnimator.SetTrigger("DoDodge");
    }
    private void DodgeDestination(Vector3 dest)
    {

        //// 경로 입력
        //agent.SetDestination(dest);
        //// 마우스 방향 보기
        //var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
        //if (dir != Vector3.zero)
        //    transform.forward = dir;
        ////transform.LookAt(dir);
    }

}
