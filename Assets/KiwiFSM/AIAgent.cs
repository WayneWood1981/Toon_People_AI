using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class AIAgent : MonoBehaviour
{
    //Add anything you need to grab hold off of the NPC from here To Access it on personal StateScript i.e ChasePlayer
    public AIStateMachine stateMachine;
    public Animator animator;
    public DecisionMaker decisionMaker;
    public FaceAnimations faceAnimations;
    public AIStateId initialState;
    public AIStateId currentState;
    public NavMeshAgent navMeshAgent;
    public AIAgentConfig config;
    public Transform playerTransform;
    public string target;
    public GameObject phoneToPickUp;
    public GameObject newPhone;
    public Transform handForPhone;
    public bool hasReachedPhone;
    public ThirdPersonCharacter character;
    public int randomNumberForDoingDecision;

    // Start is called before the first frame update
    void Start()
    {
        decisionMaker = GetComponent<DecisionMaker>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        faceAnimations = GetComponent<FaceAnimations>();
        stateMachine = new AIStateMachine(this);
        stateMachine.RegisterState(new AIChasePlayer());
        stateMachine.RegisterState(new AIDeathState());
        stateMachine.RegisterState(new IdleState());
        stateMachine.RegisterState(new GetPhoneState());
        stateMachine.RegisterState(new OnPhoneState());
        stateMachine.RegisterState(new GetChairState());
        stateMachine.RegisterState(new SittingDownState());
        stateMachine.RegisterState(new GetFridgeState());
        stateMachine.RegisterState(new OpenFridgeState());
        stateMachine.RegisterState(new GetToiletState());
        stateMachine.RegisterState(new SittingDownOnToiletState());
        stateMachine.ChangeState(initialState);
        navMeshAgent.updateRotation = false;
        phoneToPickUp = GameObject.FindGameObjectWithTag("Phone");
        playerTransform = null;


    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();

        
        animator.SetFloat("Speed", navMeshAgent.speed);

        currentState = stateMachine.currentState;

    }

    public void PickUpPhone()
    {
        
            
        
        newPhone = Instantiate(phoneToPickUp, handForPhone.position, handForPhone.rotation, handForPhone);

        newPhone.GetComponent<Rigidbody>().detectCollisions = false;
        newPhone.GetComponent<Rigidbody>().isKinematic = true;

        phoneToPickUp.SetActive(false);
        animator.SetBool("FlickThroughPhone", true);


    }

    public void PutDownPhone()
    {
        newPhone.SetActive(false);
        phoneToPickUp.SetActive(true);
        animator.SetBool("FlickThroughPhone", false);
        stateMachine.ChangeState(AIStateId.IDLE);
        decisionMaker.MakeADecision();
        faceAnimations.restoreFaceAnimation("Happy");
    }

    public void GettingUpState()
    {
        animator.SetBool("SittingDown", false);
        stateMachine.ChangeState(AIStateId.IDLE);
        decisionMaker.MakeADecision();
        faceAnimations.restoreFaceAnimation("amazed");
        faceAnimations.restoreFaceAnimation("disgusted");
    }

    public void ClosingFridge()
    {
        
        stateMachine.ChangeState(AIStateId.IDLE);
        decisionMaker.MakeADecision();

    }

    public float randomTimeDoingDecision()
    {
        randomNumberForDoingDecision = Random.Range(5, 15);

        return randomNumberForDoingDecision;
    }
}
