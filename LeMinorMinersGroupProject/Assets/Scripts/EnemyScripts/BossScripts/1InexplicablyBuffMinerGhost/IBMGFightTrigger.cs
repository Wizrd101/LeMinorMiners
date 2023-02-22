using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    BoxCollider2D triggerCollider;

    /*Vector3 rocks1;
    Vector3 rocks2;
    Vector3 rocks3;
    Vector3 rocks4;
    Vector3 rocks5;
    Vector3 rocks6;
    Vector3 rocks7;
    Vector3 rocks8;*/

    void Start()
    {
        simpleAI = boss.GetComponent<SimpleMinerGhostAI>();
        complexAI= boss.GetComponent<IBMGAI>();

        bossInfo = boss.GetComponent<Canvas>();
        bossInfo.enabled = false;

        triggerCollider.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (usingSimpleAI)
            {
                simpleAI.fightTriggered = true;
            }

            if (usingComplexAI)
            {
                complexAI.fightTriggered = true;
            }

            FightTriggerEvents();
        }
    }

    void FightTriggerEvents()
    {
        bossInfo.enabled = true;
        triggerCollider.enabled = false;
        //groundTilemap.SetTile(rocks1,rocksTile);
        Debug.Log("Fight was triggered");
    }
}
