using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropManager : MonoBehaviour
{
    public GameObject CoinPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DropGold(Transform dropTrans)
    {
        Instantiate(CoinPrefab, dropTrans);
    }

    void MonsterDropItem(int monsterID, Transform dropTrans)
    {
        // json�� ���� mosterID�� �ش��ϴ� (����Ҽ� �ִ� �ּ� ���, �ִ� ���, ������ID, Ȯ�� �� �����´�)
        // json �����ʹ� ���� ��������Ϳ� ������ �����ͷ� ����.
        // ���� ��������Ϳ��� �޾ƿ� ������ID�� ���� �����۵������� Json�� ������ ������Ʈ�� �����س��� ���.
        // ���� ������ �����͸� ���� �������� ����Ѵ�.
    }
}
