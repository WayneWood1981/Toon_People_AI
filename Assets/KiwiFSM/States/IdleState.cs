using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : AIState
{

    AIStateId AIState.GetId()
    {
        return AIStateId.IDLE;
    }

    void AIState.Enter(AIAgent agent)
    {
        agent.navMeshAgent.speed = 0.0f;
    }

    void AIState.Update(AIAgent agent)
    {
        if(agent.playerTransform != null)
        {
            Vector3 playerDirection = agent.playerTransform.position - agent.transform.position;
            if (playerDirection.magnitude > agent.config.maxSightDistance)
            {
                return;
            }

            Vector3 agentDirection = agent.transform.forward;

            playerDirection.Normalize();

            float dotProduct = Vector3.Dot(playerDirection, agentDirection);
            if (dotProduct > 0.0f)
            {
                agent.stateMachine.ChangeState(AIStateId.CHASEPLAYER);
            }
        }
        
    }

    void AIState.Exit(AIAgent agent)
    {
        
    }

    

    
}
