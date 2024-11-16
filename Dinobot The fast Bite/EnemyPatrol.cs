using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] wayPoints;

    private NavMeshAgent navMeshAgent;

    private int currentWaypointIndex = 0;

    [SerializeField] private float targetDistance;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetNextTarget();
    }

    //private void Update()
    //{
    //    if (navMeshAgent.remainingDistance <= targetDistance)
    //    {
    //        SetNextTarget();
    //    }
    //}

    public void SetNextTarget()
    {
        //currentWaypointIndex++;
        //Debug.Log(navMeshAgent.remainingDistance);
       
        if (navMeshAgent.remainingDistance <= 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= wayPoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        //currentWaypointIndex %= wayPoints.Length;

        navMeshAgent.SetDestination(wayPoints[currentWaypointIndex].position); 
    }
}
