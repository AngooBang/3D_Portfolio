using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class TalkManager : MonoBehaviour
{
    [SerializeField] public Dictionary<int, string[]> talkData;
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
        talkData.Add(10 + 1000, new string[] { "처음보는 용사님이시네요. 저희 마을에 오신걸 환영해요.", 
                                                "혹시 바쁘지 않으시다면,\n제 부탁 좀 들어주실 수 있나요?"});


        talkData.Add(20 + 1000, new string[] { "고마워요 용사님!!",
                                                "제가 지금 급히 쓸 일이 있어서 그런데...\n 파란 거북이의 등껍질을 3개만 구해줘요.",
                                                  "보수는 두둑히 드릴테니까,, 그럼 부탁해요!"});
        talkData.Add(21 + 1000, new string[] { "뭘봐? 어서 빨리 구하러 가지 않고??" });

        //string jData = JsonConvert.SerializeObject(talkData);
        //Debug.Log(jData);
    }


    public string GetTalk(int objectID, int talkIndex)
    {
        if (talkIndex == talkData[objectID].Length)
            return null;
        else
            return talkData[objectID][talkIndex];
    }
}
