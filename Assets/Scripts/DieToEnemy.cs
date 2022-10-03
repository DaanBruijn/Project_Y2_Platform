using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieToEnemy : MonoBehaviour
{
    [SerializeField]private GameManager gameManager;
    void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Debug.Log("dead");
                gameManager.Lose();
            }
            else if (collision.gameObject.tag == "Obstacle")
            {
                Debug.Log("dead");
                gameManager.Lose();
            }
        }
    
    
}
