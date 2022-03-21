using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Text;

public class QuestManager : MonoBehaviour
{
    [SerializeField] public Dictionary<int, QuestData> questList;
    private QuestUIController questUIController;


    private void Awake()
    {

        questList = new Dictionary<int, QuestData>();
        questUIController = GetComponent<QuestUIController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateQuestData(10);
        GenerateQuestData(20);
        GenerateQuestData(50);
        QuestDataConvertJson();

        ReceiveQuest(10);
    }



    void GenerateQuestData(int questID)
    {
        QuestData qData = new QuestData(questID);
        
        questList.Add(questID, qData);
    }

    public void ReceiveQuest(int questId)
    {
        questList[questId].isReceive = true;
        questUIController.ActiveQuestID = questId;
        questUIController.SetQuestUIText();
    }


    void QuestDataConvertJson()
    {
        string questJsonData = ObjectToJson(questList);
        Debug.Log(questJsonData);
        CreateJsonFile(Application.dataPath, "QuestData", questJsonData);
    }

    // 해당 npc를 통해 시작될 퀘스트가 있다면, 해당 퀘스트의 id를 return, 없다면 0을 return.
    public int GetQuestStartIndex(int objectID)
    {
        foreach(var questData in questList.Values)
        {
            if(questData.isStartReady && questData.isComplete == false)
            {
                if(questData.objectID[questData.QuestProgressNum]  == objectID)
                {
                    return questData.QuestID + questData.QuestProgressNum;
                }
            }
        }
        return 0;
    }

    public int GetQuestTalkIndex(int objectID)
    {
        foreach(var questData in questList.Values)
        {
            if(questData.isReceive && questData.isComplete == false)
            {
                // 퀘스트 진행도에 맞는 오브젝트라면
                if(questData.objectID[questData.QuestProgressNum] == objectID)
                {
                    return questData.QuestID + questData.QuestProgressNum;
                }
            }
        }

        return 0;
    }

    public void NextQuestProcess(int questId)
    {
        questList[questId].QuestProgressNum++;
    }



    public void CheckQuestFinish(int questId)
    {
        if(questId == 10)
        {
            if (questList[questId].isFinish)
            {
                questList[questId].isReceive = false;
                questList[questId].isComplete = true;
                questList[20].isStartReady = true;
                questUIController.ActiveQuestID = 0;
                questUIController.SetQuestUIText();
                // 구조 시..발.ㅜ
                var girlObject = GameObject.Find("Girl");
                InteractiveNPC girlInteract = girlObject.GetComponent<InteractiveNPC>();
                girlInteract.isQuestStart = true;
            }
        }
    }






    string ObjectToJson(object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }

    void CreateJsonFile(string createPath, string fileName, string questJsonData)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, fileName), FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(questJsonData);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }

    T LoadJsonFile<T>(string loadPath, string fileName)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();

        string questJsonData = Encoding.UTF8.GetString(data);
        return JsonConvert.DeserializeObject<T>(questJsonData);
    }
}
