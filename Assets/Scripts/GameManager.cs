using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI Scoretext;
    private GameObject textObject;
    
    
    // Start is called before the first frame update
    void Start()
    {

        //ScoreSystem
        textObject = GameObject.Find("Scoretext");
        Scoretext = textObject.GetComponent<TextMeshProUGUI>();
        Scoretext.text = "Score: " + PlayerPrefs.GetInt("score");
        
        //EndScreen
        Debug.Log("im GameManager");
        PlayerPrefs.SetInt("score",0);
        PlayerPrefs.SetFloat("time",10.50f);
        PlayerPrefs.SetFloat("iets anders", PlayerPrefs.GetFloat("iets anders") + 1);
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.text = "Score: " + PlayerPrefs.GetInt("score");
        //Debug.Log(score);
    }
    
    public void LoadNextScene()
    {
        //This will load the next scene in the build settings (edit with ctrl + shift + b)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    
    public void PlayAgain()
    {
        //load to finn-audio for ease of use (change to main scene later)
        SceneManager.LoadScene("Finn-audio");
    }
    
    public void Win()
    {
        SceneManager.LoadScene("Win");
    }

    public void Lose()
    {
        SceneManager.LoadScene("Lose");
    }

    public void IncreaseScore(int scoreToAdd)
        {
            score += scoreToAdd;
            PlayerPrefs.SetInt("score", score);
        }    
}
