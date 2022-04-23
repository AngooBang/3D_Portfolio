using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_AttackController : MonoBehaviour
{
    private Boss_DetectPlayer detect;

    private Boss_ClawAttack clawAttack;
    private Boss_BasicAttack basicAttack;
    private Boss_FlameAttack flameAttack;
    // Start is called before the first frame update
    void Start()
    {
        detect = GetComponent<Boss_DetectPlayer>();
        clawAttack = GetComponent<Boss_ClawAttack>();
        basicAttack = GetComponent<Boss_BasicAttack>();
        flameAttack = GetComponent<Boss_FlameAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if(detect.IsDetect == true && clawAttack.IsAttack == false && basicAttack.IsAttack == false && flameAttack.IsAttack == false)
        {
            //감지가 됐을때. 패턴을 랜덤하게 실행.
            int randNum = Random.Range(1, 4);

            switch (randNum)
            {
                case 1:
                    // 물기
                    basicAttack.PlayAttack();
                    Debug.Log(randNum + "번째 패턴 실행됨.");
                    break;
                case 2:
                    // 돌진하며 물어뜯기
                    clawAttack.PlayAttack();
                    Debug.Log(randNum + "번째 패턴 실행됨.");
                    break;
                case 3:
                    // 화염 브레스
                    flameAttack.PlayAttack();
                    Debug.Log(randNum + "번째 패턴 실행됨.");
                    break;
            }
            
        }
    }
}
