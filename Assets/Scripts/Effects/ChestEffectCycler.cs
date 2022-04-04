using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChestEffectCycler : MonoBehaviour
{
    [SerializeField]
    List<GameObject> listOfEffects;

    [SerializeField]
    GameObject instantiatedEffect;

    int effectIndex = 0;

    // Use this for initialization
    void Start()
    {
        instantiatedEffect = Instantiate(listOfEffects[effectIndex], transform.position, transform.rotation) as GameObject;
        effectIndex++;
    }


    public void PlayEffect()
    {
        Destroy(instantiatedEffect);
        instantiatedEffect = Instantiate(listOfEffects[effectIndex], transform.position, transform.rotation) as GameObject;
        if (effectIndex == 0)
            effectIndex++;
        else
            effectIndex = 0;
    }
    private void OnDestroy()
    {
        Destroy(instantiatedEffect);
    }
}
