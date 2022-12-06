using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public int levelSelect;
    public int levelToLoad;
    
    public void PlayGame ()
    {
        LevelFade.Instance.FadeToLevel(4);
    }

    public void LevelSelect ()
    {
        LevelFade.Instance.FadeToLevel(1);
    }

    public void LevelSelector()
    {
        LevelFade.Instance.FadeToLevel(levelSelect);
    }
    
    public void MainMenu ()
    {
        LevelFade.Instance.FadeToLevel(0);
    }
    
    public void AchievementScreen ()
    {
        LevelFade.Instance.FadeToLevel(9);
    }

    public void TutorialLevel()
    {
        LevelFade.Instance.FadeToLevel(10);
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    
    public void ResetAchievement()
    {
        PlayerPrefs.SetInt("Ach_Jess", 0);
        PlayerPrefs.SetInt("Level1Secret", 0);
        LevelFade.Instance.FadeToLevel(0);
    }
}
