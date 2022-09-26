using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]private GameManager gameManager;
    [SerializeField]private PlayerMovement playerMovement;

    [SerializeField]private GameObject pauseMenu;
    private bool paused = false;

    public GameObject scoreText;

    public TextMeshProUGUI pausedScoretext;
    public TextMeshProUGUI pausedTimetext;
    // Update is called once per frame

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            if (paused == false)
            {
                Debug.Log("paused");
                Pause();
            }   
            else if (paused == true)
            {
                Debug.Log("resumed");
                Resume();
            }
        }    

    }

    public void Pause()
    {
        Time.timeScale = 0.0f;

        pauseMenu.SetActive(true);
        scoreText.SetActive(false);

        paused = true;
        playerMovement.isPaused = true;

        pausedScoretext.text = "score: " + gameManager.score;
        pausedTimetext.text = "Time: " + gameManager.time;
    }

    public void Resume()
    {
        Time.timeScale = 1f;

        pauseMenu.SetActive(false);
        scoreText.SetActive(true);

        paused = false;
        playerMovement.isPaused = false;
    }

    public void Restart()
    {
        Debug.Log("restart");
        gameManager.Restart();
        paused = false;
    }
}
