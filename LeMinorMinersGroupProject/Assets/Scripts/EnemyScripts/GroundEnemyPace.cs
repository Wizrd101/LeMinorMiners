using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
// Also should have two colliders: one for the main body (the normal one)
// and a trigger collider just in front of where the enemy is facing

public class GroundEnemyPace : MonoBehaviour
{
    LanternOnOff lanternScript;
    public bool lanternOn;

    public GameObject player;

    public float patrolSpeed = 0.8f;
    public float patrolRange = 3.0f;

    public float chaseSpeed = 2.0f;
    public float chaseTriggerDist = 3.0f;

    Vector3 startingPosition;
    float startingX;
    public bool goToStart = false;

    int dir = 1;

    bool goingOnGround = true;

    Rigidbody2D rb;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        lanternScript = player.GetComponent<LanternOnOff>();
        startingPosition = transform.position;
        startingX = transform.position.x;
    }

    void Update()
    {
        lanternOn = lanternScript.lanternIsOn;
    }

    void FixedUpdate()
    {
        Vector3 playerPosition = player.transform.position;
        Vector2 chaseDir = new Vector2 (playerPosition.x - transform.position.x, playerPosition.y - transform.position.y);
        Vector3 scale = transform.localScale;
        if (chaseDir.magnitude <= chaseTriggerDist)
        {
            // If the lantern is on, the enemy is scared and runs away.
            if (lanternOn)
            {
                Vector2 chaseVector = new Vector2(playerPosition.x - transform.position.x, 0);
                chaseVector.Normalize();
                if (goingOnGround)
                {
                    rb.velocity = -chaseVector * chaseSpeed;
                }
                if (-chaseVector.x > 0)
                {
                    scale.x = 1;
                }
                else
                {
                    scale.x = -1;
                }
                transform.localScale = scale;
                Debug.Log("Lantern Scawy");
            }
            //If the player is in range, chase them
            else
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
                Debug.Log("I'm coming for your toes");
            }
        }
        // otherwise, patrol the area
        else
        {
            Vector2 distToStart = transform.position - startingPosition;
            // If we're too far away from our patrol starting spot (from chasing) go back home
            if (distToStart.magnitude > patrolRange || distToStart.x <= 0 || goToStart)
            {
                goToStart = true;
                if (distToStart.x > 0)
                {
                    dir = -1;
                    scale.x = -1;
                }
                else
                {
                    if (dir == -1 || scale.x == -1)
                    {
                        dir = 1;
                        scale.x = 1;
                    }
                }
                transform.localScale = scale;
                if (transform.position.x <= startingX)
                {
                    goToStart = false;
                }
                Debug.Log("Headed Home");
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
                Debug.Log("I'm on the lookout");
            }
            // If enemy is on the ground, go forward
            if (goingOnGround)
            {
                transform.Translate(Vector2.right * patrolSpeed * Time.deltaTime * dir);
                Debug.Log("I'm firmly on the ground");
            }
            // If not, turn around
            else
            {
                dir *= -1;
                scale.x = dir;
                transform.localScale = scale;
                Debug.Log("Turning around");
            }
        }

        //animator stuff
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            goingOnGround = true;
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            goingOnGround = false;
        }
    }
}