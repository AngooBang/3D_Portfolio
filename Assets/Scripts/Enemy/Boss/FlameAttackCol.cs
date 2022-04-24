using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameAttackCol : MonoBehaviour
{
    private Boss_FlameAttack flameAttack;
    // Start is called before the first frame update
    void Start()
    {
        flameAttack = GetComponentInParent<Boss_FlameAttack>();
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
            pStatus.GetDamage(flameAttack.Damage);

            StartCoroutine(pStatus.OnDamage());
        }
    }
}
