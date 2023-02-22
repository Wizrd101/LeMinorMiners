using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    Slider bossHealthSlider;

    public int currentHealth;
    public int maxHealth;

    Scene currentScene;
    public int sceneIndex;

    void Start()
    {
        // Getting which boss it is
        currentScene = SceneManager.GetActiveScene();
        sceneIndex = currentScene.buildIndex - 1;

        // Variables
        if (PlayerPrefs.GetInt("diff") == 1)
        {

        }
        else if (PlayerPrefs.GetInt("diff") == 2)
        {

        }
        else
        {

        }

        // Slider
        bossHealthSlider = GetComponent<Slider>();
        bossHealthSlider.maxValue = maxHealth;
        bossHealthSlider.value = currentHealth;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            // CHANGE THIS
            currentHealth--;
            // CHANGE THIS
            if (currentHealth <= 0)
            {
                if (sceneIndex == 1)
                {

                }
                else if (sceneIndex == 2)
                {

                }
                else if (sceneIndex == 3)
                {
                    SceneManager.LoadScene("WinScene");
                }
            }
            else
            {
                bossHealthSlider.value = currentHealth;
            }
        }
    }
}
