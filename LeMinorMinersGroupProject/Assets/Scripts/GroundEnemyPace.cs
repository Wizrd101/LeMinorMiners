using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class GroundEnemyPace : MonoBehaviour
{
    public GameObject player;

    public float patrolSpeed = 0.8f;
    public float patrolRange = 3.0f;

    public float chaseSpeed = 2.0f;
    public float chaseTriggerDist = 3.0f;

    Vector3 startingPosition;
    float startingX;
    bool goToStart = false;

    int dir = 1;

    Rigidbody2D rb;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        startingPosition = transform.position;
        startingX = transform.position.x;
    }

    void FixedUpdate()
    {
        Vector3 playerPosition = player.transform.position;
        Vector2 chaseDir = new Vector2 (playerPosition.x - transform.position.x, playerPosition.y - transform.position.y);
        if (chaseDir.magnitude <= chaseTriggerDist)
        {
            Vector2 chaseVector = new Vector2(playerPosition.x - transform.position.x, 0);
            chaseVector.Normalize();
            rb.velocity = chaseVector * chaseSpeed;
            Debug.Log("Chasing Player");
        }
        else
        {
            Vector2 distToStart = transform.position - startingPosition;
            if (distToStart.magnitude > patrolRange || goToStart)
            {
                goToStart = true;
                if (distToStart.x > 0)
                {
                    dir = -1;
                }
                else
                {
                    dir = 1;
                }
                if (transform.position.x < startingX)
                {
                    goToStart = false;
                }
                Debug.Log("Patroling, too far");
            }
            else
            {
                if (transform.position.x < startingX || transform.position.x > startingX + patrolRange)
                {
                    dir *= -1;
                }
                Debug.Log("Patroling, in range");
            }
            transform.Translate(Vector2.right * patrolSpeed * Time.deltaTime * dir);
            
        }

        //animator stuff
    }
}