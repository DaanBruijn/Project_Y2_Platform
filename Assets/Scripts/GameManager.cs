using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float score = 0f;

    public TextMeshProUGUI Scoretext;
    private GameObject textObject;
    // Start is called before the first frame update
    void Start()
    {
        textObject = GameObject.Find("Scoretext");
        Scoretext = textObject.GetComponent<TextMeshProUGUI>();
        Scoretext.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.text = "Score: " + score;
        if (Input.GetKeyDown(KeyCode.K))
        {
            score += 15;
        }
    }
}
