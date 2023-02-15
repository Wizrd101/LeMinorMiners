using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundGroundEnemyMove : MonoBehaviour
{
    public GameObject player;
    MobileMove moveScript;
    RockProjectileDestroy rpd;
    DynamiteProjectileDestroy dpd;

    bool possiblyBored = false;

    public float patrolSpeed = 0.8f;
    public float patrolRange = 3.0f;

    public float chaseSpeed = 2.0f;
    public float smallChaseTriggerDist = 1.0f;
    public float chaseTriggerDist = 3.0f;

    Vector3 startingPosition;
    float startingX;
    bool goToStart = false;

    int dir = 1;

    bool goingOnGround = true;

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
        Vector2 chaseDir = new Vector2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y);
        Vector3 scale = transform.localScale;
        //If the player is in range, chase them
        // If the player is right next to the enemy, it can detect that
        if (chaseDir.magnitude <= smallChaseTriggerDist) 
        {
            Vector2 chaseVector = new Vector2(playerPosition.x - transform.position.x, 0);
            chaseVector.Normalize();
            if (goingOnGround)
            {
                rb.velocity = chaseVector * chaseSpeed;
            }
            if (chaseVector.x > 0)
            {
                scale.x = 1;
            }
            else
            {
                scale.x = -1;
            }
            transform.localScale = scale;

            possiblyBored = true;
        }
        // If a rock recently thrown is closer to enemy than the player, go to the rock
        else if (rpd.active)
        {
            Vector2 rockPos = rpd.rockHit;
            if (rockPos.magnitude <= chaseTriggerDist)
            {
                Vector2 chaseVector = new Vector2(rockPos.x - transform.position.x, 0);
                chaseVector.Normalize();
                if (goingOnGround)
                {
                    rb.velocity = chaseVector * chaseSpeed;
                }
                if (chaseVector.x > 0)
                {
                    scale.x = 1;
                }
                else
                {
                    scale.x = -1;
                }
                transform.localScale = scale;

                possiblyBored = true;
            }
        }
        // If the player is moving and in range, the enemy can detect them and chases
        else if (chaseDir.magnitude <= chaseTriggerDist && moveScript.moveDir != 0)
        {
            Vector2 chaseVector = new Vector2(playerPosition.x - transform.position.x, 0);
            chaseVector.Normalize();
            if (goingOnGround)
            {
                rb.velocity = chaseVector * chaseSpeed;
            }
            if (chaseVector.x > 0)
            {
                scale.x = 1;
            }
            else
            {
                scale.x = -1;
            }
            transform.localScale = scale;

            possiblyBored = true;
        }
        // otherwise, patrol the area
        else
        {
            Vector2 distToStart = transform.position - startingPosition;
            // If we're too far away from our patrol starting spot (from chasing) go back home
            if (distToStart.magnitude > patrolRange || goToStart)
            {
                goToStart = true;
                if (distToStart.x > 0)
                {
                    dir = -1;
                    scale.x = -1;
                }
                else
                {
                    dir = 1;
                    scale.x = 1;
                }
                transform.localScale = scale;
                if (transform.position.x < startingX)
                {
                    goToStart = false;
                }
            }
            // Otherwise, just patrol the area normally
            else
            {
                if (transform.position.x < startingX || transform.position.x > startingX + patrolRange)
                {
                    dir *= -1;
                    scale.x = dir;
                    transform.localScale = scale;
                }
            }
            // If enemy is on the ground, go forward
            if (goingOnGround)
            {
                transform.Translate(Vector2.right * patrolSpeed * Time.deltaTime * dir);
            }
            // If not, turn around
            else
            {
                dir *= -1;
                scale.x = dir;
                transform.localScale = scale;
            }

            possiblyBored = false;
        }

        /*if (possiblyBored && rb.velocity == (0, 0))
        {

        }*/

        //animator stuff
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            goingOnGround = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            goingOnGround = false;
        }
    }
}