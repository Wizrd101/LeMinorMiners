using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void TutorialStart()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void LevelOneStart()
    {
        SceneManager.LoadScene("LevelOneScene");
    }

    public void LevelTwoStart()
    {
        SceneManager.LoadScene("LevelTwoScene");
    }

    public void LevelThreeStart()
    {
        SceneManager.LoadScene("LevelThreeScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
