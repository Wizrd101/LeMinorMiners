using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDestroy : MonoBehaviour
{
    public float destroyTimer = 0.5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject, destroyTimer);
        }
    }
}
