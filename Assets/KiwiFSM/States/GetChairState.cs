using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GetChairState : AIState
{

    AIStateId AIState.GetId()
    {
        return AIStateId.GETCHAIR;
    }

    void AIState.Enter(AIAgent agent)
    {

        if (agent.playerTransform == null || agent.playerTransform != null)
        {
            agent.playerTransform = GameObject.FindGameObjectWithTag("Chair").transform;
        }
    }

    void AIState.Update(AIAgent agent)
    {
        if (!agent.enabled) { return; }


        if (!agent.navMeshAgent.hasPath)
        {
            agent.navMeshAgent.speed = 0.5f;
            
            agent.navMeshAgent.SetDestination(agent.playerTransform.position);
            agent.character.Move(agent.navMeshAgent.desiredVelocity, false, false);
        }

        Vector3 direction = (agent.playerTransform.position - agent.navMeshAgent.destination);
        direction.y = 0;


        if (agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
        {



            if (agent.navMeshAgent.remainingDistance > agent.navMeshAgent.stoppingDistance)
            {
                agent.navMeshAgent.speed = 0.5f;
                agent.navMeshAgent.SetDestination(agent.playerTransform.position);
                agent.character.Move(agent.navMeshAgent.desiredVelocity, false, false);
            }
            else
            {
                agent.character.Move(Vector3.zero, false, false);
            }

        }




        float distance = Vector3.Distance(agent.navMeshAgent.transform.position, agent.playerTransform.position);


        if (distance <= 1.0f)
        {
            agent.playerTransform = null;
            agent.navMeshAgent.speed = 0f;
            agent.stateMachine.ChangeState(AIStateId.SITTINGDOWN);
            agent.character.Move(Vector3.zero, false, false);
            agent.transform.Rotate(-direction);
        }
        


    }

    void AIState.Exit(AIAgent agent)
    {

    }

}
