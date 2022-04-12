using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowShop : MonoBehaviour
{
    public bool isReady = false;
    public bool isShow;
    public GameObject ShopUIObject;

    private InteractiveNPC interactiveNPC;
    // Start is called before the first frame update
    void Start()
    {
        interactiveNPC = GetComponent<InteractiveNPC>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isReady == false)
        {
            if(interactiveNPC.isInteracting == true)
            {
                isReady = true;
            }
        }
        if(interactiveNPC.isInteracting == false)
        {
            if(isReady == true)
            {
                isShow = true;
                ShopUIObject.SetActive(true);
                isReady = false;
            }
        }
    }

    public void CloseShop()
    {
        isShow = false;
    }
    
}
