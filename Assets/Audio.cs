using System;
using System.Collections;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio Instance;
    
    [SerializeField]
    AudioClip buttonClick;
    
    [SerializeField]
    AudioClip waterSound;

    [SerializeField]
    AudioSource sfxAudioSource;

    void Awake()
    {
        Instance = this;
    }

    IEnumerator Start()
    {
        PlayButtonClick();
        yield return new WaitForSeconds(2.0f);
        PlayWaterSound();
    }

    public void PlayButtonClick()
    {
        sfxAudioSource.PlayOneShot(buttonClick);
    }
    
    public void PlayWaterSound()
    {
        sfxAudioSource.PlayOneShot(waterSound);
    }
}
