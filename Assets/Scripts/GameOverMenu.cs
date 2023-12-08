using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    [SerializeField] private GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.Subscribe("PlayerDie", GameOverScreen);
    }

   public void GameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void Retry()
    {
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }
}
