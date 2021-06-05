using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFridgeState : AIState
{
    float timer = 0.0f;
    bool isiFinishedEating;

    AIStateId AIState.GetId()
    {
        return AIStateId.OPENFRIDGE;
    }

    void AIState.Enter(AIAgent agent)
    {
        agent.navMeshAgent.speed = 0;

        agent.playerTransform = GameObject.FindGameObjectWithTag("Fridge").transform;
        agent.transform.position = agent.playerTransform.position;
        if (agent.navMeshAgent.desiredVelocity != Vector3.zero)
        {
            agent.transform.rotation = agent.playerTransform.rotation;
        }

        timer = agent.randomTimeDoingDecision();
    }

    void AIState.Update(AIAgent agent)
    {
        timer -= Time.deltaTime;
        agent.navMeshAgent.speed = 0.0f;
        if (timer <= 0.0)
        {
            timer = 0.0f;
            isiFinishedEating = true;

        }

        if (isiFinishedEating)
        {
            agent.ClosingFridge();
            isiFinishedEating = false;
        }
    }

    void AIState.Exit(AIAgent agent)
    {
        
    }

    

    
}
