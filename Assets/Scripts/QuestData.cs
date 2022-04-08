using System.Collections;
using System.Collections.Generic;
public enum QuestType { Talk, Collect, Kill };
public class QuestData
{
    public int QuestID { get; }            // 퀘스트 ID
    public QuestType questType;
    public string QuestName;        // 퀘스트 이름
    public string QuestDescription; // 퀘스트 설명
    public int QuestProgressNum;    // 퀘스트 전체적인 진행도.

    public int qCurrentNum;         // 현재 퀘스트 진행숫자 (얼마나 했는지)
    public int qFinishNum;          // 퀘스트 달성치
    public int collectItemID;
    
    public bool isStartReady;       // 퀘스트 시작 조건이 충족되었는지.
    public bool isReceive;          // 퀘스트를 수락해 수행중인지.
    public bool isFinish;           // 퀘스트 목표가 달성 되었는지. (완료 가능한지)
    public bool isComplete;         // 퀘스트를 완료하고 끝이났는지.

    public int[] objectID;             // 상호작용하는 오브젝트ID(순서)

    public QuestData(int questID)
    {
        if(questID == 10000)
        {
            QuestID = questID;
            questType = QuestType.Talk;
            QuestName = "새 마을 방문";
            QuestDescription = "모험의 시작이다.\n마을의 소녀와 대화하라.";
            QuestProgressNum = 0;
            QuestProgressNum = 0;

            qCurrentNum = 0;
            qFinishNum = 0;

            isStartReady = true;
            isReceive = false;
            isFinish = true;
            isComplete = false;

            objectID = new int[] { 1000 };
        }

        if (questID == 20000)
        {
            QuestID = questID;
            questType = QuestType.Collect;
            QuestName = "파란 거북이 사냥";
            QuestDescription = "소녀의 부탁이다. \n파란 거북이를 사냥해 등껍질 3개를 모아오자!";
            QuestProgressNum = 0;

            qCurrentNum = 0;
            qFinishNum = 3;
            collectItemID = 21;

            isStartReady = false;
            isReceive = false;
            isFinish = false;
            isComplete = false;

            objectID = new int[] { 1000, 1000, 1000 };
        }

        if (questID == 30000)
        {
            QuestID = questID;
            questType = QuestType.Kill;
            QuestName = "공주 구출하기";
            QuestDescription = "마을의 위기상황이다 \n 보스 드래곤을 처치하고 마을의 공주룰 구해내라!";
            QuestProgressNum = 0;

            qCurrentNum = 0;
            qFinishNum = 1;

            isStartReady = false;
            isReceive = false;
            isFinish = false;
            isComplete = false;

            objectID = new int[] { 1000, 1000, 3000 };
        }

        if (questID == 50000)
        {
            QuestID = questID;
            QuestName = "테스트 퀘스트";
            QuestDescription = "퀘스트 시스템 테스트 중입니다.";
            QuestProgressNum = 0;

            qCurrentNum = 0;
            qFinishNum = 0;
            isStartReady = true;
            isReceive = false;
            isFinish = true;
            isComplete = false;

            objectID = new int[] { 2000 };
        }
    }

}
