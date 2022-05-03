using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreBoard;
    public int score;

    private void OnEnable()
    {
        Target.TS += AddScore;
    }

    private void OnDisable()
    {
        Target.TS -= AddScore;
    }


    private void AddScore()
    {
        score++;
        scoreBoard.text = " " + score;
        
    }
    
    /*public void Update()
    {
        throw new NotImplementedException();
    }*/
}
