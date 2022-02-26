using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundUI : MonoBehaviour
{
    void Start()
    {

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
}
