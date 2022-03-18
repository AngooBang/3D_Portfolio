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
        // talkData 초기화
        // 1000 : 소녀
        // 2000 : 대장장이
        talkData.Add(1000, new string[] { "안녕!", "테스트테스트!ㅎ_ㅎ"});
        talkData.Add(2000, new string[] { "허허...", "물건 좀 둘러 보겠나?" });

        // Quest Talk
        talkData.Add(10 + 1000, new string[] { "어머! 거기 지나가는 용사님! 저 좀 도와줄래요?",
                                                "제가 지금 급히 쓸 일이 있어서 그런데...\n 파란 거북이의 등껍질을 3개만 구해줘요.",
                                                  "보수는 두둑히 드릴테니까,, 그럼 부탁해요!"});
        talkData.Add(11 + 1000, new string[] { "뭘봐? 어서 빨리 구하러 가지 않고?" });
    }


    public string GetTalk(int objectID, int talkIndex)
    {
        if (talkIndex == talkData[objectID].Length)
            return null;
        else
            return talkData[objectID][talkIndex];
    }
}
