using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptJump : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField] private Transform originPoint;
    [SerializeField] private Transform originPoint2;

    [Header("Floats")]
    [SerializeField] private float range;
    [SerializeField] private float speed;
    [SerializeField] private float JumpPower;

    [Header("Animator")]
    [SerializeField] private Animator animator;

    private Vector2 _dir = new Vector2(-1, 0);
    private Rigidbody2D _rb;
    private bool hasJumped;
    


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Wall Detect
        RaycastHit2D hitWall = Physics2D.Raycast(originPoint.position, _dir, range);
        if (hitWall)
        {
            if (hitWall.collider.CompareTag("Floor") || hitWall.collider.CompareTag("Enemy"))
            {
                Flip();
                speed *= -1;
                _dir *= -1;
            }
        }

        
        //Ground Detect
        RaycastHit2D hitGround = Physics2D.Raycast(originPoint2.position, _dir, range);
        if (hitGround && !hasJumped)
        {
            hasJumped = true;

            if (hitGround.collider.CompareTag("Floor"))
            {
                _rb.AddForce(new Vector2(0, JumpPower), ForceMode2D.Force);
                print(JumpPower);
            }
            
        }

        if (!hitGround)
        {
            hasJumped = false;
        }


        // Check Velocity / Animation Bools
        if (_rb.velocity.y >= -0.5f && _rb.velocity.y <= 0.5f)
        {
            animator.SetBool("jumping", false);
            animator.SetBool("falling", false);
        }
        else if (_rb.velocity.y > 0.5f)
        {
            animator.SetBool("jumping", true);
            animator.SetBool("falling", false);
        }
        else if (_rb.velocity.y < -0.5f)
        {
            animator.SetBool("jumping", false);
            animator.SetBool("falling", true);
        }

    }

    void FixedUpdate()
    {
        _rb.velocity = new Vector2(speed, _rb.velocity.y);
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
