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
        time = GameObject.Find("Time_Text").GetComponent<TextMeshProUGUI>();
        score = GameObject.Find("scoreText").GetComponent<TextMeshProUGUI>();
        score.text = "Score: " + PlayerPrefs.GetInt("score");
        time.text = "Time: " + PlayerPrefs.GetInt("time");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
