using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider;

    public int currentHealth;
    public int maxHealth;

    void Start()
    {
        // Variables
        if (PlayerPrefs.GetInt("diff") == 1)
        {
            maxHealth = 15;
        }
        else if (PlayerPrefs.GetInt("diff") == 2)
        {
            maxHealth = 12;
        }
        else
        {
            maxHealth = 10;
        }
        currentHealth = maxHealth;

        // Slider
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        string otherTag = other.gameObject.tag;
        if (otherTag == "Enemy" || otherTag == "EnemyDamage" || otherTag == "Boss" || otherTag == "PoisonPool")
        {
            currentHealth--;
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene("LoseScene");
            }
            else
            {
                healthSlider.value = currentHealth;
            }
        }
    }
}