using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerSkillController : MonoBehaviour
{
    public LayerMask WorldLayerMask;

    public GameObject s_crashEffect;
    public Transform s_crashEffectTransform;
    public BoxCollider s_crashCol;
    public float s_crashDashSpeed;



    private RaycastHit hit;
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
            transform.LookAt(hit.point);
            agent.ResetPath();
            playerRigid.velocity = forceVec.normalized * s_crashDashSpeed;
        }

        if (s == "Crash")
        {
            playerRigid.velocity = Vector3.zero;
            agent.ResetPath();
            agent.isStopped = true;
            agent.velocity = Vector3.zero;


            //����Ʈ ���� �� �ݶ��̴� on
            Instantiate(s_crashEffect, s_crashEffectTransform.position, Quaternion.identity);
            StartCoroutine(CrashDown(0.2f));

        }
    }


    IEnumerator CrashDown(float colEnableTime)
    {
        s_crashCol.enabled = true;

        yield return new WaitForSeconds(colEnableTime);
        s_crashCol.enabled = false;

    }
}