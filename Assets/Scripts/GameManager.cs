using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float score = 0f;

    public TextMeshProUGUI Scoretext;
    private GameObject textObject;

    // Player
    [SerializeField]private PlayerMovement player;
    private int lives;
    public TextMeshProUGUI Livestext;
    
    
    // Start is called before the first frame update
    void Start()
    {
        // Player
        lives = player.playerLevelLives;
        textObject = GameObject.Find("Livestext");
        Livestext = textObject.GetComponent<TextMeshProUGUI>();

        //ScoreSystem
        textObject = GameObject.Find("Scoretext");
        Scoretext = textObject.GetComponent<TextMeshProUGUI>();
        Scoretext.text = "Score: " + score;
        
        //EndScreen
        Debug.Log("im GameManager");
        PlayerPrefs.SetInt("score",5);
        PlayerPrefs.SetFloat("time",10.50f);
        PlayerPrefs.SetFloat("iets anders", PlayerPrefs.GetFloat("iets anders") + 1);
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.text = "     " + score;
        if (Input.GetKeyDown(KeyCode.K))
        {
            score += 15;
        }

        lives = player.playerLevelLives;
        Livestext.text = "     " + lives;
    }
    
    public void LoadNextScene()
    {
        //This will load the next scene in the build settings (edit with ctrl + shift + b)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    
    public void PlayAgain()
    {
        SceneManager.LoadScene("Finn");
    }
    
    public void Win()
    {
        Debug.Log("Win");
        SceneManager.LoadScene(5);
    }
    
    public void Lose()
    {
        Debug.Log("Lose");
        SceneManager.LoadScene(6);
    }
}
