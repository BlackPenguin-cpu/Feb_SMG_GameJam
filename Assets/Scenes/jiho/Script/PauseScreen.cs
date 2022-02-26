using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject PauseButton;
    void Start()
    {

    }

    void Update()
    {

    }

    public void PauseButtonClick()
    {
        Time.timeScale = 0;
        PauseButton.SetActive(false);
        PauseUI.SetActive(true);
    }

    public void CountinueButtonClick()
    {
        PauseUI.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void HomeButtonClice(string SceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneName);
    }
}
