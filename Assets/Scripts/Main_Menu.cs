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

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
