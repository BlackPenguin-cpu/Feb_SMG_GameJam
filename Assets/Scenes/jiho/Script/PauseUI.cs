using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public GameObject PauseScreen;
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
        PauseScreen.SetActive(true);
    }

    public void CountinueButtonClick()
    {
        PauseScreen.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1;
    }
}
