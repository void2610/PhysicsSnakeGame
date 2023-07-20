using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float SPEED = 1.0f;
    private Rigidbody2D rb;
    private Vector2 moveDirection = Vector2.up;
    private Vector2 headDirection = Vector2.up;
    private Vector2 oldHeadDirection = Vector2.up;

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
        headDirection = Vector2.zero;
        if(Input.GetKey(KeyCode.W))
        {
            moveDirection += Vector2.up;
            headDirection += Vector2.up;
        }
        if(Input.GetKey(KeyCode.S))
        {
            moveDirection += Vector2.down;
            headDirection += Vector2.down;
        }
        if(Input.GetKey(KeyCode.A))
        {
            moveDirection += Vector2.left;
            headDirection += Vector2.left;
        }
        if(Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector2.right;
            headDirection += Vector2.right;
        }

        if(headDirection.Equals(Vector2.zero))
        {
            headDirection = oldHeadDirection;
        }
        rb.velocity = moveDirection * SPEED;
        Quaternion targetRotation = Quaternion.Euler(0, 0, Mathf.Atan2(headDirection.y, headDirection.x) * Mathf.Rad2Deg - 90);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * 10);
        oldHeadDirection = headDirection;
    }
}
