using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickParticle : MonoBehaviour
{
    private ParticleSystem clickParticle;
    // Start is called before the first frame update
    void Start()
    {
        clickParticle = GetComponent<ParticleSystem>();
        PlayEffect();
    }


    private void PlayEffect()
    {
        clickParticle.Play();
        Destroy(gameObject, clickParticle.duration);
    }
}
