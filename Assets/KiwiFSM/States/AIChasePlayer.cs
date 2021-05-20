using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIChasePlayer : AIState
{
    
    float timer = 0.0f;

    public AIStateId GetId()
    {
        return AIStateId.CHASEPLAYER;
    }



    public void Enter(AIAgent agent)
    {
        if (agent.playerTransform == null)
        {
            agent.playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    public void Update(AIAgent agent)
    {
        if (!agent.enabled) { return; }

        timer -= Time.deltaTime;
        if (!agent.navMeshAgent.hasPath)
        {
            agent.navMeshAgent.destination = agent.playerTransform.position;
        }

        if (timer < 0.0f)
        {
            Vector3 direction = (agent.playerTransform.position - agent.navMeshAgent.destination);
            direction.y = 0;
            if (direction.sqrMagnitude > agent.config.maxDistance * agent.config.maxDistance)
            {
                if (agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
                {
                    agent.navMeshAgent.destination = agent.playerTransform.position;
                }
            }
            timer = agent.config.maxTime;
        }
    }

    public void Exit(AIAgent agent)
    {
        
    }


    

    
}
