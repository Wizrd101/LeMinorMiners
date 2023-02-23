using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ULTRAI : MonoBehaviour
{
    ULTRFightTrigger ft;
    public TextMeshProUGUI bossText;
    public Slider bossSlider;

    Rigidbody2D rb;
    Animator anim;

    public Transform player;

    public float fireTimer;
    public float fireSpeed;

    public bool fightTriggered = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        ResetFireRate();
    }

    void FixedUpdate()
    {
        if (fightTriggered)
        {
            fireTimer = Time.deltaTime;
            if (fireTimer < fireSpeed)
            {
                fireTimer = 0;
                //Fire a Bullet
                ResetFireRate();
            }
        }
    }

    void ResetFireRate()
    {
        if (PlayerPrefs.GetInt("diff") == 1)
        {
            fireSpeed = Random.Range(3f, 5f);
        }
        else if (PlayerPrefs.GetInt("diff") == 1)
        {
            fireSpeed = Random.Range(2f, 4f);
        }
        else
        {
            fireSpeed = Random.Range(1f, 3f);
        }
    }
}
