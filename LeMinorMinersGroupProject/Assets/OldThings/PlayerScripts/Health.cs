using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{


    public int health = 10;
    public Slider slider;
    public static bool isDead = false;

    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            //reload the level
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            isDead= true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hostile")
        {
            health -= 10;

        }
    }
}
