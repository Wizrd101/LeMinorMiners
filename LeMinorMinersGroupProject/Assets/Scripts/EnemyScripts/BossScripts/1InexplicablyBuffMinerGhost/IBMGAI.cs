using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IBMGAI : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public Transform point1;
    public Transform point2;
    public Transform point3;
    int goToPoint;
    int previousPoint;

    public Transform player;
    public float speed = 3f;

    float lungeTimer;
    float lungeTimerTrigger;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        goToPoint = Random.Range(1, 4);
        MoveToPoint();

        lungeTimerTrigger = Random.Range(7.5f, 12.5f);
    }

    void Update()
    {
        if (Time.timeScale == 1)
        {
            lungeTimer = Time.deltaTime;
            if (lungeTimer > lungeTimerTrigger)
            {
                Lunge();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
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

        MoveToPoint();
    }

    void MoveToPoint()
    {
        if (goToPoint == 1)
        {

        }
        else if (goToPoint == 2)
        {

        } 
        else
        {

        }
    }

    void Lunge()
    {

    }
}
