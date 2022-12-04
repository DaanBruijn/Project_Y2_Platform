using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField]private float horizontalPower = 0;
    [SerializeField]private float verticalPower = 10;
    [SerializeField]private float powerMultiplier = 1;
    private PlayerMovement playerMovement;
    [SerializeField]private float bounceTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {

        if (horizontalPower != 0)
        {
            if (other.gameObject.CompareTag ("Player"))
            {
                playerMovement = other.gameObject.GetComponent<PlayerMovement>();
                playerMovement.isBouncing = true;
                Invoke("ReturnMovement", bounceTime);
            }
        }
        Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
        
        rb.velocity = new Vector2(0, 0);
        
        rb.AddForce(new Vector2(horizontalPower * powerMultiplier, verticalPower * powerMultiplier), ForceMode2D.Impulse);
        
        
        Debug.Log(transform.rotation.x + transform.rotation.y + transform.rotation.z);
    }

    private void ReturnMovement()
    {
        playerMovement.isBouncing = false;
    }
}
