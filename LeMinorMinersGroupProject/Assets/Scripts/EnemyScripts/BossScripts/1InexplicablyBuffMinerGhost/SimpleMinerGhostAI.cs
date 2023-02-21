using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMinerGhostAI : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public Transform player;

    public float moveSpeed = 3.0f;

    public bool fightTriggered = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Vector2 moveDir = player.position - transform.position;
        moveDir.Normalize();
        rb.velocity = moveDir * moveSpeed;
        if (moveDir.x >= 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        anim.SetTrigger("Attack");
    }
}
