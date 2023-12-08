using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int LevelScore { get; private set; }
    public static int HighScore { get; private set; }

    private void Start()
    {
        LevelScore = 0;
        // Cargar HighScore desde PlayerPrefs
    }

    public static void UpdateScore(int score)
    {
        LevelScore += score;

        if (LevelScore > HighScore)
        {
            HighScore = LevelScore;
            // Guardar HighScore en PlayerPrefs
        }
    }
}