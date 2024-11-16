using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraSwitching : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera playerFollowCam;
    [SerializeField] private CinemachineVirtualCamera switchCamera1;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered");
        
        if (other.gameObject.name == "RC Car Final Version")
        {
            Debug.Log("collsion");
            SwitchCamera();
        }
    }

    private void SwitchCamera()
    {
        if (playerFollowCam.Priority == 10)
        {
            playerFollowCam.Priority = 0;
            switchCamera1.Priority = 10;
        }
        
    }
}
