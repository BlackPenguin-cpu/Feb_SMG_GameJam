using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundUI : MonoBehaviour
{
    [SerializeField]
    Slider BGM;
    [SerializeField]
    Slider SFX;
    void Start()
    {
        BGM.value = Audio.Instance.BGMVolume();
        SFX.value = Audio.Instance.SFXVolume();
    }

    void Update()
    {

    }

    public void SFXVolume(float volume)
    {
        if (Audio.Instance != null)
        {
            Audio.Instance.SetSFXVolume(volume);
        }
    }
    public void BGMVolume(float volume)
    {
        if (Audio.Instance != null)
        {
            Audio.Instance.SetBgmVolume(volume);
        }
    }
}
