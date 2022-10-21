using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed = 10;
    private float direction = 1;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.parent = null;
        player = GameObject.Find("Player");
        direction = player.transform.localScale.x * 0.5f;// * 0.5 is for size
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, 0, 0);
    }

    //used to change the direction of a bullet mid flight
    public void SetDirection(float newDirection)
    {
        direction = newDirection;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("colided with" + other.gameObject.tag);
        if (other.gameObject.tag == "Floor")
        {
            Destroy(gameObject); 
        }

        else if (other.gameObject.tag == "Enemy")
        {
            //called when an enemy is hit by projectiles
            Destroy(other.gameObject);
            Destroy(gameObject); 
        }
    }

    
}
