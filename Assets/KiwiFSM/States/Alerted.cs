using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alerted : AIState
{

    public AIStateId GetId()
    {
        return AIStateId.ALERTED;
    }

    public void Enter(AIAgent agent)
    {
        agent.animator.SetTrigger("Alerted");

    }

    public void Update(AIAgent agent)
    {
        agent.navMeshAgent.speed = 0.0f;
        
    }

    public void Exit(AIAgent agent)
    {
        
    }

    

    

    
}
