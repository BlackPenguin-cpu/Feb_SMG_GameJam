using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    [SerializeField]
    Sprite ending1ASprite;

    [SerializeField]
    Sprite ending1BSprite;

    [SerializeField]
    Sprite ending2Sprite;

    [SerializeField]
    Sprite ending3Sprite;

    [SerializeField]
    Image image;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip[] ending1Speech;

    [SerializeField]
    AudioClip ending2Speech;

    [SerializeField]
    AudioClip ending3Speech;

    void Start()
    {
        StartCoroutine(StartEnding1Coro());
    }

    IEnumerator StartEnding1Coro()
    {
        image.sprite = ending1ASprite;
        
        yield return new WaitForSeconds(3.0f);
        
        audioSource.PlayOneShot(ending1Speech[0]);
        
        yield return new WaitForSeconds(5.0f);
        
        audioSource.PlayOneShot(ending1Speech[1]);
        
        yield return new WaitForSeconds(7.0f);
        
        audioSource.PlayOneShot(ending1Speech[2]);
        
        yield return new WaitForSeconds(5.0f);
        
        image.sprite = ending1BSprite;
    }
}