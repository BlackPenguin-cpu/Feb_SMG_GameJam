using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public void SceneGameMain()
    {
        Audio.Instance.PlayButtonClick();
        SceneManager.LoadScene("GameMain");
    }
    public void SceneflowerSelection()
    {
        Audio.Instance.PlayButtonClick();
        SceneManager.LoadScene("flowerSelection");
    }
    public void SceneGameExplain()
    {
        Audio.Instance.PlayButtonClick();
        SceneManager.LoadScene("GameExplain");
    }
    public void SceneInGame()
    {
        Audio.Instance.PlayButtonClick();
        SceneManager.LoadScene("InGame");
    }
    public void SceneDeveloper()
    {
        Audio.Instance.PlayButtonClick();
        SceneManager.LoadScene("Developer");
    }
    public void SceneSound()
    {
        Audio.Instance.PlayButtonClick();
        SceneManager.LoadScene("Sound");
    }
}
