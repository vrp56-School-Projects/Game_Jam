using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreContoller : MonoBehaviour
{
    public Text score;
    private int _currentScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddScore()
    {
        _currentScore += 50;
        score.text = "Score: " + _currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
