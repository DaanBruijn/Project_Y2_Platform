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

    public TMP_Text textPro;
    
    // Start is called before the first frame update
    void Start()
    {
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

        textPro.text = PlayerPrefs.GetInt("ReachedLevel", reachedLevel).ToString();
    }

    public void levelReset()
    {
        PlayerPrefs.SetInt("ReachedLevel", 1);
        SceneManager.LoadScene(7);
    }
}
