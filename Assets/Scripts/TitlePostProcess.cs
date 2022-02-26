using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TitlePostProcess : MonoBehaviour
{
    static TitlePostProcess Instance;
    
    [SerializeField]
    PostProcessVolume volume;
    
    Bloom bloom;
    float currentVel;

    public static bool IsOkToInteract => Instance == null || Instance.bloom.intensity.value <= 10.0f;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        volume.profile = Instantiate(volume.profile);
        
        if (volume.profile.settings[0] is Bloom inBloom)
        {
            bloom = inBloom;

            if (Time.frameCount == 1)
            {
                bloom.intensity.value = 100.0f;
            }
            else
            {
                bloom.intensity.value = 0.0f;
            }
        }
        
    }

    void Update()
    {
        if (bloom != null)
        {
            bloom.intensity.value = Mathf.SmoothDamp(bloom.intensity.value, 0, ref currentVel, 1.5f);
        }
    }
}