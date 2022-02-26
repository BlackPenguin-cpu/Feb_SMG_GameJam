using System.Collections;
using UnityEngine;

public class Thanks : MonoBehaviour
{
    [SerializeField]
    GameObject confirmButton;
    
    IEnumerator Start()
    {
        confirmButton.SetActive(false);
        Audio.Instance.PlayAllClearSound();
        yield return new WaitForSeconds(5.0f);
        confirmButton.SetActive(true);
    }
}