using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement Input
    float inputX;
    float inputY;

    [Header("GameManager")]
    [SerializeField] private GameManager gameManager;

    [Header("PlayerLives")]
    public int playerLevelLives;
    [SerializeField] private int playerGameLives;
    [SerializeField] private bool invincible;


    [Header("Animator")]
    [SerializeField]private Animator animator;

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
    [SerializeField] private bool knockbackFromLeft;
    [SerializeField] private bool knockbackFromRight;
    [SerializeField] private bool knockedBack;
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
            animator.SetBool("jumping", true);
            isGrounded = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
            animator.SetBool("grounded", false);
            StartCoroutine(WallSlideDelay(0.2f));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!invincible)
        {
            if (playerLevelLives > 1)
            {
                if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Obstacle")
                {
                    Debug.Log("Hit");
                    playerLevelLives -= 1;
                    KnockBackHit();
                    StartCoroutine(invincibleTime(3));
                }
            }
            else if (playerLevelLives == 1)
            {
                if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Obstacle")
                {
                    gameManager.Lose();
                }
            }
        }
        if (collision.gameObject.tag == "DeathBox")
        {
            gameManager.Lose();
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            currentMovementSpeed = walkSpeed;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(7, 5), ForceMode2D.Impulse);
            StartCoroutine(KnockedBackTime(1.5f));
        }

        if (gameOver == false && !isGroundPound && !wallJumping && !knockedBack)
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
            AnimatorBoolCheck();
            
        }
    }

    private void LateUpdate()
    {
        //Raycast wall detection
        DetectRaycastLeft();
        DetectRaycastRight();
    }
    // Movement Functions    

    // Walking
    void Walking()
    {
        if (!knockedBack)
        {
            Vector2 playerVelocity = new Vector2(inputX * currentMovementSpeed, rb.velocity.y);
            rb.velocity = playerVelocity;
        }
        if (inputX != 0 && isGrounded)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
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
            animator.SetBool("grounded", false);
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
            animator.SetBool("wallSliding", false);
        }

        //Left Wall
        if (leftWallSlide)
        {
            print("leftwalljump");
            transform.localScale = new Vector3(1, 1, 1);
            wallJumping = true;
            rb.velocity = new Vector2(currentMovementSpeed, 10);
            StartCoroutine(WallJumpTimer(0.5f));
            animator.SetBool("wallSliding", false);
        }
    } 
    void AnimatorBoolCheck()
    {
        if (jumpAmount == 0 && animator.GetBool("jumping") && !isGrounded)
        {
            animator.SetBool("doubleJumping", true);
            animator.SetBool("falling", false);

        }
        else
        {
            animator.SetBool("doubleJumping", false);
        }

        if (rb.velocity.y > 2)
        {
            animator.SetBool("jumping", true);
            animator.SetBool("falling", false);
        }
        else if (rb.velocity.y < -2)
        {
            animator.SetBool("jumping", false);
            animator.SetBool("falling", true);
        }
        else
        {
            animator.SetBool("falling", false);
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
                animator.Play("Fall");
                animator.SetBool("groundPound", true);
                StartCoroutine(GroundPoundTime(0.3f));
            }
        }
    }
    void KnockBackHit()
    {
        if (knockbackFromLeft)
        {
            // laat de player naar rechts schieten
            print("Schiet naar rechts");
            currentMovementSpeed = walkSpeed;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(7, 5), ForceMode2D.Impulse);
            StartCoroutine(KnockedBackTime(1.5f));
        }
        else if (knockbackFromRight)
        {
            // laat de player naar links schieten
            print("Schiet naar rechts");
            currentMovementSpeed = walkSpeed;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(-7, 5), ForceMode2D.Impulse);
            StartCoroutine(KnockedBackTime(1.5f));
        }
        else
        {
            // laat de player recht omhoog schieten
            print("Schiet naar boven");
            currentMovementSpeed = walkSpeed;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(-2, 10), ForceMode2D.Impulse);
            StartCoroutine(KnockedBackTime(1.5f));
        }
    }

    // Ground detect
    void DetectGround()
    {
        print("ground");
        jumpAmount = maxJumps;
        isGrounded = true;
        wallSlideReady = false;
        leftWallSlide = false;
        rightWallSlide = false;
        animator.SetBool("grounded", true);
        animator.SetBool("groundPound", false);
        animator.SetBool("jumping", false);
        if (isGroundPound == true)
        {
            isGroundPound = false;
            groundPoundFall = false;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    // Raycasting
    void DetectRaycastLeft()
    {
        // Raycast naar links
        Debug.DrawLine(transform.position + new Vector3(-0.75f, 0.5f), transform.position + new Vector3(-0.75f, -0.95f), Color.blue);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position + new Vector3(-0.73f, 0.5f), Vector2.down, 1.4f);
        if (hitLeft)
        {
            print("Hit left");
            if (hitLeft.collider.CompareTag("Floor") && !wallJumping)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                if (wallSlideReady && inputX == -1)
                {
                    leftWallSlide = true;
                    Vector2 playerVelocity = new Vector2(0, -wallSlideSpeed);
                    rb.velocity = playerVelocity;
                    print("Wallslide");
                    animator.SetBool("wallSliding", true);
                }
            }
            else if (hitLeft.collider.CompareTag("Enemy") || hitLeft.collider.CompareTag("Obstacle"))
            {
                print("hit enemy left");
                knockbackFromLeft = true;
            }
        }
        else
        {
            leftWallSlide = false;
            knockbackFromLeft = false;
            animator.SetBool("wallSliding", false);

        }
    }
    void DetectRaycastRight()
    {
        // Raycast naar rechts
        Debug.DrawLine(transform.position + new Vector3(0.73f, 0.5f), transform.position + new Vector3(0.73f, -0.95f), Color.blue);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position + new Vector3(0.73f, 0.5f), Vector2.down, 1.4f);
        if (hitRight)
        {
            print("Hit right");
            if (hitRight.collider.CompareTag("Floor") && !wallJumping)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                if (wallSlideReady && inputX == 1)
                {
                    rightWallSlide = true;
                    Vector2 playerVelocity = new Vector2(0, -wallSlideSpeed);
                    rb.velocity = playerVelocity;
                    animator.SetBool("wallSliding", true);
                }
            }
            else if (hitRight.collider.CompareTag("Enemy") || hitRight.collider.CompareTag("Obstacle"))
            {
                print("hit enemy Right");
                knockbackFromRight = true;
            }
        }
        
        else
        {
            rightWallSlide = false;
            knockbackFromRight = false;
            
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
        IEnumerator invincibleTime(float time)
        {
            invincible = true;
            yield return new WaitForSeconds(time);
            invincible = false;
        }
        IEnumerator KnockedBackTime(float time)
        {
            knockedBack = true;
            animator.SetBool("gotHit", true);
            yield return new WaitForSeconds(time);
            animator.SetBool("gotHit", false);
            animator.Play("Idle");
            knockedBack = false;
        }
}
