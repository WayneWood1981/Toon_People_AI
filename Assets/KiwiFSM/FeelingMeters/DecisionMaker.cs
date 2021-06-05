using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionMaker : MonoBehaviour
{

    public bool decisionCompleted;
    public int randomNumber;
    public int lastNumber;

    public string[] decisions;

    

    // Start is called before the first frame update
    void Start()
    {
        Invoke("MakeADecision", 2);

        decisions = new string[] { "GetPhone", "Sleep", "Watch Telly", "Toilet Break", "Call Friend", "Eat" }; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeADecision()
    {
        lastNumber = randomNumber;
        randomNumber = Random.Range(0, decisions.Length);
        //lastNumber = 1;
        //randomNumber = 3;
        if(randomNumber == lastNumber)
        {
            MakeADecision();
        }
        else
        {
            if (randomNumber == 0)
            {
                Debug.Log("GetPhone");
                GetComponent<AIAgent>().stateMachine.ChangeState(AIStateId.GETPHONE);
                
            }
            else if (randomNumber == 1)
            {
                Debug.Log("Sleep");
                GetComponent<AIAgent>().stateMachine.ChangeState(AIStateId.GETTOBED);

            }
            else if (randomNumber == 2)
            {
                Debug.Log("Watch Telly");
                GetComponent<AIAgent>().stateMachine.ChangeState(AIStateId.GETCHAIR);


            }
            else if (randomNumber == 3)
            {
                Debug.Log("Toilet Break");
                GetComponent<AIAgent>().stateMachine.ChangeState(AIStateId.GETTOILET);

            }
            else if (randomNumber == 4)
            {
                Debug.Log("Call Friend");
                GetComponent<AIAgent>().stateMachine.ChangeState(AIStateId.GETPHONETOCALL);

            }
            else if (randomNumber == 5)
            {
                Debug.Log("Eat");
                GetComponent<AIAgent>().stateMachine.ChangeState(AIStateId.GETFRIDGE);

            }
        }

        
    }
}
