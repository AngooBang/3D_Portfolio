using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillData : MonoBehaviour
{
    public int skillID;
    public string skillName;
    public string skillDescription;
    public Sprite skillIcon;


    public void SetSkillData(SkillData data)
    {
        skillID = data.skillID;
        skillName = data.skillName;
        skillDescription = data.skillDescription;
        skillIcon = data.skillIcon;

        GetComponent<Image>().sprite = skillIcon;
    }
}
