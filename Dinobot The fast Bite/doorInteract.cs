using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour
{
    [SerializeField] private Door[] doors;
    private bool isInteracting = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isInteracting)
            {
                return;
            }
            isInteracting = true;

            foreach (Door door in doors)
            {
                if (Vector3.Distance(transform.position, door.transform.position) <= door.maxDistance)
                {
                    if (door.isOpen)
                    {
                        door.Close();
                    }
                    else
                    {
                        door.Open();
                    }
                    break;
                }
            }

            isInteracting = false;
        }
    }
}
