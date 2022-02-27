using System;
using UnityEngine;

public class ClearPopup : MonoBehaviour
{
    public static ClearPopup Instance;
    
    [SerializeField]
    Animator animator;

    static readonly int Pop = Animator.StringToHash("Pop");

    void Awake()
    {
        Instance = this;
    }

    public void TriggerPop()
    {
        animator.SetTrigger(Pop);
    }

    public void OnConfirmButton()
    {
        GameManager.LoadEndingScene();
    }
}
