using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level_Unlocker : MonoBehaviour
{
    public Button[] levelButtons;
    public int reachedLevel;

    public Button SecretLevel;

    public TMP_Text textPro;
    
    // Start is called before the first frame update
    void Start()
    {
        SecretLevel.interactable = false;
        
        foreach (Button b in levelButtons)
            b.interactable = true;

        reachedLevel = PlayerPrefs.GetInt("ReachedLevel", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > reachedLevel)
            {
                levelButtons[i].interactable = false;
            }
        }
        
        if (PlayerPrefs.GetInt("Collectable1collected") == 1 && PlayerPrefs.GetInt("Collectable2collected") == 1 && PlayerPrefs.GetInt("Collectable3collected") == 1 && PlayerPrefs.GetInt("Collectable4collected") == 1 && PlayerPrefs.GetInt("Collectable5collected") == 1 && PlayerPrefs.GetInt("Collectable6collected") == 1)
        {
            SecretLevel.interactable = true;
        }
        
    }

    public void levelReset()
    {
        PlayerPrefs.SetInt("ReachedLevel", 1);
        PlayerPrefs.SetInt("Collectable1collected", 0);
        PlayerPrefs.SetInt("Collectable2collected", 0);
        PlayerPrefs.SetInt("Collectable3collected", 0);
        PlayerPrefs.SetInt("Collectable4collected", 0);
        PlayerPrefs.SetInt("Collectable5collected", 0);
        PlayerPrefs.SetInt("Collectable6collected", 0);
        LevelFade.Instance.FadeToLevel(1);
    }

    public void fullUnlock()
    {
        PlayerPrefs.SetInt("ReachedLevel", 4);
        PlayerPrefs.SetInt("Collectable1collected", 1);
        PlayerPrefs.SetInt("Collectable2collected", 1);
        PlayerPrefs.SetInt("Collectable3collected", 1);
        PlayerPrefs.SetInt("Collectable4collected", 1);
        PlayerPrefs.SetInt("Collectable5collected", 1);
        PlayerPrefs.SetInt("Collectable6collected", 1);
        LevelFade.Instance.FadeToLevel(1);
    }
}
