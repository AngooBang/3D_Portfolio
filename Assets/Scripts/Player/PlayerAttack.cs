using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAttack : MonoBehaviour
{

    private PlayerInput playerInput;
    private Animator playerAnimator;

    

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(playerInput.normalAttack)
        {
            NormalAttack();
        }
    }
    private void NormalAttack()
    {
        playerAnimator.SetTrigger("DoNormalAttack");
    }
}
