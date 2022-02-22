using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAttack : MonoBehaviour
{
    public Weapon EquipWeapon;

    private PlayerInput playerInput;
    private Animator playerAnimator;

    private float fireDelay;
    private bool isFireReady;
    

    

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (EquipWeapon == null)
            return;
        fireDelay += Time.deltaTime;
        isFireReady = EquipWeapon.rate < fireDelay;

        if (playerInput.normalAttack && isFireReady )
        {
            NormalAttack();
        }
    }
    private void NormalAttack()
    {
        playerAnimator.SetTrigger("DoNormalAttack");
        EquipWeapon.Use();
        fireDelay = 0f;
    }
}
