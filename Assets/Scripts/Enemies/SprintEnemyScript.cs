using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintEnemyScript : MonoBehaviour
{
    [Header("Transform")] 
    [SerializeField] private Transform originPoint;
    [SerializeField] private Transform originPoint2;
    [SerializeField] private Transform originPoint3;

    [Header("Floats")] 
    [SerializeField] private float range;
    [SerializeField] private float setSpeed;
    [SerializeField] private float currentSpeed;

    [Header("Player Detect")] 
    [SerializeField] private float playerRange;
    [SerializeField] private float speedMod;

    private Vector2 _playerDir = new Vector2(-1, 0);
    private Vector2 _dir = new Vector2(-1, 0);
    private Rigidbody2D _rb;
    private PlayerMovement _pm;


    private void Awake()
    {
        currentSpeed = 2f;
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _pm = GameObject.Find("Player").GetComponent<PlayerMovement>();
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
                setSpeed *= -1;
                speedMod *= -1;
                _dir *= -1;
                _playerDir *= -1;
            }
        }
        
        //Ground Detect
        RaycastHit2D hitGround = Physics2D.Raycast(originPoint2.position, _dir, range);
        if (hitGround)
        {
            if (hitGround.collider.CompareTag("Floor"))
            {
                Flip();
                setSpeed *= -1;
                speedMod *= -1;
                _dir *= -1;
                _playerDir *= -1;
            }
        }
        
        RaycastHit2D hitPlayer = Physics2D.Raycast(originPoint3.position, _playerDir, playerRange);
        if (hitPlayer)
        {
            if (hitPlayer.collider.CompareTag("PlayerDetect"))
            {
                currentSpeed = speedMod;
            }
            else if (!hitPlayer.collider.CompareTag("PlayerDetect"))
            {
                currentSpeed = setSpeed;
            }
        }
    }

    void FixedUpdate()
    {
        _rb.velocity = new Vector2(currentSpeed, _rb.velocity.y);
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}