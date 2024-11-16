using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    
    [SerializeField] public Transform playerTarget;
    [SerializeField] private float sens;
    [SerializeField] public Camera MyCamera;

    void Update()
    {
         if (Input.GetMouseButton(1))
         {

            float MouseX = Input.GetAxis("Mouse X");
            transform.Rotate(0, MouseX * sens, 0);//rotatie van de camera keer de senisitvity van de camera op de x positie
            Debug.Log("position" + playerTarget.position);

        }
        transform.position = playerTarget.position;
    }
}

