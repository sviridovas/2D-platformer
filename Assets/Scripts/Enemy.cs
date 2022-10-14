using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    
    private Rigidbody2D _rigidbody2D;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.localScale.x > 0)
        {
            _rigidbody2D.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        transform.localScale = new Vector2(-Mathf.Sign(_rigidbody2D.velocity.x), 1f);
    }
}
