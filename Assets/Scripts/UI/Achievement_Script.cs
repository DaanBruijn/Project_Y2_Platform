using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Achievement;
using TMPro;

public class Achievement_Script : MonoBehaviour
{
    [Header("Achievement")]
    [SerializeField] private AchievementObject achievement;
    [SerializeField] private TMP_Text achievementBoxText;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt(achievement.playerPrefName) == 0)
            {
                //Animation with the Correct Text
                achievementBoxText.text = achievement.achievementName;
                AchievementManager.Instance.StartAnimation();

                //Sets Playerpref from ScriptableObject
                PlayerPrefs.SetInt(achievement.playerPrefName, 1);
            }
        }
    }
}
