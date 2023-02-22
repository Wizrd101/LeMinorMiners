using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlickeringLight : MonoBehaviour
{
    float intensity;
    float intensityMax;
    float intensityMin;

    Light2D light1;

    void Start()
    {
        light1 = GetComponent<Light2D>();
        intensity = light1.intensity;
        intensityMax = (float)(intensity + 0.15);
        intensityMin = (float)(intensity - 0.15);
    }

    void Update()
    {
        intensity = Random.Range(intensityMin, intensityMax);
        light1.intensity = intensity;
    }
}
