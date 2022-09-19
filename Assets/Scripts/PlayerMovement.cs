using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float currentMovementSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float maxJumps;
    [SerializeField] private float jumpAmount;
    [SerializeField] private bool gameOver;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool groundPoundReady;
    [SerializeField] private bool isGroundPound;
    [SerializeField] private bool groundPoundFall;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            jumpAmount = maxJumps;
            isGrounded = true;
            if (isGroundPound == true)
            {
                isGroundPound = false;
                groundPoundFall = false;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
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

        if (gameOver == false && isGroundPound == false)
        {
            // Walking
            transform.Translate(inputX * currentMovementSpeed * Time.deltaTime, 0, 0);

            // Turning
            if (inputX < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);

            }
            else if (inputX > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                
            }

            // Jumping

            if (jumpAmount >= 1)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    rb.velocity = new Vector3(0, 0, 0);
                    rb.AddForce(new Vector2(0, jumpPower), ForceMode2D.Force);
                    jumpAmount = jumpAmount - 1;
                    isGrounded = false;
                    StartCoroutine(GroundPoundJumpDelay(0.1f));
                }
            }

            // Sprinting
            if (isGrounded == true)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    currentMovementSpeed = sprintSpeed;
                }
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                currentMovementSpeed = walkSpeed;
            }

            // Air Bash
            if (isGrounded == false)
            {
                if (Input.GetKeyDown(KeyCode.S) && groundPoundReady == true)
                {
                    currentMovementSpeed = walkSpeed;
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                    isGroundPound = true;
                    StartCoroutine(GroundPoundTime(0.3f));
                }
            }
        }
        
        // Makes you wait midair before you ground pound
        IEnumerator GroundPoundTime(float delay)
        {
            yield return new WaitForSeconds(delay);
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.AddForce(new Vector2(0, -jumpPower), ForceMode2D.Force);
        }

        // Gives delay to Ground Pound after you jump
        IEnumerator GroundPoundJumpDelay(float delay)
        {
            groundPoundReady = false;
            yield return new WaitForSeconds(delay);
            groundPoundReady = true;
        }
    }
}
