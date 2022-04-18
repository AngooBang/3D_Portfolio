using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerDodgeState : StateMachineBehaviour
{
    private NavMeshAgent playerAgent;
    private Rigidbody playerRigid;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerAgent = animator.GetComponent<NavMeshAgent>();
        playerRigid = animator.GetComponent<Rigidbody>();
        playerAgent.ResetPath();

        //playerAgent.updatePosition = false;
        //playerAgent.speed *= 2f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log("¥Â¡ˆ¡ﬂ¿”");
        //playerAgent.ResetPath();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        //playerAgent.updatePosition = true;
        //playerAgent.speed *= 0.5f;
        //playerAgent.ResetPath();
        //playerRigid.velocity. = Vector3.Lerp(playerRigid.velocity , Vector3.zero, 0.2f);
    }

}
