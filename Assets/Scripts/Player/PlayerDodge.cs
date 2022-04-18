using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerDodge : MonoBehaviour
{
    public float DodgeCoolTime;
    public float DodgeSpeed;
    public LayerMask WorldLayerMask;
    public bool IsDodge;

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
        if(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Dodge"))
        {
            if(playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.75f)
            {
                IsDodge = false;
                playerRigid.velocity = Vector3.zero;
            }
            //else
            //{
            //    transform.position = playerAnimator.rootPosition;
            //    agent.SetDestination(playerAnimator.rootPosition);
            //}
        }
        dodgeElapsedTime += Time.deltaTime;
        if(dodgeElapsedTime > DodgeCoolTime)
        {
            if (playerInput.dodge)
            {
                Dodge();
            }
        }
    }

    void Dodge()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit, 100f, WorldLayerMask))
        {
            transform.LookAt(hit.point);

            Vector3 forceVec = hit.point - transform.position;
            Debug.Log(forceVec);

            //playerRigid.AddForce(forceVec.normalized * DodgeSpeed * Time.deltaTime, ForceMode.Impulse);
            agent.ResetPath();

            playerRigid.velocity = forceVec.normalized * DodgeSpeed;

        }
        dodgeElapsedTime = 0f;
        playerAnimator.SetTrigger("DoDodge");
        IsDodge = true;
    }


}
