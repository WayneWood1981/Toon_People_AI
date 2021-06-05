using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GetToBed : AIState
{

    AIStateId AIState.GetId()
    {
        return AIStateId.GETTOBED;
    }


    void AIState.Enter(AIAgent agent)
    {

        if (agent.playerTransform == null || agent.playerTransform != null)
        {
            agent.playerTransform = GameObject.FindGameObjectWithTag("Bed").transform;
        }
    }

    void AIState.Update(AIAgent agent)
    {
        if (!agent.enabled) { return; }


        if (!agent.navMeshAgent.hasPath)
        {
            agent.navMeshAgent.speed = 0.5f;

            agent.navMeshAgent.SetDestination(agent.playerTransform.position);
            
        }

        Vector3 direction = (agent.playerTransform.position - agent.navMeshAgent.destination);
        direction.y = 0;


        if (agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
        {
        if (agent.navMeshAgent.remainingDistance > agent.navMeshAgent.stoppingDistance)
            {
                agent.navMeshAgent.speed = 0.8f;
                agent.animator.SetFloat("Speed", 0.5f);
                agent.navMeshAgent.SetDestination(agent.playerTransform.position);
            }
        }

        float distance = Vector3.Distance(agent.navMeshAgent.transform.position, agent.playerTransform.position);

        if (distance <= 0.75f)
        {
            agent.playerTransform = null;
            agent.navMeshAgent.speed = 0f;
            agent.stateMachine.ChangeState(AIStateId.GOTOSLEEP);
            
        }



    }

    void AIState.Exit(AIAgent agent)
    {

    }




}
