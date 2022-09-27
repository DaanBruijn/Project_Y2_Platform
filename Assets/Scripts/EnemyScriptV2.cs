using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptV2 : MonoBehaviour
{
    [Header("Transform")] 
    [SerializeField] private Transform originPoint;
    [SerializeField] private Transform originPoint2;

    [Header("Floats")] 
    [SerializeField] private float range;
    [SerializeField] private float speed;
    
    private Vector2 _dir = new Vector2(-1, 0);
    private Rigidbody2D _rb;
    
    
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
            if (hitWall.collider.CompareTag("Floor"))
            {
                Flip();
                speed *= -1;
                _dir *= -1;
            }
        }
        
        //Ground Detect
        RaycastHit2D hitGround = Physics2D.Raycast(originPoint2.position, _dir, range);
        if (hitGround)
        {
            if (hitGround.collider.CompareTag("Floor"))
            {
                Flip();
                speed *= -1;
                _dir *= -1;
            }
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
