using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum WeaponType { Sword, GreatSword };
    public WeaponType type;
    public int damage;
    public float rate;
    public float attackTerm;
    public BoxCollider meleeArea;
    public TrailRenderer trailEffect;

    public void Use(int atkCount)
    {
        if (type == WeaponType.Sword)
        {
            if(atkCount == 1)
            {
                StopCoroutine(Swing(0f, 0f, 0f, 0f));
                StartCoroutine(Swing(0.3f, 0f, 0.3f, 0.2f));
            }
            
            if(atkCount == 2)
            {
                StopCoroutine(Swing(0f, 0f, 0f, 0f));
                StartCoroutine(Swing(0.3f, 0f, 0.3f, 0.4f));
            }

            if (atkCount == 3)
            {
                StopCoroutine(Swing(0f, 0f, 0f, 0f));
                StartCoroutine(Swing(0.8f, 0.1f, 0.3f, 0.5f));
            }
        }
    }

    IEnumerator Swing(float effectEnableTime, float colEnableTime, float colDisTime, float effectDisTime)
    {
        yield return new WaitForSeconds(effectEnableTime);
        trailEffect.enabled = true;

        yield return new WaitForSeconds(colEnableTime);
        meleeArea.enabled = true;

        yield return new WaitForSeconds(colDisTime);
        meleeArea.enabled = false;

        yield return new WaitForSeconds(effectDisTime);
        trailEffect.enabled = false;
    }
}
