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
    //GameObject score = GameObject.Find("GameManager");
    //public int exscore;
    // Start is called before the first frame update
    void Start()
    {
        timeObject = GameObject.Find("Timeleft");
        Timeleft = timeObject.GetComponent<TextMeshProUGUI>();
        //CountdownTimer exscore = score.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Timeleft.text = "     " + Mathf.Round(timeLeft);
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (onGoing)
            {
                onGoing = false;
            }
            else
            {
                onGoing = true;
            }
        }
        if (onGoing)
        {
        timeLeft -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GM.score += Mathf.Round(timeLeft);
            onGoing = false;
        }
        if ( timeLeft < 0 )
        {
            onGoing = false;
            Debug.Log("you lose");
        }
    }
}
