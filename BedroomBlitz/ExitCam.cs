using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ExitCam : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera playerFollowCam;
    [SerializeField] private CinemachineVirtualCamera switchCamera1;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "RC Car Final Version")
        {
            SwitchCameraBack();
        }
    }

    private void SwitchCameraBack()
    {
        if (switchCamera1.Priority == 10)
        {
            switchCamera1.Priority = 0;
            playerFollowCam.Priority = 10;
        }
        
    }
}
