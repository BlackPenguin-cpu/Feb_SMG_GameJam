using UnityEngine;

public class Fairy : MonoBehaviour
{
    public static Fairy Instance;
    
    [SerializeField]
    Animator animator;

    static readonly int Swing = Animator.StringToHash("Swing");

    void Awake()
    {
        Instance = this;
    }

    public void PlaySwing()
    {
        animator.SetTrigger(Swing);
    }
}
