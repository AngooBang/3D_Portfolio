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
        // talkData �ʱ�ȭ
        // 1000 : �ҳ�
        // 2000 : ��������
        talkData.Add(1000, new string[] { "�ȳ�!", "�׽�Ʈ�׽�Ʈ!��_��"});
        talkData.Add(2000, new string[] { "����...", "���� �� �ѷ� ���ڳ�?" });

        // Quest Talk
        talkData.Add(10 + 1000, new string[] { "���! �ű� �������� ����! �� �� �����ٷ���?",
                                                "���� ���� ���� �� ���� �־ �׷���...\n �Ķ� �ź����� ����� 3���� �������.",
                                                  "������ �ε��� �帱�״ϱ�,, �׷� ��Ź�ؿ�!"});
        talkData.Add(11 + 1000, new string[] { "����? � ���� ���Ϸ� ���� �ʰ�?" });
    }


    public string GetTalk(int objectID, int talkIndex)
    {
        if (talkIndex == talkData[objectID].Length)
            return null;
        else
            return talkData[objectID][talkIndex];
    }
}
