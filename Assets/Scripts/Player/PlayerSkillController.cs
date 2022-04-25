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

    public GameObject s_buffEffect;


    public float s_crashDashSpeed;
    public bool isCrash;
    public bool isBuff;


    private PlayerStatus pStatus;
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
        pStatus = GetComponent<PlayerStatus>();
        isCrash = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F9))
        {
            UseSkill(1);
        }
        if (Input.GetKeyDown(KeyCode.F10))
        {
            UseSkill(2);
        }
    }

    public void UseSkill(int skillID)
    {
        if(skillID == 1 && isCrash == false)
        {
            if(pStatus.CurrentSP >= 30)
            {
                pStatus.CurrentSP -= 30;
                if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit, 100f, WorldLayerMask))
                {
                    transform.LookAt(hit.point);

                    forceVec = hit.point - transform.position;
                }
                animator.SetTrigger("CrashSkill");
            }
        }
        if (skillID == 2 && isBuff == false)
        {
            if (pStatus.CurrentSP >= 30)
            {
                pStatus.CurrentSP -= 30;
                if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit, 100f, WorldLayerMask))
                {
                    transform.LookAt(hit.point);

                    //forceVec = hit.point - transform.position;
                }
                Instantiate(s_buffEffect, transform);
                animator.SetTrigger("BuffSkill");
            }
        }
    }

    public void CrashSkillEvent(string s)
    {

        if(s == "Dash")
        {
            isCrash = true;
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

        if (s == "End")
        {
            isCrash = false;
        }
    }

    public void BuffSkillEvent(string s)
    {
        if (s == "Start")
        {
            isBuff = true;
            StartCoroutine(BuffDamage(10f));
        }
        if (s == "End")
        {
            isBuff = false;
        }
    }


    IEnumerator CrashDown(float colEnableTime)
    {
        s_crashCol.enabled = true;

        yield return new WaitForSeconds(colEnableTime);
        s_crashCol.enabled = false;

    }

    IEnumerator BuffDamage(float buffDurationTime)
    {
        pStatus.Damage *= 2;
        yield return new WaitForSeconds(buffDurationTime);
        pStatus.Damage /= 2;
    }
}
