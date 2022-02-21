using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public string dodgeButtonName = "Dodge";
    public string normalAtkButton = "Fire2";
    public bool dodge { get; private set; }
    public bool normalAttack { get; private set; }

    // Update is called once per frame
    void Update()
    {
        dodge = Input.GetButtonDown(dodgeButtonName);
        normalAttack = Input.GetButtonDown(normalAtkButton);

    }
}
