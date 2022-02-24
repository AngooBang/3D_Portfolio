using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public bool dodge { get; private set; }
    public bool normalAttack { get; private set; }

    private string dodgeButtonName = "Dodge";
    private string normalAtkButton = "Fire2";
    // Update is called once per frame
    void Update()
    {
        dodge = Input.GetButtonDown(dodgeButtonName);
        normalAttack = Input.GetButtonDown(normalAtkButton);

    }
}
