using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MobileMovement : MonoBehaviour
{
    bool movable = true;

    public int moveDir = 0;
    public float moveSpeed = 1.0f;
    public int mobileDir = 0;

    public float jumpSpeed = 4.0f;
    bool grounded = false;

    Rigidbody2D rb;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (movable)
        {
            moveDir = 0;
            int inputDir = (int)Input.GetAxisRaw("Horizontal");
            moveDir += inputDir + mobileDir;
            moveDir = Mathf.Clamp(moveDir, -1, 1);

            Vector2 velocity = rb.velocity;
            velocity.x = moveDir * moveSpeed;
            rb.velocity = velocity;

            anim.SetFloat("xInput", moveDir);

            if (moveDir > 0)
            {
                Vector3 scale = transform.localScale;
                scale.x = 1;
                transform.localScale = scale;
            }
            if (moveDir < 0)
            {
                Vector3 scale = transform.localScale;
                scale.x = -1;
                transform.localScale = scale;
            }

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
    }

    public void UpdateMoveDirection(int direction)
    {
        mobileDir = direction;
    }

    public void Jump()
    {
        if (grounded)
        {
            rb.AddForce(new Vector2(0, 100 * jumpSpeed));
            grounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
        }

        if (other.gameObject.tag == "WinCollider")
        {
            movable = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}