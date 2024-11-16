using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheels : MonoBehaviour
{
    public bool isPower;
    public bool canTurn;
    //public bool canDrift = true;
    public GameObject Visual;

    private WheelCollider _wheelcollider;

    private void Start()
    {
        _wheelcollider = GetComponent<WheelCollider>();
    }
    private void Update()
    {
        Vector3 _position;
        Quaternion _rotation;
        _wheelcollider.GetWorldPose(out _position, out _rotation);
        Visual.transform.position = _position;
        Visual.transform.rotation = _rotation;
    }
    public void Accelerate(float _power)
    {
        if (isPower)
        { 
            _wheelcollider.motorTorque = _power;
        }
    }
    public void turn(float _angle)
    {
        if (canTurn)
        {
            _wheelcollider.steerAngle = _angle;
        }
    }
    public void Brake(float _power)
    {
        _wheelcollider.brakeTorque = _power;
    }
    public void Drift(float _angle)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("pressed");
            if (_wheelcollider.transform.localPosition.z < 1.6f) 
            {
                WheelFrictionCurve sidewaysFriction = _wheelcollider.sidewaysFriction;

                if (sidewaysFriction.stiffness < 1.6f)
                {
                    sidewaysFriction.stiffness *= 1.5f; 
                    sidewaysFriction.extremumSlip = 0.61f; 
                    sidewaysFriction.extremumValue = 0.32f; 
                    sidewaysFriction.asymptoteSlip = 1.81f; 
                    sidewaysFriction.asymptoteValue = 0.20f; 
                }

                _wheelcollider.sidewaysFriction = sidewaysFriction;
            }
        }
        else
        {
            ResetSidewaysFriction();
        }
    }
    private void ResetSidewaysFriction()
    {
        if(_wheelcollider.transform.localPosition.z < 0)
    {
            WheelFrictionCurve defaultSidewaysFriction = new WheelFrictionCurve();
            defaultSidewaysFriction.stiffness = 1.4f; 
            defaultSidewaysFriction.extremumSlip = 0.4f; 
            defaultSidewaysFriction.extremumValue = 1.0f; 
            defaultSidewaysFriction.asymptoteSlip = 0.5f; 
            defaultSidewaysFriction.asymptoteValue = 0.75f; 

            if (_wheelcollider.sidewaysFriction.stiffness > defaultSidewaysFriction.stiffness)
            {
                _wheelcollider.sidewaysFriction = defaultSidewaysFriction;
            }
        }
    }

}
