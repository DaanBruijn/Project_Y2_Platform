using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Cube : MonoBehaviour
{
    public CountdownTimer TMR;
    // [SerializeField] private GameObject CountdownTimer;
    // Start is called before the first frame update
    void Start()
    {
        TMR = GameObject.Find("CountdownTimer").GetComponent<CountdownTimer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            TMR.GameEnded = true;
        }
    }
}
