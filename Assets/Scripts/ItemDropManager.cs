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
        // json을 통해 mosterID에 해당하는 (드랍할수 있는 최소 골드, 최대 골드, 아이템ID, 확률 을 가져온다)
        // json 데이터는 몬스터 드랍데이터와 아이템 데이터로 구분.
        // 몬스터 드랍데이터에서 받아온 아이템ID를 통해 아이템데이터의 Json에 접근해 오브젝트를 생성해내는 방식.
        // 위의 가져온 데이터를 통해 아이템을 드랍한다.
    }
}
