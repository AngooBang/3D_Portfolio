using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public bool dodge { get; private set; }
    public bool normalAttack { get; private set; }
    public bool move { get; private set; }
    public bool interaction { get; private set; }
    public bool inventory { get; private set; }
    public bool equipment { get; private set; }
    public bool skill { get; private set; }

    private string dodgeButtonName = "Dodge";
    private string normalAtkButton = "Fire1";
    private string moveButton = "Fire2";
    private string interactionButton = "Interact";
    private string inventoryButton = "Inventory";
    private string equipmentButton = "Equipment";
    private string skillButton = "Skill";

    private PlayerUIController playerUIController;

    private void Start()
    {
        playerUIController = GetComponent<PlayerUIController>();
    }

    // Update is called once per frame
    void Update()
    {
        // 인벤토리나 장비창 켜져있을경우
        if(playerUIController.isInventoryEnable == false && playerUIController.isEquipmentEnable == false && playerUIController.isSkillEnable == false)
        {
            dodge = Input.GetButtonDown(dodgeButtonName);
            normalAttack = Input.GetButton(normalAtkButton);
            move = Input.GetButton(moveButton);
            interaction = Input.GetButtonDown(interactionButton);
        }
        inventory = Input.GetButtonDown(inventoryButton);
        equipment = Input.GetButtonDown(equipmentButton);
        skill = Input.GetButtonDown(skillButton);
    }
}
