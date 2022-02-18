using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public string dodgeButtonName = "Dodge";
    public bool dodge { get; private set; }

    // Update is called once per frame
    void Update()
    {
        dodge = Input.GetButtonDown(dodgeButtonName);
    }
}
