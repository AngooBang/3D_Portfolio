using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class QuestManager : MonoBehaviour
{
    public Dictionary<int, QuestData> questList;
    public int ActiveQuestID;

    private ItemDropManager itemDropManager;
    private QuestUIController questUIController;
    private InventorySystem inventorySystem;
    private EquipmentSystem equipmentSystem;




    private void Awake()
    {
        questList = new Dictionary<int, QuestData>();

        itemDropManager = GameObject.FindGameObjectWithTag("DropManager").GetComponent<ItemDropManager>();
        questUIController = GetComponent<QuestUIController>();
        inventorySystem = GameObject.FindGameObjectWithTag("MainInventory").GetComponent<InventorySystem>();
        equipmentSystem = GameObject.FindGameObjectWithTag("InterfaceUI").transform.GetChild(2).gameObject.GetComponent<EquipmentSystem>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateQuestData(10000);
        GenerateQuestData(10010);
        GenerateQuestData(10020);
        GenerateQuestData(10030);

        ReceiveQuest(10000);
    }

    private void LateUpdate()
    {
        CheckQuestProgress();
        SetMarkerOfQuest();
    }

    void GenerateQuestData(int questID)
    {
        QuestData qData = new QuestData(questID);
        
        questList.Add(questID, qData);
    }

    public void ReceiveQuest(int questId)
    {
        questList[questId].isReceive = true;
        ActiveQuestID = questId;
        questUIController.SetQuestUIText();
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

    public void CheckQuestProgress()
    {
        if (ActiveQuestID == 0)
            return;
        if(questList[ActiveQuestID].questType == QuestType.Collect)
        {
            // 인벤토리 시스템에서 수집하는 아이템의 개수를 리턴받아 갱신.
            questList[ActiveQuestID].qCurrentNum = inventorySystem.CheckHaveItemValues(questList[ActiveQuestID].collectItemID);
            
            questUIController.SetQuestUIText();
            CheckQuestFinish();
        }
        if(questList[ActiveQuestID].questType == QuestType.Subject)
        {
            if(ActiveQuestID == 10010)
            {
                // 장비 착용 퀘스트 체크.
                if(equipmentSystem.GetIsFullEquiped())
                {
                    questList[ActiveQuestID].qCurrentNum = 1;
                    questUIController.SetQuestUIText();
                }
                else
                {
                    questList[ActiveQuestID].qCurrentNum = 0;
                    questUIController.SetQuestUIText();
                }
                CheckQuestFinish();
            }
            if(ActiveQuestID == 10030)
            {
                // 보스 킬 퀘스트 체크.
            }
        }
    }

    public void CheckQuestFinish()
    {
        if (ActiveQuestID == 10010 || ActiveQuestID == 10020)
        {
            // 조건이 충족되었는지(등껍질 다모았는지)
            if(questList[ActiveQuestID].qCurrentNum >= questList[ActiveQuestID].qFinishNum)
            {
                // ProgressNum을 한번만 증가시키기위해. Finish가 거짓일때만 실행.
                if (questList[ActiveQuestID].isFinish == false)
                {
                    questList[ActiveQuestID].QuestProgressNum++;
                    questList[ActiveQuestID].isFinish = true;
                }
            }
            else
            {
                questList[ActiveQuestID].isFinish = false;
                if(questList[ActiveQuestID].QuestProgressNum == 2)
                    questList[ActiveQuestID].QuestProgressNum = 1;
            }
        }
    }


    public void QuestFinishAndChainQuest(int questID)
    {
        if(questID == 10000)
        {
            if (questList[questID].isFinish)
            {
                questList[questID].isReceive = false;
                questList[questID].isComplete = true;
                questList[10010].isStartReady = true;
                ActiveQuestID = 0;
                questUIController.SetQuestUIText();
                // 구조 시..발.ㅜ
                GameObject girlObject = GameObject.Find("Girl");
                girlObject.GetComponent<QuestMarkerController>().ChangeMarker(0);
                InteractiveNPC girlInteract = girlObject.GetComponent<InteractiveNPC>();
                girlInteract.isQuestStart = true;
                QuestReward(questID);
            }
        }
        if (questID == 10010)
        {
            if (questList[questID].isFinish)
            {
                questList[questID].isReceive = false;
                questList[questID].isComplete = true;
                questList[10020].isStartReady = true;
                ActiveQuestID = 0;
                questUIController.SetQuestUIText();
                
                GameObject girlObject = GameObject.Find("Girl");
                girlObject.GetComponent<QuestMarkerController>().ChangeMarker(0);
                InteractiveNPC girlInteract = girlObject.GetComponent<InteractiveNPC>();
                girlInteract.isQuestStart = true;
                QuestReward(questID);
            }
        }
        if (questID == 10020)
        {
            if (questList[questID].isFinish)
            {
                questList[questID].isReceive = false;
                questList[questID].isComplete = true;
                questList[10030].isStartReady = true;
                ActiveQuestID = 0;
                questUIController.SetQuestUIText();
                // 구조 시..발.ㅜ
                var girlObject = GameObject.Find("Girl");
                girlObject.GetComponent<QuestMarkerController>().ChangeMarker(0);
                InteractiveNPC girlInteract = girlObject.GetComponent<InteractiveNPC>();
                girlInteract.isQuestStart = true;
                QuestReward(questID);
            }
        }
        // 퀘스트 보상 지급.
    }

    public void QuestReward(int questID)
    {
        if (questID == 10000)
        {
            itemDropManager.CreateItemInInventory(1);
            itemDropManager.CreateItemInInventory(3);
            itemDropManager.CreateItemInInventory(5);
            itemDropManager.CreateItemInInventory(7);
            inventorySystem.GetCoin(5);
        }
        if (questID == 10010)
        {
            inventorySystem.GetCoin(10);
        }
        if (questID == 10020)
        {
            itemDropManager.CreateItemInInventory(2);
            itemDropManager.CreateItemInInventory(4);
            itemDropManager.CreateItemInInventory(6);
            itemDropManager.CreateItemInInventory(8);
            inventorySystem.GetCoin(15);
        }

    }

    public void SetMarkerOfQuest()
    {
        // 활성화 된 퀘스트가 없고,
        if(ActiveQuestID == 0)
        {
            foreach (var questData in questList.Values)
            {
                // 퀘스트를 시작할 준비가 되었고
                if (questData.isStartReady)
                {
                    // 받아져있는 상태가 아니면서
                    if (questData.isReceive == false)
                    {
                        GameObject[] npcObjects = GameObject.FindGameObjectsWithTag("NPC");
                        foreach (var npc in npcObjects)
                        {
                            // 퀘스트 데이터의 처음시작하는 objectID와 일치하는 objectID의 npc라면
                            if (questData.objectID[0] == npc.GetComponent<ObjectData>().ObjectID)
                            {
                                // 느낌표를 띄워준다.
                                npc.GetComponent<QuestMarkerController>().ChangeMarker(1);
                            }
                        }
                    }
                }
            }
        }
        else
        {
            GameObject[] npcObjects = GameObject.FindGameObjectsWithTag("NPC");
            foreach (var npc in npcObjects)
            {
                // 퀘스트 데이터의 진행도에 알맞는 오브젝트 아이디와 일치하는 npc를찾아서
                 if (questList[ActiveQuestID].objectID[questList[ActiveQuestID].QuestProgressNum] == npc.GetComponent<ObjectData>().ObjectID)
                {
                    // 완료 상태를 확인하여
                    if (questList[ActiveQuestID].isFinish == false)
                    {
                        // 진행중인 물음표르 ㄹ띄워준다.
                        npc.GetComponent<QuestMarkerController>().ChangeMarker(2);
                    }
                    else
                    {
                        // 완료된 물음표르 ㄹ띄워준다.
                        npc.GetComponent<QuestMarkerController>().ChangeMarker(3);

                    }
                }
            }
        }

    }
}
