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
        talkData.Add(3000, new string[] { "...", "드래곤을 무찔러주세요.." });

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

        talkData.Add(10022 + 1000, new string[] { "등껍질을 전부 구해왔구나!!", "고마워, 보상으로 더 좋은 장비들을 지급해줄게.", "(다시 말을 걸어 퀘스트를 진행하세요.)" });
        
        talkData.Add(10030 + 1000, new string[] { "사실.. 등껍질같은건 필요하지 않았어...", "드래곤에게 납치당한 마을의 공주를 \n구해줄 용사를 찾고있었거든..", "부탁이야!! 드래곤을 처치하고 공주를 구출해줘!!!!" });
        talkData.Add(10031 + 1000, new string[] { "얼른 출발해!! \n 이러다간 공주님을 영영 구하지 못할 수 있다고!!" });
        talkData.Add(10032 + 3000, new string[] { "고마워요 용사님..", "저를 구하러 와주셨군요...",  "정말 감사합니다..\n(Game Clear)" });
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
