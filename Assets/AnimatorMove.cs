using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimatorMove : MonoBehaviour
{

    public Animator anim;
    public NavMeshAgent agent;
    Vector2 smoothDeltaPosition = Vector2.zero;
    Vector2 velocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.deltaTime > 1e-5f)
        {
            velocity = smoothDeltaPosition / Time.deltaTime;
        }
        //anim.SetFloat("Speed", agent.velocity.y);
        //anim.SetFloat("Speed", agent.velocity.x);
        //anim.SetFloat("Speed", agent.velocity.z);
    }

    void OnAnimatorMove()
    {
        this.transform.position = agent.nextPosition;
    }
}
