using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class QuestManager : MonoBehaviour
{
    public Dictionary<int, QuestData> questList;
    public int ActiveQuestID;

    private QuestUIController questUIController;
    private InventorySystem inventorySystem;




    private void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        questUIController = GetComponent<QuestUIController>();
        inventorySystem = GameObject.FindGameObjectWithTag("MainInventory").GetComponent<InventorySystem>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateQuestData(10000);
        GenerateQuestData(20000);
        GenerateQuestData(50000);

        ReceiveQuest(10000);
    }

    private void LateUpdate()
    {
        CheckQuestProgress();
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


    // �ش� npc�� ���� ���۵� ����Ʈ�� �ִٸ�, �ش� ����Ʈ�� id�� return, ���ٸ� 0�� return.
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
                // ����Ʈ ���൵�� �´� ������Ʈ���
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
            // �κ��丮 �ý��ۿ��� �����ϴ� �������� ������ ���Ϲ޾� ����.
            questList[ActiveQuestID].qCurrentNum = inventorySystem.CheckHaveItemValues(questList[ActiveQuestID].collectItemID);
            
            questUIController.SetQuestUIText();
            CheckQuestFinish();
        }
    }

    public void CheckQuestFinish()
    {
        if (ActiveQuestID == 20000)
        {
            // ������ �����Ǿ�����(��� �ٸ�Ҵ���)
            if(questList[ActiveQuestID].qCurrentNum >= questList[ActiveQuestID].qFinishNum)
            {
                // ProgressNum�� �ѹ��� ������Ű������. Finish�� �����϶��� ����.
                if (questList[ActiveQuestID].isFinish == false)
                {
                    questList[ActiveQuestID].QuestProgressNum++;
                    questList[ActiveQuestID].isFinish = true;
                }
            }
        }
    }


    public void QuestFinishAndChainQuest(int questId)
    {
        if(questId == 10000)
        {
            if (questList[questId].isFinish)
            {
                questList[questId].isReceive = false;
                questList[questId].isComplete = true;
                questList[20000].isStartReady = true;
                ActiveQuestID = 0;
                questUIController.SetQuestUIText();
                // ���� ��..��.��
                var girlObject = GameObject.Find("Girl");
                InteractiveNPC girlInteract = girlObject.GetComponent<InteractiveNPC>();
                girlInteract.isQuestStart = true;
            }
        }
    }
}
