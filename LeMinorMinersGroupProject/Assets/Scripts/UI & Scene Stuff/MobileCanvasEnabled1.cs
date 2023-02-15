using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileCanvasEnabled1 : MonoBehaviour
{
    public Canvas mobileCanvas;

    void Start()
    {
        if (PlayerPrefs.GetInt("cont") == 2)
        {
            mobileCanvas.enabled = true;
        }
        else
        {
            mobileCanvas.enabled = false;
        }
    }
}
