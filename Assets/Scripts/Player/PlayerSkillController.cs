using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillController : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F5))
        {
            UseSkill(1);
        }
    }

    public void UseSkill(int skillID)
    {
        if(skillID == 1)
        {
            animator.SetTrigger("Skill1");
        }
    }
}
