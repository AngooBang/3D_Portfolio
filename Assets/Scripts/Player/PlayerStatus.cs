using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : LivingEntity
{
    public int MaxSP;
    public int CurrentSP;

    private PlayerUIController uiController;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        CurrentSP = 0;

        uiController = GetComponent<PlayerUIController>();

        uiController.SetHPBarValue();
        uiController.SetSPBarValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitEnemy()
    {
        CurrentSP += 10;
        if(CurrentSP > MaxSP)
        {
            CurrentSP = MaxSP;
        }
        uiController.SetSPBarValue();
    }

    public override void GetDamage(int damage)
    {
        base.GetDamage(damage);

        uiController.SetHPBarValue();
    }
}
