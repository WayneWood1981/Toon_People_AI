using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calling : AIState
{
    float timer = 0.0f;
    bool isPuttingPhoneDown;

    AIStateId AIState.GetId()
    {
        return AIStateId.CALLING;
    }


    void AIState.Enter(AIAgent agent)
    {
        agent.PickUpPhoneToCall();
        timer = agent.randomTimeDoingDecision();
        agent.faceAnimations.playFaceAnimation("happy");
    }

    void AIState.Update(AIAgent agent)
    {
        timer -= Time.deltaTime;
        agent.navMeshAgent.speed = 0.0f;
        if (timer <= 0.0)
        {
            timer = 0.0f;
            isPuttingPhoneDown = true;

        }

        if (isPuttingPhoneDown)
        {
            agent.PutDownPhone();
            isPuttingPhoneDown = false;
        }
    }


    void AIState.Exit(AIAgent agent)
    {
        agent.faceAnimations.restoreFaceAnimation("happy");
    }

    

    
}
