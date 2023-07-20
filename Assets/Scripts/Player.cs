using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float SPEED = 1.0f;
    private Rigidbody2D rb;
    private Vector2 moveDirection = Vector2.up;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            moveDirection += Vector2.up;
        }
        if(Input.GetKey(KeyCode.S))
        {
            moveDirection += Vector2.down;
        }
        if(Input.GetKey(KeyCode.A))
        {
            moveDirection += Vector2.left;
        }
        if(Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector2.right;
        }
        rb.velocity = moveDirection * SPEED;
    }
}
