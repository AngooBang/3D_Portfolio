using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttackCol : MonoBehaviour
{
    private Boss_BasicAttack basicAttack;
    // Start is called before the first frame update
    void Start()
    {
        basicAttack = GetComponentInParent<Boss_BasicAttack>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStatus pStatus = other.GetComponent<PlayerStatus>();
            pStatus.GetDamage(basicAttack.Damage);

            StartCoroutine(pStatus.OnDamage());
        }
    }
}
