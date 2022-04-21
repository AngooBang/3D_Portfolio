using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBarSystem : MonoBehaviour
{
    public GameObject num1Slot;
    public GameObject num2Slot;
    public GameObject num3Slot;
    public GameObject num4Slot;
    public GameObject num5Slot;
    public GameObject num6Slot;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Hot1"))
        {
            PressHotKey(num1Slot);
        }
        if (Input.GetButtonDown("Hot2"))
        {
            PressHotKey(num2Slot);
        }
        if (Input.GetButtonDown("Hot3"))
        {
            PressHotKey(num3Slot);
        }
        if (Input.GetButtonDown("Hot4"))
        {
            PressHotKey(num4Slot);
        }
        if (Input.GetButtonDown("Hot5"))
        {
            PressHotKey(num5Slot);
        }
        if (Input.GetButtonDown("Hot6"))
        {
            PressHotKey(num6Slot);
        }
    }

    void PressHotKey(GameObject hotKeySlot)
    {
        // 아이템이라면.
        UseItem slotItemUse = hotKeySlot.GetComponentInChildren<UseItem>();

        if(slotItemUse != null)
        {
            slotItemUse.startParentObject = hotKeySlot;
            slotItemUse.Use();
        }

        // 스킬이라면.
        UseSkill slotSkillUse = hotKeySlot.GetComponentInChildren<UseSkill>();

        if(slotSkillUse != null)
        {
            slotSkillUse.Use();
        }
    }
}
