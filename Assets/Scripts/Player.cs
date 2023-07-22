using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject BodyPrefab;
    public int bodyCount{get; private set;} = 0;
    private GameObject[] bodies = new GameObject[100];

    private const float SPEED = 1.0f;
    private Rigidbody2D rb;
    private Vector2 moveDirection = Vector2.up;
    private Vector2 headDirection = Vector2.up;
    private Vector2 oldHeadDirection = Vector2.up;



    public void extendBody()
    {
        GameObject body = Instantiate(BodyPrefab);
        bodies[bodyCount] = body;

        body.transform.position = this.transform.position;
        body.transform.Translate(Vector3.down * bodyCount);

        body.GetComponent<DistanceJoint2D>().connectedBody = bodies[bodyCount-1].GetComponent<Rigidbody2D>();


        bodyCount++;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bodies[0] = this.gameObject;
        bodyCount=1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            extendBody();
        }
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
