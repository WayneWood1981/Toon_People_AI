using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GetPhoneState : AIState
{

    
    AIStateId AIState.GetId()
    {
        return AIStateId.GETPHONE;
        
    }

    void AIState.Enter(AIAgent agent)
    {
        
        if (agent.playerTransform == null || agent.playerTransform != null)
        {
            agent.playerTransform = GameObject.FindGameObjectWithTag("Phone").transform;
        }
        
    }

    void AIState.Update(AIAgent agent)
    {
        if (!agent.enabled) { return; }

        
        if (!agent.navMeshAgent.hasPath)
        {
            agent.navMeshAgent.speed = 0.5f;
            //agent.navMeshAgent.destination = agent.phone.transform.position;
            agent.navMeshAgent.SetDestination(agent.phoneToPickUp.transform.position);
            agent.character.Move(agent.navMeshAgent.desiredVelocity, false, false);
        }

        
            Vector3 direction = (agent.phoneToPickUp.transform.position - agent.navMeshAgent.destination);
            direction.y = 0;

        if (agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
        {


            
            //agent.navMeshAgent.SetDestination(agent.navMeshAgent.destination);

            if (agent.navMeshAgent.remainingDistance > agent.navMeshAgent.stoppingDistance)
              {
                agent.navMeshAgent.speed = 0.5f;
                agent.navMeshAgent.SetDestination(agent.phoneToPickUp.transform.position);
                agent.character.Move(agent.navMeshAgent.desiredVelocity, false, false);
              }
              else
              {
                  agent.character.Move(Vector3.zero, false, false);
              }

        }




        float distance = Vector3.Distance(agent.navMeshAgent.transform.position, agent.phoneToPickUp.transform.position);
        

        if (distance <= 1.0f)
        {
            agent.playerTransform = null;
            agent.navMeshAgent.speed = 0f;
            agent.stateMachine.ChangeState(AIStateId.ONPHONE);
            agent.character.Move(Vector3.zero, false, false);

        }


}

    void AIState.Exit(AIAgent agent)
    {
        
    }

  
}
