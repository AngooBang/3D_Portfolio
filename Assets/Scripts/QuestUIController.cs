using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIController : MonoBehaviour
{
    public Text QuestTitle;
    public Text QuestDescription;
    public int ActiveQuestID;

    private QuestManager questManager;

    private void Awake()
    {
        questManager = GetComponent<QuestManager>();
    }

    public void SetQuestUIText()
    {
        if(ActiveQuestID == 0)
        {
            QuestTitle.text = "";
            QuestDescription.text = "";
            return;
        }
        QuestTitle.text = questManager.questList[ActiveQuestID].QuestName;
        if (ActiveQuestID == 20)
        {
            QuestDescription.text = questManager.questList[ActiveQuestID].QuestDescription + string.Format(" ({0} / {1})",
                questManager.questList[ActiveQuestID].qCurrentNum, questManager.questList[ActiveQuestID].qFinishNum);

        }
        else
        {
            QuestDescription.text = questManager.questList[ActiveQuestID].QuestDescription;
        }
    }

}
