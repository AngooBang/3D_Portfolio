using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerSkillController : MonoBehaviour
{
    public LayerMask WorldLayerMask;

    public GameObject s_crashEffect;
    public Transform s_crashEffectTransform;
    public float s_crashDashSpeed;


    private Vector3 forceVec;
    private Rigidbody playerRigid;
    private Animator animator;
    private NavMeshAgent agent;
    private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        playerRigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F5))
        {
            UseSkill(1);
        }
    }

    public void UseSkill(int skillID)
    {
        if(skillID == 1)
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit, 100f, WorldLayerMask))
            {
                transform.LookAt(hit.point);

                forceVec = hit.point - transform.position;

                //playerRigid.AddForce(forceVec.normalized * DodgeSpeed * Time.deltaTime, ForceMode.Impulse);


            }
            animator.SetTrigger("CrashSkill");
            //transform.Translate(transform.forward * 10f);
        }
    }

    public void CrashSkillEvent(string s)
    {

        if(s == "Dash")
        {
            agent.ResetPath();
            playerRigid.velocity = forceVec.normalized * s_crashDashSpeed;
        }

        if (s == "Crash")
        {
            playerRigid.velocity = Vector3.zero;
            agent.ResetPath();
            agent.isStopped = true;
            agent.velocity = Vector3.zero;


            Instantiate(s_crashEffect, s_crashEffectTransform.position, Quaternion.identity);
            Debug.Log("¶¥¿¡ ÂïÀ½!");

            //ÀÌÆåÆ® »ý¼º ¹× ÄÝ¶óÀÌ´õ on
        }
    }
    

}
