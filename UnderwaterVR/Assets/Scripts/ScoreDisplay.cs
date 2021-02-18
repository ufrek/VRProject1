﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text tScore;
    int totalScore = 0;
    int totalLives = 3;
    public static ScoreDisplay S;
    // Start is called before the first frame update
    void Start()
    {
        S = this;
        tScore = GetComponentInChildren<Text>();
        totalLives = 3;
        totalScore = 0;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int i)
    {
        totalScore += i;
        UpdateText();
    }

    public void loseLife()
    {
        totalLives -= 1;
        UpdateText();
    }

    void UpdateText()
    {
        tScore.text = "Score: " + totalScore + "\nLives: " + totalLives;
    }
}
