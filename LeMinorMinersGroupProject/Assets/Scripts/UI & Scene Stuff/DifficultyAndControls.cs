using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyAndControls : MonoBehaviour
{
    // Sets the Difficulty Level. 1 = Easy, 2 = Normal, 3 = Hard
    public TextMeshProUGUI diffTxt;

    // Sets the Controls style. 1 = PC (Keyboard), 2 = Mobile (On-Screen)
    public TextMeshProUGUI contTxt;

    // Awake sets whether the player has been to the settings menu before
    // If they have, then the values for diff and cont don't need to be reset
    void Awake()
    {
        if (PlayerPrefs.GetInt("beenToSettings") == 0)
        {
            PlayerPrefs.SetInt("diff", 2);
            PlayerPrefs.SetInt("cont", 1);
        }
    }

    void Start()
    {
        PlayerPrefs.SetInt("beenToSettings", 1);
        
        // Setting the starting Difficulty Text
        if (PlayerPrefs.GetInt("diff") == 1)
        {
            diffTxt.text = "Difficulty Mode: Easy";
        }
        else if (PlayerPrefs.GetInt("diff") == 2)
        {
            diffTxt.text = "Difficulty Mode: Normal";
        }
        else
        {
            diffTxt.text = "Difficulty Mode: Hard";
        }

        // Setting the starting Controls Text
        if (PlayerPrefs.GetInt("cont") == 1)
        {
            contTxt.text = "Controls Type: Keyboard";
        }
        else
        {
            contTxt.text = "Controls Type: On-Screen";
        }
    }

    public void SetEasyMode()
    {
        PlayerPrefs.SetInt("diff", 1);
        diffTxt.text = "Difficulty Mode: Easy";
    }

    public void SetNormalMode()
    {
        PlayerPrefs.SetInt("diff", 2);
        diffTxt.text = "Difficulty Mode: Normal";
    }

    public void SetHardMode()
    {
        PlayerPrefs.SetInt("diff", 3);
        diffTxt.text = "Difficulty Mode: Hard";
    }

    public void SetPCControls()
    {
        PlayerPrefs.SetInt("cont", 1);
        contTxt.text = "Controls Type: Keyboard";
    }

    public void SetMobileControls()
    {
        PlayerPrefs.SetInt("cont", 2);
        contTxt.text = "Controls Type: On-Screen";
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
