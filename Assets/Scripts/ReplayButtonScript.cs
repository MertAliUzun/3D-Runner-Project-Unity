using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class ReplayButtonScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public static bool isGameOver;
    public static bool gameOverScreenActive;
    public static bool victory;
    public static bool hitTrap;

    public void Awake()
    {
        isGameOver = false;
        gameOverScreenActive = false;
        hitTrap = false;
    }
    public void Update()
    {
        gameOver();
    }
    public void gameOver()                                  // Handle GameOver Screen and Victory Points
    {
        if (isGameOver && !gameOverScreenActive)
        {
            if(ScoreManager.score >= 70)
            {
                victory = true;              
            }
            if(ScoreManager.score < 70)
            {
                victory = false;
            }
            if (hitTrap)
            {
                victory = false;
            }
            gameOverScreen.SetActive(true);
            gameOverScreenActive = true;
        }       
    }                                                 
    public void ReplayScene()
    {     
        SceneManager.LoadScene(sceneName: "Level01");
        gameOverScreenActive = false;
        ScoreManager.score = 0;                                                // Reset Score When Replay
    }
}
