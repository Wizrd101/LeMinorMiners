using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerShoot playerShoot = collision.gameObject.GetComponentInChildren<PlayerShoot>();
        if (playerShoot)
        {
            playerShoot.AddRounds(playerShoot.maxReserveSize);
            Destroy(gameObject);
        }
    }
} 

