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
        // talkData �ʱ�ȭ
        // 1000 : �ҳ�
        // 2000 : ��������
        talkData.Add(1000, new string[] { "�ȳ�!", "�׽�Ʈ�׽�Ʈ!��_��"});
        talkData.Add(2000, new string[] { "����...", "���� �� �ѷ� ���ڳ�?" });

        // Quest Talk
        talkData.Add(10000 + 1000, new string[] { "ó������ �����̽ó׿�. ���� ������ ���Ű� ȯ���ؿ�.", 
                                                "Ȥ�� �ٻ��� �����ôٸ�,\n�� ��Ź �� ����ֽ� �� �ֳ���?"});


        talkData.Add(20000 + 1000, new string[] { "������ ����!!",
                                                "���� ���� ���� �� ���� �־ �׷���...\n �Ķ� �ź����� ����� 3���� �������.",
                                                  "������ �ε��� �帱�״ϱ�,, �׷� ��Ź�ؿ�!"});
        talkData.Add(20001 + 1000, new string[] { "����? � ���� ���Ϸ� ���� �ʰ�??" });

        talkData.Add(20002 + 1000, new string[] { "20000����Ʈ �Ϸ�ÿ� ������ �ؽ�Ʈ�Դϴ�.", "�׽�Ʈ�� ��Ʈ�� �ΰ� �־�ҽ��ϴ�." });
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
