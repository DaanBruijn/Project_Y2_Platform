using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement Input
    float inputX;
    float inputY;

    [Header("Rigidbody")]
    [SerializeField] private Rigidbody2D rb;
    
    [Header("Movement-Speeds")]
    [SerializeField] private float currentMovementSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float wallSlideSpeed;

    [Header("Jumps")]
    [SerializeField] private float jumpPower;
    [SerializeField] private float maxJumps;
    [SerializeField] private float jumpAmount;
    
    [Header("Bools")]
    [SerializeField] private bool gameOver;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool groundPoundReady;
    [SerializeField] private bool isGroundPound;
    [SerializeField] private bool groundPoundFall;
    [SerializeField] private bool wallSlideReady;
    [SerializeField] private bool leftWallSlide;
    [SerializeField] private bool rightWallSlide;
    [SerializeField] private bool wallJumping;
    [SerializeField] private bool wallJumpFalling;






    [Header("Raycast")]
    [SerializeField] private Transform lookDirection;


    void OnTriggerEnter2D(Collider2D other)
    {
        // Grounded / Jump Reset
        if (other.gameObject.CompareTag("Floor"))
        {
            DetectGround();
        }

        if (other.gameObject.CompareTag("Enemy") && isGroundPound)
        {
            Destroy(other.gameObject);
            DetectGround();
            Jumping();
            isGrounded = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
            StartCoroutine(WallSlideDelay(0.2f));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        if (gameOver == false && !isGroundPound && !wallJumping)
        {
            // Movement Functions
            Walking();
            Turning();
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                Jumping();
            }
            Sprinting();
            GroundPound();

            //Raycast wall detection
            DetectWallLeft();
            DetectWallRight();
        }
    }
        // Movement Functions    

        // Walking
    void Walking()
    {
        Vector2 playerVelocity = new Vector2(inputX * currentMovementSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;
    }
    void Turning()
    {
        if (inputX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }
        else if (inputX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
    }
    void Jumping()
    {
        // Jumping
        if (jumpAmount >= 1 && (!rightWallSlide && !leftWallSlide))
        {
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(new Vector2(0, jumpPower), ForceMode2D.Force);
            jumpAmount = jumpAmount - 1;
            isGrounded = false;
            StartCoroutine(GroundPoundJumpDelay(0.1f));
            StartCoroutine(WallSlideDelay(0.5f));
        }

        //Wall Jump

        //Right Wall
        if (rightWallSlide)
        {
            print("rightwalljump");
            transform.localScale = new Vector3(-1, 1, 1);
            wallJumping = true;
            rb.velocity = new Vector2(-currentMovementSpeed, 10);
            StartCoroutine(WallJumpTimer(0.5f));
        }

        //Left Wall
        if (leftWallSlide)
        {
            print("leftwalljump");
            transform.localScale = new Vector3(1, 1, 1);
            wallJumping = true;
            rb.velocity = new Vector2(currentMovementSpeed, 10);
            StartCoroutine(WallJumpTimer(0.5f));
        }
    } 
    void Sprinting()
    {
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
    }
    void GroundPound()
    {
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

    // Ground detect
    void DetectGround()
    {
        jumpAmount = maxJumps;
        isGrounded = true;
        wallSlideReady = false;
        leftWallSlide = false;
        rightWallSlide = false;
        if (isGroundPound == true)
        {
            isGroundPound = false;
            groundPoundFall = false;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    // Raycasting
    void DetectWallLeft()
    {
        // Raycast naar links
        Debug.DrawLine(transform.position + new Vector3(-0.75f, 0.5f), transform.position + new Vector3(-0.75f, -0.95f), Color.blue);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position + new Vector3(-0.73f, 0.5f), Vector2.down, 1.40f);
        if (hitLeft)
        {
            if (hitLeft.collider.CompareTag("Floor") && !wallJumping)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                if (wallSlideReady && inputX == -1)
                {
                    leftWallSlide = true;
                    Vector2 playerVelocity = new Vector2(0, -wallSlideSpeed);
                    rb.velocity = playerVelocity;
                }
            }
        }
        else
        {
            leftWallSlide = false;
        }
    }
    void DetectWallRight()
    {
        // Raycast naar rechts
        Debug.DrawLine(transform.position + new Vector3(0.73f, 0.5f), transform.position + new Vector3(0.73f, -0.95f), Color.blue);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position + new Vector3(0.73f, 0.5f), Vector2.down, 1.40f);
        if (hitRight)
        {
            if (hitRight.collider.CompareTag("Floor") && !wallJumping)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                if (wallSlideReady && inputX == 1)
                {
                    rightWallSlide = true;
                    Vector2 playerVelocity = new Vector2(0, -wallSlideSpeed);
                    rb.velocity = playerVelocity;
                }
            }
        }
        else
        {
            rightWallSlide = false;
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

        IEnumerator WallSlideDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            wallSlideReady = true;
        }

        IEnumerator WallJumpTimer(float delay)
        {
            yield return new WaitForSeconds(delay);
            wallJumping = false;
        }
}
