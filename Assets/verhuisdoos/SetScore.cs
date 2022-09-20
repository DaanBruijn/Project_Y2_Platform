using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetScore : MonoBehaviour
{
    [SerializeField]private TMP_Text score;
    [SerializeField]private TMP_Text time;
    [SerializeField]private TMP_Text iets;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: " + PlayerPrefs.GetInt("score");
        time.text = "Time: " + PlayerPrefs.GetFloat("time");
        iets.text = "Iets anders: " + PlayerPrefs.GetFloat("iets anders");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
