using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private PlayerStatus pStatus;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        pStatus = GetComponent<PlayerStatus>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyAttack"))
        {
            pStatus.GetDamage(other.gameObject.GetComponent<TurtleShellAttack>().Damage);
            animator.SetTrigger("GetHit");
        }
    }
}
