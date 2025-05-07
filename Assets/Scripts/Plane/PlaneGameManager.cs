using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneGameManager : MonoBehaviour
{
    static PlaneGameManager planeGameManager;
    public static PlaneGameManager Instance{ get{ return planeGameManager;}}

    int currentScore = 0;
    int bestScore = 0;
    
    private const string BestScoreKey = "BestScore";
    
    UIManager uiManager;
    public UIManager UIManager{ get{ return uiManager;}}
    
    private void Awake()
    {
        planeGameManager = this;
        uiManager = FindObjectOfType<UIManager>();
        
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    private void Start()
    {
        StartCoroutine(BeginGameRoutine());
    }


    public void GameOver()
    {
        Debug.Log("GameOver");
        uiManager.SetRestart();
    }
    
    IEnumerator BeginGameRoutine()
    {
        Time.timeScale = 0f;

        yield return StartCoroutine(uiManager.ShowCountdown());

        Time.timeScale = 1f;

        uiManager.UpdateScore(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        uiManager.UpdateScore(currentScore);
        
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
        }
    }
    
    public int GetBestScore()
    {
        return bestScore;
    }
}
