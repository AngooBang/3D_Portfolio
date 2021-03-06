using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class LocoMotionSimpleAgent : MonoBehaviour
{
    public bool shouldMove;

    private PlayerDodge playerDodge;
    Animator anim;
    NavMeshAgent agent;
    Vector2 smoothDeltaPosition = Vector2.zero;
    Vector2 velocity = Vector2.zero;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        // Don??t update position automatically
        agent.updatePosition = false;
    }

    void Update()
    {
        if (playerDodge.IsDodge) return;
        Vector3 worldDeltaPosition = agent.nextPosition - transform.position;

        // Map 'worldDeltaPosition' to local space
        float dx = Vector3.Dot(transform.right, worldDeltaPosition);
        float dy = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dx, dy);

        // Low-pass filter the deltaMove
        float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
        smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

        // Update velocity if time advances
        if (Time.deltaTime > 1e-5f)
            velocity = smoothDeltaPosition / Time.deltaTime;

        shouldMove = velocity.magnitude > 0.5f && agent.remainingDistance > agent.radius;

        // Update animation parameters
        anim.SetFloat("MoveBlend", shouldMove ? 1f : 0f, 0.1f, Time.deltaTime);
        //anim.SetFloat("velx", velocity.x);
        //anim.SetFloat("vely", velocity.y);

        //transform.LookAt(agent.steeringTarget + transform.forward);
        LookAt lookAt = GetComponent<LookAt>();
        if (lookAt)
            lookAt.lookAtTargetPosition = agent.steeringTarget + transform.forward;

        // Pull character towards agent
        if (worldDeltaPosition.magnitude > agent.radius)
            transform.position = agent.nextPosition - 0.9f * worldDeltaPosition;

        //// Pull agent towards character
        //if (worldDeltaPosition.magnitude > agent.radius)
        //    agent.nextPosition = transform.position + 0.9f * worldDeltaPosition;
    }

    void OnAnimatorMove()
    {
        // Update position to agent position
        Vector3 position = anim.rootPosition;
        position.y = agent.nextPosition.y;
        transform.position = position;
    }
}
