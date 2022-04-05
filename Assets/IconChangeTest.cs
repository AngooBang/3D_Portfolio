using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconChangeTest : MonoBehaviour
{
    ItemData itemData;
    // Start is called before the first frame update
    void Start()
    {
        itemData = GetComponent<ItemData>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            //itemData.DropItemPrefab = Resources.Load<GameObject>("Prefabs/ItemChest");
        }
    }
}
