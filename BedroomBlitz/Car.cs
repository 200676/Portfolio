using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Wheels[] Wheels;
    public float Power;
    public float StandardPower;
    public float MaxAngle;

    private float _Forward;
    private float _Angle;
    private float _Drift;

    public bool GameIsStarted = false;

    [Header("Speed Pad")]
    [SerializeField] private float _SpeedBoost;
    [SerializeField] private float _BoostTimeLimit;

    [Header("Audio")]
    private AudioSource accelerationAudioSource;

    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;

    private Rigidbody rb;

    private void Start()
    {
        GameIsStarted = false;

        Power = StandardPower;
        accelerationAudioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!GameIsStarted)
        {
            return;
        }

        _Forward = Input.GetAxis("Vertical")/* * Power*/;
        _Angle = Input.GetAxis("Horizontal");

        PlayAccelerateAudioClip();
    }

    private void PlayAccelerateAudioClip()
    {
        // Get the current speed of the vehicle
        float speed = rb.velocity.magnitude;

        // Map the speed to the range of audio pitch and volume
        float pitch = Mathf.Lerp(0.8f, 1.2f, Mathf.InverseLerp(minSpeed, maxSpeed, speed));
        float volume = Mathf.InverseLerp(minSpeed, maxSpeed, speed);

        // Play or stop the audio based on whether the vehicle is moving
        if (speed > 0.1f && !accelerationAudioSource.isPlaying)
        {
            accelerationAudioSource.Play();
        }
        else if (speed < 0.1f && accelerationAudioSource.isPlaying)
        {
            accelerationAudioSource.Stop();
        }
    }

    private void FixedUpdate()
    {
        foreach (Wheels _wheel in Wheels)
        {
            _wheel.Accelerate(_Forward * Power);
            _wheel.turn(_Angle * MaxAngle);
            _wheel.Drift(_Drift * _Angle);
        }
    }

    public void StartSpeedBoost()
    {
        Power = /*Power **/ _SpeedBoost;
        Invoke("StopSpeedBoost", _BoostTimeLimit);
    }

    void StopSpeedBoost()
    {
        Power = StandardPower;
    }
}
