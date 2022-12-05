using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Achievement_Unlocker : MonoBehaviour
{
    [SerializeField] private TMP_Text[] achievement_Text;
    [SerializeField] private TMP_Text[] achievement_Desc;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Ach_Jess") == 1)
        {
            achievement_Text[0].text = "You found Jesse!";
            achievement_Desc[0].text = "He is saying that he is better then Taif.";
        }
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("Ach_Jess", 0);
        LevelFade.Instance.FadeToLevel(0);
    }
}
