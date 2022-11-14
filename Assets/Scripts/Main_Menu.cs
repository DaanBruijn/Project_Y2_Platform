using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public int levelSelect;
    
    public void PlayGame ()
    {
        SceneManager.LoadScene(4);
    }

    public void LevelSelect ()
    {
        SceneManager.LoadScene(7);
    }

    public void LevelSelector()
    {
        SceneManager.LoadScene(levelSelect);
    }
    
    public void MainMenu ()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
