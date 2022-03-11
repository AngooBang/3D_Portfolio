using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    // Start is called before the first frame update
    void Start()
    {        
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(1000, new string[] { "안녕!", "테스트테스트!ㅎ_ㅎ"});
    }


    public string GetTalk(int id, int talkIndex)
    {
        return talkData[id][talkIndex];
    }
}
