using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Text;

public class MonsterDropDataJsonMaker : MonoBehaviour
{
    public Dictionary<int, MonsterDropData> monsterDrops;
    private void Awake()
    {
        monsterDrops = new Dictionary<int, MonsterDropData>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateMonsterDrops(101);
        MonsterDropsConvertToJson();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateMonsterDrops(int monsterID)
    {
        MonsterDropData monsterDrop = new MonsterDropData(monsterID);
        monsterDrops.Add(monsterID, monsterDrop);
    }

    void MonsterDropsConvertToJson()
    {
        string dropJsonData = ObjectToJson(monsterDrops);
        Debug.Log(dropJsonData);
        CreateJsonFile(Application.dataPath, "MonsterDropData", dropJsonData);
    }

    public MonsterDropData ExtractToDropDataOfMonsterID(int monsterID)
    {
        Dictionary<int, MonsterDropData> drops = LoadJsonFile<Dictionary<int, MonsterDropData>>(Application.dataPath, "MonsterDropData");
        if (drops.ContainsKey(monsterID))
        {
            return drops[monsterID];
        }
        else
        {
            return null;
        }
    }

    string ObjectToJson(object obj)
    {
        return JsonConvert.SerializeObject(obj);

    }

    void CreateJsonFile(string createPath, string fileName, string jsonData)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, fileName), FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }

    T LoadJsonFile<T>(string loadPath, string fileName)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();

        string dropJsonData = Encoding.UTF8.GetString(data);
        return JsonConvert.DeserializeObject<T>(dropJsonData);
    }
}
