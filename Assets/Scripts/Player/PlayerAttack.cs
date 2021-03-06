using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAttack : MonoBehaviour
{
    public MeleeWeapon EquipWeapon;
    public LayerMask WorldLayerMask;
    public bool IsAttack;
    public float colldownTime = 2f;
    public static int noOfClicks = 0;

    private Rigidbody rigid;
    private PlayerInput playerInput;
    private Animator playerAnimator;
    private NavMeshAgent agent;
    private Camera camera;
    private float nextFireTime = 0f;
    float lastClickedTime = 0;
    float maxComboDelay = 1f;



    

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
        camera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        if(playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f &&
            playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("WeaponComboAttack.NormalAttack01"))
        {
            playerAnimator.SetBool("SwordAtk1", false);
            noOfClicks = 0;
            IsAttack = false;
        }
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f &&
            playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("WeaponComboAttack.NormalAttack02"))
        {
            playerAnimator.SetBool("SwordAtk2", false);
            noOfClicks = 0;
            IsAttack = false;
        }
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6f &&
             playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("WeaponComboAttack.NormalAttack03"))
        {
            playerAnimator.SetBool("SwordAtk3", false);
            noOfClicks = 0;
            IsAttack = false;
        }
        if(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
        {
            noOfClicks = 0;
            playerAnimator.SetBool("SwordAtk1", false);
            playerAnimator.SetBool("SwordAtk2", false);
            playerAnimator.SetBool("SwordAtk3", false);
            IsAttack = false;
        }

        if(Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
            playerAnimator.SetBool("SwordAtk1", false);
            playerAnimator.SetBool("SwordAtk2", false);
            playerAnimator.SetBool("SwordAtk3", false);
            IsAttack = false;
        }
        if(Time.time > nextFireTime)
        {
            if(playerInput.normalAttack && !playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("WeaponComboAttack.NormalAttack03") &&
                !playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
            {
                OnClick();
            }
        }

    }


    void OnClick()
    {
        lastClickedTime = Time.time;
        noOfClicks++;
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
        //if (noOfClicks == 1 && !playerAnimator.GetBool("SwordAtk2") && !playerAnimator.GetBool("SwordAtk3"))
        if (noOfClicks >= 1 && playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Movement"))
        {
            if(!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("WeaponComboAttack.NormalAttack03"))
            {
                LookMousePosition();
            }
            playerAnimator.SetBool("SwordAtk1", true);
            //rigid.velocity = Vector3.zero;
            EquipWeapon.Use(1);
            nextFireTime = Time.time;
            IsAttack = true;
            return;
        }

        if (noOfClicks >= 2 && playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6f &&
            playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("WeaponComboAttack.NormalAttack01") && !playerAnimator.GetBool("SwordAtk3"))
        {
            LookMousePosition();
            playerAnimator.SetBool("SwordAtk1", false);
            playerAnimator.SetBool("SwordAtk2", true);
            //rigid.velocity = (transform.forward - transform.position).normalized * 10f;
            EquipWeapon.Use(2);
            nextFireTime = Time.time;
            IsAttack = true;
            return;
        }
        if (noOfClicks >= 3 && playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6f &&
             playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("WeaponComboAttack.NormalAttack02") && !playerAnimator.GetBool("SwordAtk1"))
        {
            LookMousePosition();
            playerAnimator.SetBool("SwordAtk2", false);
            playerAnimator.SetBool("SwordAtk3", true);
            //rigid.velocity = Vector3.zero;
            EquipWeapon.Use(3);
            nextFireTime = Time.time;
            IsAttack = true;
            return;
        }
    }

    void LookMousePosition()
    {
        RaycastHit hit;
        Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit, 100f, WorldLayerMask);

        agent.ResetPath();

        var dir = new Vector3(hit.point.x, playerAnimator.transform.position.y, hit.point.z) - playerAnimator.transform.position;
        if (dir != Vector3.zero)
        {
            playerAnimator.transform.forward = dir;
        }
    }
}
