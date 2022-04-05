using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Text;

public class ItemJsonMaker : MonoBehaviour
{
    public List<ItemData> itemList;
    private void Awake()
    {
        itemList = new List<ItemData>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateItemData(1);
        GenerateItemData(2);
        GenerateItemData(3);
        GenerateItemData(4);
        GenerateItemData(5);
        GenerateItemData(6);
        GenerateItemData(7);
        GenerateItemData(8);
        GenerateItemData(11);
        ItemDataConvertToJson();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateItemData(int itemID)
    {
        ItemData item = new ItemData(itemID);
        itemList.Add(item);
    }
    void ItemDataConvertToJson()
    {
        string itemJsonData = ObjectToJson(itemList);
        Debug.Log(itemJsonData);
        CreateJsonFile(Application.dataPath, "ItemDataList", itemJsonData);
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

        string questJsonData = Encoding.UTF8.GetString(data);
        return JsonConvert.DeserializeObject<T>(questJsonData);
    }
}
