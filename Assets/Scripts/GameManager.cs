using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager;
    public GameObject playerUI;
    public GameObject HotBarUI;
    public GameObject talkPanel;
    public Text talkText;                       
    public GameObject interactionObject;
    public bool isAction;
    public int talkIndex = 0;              // 대화이벤트에서 내용이 여러번에 걸쳐 출력될때 (string[])을 참조하기 위해 사용하는 카운트

    public Camera UICamera;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public void ActionWithObject(GameObject interactObj)
    {

        interactionObject = interactObj;
        ObjectData objData = interactionObject.GetComponent<ObjectData>();
        TalkWithObject(objData.ObjectID);

        UIInteractSetting();
        CameraInteractSetting();
    }

    private void TalkWithObject(int objectID)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(objectID);
        Debug.Log(questTalkIndex + ": 현재 퀘스트토크 인덱스, " + talkIndex + ": 토크 인덱스");
        string talkData = talkManager.GetTalk(objectID + questTalkIndex, talkIndex);


        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            // npc에 퀘스트대화가 있을때
            if(questTalkIndex != 0)
            {
                if (questTalkIndex != 10011 && questTalkIndex != 10021 && questTalkIndex != 10031)
                {
                    questManager.NextQuestProcess(questTalkIndex - (questTalkIndex % 10));
                }
                questManager.QuestFinishAndChainQuest(questTalkIndex - (questTalkIndex % 10));
            }
            return;
        }

        talkText.text = talkData;

        isAction = true;
        talkIndex++;
    }
    private void UIInteractSetting()
    {
        playerUI.SetActive(!isAction);
        HotBarUI.SetActive(!isAction);
        talkPanel.SetActive(isAction);
    }
    private void CameraInteractSetting()
    {
        mainCamera.enabled = !isAction;
        interactionObject.GetComponentInChildren<Camera>().enabled = isAction;
        UICamera.enabled = false;
        UICamera.enabled = true;
    }
}
