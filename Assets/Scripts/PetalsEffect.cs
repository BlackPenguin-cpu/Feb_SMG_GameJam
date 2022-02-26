using UnityEngine;
using UnityEngine.SceneManagement;

public class PetalsEffect : MonoBehaviour
{
    public static PetalsEffect Instance;
    
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        
        DontDestroyOnLoad(gameObject);

        UpdateActivation(SceneManager.GetActiveScene().name);
    }
    
    void OnEnable()
    {
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    void OnDisable()
    {
        SceneManager.activeSceneChanged -= OnActiveSceneChanged;
    }

    void OnActiveSceneChanged(Scene scene1, Scene scene2)
    {
        UpdateActivation(scene2.name);
    }

    void UpdateActivation(string sceneName)
    {
        sceneName = sceneName.ToLower();
        
        if (sceneName == "InGame".ToLower())
        {
            Destroy(gameObject);
        }
    }
}
