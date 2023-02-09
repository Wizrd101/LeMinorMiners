using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiteThrow : MonoBehaviour
{
    public GameObject dynamitePrefab;
    public Transform playerTransform;

    public float launchForceX;
    public float launchForceY;
    public Transform shotPoint;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject newBomb = Instantiate(dynamitePrefab, shotPoint.position, shotPoint.rotation);
        if (playerTransform.localScale.x == 1)
        {
            newBomb.GetComponent<Rigidbody2D>().velocity = new Vector2(launchForceX, launchForceY);
        }
        else
        {
            newBomb.GetComponent<Rigidbody2D>().velocity = new Vector2(-launchForceX, launchForceY);
        }
    }
}
