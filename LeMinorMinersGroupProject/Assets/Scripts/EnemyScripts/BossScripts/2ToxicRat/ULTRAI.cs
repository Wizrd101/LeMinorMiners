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

    public GameObject toxicBullet;
    public Transform bulletPos1;
    public Transform bulletPos2;
    public Transform bulletPos3;
    public Transform bulletPos4;
    public Transform bulletPos5;
    public int bulletTemp;

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
            fireTimer += Time.deltaTime;
            if (fireTimer >= fireSpeed)
            {
                fireTimer = 0;
                Shoot();
                ResetFireRate();
                Debug.Log("shoot");
            }
        }
    }

    void Shoot()
    {
        bulletTemp = Random.Range(0, 15);
        if (bulletTemp == 0 || bulletTemp == 1 || bulletTemp == 2 || bulletTemp == 3 || bulletTemp == 4)
        {
            Instantiate(toxicBullet, bulletPos1.position, Quaternion.identity);
        }
        else if (bulletTemp == 5 || bulletTemp == 6 || bulletTemp == 7 || bulletTemp == 8)
        {
            Instantiate(toxicBullet, bulletPos2.position, Quaternion.identity);
        }
        else if (bulletTemp == 9 || bulletTemp == 10 || bulletTemp == 11)
        {
            Instantiate(toxicBullet, bulletPos3.position, Quaternion.identity);
        }
        else if (bulletTemp == 12 || bulletTemp == 13)
        {
            Instantiate(toxicBullet, bulletPos4.position, Quaternion.identity);
        }
        else if (bulletTemp == 14)
        {
            Instantiate(toxicBullet, bulletPos5.position, Quaternion.identity);
        }

        anim.SetTrigger("Attack");

        Debug.Log("BulletSpawned");
    }

    void ResetFireRate()
    {
        if (PlayerPrefs.GetInt("diff") == 1)
        {
            fireSpeed = Random.Range(2f, 4f);
        }
        else if (PlayerPrefs.GetInt("diff") == 2)
        {
            fireSpeed = Random.Range(.75f, 2.25f);
        }
        else
        {
            fireSpeed = Random.Range(0.5f, 1f);
        }

        Debug.Log("Fire Rate Reset");
    }
}
