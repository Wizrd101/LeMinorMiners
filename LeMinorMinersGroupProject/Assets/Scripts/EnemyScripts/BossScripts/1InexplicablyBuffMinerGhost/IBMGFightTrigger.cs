using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IBMGFightTrigger : MonoBehaviour
{
    SimpleMinerGhostAI simpleAI;
    IBMGAI complexAI;

    public bool usingSimpleAI = true;
    public bool usingComplexAI = false;

    public GameObject boss;

    public Canvas bossInfo;

    void Start()
    {
        simpleAI = boss.GetComponent<SimpleMinerGhostAI>();
        complexAI= boss.GetComponent<IBMGAI>();

        bossInfo = boss.GetComponent<Canvas>();
        bossInfo.enabled = false;
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
        Debug.Log("Fight was triggered");
    }
}
