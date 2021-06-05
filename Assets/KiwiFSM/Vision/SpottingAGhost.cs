using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpottingAGhost : MonoBehaviour
{

    AIAgent agent;
    DecisionMaker decisionMaker;

    private void Start()
    {
        agent = GetComponentInParent<AIAgent>();
        decisionMaker = GetComponentInParent<DecisionMaker>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Interfered")
        {
            Debug.Log("Seen Ghost");
            if (agent.hasPhoneInHand == true)
            {
                agent.newPhone.transform.parent = null;
                agent.animator.SetBool("Calling", false);
                agent.animator.SetBool("FlickThroughPhone", false);
                agent.animator.SetBool("SittingDown", false);
                agent.newPhone.GetComponent<Rigidbody>().detectCollisions = true;
                agent.newPhone.GetComponent<Rigidbody>().isKinematic = false;
            }
            agent.playerTransform = other.transform;
            agent.stateMachine.ChangeState(AIStateId.ALERTED);
        }
        Debug.Log(other.transform.tag);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Interfered")
        {
            agent.animator.SetTrigger("AlertOver");
            agent.stateMachine.ChangeState(AIStateId.IDLE);
            Invoke("MakeANewDecision", 6);
            
            
        }
    }

    void MakeANewDecision()
    {
        decisionMaker.MakeADecision();
    }
}
