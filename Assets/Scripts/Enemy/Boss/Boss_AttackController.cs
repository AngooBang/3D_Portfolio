using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_AttackController : MonoBehaviour
{


    private Boss_DetectPlayer detect;
    private Animator animator;

    private Boss_ClawAttack clawAttack;
    private Boss_BasicAttack basicAttack;
    private Boss_FlameAttack flameAttack;
    // Start is called before the first frame update
    void Start()
    {
        detect = GetComponent<Boss_DetectPlayer>();
        animator = GetComponent<Animator>();

        clawAttack = GetComponent<Boss_ClawAttack>();
        basicAttack = GetComponent<Boss_BasicAttack>();
        flameAttack = GetComponent<Boss_FlameAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(detect.IsDetect == true && clawAttack.IsAttack == false && basicAttack.IsAttack == false && flameAttack.IsAttack == false && detect.IsScream == false)
        {
            //������ ������. ������ �����ϰ� ����.
            int randNum = Random.Range(1, 11);
            Debug.Log(randNum);
            //int randNum = 3;
            switch (randNum)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    // ����
                    basicAttack.PlayAttack();
                    Debug.Log(randNum + "��° ���� �����.");
                    break;
                case 7:
                case 8:
                case 9:
                    // �����ϸ� ������
                    clawAttack.PlayAttack();
                    Debug.Log(randNum + "��° ���� �����.");
                    break;
                case 10:
                    // ȭ�� �극��
                    flameAttack.PlayAttack();
                    Debug.Log(randNum + "��° ���� �����.");
                    break;
            }
            
        }
    }
}
