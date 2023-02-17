using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoText : MonoBehaviour
{

    public PlayerShoot playerShoot;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        UpdateAmmoText();
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateAmmoText();
    }


    public void UpdateAmmoText()
    {
        text.text = $"Ammo: {playerShoot.currentMag} | {playerShoot.currentReserves} ";
    }
}
