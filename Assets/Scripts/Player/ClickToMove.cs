using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ClickToMove : MonoBehaviour
{
    RaycastHit hitInfo = new RaycastHit();
    private NavMeshAgent agent;
    private PlayerInput playerInput;
    private PlayerAttack playerAttack;
    private PlayerDodge playerDodge;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerInput = GetComponent<PlayerInput>();
        playerAttack = GetComponent<PlayerAttack>();
        playerDodge = GetComponent<PlayerDodge>();
    }
    void Update()
    {
        if(playerAttack.IsAttack == false && playerDodge.IsDodge == false)
        {
            if (playerInput.move)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
                    agent.destination = hitInfo.point;
            }
        }
    }
}