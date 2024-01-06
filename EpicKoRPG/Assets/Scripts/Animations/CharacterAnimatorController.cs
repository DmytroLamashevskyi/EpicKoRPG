using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent( typeof(NavMeshAgent))] 
public class CharacterAnimatorController : MonoBehaviour
{
    [SerializeField] private float smoothMagnitude;

    private static int ANIMATOR_PARAM_MOVE = Animator.StringToHash("move");
    private static int ANIMATOR_PARAM_LOCOMOTION = Animator.StringToHash("locomotion");
    private static int ANIMATOR_PARAM_ATACK = Animator.StringToHash("atack");

    private Animator animator;
    private NavMeshAgent agent;

    private Vector2 velocity;
    private Vector2 smoothDeltaPosition;

    // Start is called before the first frame update
    void Awake()
    { 
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();

        animator.applyRootMotion = true;
        agent.updatePosition = false;
        agent.updateRotation = true;
    }

    private void OnAnimatorMove()
    {
        Vector3 rootPosition = animator.rootPosition;
        rootPosition.y = agent.nextPosition.y;
        transform.position = rootPosition;
        agent.nextPosition = rootPosition;
    }
    private void Update()
    { 
        SynchronizeAnimatorAndAgent();
    }

    private void SynchronizeAnimatorAndAgent()
    {
        Vector3 worldDeltaPosition = agent.nextPosition-transform.position;
        worldDeltaPosition.y = 0;

        float dx = Vector3.Dot(transform.right, worldDeltaPosition);
        float dy = Vector3.Dot(transform.forward, worldDeltaPosition);

        Vector2 deltaPosition = new Vector2(dx, dy);

        float smooth = Mathf.Min(1,Time.deltaTime/0.1f);

        smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

        velocity = smoothDeltaPosition/ Time.deltaTime;
        if(agent.remainingDistance < agent.stoppingDistance)
        {
            velocity = Vector2.Lerp(Vector2.zero, velocity, agent.remainingDistance / agent.stoppingDistance);
        }

        bool shouldMove = velocity.magnitude > smoothMagnitude
            && agent.remainingDistance > agent.stoppingDistance;

        animator.SetBool(ANIMATOR_PARAM_MOVE, shouldMove);
        animator.SetFloat(ANIMATOR_PARAM_LOCOMOTION, velocity.magnitude);

        float deltaMagnitude = worldDeltaPosition.magnitude;
        if(deltaMagnitude > agent.radius / 2f)
        {
            transform.position = Vector3.Lerp(
                animator.rootPosition,
                agent.nextPosition,
                smooth
            );
        }
    }


    internal void Atack()
    {
        animator.SetTrigger(ANIMATOR_PARAM_ATACK);
    }
}
