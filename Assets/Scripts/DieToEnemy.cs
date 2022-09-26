using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieToEnemy : MonoBehaviour
{
    [SerializeField]private GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision) 
    {        
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("dead");
            gameManager.Lose();
        }

        if (collision.gameObject.tag == "Win")
        {
            Debug.Log("w");
            gameManager.Win();
        }
    }
}
