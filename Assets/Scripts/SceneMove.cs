using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public void SceneGameMain()
    {
        SceneManager.LoadScene("GameMain");
    }
    public void SceneflowerSelection()
    {
        SceneManager.LoadScene("flowerSelection");
    }
    public void SceneGameExplain()
    {
        SceneManager.LoadScene("GameExplain");
    }
    public void SceneInGame()
    {
        SceneManager.LoadScene("InGame");
    }
    public void SceneDeveloper()
    {
        SceneManager.LoadScene("Developer");
    }
    public void SceneSound()
    {
        SceneManager.LoadScene("Sound");
    }
}
