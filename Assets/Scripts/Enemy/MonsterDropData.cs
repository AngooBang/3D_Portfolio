using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDropData
{
    public int[] dropItems;
    public int[] itemDropPercents;
    public int minGold;
    public int maxGold;

    
    public MonsterDropData(int monsterID)
    {
        if(monsterID == 101)
        {
            dropItems = new int[] { 21 };
            itemDropPercents = new int[] { 100 };
            minGold = 1;
            maxGold = 5;
        }
    }
}
