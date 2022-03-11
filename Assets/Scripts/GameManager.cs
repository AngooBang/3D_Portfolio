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
            talkText.text = "이것의 이름은 " + interactionObject.name + "이라고 한다.";
        }
        playerUI.SetActive(!isAction);
        talkPanel.SetActive(isAction);
    }
}
