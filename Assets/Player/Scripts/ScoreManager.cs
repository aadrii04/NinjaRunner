using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text finalScoreText;
    [SerializeField] int scoreRequiredToWin = 150;
    int score = 0;

    private void Awake()
    {
        instance = this; 
    }

    public void IncreaseScore(int addScore)
    {
        score += addScore;
        scoreText.text = "Score: " + score;

        // este if representa la win condition para
        // que cuando tengas una cierta puntuación ganes
        if(score == scoreRequiredToWin) { 
            LoadingScreen.LoadScene("WinScene"); }
    }

    public void GetFinalScore()
    {
        finalScoreText.text = "Final Score " + score;
    }
}
