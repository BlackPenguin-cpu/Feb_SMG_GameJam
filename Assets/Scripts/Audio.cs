using System.Collections;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio Instance;
    
    [SerializeField]
    AudioSource sfxAudioSource;

    [SerializeField]
    [Tooltip("UI 버튼 클릭")]
    AudioClip buttonClick;
    
    [SerializeField]
    [Tooltip("물뿌리개")]
    AudioClip waterSound;
    
    [SerializeField]
    [Tooltip("씨앗 심기")]
    AudioClip putSeedSound;
    
    [SerializeField]
    [Tooltip("스프레이")]
    AudioClip spraySound;
    
    [SerializeField]
    [Tooltip("벌레 윙윙")]
    AudioClip bugBuzzSound;
    
    [SerializeField]
    [Tooltip("벌레 죽을 때")]
    AudioClip bugDeathSound;
    
    [SerializeField]
    [Tooltip("꽃 수확")]
    AudioClip harvestFlowerSound;
    
    void Awake()
    {
        Instance = this;
    }

    public void PlayButtonClick()
    {
        sfxAudioSource.PlayOneShot(buttonClick);
    }
    
    public void PlayWaterSound()
    {
        sfxAudioSource.PlayOneShot(waterSound);
    }
    
    public void PlayPutSeedSound()
    {
        sfxAudioSource.PlayOneShot(putSeedSound);
    }
    
    public void PlaySpraySound()
    {
        sfxAudioSource.PlayOneShot(spraySound);
    }
    
    public void PlayBugBuzzSound()
    {
        sfxAudioSource.PlayOneShot(bugBuzzSound);
    }
    
    public void PlayBugDeathSound()
    {
        sfxAudioSource.PlayOneShot(bugDeathSound);
    }
    
    public void PlayHarvestFlowerSound()
    {
        sfxAudioSource.PlayOneShot(harvestFlowerSound);
    }

    public void SetSFXVolume(float volume)
    {
        sfxAudioSource.volume = volume;
    }

    public void PlayGrowSound(int growValue)
    {
        if (growValue <= 0)
        {
            PlayPutSeedSound();
        }
        else
        {
            PlayWaterSound();    
        }
    }
}
