using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Slider bossHealthSlider;

    public int currentHealth;
    public int maxHealth;

    Scene currentScene;
    int sceneIndex;

    void Start()
    {
        // Getting which boss it is
        currentScene = SceneManager.GetActiveScene();
        sceneIndex = currentScene.buildIndex - 1;

        // Variables
        maxHealth = 30 + (PlayerPrefs.GetInt("diff") * 40) + (sceneIndex * 10);
        currentHealth = maxHealth;

        // Slider
        bossHealthSlider.maxValue = maxHealth;
        bossHealthSlider.value = currentHealth;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        string otherTag = other.gameObject.tag;
        if (other.gameObject.tag == "PlayerBullet")
        {
            currentHealth--;
            if (currentHealth <= 0)
            {
                if (sceneIndex == 1)
                {
                    PlayerPrefs.SetInt("Level2Unlock", 1);
                    SceneManager.LoadScene("LevelTwoScene");
                }
                else if (sceneIndex == 2)
                {
                    PlayerPrefs.SetInt("Level3Unlock", 1);
                    SceneManager.LoadScene("LevelThreeScene");
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
