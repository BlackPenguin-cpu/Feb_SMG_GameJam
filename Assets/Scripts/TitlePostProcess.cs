using UnityEngine;
using UnityEngine.Rendering;

public class TitlePostProcess : MonoBehaviour
{
    static TitlePostProcess Instance;

    [SerializeField]
    Volume volume;

    UnityEngine.Rendering.Universal.Bloom bloom;
    float currentVel;

    public static bool IsOkToInteract => Instance == null || Instance.bloom.intensity.value <= 10.0f;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        volume.profile = Instantiate(volume.profile);

        if (volume.profile.components[0] is UnityEngine.Rendering.Universal.Bloom inBloom)
        {
            bloom = inBloom;

            if (Time.frameCount == 1)
            {
                bloom.intensity.value = 200.0f;
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
            bloom.intensity.value = Mathf.SmoothDamp(bloom.intensity.value, 0, ref currentVel, 1.0f);
        }
    }
}