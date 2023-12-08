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



    private void Start()
    {
        scoreText = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
        LevelScore = 0;
        EventManager.Instance.Subscribe("AsteroidDestroyed", UpdateScore);
        // Cargar HighScore desde PlayerPrefs
    }

    private void UpdateScoreText()
    {
        // Asegurarse de tener una referencia válida al objeto de texto
        if (scoreText != null)
        {
            // Actualizar el texto con el nuevo puntaje
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
}