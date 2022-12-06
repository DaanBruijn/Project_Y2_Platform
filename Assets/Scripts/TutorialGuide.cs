using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialGuide : MonoBehaviour
{
    public TextMeshProUGUI GuideText;
    private GameObject guideObject;
    // Start is called before the first frame update
    void Start()
    {
        guideObject = GameObject.Find("Guidetext");
        GuideText = guideObject.GetComponent<TextMeshProUGUI>();
        StartCoroutine(Firstmessages());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Firstmessages()
    {
        GuideText.text = "Welcome to the tutorial level my name is Frosty and i will be your guide to help you get started";
        yield return new WaitForSeconds(7);
        GuideText.text = "You can use the arrow keys or AD to move left and right and you can use W or Space bar to jump";
    }
}
