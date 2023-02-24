using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class AbyssBullets : MonoBehaviour
{
    ARAI ResidentAI;

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

        Vector2 targetPos = ResidentAI.player.transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(targetPos.x - transform.position.x, targetPos.y - transform.position.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}