using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SimpleMinerGhostAI : MonoBehaviour
{
    IBMGFightTrigger ft;
    public TextMeshProUGUI bossText;
    public Slider bossSlider;

    Rigidbody2D rb;
    Animator anim;

    public Transform player;

    public float moveSpeed;

    public bool fightTriggered = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (PlayerPrefs.GetInt("diff") == 1)
        {
            moveSpeed = 1.5f;
        }
        else if (PlayerPrefs.GetInt("diff") == 1)
        {
            moveSpeed = 2f;
        }
        else
        {
            moveSpeed = 2.5f;
        }
    }

    void FixedUpdate()
    {
        if (fightTriggered)
        {
            Vector2 moveDir = player.position - transform.position;
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

            anim.SetFloat("XMove", moveDir.x);
            anim.SetFloat("YMove", moveDir.y);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        anim.SetTrigger("Attack");
    }
}
