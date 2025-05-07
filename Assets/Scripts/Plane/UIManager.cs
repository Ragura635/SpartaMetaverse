using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI countdownText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if(restartText != null)
            Debug.Log("restart text is null");
        
        if(scoreText != null)
            Debug.Log("score text is null");

        restartText.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
    
    public IEnumerator ShowCountdown()
    {
        string[] steps = { "3", "2", "1", "Start!" };
        countdownText.gameObject.SetActive(true);

        foreach (string step in steps)
        {
            countdownText.text = step;
            yield return new WaitForSecondsRealtime(1f);
        }

        countdownText.gameObject.SetActive(false);
    }
    
    public void ReturnMainScene()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("MainScene");
    }
}
