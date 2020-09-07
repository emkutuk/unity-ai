using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour
{
    public UnityStandardAssets.Utility.WaypointCircuit circuit;
    
    //public GameObject[] waypoints;
    int currentWp = 0;

    public float speed = 1.0f;
    public float accuracy = 1.0f;
    public float rotSpeed = 0.4f;
    void Start()
    {
        //waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    
    void LateUpdate()
    {
        if(circuit.Waypoints.Length == 0) return;

        Vector3 LookAtGoal = new Vector3(circuit.Waypoints[currentWp].transform.position.x, this.transform.position.y, circuit.Waypoints[currentWp].transform.position.z);

        Vector3 direction = LookAtGoal - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);

        if(direction.magnitude < accuracy)
        {
            currentWp++;
            
            if(currentWp >= circuit.Waypoints.Length)
            currentWp=0;
        }
        this.transform.Translate(0,0,speed*Time.deltaTime);
    }
}
