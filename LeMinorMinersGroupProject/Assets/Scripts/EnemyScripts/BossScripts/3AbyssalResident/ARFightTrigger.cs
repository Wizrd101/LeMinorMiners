using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class ARFightTrigger : MonoBehaviour
{
    ARAI simpleAI;
    //IBMGAI complexAI;

    public bool usingSimpleAI = true;
    //public bool usingComplexAI = false;

    public Tile rocksTile;
    public Tilemap groundTilemap;

    public GameObject boss;

    public Canvas bossInfo;
    public TextMeshProUGUI bossNameText;
    public Slider healthSlider;

    BoxCollider2D triggerCollider;

    void Start()
    {
        simpleAI = boss.GetComponent<ARAI>();
        //complexAI = boss.GetComponent<IBMGAI>();

        bossInfo = boss.GetComponentInChildren<Canvas>();
        bossInfo.enabled = false;

        bossNameText = bossInfo.GetComponentInChildren<TextMeshProUGUI>();
        healthSlider = bossInfo.GetComponentInChildren<Slider>();

        triggerCollider = GetComponent<BoxCollider2D>();
        triggerCollider.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            FightTriggerEvents();
        }
    }

    public void FightTriggerEvents()
    {
        bossInfo.enabled = true;
        triggerCollider.enabled = false;
        if (usingSimpleAI)
        {
            simpleAI.fightTriggered = true;
        }

        /*if (usingComplexAI)
        {
            complexAI.fightTriggered = true;
        }*/
        Debug.Log("Fight was triggered");
    }
}
