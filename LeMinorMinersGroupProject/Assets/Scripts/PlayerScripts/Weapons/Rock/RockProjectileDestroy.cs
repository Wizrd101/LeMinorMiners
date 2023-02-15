using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockProjectileDestroy : MonoBehaviour
{
    public bool active = false;
    public Vector2 rockHit;

    void OnTriggerEnter2D(Collider2D other)
    {
        active = true;
        rockHit = transform.position;
        Destroy(gameObject);
        active = false;
    }
}
