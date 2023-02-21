using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IBMGAI : MonoBehaviour
{
    // TODO: 
    // ALL: Add the animator triggers into the mix

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;

    public bool fightTriggered = false;

    public Transform point1;
    public Transform point2;
    public Transform point3;
    int goToPoint;
    int previousPoint;

    public Transform player;
    public float moveSpeed = 3f;

    bool lunging = false;
    float lungeTimer;
    float lungeTimerTrigger;

    // Complete
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        goToPoint = Random.Range(1, 4);

        ResetLungeTimer();
    }

    // Complete
    void Update()
    {
        if (fightTriggered && Time.timeScale == 1)
        {
            lungeTimer += Time.deltaTime;
            if (lungeTimer > lungeTimerTrigger)
            {
                Lunge();
                ResetLungeTimer();
            }
        }
    }

    // Test the Sprite flipping
    void FixedUpdate()
    {
        if (fightTriggered)
        {
            if (Time.timeScale == 1)
            {
                MoveToPoint();
            }

            Vector2 playerToBoss = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
            if (playerToBoss.x >= 0)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
        }
    }

    // Complete
    void OnTriggerEnter2D(Collider2D other)
    {
        if (goToPoint != previousPoint)
        {
            previousPoint = goToPoint;
        
            if (previousPoint == 1)
            {
                goToPoint = Random.Range(2, 4); 
            }
            else
            {
                goToPoint = Random.Range(1, 3);
                if (previousPoint == 2 && goToPoint == 2)
                {
                    goToPoint = 3;
                }
            }
            Debug.Log("Move point reset, new move point: " + goToPoint);
        }
    }

    // Complete
    void MoveToPoint()
    {
        if (fightTriggered && !lunging && Time.timeScale == 1)
        {
            if (goToPoint == 1)
            {
                Vector2 moveDir = new Vector2(point1.transform.position.x - transform.position.x, point1.transform.position.y - transform.position.y);
                moveDir.Normalize();
                rb.velocity = moveDir * moveSpeed;
            }
            else if (goToPoint == 2)
            {
                Vector2 moveDir = new Vector2(point2.transform.position.x - transform.position.x, point2.transform.position.y - transform.position.y);
                moveDir.Normalize();
                rb.velocity = moveDir * moveSpeed;
            }
            else
            {
                Vector2 moveDir = new Vector2(point3.transform.position.x - transform.position.x, point3.transform.position.y - transform.position.y);
                moveDir.Normalize();
                rb.velocity = moveDir * moveSpeed;
            }
        }
    }

    // Incomplete
    void Lunge()
    {
        lunging = true;
        anim.SetTrigger("Attack");
        Vector2 lungeVector = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        lungeVector.Normalize();
        rb.velocity = lungeVector;
    }

    // Complete
    void ResetLungeTimer()
    {
        if (PlayerPrefs.GetInt("diff") == 1)
        {
            lungeTimerTrigger = Random.Range(10f, 15f);
        }
        else if (PlayerPrefs.GetInt("diff") == 2)
        {
            lungeTimerTrigger = Random.Range(7.5f, 12.5f);
        }
        else
        {
            lungeTimerTrigger = Random.Range(5f, 10f);
        }
    }
}
