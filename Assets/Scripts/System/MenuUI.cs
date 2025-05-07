using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public TextMeshProUGUI bestScore;
    private const string BestScoreKey = "BestScore";
    private const string LastX = "LastX";
    private const string LastY = "LastY";
    public Transform player;

    private void OnEnable()
    {
        int best = PlayerPrefs.GetInt(BestScoreKey, 0);
        bestScore.text = best.ToString();
    }
    
    public void StartMiniGame()
    {
        // 현재 플레이어 위치 저장
        PlayerPrefs.SetFloat(LastX, player.position.x);
        PlayerPrefs.SetFloat(LastY, player.position.y);
        PlayerPrefs.Save();

        // PlaneScene 실행
        SceneManager.LoadScene("PlaneScene");
    }
}
