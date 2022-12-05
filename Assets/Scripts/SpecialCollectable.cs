using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpecialCollectable : MonoBehaviour
{
    public TextMeshProUGUI Collectablestext;
    private GameObject collectablesObject;
    private int collectablenr1;
    public string title;
    private bool colectablenr3collected = false;
    private bool canCollect = true;
    // Start is called before the first frame update
    void Start()
    {
        collectablesObject = GameObject.Find("Collectablestext");
        Collectablestext = collectablesObject.GetComponent<TextMeshProUGUI>();
        
        Debug.Log("test1collected==" + PlayerPrefs.GetInt("Collectable1collected"));
       if (title == "Collectable1")
        {
            if (PlayerPrefs.GetInt("Collectable1collected") == 1)
            {
                gameObject.SetActive(false);
                if(GameObject.Find("CollectableCount").GetComponent<CollectableCount>().maxCollectableCount == 1)
                { GameManager.Instance.collectablesCollected++; }
            }
        }
        if (title == "Collectable2")
        {
            if (PlayerPrefs.GetInt("Collectable2collected") == 1)
            {
                gameObject.SetActive(false);
                if (GameObject.Find("CollectableCount").GetComponent<CollectableCount>().maxCollectableCount == 2)
                { GameManager.Instance.collectablesCollected++; }
            }
        }
        if (title == "Collectable3")
        {
            if (PlayerPrefs.GetInt("Collectable3collected") == 1)
            {
                gameObject.SetActive(false);
                
                if (GameObject.Find("CollectableCount").GetComponent<CollectableCount>().maxCollectableCount == 2)
                { GameManager.Instance.collectablesCollected++; }
            }
        }
        if (title == "Collectable4")
        {
            if (PlayerPrefs.GetInt("Collectable4collected") == 1)
            {
                gameObject.SetActive(false);
                if (GameObject.Find("CollectableCount").GetComponent<CollectableCount>().maxCollectableCount == 3)
                { GameManager.Instance.collectablesCollected++; }
            }
        }
        if (title == "Collectable5")
        {
            if (PlayerPrefs.GetInt("Collectable5collected") == 1)
            {
                gameObject.SetActive(false);
                if (GameObject.Find("CollectableCount").GetComponent<CollectableCount>().maxCollectableCount == 3)
                { GameManager.Instance.collectablesCollected++; }
            }
        }
        if (title == "Collectable6")
        {
            if (PlayerPrefs.GetInt("Collectable6collected") == 1)
            {
                gameObject.SetActive(false);
                if (GameObject.Find("CollectableCount").GetComponent<CollectableCount>().maxCollectableCount == 3)
                { GameManager.Instance.collectablesCollected++; }
            }
        }
        Collectablestext.text = ("     " + GameManager.Instance.collectablesCollected + " / " + GameObject.Find("CollectableCount").GetComponent<CollectableCount>().maxCollectableCount);

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (canCollect)
            {
                Debug.Log("hit player");
                GameManager.Instance.collectablesCollected++;
                Collectablestext.text = ("     " + GameManager.Instance.collectablesCollected + " / " + GameObject.Find("CollectableCount").GetComponent<CollectableCount>().maxCollectableCount);

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
                    //colectablenr3collected = true;
                    //GameManager.Instance.collectablesCollected--;
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
                canCollect = false;
                StartCoroutine(canCollectcheck());
            }
        }
    }
    IEnumerator canCollectcheck()
    {
        yield return new WaitForSeconds(0.25f);
        canCollect = true;
    }
}
