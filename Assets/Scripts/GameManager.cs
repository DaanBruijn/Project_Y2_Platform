using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 5;

    public TextMeshProUGUI Scoretext;
    private GameObject textObject;
    
    
    // Start is called before the first frame update
    void Start()
    {
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
        if (Input.GetKeyDown(KeyCode.K))
        {
            score += 15;
            Scoretext.text = "Score: " + score;
        }
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
