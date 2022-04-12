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
        talkData.Add(10000 + 1000, new string[] { "ó������ ���谡���̽ó׿�. ���� ������ ���Ű� ȯ���ؿ�.", 
                                                "Ȥ�� �ٻ��� �����ôٸ�,\n�� ��Ź �� ����ֽ� �� �ֳ���?",
                                                "(�ٽ� ���� �ɾ� ����Ʈ�� �����ϼ���.)"});

        talkData.Add(10010 + 1000, new string[] { "��...",
                                                  "�ƹ����� ���谡���� ���� �ο��غ� �ȵ� �� ���ƿ�.",
                                                "'I'Ű�� ���� �κ��丮 â�� �� ��, \n��Ŭ�� ���� ���� ��� ���� �����غ�����."});

        talkData.Add(10011 + 1000, new string[] { "���� ��� �� �������� �����̴°ɿ�?"});

        talkData.Add(10012 + 1000, new string[] { "�Ḣ�ؿ�!! ���� ���� �ο� �غ� �Ǿ�̴µ���?", 
                                                "(�ٽ� ���� �ɾ� ����Ʈ�� �����ϼ���.)" });


        talkData.Add(10020 + 1000, new string[] { "���谡��! ��� �����ϼ̰ڴ�, ����Ʈ�� �����ϼž߰���?",
                                                "��ħ ���� ���� ���� �� ���� �־ �׷���...\n �Ķ� �ź����� ����� 3���� �������.",
                                                  "������ �ε��� �帱�״ϱ�.. �׷� ��Ź�ؿ�!"});
        talkData.Add(10021 + 1000, new string[] { "����? � ���� ���Ϸ� ���� �ʰ�??" });

        talkData.Add(10022 + 1000, new string[] { "20000����Ʈ �Ϸ�ÿ� ������ �ؽ�Ʈ�Դϴ�.", "�׽�Ʈ�� ��Ʈ�� �ΰ� �־�ҽ��ϴ�." });
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
