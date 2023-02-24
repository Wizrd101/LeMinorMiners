using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ToxicBullets : MonoBehaviour
{
    Rigidbody2D rb;

    public float bulletSpeed;

    void Start()
    {
        if (PlayerPrefs.GetInt("diff") == 1)
        {
            bulletSpeed = 3f;
        }
        else if (PlayerPrefs.GetInt("diff") == 2)
        {
            bulletSpeed = 6f;
        }
        else
        {
            bulletSpeed = 9f;
        }

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-bulletSpeed, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
