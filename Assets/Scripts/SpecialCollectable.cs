using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCollectable : MonoBehaviour
{

    public string title;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("test1collected==" + PlayerPrefs.GetInt("Collectable1collected"));
       if (title == "Collectable1")
        {
            if (PlayerPrefs.GetInt("Collectable1collected") == 1)
            {
                gameObject.SetActive(false);
            }
        }
        if (title == "Collectable2")
        {
            if (PlayerPrefs.GetInt("Collectable2collected") == 1)
            {
                gameObject.SetActive(false);
            }
        }
        if (title == "Collectable3")
        {
            if (PlayerPrefs.GetInt("Collectable3collected") == 1)
            {
                gameObject.SetActive(false);
            }
        }
        if (title == "Collectable4")
        {
            if (PlayerPrefs.GetInt("Collectable4collected") == 1)
            {
                gameObject.SetActive(false);
            }
        }
        if (title == "Collectable5")
        {
            if (PlayerPrefs.GetInt("Collectable5collected") == 1)
            {
                gameObject.SetActive(false);
            }
        }
        if (title == "Collectable6")
        {
            if (PlayerPrefs.GetInt("Collectable6collected") == 1)
            {
                gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (title == "Collectable1")
            {
                PlayerPrefs.SetInt("Collectable1collected", 1);
                Destroy(gameObject);
            }
            else if (title == "Collectable2")
            {
                PlayerPrefs.SetInt("Collectable2collected", 1);
                Destroy(gameObject);
            }
            else if (title == "Collectable3")
            {
                PlayerPrefs.SetInt("Collectable3collected", 1);
                Destroy(gameObject);
            }
            else if (title == "Collectable4")
            {
                PlayerPrefs.SetInt("Collectable4collected", 1);
                Destroy(gameObject);
            }
            else if (title == "Collectable5")
            {
                PlayerPrefs.SetInt("Collectable5collected", 1);
                Destroy(gameObject);
            }
            else if (title == "Collectable6")
            {
                PlayerPrefs.SetInt("Collectable6collected", 1);
                Destroy(gameObject);
            }
        }
    }
}
