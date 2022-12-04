using UnityEngine;


public class AchievementManager : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] private Animator _animator;

    public static AchievementManager Instance;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void StartAnimation()
    {
        _animator.SetBool("Achievement_Got", true);
    }

    public void EndAnimation()
    {
        _animator.SetBool("Achievement_Got", false);
    }
}
