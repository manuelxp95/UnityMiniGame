using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    public static int LevelScore { get; private set; }
    public static int HighScore { get; private set; }

    public TextMeshProUGUI scoreText;
    AudioManager audioManager;



    private void Start()
    {
        scoreText = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
        LevelScore = 0;
        EventManager.Instance.Subscribe("AsteroidDestroyed", UpdateScore);
        EventManager.Instance.Subscribe("BigAsteroidDestroyed", BigUpdateScore);
        audioManager=GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            audioManager.PlaySFX(audioManager.highScore);
            scoreText.text = "HighScore: " + HighScore.ToString();
        }
        else
        {
            Debug.LogError("Objeto de texto no asignado en el inspector.");
        }
    }
    public void UpdateScore()
    {
        LevelScore += 10;

        if (LevelScore > HighScore)
        {
            HighScore = LevelScore;
            UpdateScoreText();
        }
    }

    public void BigUpdateScore()
    {
        LevelScore += 30;

        if (LevelScore > HighScore)
        {
            HighScore = LevelScore;
            UpdateScoreText();
        }
    }
}