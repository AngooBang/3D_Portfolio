using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_BasicAttack : MonoBehaviour
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
        AttackBox.SetActive(true);
        Invoke("PlayBasicAni", 0.7f);
        IsAttack = true;
    }
    void PlayBasicAni()
    {
        animator.SetTrigger("DoBasicAttack");

    }
    void BasicAttackEvent(string s)
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
