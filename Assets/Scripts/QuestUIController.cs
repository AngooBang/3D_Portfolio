using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIController : MonoBehaviour
{
    public Text QuestTitle;
    public Text QuestDescription;

    private QuestManager questManager;

    private void Awake()
    {
        questManager = GetComponent<QuestManager>();
    }

    public void SetQuestUIText()
    {
        if(questManager.ActiveQuestID == 0)
        {
            QuestTitle.text = "";
            QuestDescription.text = "";
            return;
        }
        QuestTitle.text = questManager.questList[questManager.ActiveQuestID].QuestName;
        if (questManager.questList[questManager.ActiveQuestID].questType == QuestType.Collect)
        {
            QuestDescription.text = questManager.questList[questManager.ActiveQuestID].QuestDescription + string.Format(" ({0} / {1})",
                questManager.questList[questManager.ActiveQuestID].qCurrentNum, questManager.questList[questManager.ActiveQuestID].qFinishNum);

        }
        else
        {
            QuestDescription.text = questManager.questList[questManager.ActiveQuestID].QuestDescription;
        }
    }

}
