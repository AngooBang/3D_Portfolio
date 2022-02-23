using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAttack : MonoBehaviour
{
    public Weapon EquipWeapon;

    private PlayerInput playerInput;
    private Animator playerAnimator;

    //private float fireDelay;
    //private bool isFireReady;

    public float colldownTime = 2f;
    private float nextFireTime = 0f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 1;

    

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f &&
            playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("WeaponComboAttack.NormalAttack01"))
        {
            playerAnimator.SetBool("SwordAtk1", false);
        }
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f &&
            playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("WeaponComboAttack.NormalAttack02"))
        {
            playerAnimator.SetBool("SwordAtk2", false);
        }
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f &&
             playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("WeaponComboAttack.NormalAttack03"))
        {
            playerAnimator.SetBool("SwordAtk3", false);
        }

        if(Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }
        if(Time.time > nextFireTime)
        {
            if(playerInput.normalAttack)
            {
                OnClick();
            }
        }

    }


    void OnClick()
    {
        lastClickedTime = Time.time;
        noOfClicks++;
        if(noOfClicks == 1)
        {
            playerAnimator.SetBool("SwordAtk1", true);
            EquipWeapon.Use(1);
        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

        if(noOfClicks >= 2 && playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f &&
            playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("WeaponComboAttack.NormalAttack01"))
        {
            playerAnimator.SetBool("SwordAtk1", false);
            playerAnimator.SetBool("SwordAtk2", true);
            EquipWeapon.Use(2);
        }
        if (noOfClicks >= 3 && playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f &&
             playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("WeaponComboAttack.NormalAttack02"))
        {
            playerAnimator.SetBool("SwordAtk2", false);
            playerAnimator.SetBool("SwordAtk3", true);
            EquipWeapon.Use(3);
        }
    }
}
