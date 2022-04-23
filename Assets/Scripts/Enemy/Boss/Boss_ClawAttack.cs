using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_ClawAttack : MonoBehaviour
{
    public bool IsAttack = false;
    public int Damage;

    public GameObject AttackBox;
    public BoxCollider collider;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAttack()
    {
        animator.SetTrigger("DoClawAttack");
        IsAttack = true;
    }

    void ClawAttackEvent(string s)
    {
        if(s == "Start")
        {
            AttackBox.SetActive(true);
        }

        if(s == "Attack")
        {
            AttackBox.SetActive(false);
            collider.enabled = true;
        }

        if(s == "End")
        {
            IsAttack = false;
            collider.enabled = false;
        }
    }
}
