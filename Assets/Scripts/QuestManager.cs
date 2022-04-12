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
    private EquipmentSystem equipmentSystem;




    private void Awake()
    {
        questList = new Dictionary<int, QuestData>();
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
        if(questList[ActiveQuestID].questType == QuestType.Subject)
        {
            if(ActiveQuestID == 10010)
            {
                // ��� ���� ����Ʈ üũ.
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
                // ���� ų ����Ʈ üũ.
            }
        }
    }

    public void CheckQuestFinish()
    {
        if (ActiveQuestID == 10010 || ActiveQuestID == 10020)
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
            else
            {
                questList[ActiveQuestID].isFinish = false;
                if(questList[ActiveQuestID].QuestProgressNum == 2)
                    questList[ActiveQuestID].QuestProgressNum = 1;
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
                questList[10010].isStartReady = true;
                ActiveQuestID = 0;
                questUIController.SetQuestUIText();
                // ���� ��..��.��
                var girlObject = GameObject.Find("Girl");
                girlObject.GetComponent<QuestMarkerController>().ChangeMarker(0);
                InteractiveNPC girlInteract = girlObject.GetComponent<InteractiveNPC>();
                girlInteract.isQuestStart = true;
            }
        }
        if (questId == 10010)
        {
            if (questList[questId].isFinish)
            {
                questList[questId].isReceive = false;
                questList[questId].isComplete = true;
                questList[10020].isStartReady = true;
                ActiveQuestID = 0;
                questUIController.SetQuestUIText();
                // ���� ��..��.��
                var girlObject = GameObject.Find("Girl");
                girlObject.GetComponent<QuestMarkerController>().ChangeMarker(0);
                InteractiveNPC girlInteract = girlObject.GetComponent<InteractiveNPC>();
                girlInteract.isQuestStart = true;
            }
        }
        if (questId == 10020)
        {
            if (questList[questId].isFinish)
            {
                questList[questId].isReceive = false;
                questList[questId].isComplete = true;
                questList[10030].isStartReady = true;
                ActiveQuestID = 0;
                questUIController.SetQuestUIText();
                // ���� ��..��.��
                var girlObject = GameObject.Find("Girl");
                girlObject.GetComponent<QuestMarkerController>().ChangeMarker(0);
                InteractiveNPC girlInteract = girlObject.GetComponent<InteractiveNPC>();
                girlInteract.isQuestStart = true;
            }
        }
    }

    public void SetMarkerOfQuest()
    {
        // Ȱ��ȭ �� ����Ʈ�� ����,
        if(ActiveQuestID == 0)
        {
            foreach (var questData in questList.Values)
            {
                // ����Ʈ�� ������ �غ� �Ǿ���
                if (questData.isStartReady)
                {
                    // �޾����ִ� ���°� �ƴϸ鼭
                    if (questData.isReceive == false)
                    {
                        GameObject[] npcObjects = GameObject.FindGameObjectsWithTag("NPC");
                        foreach (var npc in npcObjects)
                        {
                            // ����Ʈ �������� ó�������ϴ� objectID�� ��ġ�ϴ� objectID�� npc���
                            if (questData.objectID[0] == npc.GetComponent<ObjectData>().ObjectID)
                            {
                                // ����ǥ�� ����ش�.
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
                // ����Ʈ �������� ���൵�� �˸´� ������Ʈ ���̵�� ��ġ�ϴ� npc��ã�Ƽ�
                 if (questList[ActiveQuestID].objectID[questList[ActiveQuestID].QuestProgressNum] == npc.GetComponent<ObjectData>().ObjectID)
                {
                    // �Ϸ� ���¸� Ȯ���Ͽ�
                    if (questList[ActiveQuestID].isFinish == false)
                    {
                        // �������� ����ǥ�� ������ش�.
                        npc.GetComponent<QuestMarkerController>().ChangeMarker(2);
                    }
                    else
                    {
                        // �Ϸ�� ����ǥ�� ������ش�.
                        npc.GetComponent<QuestMarkerController>().ChangeMarker(3);

                    }
                }
            }
        }

    }
}
