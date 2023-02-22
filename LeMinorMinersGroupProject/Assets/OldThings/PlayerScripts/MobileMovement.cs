using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class MobileMovement : MonoBehaviour
{
    public int moveDir = 2;
    public int mobileDir = 0;
    [SerializeField]
    public float moveSpeed = 2.0f;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator animator;
    public float jumpSpeed = 2.0f;
    bool grounded = false;

   
   
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody2D> ();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            int inputDir = (int)Input.GetAxisRaw("Horizontal");
            moveDir = inputDir + mobileDir;
            moveDir = Mathf.Clamp(moveDir, -15, 15);
            Vector2 velocity = rb.velocity;
            velocity.x = moveDir * moveSpeed;
            rb.velocity = velocity;

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
                animator.SetTrigger("Jump");
            }
            if (rb.velocity.y < -0.1f && !grounded)
            {
                animator.SetTrigger("Fall");
            }
            animator.SetFloat("xInput", moveDir);
            animator.SetBool("grounded", grounded);
            if (moveDir < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (moveDir > 0)
            {
                spriteRenderer.flipX = false;
            }
            if (moveDir > 0)
            {
                Vector3 scale = transform.localScale;
                scale.x = 0.4f;
                transform.localScale = scale;
            }
            if (moveDir < 0)
            {
                Vector3 scale = transform.localScale;
                scale.x = -0.4f;
                transform.localScale = scale;
            }
        }
    }

   
    public void UpdateMoveDirection (int direction)
    {
        mobileDir = direction;
      
    }

    public void Jump()
    {
        if (grounded)
        {
            rb.AddForce(new Vector2(0, 100 *jumpSpeed));
            grounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
