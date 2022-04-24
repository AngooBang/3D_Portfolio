using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawAttackCol : MonoBehaviour
{
    private Boss_ClawAttack clawAttack;
    // Start is called before the first frame update
    void Start()
    {
        clawAttack = GetComponentInParent<Boss_ClawAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerStatus pStatus = other.GetComponent<PlayerStatus>();
            pStatus.GetDamage(clawAttack.Damage);

            StartCoroutine(pStatus.OnDamage());
        }
    }
}
