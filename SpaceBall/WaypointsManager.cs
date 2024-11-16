using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsManager : MonoBehaviour
{

    [SerializeField] private GameObject[] waypoints;
    private int currentwaypointIndex = 0;
    [SerializeField] private float _speed;
    
    
    private void Update()
    {
        if (Vector3.Distance(waypoints [currentwaypointIndex].transform.position, transform.position) < 1f)
        {
            currentwaypointIndex++;

            if (currentwaypointIndex >= waypoints.Length)
            {
                currentwaypointIndex = 0;

               
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentwaypointIndex].transform.position, Time.deltaTime * _speed);
    }


}
