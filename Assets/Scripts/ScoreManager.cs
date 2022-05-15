using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;
    public TextMeshProUGUI text;
    public static int score;

    void Start()
    {
        if(scoreManager == null)
        {
            scoreManager = this;
        }
    }


    public void ChangeScore(int scoreValue)
    {
        score += scoreValue;
        if (score >= 100)
        {
            score = 100;
        }
        if(score <= 0)
        {
            score = 0;
        }
        if(score <= -10)
        {
            score = 0;
        }
        
        text.text = score.ToString();
    }
}
