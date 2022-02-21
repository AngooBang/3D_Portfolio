using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNormalAttackState : StateMachineBehaviour
{
    private NavMeshAgent playerAgent;
    private Camera camera;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        camera = Camera.main;
        playerAgent = animator.GetComponent<NavMeshAgent>();

        playerAgent.ResetPath();

        RaycastHit hit;
        Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit);

        animator.transform.LookAt(hit.point);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
