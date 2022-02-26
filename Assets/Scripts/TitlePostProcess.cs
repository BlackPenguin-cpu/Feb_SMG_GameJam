using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TitlePostProcess : MonoBehaviour
{
    [SerializeField]
    PostProcessProfile profile;

    Bloom bloom;
    float currentVel;

    void Start()
    {
        if (profile.settings[0] is Bloom inBloom)
        {
            bloom = inBloom;
            bloom.intensity.value = 100.0f;
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
