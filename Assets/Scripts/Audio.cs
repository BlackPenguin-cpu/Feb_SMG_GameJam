using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    public static Audio Instance;
    
    [SerializeField]
    AudioSource bgmAudioSource;
    
    [SerializeField]
    AudioSource sfxAudioSource;
    
    [SerializeField]
    AudioSource speechAudioSource;

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

    [SerializeField]
    [Tooltip("타이틀 BGM")]
    AudioClip titleBgm;
    
    [SerializeField]
    [Tooltip("인게임 BGM")]
    AudioClip inGameBgm;
    
    [SerializeField]
    [Tooltip("엔딩 1 BGM")]
    AudioClip ending1Bgm;
    
    [SerializeField]
    [Tooltip("엔딩 2 BGM")]
    AudioClip ending2Bgm;
    
    [SerializeField]
    [Tooltip("엔딩 3 BGM")]
    AudioClip ending3Bgm;
    
    [SerializeField]
    [Tooltip("게임 가이드 스피치")]
    AudioClip gameGuideSpeech;

    float targetBgmVolume;
    float targetBgmVolumeVel;
    
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        
        DontDestroyOnLoad(gameObject);

        UpdateBgm(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        bgmAudioSource.volume = Mathf.SmoothDamp(bgmAudioSource.volume, targetBgmVolume, ref targetBgmVolumeVel, 0.1f);
    }

    void UpdateBgm(string sceneName)
    {
        sceneName = sceneName.ToLower();
        
        if (sceneName == "GameMain".ToLower())
        {
            if (bgmAudioSource.clip != titleBgm)
            {
                bgmAudioSource.clip = titleBgm;
                bgmAudioSource.Play();
            }
            
            targetBgmVolume = 1.0f;
            
            speechAudioSource.Stop();
        }
        else if (sceneName == "flowerSelection".ToLower())
        {
            if (bgmAudioSource.clip != titleBgm)
            {
                bgmAudioSource.clip = titleBgm;
                bgmAudioSource.Play();
            }
            
            targetBgmVolume = 1.0f;
            
            speechAudioSource.Stop();
        }
        else if (sceneName == "InGame".ToLower())
        {
            if (bgmAudioSource.clip != inGameBgm)
            {
                bgmAudioSource.clip = inGameBgm;
                bgmAudioSource.Play();
            }
            
            targetBgmVolume = 1.0f;
            
            speechAudioSource.Stop();
        }
        else if (sceneName == "Ending".ToLower())
        {
            if (bgmAudioSource.clip != ending1Bgm)
            {
                bgmAudioSource.clip = ending1Bgm;
                bgmAudioSource.Play();
            }
            
            targetBgmVolume = 1.0f;
            
            speechAudioSource.Stop();
        }
        else if (sceneName == "GameExplain".ToLower())
        {
            speechAudioSource.clip = gameGuideSpeech;
            speechAudioSource.Play();
            
            targetBgmVolume = 0.2f;
        }
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
        UpdateBgm(scene2.name);
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

    public void SetBgmVolume(float volume)
    {
        bgmAudioSource.volume = volume;
    }

    public float SFXVolume()
    {
        return sfxAudioSource.volume;
    }
    public float BGMVolume()
    {
        return bgmAudioSource.volume;
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

    public void PlayGameGuideSpeech()
    {
        speechAudioSource.PlayOneShot(gameGuideSpeech);
    }
}
