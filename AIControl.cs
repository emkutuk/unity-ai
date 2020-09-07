using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour {

	GameObject[] goalLocations;
	UnityEngine.AI.NavMeshAgent agent;
	Animator anim;
	float speedMult;
	float detectionRadius = 20;
	float fleeRadius = 10;

	void ResetAgent()
	{
		speedMult = Random.Range(0.3f, 1.5f);
		agent.speed = 2 * speedMult;
		agent.angularSpeed = 120;
		anim.SetFloat("speedMult", speedMult);
		anim.SetTrigger("isWalking");
		agent.ResetPath();
	}

	public void DetectNewObstacle(Vector3 position)
	{
		if(Vector3.Distance(position, this.transform.position) < detectionRadius)
		{
			Vector3 fleeDirection = (this.transform.position - position).normalized;
			Vector3 newGoal = this.transform.position + fleeDirection * fleeRadius;

			NavMeshPath path = new NavMeshPath();
			agent.CalculatePath(newGoal, path);

			if(path.status != NavMeshPathStatus.PathInvalid)
			{
				agent.SetDestination(path.corners[path.corners.Length - 1]);
				anim.SetTrigger("isRunning");
				agent.speed = 10;
				agent.angularSpeed = 500;
			}
		}
	}
	void Start () 
	{
		goalLocations = GameObject.FindGameObjectsWithTag("goal");
		agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
		SetRandomLocation();
		anim = this.GetComponent<Animator>();
		anim.SetFloat("wOffset", Random.Range(0f, 1.0f));
		ResetAgent();
	}
	
	void SetRandomLocation()
	{
		agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
	}
	// Update is called once per frame
	void Update () 
	{
		if(agent.remainingDistance < 1)
		{
			ResetAgent();
			SetRandomLocation();
		}
	}
}
