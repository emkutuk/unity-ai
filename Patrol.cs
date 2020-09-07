using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : NPCBaseSM
{
    GameObject[] waypoints;
    int currentWp;

    void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");  
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        currentWp = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (waypoints.Length == 0) return;

        if (Vector3.Distance(waypoints[currentWp].transform.position, NPC.transform.position) < accuracy)
            {
            currentWp++;
            if(currentWp >= waypoints.Length)
                {
                    currentWp = 0;
                }
            }

        agent.SetDestination(waypoints[currentWp].transform.position);
        // Rotate towards target
        //var direction = waypoints[currentWp].transform.position - NPC.transform.position;
        //NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
        //NPC.transform.Translate(0, 0, Time.deltaTime * speed);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
