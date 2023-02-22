using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI menuDiffTxt;
    public TextMeshProUGUI menuContTxt;

    public Button LevelTwoButton;
    public Button LevelThreeButton;

    void Awake()
    {
        if (PlayerPrefs.GetInt("FirstTime") == 0)
        {
            PlayerPrefs.SetInt("Level2Unlock", 0);
            PlayerPrefs.SetInt("Level3Unlock", 0);
        }
    }

    void Start()
    {
        // Making it so that the locked levels don't reset their locks every time the scene is reloaded
        PlayerPrefs.SetInt("FirstTime", 1);

        // Setting Difficulty and Controls
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

        // Making the levels 2 and 3 locked or unlocked
        if (PlayerPrefs.GetInt("Level2Unlock") == 0)
        {
            LevelTwoButton.interactable = false;
        }
        else
        {
            LevelTwoButton.interactable = true;
        }

        if (PlayerPrefs.GetInt("Level3Unlock") == 0)
        {
            LevelThreeButton.interactable = false;
        }
        else
        {
            LevelThreeButton.interactable = true;
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
