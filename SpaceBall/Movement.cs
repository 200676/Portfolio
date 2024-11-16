using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float _speed;
    [SerializeField] public float _jumpForce;
    [SerializeField] public Vector3 _jump;
    [SerializeField] Transform _cam;


    private bool isGrounded;
    [SerializeField] private int _jumpCount = 0;

    private Vector3 _force;

    private Rigidbody _rb;

    private bool _jumpCheck;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();//om de object gravity, force, of snelheid aan te passen
        _jump = new Vector3(0, 1.5f, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        isGrounded = true;
        _jumpCount = 2; //maximum aantal kunnen springen.
    }

    void FixedUpdate()
    {
        _rb.AddForce(_force * _speed);
        if (_jumpCheck == true)
        {
            _rb.AddForce(_jump * _jumpForce, ForceMode.Impulse);//impulse voor de direct force die snel direct impact op het springen heeft.
            isGrounded = false; //niet meer op de grond
            _jumpCount--; // haalt 1 eraf en als nog een keer springt nog 1 totdat het 0 is
            Debug.Log("can't double jump");
            _jumpCheck = false;
        }

    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        _force = (_cam.forward * moveVertical + _cam.right * moveHorizontal) * _speed * Time.deltaTime;//righting van bal met de camera
        


        if (Input.GetKeyDown(KeyCode.Space) && _jumpCount > 0)
        {
            _jumpCheck = true;
        }

    }





}
