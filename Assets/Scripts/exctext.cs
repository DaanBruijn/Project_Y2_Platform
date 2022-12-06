using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class exctext : MonoBehaviour
{
    [TextArea] public string text;
    public TextMeshProUGUI GuideText;
    private GameObject guideObject;
    // Start is called before the first frame update
    void Start()
    {
        guideObject = GameObject.Find("Guidetext");
        GuideText = guideObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SetText(string text) 
    {
        GuideText.text = text;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GuideText.text = text;
    }
}
