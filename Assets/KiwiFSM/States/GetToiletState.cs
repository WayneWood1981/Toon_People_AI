using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GetToiletState : AIState
{

    AIStateId AIState.GetId()
    {
        return AIStateId.GETTOILET;
    }

    void AIState.Enter(AIAgent agent)
    {

        if (agent.playerTransform == null || agent.playerTransform != null)
        {
            agent.playerTransform = GameObject.FindGameObjectWithTag("Toilet").transform;
        }
    }

    void AIState.Update(AIAgent agent)
    {
        if (!agent.enabled) { return; }
        Vector3 direction = (agent.playerTransform.position - agent.navMeshAgent.destination);
        direction.y = 0;
        
        if (!agent.navMeshAgent.hasPath)
        {
            agent.navMeshAgent.speed = 0.5f;
            agent.animator.SetFloat("Speed", agent.navMeshAgent.speed);
            
            agent.navMeshAgent.SetDestination(agent.playerTransform.position);
            //agent.character.Move(agent.navMeshAgent.desiredVelocity, false, false);
        }

        


        if (agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
        {



            if (agent.navMeshAgent.remainingDistance > agent.navMeshAgent.stoppingDistance)
            {
                agent.navMeshAgent.speed = 0.8f;
                agent.animator.SetFloat("Speed", 0.5f);
                agent.navMeshAgent.SetDestination(agent.playerTransform.position);
                //agent.character.Move(agent.navMeshAgent.desiredVelocity, false, false);
               
            }
            else
            {
                //agent.character.Move(Vector3.zero, false, false);
            }

        }




        float distance = Vector3.Distance(agent.navMeshAgent.transform.position, agent.playerTransform.position);


        if (distance <= 1.0f)
        {
            agent.playerTransform = null;
            agent.navMeshAgent.speed = 0f;
            agent.stateMachine.ChangeState(AIStateId.SITTINGDOWNONTOILET);
            //agent.character.Move(Vector3.zero, false, false);
            //agent.transform.Rotate(-direction);
        }
        


    }

    void AIState.Exit(AIAgent agent)
    {

    }

}
