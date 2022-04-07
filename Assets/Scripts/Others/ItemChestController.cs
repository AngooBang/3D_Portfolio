using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemChestController : MonoBehaviour
{
    [SerializeField]
    private Animation animation;
    [SerializeField]
    private ChestEffectCycler chestEffectCycler;

    public InventorySystem inventorySystem;

    public ItemData itemData;
    public Canvas HUDCanvas;
    public GameObject NameTextPrefab;

    public GameObject player;

    public TextMeshProUGUI NameText;
    

    private void Awake()
    {
        animation = GetComponentInChildren<Animation>();
        chestEffectCycler = GetComponentInChildren<ChestEffectCycler>();
        HUDCanvas = GameObject.FindGameObjectWithTag("HUDCanvas").GetComponent<Canvas>();

        NameTextPrefab = Instantiate(NameTextPrefab, HUDCanvas.transform);
        NameTextPrefab.GetComponent<HUDObject>().target = transform;
        NameText = NameTextPrefab.GetComponentInChildren<TextMeshProUGUI>();


        player = GameObject.FindGameObjectWithTag("Player");

        inventorySystem = GameObject.FindGameObjectWithTag("MainInventory").GetComponent<InventorySystem>();
        

    }

    private void OnDestroy()
    {
        Destroy(NameTextPrefab);
    }

    public void SetItemData()
    {
        itemData = GetComponentInChildren<ItemData>();
        NameText.text = itemData.itemName;
    }
    private void Update()
    {
        Vector3 distVec = player.transform.position - transform.position;
        
        if(distVec.magnitude < 4.0f)
        {
            NameTextPrefab.SetActive(true);
            if (Input.GetKeyDown(KeyCode.G))
            {
                PickUpItem();
            }
        }
        else
        {
            NameTextPrefab.SetActive(false);
        }

    }
    void PickUpItem()
    {
        animation.Play();
        chestEffectCycler.PlayEffect();
        GameObject itemObject = transform.GetChild(2).gameObject;
        inventorySystem.AddItem(itemObject);

        Destroy(gameObject, 1.5f);
    }
}
