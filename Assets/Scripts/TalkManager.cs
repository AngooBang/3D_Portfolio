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
        talkData.Add(10000 + 1000, new string[] { "처음보는 모험가님이시네요. 저희 마을에 오신걸 환영해요.", 
                                                "혹시 바쁘지 않으시다면,\n제 부탁 좀 들어주실 수 있나요?",
                                                "(다시 말을 걸어 퀘스트를 진행하세요.)"});

        talkData.Add(10010 + 1000, new string[] { "음...",
                                                  "아무래도 모험가님은 아직 싸울준비가 안된 것 같아요.",
                                                "'I'키를 눌러 인벤토리 창을 켠 후, \n우클릭 등을 통해 장비를 전부 착용해보세요."});

        talkData.Add(10011 + 1000, new string[] { "아직 장비를 다 착용하지 않으셨는걸요?"});

        talkData.Add(10012 + 1000, new string[] { "휼륭해요!! 이제 제법 싸울 준비가 되어보이는데요?", 
                                                "(다시 말을 걸어 퀘스트를 진행하세요.)" });


        talkData.Add(10020 + 1000, new string[] { "모험가님! 장비도 착용하셨겠다, 퀘스트를 진행하셔야겠죠?",
                                                "마침 제가 지금 급히 쓸 일이 있어서 그런데...\n 파란 거북이의 등껍질을 3개만 구해줘요.",
                                                  "보수는 두둑히 드릴테니까.. 그럼 부탁해요!"});
        talkData.Add(10021 + 1000, new string[] { "뭘봐? 어서 빨리 구하러 가지 않고??" });

        talkData.Add(10022 + 1000, new string[] { "20000퀘스트 완료시에 나오는 텍스트입니다.", "테스트로 스트링 두개 넣어보았습니다." });
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
