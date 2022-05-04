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
        if(score >= 100)
        {
            score = 90;
        }
        score += scoreValue;
        text.text = score.ToString();
    }
}
