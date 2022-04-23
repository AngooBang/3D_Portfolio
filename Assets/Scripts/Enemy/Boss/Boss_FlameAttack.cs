using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_FlameAttack : MonoBehaviour
{
    public bool IsAttack = false;
    public int Damage;

    public GameObject AttackBox;
    public CapsuleCollider collider;

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
        AttackBox.SetActive(true);
        Invoke("PlayFlameAni", 1.5f);
        IsAttack = true;
    }

    void PlayFlameAni()
    {
        animator.SetTrigger("DoFlameAttack");

    }
    void FlameAttackEvent(string s)
    {
        if (s == "Start")
        {
        }

        if (s == "Attack")
        {
            AttackBox.SetActive(false);
            collider.enabled = true;
        }

        if (s == "End")
        {
            IsAttack = false;
            collider.enabled = false;
        }
    }
}
