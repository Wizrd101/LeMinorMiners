using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinAndLose : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
