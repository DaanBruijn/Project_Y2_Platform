using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene(3);
    }

    public void LevelSelect ()
    {
        SceneManager.LoadScene(7);
    }

    public void Level1()
    {
        SceneManager.LoadScene(3);
    }

    public void level2()
    {
        SceneManager.LoadScene(4);
    }

    public void MainMenu ()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
