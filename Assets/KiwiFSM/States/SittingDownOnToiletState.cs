using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingDownOnToiletState : AIState
{
    float timer = 0.0f;
    bool isSittingDown;

    AIStateId AIState.GetId()
    {
        return AIStateId.SITTINGDOWNONTOILET;
    }

    void AIState.Enter(AIAgent agent)
    {
        agent.playerTransform = GameObject.FindGameObjectWithTag("Toilet").transform;
        agent.transform.position = agent.playerTransform.position;
        if (agent.navMeshAgent.desiredVelocity != Vector3.zero)
        {
            agent.transform.rotation = agent.playerTransform.rotation;
        }
        
        agent.animator.SetBool("SittingDown", true);
        timer = agent.randomTimeDoingDecision();
        
    }

    void AIState.Update(AIAgent agent)
    {
        timer -= Time.deltaTime;
        agent.navMeshAgent.speed = 0.0f;
        agent.faceAnimations.playFaceAnimation("disgust");
        if (timer <= 0.0)
        {
            timer = 0.0f;
            isSittingDown = true;

        }

        if (isSittingDown)
        {
            agent.GettingUpState();
            isSittingDown = false;
        }
    }

    void AIState.Exit(AIAgent agent)
    {
        agent.faceAnimations.restoreFaceAnimation("disgust");
    }

    

    
}
