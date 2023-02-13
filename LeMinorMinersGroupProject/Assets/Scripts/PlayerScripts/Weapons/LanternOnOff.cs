using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LanternOnOff : MonoBehaviour
{
    public Light2D lanternOnLight;
    public Light2D lanternOffLight;

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
            oilAmount = Mathf.Clamp(oilAmount, 0, 500);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "OilPickup")
        {
            oilAmount += 100;
            oilAmount = Mathf.Clamp(oilAmount, 0, 500);
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
            if (oilAmount > 0)
            {
                lanternOnLight.enabled = true;
                lanternOffLight.enabled = false;
            }
        }
    }
}
