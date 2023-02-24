using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ARAI : MonoBehaviour
{
    IBMGFightTrigger ft;
    public TextMeshProUGUI bossText;
    public Slider bossSlider;

    Rigidbody2D rb;
    Animator anim;

    public Transform player;

    public float moveSpeed;

    public GameObject abyssBullet;
    public Transform bulletPos;
    
    public float fireTimer;
    public float fireSpeed;

    public bool fightTriggered = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (PlayerPrefs.GetInt("diff") == 1)
        {
            moveSpeed = 2.5f;
        }
        else if (PlayerPrefs.GetInt("diff") == 1)
        {
            moveSpeed = 3f;
        }
        else
        {
            moveSpeed = 3.5f;
        }
    }

    void FixedUpdate()
    {
        if (fightTriggered)
        {
            fireTimer += Time.deltaTime;
            Vector2 moveDir = player.position - transform.position;
            moveDir.y = 0f;
            moveDir.Normalize();
            rb.velocity = moveDir * moveSpeed;
            if (moveDir.x >= 0)
            {
                Vector3 scale = transform.localScale;
                scale.x = -3;
                transform.localScale = scale;
                Vector3 textScale = bossText.transform.localScale;
                textScale.x = -0.5f;
                bossText.transform.localScale = textScale;
                Vector3 sliderScale = bossSlider.transform.localScale;
                sliderScale.x = -1.5f;
                bossSlider.transform.localScale = sliderScale;
            }
            else
            {
                Vector3 scale = transform.localScale;
                scale.x = 3;
                transform.localScale = scale;
                Vector3 textScale = bossText.transform.localScale;
                textScale.x = 0.5f;
                bossText.transform.localScale = textScale;
                Vector3 sliderScale = bossSlider.transform.localScale;
                sliderScale.x = 1.5f;
                bossSlider.transform.localScale = sliderScale;
            }

            if (fireTimer >= fireSpeed)
            {
                fireTimer = 0;
                Instantiate(abyssBullet, bulletPos.position, Quaternion.identity);
                ResetFireRate();
                Debug.Log("shoot");
            }

            anim.SetFloat("XMove", moveDir.x);
        }
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
