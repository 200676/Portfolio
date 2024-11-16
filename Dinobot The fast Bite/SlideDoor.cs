using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoor : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentwaypointIndex = 0;
    [SerializeField] private float doorSpeed;
    [SerializeField] private GameObject door;
    [SerializeField] private float maxDistance = 2f;

    private Inventory inventory;


    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) &&
            Vector3.Distance(waypoints[currentwaypointIndex].transform.position, transform.position) < 1f &&
            inventory.hasGreenKeycard)
        {
            currentwaypointIndex++;

            if (currentwaypointIndex >= waypoints.Length)
            {
                currentwaypointIndex = 1;
            }
            //OpenDoor();
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentwaypointIndex].transform.position, Time.deltaTime * doorSpeed);
    }
}
