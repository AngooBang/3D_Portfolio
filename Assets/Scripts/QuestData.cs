using System.Collections;
using System.Collections.Generic;
public enum QuestType { Talk, Collect, Kill };
public class QuestData
{
    public int QuestID { get; }            // ����Ʈ ID
    public QuestType questType;
    public string QuestName;        // ����Ʈ �̸�
    public string QuestDescription; // ����Ʈ ����
    public int QuestProgressNum;    // ����Ʈ ��ü���� ���൵.

    public int qCurrentNum;         // ���� ����Ʈ ������� (�󸶳� �ߴ���)
    public int qFinishNum;          // ����Ʈ �޼�ġ
    public int collectItemID;
    
    public bool isStartReady;       // ����Ʈ ���� ������ �����Ǿ�����.
    public bool isReceive;          // ����Ʈ�� ������ ����������.
    public bool isFinish;           // ����Ʈ ��ǥ�� �޼� �Ǿ�����. (�Ϸ� ��������)
    public bool isComplete;         // ����Ʈ�� �Ϸ��ϰ� ���̳�����.

    public int[] objectID;             // ��ȣ�ۿ��ϴ� ������ƮID(����)

    public QuestData(int questID)
    {
        if(questID == 10000)
        {
            QuestID = questID;
            questType = QuestType.Talk;
            QuestName = "�� ���� �湮";
            QuestDescription = "������ �����̴�.\n������ �ҳ�� ��ȭ�϶�.";
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
            QuestName = "�Ķ� �ź��� ���";
            QuestDescription = "�ҳ��� ��Ź�̴�. \n�Ķ� �ź��̸� ����� ��� 3���� ��ƿ���!";
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
            QuestName = "���� �����ϱ�";
            QuestDescription = "������ �����Ȳ�̴� \n ���� �巡���� óġ�ϰ� ������ ���ַ� ���س���!";
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
            QuestName = "�׽�Ʈ ����Ʈ";
            QuestDescription = "����Ʈ �ý��� �׽�Ʈ ���Դϴ�.";
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
