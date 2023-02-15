using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class InstructionMenu : MonoBehaviour
{
    // Sets the Difficulty Level. 1 = Easy, 2 = Normal, 3 = Hard
    public int diff = 2;
    public TextMeshProUGUI diffTxt;

    // Sets the Controls style. 1 = PC (Keyboard), 2 = Mobile (On-Screen)
    public int cont = 1;
    public TextMeshProUGUI contTxt;

    void Start()
    {
        
    }

    public void SetEasyMode()
    {
        diff = 1;
        diffTxt.text = "Difficulty Mode: Easy";
    }

    public void SetNormalMode()
    {
        diff = 2;
        diffTxt.text = "Difficulty Mode: Normal";
    }

    public void SetHardMode()
    {
        diff = 3;
        diffTxt.text = "Difficulty Mode: Hard";
    }

    public void SetPCControls()
    {
        cont = 1;
        diffTxt.text = "Controls Type: Keyboard";
    }

    public void SetMobileControls()
    {
        cont = 2;
        diffTxt.text = "Controls Type: On-Screen";
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}

