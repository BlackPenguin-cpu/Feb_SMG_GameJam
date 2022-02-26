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
        Audio.Instance.SetSFXVolume(volume);
    }
}
