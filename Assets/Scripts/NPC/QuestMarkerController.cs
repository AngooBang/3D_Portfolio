using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMarkerController : MonoBehaviour
{
    public GameObject ExclamationObject;
    public GameObject NonColorQuestionObject;
    public GameObject CompleteQuestionObject;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            if(child.gameObject.CompareTag("QuestMarkers"))
            {
                GameObject questMarkers = child.gameObject;
                ExclamationObject = questMarkers.transform.GetChild(0).gameObject;
                NonColorQuestionObject = questMarkers.transform.GetChild(1).gameObject;
                CompleteQuestionObject = questMarkers.transform.GetChild(2).gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Keypad0))
        //{
        //    ChangeMarker(0);
        //}
        //if (Input.GetKeyDown(KeyCode.Keypad1))
        //{
        //    ChangeMarker(1);
        //}
        //if (Input.GetKeyDown(KeyCode.Keypad2))
        //{
        //    ChangeMarker(2);
        //}
        //if (Input.GetKeyDown(KeyCode.Keypad3))
        //{
        //    ChangeMarker(3);
        //}
    }

    public void ChangeMarker(int value)
    {
        // value �� 0�̶�� ��Ŀ ��� ����, 1�̶�� ����ǥ, 2��� ȸ������ǥ, 3�̶�� �ϷṰ��ǥ
        if(value == 0)
        {
            ExclamationObject.SetActive(false);
            NonColorQuestionObject.SetActive(false);
            CompleteQuestionObject.SetActive(false);
        }
        if(value == 1)
        {
            ExclamationObject.SetActive(true);
            NonColorQuestionObject.SetActive(false);
            CompleteQuestionObject.SetActive(false);
        }
        if (value == 2)
        {
            ExclamationObject.SetActive(false);
            NonColorQuestionObject.SetActive(true);
            CompleteQuestionObject.SetActive(false);
        }
        if (value == 3)
        {
            ExclamationObject.SetActive(false);
            NonColorQuestionObject.SetActive(false);
            CompleteQuestionObject.SetActive(true);
        }
    }
}
