using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float timeLeft = 20;
    public TextMeshProUGUI Timeleft;
    private GameObject timeObject;
    public bool onGoing = true;
    public GameManager GM;
    public bool GameEnded = false;
    private bool GameEnding = false;
    public bool hasTimer = true;
    //GameObject score = GameObject.Find("GameManager");
    //public int exscore;
    // Start is called before the first frame update
    void Start()
    {
        
        timeObject = GameObject.Find("Timeleft");
        Timeleft = timeObject.GetComponent<TextMeshProUGUI>();
        //CountdownTimer exscore = score.GetComponent<GameManager>();
    
    if(!hasTimer)
    {
        GameObject.Find("Timeleft").SetActive(false);
        //GameObject.Find("Collectablestext").transform.position = new Vector3(100, 155, 0);
    }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasTimer)
        {
	        Timeleft.text = "     " + Mathf.Round(timeLeft);
	        if (onGoing)
	        {
	        timeLeft -= Time.deltaTime;
	        PlayerPrefs.SetInt("time", (int)timeLeft);
	        }
	        if (GameEnded && GameEnding == false)
	        {
	            
	            GameEnding = true;
	            GM.IncreaseScore(Mathf.Round(timeLeft));
	            onGoing = false;
	        }
	        if ( timeLeft < 0 )
	        {
	            onGoing = false;
	            Debug.Log("you lose");
                GM.Lose();
	        }
        }

        else
        {
            
        }
    }
}
