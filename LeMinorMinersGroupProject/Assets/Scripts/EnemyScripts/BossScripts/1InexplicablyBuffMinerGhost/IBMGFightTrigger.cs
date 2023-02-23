using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class IBMGFightTrigger : MonoBehaviour
{
    SimpleMinerGhostAI simpleAI;
    IBMGAI complexAI;

    public bool usingSimpleAI = true;
    public bool usingComplexAI = false;

    public Tile rocksTile;
    public Tilemap groundTilemap;

    public GameObject boss;

    public Canvas bossInfo;
    public TextMeshProUGUI bossNameText;
    public Slider healthSlider;

    BoxCollider2D triggerCollider;

    Vector3Int rocks1 = new Vector3Int(85, -35, 0);
    Vector3Int rocks2 = new Vector3Int(85, -36, 0);
    Vector3Int rocks3 = new Vector3Int(85, -37, 0);
    Vector3Int rocks4 = new Vector3Int(85, -38, 0);
    Vector3Int rocks5 = new Vector3Int(86, -35, 0);
    Vector3Int rocks6 = new Vector3Int(86, -36, 0);
    Vector3Int rocks7 = new Vector3Int(86, -37, 0);
    Vector3Int rocks8 = new Vector3Int(86, -38, 0);

    void Start()
    {
        simpleAI = boss.GetComponent<SimpleMinerGhostAI>();
        complexAI= boss.GetComponent<IBMGAI>();

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
        groundTilemap.SetTile(rocks5, rocksTile);
        groundTilemap.SetTile(rocks6, rocksTile);
        groundTilemap.SetTile(rocks7, rocksTile);
        groundTilemap.SetTile(rocks8, rocksTile);
        if (usingSimpleAI)
        {
            simpleAI.fightTriggered = true;
        }

        if (usingComplexAI)
        {
            complexAI.fightTriggered = true;
        }
        Debug.Log("Fight was triggered");
    }
}
