using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float doorSpeed = 1f; 
    [SerializeField] private float openAngle = -90f; 
    [SerializeField] private Transform hinge; 
    [SerializeField] public bool isOpen = false;
    public float maxDistance = 2f;

    private Quaternion startRotation;
    private Quaternion endRotation;


    private float distance = 0f;

    private void Awake()
    {
        startRotation = hinge.rotation;
        endRotation = startRotation * Quaternion.Euler(0f, openAngle, 0f);
    }

    public void Open()
    {
        if (!isOpen)
        {
            isOpen = true;
            distance = 0f;
        }
    }

    public void Close()
    {
        if (isOpen)
        {
            isOpen = false;
            distance = 0f;
        }
    }

    private void Update()
    {
        if (isOpen)
        {
            distance += Time.deltaTime * doorSpeed;
            hinge.rotation = Quaternion.Slerp(startRotation, endRotation, distance);

            if (distance >= 1f)
            {
                distance = 1f;
            }
        }
        else
        {
            distance += Time.deltaTime * doorSpeed;
            hinge.rotation = Quaternion.Slerp(endRotation, startRotation, distance);

            if (distance >= 1f)
            {
                distance = 1f;
            }
        }
        

    }
}
