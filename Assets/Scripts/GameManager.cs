using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerUI;
    public GameObject talkPanel;
    public Text talkText;
    public GameObject interactionObject;
    public bool isAction;

    public void ActionWithObject(GameObject interactObj)
    {
        if(isAction)
        {
            isAction = false;
        }
        else
        {
            isAction = true;
            interactionObject = interactObj;
            talkText.text = "�̰��� �̸��� " + interactionObject.name + "�̶�� �Ѵ�.";
        }
        playerUI.SetActive(!isAction);
        talkPanel.SetActive(isAction);
    }
}
