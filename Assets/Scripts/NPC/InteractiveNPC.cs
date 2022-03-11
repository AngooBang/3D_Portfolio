using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveNPC : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject player;

    private bool isRangeIn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isRangeIn)
        {
            if (Input.GetButtonDown("Interact"))
            {
                player.GetComponent<PlayerUIController>().HideInteractiveImg();
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
