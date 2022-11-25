using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement_Slide : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            _animator.SetBool("Achievement_Got", true);
        }
    }

    void EndAchievement()
    {
        _animator.SetBool("Achievement_Got", false);
    }
}
