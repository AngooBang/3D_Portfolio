using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSkill : MonoBehaviour
{

    private PlayerSkillController pSkillController;

    private SkillData skillData;
    // Start is called before the first frame update
    void Start()
    {
        skillData = GetComponent<SkillData>();
        pSkillController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSkillController>();
    }


    public void Use()
    {
        pSkillController.UseSkill(skillData.skillID);
    }
}
