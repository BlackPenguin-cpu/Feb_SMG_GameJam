using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public void SceneGameMain()
    {
        if (TitlePostProcess.IsOkToInteract == false) return;
        
        Audio.Instance.PlayButtonClick();
        SceneManager.LoadScene("GameMain");
    }
    
    public void SceneGameMainWithAllClearCheck()
    {
        if (TitlePostProcess.IsOkToInteract == false) return;
        
        Audio.Instance.PlayButtonClick();

        if (PlayerPrefs.GetInt("Ending1Clear", 0) != 0
            && PlayerPrefs.GetInt("Ending2Clear", 0) != 0
            && PlayerPrefs.GetInt("Ending3Clear", 0) != 0
            && PlayerPrefs.GetInt("AllCleared", 0) == 0)
        {
            PlayerPrefs.SetInt("AllCleared", 1);
            PlayerPrefs.Save();
                
            SceneManager.LoadScene("Thanks");
        }
        else
        {
            SceneManager.LoadScene("GameMain");    
        }
    }
    
    public void SceneflowerSelection()
    {
        if (TitlePostProcess.IsOkToInteract == false) return;
        
        Audio.Instance.PlayButtonClick();
        SceneManager.LoadScene("flowerSelection");
    }
    public void SceneGameExplain()
    {
        if (TitlePostProcess.IsOkToInteract == false) return;
        
        Audio.Instance.PlayButtonClick();
        SceneManager.LoadScene("GameExplain");
    }
    public void SceneInGame(int flowerType)
    {
        if (TitlePostProcess.IsOkToInteract == false) return;
        
        Audio.Instance.PlayButtonClick();

        GameManager.FlowerType = (FlowerType) flowerType;
        
        SceneManager.LoadScene("InGame");
    }
    public void SceneDeveloper()
    {
        if (TitlePostProcess.IsOkToInteract == false) return;
        
        Audio.Instance.PlayButtonClick();
        SceneManager.LoadScene("Developer");
    }
    public void SceneSound()
    {
        if (TitlePostProcess.IsOkToInteract == false) return;
        
        Audio.Instance.PlayButtonClick();
        SceneManager.LoadScene("Sound");
    }
}
