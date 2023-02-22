using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprint : MonoBehaviour
{

    /// <summary>
    ///
    ///you will need to create another script named PlayerVariable with this line of code: public static bool isRunning;
    ///need a game object to represent the stamina bar/circle/whatever you want
    ///movement script
    ///code for if the player is not running,(!PlayerVariable.isRunning)
    ///code for if the player is running,(PlayerVariable.isRunning)
    /// </summary>
    public float totalStamina;
    public float stamina;
    public GameObject staminaBar;

    // Start is called before the first frame update
    void Start()
    {
        stamina = totalStamina;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && stamina > 0 ) 
        {
            PlayerVariable.isRunning = true;
            stamina -= 0.5f;
        }
        else
        {
            PlayerVariable.isRunning = false;
        }
        if(stamina < 100 && !Input.GetKey(KeyCode.LeftShift))
        {
            stamina += 0.25f;
        }

        if(staminaBar != null)
        {
            staminaBar.transform.localScale = new Vector2(stamina / totalStamina, staminaBar.transform.localScale.y);
        }
    }
}
