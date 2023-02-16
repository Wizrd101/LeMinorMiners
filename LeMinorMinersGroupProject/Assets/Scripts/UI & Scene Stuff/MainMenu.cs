using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    DifficultyAndControls dac;

    public TextMeshProUGUI menuDiffTxt;
    public TextMeshProUGUI menuContTxt;

    void Start()
    {

        if (PlayerPrefs.GetInt("diff") == 1)
        {
            menuDiffTxt.text = "Difficulty: Easy";
        }
        else if (PlayerPrefs.GetInt("diff") == 2)
        {
            menuDiffTxt.text = "Difficulty: Normal";
        } 
        else
        {
            menuDiffTxt.text = "Difficulty: Hard";
        }

        if (PlayerPrefs.GetInt("cont") == 1)
        {
            menuContTxt.text = "Controls: Keyboard";
        }
        else
        {
            menuContTxt.text = "Controls: On-Screen";
        }
    }

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
    
    public void InstructionsStart()
    {
        SceneManager.LoadScene("InstructionsScene");
    }

    public void SettingsStart()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void Quit()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
