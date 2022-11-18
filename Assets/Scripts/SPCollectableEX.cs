using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPCollectableEX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            PlayerPrefs.SetInt("Collectable1collected", 0);
            PlayerPrefs.SetInt("Collectable2collected", 0);
            PlayerPrefs.SetInt("Collectable3collected", 0);
            PlayerPrefs.SetInt("Collectable4collected", 0);
            PlayerPrefs.SetInt("Collectable5collected", 0);
            PlayerPrefs.SetInt("Collectable6collected", 0);
        }
    }
}
