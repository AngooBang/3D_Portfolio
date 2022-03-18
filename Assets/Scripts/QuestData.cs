using System.Collections;
using System.Collections.Generic;

public class QuestData
{
    public int QuestID { get; }            // ����Ʈ ID
    public string QuestName;        // ����Ʈ �̸�
    public string QuestDescription; // ����Ʈ ����
    public int QuestProgressNum;    // ����Ʈ ��ü���� ���൵.

    public int qCurrentNum;         // ���� ����Ʈ ������� (�󸶳� �ߴ���)
    public int qFinishNum;          // ����Ʈ �޼�ġ

    
    public bool isStartReady;       // ����Ʈ ���� ������ �����Ǿ�����.
    public bool isReceive;          // ����Ʈ�� ������ ����������.
    public bool isFinish;           // ����Ʈ ��ǥ�� �޼� �Ǿ�����. (�Ϸ� ��������)
    public bool isComplete;         // ����Ʈ�� �Ϸ��ϰ� ���̳�����.

    public int[] objectID;             // ��ȣ�ۿ��ϴ� ������ƮID(����)

    public QuestData(int questID)
    {
        if(questID == 10)
        {
            QuestID = questID;
            QuestName = "�� ���� �湮";
            QuestDescription = "������ �����̴�. ������ �ҳ࿡�� �̵��� ����Ʈ�� �����϶�.";
            QuestProgressNum = 0;

            qCurrentNum = 0;
            qFinishNum = 0;

            isStartReady = true;
            isReceive = false;
            isFinish = true;
            isComplete = false;

            objectID = new int[] { 1000 };
        }

        if(questID == 50)
        {
            QuestID = 50;
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

    public void ReceiveQuest()
    {
        isReceive = true;
    }
}
