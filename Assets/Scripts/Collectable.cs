using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public float scoreToAdd = 5;
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            soundManager.PlayGoodSound();
            gameManager.IncreaseScore(scoreToAdd);
            Destroy(gameObject);
        }   
    }
}
