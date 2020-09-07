using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathNavMesh : MonoBehaviour
{
	public GameObject wpManager;
	GameObject[] wps;
	UnityEngine.AI.NavMeshAgent agent;
	
	// Use this for initialization
	void Start()
	{
		wps = wpManager.GetComponent<WPManager>().waypoints;
		agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

	public void GoToHeli()
	{
		agent.SetDestination(wps[1].transform.position);
	}

	public void GoToRuins()
	{
		agent.SetDestination(wps[2].transform.position);
	}

	// Update is called once per frame
	void LateUpdate()
	{

		

	}
}
