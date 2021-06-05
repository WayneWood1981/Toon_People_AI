using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimatorMove : MonoBehaviour
{

    public Animator anim;
    public NavMeshAgent navMeshAgent;
    Vector2 smoothDeltaPosition = Vector2.zero;
    Vector2 velocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }



    private void FixedUpdate() // was OnAnimationMove() but this caused root motion problems
    {
        this.transform.position = navMeshAgent.nextPosition;

        if (Time.deltaTime > 1e-5f)
        {
            velocity = smoothDeltaPosition / Time.deltaTime;
            anim.SetFloat("Speed", navMeshAgent.speed);
        }
        
        
        if (navMeshAgent.desiredVelocity != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(navMeshAgent.desiredVelocity);


            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, navMeshAgent.angularSpeed * Time.deltaTime);
        }
    }
}
