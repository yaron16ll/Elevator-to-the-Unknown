using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PeasantMan3 : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;
    public GameObject target;
    public GameObject point1;
    public GameObject point2;
    bool goes_to_pt1 = true;
    LineRenderer lines;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();//connect to property in unity
        agent = GetComponent<NavMeshAgent>();
        lines = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        
            animator.SetInteger("State", 1);
            // compute the path to the target and starts moving NPC towards the target
            agent.SetDestination(target.transform.position);
            if (agent.isStopped)
            {
                agent.isStopped = false;
            }
        
        if (distance < 2)
        {
            animator.SetInteger("State", 0);
            agent.isStopped = true;
        }
        if(distance < 3)//goes constantly from pt1 to pt2 and back
        {
            if (goes_to_pt1)
            {
                target.transform.position = point2.transform.position;
                goes_to_pt1 = false;
                agent.SetDestination(target.transform.position);//compute new path
            }
            else
            {
                target.transform.position = point1.transform.position;
                goes_to_pt1 = true;
                agent.SetDestination(target.transform.position);
            }
        }
        lines.positionCount =  agent.path.corners.Length;
        lines.SetPositions(agent.path.corners);
    }
}
