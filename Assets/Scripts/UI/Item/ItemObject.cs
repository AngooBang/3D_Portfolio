using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour
{
    public ItemData item;                                       //Item 
    private Text text;                                      //text for the itemValue
    private Image image; 

    void Start()
    {
        image = transform.GetChild(0).GetComponent<Image>();
        image.sprite = item.itemIcon;                                                       //set the sprite of the Item 
        text = transform.GetChild(1).GetComponent<Text>();                                  //get the text(itemValue GameObject) of the item
    }
    void Update()
    {
        if(item.itemType == ItemType.Consumable || item.itemType == ItemType.Quest)
        {
            text.text = "" + item.itemValue;                     //sets the itemValue
        }
        else
        {
            text.text = "";
        }
        image.sprite = item.itemIcon;
        //GetComponent<ConsumeItem>().item = item;
    }

}
