using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject playButton;
    public GameObject optionButton;
    public GameObject quitButton;
    public GameObject OptionMenu;
    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
    }

    public void PlayGame()
    {
        mainMenu.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OptionsMenu()
    {
        playButton.SetActive(false);
        optionButton.SetActive(false);
        quitButton.SetActive(false);
        OptionMenu.SetActive(true);
    }
    public void Back()
    {
        playButton.SetActive(true);
        optionButton.SetActive(true);
        quitButton.SetActive(true);
        OptionMenu.SetActive(false);
    }
}
