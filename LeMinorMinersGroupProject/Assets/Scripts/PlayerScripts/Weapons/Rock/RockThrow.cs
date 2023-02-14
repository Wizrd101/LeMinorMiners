using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThrow : MonoBehaviour
{
    public GameObject rockPrefab;
    public Transform playerTransform;

    public float launchForceX;
    public float launchForceY;
    public Transform shotPoint;

    public int ammo = 10;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (ammo > 0)
        {
            GameObject newBomb = Instantiate(rockPrefab, shotPoint.position, shotPoint.rotation);
            if (playerTransform.localScale.x == 1)
            {
                newBomb.GetComponent<Rigidbody2D>().velocity = new Vector2(launchForceX, launchForceY);
            }
            else
            {
                newBomb.GetComponent<Rigidbody2D>().velocity = new Vector2(-launchForceX, launchForceY);
            }
            ammo--;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DynamitePickup")
        {
            ammo += 4;
        }
    }
}

