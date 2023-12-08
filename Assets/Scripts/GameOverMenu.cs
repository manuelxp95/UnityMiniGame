using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    [SerializeField] private GameObject gameOverScreen;
    void Start()
    {
        gameOverScreen.SetActive(false);
        EventManager.Instance.Subscribe("PlayerDie", GameOverScreen);
    }

   public void GameOverScreen()
    {
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        gameOverScreen.SetActive(false);
        EventManager.Instance.TriggerEvent("RetryGame");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
