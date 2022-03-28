using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveNPC : MonoBehaviour
{
    public GameManager gameManager;
    public QuestManager questManager;
    public GameObject player;

    public bool isQuestStart = false;

    private PlayerInput playerInput;
    private bool isRangeIn;
    private ObjectData objectData;

    
    // Start is called before the first frame update
    void Start()
    {
        objectData = GetComponent<ObjectData>();
        playerInput = player.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isRangeIn)
        {
            if (playerInput.interaction)
            {
                player.GetComponent<PlayerUIController>().HideInteractiveImg();
                if(isQuestStart)
                {
                    int tempQuestID = questManager.GetQuestStartIndex(objectData.ObjectID);
                    if (tempQuestID != 0)
                    {
                        questManager.ReceiveQuest(tempQuestID);
                        isQuestStart = false;
                    }
                }
                gameManager.ActionWithObject(gameObject);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerUIController>().ShowInteractiveImg();
            isRangeIn = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerUIController>().HideInteractiveImg();
            isRangeIn = false;
        }
    }
}
