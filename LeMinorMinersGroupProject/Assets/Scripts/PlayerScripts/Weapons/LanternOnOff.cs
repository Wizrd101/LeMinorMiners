using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternOnOff : MonoBehaviour
{
    public Light lanternOnLight;
    public Light lanternOffLight;

    public float oilAmount;
    public float usageRate;

    void Start()
    {
        lanternOnLight.enabled = false;
        lanternOffLight.enabled = true;
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            LanternDoStuff();
        }

        if (lanternOnLight.enabled)
        {
            oilAmount -= usageRate * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "OilPickup")
        {
            oil += 100;
        }
    }

    public void LanternDoStuff()
    {
        if (lanternOnLight.enabled == true)
        {
            lanternOnLight.enabled = false;
            lanternOffLight.enabled = true;
        }
        else
        {
            if (oil > 0)
            {
                lanternOnLight.enabled = true;
                lanternOffLight.enabled = false;
            }
        }
    }
}
