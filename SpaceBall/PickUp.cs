using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUp : MonoBehaviour
{
    private ScoreSystem _scoreSystem;
    [SerializeField] private int _rotateSpeed;

    private void Start()
    {
        _scoreSystem = FindObjectOfType<ScoreSystem>(); // zoek naar object ScoreSystem object.
    }
    private void OnTriggerEnter(Collider other)
    {
        //met collision haalt de object weg en telt met 1 op door naar de scoresytem script aan te roepen.
        _scoreSystem.AddScore();
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(0, 2.5f, 0 * Time.deltaTime * _rotateSpeed);
    }

}
