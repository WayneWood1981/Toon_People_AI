using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDeathState : AIState
{

    AIStateId AIState.GetId()
    {
        return AIStateId.DEATH;
    }

    void AIState.Enter(AIAgent agent)
    {
        throw new System.NotImplementedException();
    }

    void AIState.Update(AIAgent agent)
    {
        throw new System.NotImplementedException();
    }

    void AIState.Exit(AIAgent agent)
    {
        throw new System.NotImplementedException();
    }

    

    
}
