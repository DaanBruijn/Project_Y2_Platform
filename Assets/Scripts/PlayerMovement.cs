using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float runMultiplier;
    [SerializeField] private float jumpPower;
    [SerializeField] private float maxJumps;
    [SerializeField] private float jumpAmount;
    [SerializeField] private bool gameOver;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            jumpAmount = maxJumps;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if (gameOver == false)
        {
            // Walking
            transform.Translate(inputX * movementSpeed * Time.deltaTime, 0, 0);

            // Jumping

            if (jumpAmount >= 1)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    rb.velocity = new Vector3(0, 0, 0);
                    rb.AddForce(new Vector2(0, jumpPower), ForceMode2D.Force);
                    jumpAmount = jumpAmount - 1;
                }
            }

            // Sprinting
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                movementSpeed = movementSpeed * runMultiplier;
            }

            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                movementSpeed = movementSpeed / runMultiplier;
            }
        }
        
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Floor")
            {
                jumpAmount = maxJumps;
            }

        }
    }
}
