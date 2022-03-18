using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Text;

public class QuestManager : MonoBehaviour
{
    public Dictionary<int, QuestData> questList;
    // Start is called before the first frame update
    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        ReceiveQuest(10);
        ReceiveQuest(50);
        questList[10].ReceiveQuest();
    }


    void ReceiveQuest(int questID)
    {
        QuestData qData = new QuestData(questID);
        string questJsonData = ObjectToJson(qData);
        Debug.Log(qData);
        FileInfo fi = new FileInfo(Application.dataPath + "QuestData.json");
        if(fi.Exists == false)
        {
            CreateJsonFile(Application.dataPath, "QuestData" + qData.QuestID, questJsonData);
        }
        else
        {
            WriteJsonFile(Application.dataPath, "QuestData", questJsonData);
        }

        var qObject = LoadJsonFile<QuestData>(Application.dataPath, "QuestData" + qData.QuestID);
        
        questList.Add(qObject.QuestID, qObject);
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

    void WriteJsonFile(string loadPath, string fileName, string questJsonData)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.Open);
        byte[] data = Encoding.UTF8.GetBytes(questJsonData);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }
}
