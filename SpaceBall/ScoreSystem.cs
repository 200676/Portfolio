using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] public GameObject _scoreText;
    public int _score;

    public void AddScore()
    {
        _score++;//telt op
        _scoreText.GetComponent<Text>().text = "SCORE: " + _score;//update score met component van score aan te roepen en op te tellen.
        
    }

   

}
