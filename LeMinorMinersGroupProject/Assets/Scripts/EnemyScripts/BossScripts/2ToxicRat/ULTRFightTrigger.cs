using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class ULTRFightTrigger : MonoBehaviour
{
    ULTRAI simpleAI;

    public bool usingSimpleAI;
    
    public Tile rocksTile;
    public Tilemap groundTilemap;

    public GameObject boss;

    public Canvas bossInfo;
    public TextMeshProUGUI bossNameText;
    public Slider healthSlider;

    BoxCollider2D triggerCollider;

    Vector3Int rocks1 = new Vector3Int(73, -89, 0);
    Vector3Int rocks2 = new Vector3Int(73, -90, 0);
    Vector3Int rocks3 = new Vector3Int(74, -89, 0);
    Vector3Int rocks4 = new Vector3Int(74, -90, 0);

    void Start()
    {
        simpleAI = boss.GetComponent<ULTRAI>();
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
        groundTilemap.SetTile(rocks1, rocksTile);
        groundTilemap.SetTile(rocks2, rocksTile);
        groundTilemap.SetTile(rocks3, rocksTile);
        groundTilemap.SetTile(rocks4, rocksTile);
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
